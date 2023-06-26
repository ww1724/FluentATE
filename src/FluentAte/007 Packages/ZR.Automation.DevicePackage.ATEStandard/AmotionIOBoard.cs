using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZR.Automation.Device;

namespace ZR.Automation.DevicePackage.ATEStandard
{
    [DeviceDescriptor(deviceId:"AmotionIOBoard",deviceName:"艾莫迅IO模块",deviceDescription:"纯数字量IO模块，支持Mobus Tcp|RTU、级联|串联方式控制")]
    public class AmotionIOBoard : IAutomationDevice
    {
        public ICollection<object> GetCommandList()
        {
            return new Collection<object>
            {
                new DeviceCommand {  }
            };
        }

        public ICollection<object> GetCommandList(string contract)
        {
            return new Collection<object>();
        }


        public object GetValue(string key)
        {
            if (key == null || key == "") return null;
            switch(key) {

                default: return null;
            }
        }

        public bool SendCommand(string command, string parameters)
        {
            return true;
        }

        public object SendCommand(string command, params object[] paramters)
        {
            return true;
        }
    }
}
