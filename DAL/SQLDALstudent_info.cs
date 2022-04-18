using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Model;
using DB;
using System.Data;

namespace DAL
{
    #region class SQLDALstudent_info
    /// <summary>
    /// it is suitable to the table with only one primary key,and can not deal with the aotu-increment key.
    /// Note:the first field in the table must be primary and autoincrement and int ,if exists 
    /// class:DAL student_info 
    /// Author:NetCenter
    /// DateTime:2019/1/8 8:12:46
    /// </summary>	
    public class DALstudent_info
    {
        #region SQL CONST
        private const string INSERT_SQL = "INSERT INTO [student_info] ([StudentId],[StudentPassword],[StudentName],[StudentPhoto],[StudentSex],[StudentNation],[StudentTelephone],[StudentQQ],[StudentClass],[StudentDormitory],[StudentAddress]) Values (@StudentId,@StudentPassword,@StudentName,@StudentPhoto,@StudentSex,@StudentNation,@StudentTelephone,@StudentQQ,@StudentClass,@StudentDormitory,@StudentAddress)";
        private const string UPDATE_SQL = "UPDATE [student_info] SET StudentId=@StudentId,StudentPassword=@StudentPassword,StudentName=@StudentName,StudentPhoto=@StudentPhoto,StudentSex=@StudentSex,StudentNation=@StudentNation,StudentTelephone=@StudentTelephone,StudentQQ=@StudentQQ,StudentClass=@StudentClass,StudentDormitory=@StudentDormitory,StudentAddress=@StudentAddress WHERE [Id]=@Id";
        private const string DEL_SQL = "DELETE FROM [student_info] WHERE [Id]=@Id";
        private const string SELECT_ALL_SQL = "SELECT [Id],[StudentId],[StudentPassword],[StudentName],[StudentPhoto],[StudentSex],[StudentNation],[StudentTelephone],[StudentQQ],[StudentClass],[StudentDormitory],[StudentAddress] FROM [student_info] order by id desc";
        private const string SELECT_ONE_SQL = "SELECT [Id],[StudentId],[StudentPassword],[StudentName],[StudentPhoto],[StudentSex],[StudentNation],[StudentTelephone],[StudentQQ],[StudentClass],[StudentDormitory],[StudentAddress] FROM [student_info] WHERE [Id]=@Id";
        private const string SELECT_WHERE_SQL = "SELECT [Id],[StudentId],[StudentPassword],[StudentName],[StudentPhoto],[StudentSex],[StudentNation],[StudentTelephone],[StudentQQ],[StudentClass],[StudentDormitory],[StudentAddress] FROM [student_info] {$where} order by  id desc";
        #endregion
        #region Paras const
        private const string PARA_Id = "@Id";
        private const string PARA_StudentId = "@StudentId";
        private const string PARA_StudentPassword = "@StudentPassword";
        private const string PARA_StudentName = "@StudentName";
        private const string PARA_StudentPhoto = "@StudentPhoto";
        private const string PARA_StudentSex = "@StudentSex";
        private const string PARA_StudentNation = "@StudentNation";
        private const string PARA_StudentTelephone = "@StudentTelephone";
        private const string PARA_StudentQQ = "@StudentQQ";
        private const string PARA_StudentClass = "@StudentClass";
        private const string PARA_StudentDormitory = "@StudentDormitory";
        private const string PARA_StudentAddress = "@StudentAddress";
        #endregion
        #region Add Method
        /// <summary>
        /// Insert an item
        /// </summary>
        /// <param name="student_info"></param>
        /// <returns>count of rows affected</returns>
        public int Addstudent_info(student_infoEntity student_info)
        {
            int backvalue = 0;
            //get paras
            SqlParameter[] student_infoParms = Getstudent_infoParametersInsert();
            //set values to paras
            student_infoParms[0].Value = student_info.StudentId;
            student_infoParms[1].Value = student_info.StudentPassword;
            student_infoParms[2].Value = student_info.StudentName;
            student_infoParms[3].Value = student_info.StudentPhoto;
            student_infoParms[4].Value = student_info.StudentSex;
            student_infoParms[5].Value = student_info.StudentNation;
            student_infoParms[6].Value = student_info.StudentTelephone;
            student_infoParms[7].Value = student_info.StudentQQ;
            student_infoParms[8].Value = student_info.StudentClass;
            student_infoParms[9].Value = student_info.StudentDormitory;
            student_infoParms[10].Value = student_info.StudentAddress;
            //insert			
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, INSERT_SQL, student_infoParms);
            }
            return backvalue;
        }
        #endregion
        #region Mod Method
        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="student_info"></param>
        /// <returns>count of rows affected</returns>
        public int Modstudent_info(student_infoEntity student_info)
        {
            int backvalue = 0;
            //get paras
            SqlParameter[] student_infoParms = Getstudent_infoParameters();
            //set values to paras
            student_infoParms[0].Value = student_info.Id;
            student_infoParms[1].Value = student_info.StudentId;
            student_infoParms[2].Value = student_info.StudentPassword;
            student_infoParms[3].Value = student_info.StudentName;
            student_infoParms[4].Value = student_info.StudentPhoto;
            student_infoParms[5].Value = student_info.StudentSex;
            student_infoParms[6].Value = student_info.StudentNation;
            student_infoParms[7].Value = student_info.StudentTelephone;
            student_infoParms[8].Value = student_info.StudentQQ;
            student_infoParms[9].Value = student_info.StudentClass;
            student_infoParms[10].Value = student_info.StudentDormitory;
            student_infoParms[11].Value = student_info.StudentAddress;
            //update			
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, UPDATE_SQL, student_infoParms);
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
        public int Delstudent_info(int id)
        {
            int backvalue = 0;
            //primarykeys
            //get paras
            SqlParameter[] student_infoParms = Getstudent_infoPrimaryKeyParameters();
            //set values to paras
            student_infoParms[0].Value = id;
            //delete
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, DEL_SQL, student_infoParms);
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
        public student_infoEntity Getstudent_info(int id)
        {
            student_infoEntity student_info = new student_infoEntity();
            //primarykeys
            //get paras
            SqlParameter[] student_infoParms = Getstudent_infoPrimaryKeyParameters();
            //set values to paras
            student_infoParms[0].Value = id;
            //select
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ONE_SQL, student_infoParms))
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0)) student_info.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) student_info.StudentId = reader.GetString(1);
                    if (!reader.IsDBNull(2)) student_info.StudentPassword = reader.GetString(2);
                    if (!reader.IsDBNull(3)) student_info.StudentName = reader.GetString(3);
                    if (!reader.IsDBNull(4)) student_info.StudentPhoto = reader.GetString(4);
                    if (!reader.IsDBNull(5)) student_info.StudentSex = reader.GetString(5);
                    if (!reader.IsDBNull(6)) student_info.StudentNation = reader.GetString(6);
                    if (!reader.IsDBNull(7)) student_info.StudentTelephone = reader.GetString(7);
                    if (!reader.IsDBNull(8)) student_info.StudentQQ = reader.GetString(8);
                    if (!reader.IsDBNull(9)) student_info.StudentClass = reader.GetString(9);
                    if (!reader.IsDBNull(10)) student_info.StudentDormitory = reader.GetString(10);
                    if (!reader.IsDBNull(11)) student_info.StudentAddress = reader.GetString(11);
                }
                else
                {
                    student_info = null;
                }
            }
            return student_info;

        }
        #endregion
        #region Select_All Method
        /// <summary>
        /// Select all items
        /// </summary>
        /// <returns>items</returns>
        public IList<student_infoEntity> Getstudent_infos()
        {
            IList<student_infoEntity> student_infos = new List<student_infoEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ALL_SQL, null))
            {
                while (reader.Read())
                {
                    student_infoEntity student_info = new student_infoEntity();
                    if (!reader.IsDBNull(0)) student_info.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) student_info.StudentId = reader.GetString(1);
                    if (!reader.IsDBNull(2)) student_info.StudentPassword = reader.GetString(2);
                    if (!reader.IsDBNull(3)) student_info.StudentName = reader.GetString(3);
                    if (!reader.IsDBNull(4)) student_info.StudentPhoto = reader.GetString(4);
                    if (!reader.IsDBNull(5)) student_info.StudentSex = reader.GetString(5);
                    if (!reader.IsDBNull(6)) student_info.StudentNation = reader.GetString(6);
                    if (!reader.IsDBNull(7)) student_info.StudentTelephone = reader.GetString(7);
                    if (!reader.IsDBNull(8)) student_info.StudentQQ = reader.GetString(8);
                    if (!reader.IsDBNull(9)) student_info.StudentClass = reader.GetString(9);
                    if (!reader.IsDBNull(10)) student_info.StudentDormitory = reader.GetString(10);
                    if (!reader.IsDBNull(11)) student_info.StudentAddress = reader.GetString(11);
                    student_infos.Add(student_info);
                }
            }
            return student_infos;
        }
        #endregion
        #region private common select by conditions
        /// <summary>
        /// private common select by conditions
        /// </summary>
        /// <returns>IList<student_infoEntity></returns>
        private IList<student_infoEntity> Getstudent_infosbyQueryString(string SQLstr)
        {
            IList<student_infoEntity> student_infos = new List<student_infoEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SQLstr))
            {
                while (reader.Read())
                {
                    student_infoEntity student_info = new student_infoEntity();
                    if (!reader.IsDBNull(0)) student_info.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) student_info.StudentId = reader.GetString(1);
                    if (!reader.IsDBNull(2)) student_info.StudentPassword = reader.GetString(2);
                    if (!reader.IsDBNull(3)) student_info.StudentName = reader.GetString(3);
                    if (!reader.IsDBNull(4)) student_info.StudentPhoto = reader.GetString(4);
                    if (!reader.IsDBNull(5)) student_info.StudentSex = reader.GetString(5);
                    if (!reader.IsDBNull(6)) student_info.StudentNation = reader.GetString(6);
                    if (!reader.IsDBNull(7)) student_info.StudentTelephone = reader.GetString(7);
                    if (!reader.IsDBNull(8)) student_info.StudentQQ = reader.GetString(8);
                    if (!reader.IsDBNull(9)) student_info.StudentClass = reader.GetString(9);
                    if (!reader.IsDBNull(10)) student_info.StudentDormitory = reader.GetString(10);
                    if (!reader.IsDBNull(11)) student_info.StudentAddress = reader.GetString(11);
                    student_infos.Add(student_info);
                }
            }
            return student_infos;
        }
        #endregion
        #region public common select by conditions ,we can use it by changing the Getstudent_infosbyCondition(datatype condition) and sql
        /// <summary>
        /// Select items by Columns
        /// </summary>
        /// <returns>IList<student_infoEntity></returns>
        public IList<student_infoEntity> Getstudent_infosbyCondition(string sql)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SELECT_WHERE_SQL);
            sb.Replace("{$where}", "where " + sql);
            return Getstudent_infosbyQueryString(sb.ToString());
        }
        #endregion
        #region Select Method Top n
        /// <summary>
        /// Select items by Columns
        /// </summary>
        /// <returns>IList<student_infoEntity></returns>
        public IList<student_infoEntity> Getstudent_infosTopN(int n)
        {
            IList<student_infoEntity> student_infos = new List<student_infoEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ALL_SQL, null))
            {
                int i = 0;
                while (reader.Read() && i < n)
                {
                    student_infoEntity student_info = new student_infoEntity();
                    if (!reader.IsDBNull(0)) student_info.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) student_info.StudentId = reader.GetString(1);
                    if (!reader.IsDBNull(2)) student_info.StudentPassword = reader.GetString(2);
                    if (!reader.IsDBNull(3)) student_info.StudentName = reader.GetString(3);
                    if (!reader.IsDBNull(4)) student_info.StudentPhoto = reader.GetString(4);
                    if (!reader.IsDBNull(5)) student_info.StudentSex = reader.GetString(5);
                    if (!reader.IsDBNull(6)) student_info.StudentNation = reader.GetString(6);
                    if (!reader.IsDBNull(7)) student_info.StudentTelephone = reader.GetString(7);
                    if (!reader.IsDBNull(8)) student_info.StudentQQ = reader.GetString(8);
                    if (!reader.IsDBNull(9)) student_info.StudentClass = reader.GetString(9);
                    if (!reader.IsDBNull(10)) student_info.StudentDormitory = reader.GetString(10);
                    if (!reader.IsDBNull(11)) student_info.StudentAddress = reader.GetString(11);
                    student_infos.Add(student_info);
                    i++;
                }
            }
            return student_infos;
        }
        #endregion
        #region paras configuration
        /// <summary>
        /// Internal function to get cached parameters:all paras --- suitable to insert ,especially autoincrement
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] Getstudent_infoParametersInsert()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_ALL_student_info_Insert");

            if (parms == null)
            {
                parms = new SqlParameter[] {
			new SqlParameter(PARA_StudentId,SqlDbType.VarChar) ,
			new SqlParameter(PARA_StudentPassword,SqlDbType.VarChar) ,
			new SqlParameter(PARA_StudentName,SqlDbType.VarChar) ,
			new SqlParameter(PARA_StudentPhoto,SqlDbType.VarChar) ,
			new SqlParameter(PARA_StudentSex,SqlDbType.VarChar) ,
			new SqlParameter(PARA_StudentNation,SqlDbType.VarChar) ,
			new SqlParameter(PARA_StudentTelephone,SqlDbType.VarChar) ,
			new SqlParameter(PARA_StudentQQ,SqlDbType.VarChar) ,
			new SqlParameter(PARA_StudentClass,SqlDbType.VarChar) ,
			new SqlParameter(PARA_StudentDormitory,SqlDbType.VarChar) ,
			new SqlParameter(PARA_StudentAddress,SqlDbType.VarChar)			};
                SQLHelper.CacheParameters("SQL_ALL_student_info_Insert", parms);
            }
            return parms;
        }
        /// <summary>
        /// Internal function to get cached parameters:all paras --- suitable to update
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] Getstudent_infoParameters()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_ALL_student_info_Update");

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARA_Id,SqlDbType.Int) ,
					new SqlParameter(PARA_StudentId,SqlDbType.VarChar) ,
					new SqlParameter(PARA_StudentPassword,SqlDbType.VarChar) ,
					new SqlParameter(PARA_StudentName,SqlDbType.VarChar) ,
					new SqlParameter(PARA_StudentPhoto,SqlDbType.VarChar) ,
					new SqlParameter(PARA_StudentSex,SqlDbType.VarChar) ,
					new SqlParameter(PARA_StudentNation,SqlDbType.VarChar) ,
					new SqlParameter(PARA_StudentTelephone,SqlDbType.VarChar) ,
					new SqlParameter(PARA_StudentQQ,SqlDbType.VarChar) ,
					new SqlParameter(PARA_StudentClass,SqlDbType.VarChar) ,
					new SqlParameter(PARA_StudentDormitory,SqlDbType.VarChar) ,
					new SqlParameter(PARA_StudentAddress,SqlDbType.VarChar)					};
                SQLHelper.CacheParameters("SQL_ALL_student_info_Update", parms);
            }
            return parms;
        }
        /// <summary>
        /// Internal function to get cached parameters:primary key paras
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] Getstudent_infoPrimaryKeyParameters()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_PrimaryKey_student_info");

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARA_Id,SqlDbType.Int) ,
					};
                SQLHelper.CacheParameters("SQL_PrimaryKey_student_info", parms);
            }
            return parms;
        }
        #endregion
    }
    #endregion
}
