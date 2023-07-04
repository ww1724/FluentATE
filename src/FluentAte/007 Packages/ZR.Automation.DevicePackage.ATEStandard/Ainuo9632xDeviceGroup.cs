using ATE.Common.Test;
using System.ComponentModel.Composition;

namespace ATE.Package.Device.Standard
{
    [Export("Device.Ainuo9632x", typeof(IDeviceGroup)), PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IDeviceGroup))]
    [DeviceGroupMetadata(id: "Device.Ainuo9632x", name: "艾诺耐压测试仪", description: "耐压|绝缘测试, 选配485/232")]
    public class Ainuo9632xDeviceGroup : IDeviceGroup
    {
        public Dictionary<int, object> Devices { get; set; }

        public DeviceState State { get; private set; } = DeviceState.Unused;

        public string ErrorString { get; private set; } = "";

        public Ainuo9632xDeviceGroup()
        {
        }

        public void Initialize()
        {
            State = DeviceState.Initializing;
            try
            {

            }
            catch (Exception e)
            {
                State = DeviceState.Error;
            }

            State = DeviceState.Initialized;
        }

        public bool AddDevice(int id, IDevice device)
        {
            try
            {
                Devices.Add(id, device);
            }
            catch (Exception)
            {
                ErrorString = "添加设备错误";
                return false;
            }

            return true;
        }

        public void SendCommandToDevice(int deviceID, string command, params object[] parameter)
        {
        }

        public void SendCommandToDevice(int deviceID, string command, string parameter)
        {
        }


    }
}
