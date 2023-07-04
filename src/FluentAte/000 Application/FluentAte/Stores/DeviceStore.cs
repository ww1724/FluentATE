using ATE.Common.Test;
using ATE.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WpfExtensions.Binding;

namespace ATE.Share.Stores
{
    public partial class DeviceStore : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<object> devices;

        private DeviceManager _deviceManager { get;set; }

        [ObservableProperty]
        private bool isDetectingDevice = false;

        private int DetectTimeout = 5000;

        [ObservableProperty]
        private string detectDeviceErrorString = string.Empty;

        [ObservableProperty]    
        public ObservableCollection<IDeviceGroupMetadata> supportDevicePackages;

        public int AvailableDevicePackageNumber => SupportDevicePackages.Count; 

        public DeviceStore(DeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
            devices = new ObservableCollection<object>(_deviceManager.GetDeviceList());
            SupportDevicePackages = new ObservableCollection<IDeviceGroupMetadata>();
            this.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SupportDevicePackages))
                {
                    OnPropertyChanged(nameof(AvailableDevicePackageNumber));
                }
            };
        }

        [RelayCommand]
        public async void DetectDevice()
        {
            IsDetectingDevice = true;
            SupportDevicePackages = new ObservableCollection<IDeviceGroupMetadata>();
            var operationTask = Task.Run(() => _deviceManager.DetectDevice());
            if ( await Task.WhenAny(operationTask, Task.Delay(DetectTimeout)) == operationTask)
            {
                try
                {
                    await Task.Delay(100);
                    IsDetectingDevice = false;
                    
                   foreach (var package in _deviceManager.DeviceGroupPackages.Keys)
                    {
                        SupportDevicePackages.Add(package);
                    }

                   OnPropertyChanged(nameof(SupportDevicePackages));
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
