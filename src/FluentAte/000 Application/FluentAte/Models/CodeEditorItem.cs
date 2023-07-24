using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAte.Models
{
    public partial class CodeEditorItem : ObservableObject
    {
        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string taskType;

        [ObservableProperty]
        public bool isGroup;

        [ObservableProperty]
        public string description;

        [ObservableProperty]
        public bool isExpand;

        [ObservableProperty]
        public bool isChecked;

        [ObservableProperty]
        public ObservableCollection<CodeEditorItem> childItems;
    }
}
