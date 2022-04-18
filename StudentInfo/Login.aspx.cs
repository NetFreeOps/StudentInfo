using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using DAL;
using DB;
using System.Collections.Generic;
using Model;

namespace StudentInfo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["CheckCode"];
            if (cookie.Value == usercode.Value.ToUpper())
            {
                if (userrole.Value == "管理员" || userrole.Value == "教师")
                {
                    string name = user_name.Value;
                    string pwd = user_pwd.Value;
                    DALadmin_user dal = new DALadmin_user();
                    IList<admin_userEntity> users = new List<admin_userEntity>();
                    users = dal.Getadmin_usersbyCondition("username='" + name + "' and userpassword='" + pwd + "'");

                    if(userrole.Value == "管理员")
                    {
                        Session["roleid"] = "管理员";
                    }
                    else
                    {
                        Session["roleid"] = "教师";
                    }

                    if (users.Count > 0)
                    {
                        Session["xm"] = name;
                        Session["loginType"] = "admin";
                        Response.Write("<script>location.href='StudentFind.aspx';</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('用户和密码不正确!')</script>");

                    }
                }
                else//学生
                {
                    string name = user_name.Value;
                    string pwd = user_pwd.Value;
                    DALstudent_info dal = new DALstudent_info();
                    IList<student_infoEntity> stu = new List<student_infoEntity>();
                    stu = dal.Getstudent_infosbyCondition("studentid='" + name + "' and studentpassword='" + pwd + "'");
                    if (stu.Count > 0)
                    {
                        DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.ConnectionString, CommandType.Text, "select * from Student_Info where studentid='" + user_name.Value + "' and studentpassword='" + user_pwd.Value + "'");
                        Session["xh"] = ds.Tables[0].Rows[0][1].ToString();
                        Session["uname"] = ds.Tables[0].Rows[0][3].ToString();
                        Session["xm"] = ds.Tables[0].Rows[0][3].ToString();
                        Session["roleid"] = "学生";
                        Session["loginType"] = "student";
                        Response.Redirect("./CourseSelect.aspx");

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('用户和密码不正确!')</script>");

                    }
                }
            }
            else
                Response.Write("<script>alert('验证码错误！')</script>");
        }
        }
    }