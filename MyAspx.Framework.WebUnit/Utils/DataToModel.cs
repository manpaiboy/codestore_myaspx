
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAspx.Framework.WebUnit.Common
{
    public class DataToModel<T> where T : new()
    { /// <summary>
        /// 动态反射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="newmodel"></param>
        /// <returns></returns>
        public static T NewObject(T model, T newmodel)
        {
            Type t2 = typeof(T);
            PropertyInfo[] propertys2 = t2.GetProperties();
            foreach (PropertyInfo pi in propertys2)
            {
                string name = pi.Name;
                object value = t2.GetProperty(name).GetValue(model, null);
                if (!pi.CanWrite) continue;//该属性不可写，直接跳出  

                if (value != null)
                {
                    value = (value + "").Trim();
                    if (pi.PropertyType.ToString() == "System.DateTime")
                    {
                        if (Convert.ToDateTime(value).Ticks == 0)
                            continue;
                    }
                    if (!pi.PropertyType.IsGenericType)
                    {
                        //非泛型
                        pi.SetValue(newmodel, string.IsNullOrEmpty(value + "") ? null : Convert.ChangeType(value, pi.PropertyType), null);
                    }
                    else
                    {
                        //泛型Nullable<>
                        Type genericTypeDefinition = pi.PropertyType.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(Nullable<>))
                        {
                            pi.SetValue(newmodel, string.IsNullOrEmpty(value + "") ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(pi.PropertyType)), null);
                        }
                    }
                }
            }
            return newmodel;
        }
        public static List<T> ConvertToList(DataTable dt)
        {

            // 定义集合  
            List<T> ts = new List<T>();

            // 获得此模型的类型  
            Type type = typeof(T);
            //定义一个临时变量  
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行  
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性  
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性  
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量  
                    //检查DataTable是否包含此列（列名==对象的属性名）    
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter  
                        if (!pi.CanWrite) continue;//该属性不可写，直接跳出  
                        //取值  
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性  
                        if (value != DBNull.Value && value != null)
                        {
                            if (!pi.PropertyType.IsGenericType)
                            {
                                //非泛型
                                pi.SetValue(t, string.IsNullOrEmpty(value + "") ? null : Convert.ChangeType(value, pi.PropertyType), null);
                            }
                            else
                            {
                                //泛型Nullable<>
                                Type genericTypeDefinition = pi.PropertyType.GetGenericTypeDefinition();
                                if (genericTypeDefinition == typeof(Nullable<>))
                                {
                                    pi.SetValue(t, string.IsNullOrEmpty(value + "") ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(pi.PropertyType)), null);
                                }
                            }
                        }
                    }
                }
                //对象添加到泛型集合中  
                ts.Add(t);
            }

            return ts;

        }

        /// <summary>
        /// 通过传入的SQL返回分页后的SQL
        /// </summary>
        /// <param name="sql">查询SQL语句</param>
        /// <param name="startRowNum">起始的行号</param>
        /// <param name="pageSize">每页条数</param>
        ///   <param name="OrderRowName">排序字段 后面可以加 DESC 或 ASC</param>
        /// <returns></returns>
        public static string GetPageSql(string sql, int currentPage, int pageSize, string OrderRowName)
        {
            int curr = currentPage < 1 ? 1 : currentPage;
            int startRowNum = (curr - 1) * pageSize + 1;
            int endRowNum = currentPage * pageSize;
            string mysql = "";
            mysql = @"SELECT *,(SELECT COUNT(*)  FROM( " + sql +
                           @"  )AS h  ) AS 'num' FROM (SELECT *,ROW_NUMBER() OVER 
                          (ORDER BY " + OrderRowName + @") AS 'RowNumber' FROM ( " + sql + ")AS c) a  WHERE a.RowNumber BETWEEN " + startRowNum + "  AND " + endRowNum;
            return mysql;
        }

        //public static  List<T> GetListBySql(string sql, int currentPage, int pageSize, string OrderRowName,out int count)
        //{
        //   return   DataToModel<T>.ConvertToList(GetDataSetPage(GetPageSql(sql, currentPage, pageSize, OrderRowName), out count).Tables[0]);
        //}
        public static T ConvertToModel(DataRow dr)
        {
            // 定义集合  

            //定义一个临时变量  
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行  

            T t = new T();
            // 获得此模型的公共属性  
            PropertyInfo[] propertys = t.GetType().GetProperties();
            //遍历该对象的所有属性  
            foreach (PropertyInfo pi in propertys)
            {
                tempName = pi.Name;//将属性名称赋值给临时变量  
                //检查DataTable是否包含此列（列名==对象的属性名）    
                if (dr.Table.Columns.Contains(tempName))
                {
                    // 判断此属性是否有Setter  
                    if (!pi.CanWrite) continue;//该属性不可写，直接跳出  
                    //取值  
                    object value = dr[tempName];
                    //如果非空，则赋给对象的属性  
                    if (value != DBNull.Value && value != null)
                    {
                        if (!pi.PropertyType.IsGenericType)
                        {
                            //非泛型
                            pi.SetValue(t, string.IsNullOrEmpty(value + "") ? null : Convert.ChangeType(value, pi.PropertyType), null);
                        }
                        else
                        {
                            //泛型Nullable<>
                            Type genericTypeDefinition = pi.PropertyType.GetGenericTypeDefinition();
                            if (genericTypeDefinition == typeof(Nullable<>))
                            {
                                pi.SetValue(t, string.IsNullOrEmpty(value + "") ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(pi.PropertyType)), null);
                            }
                        }
                    }
                }
            }
            //对象添加到泛型集合中  
            return t;
        }  
    }
}
