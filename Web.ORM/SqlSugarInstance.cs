﻿using Web.Library;
using SqlSugar;
using System.Collections.Generic;

namespace Web.ORM
{
    public partial class SqlSugarInstance
    {
        #region 构造：无参构造函数，禁止实例化 + public SqlSugarInstance()
        /// <summary>
        /// 禁止实例化
        /// </summary>
        public SqlSugarInstance()
        {
        }
        #endregion

        #region 静态：获取Sugar客户端实例对象 + public static SqlSugarClient GetInstance()
        /// <summary>
        /// 获取Sugar客户端实例对象
        /// </summary>
        /// <returns>SqlSugarClient</returns>
        public static SqlSugarClient GetInstance()
        {
            string connection = ConfigManger.GetAppSettings()["ConnectionString"];
            SqlSugarClient _SqlSugarClient = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connection,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            return _SqlSugarClient;
        }
        #endregion
    }
}
