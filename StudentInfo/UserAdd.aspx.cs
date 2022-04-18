using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using Model;
using DB;

namespace StudentInfo
{
    public partial class UserAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DALadmin_user dal = new DALadmin_user();
            admin_userEntity user = new admin_userEntity();
            user.UserName = username.Value;
            user.UserPassword = userpwd.Value;
            user.UserType = role.Value;
            user.LoginTimes = 1;
            user.LoginTime = DateTime.Now;
            user.TrueName = truename.Value;
            user.LinkTelephone = linktelephone.Value;
            dal.Addadmin_user(user);
            // this.Page.RegisterStartupScript("key", "<script>alert('添加成功')</script>");
            Response.Write("<script>alert('添加成功');location.href='Login.aspx';</script>");
           
        }
    }
}