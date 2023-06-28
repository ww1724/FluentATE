using ATE.Common.Test;
using System.ComponentModel.Composition;

namespace ATE.Package.Device.Standard
{
    [Export(typeof(IDeviceGroup))]
    [DeviceMetadata(deviceId: "AmotionIOBoardGroup", name: "艾莫迅IO模块设备组", description: "设备组,批量管理IO模块")]
    public class AmotionIOBoardGroup : IDeviceGroup
    {
        public Dictionary<int, object> Devices { get; set; }

        public DeviceState State { get; private set; } = DeviceState.Unused;

        public string ErrorString { get; private set; } = "";

        public AmotionIOBoardGroup()
        {
            Devices = new Dictionary<int, object>
            {
            };
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
