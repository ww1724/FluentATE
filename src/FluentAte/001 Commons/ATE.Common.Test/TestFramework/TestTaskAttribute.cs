using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Test.TestFramework
{
    public interface ITestTaskMetadata
    {
        public string Id { get; set; }

        public string Group { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Type ParameterType { get; set; }
    }

    [MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TestTaskAttribute : Attribute, ITestTaskMetadata
    {
        public TestTaskAttribute(string id, string name, Type parameterType, string group = "默认类别", string description = "")
        {
            Id = id;
            Name = name;
            Description = description;
            ParameterType = parameterType;
            Group = group;
        }

        public string Id { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ParameterType { get; set; }

    }
}
