using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DB;
using DAL;
using Model;
namespace StudentInfo
{
    public partial class UserEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            if (!IsPostBack)//首次加载
            {
                LoadUser(id);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            LoadUsers(id);
        }

        public void LoadUser(int id)
        {
            DALadmin_user dal = new DALadmin_user();
            admin_userEntity user = dal.Getadmin_user(id);

            username.Value = user.UserName;
            userpwd.Value = user.UserPassword;
            truename.Value = user.TrueName;
            linktelephone.Value = user.LinkTelephone;
            role.Value = user.UserType;


        }

        public void LoadUsers(int id)
        {
            DALadmin_user dal = new DALadmin_user();
            admin_userEntity user = dal.Getadmin_user(id);
            user.UserName = username.Value.Trim();
            user.UserPassword = userpwd.Value.Trim();
            user.LoginTimes = 1;
            user.TrueName = truename.Value.Trim();
            user.LinkTelephone = linktelephone.Value.Trim();
            user.UserType = role.Value;
            user.LoginTime = DateTime.Parse(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (dal.Modadmin_user(user) > 0)
            {
                Response.Write("<script>alert('编辑成功!');window.location.href='UserManage.aspx';</script>");
                //this.Page.RegisterStartupScript("key", "<script>alert('编辑成功!');</script>");
            }
            else
            {
                Response.Write("<script>alert('编辑失败!');window.location.href='UserManage.aspx';</script>");
                //this.Page.RegisterStartupScript("key", "<script>alert('编辑失败!');</script>");
            }

        }

    }
}