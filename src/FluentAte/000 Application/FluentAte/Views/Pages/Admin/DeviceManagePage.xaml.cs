﻿using FluentAte.ViewModels.Pages;
using FluentAte.ViewModels.Pages.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
