using ATE.Common.Configuration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Common.Configuration.Interfaces
{
    public interface IConfigManager
    {
        public void InitializeComponent();

        public void RefreshConfigurations();

        public void RegisterConfig(IConfigItem item);

        public void SetConfigValue(string id, object value);

        public object GetConfigValue(string id);

        public List<ConfigItem> GetConfigs();

    }
}
