using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace DB
{
    /// <summary>
    /// 封装通用的数据库访问方法
    /// </summary>
    public abstract class SQLHelper
    {
        //数据库连接
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        // Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) using an existing SQL Transaction 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">an existing sql transaction</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// Execute a SqlCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>A SqlDataReader containing the results</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of SqlParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }







        #region 存储过程操作
        /// <summary>    
        /// 执行存储过程    
        /// </summary>    
        /// <param name="storedProcName">存储过程名</param>    
        /// <param name="parameters">存储过程参数</param>    
        /// <returns>SqlDataReader</returns>    
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataReader returnReader;
            connection.Open();
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader();
            return returnReader;
        }

        /// <summary>    
        /// 执行存储过程    
        /// </summary>    
        /// <param name="storedProcName">存储过程名</param>    
        /// <param name="parameters">存储过程参数</param>    
        /// <param name="tableName">DataSet结果中的表名</param>    
        /// <returns>DataSet</returns>    
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                //sqlDA.Fill(dataSet, tableName);
                sqlDA.Fill(dataSet);
                connection.Close();
                return dataSet;
            }
            //SqlConnection connection = new SqlConnection(ConnectionString);
            //SqlCommand cmd = new SqlCommand(storedProcName, connection);
            //cmd.CommandType = CommandType.StoredProcedure;
            //for (int i = 0; i < 11; i++)
            //{
            //    cmd.Parameters.Add(parameters[i]);
            //}
            //SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
            //DataSet dataSet = new DataSet();
            //sqlDA.Fill(dataSet);
            //return dataSet;
        }

        /// <summary>    
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)    
        /// </summary>    
        /// <param name="connection">数据库连接</param>    
        /// <param name="storedProcName">存储过程名</param>    
        /// <param name="parameters">存储过程参数</param>    
        /// <returns>SqlCommand</returns>    
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }



        /////// <summary>
        /////// 分页存储过程 090719 by ghg
        /////// </summary>
        /////// <param name="connectionString"></param>
        /////// <param name="cmdType"></param>
        /////// <param name="cmdText"></param>
        /////// <returns></returns>
        //public static Model.datapageEntity Executedateset1(string connectionString, CommandType cmdType, string[] dp_canshu)
        ////string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        //{

        //    //自己创建的根据传入的参数自动进行判断是使用升序还是降序,还是多条件排序
        //    //排序的依据
        //    //SortType sortType = SortType.DESC;
        //    //if (strOrder.Split(',').Length > 1)//多条件的
        //    //{
        //    //    sortType = SortType.Multinomial;
        //    //}
        //    //else //单个条件或者无条件的
        //    //{
        //    //    if (null == strOrder || "".Equals(strOrder))//无条件的
        //    //    {
        //    //        sortType = SortType.DESC;
        //    //    }
        //    //    else if (strOrder.ToLower().IndexOf("asc") >= 0)
        //    //    {
        //    //        string[] orderTemp = strOrder.ToLower().Split(' ');//使用空格分隔,确保asc不是某个字段里的字母
        //    //        if (2 == orderTemp.Length && orderTemp[1].Equals("asc"))
        //    //        {
        //    //            sortType = SortType.ASC;
        //    //        }
        //    //    }
        //    //}
        //    if (null == dp_canshu[1] || "".Equals(dp_canshu[1].Trim()))
        //    {
        //        dp_canshu[1] = " * ";
        //    }



        //    Model.datapageEntity dp = new Model.datapageEntity();
        //    //存储过程1
        //    SqlConnection connection = new SqlConnection(ConnectionString);

        //    SqlCommand cmd = new SqlCommand("SP_ViewPage", connection);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    SqlParameter[] parameters = {
        //            new SqlParameter("@TableName", SqlDbType.VarChar, 255), //--表名          
        //            new SqlParameter("@FieldList", SqlDbType.VarChar, 2000), //--显示列名，如果是全部字段则为*  --[至少要传个*进来]          
        //            new SqlParameter("@PrimaryKey", SqlDbType.VarChar, 255),//--单一主键或唯一值键 
        //            new SqlParameter("@Where", SqlDbType.VarChar,1000),     // --查询条件 不含'where'字符，如id>10 and len(userid)>9     
        //            new SqlParameter("@Order", SqlDbType.VarChar,255),      //--排序 不含'order by'字符，如id asc,userid desc，必须指定asc或desc 也可以不指定排序字段直接传null 或者 ''  进来
        //                                                                    //--注意当@SortType=3时生效，记住一定要在最后加上主键，否则会让你比较郁闷   
        //            new SqlParameter("@SortType", SqlDbType.Int),           //--排序规则 1:正序asc 2:倒序desc 3:多列排序方法[多列排序,必须给@Order 赋值,其他两种排序的倒无所谓]
        //            new SqlParameter("@RecorderCount", SqlDbType.Int),      // --记录总数 0:会返回总记录 
        //            new SqlParameter("@PageSize", SqlDbType.Int),           // --每页输出的记录数     
        //            new SqlParameter("@PageIndex", SqlDbType.Int),          // --当前页数   
        //            new SqlParameter("@TotalCount", SqlDbType.Int),         //--记返回总记录
        //            new SqlParameter("@TotalPageCount", SqlDbType.Int),     //--返回总页数
        //                                };
        //    parameters[0].Value = dp_canshu[0];
        //    parameters[1].Value = dp_canshu[1];
        //    parameters[2].Value = dp_canshu[2];
        //    parameters[3].Value = dp_canshu[3];
        //    parameters[4].Value = dp_canshu[4];
        //    parameters[5].Value = Convert.ToInt32(dp_canshu[5]);
        //    parameters[6].Value = 0;
        //    parameters[7].Value = Convert.ToInt32(dp_canshu[7]);
        //    parameters[8].Value = Convert.ToInt32(dp_canshu[8]);
        //    parameters[9].Direction = ParameterDirection.Output;
        //    parameters[10].Direction = ParameterDirection.Output;


        //    for (int i = 0; i < 11; i++)
        //    {
        //        cmd.Parameters.Add(parameters[i]);
        //    }

        //    SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();

        //    sqlDA.Fill(ds, dp_canshu[0]);

        //    dp.DS = ds;
        //    //总记录数
        //    dp.RECORDCOUNT = int.Parse(cmd.Parameters["Pcountnum"].Value.ToString());

        //    //总页数
        //    dp.PAGECOUNT = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cmd.Parameters["Pcount"].Value.ToString())));
        //    return dp;


        //}

        #endregion






        /// <summary>
        /// Execute a 根据定制语句返回 a dateset query that will return a result set edit 
        /// </summary>
        /// <param name="connString">Connection string</param>
        //// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or PL/SQL command</param>
        /// <param name="commandParameters">an array of OracleParamters used to execute the command</param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connectionString, CommandType cmdType, string cmdText)
        {

            //Create the command and connection

            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.SelectCommand.Connection = conn;
            DataSet ds = new DataSet();

            try
            {
                //Prepare the command to execute

                //Execute the query, stating that the connection should close when the resulting datareader has been read
                //OracleDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //cmd.Parameters.Clear();
                da.Fill(ds);
                return ds;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                conn.Close();
                throw;
            }
        }


        /// <summary>
        /// Execute a 根据定制语句返回 a DataTable query that will return a result set edit by lww 090624
        /// </summary>
        /// <param name="connString">Connection string</param>
        //// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or PL/SQL command</param>
        /// <param name="commandParameters">an array of OracleParamters used to execute the command</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string connectionString, CommandType cmdType, string cmdText)
        {

            //Create the command and connection
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.SelectCommand.Connection = conn;
            DataTable dt = new DataTable();

            try
            {
                //Prepare the command to execute

                //Execute the query, stating that the connection should close when the resulting datareader has been read
                //OracleDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //cmd.Parameters.Clear();
                da.Fill(dt);
                return dt;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                conn.Close();
                throw;
            }
        }
    }
}
