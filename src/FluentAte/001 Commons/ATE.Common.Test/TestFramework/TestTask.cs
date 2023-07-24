using ATE.Common.Test.TestFramework.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Test.TestFramework
{
    public abstract class TestTask
    {
        public abstract void RunAsync(IExecutionContext executionContext);
    }
}
