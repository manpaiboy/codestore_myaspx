using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyAspx.Framework.WebUnit.Common
{
    public class ComFun
    {
        /// <summary>
        /// 动态反射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="newmodel"></param>
        /// <returns></returns>
        public static T NewObject<T>(T model, T newmodel)
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
        /// <summary>
        /// 页面请求数据转化为对像
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ReqConvertToModel<T>() where T : new()
        {

            // 定义集合  
            T t = new T();

            // 获得此模型的类型  
            Type type = typeof(T);
            //定义一个临时变量  
            string tempName = string.Empty;

            // 获得此模型的公共属性  
            PropertyInfo[] propertys = t.GetType().GetProperties();
            //遍历该对象的所有属性  
            foreach (PropertyInfo pi in propertys)
            {
                tempName = pi.Name;//将属性名称赋值给临时变量  
                pi.GetType().ToString();
                // 判断此属性是否有Setter  
                if (!pi.CanWrite) continue;//该属性不可写，直接跳出  
                //取值  
                object value = HttpContext.Current.Request[tempName];
                //如果非空，则赋给对象的属性  
                if (value != DBNull.Value && value != null)
                {
                    try
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
                    catch
                    {

                    }

                }
            }
            return t;

        }
        /// <summary>
        /// 计算文件大小函数(保留两位小数),Size为字节大小
        /// </summary>
        /// <param name="Size">初始文件大小</param>
        /// <returns></returns>
        public static string CountFileSize(long Size)
        {
            double KBCount = 1024;
            double MBCount = KBCount * 1024;
            double GBCount = MBCount * 1024;
            double TBCount = GBCount * 1024;
            string m_strSize = "";
            long FactSize = 0;
            FactSize = Size;
            if (FactSize < KBCount)
                m_strSize = FactSize.ToString("F2") + " Byte";
            else if (FactSize >= KBCount && FactSize < MBCount)
                m_strSize = (FactSize / KBCount).ToString("F2") + " KB";
            else if (FactSize >= MBCount && FactSize < GBCount)
                m_strSize = (FactSize / MBCount).ToString("F2") + " MB";
            else if (FactSize >= GBCount && FactSize < TBCount)
                m_strSize = (FactSize / GBCount).ToString("F2") + " GB";
            else if (FactSize >= TBCount)
                m_strSize = (FactSize / TBCount).ToString("F2") + " TB";
            return m_strSize;
        }
        public static string getFilesMD5Hash(string file)
        {
            //MD5 hash provider for computing the hash of the file
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //open the file
            FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);
            //calculate the files hash
            md5.ComputeHash(stream);
            //close our stream
            stream.Close();
            //byte array of files hash
            byte[] hash = md5.Hash;
            //string builder to hold the results
            StringBuilder sb = new StringBuilder();
            //loop through each byte in the byte array
            foreach (byte b in hash)
            {
                //format each byte into the proper value and append
                //current value to return value
                sb.Append(string.Format("{0:X2}", b));
            }
            //return the MD5 hash of the file
            return sb.ToString();
        }

        public static string GetCheckListItemsString<T>(string controlName, List<T> list, string itemValueName, string itemTextName, string defKey)
        {
            string str = "";
            foreach (T m in list)
            {
                Type t2 = typeof(T);
                str += "<input  type=\"checkbox\" value=\"" + t2.GetProperty(itemValueName).GetValue(m, null) + "\" " + (t2.GetProperty(itemValueName).GetValue(m, null) + "" == defKey ? " checked=\"checked\"" : "") + @" name='" + controlName + @"' />" + t2.GetProperty(itemTextName).GetValue(m, null) + "  ";
            }
            return str;
        }
        public static string GetDropItemsString<T>(List<T> list, string itemValueName, string itemTextName, string defKey)
        {
            string str = "";
            foreach (T m in list)
            {
                Type t2 = typeof(T);
                str += "<option value=\"" + t2.GetProperty(itemValueName).GetValue(m, null) + "\" " + (t2.GetProperty(itemValueName).GetValue(m, null) + "" == defKey ? " selected=\"selected\"" : "") + @">" + t2.GetProperty(itemTextName).GetValue(m, null) + "</option>";
            }
            return str;
        }
    }
}
