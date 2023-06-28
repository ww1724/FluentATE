using ATE.Common.Test;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Package.Device.Standard
{
    [Export(typeof(IDevice))]
    [DeviceMetadata(deviceId: "AmotionIOBoardDevice", name: "艾莫迅IO模块", description: "纯数字量IO模块，支持Mobus Tcp|RTU、级联|串联方式控制")]
    public class AmotionIOBoardDevice : IDevice
    {
        public string Id { get; set; } = "AmotionIOBoardDevice";
        public string Name { get; set; } = "艾莫迅IO模块";
        public string Description { get; set; } = "纯数字量IO模块，支持Mobus Tcp|RTU、级联|串联方式控制";
        public DeviceState State { get; set; } = DeviceState.Unused;

        public AmotionIOBoardDevice()
        {

        }

        public bool Initialize()
        {
            State = DeviceState.Initializing;
            try
            {

            }
            catch (Exception)
            {
                State = DeviceState.Error; return false;
            }
            State = DeviceState.Initialized;
            return true;
        }

        public bool ExecAction()
        {
            return true;
        }

        public bool ExecActionAsync()
        {
            return true;
        }

        public object GetValue(string name, params object[] parameters)
        {
            return null;
        }

        public void Shutdown()
        {
        }
    }
}
