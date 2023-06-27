using FluentAte.ViewModels.Pages;
using FluentAte.Views.Pages.Manage;
using System;
using System.Windows;
using Wpf.Ui.Controls.Navigation;

namespace FluentAte.Views.Pages
{
    /// <summary>
    /// ManagePage.xaml 的交互逻辑
    /// </summary>
    public partial class ManagePage : INavigableView<ManageViewModel>
    {
        public ManageViewModel ViewModel
        {
            get;
        }

        public ManagePage(ManageViewModel viewModel, IServiceProvider serviceProvider)
        {
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
            NavigationView.SetServiceProvider(serviceProvider);
            NavigationView.Loaded += (_, _) => NavigationView.Navigate(typeof(HomePage));
        }

        private void OnNavigationSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (sender is not Wpf.Ui.Controls.Navigation.NavigationView navigationView)
                return;

            NavigationView.HeaderVisibility = navigationView.SelectedItem?.TargetPageType != typeof(DashboardPage)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }
    }
}
