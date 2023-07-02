using ATE.Common.Test;
using ATE.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATE.Share.Stores
{
    public partial class DeviceStore : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<object> devices;

        private DeviceManager _deviceManager { get;set; }

        [ObservableProperty]
        private bool isDetectingDevice = false;

        [ObservableProperty]
        private bool isShowDetectDeviceBoard = false;

        private int DetectTimeout = 5000;

        [ObservableProperty]
        private string detectDeviceErrorString = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AvailableDevicePackageNumber))]
        public ObservableCollection<IDeviceGroupMetadata> supportDevicePackages;


        public int AvailableDevicePackageNumber { get => SupportDevicePackages.Count; }

        public DeviceStore(DeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
            devices = new ObservableCollection<object>(_deviceManager.GetDeviceList());
            SupportDevicePackages = new ObservableCollection<IDeviceGroupMetadata>();
            DetectDevice();
        }

        [RelayCommand]
        public async void DetectDevice()
        {
            IsDetectingDevice = true;
            IsShowDetectDeviceBoard = true;
            var operationTask = Task.Run(() => _deviceManager.DetectDevice());
            if ( await Task.WhenAny(operationTask, Task.Delay(DetectTimeout)) == operationTask)
            {
                try
                {
                    await Task.Delay(3000);
                    IsDetectingDevice = false;
                    IsShowDetectDeviceBoard = false;
                    SupportDevicePackages = new ObservableCollection<IDeviceGroupMetadata>();
                   foreach (var package in _deviceManager.DeviceGroupPackages.Keys)
                    {
                        SupportDevicePackages.Add(package);
                    }
                    return;
                }
                catch (Exception)
                {

                }
            } else
            {

            }
            IsDetectingDevice = false;

        }
    }
}
