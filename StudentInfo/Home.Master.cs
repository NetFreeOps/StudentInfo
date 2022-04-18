using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace StudentInfo
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected string menus()
        {
            string roleid = "";
            try
            {
                roleid = Session["roleid"].ToString();
            }
            catch(Exception)
            {
                roleid = "";
            }
        
            
        
            StringBuilder  sb = new StringBuilder();
            switch (roleid)
            {
                case "学生":
                    sb.Append("<li class=\"sidebar-nav-link\"><a href=\"CourseSelect.aspx\"><i class=\"am-icon-bar-chart sidebar-nav-link-logo\"></i>选课 </a></li>");
                    sb.Append("<li class=\"sidebar-nav-link\"><a href=\"NewsShow.aspx\"><i class=\"am-icon-bar-chart sidebar-nav-link-logo\"></i>查看公告 </a></li>");
                    break;
                case "教师":
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"StudentFind.aspx\" class=\"active\"><i class=\"am-icon-home sidebar-nav-link-logo\"></i>查找学生 </a></li>");
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"StudentManage.aspx\"><i class=\"am-icon-wpforms sidebar-nav-link-logo\"></i>学生管理 </a></li>");
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"StudentAdd.aspx\"><i class=\"am-icon-calendar sidebar-nav-link-logo\"></i>添加学生 </a></li>");
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"CourseScore.aspx\"><i class=\"am-icon-calendar sidebar-nav-link-logo\"></i>成绩录入 </a></li>");
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"scoreManager.aspx\"><i class=\"am-icon-calendar sidebar-nav-link-logo\"></i>成绩查询 </a></li>");

                   sb.Append(" <li class=\"sidebar-nav-link\"><a href=\"StuImport.aspx\"><i class=\"am-icon-wpforms sidebar-nav-link-logo\"></i>导入导出 </a></li>");
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"NewsShow.aspx\"><i class=\"am-icon-bar-chart sidebar-nav-link-logo\"></i>查看公告 </a></li>");
                   break;
                case "管理员":
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"StudentFind.aspx\" class=\"active\"><i class=\"am-icon-home sidebar-nav-link-logo\"></i>查找学生 </a></li>");
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"StudentManage.aspx\"><i class=\"am-icon-wpforms sidebar-nav-link-logo\"></i>学生管理 </a></li>");
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"StudentAdd.aspx\"><i class=\"am-icon-calendar sidebar-nav-link-logo\"></i>添加学生 </a></li>");
                   sb.Append(" <li class=\"sidebar-nav-link\"><a href=\"StuImport.aspx\"><i class=\"am-icon-wpforms sidebar-nav-link-logo\"></i>导入导出 </a></li>");
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"UserManage.aspx\"><i class=\"am-icon-table sidebar-nav-link-logo\"></i>用户管理 </a></li>");
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"UserAdd.aspx\"><i class=\"am-icon-wpforms sidebar-nav-link-logo\"></i>添加用户 </a></li>");
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"NewsShow.aspx\"><i class=\"am-icon-bar-chart sidebar-nav-link-logo\"></i>查看公告 </a></li>");
                 
                   sb.Append(" <li class=\"sidebar-nav-link\"><a href=\"NewsAdd.aspx\"><i class=\"am-icon-wpforms sidebar-nav-link-logo\"></i>添加公告 </a></li>");
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"CourseManage.aspx\"><i class=\"am-icon-calendar sidebar-nav-link-logo\"></i>课程管理 </a></li>");
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"CourseAdd.aspx\"><i class=\"am-icon-table sidebar-nav-link-logo\"></i>添加课程 </a></li>");
                   break;
                default:
                   sb.Append("<li class=\"sidebar-nav-link\"><a href=\"NewsShow.aspx\"><i class=\"am-icon-bar-chart sidebar-nav-link-logo\"></i>查看公告（匿名用户） </a></li>");
                    break;
            }


            return sb.ToString();
        }
    }
}