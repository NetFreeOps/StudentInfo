using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    #region newEntity
    /// <summary>
    /// Entity:newsEntity
    /// Author:NetCenter
    /// DateTime:2019/1/9 9:30:51
    /// </summary>
    [Serializable]
    public class newEntity
    {
        #region Member Variables
        protected int _id;
        protected string _title = String.Empty;
        protected string _author = String.Empty;
        protected DateTime _releaseTime;
        protected string _content = String.Empty;
        protected string _relateFile = String.Empty;
        #endregion
        #region Constructer without paras
        public newEntity()
        {
        }
        #endregion
        #region Constructer with paras
        /// <summary>
        /// Constructer with paras
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="releaseTime"></param>
        /// <param name="content"></param>
        /// <param name="relateFile"></param>
        public newEntity(
        int id,
        string title,
        string author,
        DateTime releaseTime,
        string content,
        string relateFile)
        {
            this._id = id;
            this._title = title;
            this._author = author;
            this._releaseTime = releaseTime;
            this._content = content;
            this._relateFile = relateFile;
        }
        #endregion
        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public DateTime ReleaseTime
        {
            get { return _releaseTime; }
            set { _releaseTime = value; }
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public string RelateFile
        {
            get { return _relateFile; }
            set { _relateFile = value; }
        }
        #endregion
    }
    #endregion
}
