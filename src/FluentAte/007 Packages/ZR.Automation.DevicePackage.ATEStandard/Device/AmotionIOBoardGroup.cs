﻿using ATE.Common.Test;
using System.ComponentModel.Composition;

namespace ATE.Package.Normal.Standard.Device
{
    [Export("Device.AmotionIOBoard", typeof(IDeviceGroup)), PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IDeviceGroup))]
    [DeviceGroupMetadata(id: "Device.AmotionIOBoard", name: "艾莫迅IO模块", description: "纯数字量IO模块，支持Mobus Tcp|RTU、级联|串联方式控制")]
    public class AmotionIOBoardGroup : IDeviceGroup
    {
        public Dictionary<int, object> Devices { get; set; }

        public DeviceState State { get; private set; } = DeviceState.Unused;

        public string ErrorString { get; private set; } = "";

        public AmotionIOBoardGroup()
        {
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
