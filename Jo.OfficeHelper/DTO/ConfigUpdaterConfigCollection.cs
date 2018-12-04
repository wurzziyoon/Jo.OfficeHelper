using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jo.OfficeHelper.DTO
{
    public class ConfigUpdaterConfigCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// 创建新元素
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigUpdaterConfigDTO();
        }

        /// <summary>
        /// 获取元素的键
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigUpdaterConfigDTO)element).Name;
        }

        /// <summary>
        /// 获取所有键
        /// </summary>
        public IEnumerable<string> AllKeys { get { return BaseGetAllKeys().Cast<string>(); } }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public new ConfigUpdaterConfigDTO this[string name]
        {
            get { return (ConfigUpdaterConfigDTO)BaseGet(name); }
        }
    }
}
