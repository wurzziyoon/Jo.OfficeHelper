using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jo.OfficeHelper.Business
{
    public class CMDHelper:IDisposable
    {
        private static CMDHelper m_obj;
        private Process m_cmdProcess;


        private CMDHelper(string cmdPath)
        {
            Init(cmdPath);
        }
        private event Action<object, DataReceivedEventArgs> m_onOutputDataReceived;

        public event Action<object, DataReceivedEventArgs> OnOutputDataReceived
        {
            add
            {
                m_onOutputDataReceived += value;
            }
            remove
            {
                m_onOutputDataReceived -= value;
            }
        }
        private event Action<object, DataReceivedEventArgs> m_onErrorDataReceived;

        public event Action<object, DataReceivedEventArgs> OnErrorDataReceived
        {
            add
            {
                m_onErrorDataReceived += value;
            }
            remove
            {
                m_onErrorDataReceived -= value;
            }
        }

        private event Action m_onInited;

        public event Action OnInited
        {
            add
            {
                m_onInited += value;
            }
            remove
            {
                m_onInited -= value;
            }
        }

        private event Action<object, EventArgs> m_onDisposed;

        public event Action<object, EventArgs> OnDisposed
        {
            add
            {
                m_onDisposed += value;
            }
            remove
            {
                m_onDisposed -= value;
            }
        }
        private void Init(string cmdPath)
        {
            string filePath = string.IsNullOrWhiteSpace(cmdPath) ? @"c:\windows\system32\cmd.exe" : cmdPath;
            if (!File.Exists(filePath))
            {
                throw new Exception("Can not find cmd");
            }
            ProcessStartInfo startInfo = new ProcessStartInfo(filePath);
            startInfo.CreateNoWindow = true; //不创建窗口
            startInfo.UseShellExecute = false; //不使用系统外壳程序启动,重定向输出的话必须设为false
            startInfo.RedirectStandardOutput = true; //重定向输出，而不是默认的显示在dos控制台上
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;

            if (m_cmdProcess == null)
            {
                m_cmdProcess = Process.Start(startInfo);
                m_cmdProcess.OutputDataReceived +=
                    (sender, data) =>
                    {
                        if (m_onOutputDataReceived != null)
                        {
                            m_onOutputDataReceived.Invoke(sender, data);
                        }
                    };
                m_cmdProcess.ErrorDataReceived +=
                    (sender, data) =>
                    {
                        if (m_onErrorDataReceived != null)
                        {
                            m_onErrorDataReceived.Invoke(sender, data);
                        }
                    };
                m_cmdProcess.Disposed += (sender, e) => { if (m_onDisposed != null) m_onDisposed.Invoke(sender, e); };
                //SendCommand(" ");

                m_cmdProcess.EnableRaisingEvents = true;
                m_cmdProcess.BeginErrorReadLine();
                m_cmdProcess.BeginOutputReadLine();
            }
            if (m_onInited != null)
                m_onInited.Invoke();
        }
        public void DisposeAndExit()
        {
            m_cmdProcess.Kill();
            m_cmdProcess.Dispose();
            m_cmdProcess.Close();
        }

        public void SendCommand(string cmd)
        {
            m_cmdProcess.StandardInput.WriteLine(cmd);
        }
        public void SendNewLine()
        {
            m_cmdProcess.StandardInput.WriteLine(" ");
        }
        public static CMDHelper GetInstance(string cmdPath=null)
        {
            if (m_obj == null)
            {
                m_obj = new CMDHelper(cmdPath);
            }
            return m_obj;
        }

        public void Dispose()
        {
            m_obj.DisposeAndExit();
            m_obj = null;
        }
    }
}
