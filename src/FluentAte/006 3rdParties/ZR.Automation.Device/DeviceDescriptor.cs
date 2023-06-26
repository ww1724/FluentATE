using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Automation.Device
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class DeviceDescriptor : Attribute
    {
        public string DeviceId { get; set; }

        public string DeviceName { get;set; } 

        public string DeviceDescription { get; set; }

        public DeviceDescriptor(string deviceId, string deviceName, string deviceDescription = "")
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            DeviceDescription = deviceDescription;
        }
    }
}
