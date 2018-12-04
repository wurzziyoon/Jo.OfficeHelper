using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Jo.OfficeHelper.Business
{
    public class ProcessHelper:IDisposable
    {
        [DllImport("user32", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(
                int hwnd,
                int nCmdShow
        );
        private ProcessHelper()
        {
            m_processNameList = new List<string>();
        }
        private static object m_lockObj = new object();
        private static ProcessHelper m_instance;
        private bool m_status = false;
        private List<string> m_processNameList
        {
            get;
            set;
        }
        public static ProcessHelper GetInstance()
        {
            if (m_instance == null)
            {
                lock (m_lockObj)
                {
                    if (m_instance == null)
                    {
                        m_instance = new ProcessHelper();
                    }
                }
            }
            return m_instance;
        }
        public List<string> GetQuickHideProcessList()
        {
            return m_processNameList;
        }
        public void AddProcess(string name)
        {
            m_processNameList.Add(name);
            if (m_status)
            {
                HideProcess(name);
            }
        }

        public void RemoveProcess(string name)
        {
            List<string> tmp = new List<string>();
            foreach (string processName in m_processNameList)
            {
                if (processName != name)
                {
                    tmp.Add(processName);
                }
                else
                {
                    if (m_status)
                    {
                        ShowProcess(processName);
                    }
                }
            }
            m_processNameList = tmp;
        }

        public void Toggle()
        {
            if (m_status)
            {
                ShowAllProcess();
            }
            else
            {
                HideAllProcess();
            }
        }
        public void ShowAllProcess()
        {
            m_status = false;
            foreach (string processName in m_processNameList)
            {
                ShowProcess(processName);
            }
        }
        private void ShowProcess(string processName)
        {
            List<Process> listProcess = Process.GetProcesses().Where(t => t.ProcessName == processName).ToList();
            if (listProcess.Count == 0)
            {
                m_processNameList.Remove(processName);
            }
            foreach (Process p in listProcess)
            {
                ShowWindow((int)p.MainWindowHandle, 1);
            }
        }
        public void HideAllProcess()
        {
            m_status = true;
            foreach (string processName in m_processNameList)
            {
                HideProcess(processName);
            }
        }
        private void HideProcess(string processName)
        {
            List<Process> listProcess = Process.GetProcesses().Where(t => t.ProcessName == processName).ToList();
            if (listProcess.Count == 0)
            {
                m_processNameList.Remove(processName);
            }
            foreach (Process p in listProcess)
            {
                ShowWindow((int)p.MainWindowHandle, 0);
            }            
        }

        public void Dispose()
        {
            if (m_processNameList != null && m_processNameList.Count > 0)
            {
                ShowAllProcess();
            }
        }
    }
}
