using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentAte.Services;
using FluentAte.Views.Pages;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FluentAte.Stores
{
    public class MenuItem
    {
        public char Icon { get; set; }

        public Type Path { get; set; }

        public string Title { get; set; }

        public ObservableCollection<MenuItem> Children { get; set; } = new ObservableCollection<MenuItem> { };
    }

    public partial class AppStore : ObservableObject
    {
        private AppNavigationService _navigationService;

        [ObservableProperty]
        private bool leftDrawerOpened;

        [ObservableProperty]
        private ObservableCollection<MenuItem> menuItems;

        [ObservableProperty]
        private MenuItem currentMenu;

        public AppStore(AppNavigationService navigationService)
        {
            _navigationService = navigationService;
            LeftDrawerOpened = true;
            MenuItems = new ObservableCollection<MenuItem>() { 
                new MenuItem { Icon = (char)0xe6b9, Title="首页", Path=typeof(DashboardPage),Children = new ObservableCollection<MenuItem> {}},
                new MenuItem { Icon = (char)0xe638, Title="管理页", Path=typeof(ManagePage),Children = new ObservableCollection<MenuItem> {}},
                new MenuItem { Icon = (char)0xea49, Title="控制页", Path=typeof(AdminPage),Children = new ObservableCollection<MenuItem> {}},
                new MenuItem { Icon = (char)0xe65e, Title="配置页", Path=typeof(SettingsPage),Children = new ObservableCollection<MenuItem> {}},
                new MenuItem { Icon = (char)0xe600, Title="关于", Path=typeof(AboutPage),Children = new ObservableCollection<MenuItem> {}},
    
            };

            CurrentMenu = MenuItems.FirstOrDefault() ?? new MenuItem { Icon = (char)0xe6b9, Title = "首页", Path = typeof(DashboardPage) };
            
        }


        [RelayCommand]
        private void SwitchLeftDrawer()
        {
            LeftDrawerOpened = !LeftDrawerOpened;
        }


        partial void OnCurrentMenuChanged(MenuItem item)
        {
            _navigationService.Navigate(item.Path);
            //MessageBox.Info("Changed");
        }
    }
}
