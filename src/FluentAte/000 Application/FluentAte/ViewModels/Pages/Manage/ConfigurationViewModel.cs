using ATE.Common.Configuration.Interfaces;
using ATE.Common.Configuration.Models;
using ATE.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAte.Stores;
using System.Collections.ObjectModel;
using System.Linq;

namespace FluentAte.ViewModels.Pages.Manage
{
    public partial class ConfigurationViewModel : ObservableObject
    {

        public ConfigStore ConfigStore { get; set; }

        public ConfigurationViewModel(ConfigStore configStore)
        {
            ConfigStore = configStore;
        }


    }
}
