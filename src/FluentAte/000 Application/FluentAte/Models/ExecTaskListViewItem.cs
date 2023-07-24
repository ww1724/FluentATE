using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAte.Models
{
    public class ExecTaskListViewItem
    {
        public string Group { get; set; }

        public string Name { get; set; }

        public Type TaskType { get; set; }

        public object TaskParameter { get; set; }
    }
}
