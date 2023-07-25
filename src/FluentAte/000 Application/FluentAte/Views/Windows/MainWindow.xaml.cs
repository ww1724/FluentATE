using ATE.Common.Contracts;
using CommunityToolkit.Mvvm.Input;
using FluentAte.Controls;
using FluentAte.Services;
using FluentAte.ViewModels;
using FluentAte.Views.Pages;
using HandyControl.Controls;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;

namespace FluentAte.Views.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : HandyControl.Controls.Window, IWindow
{
    public MainWindowViewModel ViewModel { get; }

    private DesktopPet _pet;

    public MainWindow(MainWindowViewModel viewModel, AppNavigationService navigationService, IServiceProvider serviceProvider)
    {

        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();

        navigationService.SetNavigationContainer(NavigationContainer);
        navigationService.SetServiceProvider(serviceProvider);
        navigationService.Navigate(typeof(DashboardPage));
        WindowAttach.SetIgnoreAltF4(this, true);

        _pet = new DesktopPet();
        _pet.DataContext = this;
        
        Sprite.Show(_pet).WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    

    protected override void OnClosed(EventArgs e)
    {
        //base.OnClosed(e);
        this.Hide();
    }

    [RelayCommand]
    private void ShowWindow()
    {
        Show();
    }
    
    [RelayCommand]
    private void ShowAppDesktopPet()
    {
        Sprite.Show(_pet);
    }

    [RelayCommand]
    private void CloseApplication()
    {
        App.Current.Shutdown();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        Hide();
        e.Cancel = true;
    }

    private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
     
    }

}

