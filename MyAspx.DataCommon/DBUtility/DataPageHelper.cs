using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

namespace MyAspx.DataCommon.DBUtility
{
    public class DataPageHelper
    {
        public static DataSet GetDataPage(string sql, out int count)
        {
            count = 0;
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Contains("num"))
                count = Convert.ToInt32(ds.Tables[0].Rows[0]["num"]);
            return ds;
        }
        /// <summary>
        /// DataTable分页
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="PageIndex">页索引,注意：从1开始</param>
        /// <param name="PageSize">每页大小</param>
        /// <returns>分好页的DataTable数据</returns>              第1页        每页10条
        public static DataTable GetPagedTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (PageIndex == 0) { return dt; }
            DataTable newdt = dt.Copy();
            newdt.Clear();
            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
            { return newdt; }

            if (rowend > dt.Rows.Count)
            { rowend = dt.Rows.Count; }
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }
            return newdt;
        }

        /// <summary>
        /// 返回分页的页数
        /// </summary>
        /// <param name="count">总条数</param>
        /// <param name="pageye">每页显示多少条</param>
        /// <returns>如果 结尾为0：则返回1</returns>
        public static int PageCount(int count, int pageye)
        {
            int page = 0;
            int sesepage = pageye;
            if (count % sesepage == 0) { page = count / sesepage; }
            else { page = (count / sesepage) + 1; }
            if (page == 0) { page += 1; }
            return page;
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
            //            mysql = @"SELECT *,(SELECT COUNT(*)  FROM( " + sql +
            //                           @"  )AS h  ) AS 'num' FROM (SELECT *,ROW_NUMBER() OVER 
            //                          (ORDER BY " + OrderRowName + @") AS 'RowNumber' FROM ( " + sql + ")AS c) a  WHERE a.RowNumber BETWEEN " + startRowNum + "  AND " + endRowNum;
            mysql = @"SELECT *,(SELECT COUNT(*)  FROM( " + sql +
                           @"  )AS h  ) AS 'num' FROM (SELECT *,ROW_NUMBER() OVER 
                          (ORDER BY " + OrderRowName + @") AS 'RowNumber' FROM ( " + sql + ")AS c) a  WHERE a.RowNumber BETWEEN " + startRowNum + "  AND " + endRowNum;
            return mysql;
        }
        /// <summary>
        /// 通过传入的SQL返回分页后的SQL
        /// </summary>
        /// <param name="sql">查询SQL语句</param>
        /// <param name="startRowNum">起始的行号</param>
        /// <param name="pageSize">每页条数</param>
        ///   <param name="OrderRowName">排序字段 后面可以加 DESC 或 ASC</param>
        /// <returns></returns>
        public static string GetPageTempTableSql(string sql, int currentPage, int pageSize, string OrderRowName, string EndSql)
        {
            int curr = currentPage < 1 ? 1 : currentPage;
            int startRowNum = (curr - 1) * pageSize + 1;
            int endRowNum = currentPage * pageSize;
            string mysql = "";
            mysql = @"SELECT *,(SELECT COUNT(*)  FROM( " + sql +
                           @"  )AS h  ) AS 'num' into #tb FROM (SELECT *,ROW_NUMBER() OVER 
                          (ORDER BY " + OrderRowName + @") AS 'RowNumber' FROM ( " + sql + ")AS c) a  WHERE a.RowNumber BETWEEN " + startRowNum + "  AND " + endRowNum;
            mysql += " " + EndSql;
            return mysql;
        }

   
        #region CSV执行导入
        /// <summary>
        /// 执行导入
        /// </summary>
        /// <param name="strFileName">对应文件路径</param>
        /// <param name="tableName">返回的Table名称</param>
        /// <param name="message">返回的错误</param>
        /// <returns>DataTable</returns>
        public static DataTable GetCSVToTable(string strFileName, string tableName, ref string message)
        {
            if (string.IsNullOrEmpty(strFileName)) return null;

            string line = string.Empty;
            string[] split = null;
            bool isReplace;
            int subBegion;
            int subEnd;
            string itemString = string.Empty;
            string oldItemString = string.Empty;
            DataTable table = new DataTable(tableName);
            DataRow row = null;
            StreamReader sr = new StreamReader(strFileName, System.Text.Encoding.Default);
            //创建与数据源对应的数据列 
            line = sr.ReadLine();
            split = line.Split(',');
            foreach (String colname in split)
            {
                table.Columns.Add(colname, System.Type.GetType("System.String"));
            }
            //将数据填入数据表 
            int j = 0;
            while ((line = sr.ReadLine()) != null)
            {
                subEnd = 0;
                subBegion = 0;

                if (line.IndexOf('\"') > 0)
                {
                    isReplace = true;
                }
                else
                {
                    isReplace = false;
                }
                itemString = string.Empty;
                while (isReplace)
                {

                    subBegion = line.IndexOf('\"');
                    if (line.Length - 1 > subBegion)
                    {
                        subEnd = line.IndexOf('\"', subBegion + 1);
                    }

                    if (subEnd - subBegion > 0)
                    {
                        itemString = line.Substring(subBegion, subEnd - subBegion + 1);
                        oldItemString = itemString;
                        itemString = itemString.Replace(',', '|').Replace("\"", string.Empty);
                        line = line.Replace(oldItemString, itemString);

                    }

                    if (line.IndexOf('\"') == -1)
                    {
                        isReplace = false;
                    }

                }


                j = 0;
                row = table.NewRow();
                split = line.Split(',');
                List<string> listT = new List<string>();
                foreach (String colname in split)
                {
                    listT.Add((colname.Replace('|', ',') + "").Trim());
                    row[j] = colname.Replace('|', ',');
                    j++;
                }
                if (listT.Where(P => P.Trim() == "").ToList().Count != split.Length)
                    table.Rows.Add(row);
            }
            sr.Close();
            //显示数据 

            return table;



        }
        #endregion


        /// <summary>
        ///  读取Csv文件返回DataSet
        /// </summary>
        /// <returns>Csv内容</returns>
        public static DataSet GetCSVToTable(string FileName)
        {
            OleDbConnection OleCon = new OleDbConnection();
            OleDbCommand OleCmd = new OleDbCommand();
            OleDbDataAdapter OleDa = new OleDbDataAdapter();

            DataSet CsvData = new DataSet();
            OleCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties='Text;FMT=Delimited;HDR=YES;'";
            OleCon.Open();
            OleCmd.Connection = OleCon;

            OleCmd.CommandText = "select * From " + OleCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"];
            OleDa.SelectCommand = OleCmd;
            try
            {
                OleDa.Fill(CsvData, "Csv");
                return CsvData;
            }
            catch
            {
                return CsvData;
            }
            finally
            {
                OleCon.Close();
                OleCmd.Dispose();
                OleDa.Dispose();
                OleCon.Dispose();
            }
        }


    }
}
