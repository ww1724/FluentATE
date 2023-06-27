using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Test
{
    public interface IDevice
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
