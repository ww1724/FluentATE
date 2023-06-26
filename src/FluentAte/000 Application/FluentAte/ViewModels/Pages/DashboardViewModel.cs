using ATE.Share.Stores;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Wpf.Ui.Common;
using Wpf.Ui.Controls.Navigation;

namespace FluentAte.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        public TestStore TestStore { get; set; }

        [ObservableProperty]
        private int _counter = 0;

        [ObservableProperty]
        private ICollection<object> menuItems;

        [RelayCommand]
        private void OnCounterIncrement()
        {
            Counter++;
        }

        public DashboardViewModel(TestStore testStore)
        {
            TestStore = testStore;

            menuItems = new ObservableCollection<object>
            {
                new NavigationViewItem("测试首页", SymbolRegular.Home24, typeof(Views.Pages.DashboardPage))
                {
                    MenuItems = new object[]
                    {
                        new NavigationViewItem("测试首页", SymbolRegular.Home24, typeof(Views.Pages.DashboardPage))
                    }
                },
                new NavigationViewItem("管理页", SymbolRegular.DesktopEdit16, typeof(Views.Pages.ManagePage)),
                new NavigationViewItem("控制页", SymbolRegular.AccessibilityCheckmark24, typeof(Views.Pages.AdminPage)),
                new NavigationViewItem("关于", SymbolRegular.AnimalRabbit32, typeof(Views.Pages.AboutPage))
            };
        }

        [RelayCommand]
        public void ExpandAllItems()
        {
            foreach (var step in TestStore.Record.Steps)
            {
                step.IsExpand = true;
            }
        }

        [RelayCommand]
        public void ShrinkAllItems()
        {
            foreach (var step in TestStore.Record.Steps)
            {
                step.IsExpand = false;
            }
        }

        [RelayCommand]
        public void AllToTest()
        {
            foreach (var step in TestStore.Record.Steps)
            {
                step.IsToTest = true;
            }
        }

        [RelayCommand]
        public void AllNotToTest()
        {
            foreach (var step in TestStore.Record.Steps)
            {
                step.IsToTest = false;
            }
        }
    }
}
