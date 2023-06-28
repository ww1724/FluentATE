using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Test
{
    public interface IDeviceMetadata
    {
        public string DeviceId { get;  }

        public string Name { get; }

        public string Description { get; }
    }


    [MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DeviceMetadataAttribute : ExportAttribute, IDeviceMetadata
    {
        public string DeviceId { get;  }
        public string Name { get; }
        public string Description { get; }


        public DeviceMetadataAttribute(string deviceId, string name, string description="")
        {
            DeviceId = deviceId;
            Name = name;
            Description = description;
        }

    }
}
