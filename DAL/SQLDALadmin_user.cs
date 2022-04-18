using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Model;
using DB;

namespace DAL
{
    #region class SQLDALadmin_user
    /// <summary>
    /// it is suitable to the table with only one primary key,and can not deal with the aotu-increment key.
    /// Note:the first field in the table must be primary and autoincrement and int ,if exists 
    /// class:DAL admin_user 
    /// Author:NetCenter
    /// DateTime:2019/1/7 9:58:29
    /// </summary>	
    public class DALadmin_user
    {
        #region SQL CONST
        private const string INSERT_SQL = "INSERT INTO [admin_user] ([UserName],[UserType],[UserPassword],[LoginTimes],[TrueName],[LinkTelephone],[LoginTime]) Values (@UserName,@UserType,@UserPassword,@LoginTimes,@TrueName,@LinkTelephone,@LoginTime)";
        private const string UPDATE_SQL = "UPDATE [admin_user] SET UserName=@UserName,UserType=@UserType,UserPassword=@UserPassword,LoginTimes=@LoginTimes,TrueName=@TrueName,LinkTelephone=@LinkTelephone,LoginTime=@LoginTime WHERE [Id]=@Id";
        private const string DEL_SQL = "DELETE FROM [admin_user] WHERE [Id]=@Id";
        private const string SELECT_ALL_SQL = "SELECT [Id],[UserName],[UserType],[UserPassword],[LoginTimes],[TrueName],[LinkTelephone],[LoginTime] FROM [admin_user] order by id desc";
        private const string SELECT_ONE_SQL = "SELECT [Id],[UserName],[UserType],[UserPassword],[LoginTimes],[TrueName],[LinkTelephone],[LoginTime] FROM [admin_user] WHERE [Id]=@Id";
        private const string SELECT_WHERE_SQL = "SELECT [Id],[UserName],[UserType],[UserPassword],[LoginTimes],[TrueName],[LinkTelephone],[LoginTime] FROM [admin_user] {$where} order by  id desc";
        #endregion
        #region Paras const
        private const string PARA_Id = "@Id";
        private const string PARA_UserName = "@UserName";
        private const string PARA_UserType = "@UserType";
        private const string PARA_UserPassword = "@UserPassword";
        private const string PARA_LoginTimes = "@LoginTimes";
        private const string PARA_TrueName = "@TrueName";
        private const string PARA_LinkTelephone = "@LinkTelephone";
        private const string PARA_LoginTime = "@LoginTime";
        #endregion
        #region Add Method
        /// <summary>
        /// Insert an item
        /// </summary>
        /// <param name="admin_user"></param>
        /// <returns>count of rows affected</returns>
        public int Addadmin_user(admin_userEntity admin_user)
        {
            int backvalue = 0;
            //get paras
            SqlParameter[] admin_userParms = Getadmin_userParametersInsert();
            //set values to paras
            admin_userParms[0].Value = admin_user.UserName;
            admin_userParms[1].Value = admin_user.UserType;
            admin_userParms[2].Value = admin_user.UserPassword;
            admin_userParms[3].Value = admin_user.LoginTimes;
            admin_userParms[4].Value = admin_user.TrueName;
            admin_userParms[5].Value = admin_user.LinkTelephone;
            admin_userParms[6].Value = admin_user.LoginTime;
            //insert			
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, INSERT_SQL, admin_userParms);
            }
            return backvalue;
        }
        #endregion
        #region Mod Method
        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="admin_user"></param>
        /// <returns>count of rows affected</returns>
        public int Modadmin_user(admin_userEntity admin_user)
        {
            int backvalue = 0;
            //get paras
            SqlParameter[] admin_userParms = Getadmin_userParameters();
            //set values to paras
            admin_userParms[0].Value = admin_user.Id;
            admin_userParms[1].Value = admin_user.UserName;
            admin_userParms[2].Value = admin_user.UserType;
            admin_userParms[3].Value = admin_user.UserPassword;
            admin_userParms[4].Value = admin_user.LoginTimes;
            admin_userParms[5].Value = admin_user.TrueName;
            admin_userParms[6].Value = admin_user.LinkTelephone;
            admin_userParms[7].Value = admin_user.LoginTime;
            //update			
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, UPDATE_SQL, admin_userParms);
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
        public int Deladmin_user(int id)
        {
            int backvalue = 0;
            //primarykeys
            //get paras
            SqlParameter[] admin_userParms = Getadmin_userPrimaryKeyParameters();
            //set values to paras
            admin_userParms[0].Value = id;
            //delete
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, DEL_SQL, admin_userParms);
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
        public admin_userEntity Getadmin_user(int id)
        {
            admin_userEntity admin_user = new admin_userEntity();
            //primarykeys
            //get paras
            SqlParameter[] admin_userParms = Getadmin_userPrimaryKeyParameters();
            //set values to paras
            admin_userParms[0].Value = id;
            //select
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ONE_SQL, admin_userParms))
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0)) admin_user.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) admin_user.UserName = reader.GetString(1);
                    if (!reader.IsDBNull(2)) admin_user.UserType = reader.GetString(2);
                    if (!reader.IsDBNull(3)) admin_user.UserPassword = reader.GetString(3);
                    if (!reader.IsDBNull(4)) admin_user.LoginTimes = reader.GetInt32(4);
                    if (!reader.IsDBNull(5)) admin_user.TrueName = reader.GetString(5);
                    if (!reader.IsDBNull(6)) admin_user.LinkTelephone = reader.GetString(6);
                    if (!reader.IsDBNull(7)) admin_user.LoginTime = reader.GetDateTime(7);
                }
                else
                {
                    admin_user = null;
                }
            }
            return admin_user;

        }
        #endregion
        #region Select_All Method
        /// <summary>
        /// Select all items
        /// </summary>
        /// <returns>items</returns>
        public IList<admin_userEntity> Getadmin_users()
        {
            IList<admin_userEntity> admin_users = new List<admin_userEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ALL_SQL, null))
            {
                while (reader.Read())
                {
                    admin_userEntity admin_user = new admin_userEntity();
                    if (!reader.IsDBNull(0)) admin_user.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) admin_user.UserName = reader.GetString(1);
                    if (!reader.IsDBNull(2)) admin_user.UserType = reader.GetString(2);
                    if (!reader.IsDBNull(3)) admin_user.UserPassword = reader.GetString(3);
                    if (!reader.IsDBNull(4)) admin_user.LoginTimes = reader.GetInt32(4);
                    if (!reader.IsDBNull(5)) admin_user.TrueName = reader.GetString(5);
                    if (!reader.IsDBNull(6)) admin_user.LinkTelephone = reader.GetString(6);
                    if (!reader.IsDBNull(7)) admin_user.LoginTime = reader.GetDateTime(7);
                    admin_users.Add(admin_user);
                }
            }
            return admin_users;
        }
        #endregion
        #region private common select by conditions
        /// <summary>
        /// private common select by conditions
        /// </summary>
        /// <returns>IList<admin_userEntity></returns>
        private IList<admin_userEntity> Getadmin_usersbyQueryString(string SQLstr)
        {
            IList<admin_userEntity> admin_users = new List<admin_userEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SQLstr))
            {
                while (reader.Read())
                {
                    admin_userEntity admin_user = new admin_userEntity();
                    if (!reader.IsDBNull(0)) admin_user.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) admin_user.UserName = reader.GetString(1);
                    if (!reader.IsDBNull(2)) admin_user.UserType = reader.GetString(2);
                    if (!reader.IsDBNull(3)) admin_user.UserPassword = reader.GetString(3);
                    if (!reader.IsDBNull(4)) admin_user.LoginTimes = reader.GetInt32(4);
                    if (!reader.IsDBNull(5)) admin_user.TrueName = reader.GetString(5);
                    if (!reader.IsDBNull(6)) admin_user.LinkTelephone = reader.GetString(6);
                    if (!reader.IsDBNull(7)) admin_user.LoginTime = reader.GetDateTime(7);
                    admin_users.Add(admin_user);
                }
            }
            return admin_users;
        }
        #endregion
        #region public common select by conditions ,we can use it by changing the Getadmin_usersbyCondition(datatype condition) and sql
        /// <summary>
        /// Select items by Columns
        /// </summary>
        /// <returns>IList<admin_userEntity></returns>
        public IList<admin_userEntity> Getadmin_usersbyCondition(string sql)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SELECT_WHERE_SQL);
            sb.Replace("{$where}", "where " + sql);
            return Getadmin_usersbyQueryString(sb.ToString());
        }
        #endregion
        #region Select Method Top n
        /// <summary>
        /// Select items by Columns
        /// </summary>
        /// <returns>IList<admin_userEntity></returns>
        public IList<admin_userEntity> Getadmin_usersTopN(int n)
        {
            IList<admin_userEntity> admin_users = new List<admin_userEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ALL_SQL, null))
            {
                int i = 0;
                while (reader.Read() && i < n)
                {
                    admin_userEntity admin_user = new admin_userEntity();
                    if (!reader.IsDBNull(0)) admin_user.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) admin_user.UserName = reader.GetString(1);
                    if (!reader.IsDBNull(2)) admin_user.UserType = reader.GetString(2);
                    if (!reader.IsDBNull(3)) admin_user.UserPassword = reader.GetString(3);
                    if (!reader.IsDBNull(4)) admin_user.LoginTimes = reader.GetInt32(4);
                    if (!reader.IsDBNull(5)) admin_user.TrueName = reader.GetString(5);
                    if (!reader.IsDBNull(6)) admin_user.LinkTelephone = reader.GetString(6);
                    if (!reader.IsDBNull(7)) admin_user.LoginTime = reader.GetDateTime(7);
                    admin_users.Add(admin_user);
                    i++;
                }
            }
            return admin_users;
        }
        #endregion
        #region paras configuration
        /// <summary>
        /// Internal function to get cached parameters:all paras --- suitable to insert ,especially autoincrement
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] Getadmin_userParametersInsert()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_ALL_admin_user_Insert");

            if (parms == null)
            {
                parms = new SqlParameter[] {
			new SqlParameter(PARA_UserName,SqlDbType.VarChar) ,
			new SqlParameter(PARA_UserType,SqlDbType.VarChar) ,
			new SqlParameter(PARA_UserPassword,SqlDbType.VarChar) ,
			new SqlParameter(PARA_LoginTimes,SqlDbType.Int) ,
			new SqlParameter(PARA_TrueName,SqlDbType.VarChar) ,
			new SqlParameter(PARA_LinkTelephone,SqlDbType.VarChar) ,
			new SqlParameter(PARA_LoginTime,SqlDbType.DateTime)			};
                SQLHelper.CacheParameters("SQL_ALL_admin_user_Insert", parms);
            }
            return parms;
        }
        /// <summary>
        /// Internal function to get cached parameters:all paras --- suitable to update
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] Getadmin_userParameters()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_ALL_admin_user_Update");

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARA_Id,SqlDbType.Int) ,
					new SqlParameter(PARA_UserName,SqlDbType.VarChar) ,
					new SqlParameter(PARA_UserType,SqlDbType.VarChar) ,
					new SqlParameter(PARA_UserPassword,SqlDbType.VarChar) ,
					new SqlParameter(PARA_LoginTimes,SqlDbType.Int) ,
					new SqlParameter(PARA_TrueName,SqlDbType.VarChar) ,
					new SqlParameter(PARA_LinkTelephone,SqlDbType.VarChar) ,
					new SqlParameter(PARA_LoginTime,SqlDbType.DateTime)					};
                SQLHelper.CacheParameters("SQL_ALL_admin_user_Update", parms);
            }
            return parms;
        }
        /// <summary>
        /// Internal function to get cached parameters:primary key paras
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] Getadmin_userPrimaryKeyParameters()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_PrimaryKey_admin_user");

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARA_Id,SqlDbType.Int) ,
					};
                SQLHelper.CacheParameters("SQL_PrimaryKey_admin_user", parms);
            }
            return parms;
        }
        #endregion
    }
    #endregion
}
