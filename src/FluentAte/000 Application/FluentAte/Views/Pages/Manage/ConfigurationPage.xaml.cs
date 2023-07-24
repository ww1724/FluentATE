﻿using ATE.Common.Configuration.Interfaces;
using ATE.Common.Configuration.Models;
using ATE.Service;
using FluentAte.ViewModels.Pages.Manage;
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

namespace FluentAte.Views.Pages.Manage
{
    /// <summary>
    /// Configuration.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigurationPage : Page
    {
        public ConfigurationViewModel ViewModel
        {
            get;
        }

        public ConfigurationPage(ConfigurationViewModel configurationViewModel)
        {
            ViewModel = configurationViewModel;
            DataContext = this;
            InitializeComponent();
        }

    }
}
