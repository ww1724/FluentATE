using ATE.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Wpf.Ui.Common;
using Wpf.Ui.Controls.Navigation;

namespace FluentAte.ViewModels.Pages
{
    public partial class ManageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ICollection<object> _menuItems;

        public ManageViewModel(LoggerService loggerService)
        {
            loggerService.Error("小小报个错");

            _menuItems = new ObservableCollection<object>
            {
                new NavigationViewItem("管理首页", SymbolRegular.Home24, typeof(Views.Pages.Manage.HomePage)),
                new NavigationViewItem("程序编辑", SymbolRegular.Check24, typeof(Views.Pages.Manage.CodeEditorPage)),
                new NavigationViewItem("程序管理", SymbolRegular.Bookmark32, typeof(Views.Pages.Manage.CodeManagePage)),
                new NavigationViewItem("数据中心", SymbolRegular.DataUsage20, typeof(Views.Pages.Manage.DataCentralPage)),
                new NavigationViewItem("设备监控", SymbolRegular.DeveloperBoardLightning20, typeof(Views.Pages.Manage.DeviceMonitorPage)),
                new NavigationViewItem("配置管理", SymbolRegular.EditSettings20, typeof(Views.Pages.Manage.ConfigurationPage)),
            };
        }

    }
}
