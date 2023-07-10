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
                new NavigationViewItem("测试项目", SymbolRegular.AppRecent24, typeof(Views.Pages.Admin.DeviceManagePage)),
                new NavigationViewItem("控制助手", SymbolRegular.GiftCardMoney20, typeof(Views.Pages.Admin.MyAppAssistantPage)),
                //new NavigationViewItem("权限管理", SymbolRegular.AppRecent24, typeof(Views.Pages.Admin.DeviceManagePage)),
                //new NavigationViewItem("服务管理", SymbolRegular.AppRecent24, typeof(Views.Pages.Admin.DeviceManagePage)),
                //new NavigationViewItem("数据库", SymbolRegular.AppRecent24, typeof(Views.Pages.Admin.DeviceManagePage)),
                //new NavigationViewItem("环境管理", SymbolRegular.AppRecent24, typeof(Views.Pages.Admin.DeviceManagePage)),
            };
        }

    }
}
