using ATE.Common.Configuration.Interfaces;
using SqlSugar;

namespace ATE.Common.Dal
{
    public class ConfigEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description {get; set; }

        public string Type { get;set; }

        public object Value { get; set; }
    }
}
