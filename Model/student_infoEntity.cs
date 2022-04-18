using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    #region student_infoEntity
    /// <summary>
    /// Entity:student_infoEntity
    /// Author:NetCenter
    /// DateTime:2019/1/8 8:13:45
    /// </summary>
    [Serializable]
    public class student_infoEntity
    {
        #region Member Variables
        protected int _id;
        protected string _studentId = String.Empty;
        protected string _studentPassword = String.Empty;
        protected string _studentName = String.Empty;
        protected string _studentPhoto = String.Empty;
        protected string _studentSex = String.Empty;
        protected string _studentNation = String.Empty;
        protected string _studentTelephone = String.Empty;
        protected string _studentQQ = String.Empty;
        protected string _studentClass = String.Empty;
        protected string _studentDormitory = String.Empty;
        protected string _studentAddress = String.Empty;
        #endregion
        #region Constructer without paras
        public student_infoEntity()
        {
        }
        #endregion
        #region Constructer with paras
        /// <summary>
        /// Constructer with paras
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentId"></param>
        /// <param name="studentPassword"></param>
        /// <param name="studentName"></param>
        /// <param name="studentPhoto"></param>
        /// <param name="studentSex"></param>
        /// <param name="studentNation"></param>
        /// <param name="studentTelephone"></param>
        /// <param name="studentQQ"></param>
        /// <param name="studentClass"></param>
        /// <param name="studentDormitory"></param>
        /// <param name="studentAddress"></param>
        public student_infoEntity(
        int id,
        string studentId,
        string studentPassword,
        string studentName,
        string studentPhoto,
        string studentSex,
        string studentNation,
        string studentTelephone,
        string studentQQ,
        string studentClass,
        string studentDormitory,
        string studentAddress)
        {
            this._id = id;
            this._studentId = studentId;
            this._studentPassword = studentPassword;
            this._studentName = studentName;
            this._studentPhoto = studentPhoto;
            this._studentSex = studentSex;
            this._studentNation = studentNation;
            this._studentTelephone = studentTelephone;
            this._studentQQ = studentQQ;
            this._studentClass = studentClass;
            this._studentDormitory = studentDormitory;
            this._studentAddress = studentAddress;
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

        public string StudentPassword
        {
            get { return _studentPassword; }
            set { _studentPassword = value; }
        }

        public string StudentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        public string StudentPhoto
        {
            get { return _studentPhoto; }
            set { _studentPhoto = value; }
        }

        public string StudentSex
        {
            get { return _studentSex; }
            set { _studentSex = value; }
        }

        public string StudentNation
        {
            get { return _studentNation; }
            set { _studentNation = value; }
        }

        public string StudentTelephone
        {
            get { return _studentTelephone; }
            set { _studentTelephone = value; }
        }

        public string StudentQQ
        {
            get { return _studentQQ; }
            set { _studentQQ = value; }
        }

        public string StudentClass
        {
            get { return _studentClass; }
            set { _studentClass = value; }
        }

        public string StudentDormitory
        {
            get { return _studentDormitory; }
            set { _studentDormitory = value; }
        }

        public string StudentAddress
        {
            get { return _studentAddress; }
            set { _studentAddress = value; }
        }
        #endregion
    }
    #endregion
}
