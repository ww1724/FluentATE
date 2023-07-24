using ATE.Common.Contracts;
using ATE.Service;
using ATE.Share.Stores;
using FluentAte.Models;
using FluentAte.Services;
using FluentAte.Stores;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace FluentAte
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        // The.NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)); })
            .ConfigureServices((context, services) =>
            {
                // App Host
                services.AddHostedService<ApplicationHostService>();
                services.AddSerilog();


                // UI Services
                services.AddSingleton<ViewModels.MainWindowViewModel>();
                services.AddSingleton<AppNavigationService>();
                //services.AddSingleton<INavigationService, Wpf.Ui.Services.NavigationService>();
                //services.AddSingleton<ISnackbarService, SnackbarService>();
                services.AddSingleton<WindowsProviderService>();
                

                // MyServices
                // Level 1
                services.AddSingleton<MefService>();
                services.AddSingleton<DbService>();
                // Level 2
                services.AddSingleton<PackageManager>();
                services.AddSingleton<ConfigManager>();
                services.AddSingleton<LoggerService>();
                // Level 3
                services.AddSingleton<DeviceManager>();

                // MyStores
                services.AddSingleton<AppStore>();
                services.AddSingleton<TestStore>();
                services.AddSingleton<DeviceStore>();
                services.AddSingleton<ConfigStore>();

                // Main window with navigation
                services.AddScoped<IWindow, Views.Windows.MainWindow>();
                services.AddScoped<ViewModels.MainWindowViewModel>();

                // Views and ViewModels
                services.AddScoped<Views.Pages.DashboardPage>();
                services.AddScoped<ViewModels.DashboardViewModel>();
                // manage
                services.AddScoped<Views.Pages.ManagePage>();
                services.AddScoped<ViewModels.Pages.ManageViewModel>();
                services.AddScoped<Views.Pages.Manage.CodeManagePage>();
                services.AddScoped<Views.Pages.Manage.CodeEditorPage>();
                services.AddScoped<Views.Pages.Manage.DataCentralPage>();
                services.AddScoped<Views.Pages.Manage.ConfigurationPage>();
                services.AddScoped<Views.Pages.Manage.DeviceMonitorPage>();
                services.AddScoped<ViewModels.Pages.Manage.HomeViewModel>();
                services.AddScoped<ViewModels.Pages.Manage.CodeManageViewModel>();
                services.AddScoped<ViewModels.Pages.Manage.CodeEditorViewModel>();
                services.AddScoped<ViewModels.Pages.Manage.DataCentralViewModel>();
                services.AddScoped<ViewModels.Pages.Manage.ConfigurationViewModel>();
                services.AddScoped<ViewModels.Pages.Manage.DeviceMonitorViewModel>();
                //admin
                services.AddScoped<Views.Pages.AdminPage>();
                services.AddScoped<ViewModels.Pages.AdminViewModel>();
                services.AddScoped<ViewModels.Pages.Admin.HomeViewModel>();
                services.AddScoped<Views.Pages.Admin.StandardPackagePage>();
                services.AddScoped<ViewModels.Pages.Admin.StandardPackageViewModel>();
                services.AddScoped<Views.Pages.Admin.DeviceManagePage>();
                services.AddScoped<ViewModels.Pages.Admin.DeviceManageViewModel>();
                services.AddSingleton<Views.Pages.Admin.MyAppAssistantPage>();
                services.AddSingleton<ViewModels.Pages.Admin.MyAppAssistantViewModel>();


                //about
                services.AddTransient<ViewModels.Pages.AboutViewModel>();
                services.AddTransient<Views.Pages.AboutPage>();

                services.AddScoped<Views.Pages.SettingsPage>();
                services.AddScoped<ViewModels.SettingsViewModel>();

                // Configuration
                services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
            })
            .UseSerilog()
            .Build();

        /// <summary>
        /// Gets registered service.
        /// </summary>
        /// <typeparam name="T">Type of the service to get.</typeparam>
        /// <returns>Instance of the service or <see langword="null"/>.</returns>
        public static T GetService<T>()
            where T : class
        {
            return _host.Services.GetService(typeof(T)) as T;
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
        }

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("一个未处理的异常：\n" + e.Exception.Message);
            e.Handled = true;
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}