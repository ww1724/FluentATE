using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Configuration.Interfaces
{
    public interface IConfigItem
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Type Type { get; set; }

        public object Value { get; set; }
    }
}
