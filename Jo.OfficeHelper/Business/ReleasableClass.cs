using Jo.OfficeHelper.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jo.OfficeHelper.Business
{
    public abstract class ReleasableClass : IReleasable
    {

        public bool CheckResources(Dictionary<string, Stream> resources)
        {
            foreach (string key in resources.Keys)
            {
                if (!File.Exists(Environment.CurrentDirectory + "\\" + key))
                {
                    return false;
                }
            }
            return true;
        }

        public void ReleaseResources(Dictionary<string, Stream> resources)
        {
            foreach (string key in resources.Keys)
            {
                string resourcePath = Environment.CurrentDirectory + "\\" + key;
                if (!File.Exists(resourcePath))
                {
                    using (FileStream fs = new FileStream(resourcePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        int content;
                        while ((content = resources[key].ReadByte()) != -1)
                        {
                            fs.WriteByte((byte)content);
                        }
                    }
                }
            }
        }
    }
}
