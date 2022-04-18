using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Model;
using DB;

namespace DAL
{
    #region class SQLDALnew
    /// <summary>
    /// it is suitable to the table with only one primary key,and can not deal with the aotu-increment key.
    /// Note:the first field in the table must be primary and autoincrement and int ,if exists 
    /// class:DAL news 
    /// Author:NetCenter
    /// DateTime:2019/1/9 9:27:58
    /// </summary>	
    public class DALnew
    {
        #region SQL CONST
        private const string INSERT_SQL = "INSERT INTO [news] ([Title],[Author],[ReleaseTime],[Content],[RelateFile]) Values (@Title,@Author,@ReleaseTime,@Content,@RelateFile)";
        private const string UPDATE_SQL = "UPDATE [news] SET Title=@Title,Author=@Author,ReleaseTime=@ReleaseTime,Content=@Content,RelateFile=@RelateFile WHERE [Id]=@Id";
        private const string DEL_SQL = "DELETE FROM [news] WHERE [Id]=@Id";
        private const string SELECT_ALL_SQL = "SELECT [Id],[Title],[Author],[ReleaseTime],[Content],[RelateFile] FROM [news] order by id desc";
        private const string SELECT_ONE_SQL = "SELECT [Id],[Title],[Author],[ReleaseTime],[Content],[RelateFile] FROM [news] WHERE [Id]=@Id";
        private const string SELECT_WHERE_SQL = "SELECT [Id],[Title],[Author],[ReleaseTime],[Content],[RelateFile] FROM [news] {$where} order by  id desc";
        #endregion
        #region Paras const
        private const string PARA_Id = "@Id";
        private const string PARA_Title = "@Title";
        private const string PARA_Author = "@Author";
        private const string PARA_ReleaseTime = "@ReleaseTime";
        private const string PARA_Content = "@Content";
        private const string PARA_RelateFile = "@RelateFile";
        #endregion
        #region Add Method
        /// <summary>
        /// Insert an item
        /// </summary>
        /// <param name="news"></param>
        /// <returns>count of rows affected</returns>
        public int Addnews(newEntity news)
        {
            int backvalue = 0;
            //get paras
            SqlParameter[] newsParms = GetnewsParametersInsert();
            //set values to paras
            newsParms[0].Value = news.Title;
            newsParms[1].Value = news.Author;
            newsParms[2].Value = news.ReleaseTime;
            newsParms[3].Value = news.Content;
            newsParms[4].Value = news.RelateFile;
            //insert			
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, INSERT_SQL, newsParms);
            }
            return backvalue;
        }
        #endregion
        #region Mod Method
        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="news"></param>
        /// <returns>count of rows affected</returns>
        public int Modnews(newEntity news)
        {
            int backvalue = 0;
            //get paras
            SqlParameter[] newsParms = GetnewsParameters();
            //set values to paras
            newsParms[0].Value = news.Id;
            newsParms[1].Value = news.Title;
            newsParms[2].Value = news.Author;
            newsParms[3].Value = news.ReleaseTime;
            newsParms[4].Value = news.Content;
            newsParms[5].Value = news.RelateFile;
            //update			
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, UPDATE_SQL, newsParms);
            }
            return backvalue;
        }
        #endregion
        #region Del Method
        /// <summary>
        /// Del an item by primary key
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>count of rows affected</returns>
        public int Delnews(int id)
        {
            int backvalue = 0;
            //primarykeys
            //get paras
            SqlParameter[] newsParms = GetnewsPrimaryKeyParameters();
            //set values to paras
            newsParms[0].Value = id;
            //delete
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, DEL_SQL, newsParms);
            }
            return backvalue;
        }
        #endregion
        #region Select Method
        /// <summary>
        /// Select an item by Primarykey
        /// </summary>
        /// <param name="id"></param>
        /// <returns>an item</returns>
        public newEntity Getnews(int id)
        {
            newEntity news = new newEntity();
            //primarykeys
            //get paras
            SqlParameter[] newsParms = GetnewsPrimaryKeyParameters();
            //set values to paras
            newsParms[0].Value = id;
            //select
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ONE_SQL, newsParms))
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0)) news.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) news.Title = reader.GetString(1);
                    if (!reader.IsDBNull(2)) news.Author = reader.GetString(2);
                    if (!reader.IsDBNull(3)) news.ReleaseTime = reader.GetDateTime(3);
                    if (!reader.IsDBNull(4)) news.Content = reader.GetString(4);
                    if (!reader.IsDBNull(5)) news.RelateFile = reader.GetString(5);
                }
                else
                {
                    news = null;
                }
            }
            return news;

        }
        #endregion
        #region Select_All Method
        /// <summary>
        /// Select all items
        /// </summary>
        /// <returns>items</returns>
        public IList<newEntity> Getnewss()
        {
            IList<newEntity> newss = new List<newEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ALL_SQL, null))
            {
                while (reader.Read())
                {
                    newEntity news = new newEntity();
                    if (!reader.IsDBNull(0)) news.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) news.Title = reader.GetString(1);
                    if (!reader.IsDBNull(2)) news.Author = reader.GetString(2);
                    if (!reader.IsDBNull(3)) news.ReleaseTime = reader.GetDateTime(3);
                    if (!reader.IsDBNull(4)) news.Content = reader.GetString(4);
                    if (!reader.IsDBNull(5)) news.RelateFile = reader.GetString(5);
                    newss.Add(news);
                }
            }
            return newss;
        }
        #endregion
        #region private common select by conditions
        /// <summary>
        /// private common select by conditions
        /// </summary>
        /// <returns>IList<newEntity></returns>
        private IList<newEntity> GetnewsbyQueryString(string SQLstr)
        {
            IList<newEntity> newss = new List<newEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SQLstr))
            {
                while (reader.Read())
                {
                    newEntity news = new newEntity();
                    if (!reader.IsDBNull(0)) news.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) news.Title = reader.GetString(1);
                    if (!reader.IsDBNull(2)) news.Author = reader.GetString(2);
                    if (!reader.IsDBNull(3)) news.ReleaseTime = reader.GetDateTime(3);
                    if (!reader.IsDBNull(4)) news.Content = reader.GetString(4);
                    if (!reader.IsDBNull(5)) news.RelateFile = reader.GetString(5);
                    newss.Add(news);
                }
            }
            return newss;
        }
        #endregion
        #region public common select by conditions ,we can use it by changing the GetnewsbyCondition(datatype condition) and sql
        /// <summary>
        /// Select items by Columns
        /// </summary>
        /// <returns>IList<newEntity></returns>
        public IList<newEntity> GetnewsbyCondition(string sql)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SELECT_WHERE_SQL);
            sb.Replace("{$where}", "where " + sql);
            return GetnewsbyQueryString(sb.ToString());
        }
        #endregion
        #region Select Method Top n
        /// <summary>
        /// Select items by Columns
        /// </summary>
        /// <returns>IList<newEntity></returns>
        public IList<newEntity> GetnewsTopN(int n)
        {
            IList<newEntity> newss = new List<newEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ALL_SQL, null))
            {
                int i = 0;
                while (reader.Read() && i < n)
                {
                    newEntity news = new newEntity();
                    if (!reader.IsDBNull(0)) news.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) news.Title = reader.GetString(1);
                    if (!reader.IsDBNull(2)) news.Author = reader.GetString(2);
                    if (!reader.IsDBNull(3)) news.ReleaseTime = reader.GetDateTime(3);
                    if (!reader.IsDBNull(4)) news.Content = reader.GetString(4);
                    if (!reader.IsDBNull(5)) news.RelateFile = reader.GetString(5);
                    newss.Add(news);
                    i++;
                }
            }
            return newss;
        }
        #endregion
        #region paras configuration
        /// <summary>
        /// Internal function to get cached parameters:all paras --- suitable to insert ,especially autoincrement
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetnewsParametersInsert()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_ALL_news_Insert");

            if (parms == null)
            {
                parms = new SqlParameter[] {
			new SqlParameter(PARA_Title,SqlDbType.VarChar) ,
			new SqlParameter(PARA_Author,SqlDbType.VarChar) ,
			new SqlParameter(PARA_ReleaseTime,SqlDbType.DateTime) ,
			new SqlParameter(PARA_Content,SqlDbType.VarChar) ,
			new SqlParameter(PARA_RelateFile,SqlDbType.VarChar)			};
                SQLHelper.CacheParameters("SQL_ALL_news_Insert", parms);
            }
            return parms;
        }
        /// <summary>
        /// Internal function to get cached parameters:all paras --- suitable to update
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetnewsParameters()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_ALL_news_Update");

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARA_Id,SqlDbType.Int) ,
					new SqlParameter(PARA_Title,SqlDbType.VarChar) ,
					new SqlParameter(PARA_Author,SqlDbType.VarChar) ,
					new SqlParameter(PARA_ReleaseTime,SqlDbType.DateTime) ,
					new SqlParameter(PARA_Content,SqlDbType.VarChar) ,
					new SqlParameter(PARA_RelateFile,SqlDbType.VarChar)					};
                SQLHelper.CacheParameters("SQL_ALL_news_Update", parms);
            }
            return parms;
        }
        /// <summary>
        /// Internal function to get cached parameters:primary key paras
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetnewsPrimaryKeyParameters()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_PrimaryKey_news");

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARA_Id,SqlDbType.Int) ,
					};
                SQLHelper.CacheParameters("SQL_PrimaryKey_news", parms);
            }
            return parms;
        }
        #endregion
    }
    #endregion
}
