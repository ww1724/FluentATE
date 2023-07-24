using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Test.TestFramework
{
    public interface ITestHost
    {
        /// <summary>
        /// 开始测试流程
        /// </summary>
        /// <returns>任务流程ID</returns>
        public int StartFlowAsync();

        /// <summary>
        /// 根据ID停止任务流程
        /// </summary>
        /// <param name="id">流程ID</param>
        public void StopFlowAsync(int id);
    }
}
