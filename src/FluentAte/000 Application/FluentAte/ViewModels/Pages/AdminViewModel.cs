using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Wpf.Ui.Common;
using Wpf.Ui.Controls.Navigation;

namespace FluentAte.ViewModels.Pages
{
    public partial class AdminViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<object> subMenus;

        public AdminViewModel()
        {
            subMenus = new ObservableCollection<object>()
            {
                //new NavigationViewItem("主页", SymbolRegular.Home48, typeof(Views.Pages.Admin.HomePage)),
                new NavigationViewItem("设备管理", SymbolRegular.AppRecent24, typeof(Views.Pages.Admin.DeviceManagePage)),
            };
        }

    }
}
