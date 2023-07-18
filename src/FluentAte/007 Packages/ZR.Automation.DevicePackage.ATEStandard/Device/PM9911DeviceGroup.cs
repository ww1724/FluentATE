using ATE.Common.Test;
using System.ComponentModel.Composition;

namespace ATE.Package.Normal.Standard.Device
{
    [Export("Device.PM9911", typeof(IDeviceGroup)), PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IDeviceGroup))]
    [DeviceGroupMetadata(id: "Device.PM9911", name: "PM9911功率计", description: "普美功率计,选配232/UART/485")]
    public class PM9911DeviceGroup : IDeviceGroup
    {
        public Dictionary<int, object> Devices { get; set; }

        public DeviceState State { get; private set; } = DeviceState.Unused;

        public string ErrorString { get; private set; } = "";

        public PM9911DeviceGroup()
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
