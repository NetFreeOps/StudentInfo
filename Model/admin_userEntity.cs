using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    #region admin_userEntity
    /// <summary>
    /// Entity:admin_userEntity
    /// Author:NetCenter
    /// DateTime:2019/1/7 10:02:20
    /// </summary>
    [Serializable]
    public class admin_userEntity
    {
        #region Member Variables
        protected int _id;
        protected string _userName = String.Empty;
        protected string _userType = String.Empty;
        protected string _userPassword = String.Empty;
        protected int _loginTimes;
        protected string _trueName = String.Empty;
        protected string _linkTelephone = String.Empty;
        protected DateTime _loginTime;
        #endregion
        #region Constructer without paras
        public admin_userEntity()
        {
        }
        #endregion
        #region Constructer with paras
        /// <summary>
        /// Constructer with paras
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="userType"></param>
        /// <param name="userPassword"></param>
        /// <param name="loginTimes"></param>
        /// <param name="trueName"></param>
        /// <param name="linkTelephone"></param>
        /// <param name="loginTime"></param>
        public admin_userEntity(
        int id,
        string userName,
        string userType,
        string userPassword,
        int loginTimes,
        string trueName,
        string linkTelephone,
        DateTime loginTime)
        {
            this._id = id;
            this._userName = userName;
            this._userType = userType;
            this._userPassword = userPassword;
            this._loginTimes = loginTimes;
            this._trueName = trueName;
            this._linkTelephone = linkTelephone;
            this._loginTime = loginTime;
        }
        #endregion
        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        public int LoginTimes
        {
            get { return _loginTimes; }
            set { _loginTimes = value; }
        }

        public string TrueName
        {
            get { return _trueName; }
            set { _trueName = value; }
        }

        public string LinkTelephone
        {
            get { return _linkTelephone; }
            set { _linkTelephone = value; }
        }

        public DateTime LoginTime
        {
            get { return _loginTime; }
            set { _loginTime = value; }
        }
        #endregion
    }
    #endregion
}
