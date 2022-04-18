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
    public partial class CourseAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string courseid = course_id.Value;
            string coursename = course_name.Value;
            string courseteacher = course_teacher.Value;
            int coursenum = int.Parse(course_number.Value);
            string courseinfo = course_info.Value;

            DALcourse dal = new DALcourse();
            IList<courseEntity> courses = new List<courseEntity>();
            courses = dal.GetcoursesbyCondition("CourseId='" + courseid + "' or CourseName='" + coursename + "'");
            if (courses.Count > 0)
            {
                this.Page.RegisterStartupScript("key", "<script>alert('课程信息重复，无法添加！');</script>");
            }
            else
            {
                courseEntity course = new courseEntity();
                course.CourseId = courseid;
                course.CourseInfo = courseinfo;
                course.CourseName = coursename;
                course.CourseStudentNum = coursenum;
                course.CourseTeacher = courseteacher;
                dal.Addcourse(course);
                this.Page.RegisterStartupScript("key", "<script>alert('课程信息添加成功！');</script>");
            }
        }
    }
}