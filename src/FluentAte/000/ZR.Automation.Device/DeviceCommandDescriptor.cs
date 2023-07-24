using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Automation.Device
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DeviceCommandDescriptor : Attribute
    {
        public string Command { get; set; }

        public Type ParameterType { get; set; }

        public string Contract { get; set; }

        public string Group { get; set; }

        public DeviceCommandDescriptor(string command, string group = "", Type parameterType = null, string contract="")
        {
            Command = command;
            ParameterType = parameterType;
            Contract = contract;
            Group = group;
        }
    }
}
