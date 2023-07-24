using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Test
{
    public interface IDeviceGroup
    {
        public Dictionary<int, object> Devices { get; set; }

        public DeviceState State { get; }

        public string ErrorString { get; }

        public abstract void Initialize();

        public abstract bool AddDevice(int id, IDevice device);

        public abstract void SendCommandToDevice(int deviceID, string command, params object[] parameter);

        public abstract void SendCommandToDevice(int deviceID, string command, string parameter);

        
    }
}
