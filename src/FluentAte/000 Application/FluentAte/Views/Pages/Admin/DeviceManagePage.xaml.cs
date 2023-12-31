﻿using FluentAte.ViewModels.Pages;
using FluentAte.ViewModels.Pages.Admin;
using Wpf.Ui.Controls.Navigation;

namespace FluentAte.Views.Pages.Admin
{
    /// <summary>
    /// DeviceManagePage.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceManagePage : INavigableView<DeviceManageViewModel>
    {
        public DeviceManageViewModel ViewModel
        {
            get;
        }
        public DeviceManagePage(DeviceManageViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
        }
    }
}
