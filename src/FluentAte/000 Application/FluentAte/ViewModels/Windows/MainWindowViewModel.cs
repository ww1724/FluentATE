using ATE.Share.Stores;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAte.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.IconElements;
using Wpf.Ui.Controls.Navigation;

namespace FluentAte.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public TestStore TestStore { get; set; }

        public AppStore AppStore { get; set; }  

        private readonly IServiceProvider _serviceProvider;

        [ObservableProperty]
        private string _applicationTitle;

        [ObservableProperty]
        private ICollection<object> _menuItems;

        [ObservableProperty]
        private ICollection<object> _footerMenuItems = new ObservableCollection<object>();

        public MainWindowViewModel(IServiceProvider serviceProvider, TestStore testStore, AppStore appStore)
        {
            _serviceProvider = serviceProvider;
            TestStore = testStore;
            AppStore = appStore;

            _applicationTitle = "Fluent ATE";

            _menuItems = new ObservableCollection<object>
            {
                new NavigationViewItem("测试首页", SymbolRegular.Home24, typeof(Views.Pages.DashboardPage)),
                new NavigationViewItem("管理页", SymbolRegular.DesktopEdit16, typeof(Views.Pages.ManagePage)),
                new NavigationViewItem("控制页", SymbolRegular.AccessibilityCheckmark24, typeof(Views.Pages.AdminPage)),
                new NavigationViewItem("关于", SymbolRegular.AnimalRabbit32, typeof(Views.Pages.AboutPage))
            };

            var toggleThemeNavigationViewItem = new NavigationViewItem
            {
                Content = "切换",
                Icon = new SymbolIcon { Symbol = SymbolRegular.BrightnessHigh16 }
            };
            toggleThemeNavigationViewItem.Click += OnToggleThemeClicked;
            _footerMenuItems.Add(toggleThemeNavigationViewItem);
            _footerMenuItems.Add(new NavigationViewItem("基础设置", SymbolRegular.Settings48, typeof(Views.Pages.SettingsPage))); 
        
        
        }

        private void OnToggleThemeClicked(object sender, RoutedEventArgs e)
        {
            var currentTheme = Wpf.Ui.Appearance.Theme.GetAppTheme();

            Wpf.Ui.Appearance.Theme.Apply(currentTheme == Wpf.Ui.Appearance.ThemeType.Light ? Wpf.Ui.Appearance.ThemeType.Dark : Wpf.Ui.Appearance.ThemeType.Light);
        }
    }
}

// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

