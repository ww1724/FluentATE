using ATE.Common.Contracts;
using FluentAte.Services;
using FluentAte.ViewModels;
using FluentAte.Views.Pages;
using HandyControl.Controls;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace FluentAte.Views.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : HandyControl.Controls.Window, IWindow
{
    public MainWindow(MainWindowViewModel viewModel, AppNavigationService navigationService, IServiceProvider serviceProvider)
    {

        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();

        navigationService.SetNavigationContainer(NavigationContainer);
        navigationService.SetServiceProvider(serviceProvider);
        navigationService.Navigate(typeof(DashboardPage));
        WindowAttach.SetIgnoreAltF4(this, true);
    }

    public MainWindowViewModel ViewModel { get; }


    private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
     
    }

}

