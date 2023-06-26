namespace ZR.Automation.Device
{
    public interface IAutomationDevice
    {
        public ICollection<object> GetCommandList();

        public ICollection<object> GetCommandList(string contract);

        [DeviceCommandDescriptor(command:"默认发送控制命令",group:"default")]
        public object SendCommand(string command, string parameters);

        public object SendCommand(string command, params object[] paramters);

        public object GetValue(string key);   
    }
}
