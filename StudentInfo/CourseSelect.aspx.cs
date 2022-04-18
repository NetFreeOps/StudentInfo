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
    public partial class CourseSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllCourse();
                BindSelectedCourse();
            }
        }

        public void BindAllCourse()
        {
            DALcourse dal = new DALcourse();
            IList<courseEntity> courses = dal.Getcourses();
            ListBox1.DataSource = courses;
            ListBox1.DataTextField = "CourseName";
            ListBox1.DataValueField = "CourseId";
            ListBox1.DataBind();
        }

        public void BindSelectedCourse()
        {
            DALstudent_course dal = new DALstudent_course();
            IList<student_courseEntity> stu = dal.Getstudent_coursesbyCondition("StudentId='" + Session["xh"] + "'");
            ListBox2.DataSource = stu;
            ListBox2.DataTextField = "CourseName";
            ListBox2.DataValueField = "CourseId";
            ListBox2.DataBind();

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string xh = Session["xh"].ToString();
            string xm = Session["xm"].ToString();
            DALstudent_course dal = new DALstudent_course();
            foreach (ListItem li in ListBox2.Items)
            {
                student_courseEntity sc = new student_courseEntity();
                sc.CourseId = li.Value;
                sc.CourseName = li.Text;
                sc.StudentId = xh;
                sc.StudetnName = xm;
                dal.Addstudent_course(sc);
            }
            btnSubmit.Enabled = false;
            this.Page.RegisterStartupScript("key", "<script>alert('选课成功！');</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ListItem li = ListBox1.SelectedItem;
            if (ListBox2.Items.Contains(li))
                this.Page.RegisterStartupScript("key", "<script>alert('已经选择该课程，不能重复！');</script>");
            else
            {
                ListBox2.Items.Add(li);
                ListBox1.Items.Remove(li);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ListItem li = ListBox2.SelectedItem;
            if (ListBox1.Items.Contains(li))
            {

            }
            else
            {
                ListBox1.Items.Add(li);
                ListBox2.Items.Remove(li);
            }
        }


    }
}