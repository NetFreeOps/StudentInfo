using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    #region courseEntity
    /// <summary>
    /// Entity:courseEntity
    /// Author:NetCenter
    /// DateTime:2019/1/9 9:29:57
    /// </summary>
    [Serializable]
    public class courseEntity
    {
        #region Member Variables
        protected int _id;
        protected string _courseId = String.Empty;
        protected string _courseName = String.Empty;
        protected string _courseTeacher = String.Empty;
        protected string _courseInfo = String.Empty;
        protected int _courseStudentNum;
        #endregion
        #region Constructer without paras
        public courseEntity()
        {
        }
        #endregion
        #region Constructer with paras
        /// <summary>
        /// Constructer with paras
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courseId"></param>
        /// <param name="courseName"></param>
        /// <param name="courseTeacher"></param>
        /// <param name="courseInfo"></param>
        /// <param name="courseStudentNum"></param>
        public courseEntity(
        int id,
        string courseId,
        string courseName,
        string courseTeacher,
        string courseInfo,
        int courseStudentNum)
        {
            this._id = id;
            this._courseId = courseId;
            this._courseName = courseName;
            this._courseTeacher = courseTeacher;
            this._courseInfo = courseInfo;
            this._courseStudentNum = courseStudentNum;
        }
        #endregion
        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CourseId
        {
            get { return _courseId; }
            set { _courseId = value; }
        }

        public string CourseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        public string CourseTeacher
        {
            get { return _courseTeacher; }
            set { _courseTeacher = value; }
        }

        public string CourseInfo
        {
            get { return _courseInfo; }
            set { _courseInfo = value; }
        }

        public int CourseStudentNum
        {
            get { return _courseStudentNum; }
            set { _courseStudentNum = value; }
        }
        #endregion
    }
    #endregion
}
