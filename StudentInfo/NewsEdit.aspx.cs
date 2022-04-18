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
    public partial class NewsEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            if (!IsPostBack)//首次加载
            {
                LoadNe(id);
            }
        }

        public void LoadNe(int id)
        {
            DALnew dal = new DALnew();
            newEntity ne = dal.Getnews(id);
            title.Value = ne.Title;
            auther.Value = ne.Author;
            content.Value = ne.Content;
        }

        public void LoadNes(int id)
        {
            DALnew dal = new DALnew();
            newEntity ne = dal.Getnews(id);
            ne.Title = title.Value;
            ne.Author = auther.Value;
            string con = content.Value;
            con = con.Replace("<p>", "");
            ne.Content = con.Replace("</p>", "");
            ne.RelateFile = "";
            ne.ReleaseTime = DateTime.Now;
            if (dal.Modnews(ne) > 0)
            {
                Response.Write("<script>alert('编辑成功!');window.location.href='NewsManage.aspx';</script>");
                //this.Page.RegisterStartupScript("key", "<script>alert('编辑成功!');</script>");
            }
            else
            {
                Response.Write("<script>alert('编辑失败!');window.location.href='NewsManage.aspx';</script>");
                //this.Page.RegisterStartupScript("key", "<script>alert('编辑失败!');</script>");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            LoadNes(id);
        }

    }
}