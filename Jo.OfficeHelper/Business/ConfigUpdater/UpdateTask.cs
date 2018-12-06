using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jo.OfficeHelper.DTO;
using System.IO;
using static Jo.OfficeHelper.Business.CommonBiz;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Management;

namespace Jo.OfficeHelper.Business.ConfigUpdater
{
    public class UpdateTask
    {
        public string ConfigFilePath { get; private set; }
        public string MatchingText { get; private set; }
        public string MatchingRegex { get; private set; }
        public string Name { get; private set; }
        public string ReplaceText { get; private set; }
        public string ReplaceJavaScriptContent { get; private set; }
        public string RestartServiceName { get; private set; }
        public string RestartProcessName { get; private set; }

        private Encoding m_configEncoding = Encoding.UTF8;
        public Encoding ConfigEncoding
        {
            get
            {
                return m_configEncoding;
            }
            set
            {
                m_configEncoding = value;
            }
        }

        private event Action m_updateSuccessfully;
        public event Action UpdateSuccessfully
        {
            add
            {
                m_updateSuccessfully += value;
            }
            remove
            {
                m_updateSuccessfully -= value;
            }
        }

        private event Action<Exception> m_onError;
        public event Action<Exception> OnError
        {
            add
            {
                m_onError += value;
            }
            remove
            {
                m_onError -= value;
            }
        }

        private event Action<bool> m_updateFinished;
        public event Action<bool> UpdateFinished
        {
            add
            {
                m_updateFinished += value;
            }
            remove
            {
                m_updateFinished -= value;
            }
        }

        public UpdateTask(ConfigUpdaterConfigDTO updateConfig)
        {
            if (updateConfig != null)
            {
                if (File.Exists(updateConfig.ConfigFilePath))
                {
                    this.Name = updateConfig.Name;
                    this.MatchingText = updateConfig.MatchingText;
                    this.MatchingRegex = updateConfig.MatchingRegex;
                    this.ConfigFilePath = updateConfig.ConfigFilePath;
                    this.ReplaceText = updateConfig.ReplaceText;
                    this.ReplaceJavaScriptContent = updateConfig.ReplaceJavaScriptContent;
                    this.RestartProcessName = updateConfig.RestartProcessName;
                    this.RestartServiceName = updateConfig.RestartServiceName;
                    if (string.IsNullOrWhiteSpace(MatchingRegex) && string.IsNullOrWhiteSpace(MatchingText))
                    {
                        if (m_onError != null)
                        {
                            m_onError.Invoke(new Exception("Can not matching condition!"));
                        }
                    }
                    if (string.IsNullOrWhiteSpace(ReplaceText) && string.IsNullOrWhiteSpace(ReplaceJavaScriptContent))
                    {
                        if (m_onError != null)
                        {
                            m_onError.Invoke(new Exception("Can not replace condition!"));
                        }
                    }
                }
                else
                {
                    if (m_onError != null)
                    {
                        m_onError.Invoke(new Exception($"Can not find file({this.ConfigFilePath})!"));
                    }
                }
            }
            else
            {
                m_onError.Invoke(new Exception("UpdateConfig can not be empty!"));
            }

        }

        public UpdateTask(ConfigUpdaterConfigDTO updateConfig, Encoding configEncoding) : this(updateConfig)
        {
            if (configEncoding != null)
            {
                this.ConfigEncoding = configEncoding;
            }
            else
            {
                m_onError.Invoke(new Exception("ConfigEncoding can not be empty!"));
            }
        }

        public void Invoke()
        {
            bool isSuccess = false;
            try
            {
                string str = File.ReadAllText(ConfigFilePath, ConfigEncoding);
                if (!string.IsNullOrWhiteSpace(MatchingText))
                {
                    if (!string.IsNullOrWhiteSpace(ReplaceText))
                    {
                        str = str.Replace(MatchingText, ReplaceText);
                    }
                    else
                    {
                        str = str.Replace(MatchingText, ReplaceJavaScriptContent.GetJSResult());
                    }
                }
                else
                {
                    Regex regex = new Regex(MatchingRegex, RegexOptions.Multiline | RegexOptions.Singleline);
                    MatchCollection matchCollection = regex.Matches(str);
                    string tmpStr = matchCollection.Count > 0 ? "" : str;
                    while (matchCollection.Count > 0)
                    {
                        Match firstMatch = matchCollection[0];
                        tmpStr += str.Substring(0, firstMatch.Index) + ReplaceJavaScriptContent.GetJSResult();
                        if (!string.IsNullOrWhiteSpace(ReplaceText))
                        {
                            str = str.Substring(firstMatch.Index + firstMatch.Length + 1);
                        }
                        else
                        {
                            str = str.Substring(firstMatch.Index + firstMatch.Value.Length);
                            
                        }                        
                        matchCollection = regex.Matches(str);
                    }
                    str = tmpStr;
                }
                if (!string.IsNullOrWhiteSpace(RestartServiceName))
                {
                    RestartService(RestartServiceName);
                }
                if (!string.IsNullOrWhiteSpace(RestartProcessName))
                {
                   List<string> list= GetCommandLines(RestartProcessName);
                    foreach (Process process in Process.GetProcessesByName(RestartProcessName))
                    {
                        Process newProcess = new Process();
                        newProcess.StartInfo = process.StartInfo;
                        process.Kill();
                        process.Close();
                        process.Dispose();
                        newProcess.Start();
                    }
                }
                File.WriteAllText(ConfigFilePath, str, ConfigEncoding);
                if (m_updateSuccessfully != null)
                {
                    m_updateSuccessfully.Invoke();
                }
                isSuccess = true;
            }
            catch (Exception e)
            {
                if (m_onError != null)
                {
                    m_onError.Invoke(e);
                }
            }
            finally
            {
                if (m_updateFinished != null)
                {
                    m_updateFinished(isSuccess);
                }
            }
        }

        private void RestartService(string serviceName)
        {
            CMDHelper cmd = CMDHelper.GetInstance();
            cmd.OnErrorDataReceived += (obj, e) =>
            {
                throw (new Exception(e.Data));
            };
            cmd.SendCommand($"sc stop {serviceName}");
            cmd.SendCommand($"sc start {serviceName}");
            cmd.DisposeAndExit();
        }

        private static List<string> GetCommandLines(string processName)
        {
            List<string> results = new List<string>();
            string wmiQuery = string.Format("PROCESS", processName);
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery))
            {
                using (ManagementObjectCollection retObjectCollection = searcher.Get())
                {
                    foreach (ManagementObject retObject in retObjectCollection)
                    {
                        results.Add((string)retObject["CommandLine"]);
                    }
                }
            }
            return results;
        }
    }
}
