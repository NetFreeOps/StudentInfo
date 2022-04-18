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
    public partial class CourseEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            if (!IsPostBack)//首次加载
            {
                LoadCourse(id);
            }
        }

        public void LoadCourse(int id)
        {
            DALcourse dal = new DALcourse();
            courseEntity cour = dal.Getcourse(id);
            course_id.Value = cour.CourseId;
            course_name.Value = cour.CourseName;
            course_teacher.Value = cour.CourseTeacher;
            course_info.Value = cour.CourseInfo;
            course_number.Value = cour.CourseStudentNum.ToString();
        }

        public void LoadCourses(int id)
        {
            DALcourse dal = new DALcourse();
            courseEntity cour = dal.Getcourse(id);
            cour.CourseId = course_id.Value.Trim();
            cour.CourseName = course_name.Value.Trim();
            cour.CourseTeacher = course_teacher.Value.Trim();
            cour.CourseInfo = course_info.Value.Trim();
            cour.CourseStudentNum = int.Parse(course_number.Value.Trim());
            if (dal.Modcourse(cour) > 0)
            {
                Response.Write("<script>alert('编辑成功!');window.location.href='CourseManage.aspx';</script>");
                //this.Page.RegisterStartupScript("key", "<script>alert('编辑成功!');</script>");
            }
            else
            {
                Response.Write("<script>alert('编辑失败!');window.location.href='CourseManage.aspx';</script>");
                //this.Page.RegisterStartupScript("key", "<script>alert('编辑失败!');</script>");
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            LoadCourses(id);
        }
    }
}