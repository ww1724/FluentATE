using ATE.Common.Test;
using ATE.Common.Test.Dal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Service
{
    public class DeviceManager
    {
        private MefService _mefService;

        private DbService _dbService;

        public List<object> DeviceGroups { get; set; }

        public List<object> Devices { get; set; }

        public Dictionary<IDeviceGroupMetadata, IDeviceGroup> DeviceGroupPackages { get; set; }

        public DeviceManager(MefService mefService, DbService dbService)
        {
            _mefService = mefService;
            _dbService = dbService;

            InitializeComponent();
        }

        public void InitializeComponent()
        {
            DeviceGroupPackages = new Dictionary<IDeviceGroupMetadata, IDeviceGroup>();
            DeviceGroups = new List<object>();
            Devices = new List<object>();
            InitializeDevices();
        }

        /// <summary>
        /// 初始化已注册设备
        /// </summary>
        /// <param name="deviceId"></param>
        public void InitializeDevice(string deviceId)
        {

        }

        /// <summary>
        /// 加载所有已注册设备
        /// </summary>
        /// <param name="deviceId"></param>
        public void InitializeDevices()
        {
            var groupEntities = _dbService.Query<DeviceGroupEntity>();
        }

        public void AddDeviceGroup(string deviceGroupId)
        {
           var a =  _mefService.container.GetExportedValue<IDeviceGroup>(deviceGroupId);
           var b = _mefService.container.GetExportedValue<IDeviceGroup>(deviceGroupId);
        }

        /// <summary>
        /// 扫描设备包
        /// </summary>
        public async void DetectDevice()
        {
            await Task.CompletedTask;
            var groups = _mefService.container.GetExports<IDeviceGroup, IDeviceGroupMetadata>();
            DeviceGroupPackages = new Dictionary<IDeviceGroupMetadata, IDeviceGroup>();
            foreach (var groupPackage in groups)
            {
                var a = groupPackage.Metadata.DeviceGoupId;
                DeviceGroupPackages.Add(groupPackage.Metadata, groupPackage.Value);
            }
            await Task.CompletedTask;
        }


        public ICollection<object> GetDeviceList()
        {
            return new List<object>();
        }

        public void SendCommandToDevice(string groupID, string deviceID, string command, params object[] parameter) { }
        
        public void SendCommandToDevice(string groupID, string deviceID, string command, string parameter) { }

        public void SendCommandToDevice(string deviceID, string command, params object[] parameter) { }

        public void SendCommandToDevice(string deviceID, string command, string parameter) { }

    }
}
