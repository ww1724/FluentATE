using ATE.Common.Test.TestFramework;
using ATE.Common.Test.TestFramework.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Package.Normal.Standard.Tasks
{
    public class DelayTaskParameter
    {
        public double Delay { get; set; } = 1;
    }

    [Export("Task.Delay", typeof(ITestTask)), PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(ITestTask))]
    [TestTaskAttribute(id:"Task.Delay",name:"延迟任务", parameterType:typeof(DelayTaskParameter))]
    public class DelayTask : ITestTask
    {
        public void RunAsync(IExecutionContext executionContext)
        {
            DelayTaskParameter parameter = executionContext.TaskParameter as DelayTaskParameter;
            if (parameter == null) Task.Delay(0);
            Task.Delay(Convert.ToInt32(parameter.Delay * 1000));
        }
    }
}
