using ATE.Common.Contracts;
using FluentAte.ViewModels;
using FluentAte.Views.Pages;
using System;
using System.Windows;
using Wpf.Ui.Contracts;
using Wpf.Ui.Controls.Navigation;

namespace FluentAte.Views.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : IWindow
{
    public MainWindow(MainWindowViewModel viewModel, INavigationService navigationService,
        IServiceProvider serviceProvider, ISnackbarService snackbarService, IContentDialogService contentDialogService)
    {
        Wpf.Ui.Appearance.Watcher.Watch(this);

        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();

        snackbarService.SetSnackbarPresenter(SnackbarPresenter);
        navigationService.SetNavigationControl(NavigationView);
        contentDialogService.SetContentPresenter(RootContentDialog);

        NavigationView.SetServiceProvider(serviceProvider);
        NavigationView.Loaded += (_, _) => NavigationView.Navigate(typeof(DashboardPage));
    }

    public MainWindowViewModel ViewModel { get; }

    private bool _isUserClosedPane;
    private bool _isPaneOpenedOrClosedFromCode;

    private void OnNavigationSelectionChanged(object sender, RoutedEventArgs e)
    {
        if (sender is not Wpf.Ui.Controls.Navigation.NavigationView navigationView)
            return;

        NavigationView.HeaderVisibility = navigationView.SelectedItem?.TargetPageType != typeof(DashboardPage)
            ? Visibility.Visible
            : Visibility.Collapsed;
    }

    private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (_isUserClosedPane)
            return;

        _isPaneOpenedOrClosedFromCode = true;
        NavigationView.IsPaneOpen = !(e.NewSize.Width <= 1200);
        _isPaneOpenedOrClosedFromCode = false;
    }

}

