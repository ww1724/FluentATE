using ATE.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common
{
    public class MefService : IAppService
    {
        public string Id => "Core.MefService";

        public string ServiceName => "插件服务";

        public bool IsRunning { get; private set; } = false;

        public string StateString { get; private set; } = "default";

        public MefService() {
        
        
        }

    }
}
