/*----------------------------------------------------------------
// Copyright (C) 2011 福建兴宇信息科技有限公司
//
// 文件名：DalBase.cs
// 文件功能描述：数据操作基础类
// 
// 创建标识：code.黄晗(2011-12-9 10:27:47)
// 
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.Common;

namespace MyAspx.EasyFramework.DAL
{
    public class DalBase
    {
        public static GetSqlMapper objMapper = new GetSqlMapper();

        /// 服务器当前时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerTime()
        {
            return objMapper.GetMapper().QueryForObject<DateTime>("BaseXml.GetServerTime", "");
        }
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return objMapper.GetMapper().DataSource.ConnectionString;
        }
    }
    public class DBAccess
    {

        private SqlConnection con;
        private string DBName = "commyaspxdb";

        //创建连接对象并打开
        public void Open()
        {
            if (con == null)
                con = new SqlConnection("server=.;uid=sa;pwd=1;database=" + DBName);
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        //创建一个命令对象并返回该对象
        public SqlCommand CreateCommand(string sqlStr)
        {
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;
            cmd.Connection = con;
            return cmd;
        }
        //生成一个对象并返回该结果集第一行第一列
        public object GetScalar(string sqlStr)
        {
            SqlCommand cmd = CreateCommand(sqlStr);
            object obj = cmd.ExecuteScalar();
            //CommadnBehavior.CloseConnection是将于DataReader的数据库链接关联起来 
            //当关闭DataReader对象时候也自动关闭链接
            return obj;
        }
        //执行数据库查询并返回一个数据集 [当前页码,每页记录条数]
        public DataSet GetCurrentPage(int pageIndex, int pageSize,string tablename,string ordercol)
        {
            //设置导入的起始地址
            int firstPage = pageIndex * pageSize;
            //SELECT a.*,b.tagname as tagname FROM [my_fileinfo] as a left join [my_tag] as b on a.fileid=b.fileinfoid ORDER BY [addtime] DESC
            string sqlStr = "SELECT a.*,b.tagname as tagname FROM  " + tablename + " as a left join [my_tag] as b on a.fileid=b.fileinfoid  order by " + ordercol + " desc";
            SqlCommand cmd = CreateCommand(sqlStr);
            DataSet dataset = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataset, firstPage, pageSize, "tablename");
            cmd.Dispose();
            Close();
            dataAdapter.Dispose();
            return dataset;
        }
        //获得查询数据的总条数
        public object GetAllCount(string tablename)
        {
            string sqlStr = "select count(*) from "+tablename;
            object obj = GetScalar(sqlStr);
            return obj;
        }

        //关闭数据库
        public void Close()
        {
            if (con != null)
            {
                con.Close();
            }
        }
        //释放资源
        public void Dispose()
        {
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }
    }

}
