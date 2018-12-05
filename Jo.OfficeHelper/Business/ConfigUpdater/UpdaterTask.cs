using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jo.OfficeHelper.DTO;
using System.IO;
using static Jo.OfficeHelper.Business.CommonBiz;

namespace Jo.OfficeHelper.Business.ConfigUpdater
{
    public class UpdaterTask
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
        public Encoding ConfigEncoding { get; set; }

        private event Action m_updateSuccessfully;
        event Action UpdateSuccessfully
        {
            add
            {
                lock (m_updateSuccessfully)
                {
                    m_updateSuccessfully += value;
                }
            }
            remove
            {
                lock (m_updateSuccessfully)
                {
                    m_updateSuccessfully -= value;
                }                
            }
        }

        private event Action<Exception> m_onError;
        event Action<Exception> OnError
        {
            add
            {
                lock (m_onError)
                {
                    m_onError += value;
                }
            }
            remove
            {
                lock (m_onError)
                {
                    m_onError -= value;
                }
            }
        }

        private event Action m_updateFinished;
        event Action UpdateFinished
        {
            add
            {
                lock (m_updateFinished)
                {
                    m_updateFinished += value;
                }
            }
            remove
            {
                lock (m_updateFinished)
                {
                    m_updateFinished -= value;
                }
            }
        }

        public UpdaterTask(ConfigUpdaterConfigDTO updateConfig)
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
            }
            else
            {
                if (m_onError!=null)
                {
                    m_onError.Invoke(new Exception($"Can not find file({this.ConfigFilePath})!"));
                }
            }            
        }

        public UpdaterTask(ConfigUpdaterConfigDTO updateConfig, Encoding configEncoding):this(updateConfig)
        {
            this.ConfigEncoding = configEncoding;
        }

        public void Invoke()
        {
            string str = File.ReadAllText(this.ConfigFilePath, this.ConfigEncoding);
        }

        
    }
}
