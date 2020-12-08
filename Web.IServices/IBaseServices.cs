using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Web.IServices
{
    public partial interface IBaseServices<T> where T : class, new()
    {
        #region 方法：插入数据 + public object Insert(T entity, bool isIdentity = true)
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="model">将某些字段排除，用于自增列使用</param>
        /// <returns></returns>
        object Insert(T entity, Expression<Func<T, object>> model = null);
        #endregion

        #region 方法：批量插入数据 + public List<object> InsertRange(List<T> entites, bool isIdentity = true)
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entites">实体集合</param>
        /// <param name="model">将某些字段排除，用于自增列使用</param>
        /// <returns></returns>
        int InsertRange(List<T> entites, Expression<Func<T, object>> model = null);
        #endregion

        #region 方法：批量插入大量数据 + public List<object> InsertRange(List<T> entites, bool isIdentity = true)
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entites">实体集合</param>
        /// <param name="model">将某些字段排除，用于自增列使用</param>
        /// <returns></returns>
        int InsertNumerousRange(List<T> entites, Expression<Func<T, object>> model = null);
        #endregion

        #region 方法：更新实体所有的列 + public bool Update(T model)
        /// <summary>
        /// 更新实体所有的列
        /// </summary>
        /// <param name="model">实体对象，主键必须是第一位</param>
        /// <returns></returns>
        int Update(T model);
        #endregion

        #region 方法：更新数据 + public bool Update(object model, Expression<Func<T, bool>> expression)
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model">entity为T类型将更新该实体的非主键所有列，如果rowObj类型为匿名类将更新指定列</param>
        /// <param name="expression">Lambda表达式</param>
        /// <returns></returns>
        int Update(object model, Expression<Func<T, bool>> expression);
        #endregion

        #region 方法：删除数据 + public bool Delete(Expression<Func<T, bool>> expression)
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <returns></returns>
        int Delete(Expression<Func<T, bool>> expression);
        #endregion

        #region 方法：删除数据（集合） public int DeleteList(List<T> list)
        /// <summary>
        /// 删除数据（集合）
        /// </summary>
        /// <param name="list"></param>
        /// var  t1 = db.Deleteable<Student>().Where(new List<Student>() { new Student() { Id = 1 } }).ExecuteCommand();
        /// <returns></returns>
        int DeleteList(List<T> list);
        #endregion

        #region 方法：删除数据（根据主键）public int DelteteByID(object ID)
        /// <summary>
        /// 删除数据（根据主键）
        /// </summary>
        /// <param name="ID"></param>
        /// var t3 = db.Deleteable<Student>().In(1).ExecuteCommand()
        /// <returns></returns>
        int DelteteByID(object ID);
        #endregion

        #region 方法：查询一个 + public T QuerySingle()
        /// <summary>
        /// 查询一个
        /// </summary>
        /// <returns></returns>
        T QuerySingle();
        #endregion

        #region 方法：查询一个 + public T QuerySingle(Expression<Func<T, bool>> expression)
        /// <summary>
        /// 查询一个
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <returns></returns>
        T QuerySingle(Expression<Func<T, bool>> expression);
        #endregion

        #region 方法：查询所有 + public List<T> QueryAll()
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        List<T> QueryAll();
        #endregion

        #region 方法：查询所有 + public List<T> QueryByWhere(Expression<Func<T, bool>> whereExpression, string orderbyStr)
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderbyStr">排序字符串</param>
        /// <returns></returns>
        List<T> QueryByWhere(Expression<Func<T, bool>> whereExpression, string orderbyStr);
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
        List<T> QueryByWhere(Expression<Func<T, bool>> whereExpression, string orderbyStr, string whereString = "1=1", object whereObj = null);
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
        List<T> QueryByWherePage(int pageIndex, int pageSize, Expression<Func<T, bool>> whereExpression, string orderbyStr);
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
        List<T> QueryByWherePage(int pageIndex, int pageSize, Expression<Func<T, bool>> whereExpression, string orderbyStr, string whereString = "1=1", object whereObj = null);
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
        List<T> QueryByRange(int skipNum, int takeNum, Expression<Func<T, bool>> whereExpression, string orderbyStr);
        #endregion

        #region 方法：查询索引后的所有数据 + public List<T> QuerySkipfterIndex(int skipNum, Expression<Func<T, bool>> whereExpression, string orderbyStr)
        /// <summary>
        /// 查询索引后的所有数据
        /// </summary>
        /// <param name="skipNum">跳过的索引</param>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderbyStr">排序字段</param>
        /// <returns></returns>
        List<T> QuerySkipfterIndex(int skipNum, Expression<Func<T, bool>> whereExpression, string orderbyStr);
        #endregion

        #region 方法：查询指定个数的数据 + public List<T> QueryTakeIndex(int takeNum, Expression<Func<T, bool>> whereExpression, string orderbyStr)
        /// <summary>
        /// 查询指定个数的数据
        /// </summary>
        /// <param name="takeNum">指定个数</param>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderbyStr">排序字段</param>
        /// <returns></returns>
        List<T> QueryTakeIndex(int takeNum, Expression<Func<T, bool>> whereExpression, string orderbyStr);
        #endregion

        #region 方法：查询条数 + public int QueryCount(Expression<Func<T, bool>> whereExpression)
        /// <summary>
        /// 查询条数
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <returns></returns>
        int QueryCount(Expression<Func<T, bool>> whereExpression);
        #endregion

        #region 方法：查询是否存在记录 + public bool Any(Expression<Func<T, bool>> whereExpression)
        /// <summary>
        /// 查询是否存在记录
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <returns></returns>
        bool Any(Expression<Func<T, bool>> whereExpression);
        #endregion

        #region 方法：执行sql语句或存储过程 + public List<TResult> QueryBySql<TResult>(string sql, object whereObj = null)
        /// <summary>
        /// 执行sql语句或存储过程
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="whereObj">命令参数对应匿名对象</param>
        /// <returns></returns>
        List<TResult> QueryBySql<TResult>(string sql, object whereObj = null);
        #endregion

        #region 方法：事务执行sql语句或存储过程 + public List<TResult> QueryBySqlTransactions<TResult>(string sql, object whereObj = null)
        /// <summary>
        /// 事务执行sql语句或存储过程
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="whereObj">命令参数对应匿名对象</param>
        /// <returns></returns>
        List<TResult> QueryBySqlTransactions<TResult>(string sql, object whereObj = null);
        #endregion

        /*
         * 多表查询建议用视图或者存储过程，就不再封装，有必要时添加拓展方法
         */
    }
}
