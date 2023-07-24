using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Test
{
    public interface IDevice
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DeviceState State { get; set; }

        public abstract bool Initialize();

        public abstract bool ExecAction();

        public abstract bool ExecActionAsync();

        public abstract object GetValue(string name, params object[] parameters);

        public void Shutdown();

    }
}
