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
    public partial class NewsAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DALnew dal = new DALnew();
            newEntity news = new newEntity();
            news.Title = title.Value;
            news.Author = auther.Value;
            string con = content.Value;
            con = con.Replace("<p>", "");
            news.Content = con.Replace("</p>", "");
            news.RelateFile = "";
            news.ReleaseTime = DateTime.Now;
            if (dal.Addnews(news) > 0)
            {
                this.Page.RegisterStartupScript("key", "<script>alert('添加成功！');</script>");

            }
        }
    }
}