using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using IBatisNet.Common;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.DataMapper.Configuration.Statements;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;
/**
 * 创建：px
 * 日期：2010-12-03
 * 功能：Ibatis底层操作类
 */
namespace MyAspx.EasyFramework.DAL
{
    /// <summary>
    /// Ibatis底层操作类
    /// </summary>
    public class GetSqlMapper
    {
        #region 属性

        private log4net.ILog m_objLog = log4net.LogManager.GetLogger("GetSqlMapper");  //日志输出对象
        private static ISqlMapper m_objMapper = null; //ISqlMapper对象

        #endregion

        #region public 方法
        /// <summary>
        /// 返回一个SqlMapper,一个SqlMapper对应一个SqlMap.config配置文件
        /// </summary>
        /// <returns>一个SqlMapper</returns>
        public ISqlMapper GetMapper()
        {
            m_objLog.Info("GetMapper Start");
            DomSqlMapBuilder _objDomBuilder = null;
            if (m_objMapper == null)
            {
                _objDomBuilder = new DomSqlMapBuilder();//初始化一个DomSqlMapBuilder

                m_objMapper = _objDomBuilder.Configure("Config/SqlMap.config");//调用Configure方法并指定配置文件的名称,返回一个SqlMapper
            }
            m_objLog.Info("GetMapper End");
            return m_objMapper;
        }

        /// <summary>
        /// 返回一个SqlMapper,一个SqlMapper对应一个SqlMap.config配置文件
        /// </summary>
        /// <returns>一个SqlMapper</returns>
        public ISqlMapper GetMapperRainWater()
        {
            m_objLog.Info("GetMapper Start");
            DomSqlMapBuilder _objDomBuilder = null;
            if (m_objMapper == null)
            {
                _objDomBuilder = new DomSqlMapBuilder();//初始化一个DomSqlMapBuilder

                m_objMapper = _objDomBuilder.Configure("Config/IBatis/RainWater.config");//调用Configure方法并指定配置文件的名称,返回一个SqlMapper
            }
            m_objLog.Info("GetMapper End");
            return m_objMapper;
        }

        /// <summary>
        /// 根据路径返回一个SqlMapper,一个SqlMapper对应一个SqlMap.config配置文件
        /// </summary>
        /// <param name="_strResource">路径</param>
        /// <returns>一个SqlMapper</returns>
        public ISqlMapper GetMapper(String _strResource)
        {

            m_objLog.Info("GetMapper Start");
            DomSqlMapBuilder _objDomBuilder = null;
            ISqlMapper _objMapper = null;
            _objDomBuilder = new DomSqlMapBuilder();//初始化一个DomSqlMapBuilder
            _objMapper = _objDomBuilder.Configure(_strResource);//调用Configure方法并指定配置文件的名称,返回一个SqlMapper
            m_objLog.Info("GetMapper End");
            return _objMapper;
        }

        /**/
        /// <summary>
        /// 得到参数化后的SQL
        /// </summary>
        /// <param name="_strTag">语句ID</param>
        /// <param name="_objParam">参数</param>
        /// <param name="_objSqlMap">ISqlMapper类对象</param>
        /// <returns>返回SQL</returns>
        protected string GetSql(string _strTag, object _objParam, ISqlMapper _objSqlMap)
        {
            m_objLog.Info("GetSql Start");
            IStatement _objStatement = null;
            IMappedStatement _objMapStatement = null;
            IDalSession _objSession = null;
            RequestScope _objRequest = null;
            if (_objSqlMap == null) _objSqlMap = GetMapper();//zca20110212修改，参数可以传null过来默认使用本类配置的map

            _objStatement = _objSqlMap.GetMappedStatement(_strTag).Statement;

            _objMapStatement = _objSqlMap.GetMappedStatement(_strTag);

            _objSession = new SqlMapSession(_objSqlMap);

            _objRequest = _objStatement.Sql.GetRequestScope(_objMapStatement, _objParam, (ISqlMapSession)_objSession);
            m_objLog.Info("GetSql End");
            return _objRequest.PreparedStatement.PreparedSql;

        }

        /// <summary>
        /// 得到参数化后的SQL
        /// </summary>
        /// <param name="_strTag">语句ID</param>
        /// <param name="_objParam">参数</param>
        /// <param name="_objSqlMap">ISqlMapper类对象</param>
        /// <returns>返回SQL</returns>
        public IDbCommand GetDbCommand(string _strTag, object _objParam, ISqlMapper _objSqlMap)
        {
            m_objLog.Info("GetDbCommand Start");
            IStatement _objStatement = null;
            IMappedStatement _objMapStatement = null;
            IDalSession _objSession = null;
            RequestScope _objRequest = null;
            if (_objSqlMap == null) _objSqlMap = GetMapper();//zca20110212修改，参数可以传null过来默认使用本类配置的map
            _objStatement = _objSqlMap.GetMappedStatement(_strTag).Statement;

            _objMapStatement = _objSqlMap.GetMappedStatement(_strTag);

            _objSession = new SqlMapSession(_objSqlMap);

            _objRequest = _objStatement.Sql.GetRequestScope(_objMapStatement, _objParam, (ISqlMapSession)_objSession);

            _objMapStatement.PreparedCommand.Create(_objRequest, (ISqlMapSession)_objSession, _objStatement, _objParam);
            m_objLog.Info("GetDbCommand End");
            return _objRequest.IDbCommand;

        }

