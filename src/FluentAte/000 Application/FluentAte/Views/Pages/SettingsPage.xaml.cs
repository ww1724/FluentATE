using FluentAte.ViewModels;
using Wpf.Ui.Controls.Navigation;

namespace FluentAte.Views.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : INavigableView<SettingsViewModel>
    {
        public SettingsViewModel ViewModel
        {
            get;
        }

        public SettingsPage(SettingsViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}