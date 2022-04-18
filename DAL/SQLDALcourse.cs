using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Model;
using DB;

namespace DAL
{
    #region class SQLDALcourse
    /// <summary>
    /// it is suitable to the table with only one primary key,and can not deal with the aotu-increment key.
    /// Note:the first field in the table must be primary and autoincrement and int ,if exists 
    /// class:DAL course 
    /// Author:NetCenter
    /// DateTime:2019/1/9 9:24:42
    /// </summary>	
    public class DALcourse
    {
        #region SQL CONST
        private const string INSERT_SQL = "INSERT INTO [course] ([CourseId],[CourseName],[CourseTeacher],[CourseInfo],[CourseStudentNum]) Values (@CourseId,@CourseName,@CourseTeacher,@CourseInfo,@CourseStudentNum)";
        private const string UPDATE_SQL = "UPDATE [course] SET CourseId=@CourseId,CourseName=@CourseName,CourseTeacher=@CourseTeacher,CourseInfo=@CourseInfo,CourseStudentNum=@CourseStudentNum WHERE [Id]=@Id";
        private const string DEL_SQL = "DELETE FROM [course] WHERE [Id]=@Id";
        private const string SELECT_ALL_SQL = "SELECT [Id],[CourseId],[CourseName],[CourseTeacher],[CourseInfo],[CourseStudentNum] FROM [course] order by id desc";
        private const string SELECT_ONE_SQL = "SELECT [Id],[CourseId],[CourseName],[CourseTeacher],[CourseInfo],[CourseStudentNum] FROM [course] WHERE [Id]=@Id";
        private const string SELECT_WHERE_SQL = "SELECT [Id],[CourseId],[CourseName],[CourseTeacher],[CourseInfo],[CourseStudentNum] FROM [course] {$where} order by  id desc";
        #endregion
        #region Paras const
        private const string PARA_Id = "@Id";
        private const string PARA_CourseId = "@CourseId";
        private const string PARA_CourseName = "@CourseName";
        private const string PARA_CourseTeacher = "@CourseTeacher";
        private const string PARA_CourseInfo = "@CourseInfo";
        private const string PARA_CourseStudentNum = "@CourseStudentNum";
        #endregion
        #region Add Method
        /// <summary>
        /// Insert an item
        /// </summary>
        /// <param name="course"></param>
        /// <returns>count of rows affected</returns>
        public int Addcourse(courseEntity course)
        {
            int backvalue = 0;
            //get paras
            SqlParameter[] courseParms = GetcourseParametersInsert();
            //set values to paras
            courseParms[0].Value = course.CourseId;
            courseParms[1].Value = course.CourseName;
            courseParms[2].Value = course.CourseTeacher;
            courseParms[3].Value = course.CourseInfo;
            courseParms[4].Value = course.CourseStudentNum;
            //insert			
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, INSERT_SQL, courseParms);
            }
            return backvalue;
        }
        #endregion
        #region Mod Method
        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="course"></param>
        /// <returns>count of rows affected</returns>
        public int Modcourse(courseEntity course)
        {
            int backvalue = 0;
            //get paras
            SqlParameter[] courseParms = GetcourseParameters();
            //set values to paras
            courseParms[0].Value = course.Id;
            courseParms[1].Value = course.CourseId;
            courseParms[2].Value = course.CourseName;
            courseParms[3].Value = course.CourseTeacher;
            courseParms[4].Value = course.CourseInfo;
            courseParms[5].Value = course.CourseStudentNum;
            //update			
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, UPDATE_SQL, courseParms);
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
        public int Delcourse(int id)
        {
            int backvalue = 0;
            //primarykeys
            //get paras
            SqlParameter[] courseParms = GetcoursePrimaryKeyParameters();
            //set values to paras
            courseParms[0].Value = id;
            //delete
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, DEL_SQL, courseParms);
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
        public courseEntity Getcourse(int id)
        {
            courseEntity course = new courseEntity();
            //primarykeys
            //get paras
            SqlParameter[] courseParms = GetcoursePrimaryKeyParameters();
            //set values to paras
            courseParms[0].Value = id;
            //select
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ONE_SQL, courseParms))
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0)) course.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) course.CourseId = reader.GetString(1);
                    if (!reader.IsDBNull(2)) course.CourseName = reader.GetString(2);
                    if (!reader.IsDBNull(3)) course.CourseTeacher = reader.GetString(3);
                    if (!reader.IsDBNull(4)) course.CourseInfo = reader.GetString(4);
                    if (!reader.IsDBNull(5)) course.CourseStudentNum = reader.GetInt32(5);
                }
                else
                {
                    course = null;
                }
            }
            return course;

        }
        #endregion
        #region Select_All Method
        /// <summary>
        /// Select all items
        /// </summary>
        /// <returns>items</returns>
        public IList<courseEntity> Getcourses()
        {
            IList<courseEntity> courses = new List<courseEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ALL_SQL, null))
            {
                while (reader.Read())
                {
                    courseEntity course = new courseEntity();
                    if (!reader.IsDBNull(0)) course.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) course.CourseId = reader.GetString(1);
                    if (!reader.IsDBNull(2)) course.CourseName = reader.GetString(2);
                    if (!reader.IsDBNull(3)) course.CourseTeacher = reader.GetString(3);
                    if (!reader.IsDBNull(4)) course.CourseInfo = reader.GetString(4);
                    if (!reader.IsDBNull(5)) course.CourseStudentNum = reader.GetInt32(5);
                    courses.Add(course);
                }
            }
            return courses;
        }
        #endregion
        #region private common select by conditions
        /// <summary>
        /// private common select by conditions
        /// </summary>
        /// <returns>IList<courseEntity></returns>
        private IList<courseEntity> GetcoursesbyQueryString(string SQLstr)
        {
            IList<courseEntity> courses = new List<courseEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SQLstr))
            {
                while (reader.Read())
                {
                    courseEntity course = new courseEntity();
                    if (!reader.IsDBNull(0)) course.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) course.CourseId = reader.GetString(1);
                    if (!reader.IsDBNull(2)) course.CourseName = reader.GetString(2);
                    if (!reader.IsDBNull(3)) course.CourseTeacher = reader.GetString(3);
                    if (!reader.IsDBNull(4)) course.CourseInfo = reader.GetString(4);
                    if (!reader.IsDBNull(5)) course.CourseStudentNum = reader.GetInt32(5);
                    courses.Add(course);
                }
            }
            return courses;
        }
        #endregion
        #region public common select by conditions ,we can use it by changing the GetcoursesbyCondition(datatype condition) and sql
        /// <summary>
        /// Select items by Columns
        /// </summary>
        /// <returns>IList<courseEntity></returns>
        public IList<courseEntity> GetcoursesbyCondition(string sql)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SELECT_WHERE_SQL);
            sb.Replace("{$where}", "where " + sql);
            return GetcoursesbyQueryString(sb.ToString());
        }
        #endregion
        #region Select Method Top n
        /// <summary>
        /// Select items by Columns
        /// </summary>
        /// <returns>IList<courseEntity></returns>
        public IList<courseEntity> GetcoursesTopN(int n)
        {
            IList<courseEntity> courses = new List<courseEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ALL_SQL, null))
            {
                int i = 0;
                while (reader.Read() && i < n)
                {
                    courseEntity course = new courseEntity();
                    if (!reader.IsDBNull(0)) course.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) course.CourseId = reader.GetString(1);
                    if (!reader.IsDBNull(2)) course.CourseName = reader.GetString(2);
                    if (!reader.IsDBNull(3)) course.CourseTeacher = reader.GetString(3);
                    if (!reader.IsDBNull(4)) course.CourseInfo = reader.GetString(4);
                    if (!reader.IsDBNull(5)) course.CourseStudentNum = reader.GetInt32(5);
                    courses.Add(course);
                    i++;
                }
            }
            return courses;
        }
        #endregion
        #region paras configuration
        /// <summary>
        /// Internal function to get cached parameters:all paras --- suitable to insert ,especially autoincrement
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetcourseParametersInsert()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_ALL_course_Insert");

            if (parms == null)
            {
                parms = new SqlParameter[] {
			new SqlParameter(PARA_CourseId,SqlDbType.VarChar) ,
			new SqlParameter(PARA_CourseName,SqlDbType.VarChar) ,
			new SqlParameter(PARA_CourseTeacher,SqlDbType.VarChar) ,
			new SqlParameter(PARA_CourseInfo,SqlDbType.VarChar) ,
			new SqlParameter(PARA_CourseStudentNum,SqlDbType.Int)			};
                SQLHelper.CacheParameters("SQL_ALL_course_Insert", parms);
            }
            return parms;
        }
        /// <summary>
        /// Internal function to get cached parameters:all paras --- suitable to update
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetcourseParameters()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_ALL_course_Update");

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARA_Id,SqlDbType.Int) ,
					new SqlParameter(PARA_CourseId,SqlDbType.VarChar) ,
					new SqlParameter(PARA_CourseName,SqlDbType.VarChar) ,
					new SqlParameter(PARA_CourseTeacher,SqlDbType.VarChar) ,
					new SqlParameter(PARA_CourseInfo,SqlDbType.VarChar) ,
					new SqlParameter(PARA_CourseStudentNum,SqlDbType.Int)					};
                SQLHelper.CacheParameters("SQL_ALL_course_Update", parms);
            }
            return parms;
        }
        /// <summary>
        /// Internal function to get cached parameters:primary key paras
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetcoursePrimaryKeyParameters()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_PrimaryKey_course");

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARA_Id,SqlDbType.Int) ,
					};
                SQLHelper.CacheParameters("SQL_PrimaryKey_course", parms);
            }
            return parms;
        }
        #endregion
    }
    #endregion
}
