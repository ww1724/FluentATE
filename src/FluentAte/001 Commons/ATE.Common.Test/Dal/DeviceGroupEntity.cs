using SqlSugar;

namespace ATE.Common.Test.Dal
{
    [SugarTable("DeviceGroup")]
    public class DeviceGroupEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(ColumnDataType = "varchar(100)", IsNullable = true)]
        public string GroupId { get; set; }

        [SugarColumn(ColumnDataType = "varchar(100)", IsNullable = false)]
        public string GroupName { get; set; }

    }
}
