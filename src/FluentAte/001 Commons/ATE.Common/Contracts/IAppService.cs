using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Contracts
{
    public interface IAppService
    {
        public string Id { get; }

        public string ServiceName { get; }

        public bool IsRunning { get; }

        public string StateString { get; }
    }
}
