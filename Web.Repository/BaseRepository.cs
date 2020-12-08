using Web.IRepository;
using Web.ORM;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Web.Repository
{
    public partial class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        #region 方法：插入数据 + public object Insert(T entity, bool isIdentity = true)
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="model">将某些字段排除，用于自增列使用</param>
        /// <returns></returns>
        public object Insert(T entity, Expression<Func<T, object>> model = null)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                if (model != null)
                {
                    //IgnoreColumns排除那一列不插入
                    var res = dbClient.Insertable<T>(entity).IgnoreColumns(model).ExecuteCommand();
                    dbClient.Ado.CommitTran();
                    return res;
                }
                else
                {
                    var res = dbClient.Insertable<T>(entity).ExecuteCommand();
                    dbClient.Ado.CommitTran();
                    return res;
                }
            }
        }
        #endregion

        #region 方法：批量插入数据 + public List<object> InsertRange(List<T> entites, bool isIdentity = true)
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entites">实体集合</param>
        /// <param name="model">将某些字段排除，用于自增列使用</param>
        /// <returns></returns>
        public int InsertRange(List<T> entites, Expression<Func<T, object>> model = null)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                try
                {
                    //开启事物
                    dbClient.Ado.BeginTran();
                    if (model != null)
                    {
                        //IgnoreColumns排除那一列不插入
                        var res = dbClient.Insertable<T>(entites).IgnoreColumns(model).ExecuteCommand();
                        dbClient.Ado.CommitTran();
                        return res;
                    }
                    else
                    {
                        var res = dbClient.Insertable<T>(entites).ExecuteCommand();
                        dbClient.Ado.CommitTran();
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    //事务回滚
                    dbClient.RollbackTran();
                    throw ex;
                }
            }
        }
        #endregion

        #region 方法：批量插入大量数据 + public List<object> InsertRange(List<T> entites, bool isIdentity = true)
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entites">实体集合</param>
        /// <param name="model">将某些字段排除，用于自增列使用</param>
        /// <returns></returns>
        public int InsertNumerousRange(List<T> entites, Expression<Func<T, object>> model = null)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                try
                {
                    //开启事物
                    dbClient.Ado.BeginTran();
                    if (model != null)
                    {
                        //IgnoreColumns排除那一列不插入
                        var res = 0;
                        while (entites.Count() > 2000) {
                            var list = entites.Take(2000).ToList();
                            res+= dbClient.Insertable<T>(list).IgnoreColumns(model).ExecuteCommand();
                            entites.RemoveRange(0,2000);
                        }
                        res += dbClient.Insertable<T>(entites).IgnoreColumns(model).ExecuteCommand();
                        dbClient.Ado.CommitTran();
                        return res;
                    }
                    else
                    {
                        var res = 0;
                        while (entites.Count() > 2000)
                        {
                            var list = entites.Take(2000).ToList();
                            res += dbClient.Insertable<T>(list).ExecuteCommand();
                            entites.RemoveRange(0, 2000);
                        }
                        res += dbClient.Insertable<T>(entites).ExecuteCommand();
                        dbClient.Ado.CommitTran();
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    //事务回滚
                    dbClient.RollbackTran();
                    throw ex;
                }
            }
        }
        #endregion

        #region 方法：更新实体所有的列 + public bool Update(T model)
        /// <summary>
        /// 更新实体所有的列
        /// </summary>
        /// <param name="model">实体对象，主键必须是第一位</param>
        /// <returns></returns>
        public int Update(T model)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                //开启事物
                dbClient.Ado.BeginTran();
                var res = dbClient.Updateable<T>(model).ExecuteCommand();
                dbClient.Ado.CommitTran();
                return res;
            }
        }
        #endregion

        #region 方法：更新数据 + public bool Update(object model, Expression<Func<T, bool>> expression)
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model">entity为T类型将更新该实体的非主键所有列，如果rowObj类型为匿名类将更新指定列</param>
        /// <param name="expression">Lambda表达式</param>
        /// <returns></returns>
        public int Update(object model, Expression<Func<T, bool>> expression)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                try
                {
                    //开启事物
                    dbClient.Ado.BeginTran();
                    var res = dbClient.Updateable<T>(model).Where(expression).ExecuteCommand();
                    dbClient.Ado.CommitTran();
                    return res;
                }
                catch (Exception ex)
                {
                    dbClient.RollbackTran();
                    throw ex;
                }
            }
        }
        #endregion

        #region 方法：删除数据 + public bool Delete(Expression<Func<T, bool>> expression)
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <returns></returns>
        public int Delete(Expression<Func<T, bool>> expression)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                try
                {
                    //使用事物删除操作
                    dbClient.Ado.BeginTran();
                    var res = dbClient.Deleteable<T>().Where(expression).ExecuteCommand();
                    dbClient.Ado.CommitTran();
                    return res;
                }
                catch (Exception ex)
                {
                    dbClient.RollbackTran();
                    throw ex;
                }
            }
        }
        #endregion

        #region 方法：删除数据（集合） public int DeleteList(List<T> list)
        /// <summary>
        /// 删除数据（集合）
        /// </summary>
        /// <param name="list"></param>
        /// var  t1 = db.Deleteable<Student>().Where(new List<Student>() { new Student() { Id = 1 } }).ExecuteCommand();
        /// <returns></returns>
        public int DeleteList(List<T> list)
        {
            SqlSugarClient dbClient = SqlSugarInstance.GetInstance();
            try
            {
                dbClient.Ado.BeginTran();
                var res = dbClient.Deleteable<T>().Where(list).ExecuteCommand();
                dbClient.Ado.CommitTran();
                return res;
            }
            catch (Exception ex)
            {
                dbClient.Ado.RollbackTran();
                throw ex;
            }
        }
        #endregion

        #region 方法：删除数据（根据主键）public int DelteteByID(object ID)
        /// <summary>
        /// 删除数据（根据主键）
        /// </summary>
        /// <param name="ID"></param>
        /// var t3 = db.Deleteable<Student>().In(1).ExecuteCommand()
        /// <returns></returns>
        public int DelteteByID(object ID)
        {
            SqlSugarClient dbClient = SqlSugarInstance.GetInstance();
            try
            {
                //使用事物删除操作
                dbClient.Ado.BeginTran();
                var res = dbClient.Deleteable<T>().In(ID).ExecuteCommand();
                dbClient.Ado.CommitTran();
                return res;
            }
            catch (Exception ex)
            {
                dbClient.Ado.RollbackTran();
                throw ex;
            }
        }
        #endregion

        #region 方法：查询一个 + public T QuerySingle()
        /// <summary>
        /// 查询一个
        /// </summary>
        /// <returns></returns>
        public T QuerySingle()
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                return dbClient.Queryable<T>().Single();
            }
        }
        #endregion

        #region 方法：查询一个 + public T QuerySingle(Expression<Func<T, bool>> expression)
        /// <summary>
        /// 查询一个
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <returns></returns>
        public T QuerySingle(Expression<Func<T, bool>> expression)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                return dbClient.Queryable<T>().Single(expression);
            }
        }
        #endregion

        #region 方法：查询所有 + public List<T> QueryAll()
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<T> QueryAll()
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                return dbClient.Queryable<T>().ToList();
            }
        }
        #endregion

        #region 方法：查询所有 + public List<T> QueryByWhere(Expression<Func<T, bool>> whereExpression, string orderbyStr)
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderbyStr">排序字符串</param>
        /// <returns></returns>
        public List<T> QueryByWhere(Expression<Func<T, bool>> whereExpression, string orderbyStr)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                if (string.IsNullOrEmpty(orderbyStr))
                {
                    return dbClient.Queryable<T>().Where(whereExpression).ToList();
                }
                else
                {
                    return dbClient.Queryable<T>().Where(whereExpression).OrderBy(orderbyStr).ToList();
                }
            }
        }
        #endregion

        #region 方法：查询所有 + public List<T> QueryByWhere(Expression<Func<T, bool>> whereExpression, string orderbyStr, string whereString = "1=1", object whereObj = null)
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderbyStr">排序字段</param>
        /// <param name="whereString">where字符串</param>
        /// <param name="whereObj">命令参数对应匿名对象</param>
        /// <returns></returns>
        public List<T> QueryByWhere(Expression<Func<T, bool>> whereExpression, string orderbyStr, string whereString = "1=1", object whereObj = null)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                return dbClient.Queryable<T>().Where(whereExpression).Where(whereString, whereObj).OrderBy(orderbyStr).ToList();
            }
        }
        #endregion

        #region 方法：单表分页查询 + public List<T> QueryByWherePage(int pageIndex, int pageSize, Expression<Func<T, bool>> whereExpression, string orderbyStr)
        /// <summary>
        /// 单表分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderbyStr">排序字段</param>
        /// <returns></returns>
        public List<T> QueryByWherePage(int pageIndex, int pageSize, Expression<Func<T, bool>> whereExpression, string orderbyStr)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                return dbClient.Queryable<T>().Where(whereExpression).OrderBy(orderbyStr).ToPageList(pageIndex, pageSize);
            }
        }
        #endregion

        #region 方法：单表分页查询 + public List<T> QueryByWherePage(int pageIndex, int pageSize, Expression<Func<T, bool>> whereExpression, string orderbyStr, string whereString = "1=1", object whereObj = null)
        /// <summary>
        /// 单表分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderbyStr">排序字段</param>
        /// <param name="whereString">where字符串</param>
        /// <param name="whereObj">命令参数对应匿名对象</param>
        /// <returns></returns>
        public List<T> QueryByWherePage(int pageIndex, int pageSize, Expression<Func<T, bool>> whereExpression, string orderbyStr, string whereString = "1=1", object whereObj = null)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                return dbClient.Queryable<T>().Where(whereExpression).Where(whereString, whereObj).OrderBy(orderbyStr).ToPageList(pageIndex, pageSize);
            }
        }
        #endregion

        #region 方法：查询索引多少到多少条 + public List<T> QueryByRange(int skipNum, int takeNum, Expression<Func<T, bool>> whereExpression, string orderbyStr)
        /// <summary>
        /// 查询索引多少到多少条
        /// </summary>
        /// <param name="skipNum">跳过的索引</param>
        /// <param name="takeNum">结束索引</param>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderbyStr">排序字段</param>
        /// <returns></returns>
        public List<T> QueryByRange(int skipNum, int takeNum, Expression<Func<T, bool>> whereExpression, string orderbyStr)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                return dbClient.Queryable<T>().Where(whereExpression).OrderBy(orderbyStr).Skip(skipNum).Take(takeNum).ToList();
            }
        }
        #endregion

        #region 方法：查询索引后的所有数据 + public List<T> QuerySkipfterIndex(int skipNum, Expression<Func<T, bool>> whereExpression, string orderbyStr)
        /// <summary>
        /// 查询索引后的所有数据
        /// </summary>
        /// <param name="skipNum">跳过的索引</param>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderbyStr">排序字段</param>
        /// <returns></returns>
        public List<T> QuerySkipfterIndex(int skipNum, Expression<Func<T, bool>> whereExpression, string orderbyStr)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                return dbClient.Queryable<T>().Where(whereExpression).OrderBy(orderbyStr).Skip(skipNum).ToList();
            }
        }
        #endregion

        #region 方法：查询指定个数的数据 + public List<T> QueryTakeIndex(int takeNum, Expression<Func<T, bool>> whereExpression, string orderbyStr)
        /// <summary>
        /// 查询指定个数的数据
        /// </summary>
        /// <param name="takeNum">指定个数</param>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderbyStr">排序字段</param>
        /// <returns></returns>
        public List<T> QueryTakeIndex(int takeNum, Expression<Func<T, bool>> whereExpression, string orderbyStr)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                return dbClient.Queryable<T>().Where(whereExpression).OrderBy(orderbyStr).Take(takeNum).ToList();
            }
        }
        #endregion

        #region 方法：查询条数 + public int QueryCount(Expression<Func<T, bool>> whereExpression)
        /// <summary>
        /// 查询条数
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <returns></returns>
        public int QueryCount(Expression<Func<T, bool>> whereExpression)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                return dbClient.Queryable<T>().Where(whereExpression).Count();
            }
        }
        #endregion

        #region 方法：查询是否存在记录 + public bool Any(Expression<Func<T, bool>> whereExpression)
        /// <summary>
        /// 查询是否存在记录
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> whereExpression)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                return dbClient.Queryable<T>().Any(whereExpression);
            }
        }
        #endregion

        #region 方法：执行sql语句或存储过程 + public List<TResult> QueryBySql<TResult>(string sql, object whereObj = null)
        /// <summary>
        /// 执行sql语句或存储过程
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="whereObj">命令参数对应匿名对象</param>
        /// <returns></returns>
        public List<TResult> QueryBySql<TResult>(string sql, object whereObj = null)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                //使用事物删除操作
                dbClient.Ado.BeginTran();
                var res = dbClient.Ado.SqlQuery<TResult>(sql, whereObj);
                dbClient.Ado.CommitTran();
                return res;
            }
        }
        #endregion

        #region 方法：事务执行sql语句或存储过程 + public List<TResult> QueryBySqlTransactions<TResult>(string sql, object whereObj = null)
        /// <summary>
        /// 事务执行sql语句或存储过程
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="whereObj">命令参数对应匿名对象</param>
        /// <returns></returns>
        public List<TResult> QueryBySqlTransactions<TResult>(string sql, object whereObj = null)
        {
            using (SqlSugarClient dbClient = SqlSugarInstance.GetInstance())
            {
                try
                {
                    //开启事物
                    dbClient.Ado.BeginTran();
                    var res = dbClient.Ado.SqlQuery<TResult>(sql, whereObj);
                    dbClient.Ado.CommitTran();
                    return res;
                }
                catch (Exception ex)
                {
                    dbClient.RollbackTran();
                    throw ex;
                }
            }
        }
        #endregion

        

        /*
         * 多表查询建议用视图或者存储过程，就不再封装，有必要时添加拓展方法
         */
    }
}
