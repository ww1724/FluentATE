using FluentAte.ViewModels.Pages;
using FluentAte.ViewModels.Pages.Admin;
using Wpf.Ui.Controls.Navigation;

namespace FluentAte.Views.Pages.Admin
{
    /// <summary>
    /// DeviceManagePage.xaml 的交互逻辑
    /// </summary>
    public partial class StandardPackagePage : INavigableView<StandardPackageViewModel>
    {
        public StandardPackageViewModel ViewModel
        {
            get;
        }
        public StandardPackagePage(StandardPackageViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
        }
    }
}
