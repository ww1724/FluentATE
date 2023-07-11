using FluentAte.ViewModels.Pages;
using FluentAte.Views.Pages.Admin;
using System;
using System.Windows;
using Wpf.Ui.Controls.Navigation;

namespace FluentAte.Views.Pages
{
    /// <summary>
    /// ManagePage.xaml 的交互逻辑
    /// </summary>
    public partial class AdminPage : INavigableView<AdminViewModel>
    {
        public AdminViewModel ViewModel
        {
            get;
        }

        public AdminPage(AdminViewModel viewModel, IServiceProvider serviceProvider)
        {
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();

            NavigationView.SetServiceProvider(serviceProvider);
            NavigationView.Loaded += (_, _) => NavigationView.Navigate(typeof(StandardPackagePage));

        }
    }
}
