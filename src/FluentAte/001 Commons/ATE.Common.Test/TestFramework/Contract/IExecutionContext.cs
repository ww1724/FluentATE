using ATE.Common.Test.TestFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Test.TestFramework.Contract
{
    public interface IExecutionContext
    {
        object Data { get; set; }

        object TaskParameter { get; set; }

        ITestTask Task { get; set; }

        FlowInstance Flow { get; set; }

        ConfigCollection Config { get; set; }

        CancellationToken CancellationToken { get; set; }
    }
}
