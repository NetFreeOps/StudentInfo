using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Model;
using DB;

namespace DAL
{
    #region class SQLDALstudent_course
    /// <summary>
    /// it is suitable to the table with only one primary key,and can not deal with the aotu-increment key.
    /// Note:the first field in the table must be primary and autoincrement and int ,if exists 
    /// class:DAL student_course 
    /// Author:NetCenter
    /// DateTime:2019/1/9 10:15:15
    /// </summary>	
    public class DALstudent_course
    {
        #region SQL CONST
        private const string INSERT_SQL = "INSERT INTO [student_course] ([StudentId],[StudetnName],[CourseId],[CourseName],[CourseScore]) Values (@StudentId,@StudetnName,@CourseId,@CourseName,@CourseScore)";
        private const string UPDATE_SQL = "UPDATE [student_course] SET StudentId=@StudentId,StudetnName=@StudetnName,CourseId=@CourseId,CourseName=@CourseName,CourseScore=@CourseScore WHERE [Id]=@Id";
        private const string DEL_SQL = "DELETE FROM [student_course] WHERE [Id]=@Id";
        private const string SELECT_ALL_SQL = "SELECT [Id],[StudentId],[StudetnName],[CourseId],[CourseName],[CourseScore] FROM [student_course] order by id desc";
        private const string SELECT_ONE_SQL = "SELECT [Id],[StudentId],[StudetnName],[CourseId],[CourseName],[CourseScore] FROM [student_course] WHERE [Id]=@Id";
        private const string SELECT_WHERE_SQL = "SELECT [Id],[StudentId],[StudetnName],[CourseId],[CourseName],[CourseScore] FROM [student_course] {$where} order by  id desc";
        #endregion
        #region Paras const
        private const string PARA_Id = "@Id";
        private const string PARA_StudentId = "@StudentId";
        private const string PARA_StudetnName = "@StudetnName";
        private const string PARA_CourseId = "@CourseId";
        private const string PARA_CourseName = "@CourseName";
        private const string PARA_CourseScore = "@CourseScore";
        #endregion
        #region Add Method
        /// <summary>
        /// Insert an item
        /// </summary>
        /// <param name="student_course"></param>
        /// <returns>count of rows affected</returns>
        public int Addstudent_course(student_courseEntity student_course)
        {
            int backvalue = 0;
            //get paras
            SqlParameter[] student_courseParms = Getstudent_courseParametersInsert();
            //set values to paras
            student_courseParms[0].Value = student_course.StudentId;
            student_courseParms[1].Value = student_course.StudetnName;
            student_courseParms[2].Value = student_course.CourseId;
            student_courseParms[3].Value = student_course.CourseName;
            student_courseParms[4].Value = student_course.CourseScore;
            //insert			
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, INSERT_SQL, student_courseParms);
            }
            return backvalue;
        }
        #endregion
        #region Mod Method
        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="student_course"></param>
        /// <returns>count of rows affected</returns>
        public int Modstudent_course(student_courseEntity student_course)
        {
            int backvalue = 0;
            //get paras
            SqlParameter[] student_courseParms = Getstudent_courseParameters();
            //set values to paras
            student_courseParms[0].Value = student_course.Id;
            student_courseParms[1].Value = student_course.StudentId;
            student_courseParms[2].Value = student_course.StudetnName;
            student_courseParms[3].Value = student_course.CourseId;
            student_courseParms[4].Value = student_course.CourseName;
            student_courseParms[5].Value = student_course.CourseScore;
            //update			
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, UPDATE_SQL, student_courseParms);
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
        public int Delstudent_course(int id)
        {
            int backvalue = 0;
            //primarykeys
            //get paras
            SqlParameter[] student_courseParms = Getstudent_coursePrimaryKeyParameters();
            //set values to paras
            student_courseParms[0].Value = id;
            //delete
            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            {
                backvalue = SQLHelper.ExecuteNonQuery(SQLHelper.ConnectionString, CommandType.Text, DEL_SQL, student_courseParms);
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
        public student_courseEntity Getstudent_course(int id)
        {
            student_courseEntity student_course = new student_courseEntity();
            //primarykeys
            //get paras
            SqlParameter[] student_courseParms = Getstudent_coursePrimaryKeyParameters();
            //set values to paras
            student_courseParms[0].Value = id;
            //select
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ONE_SQL, student_courseParms))
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0)) student_course.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) student_course.StudentId = reader.GetString(1);
                    if (!reader.IsDBNull(2)) student_course.StudetnName = reader.GetString(2);
                    if (!reader.IsDBNull(3)) student_course.CourseId = reader.GetString(3);
                    if (!reader.IsDBNull(4)) student_course.CourseName = reader.GetString(4);
                    if (!reader.IsDBNull(5)) student_course.CourseScore = reader.GetDecimal(5);
                }
                else
                {
                    student_course = null;
                }
            }
            return student_course;

        }
        #endregion
        #region Select_All Method
        /// <summary>
        /// Select all items
        /// </summary>
        /// <returns>items</returns>
        public IList<student_courseEntity> Getstudent_courses()
        {
            IList<student_courseEntity> student_courses = new List<student_courseEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ALL_SQL, null))
            {
                while (reader.Read())
                {
                    student_courseEntity student_course = new student_courseEntity();
                    if (!reader.IsDBNull(0)) student_course.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) student_course.StudentId = reader.GetString(1);
                    if (!reader.IsDBNull(2)) student_course.StudetnName = reader.GetString(2);
                    if (!reader.IsDBNull(3)) student_course.CourseId = reader.GetString(3);
                    if (!reader.IsDBNull(4)) student_course.CourseName = reader.GetString(4);
                    if (!reader.IsDBNull(5)) student_course.CourseScore = reader.GetDecimal(5);
                    student_courses.Add(student_course);
                }
            }
            return student_courses;
        }
        #endregion
        #region private common select by conditions
        /// <summary>
        /// private common select by conditions
        /// </summary>
        /// <returns>IList<student_courseEntity></returns>
        private IList<student_courseEntity> Getstudent_coursesbyQueryString(string SQLstr)
        {
            IList<student_courseEntity> student_courses = new List<student_courseEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SQLstr))
            {
                while (reader.Read())
                {
                    student_courseEntity student_course = new student_courseEntity();
                    if (!reader.IsDBNull(0)) student_course.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) student_course.StudentId = reader.GetString(1);
                    if (!reader.IsDBNull(2)) student_course.StudetnName = reader.GetString(2);
                    if (!reader.IsDBNull(3)) student_course.CourseId = reader.GetString(3);
                    if (!reader.IsDBNull(4)) student_course.CourseName = reader.GetString(4);
                    if (!reader.IsDBNull(5)) student_course.CourseScore = reader.GetDecimal(5);
                    student_courses.Add(student_course);
                }
            }
            return student_courses;
        }
        #endregion
        #region public common select by conditions ,we can use it by changing the Getstudent_coursesbyCondition(datatype condition) and sql
        /// <summary>
        /// Select items by Columns
        /// </summary>
        /// <returns>IList<student_courseEntity></returns>
        public IList<student_courseEntity> Getstudent_coursesbyCondition(string sql)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SELECT_WHERE_SQL);
            sb.Replace("{$where}", "where " + sql);
            return Getstudent_coursesbyQueryString(sb.ToString());
        }
        #endregion
        #region Select Method Top n
        /// <summary>
        /// Select items by Columns
        /// </summary>
        /// <returns>IList<student_courseEntity></returns>
        public IList<student_courseEntity> Getstudent_coursesTopN(int n)
        {
            IList<student_courseEntity> student_courses = new List<student_courseEntity>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SELECT_ALL_SQL, null))
            {
                int i = 0;
                while (reader.Read() && i < n)
                {
                    student_courseEntity student_course = new student_courseEntity();
                    if (!reader.IsDBNull(0)) student_course.Id = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) student_course.StudentId = reader.GetString(1);
                    if (!reader.IsDBNull(2)) student_course.StudetnName = reader.GetString(2);
                    if (!reader.IsDBNull(3)) student_course.CourseId = reader.GetString(3);
                    if (!reader.IsDBNull(4)) student_course.CourseName = reader.GetString(4);
                    if (!reader.IsDBNull(5)) student_course.CourseScore = reader.GetDecimal(5);
                    student_courses.Add(student_course);
                    i++;
                }
            }
            return student_courses;
        }
        #endregion
        #region paras configuration
        /// <summary>
        /// Internal function to get cached parameters:all paras --- suitable to insert ,especially autoincrement
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] Getstudent_courseParametersInsert()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_ALL_student_course_Insert");

            if (parms == null)
            {
                parms = new SqlParameter[] {
			new SqlParameter(PARA_StudentId,SqlDbType.VarChar) ,
			new SqlParameter(PARA_StudetnName,SqlDbType.VarChar) ,
			new SqlParameter(PARA_CourseId,SqlDbType.VarChar) ,
			new SqlParameter(PARA_CourseName,SqlDbType.VarChar) ,
			new SqlParameter(PARA_CourseScore,SqlDbType.Decimal)			};
                SQLHelper.CacheParameters("SQL_ALL_student_course_Insert", parms);
            }
            return parms;
        }
        /// <summary>
        /// Internal function to get cached parameters:all paras --- suitable to update
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] Getstudent_courseParameters()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_ALL_student_course_Update");

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARA_Id,SqlDbType.Int) ,
					new SqlParameter(PARA_StudentId,SqlDbType.VarChar) ,
					new SqlParameter(PARA_StudetnName,SqlDbType.VarChar) ,
					new SqlParameter(PARA_CourseId,SqlDbType.VarChar) ,
					new SqlParameter(PARA_CourseName,SqlDbType.VarChar) ,
					new SqlParameter(PARA_CourseScore,SqlDbType.Decimal)					};
                SQLHelper.CacheParameters("SQL_ALL_student_course_Update", parms);
            }
            return parms;
        }
        /// <summary>
        /// Internal function to get cached parameters:primary key paras
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] Getstudent_coursePrimaryKeyParameters()
        {
            SqlParameter[] parms = SQLHelper.GetCachedParameters("SQL_PrimaryKey_student_course");

            if (parms == null)
            {
                parms = new SqlParameter[] {
					new SqlParameter(PARA_Id,SqlDbType.Int) ,
					};
                SQLHelper.CacheParameters("SQL_PrimaryKey_student_course", parms);
            }
            return parms;
        }
        #endregion
    }
    #endregion
}
