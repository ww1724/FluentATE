using ATE.Common.Test;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Share.Stores
{
    public partial class DeviceStore : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<object> devices;

        private DeviceManager _deviceManager { get;set; }

        public DeviceStore(DeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
            devices = new ObservableCollection<object>(_deviceManager.GetDeviceList());
        }
    }
}
