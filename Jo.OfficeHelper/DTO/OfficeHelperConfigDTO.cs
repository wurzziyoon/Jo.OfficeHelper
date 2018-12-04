using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jo.OfficeHelper.DTO
{
    public class OfficeHelperConfigDTO: ConfigurationSection
    {
        [ConfigurationProperty("ConfigUpdaterConfig", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(ConfigUpdaterConfigDTO),AddItemName = "add")]
        public ConfigUpdaterConfigCollection OfficeHelperConfig
        {
            get
            {
                return (ConfigUpdaterConfigCollection)this["ConfigUpdaterConfig"];
            }
            set
            {
                this["ConfigUpdaterConfig"] = value;
            }
        }
    }
}
