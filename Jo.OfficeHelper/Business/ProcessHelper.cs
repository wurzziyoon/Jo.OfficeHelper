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
            m_processList = new List<Process>();
        }
        private static object m_lockObj = new object();
        private static ProcessHelper m_instance;
        private bool m_status = false;
        private List<Process> m_processList
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

        public void AddProcess(string name)
        {
            List<Process> process=Process.GetProcesses().Where((t) => t.ProcessName == name).ToList();
            foreach (Process p in process)
            {
                m_processList.Add(p);
                if (m_status)
                {
                    HideProcess(p.Id);
                }
            }
        }

        public void RemoveProcess(string name)
        {
            List<Process> tmp = new List<Process>();
            foreach (Process p in m_processList)
            {
                if (p.ProcessName != name)
                {
                    tmp.Add(p);
                }
                else
                {
                    if (m_status)
                    {
                        ShowProcess(p.Id);
                    }
                }
            }
            m_processList = tmp;
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
            foreach (Process p in m_processList)
            {
                ShowProcess((int)p.MainWindowHandle);
            }
        }
        private void ShowProcess(int hwnd)
        {
            ShowWindow(hwnd, 1);
        }
        public void HideAllProcess()
        {
            m_status = true;
            foreach (Process p in m_processList)
            {
                HideProcess((int)p.MainWindowHandle);
            }
        }
        private void HideProcess(int hwnd)
        {
            ShowWindow(hwnd, 0);
        }

        public void Dispose()
        {
            if (m_processList != null && m_processList.Count > 0)
            {
                ShowAllProcess();
            }
        }
    }
}
