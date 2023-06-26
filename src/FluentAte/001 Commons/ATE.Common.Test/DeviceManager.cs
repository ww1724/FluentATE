using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Test
{
    public class DeviceManager
    {
        

        public DeviceManager()
        {
            
        }

        public void InitializeDevice(string deviceId)
        {

        }

        public ICollection<object> GetDeviceList()
        {
            return new List<object>();
        }

        public void SendCommandToDevice(string deviceID, string command, params object[] parameter) { }
    
        public void SendCommandToDevice(string deviceID, string command, string parameter) { }

    }
}
