using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Service
{
    public class DeviceManageService
    {
        private MefService _mefService;
        public DeviceManageService(MefService mefService)
        {
            _mefService = mefService;
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
