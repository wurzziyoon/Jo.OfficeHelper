using Jo.OfficeHelper.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jo.OfficeHelper.Business.ConfigUpdater
{
    public class ConfigUpdater
    {
        private static ConfigUpdater m_instance;
        private static object m_lockObj = new object();
        private OfficeHelperConfigDTO m_configDTO = null;
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
        private event Action<string, bool> m_onTaskFinished;
        public event Action<string, bool> OnTaskFinished
        {
            add
            {

                m_onTaskFinished += value;

            }
            remove
            {

                m_onTaskFinished -= value;

            }
        }
        private ConfigUpdater()
        {
            try
            {
                m_configDTO = (OfficeHelperConfigDTO)ConfigurationManager.GetSection("OfficeHelper");
            }
            catch (Exception e)
            {
                if (m_onError != null)
                {
                    m_onError.Invoke(e);
                }
            }
        }

        public static ConfigUpdater GetInstance()
        {
            if (m_instance == null)
            {
                lock (m_lockObj)
                {
                    if (m_instance == null)
                    {
                        m_instance = new ConfigUpdater();
                    }
                }
            }
            return m_instance;
        }

        public void StartUpdating()
        {
            if (m_configDTO == null)
            {
                if (m_onError != null)
                {
                    m_onError.Invoke(new Exception("Init config file error!"));
                }
            }
            else
            {
                foreach (var obj in m_configDTO.OfficeHelperConfig)
                {
                    ConfigUpdaterConfigDTO dto = obj as ConfigUpdaterConfigDTO;
                    UpdateTask task = new UpdateTask(dto);
                    task.UpdateFinished += (isSuccess) =>
                      {
                          if (this.m_onTaskFinished != null)
                          {
                              m_onTaskFinished.Invoke(task.Name, isSuccess);
                          }
                      };
                    task.OnError += (e) =>
                     {
                         if (this.m_onError != null)
                         {
                             m_onError.Invoke(e);
                         }
                     };
                    task.Invoke();
                }
            }
        }
    }
}
