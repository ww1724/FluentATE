using ATE.Share.Stores;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAte.ViewModels.Pages.Admin
{
    public class DeviceManageViewModel : ObservableObject
    {
        public DeviceStore DeviceStore { get; set; }



        public DeviceManageViewModel(DeviceStore deviceStore)
        {
            DeviceStore = deviceStore;
        }
    }
}
