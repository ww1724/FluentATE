using ATE.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common
{
    public class AppServiceManager
    {
        public List<object> AppServices { get; set; }

        public AppServiceManager() { 
        
            AppServices = new List<object>();
        }

        public bool RegisterAppService(IAppService service)
        {
            return true;
        }

        
    }
}
