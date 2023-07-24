using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Test
{
    public interface IDeviceGroupMetadata
    {
        public string DeviceGoupId { get;  }

        public string Name { get; }

        public string Description { get; }

        public int Version { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DeviceGroupMetadataAttribute : Attribute, IDeviceGroupMetadata
    {
        public string DeviceGoupId { get;  }
        public string Name { get; }
        public string Description { get; }
        public int Version { get; }

        public DeviceGroupMetadataAttribute(string id, string name, int version = 1,string description="")
        {
            DeviceGoupId = id;
            Name = name;
            Description = description;
        }

    }
}
