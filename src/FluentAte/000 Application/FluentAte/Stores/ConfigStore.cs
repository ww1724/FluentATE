using ATE.Common.Configuration.Interfaces;
using ATE.Common.Configuration.Models;
using ATE.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace FluentAte.Stores
{
    public partial class ConfigStore : ObservableObject
    {
        private IConfigManager _configManager;

        [ObservableProperty]
        ObservableCollection<IConfigItem> configItems;

        public ConfigStore(ConfigManager configManager) { 
            _configManager = configManager;

            configItems = new ObservableCollection<IConfigItem>(configManager.GetConfigs().Select(x => new ConfigItem
            {
                Type = x.GetType(),
                Title = x.Title,
                Value = x.Value,
                Name = x.Name,
                Description = x.Description,
            }).ToList());
        }

    }
}
