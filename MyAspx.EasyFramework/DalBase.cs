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
}
