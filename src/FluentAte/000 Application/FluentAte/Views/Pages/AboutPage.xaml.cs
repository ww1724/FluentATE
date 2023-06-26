using FluentAte.ViewModels.Pages;
using Wpf.Ui.Controls.Navigation;

namespace FluentAte.Views.Pages
{
    /// <summary>
    /// ManagePage.xaml 的交互逻辑
    /// </summary>
    public partial class AboutPage : INavigableView<AboutViewModel>
    {
        public AboutViewModel ViewModel
        {
            get;
        }

        public AboutPage(AboutViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
        }
    }
}
