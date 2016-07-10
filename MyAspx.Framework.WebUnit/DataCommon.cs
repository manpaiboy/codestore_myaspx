using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XYcms.Common
{
    public class DataCommon
    {
        static readonly string Connection = "name=POMonitorDBEntities";
        POMonitorDBEntities entities = new ENTITY.POMonitorDBEntities(Connection);
        
        #region 根据SQL语句查询数据
        public IEnumerable<T> ExecuteQuery<T>(string conn, string query, params object[] parms)
        {
            try
            {
                if (string.IsNullOrEmpty(conn))
                {
                    return entities.ExecuteStoreQuery<T>(query, parms);
                }
                else
                {
                    DataContext myDC = new DataContext(conn);
                    return myDC.ExecuteQuery<T>(query, parms);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<T> ExecuteQuery<T>(string query)
        {
            return ExecuteQuery<T>(string.Empty, query, new object[] { });
        }
        #endregion

        #region 执行操作类型SQl语句
        /// <summary>  
        /// 执行SQL命令  
        /// </summary>  
        /// <param name="sqlCommand"></param>  
        /// <returns></returns>  
        public int ExecuteSqlCommand(string sqlCommand, string connection = null)
        {
            if (string.IsNullOrEmpty(connection))
                return entities.ExecuteStoreCommand(sqlCommand); //ExecuteCommand(sqlCommand);  
            else
            {
                POMonitorDBEntities entitiesNew = new POMonitorDBEntities(connection);
                return entitiesNew.ExecuteStoreCommand(sqlCommand);
            }
        }
        /// <summary>  
        /// 执行SQL命令  
        /// </summary>  
        /// <param name="sqlCommand"></param>  
        /// <returns></returns>  
        public void ExecuteSqlCommand(string sqlCommand)
        {
            ExecuteSqlCommand(connection: string.Empty, sqlCommand: sqlCommand);
        }
        #endregion


        #region 私有方法
        private ObjectSet<T> GetTable<T>() where T : class
        {
            try
            {
                ObjectSet<T> customers = entities.CreateObjectSet<T>();
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region 统计指定条件的数据量
        /// <summary>  
        /// 统计指定条件的数据量  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="query"></param>  
        /// <returns></returns>  
        public virtual int Count<T>(Expression<Func<T, bool>> query) where T : class
        {
            var table = GetTable<T>();
            return (from t in table
                    select t).Where(query).Count();
        }
        #endregion


        #region 获取单个实体
        /// <summary>  
        /// 获取单个实体  
        /// </summary>  
        /// <typeparam name="T">泛型类型参数</typeparam>  
        /// <param name="express">查询条件</param>  
        /// <returns></returns>  
        public virtual T GetSingleEntity<T>(Expression<Func<T, bool>> query) where T : class
        {
            try
            {
                var table = GetTable<T>();
                return (from t in table
                        select t).Where(query).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region 更新实体
        /// <summary>  
        /// 更新实体  
        /// </summary>  
        /// <typeparam name="T">泛型类型参数</typeparam>  
        /// <param name="entity">更改后的实体</param>  
        public virtual bool Update<T>(T entity) where T : class
        {
            object propertyValue = null;
            T entityFromDB = GetSingleEntity<T>(s => s == entity);
            if (null == entityFromDB)
                return false;
            PropertyInfo[] properties = entityFromDB.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                propertyValue = null;
                if (null != property.GetSetMethod())
                {
                    PropertyInfo entityProperty =
                          entity.GetType().GetProperty(property.Name);
                    if (entityProperty.PropertyType.BaseType ==
                        Type.GetType("System.ValueType") ||
                        entityProperty.PropertyType ==
                        Type.GetType("System.String"))

                        propertyValue = entity.GetType().GetProperty(property.Name).GetValue(entity, null);
                    if (propertyValue == null)
                    {
                        Thread.Sleep(50);
                        propertyValue = entity.GetType().GetProperty(property.Name).GetValue(entity, null);
                    }
                    if (null != propertyValue)
                        property.SetValue(entityFromDB, propertyValue, null);
                }
            }

            entities.SaveChanges();
            return true;
        }

        #endregion


        #region 获取相关的实体信息
        /// <summary>  
        /// 分页_获取指定页的数据集合  
        /// </summary>  
        /// <typeparam name="T">泛型类型参数</typeparam>  
        /// <param name="query">查询条件</param>  
        /// <param name="pageSize">每页显示数量</param>  
        /// <param name="pageNum">当前页号</param>  
        /// <param name="pageTotal">总页数</param>  
        /// <param name="datasTotal">总数据量</param>  
        /// <returns></returns>  
        public virtual List<T> GetAllEntity<T>(Expression<Func<T, bool>> query, int pageSize, int pageNum, out int pageTotal, out int datasTotal) where T : class
        {
            var table = GetTable<T>();

            datasTotal = (from t in table
                          select t).Where(query).Count();

            pageTotal = datasTotal / pageSize + 1;

            return (from t in table
                    select t).Where(query).Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
        }
        /// <summary>  
        /// 分页_获取指定页的数据集合  
        /// </summary>  
        /// <typeparam name="T">泛型类型参数</typeparam>  
        /// <param name="query">查询条件</param>  
        /// <param name="pageSize">每页显示数量</param>  
        /// <param name="pageNum">当前页号</param>  
        /// <param name="pageTotal">总页数</param>  
        /// <param name="datasTotal">总数据量</param>  
        /// <returns></returns>  
        public virtual List<T> GetAllEntity<T>(Expression<Func<T, bool>> query, Func<T, object> orderByDesc, int pageSize, int pageNum, out int pageTotal, out int datasTotal) where T : class
        {
            var table = GetTable<T>();

            datasTotal = (from t in table
                          select t).Where(query).Count();

            pageTotal = (int)Math.Ceiling((double)datasTotal / pageSize);
            return (from t in table
                    select t).Where(query).OrderByDescending(orderByDesc).Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
        }
        /// <summary>  
        /// 获取指定条件的实体集合  

        /// </summary>  
        /// <typeparam name="T">泛型类型参数</typeparam>  
        /// <param name="query">查询条件</param>  
        /// <returns></returns>  
        public virtual List<T> GetAllEntity<T>(Expression<Func<T, bool>> query) where T : class
        {
            var table = GetTable<T>();
            return (from t in table
                    select t).Where(query).ToList();
        }

        /// <summary>  
        /// 获取指定条件的实体集合  

        /// </summary>  
        /// <typeparam name="T">泛型类型参数</typeparam>  
        /// <param name="query">查询条件</param>        
        /// <param name="orderAsc"></param>         
        /// <returns></returns>  
        public virtual List<T> GetAllEntity<T>(Expression<Func<T, bool>> query, bool isAsc, Func<T, object> order) where T : class
        {
            var table = GetTable<T>();
            if (isAsc)
                return (from t in table
                        select t).Where(query).OrderBy(order).ToList();
            return (from t in table
                    select t).Where(query).OrderByDescending(order).ToList();
        }

        public virtual List<T> GetAllEntity<T>() where T : class
        {
            var table = GetTable<T>();
            return (from t in table
                    select t).ToList();
        }
        #endregion


        #region 新增实体
        /// <summary>  
        /// 新增单个实体  
        /// </summary>  
        /// <typeparam name="T">泛型类型参数</typeparam>  
        /// <param name="entity">待插入的实体</param>  
        /// <returns></returns>  
        public virtual void InsertEntity<T>(T entity) where T : class
        {
            var table = GetTable<T>();
            table.AddObject(entity);
            entities.SaveChanges();
        }

        /// <summary>  
        /// 批量新增实体  
        /// </summary>  
        /// <typeparam name="T">泛型类型参数</typeparam>  
        /// <param name="entityList">待添加的实体集合</param>  
        /// <returns></returns>  
        public virtual void BatchInsertEntity<T>(List<T> entityList) where T : class
        {
            if (entityList.Count > 0)
            {
                var table = GetTable<T>();
                foreach (var item in entityList)
                {
                    table.AddObject(item);//DeleteAllOnSubmit(toDeletedColl);  
                }
                entities.SaveChanges();
            }
        }
        #endregion

        #region 删除实体
        /// <summary>  
        /// 根据条件删除指定实体  
        /// </summary>  
        /// <typeparam name="T">实体</typeparam>  
        /// <param name="query">条件</param>  
        /// <returns>bool</returns>  
        public virtual void DeleteEntitys<T>(Expression<Func<T, bool>> query) where T : class
        {
            var table = GetTable<T>();
            var toDeletedColl = table.Where(query);
            if (toDeletedColl != null && toDeletedColl.Count() > 0)
            {
                foreach (var item in toDeletedColl)
                {
                    table.DeleteObject(item);//DeleteAllOnSubmit(toDeletedColl);  
                }
                entities.SaveChanges();
            }
        }
        #endregion
    }  
}
