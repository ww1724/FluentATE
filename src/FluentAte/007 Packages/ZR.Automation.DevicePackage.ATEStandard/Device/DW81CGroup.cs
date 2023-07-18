using ATE.Common.Test;
using System.ComponentModel.Composition;

namespace ATE.Package.Normal.Standard.Device
{
    [Export("Device.DW81C", typeof(IDeviceGroup)), PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IDeviceGroup))]
    [DeviceGroupMetadata(id: "Device.DW81C", name: "创鸿DW81-C电流电压表", description: "电流电压表,支持485")]
    public class DW81CGroup : IDeviceGroup
    {
        public Dictionary<int, object> Devices { get; set; }

        public DeviceState State { get; private set; } = DeviceState.Unused;

        public string ErrorString { get; private set; } = "";

        public DW81CGroup()
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
