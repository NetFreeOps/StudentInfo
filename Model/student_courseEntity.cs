using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    #region student_courseEntity
    /// <summary>
    /// Entity:student_courseEntity
    /// Author:NetCenter
    /// DateTime:2019/1/9 10:16:06
    /// </summary>
    [Serializable]
    public class student_courseEntity
    {
        #region Member Variables
        protected int _id;
        protected string _studentId = String.Empty;
        protected string _studetnName = String.Empty;
        protected string _courseId = String.Empty;
        protected string _courseName = String.Empty;
        protected decimal _courseScore;
        #endregion
        #region Constructer without paras
        public student_courseEntity()
        {
        }
        #endregion
        #region Constructer with paras
        /// <summary>
        /// Constructer with paras
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentId"></param>
        /// <param name="studetnName"></param>
        /// <param name="courseId"></param>
        /// <param name="courseName"></param>
        /// <param name="courseScore"></param>
        public student_courseEntity(
        int id,
        string studentId,
        string studetnName,
        string courseId,
        string courseName,
        decimal courseScore)
        {
            this._id = id;
            this._studentId = studentId;
            this._studetnName = studetnName;
            this._courseId = courseId;
            this._courseName = courseName;
            this._courseScore = courseScore;
        }
        #endregion
        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        public string StudetnName
        {
            get { return _studetnName; }
            set { _studetnName = value; }
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

        public decimal CourseScore
        {
            get { return _courseScore; }
            set { _courseScore = value; }
        }
        #endregion
    }
    #endregion
}
