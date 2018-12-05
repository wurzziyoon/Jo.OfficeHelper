using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jo.OfficeHelper.DTO
{
    public class ConfigUpdaterConfigDTO: ConfigurationSection
    {
        [ConfigurationProperty("Name",IsRequired =true,IsKey =false)]
        public string Name
        {
            get
            {
                return this["Name"].ToString();
            }
            set
            {
                this["Name"] = value;
            }
        }
        [ConfigurationProperty("MatchingText", IsRequired = false)]
        public string MatchingText
        {
            get
            {
                return this["MatchingText"].ToString();
            }
            set
            {
                this["MatchingText"] = value;
            }
        }

        [ConfigurationProperty("MatchingRegex", IsRequired = false)]
        public string MatchingRegex
        {
            get
            {
                return this["MatchingRegex"].ToString();
            }
            set
            {
                this["MatchingRegex"] = value;
            }
        }
        [ConfigurationProperty("ConfigFilePath", IsRequired = true)]
        public string ConfigFilePath
        {
            get
            {
                return this["ConfigFilePath"].ToString();
            }
            set
            {
                this["ConfigFilePath"] = value;
            }
        }
        [ConfigurationProperty("ReplaceText", IsRequired = false)]
        public string ReplaceText
        {
            get
            {
                return this["ReplaceText"].ToString();
            }
            set
            {
                this["ReplaceText"] = value;
            }
        }

        [ConfigurationProperty("ReplaceJavaScriptContent", IsRequired = false)]
        public string ReplaceJavaScriptContent
        {
            get
            {
                return this["ReplaceJavaScriptContent"].ToString();
            }
            set
            {
                this["ReplaceJavaScriptContent"] = value;
            }
        }

        [ConfigurationProperty("RestartServiceName", IsRequired = false)]
        public string RestartServiceName
        {
            get
            {
                return this["RestartServiceName"].ToString();
            }
            set
            {
                this["RestartServiceName"] = value;
            }
        }

        [ConfigurationProperty("RestartProcessName", IsRequired = false)]
        public string RestartProcessName
        {
            get
            {
                return this["RestartProcessName"].ToString();
            }
            set
            {
                this["RestartProcessName"] = value;
            }
        }

    }
}
