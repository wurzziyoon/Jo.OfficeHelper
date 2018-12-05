using Jo.OfficeHelper.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jo.OfficeHelper.Business
{
    public class ConfigUpdaterBiz
    {
        private static ConfigUpdaterBiz m_instance;
        private static object m_lockObj = new object();
        private OfficeHelperConfigDTO m_configDTO=null;
        event Action<Exception> OnError;
        event Action<List<ConfigUpdaterConfigDTO>> OnFinished;
        private ConfigUpdaterBiz()
        {
            try
            {
                m_configDTO = (OfficeHelperConfigDTO)ConfigurationManager.GetSection("OfficeHelper");
            }
            catch (Exception e)
            {
                if (OnError != null)
                {
                    OnError.Invoke(e);
                }
            }
        }

        public static ConfigUpdaterBiz GetInstance()
        {
            if (m_instance == null)
            {
                lock (m_lockObj)
                {
                    if (m_instance == null)
                    {
                        m_instance = new ConfigUpdaterBiz();
                    }
                }
            }
            return m_instance;
        }

        public void StartUpdating()
        {
            if (m_configDTO == null)
            {
                if (OnError != null)
                {
                    OnError.Invoke(new Exception("Init config file error!"));
                }
            }
            else
            {
                //TODO:添加更新操作

                OnFinished.Invoke(new List<ConfigUpdaterConfigDTO>());   //将更新结果返回
            }
        }

        public void RestartService(string serviceName)
        {

        }

        public void RestartProcessName(string processName)
        {

        }
    }
}
