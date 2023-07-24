using ATE.Common.Contracts;
using ATE.Common.Dal;
using ATE.Common.Test.Dal;
using SqlSugar;
using System.Configuration;

namespace ATE.Service
{
    public class DbService : IAppService
    {
        // service
        public string Id => "Core.DbService";

        public string ServiceName => "核心数据库服务";

        public bool IsRunning { get; private set; }

        // db config
        public string StateString => "default";

        private SqlSugarClient sugarClient { get; set; }

        private DbType DbType => DbType.MySql;

        public DbService()
        {
            sugarClient = new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["MysqlConnectionString"].ConnectionString,
                DbType = DbType
            });
            InitTables();
        }

        private void InitTables()
        {
            sugarClient.DbMaintenance.CreateDatabase();
            sugarClient.CodeFirst.InitTables(
                typeof(UserEntity),
                typeof(DeviceGroupEntity),
                typeof(ConfigEntity)
                );
            if (!sugarClient.Queryable<UserEntity>().Any())
            {
                sugarClient.InsertableByObject(new UserEntity
                {
                    Name = "Zoran.Yang",
                    Role = "SuperAdmin",
                    Passwd = "db49172",
                }).ExecuteCommand();
            }


            //if (!sugarClient.Queryable<ConfigurationEntity>().Any())
            //{
            //    sugarClient.InsertableByObject(new ConfigurationEntity
            //    {
            //        Key = "IsInitializeDb",
            //        Value = "True"
            //    }).ExecuteCommand();
            //}
        }

        /// <summary>
        /// 通用查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public List<T> Query<T>(string condition = "")
        {
            return sugarClient.Queryable<T>().ToList();
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public int Insert<T>(T entity)
        {
            return sugarClient.InsertableByObject(entity).ExecuteCommand();
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Update<T>(T entity)
        {
            return sugarClient.UpdateableByObject(entity).ExecuteCommand();
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Delete<T>(T entity)
        {
            return 0;
        }
    }
}
