using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using Model;

namespace StudentInfo
{
    public partial class NewsShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindNews();
            }
        }

        private void BindNews()
        {
            DALnew dal = new DALnew();
            IList<newEntity> ne = dal.Getnewss();

            GridView1.DataSource = ne;
            GridView1.DataBind();
        }
    }
}