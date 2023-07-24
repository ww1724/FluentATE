using ATE.Common.Configuration.Interfaces;
using ATE.Common.Configuration.Models;
using ATE.Common.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Service
{
    public class ConfigManager : IConfigManager
    {
        private DbService _dbService;

        private List<Dictionary<string, object>> m_configs;

        public ConfigManager(DbService dbService)
        {
            _dbService = dbService;
            InitializeComponent();
        }


        public void InitializeComponent()
        {
            m_configs = new List<Dictionary<string, object>>();
            //var db_configs = _dbService.Query
        }



        public void RefreshConfigurations()
        {
            throw new NotImplementedException();
        }

        public void RegisterConfig(IConfigItem item)
        {
            _dbService.Insert<ConfigEntity>(new ConfigEntity
            {
                Name = item.Name,
                Title = item.Title,
                Value = item.Value,
                Description = item.Description,
                Type = item.Type.ToString(),
            });
        }

        public void SetConfigValue(string id, object value)
        {
            throw new NotImplementedException();
        }

        public object GetConfigValue(string id)
        {
            throw new NotImplementedException();
        }

        public List<ConfigItem> GetConfigs()
        {
            return _dbService.Query<ConfigEntity>().Select(x => new ConfigItem
            {
                Description = x.Description,
             Name = x.Name,
              Value = ParseValue(Type.GetType(x.Type) ?? typeof(string), x.Value as string),
               Title = x.Title,
                Type = Type.GetType(x.Type) ?? typeof(string)
            }).ToList();
        }

        public static object ParseValue(Type type, string value)
        {
            if (type == typeof(bool))
            {
                return value == "1" ? true : false;
            }

            return value;
        }
    }
}
