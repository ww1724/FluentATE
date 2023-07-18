using ATE.Share.Stores;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentAte.Services;
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

        private AppNavigationService _navigationService;

        private readonly IServiceProvider _serviceProvider;

        [ObservableProperty]
        private string _applicationTitle;

        public MainWindowViewModel(
            IServiceProvider serviceProvider, 
            TestStore testStore, 
            AppStore appStore, 
            AppNavigationService navigationService)
        {
            _serviceProvider = serviceProvider;
            TestStore = testStore;
            AppStore = appStore;

            _applicationTitle = "Fluent ATE";

            _navigationService = navigationService;
        }

        [RelayCommand]
        private void NavigationTo(Type path)
        {
            _navigationService.Navigate(path);
        }

    }
}

// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

