using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jo.OfficeHelper.Interface
{
    interface IReleasable
    {
        void ReleaseResources(Dictionary<string, Stream> resources);

        bool CheckResources(Dictionary<string, Stream> resources);
    }
}