        /**/
        /// <summary>
        /// 通用的以DataTable的方式得到Select的结果(xml文件中参数要使用$标记的占位参数)
        /// </summary>
        /// <param name="tag">语句ID</param>
        /// <param name="paramObject">语句所需要的参数</param>
        /// <returns>得到的DataTable</returns>
        public DataTable GetDataTable(string _strTag, object _objParam)
        {

            m_objLog.Info("GetDataTable Start");
            ISqlMapper _objSqlMap = null;
            bool _bIsSessionLocal = false;
            IDalSession _objSession = null;
            System.Data.DataSet _dstData = new System.Data.DataSet();
            _objSqlMap = GetMapper();

            _objSession = _objSqlMap.LocalSession;
            if (_objSession == null)
            {
                _objSession = new SqlMapSession(_objSqlMap);
                //_objSession.Connection.ConnectionString
                _objSession.OpenConnection();
                _bIsSessionLocal = true;
            }
            IDbCommand _objCommand = _objSession.CreateCommand(CommandType.Text);
            _objCommand.CommandText = GetDbCommand(_strTag, _objParam, _objSqlMap).CommandText;
            IDbDataAdapter adapter = _objSession.CreateDataAdapter(_objCommand);

            adapter.Fill(_dstData);
            if (_bIsSessionLocal)
            {
                _objSession.CloseConnection();
            }
            m_objLog.Info("GetDataTable End");
            return _dstData.Tables[0];

        }

        /// <summary>
        /// 调用存储过程返回DataTable
        /// </summary>
        /// <param name="_strProcedureName">存储过程名字</param>
        /// <param name="_alArg">参数</param>
        /// <returns>返回数据集</returns>
        public DataTable SelectWithStoredProcedure(string _strProcedureName, ArrayList _alArg)
        {
            m_objLog.Info("SelectWithStoredProcedure Start");


            System.Data.DataSet _dstData = new System.Data.DataSet();
            bool _bIsSessionLocal = false;

            ISqlMapper _objSqlMap = GetMapper();

            IDalSession _objSession = _objSqlMap.LocalSession;

            if (_objSession == null)
            {
                _objSession = new SqlMapSession(_objSqlMap);
                _objSession.OpenConnection();
                _bIsSessionLocal = true;
            }
            IDbCommand _objCommand = _objSession.CreateCommand(CommandType.StoredProcedure);
            _objCommand.CommandText = _strProcedureName;
            Object[] _objsArray = new Object[3];
            for (int i = 0; i < _alArg.Count; i++)
            {
                SqlParameter _objSqlParm = new SqlParameter();
                _objsArray = (Object[])_alArg[i];
                _objSqlParm.DbType = (DbType)_objsArray[1];
                _objSqlParm.ParameterName = System.Convert.ToString(_objsArray[0]);
                _objSqlParm.Value = System.Convert.ToString(_objsArray[2]);
                _objCommand.Parameters.Add(_objSqlParm);
            }
            IDbDataAdapter adapter = _objSession.CreateDataAdapter(_objCommand);
            adapter.Fill(_dstData);
            if (_bIsSessionLocal)
            {
                _objSession.CloseConnection();
            }
            m_objLog.Info("SelectWithStoredProcedure End");
            return _dstData.Tables[0];
        }
        /// <summary>
        /// 调用存储过程返回DataSet
        /// </summary>
        /// <param name="_strProcedureName">存储过程名字</param>
        /// <param name="_alArg">参数</param>
        /// <returns>返回数据集</returns>
        public DataSet SelectWithStoredProcedureDataSet(string _strProcedureName, ArrayList _alArg)
        {
            m_objLog.Info("SelectWithStoredProcedureDataSet Start");


            System.Data.DataSet _dstData = new System.Data.DataSet();
            bool _bIsSessionLocal = false;

            ISqlMapper _objSqlMap = GetMapper();

            IDalSession _objSession = _objSqlMap.LocalSession;

            if (_objSession == null)
            {
                _objSession = new SqlMapSession(_objSqlMap);
                _objSession.OpenConnection();
                _bIsSessionLocal = true;
            }
            IDbCommand _objCommand = _objSession.CreateCommand(CommandType.StoredProcedure);
            _objCommand.CommandText = _strProcedureName;
            Object[] _objsArray = new Object[3];
            for (int i = 0; i < _alArg.Count; i++)
            {
                SqlParameter _objSqlParm = new SqlParameter();
                _objsArray = (Object[])_alArg[i];
                _objSqlParm.DbType = (DbType)_objsArray[1];
                _objSqlParm.ParameterName = System.Convert.ToString(_objsArray[0]);
                _objSqlParm.Value = System.Convert.ToString(_objsArray[2]);
                _objCommand.Parameters.Add(_objSqlParm);
            }
            IDbDataAdapter adapter = _objSession.CreateDataAdapter(_objCommand);
            adapter.Fill(_dstData);
            if (_bIsSessionLocal)
            {
                _objSession.CloseConnection();
            }
            m_objLog.Info("SelectWithStoredProcedureDataSet End");
            return _dstData;
        }

        #endregion

    }
}