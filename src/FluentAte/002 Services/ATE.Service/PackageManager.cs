using ATE.Common.Test.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Service
{
    public class PackageManager
    {
        private MefService _mefService;


        public PackageManager(MefService mefService)
        {
            _mefService = mefService;
        }

        public List<ITestTaskMetadata> GetAvailableTasks() { 
            List<ITestTaskMetadata> testTasks = new List<ITestTaskMetadata>();
            var a  = _mefService.container.GetExports<ITestTask, ITestTaskMetadata>();
            return testTasks;
        }
    }
}
