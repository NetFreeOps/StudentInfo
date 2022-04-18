using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using Model;
using System.Data;

namespace StudentInfo
{
    public partial class CourseScore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCourse();
                BindSelectCourse();
            }
        }


        private void BindCourse()
        {
            DALcourse dal = new DALcourse();
            IList<courseEntity> cs = dal.Getcourses();
            DropDownList1.DataSource = cs;
            DropDownList1.DataTextField = "CourseName";
            DropDownList1.DataValueField = "CourseId";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("全部", "0"));
        }

        public void BindSelectCourse()
        {
            DALstudent_course dal = new DALstudent_course();
            IList<student_courseEntity> scs = dal.Getstudent_courses();
            
            GridView1.DataSource = scs;
            GridView1.DataBind();
        }

        private DataTable ReadGridView()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("Id", typeof(int)));
            dt.Columns.Add(new DataColumn("StudentId", typeof(string)));
            dt.Columns.Add(new DataColumn("StudetnName", typeof(string)));
            dt.Columns.Add(new DataColumn("CourseId", typeof(string)));
            dt.Columns.Add(new DataColumn("CourseName", typeof(string)));
            dt.Columns.Add(new DataColumn("CourseScore", typeof(int)));


            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = this.GridView1.Rows[i].Cells[0].Text.Trim();
                dr[1] = this.GridView1.Rows[i].Cells[1].Text.Trim();
                dr[2] = this.GridView1.Rows[i].Cells[2].Text.Trim();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 成绩提交处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            DALstudent_course dal = new DALstudent_course();
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                if (gvr.RowType == DataControlRowType.DataRow)//如果是数据行
                {
                    student_courseEntity sc = new student_courseEntity();
                    int id = int.Parse(GridView1.DataKeys[gvr.RowIndex].Value.ToString());
                    sc = dal.Getstudent_course(id);//获取当前的数据
                    TextBox tb1 = (TextBox)gvr.FindControl("tb1");
                    if (string.IsNullOrEmpty(tb1.Text))
                    {
                        sc.CourseScore = 0;
                    }
                    else
                    {
                        sc.CourseScore = decimal.Parse(tb1.Text.Trim());
                    }
                    dal.Modstudent_course(sc);
                }
            }
            Button1.Enabled = false;
            this.Page.RegisterStartupScript("key", "<script>alert('成绩录入成功！');</script>");
        }
        /// <summary>
        /// 添加新行以录入成绩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {


            //DataTable dt = ReadGridView();
            //DataRow row = dt.NewRow();

            //row.ItemArray = new object[] { 230, "oec2003", "oec2003", "oec2003", "xxx", 100 };
            //dt.Rows.InsertAt(row, 0);
            //dt.AcceptChanges();
            //this.GridView1.DataSource = dt;
            //this.GridView1.DataBind();

            //DALstudent_course dal = new DALstudent_course();
            //foreach (GridViewRow gvr in GridView1.Rows)
            //{
            //    if (gvr.RowType == DataControlRowType.DataRow)//如果是数据行
            //    {
            //        student_courseEntity sc = new student_courseEntity();
            //        int id = int.Parse(GridView1.DataKeys[gvr.RowIndex].Value.ToString());
            //        sc = dal.Getstudent_course(id);//获取当前的数据
            //        TextBox tb1 = (TextBox)gvr.FindControl("tb1");
            //        if (string.IsNullOrEmpty(tb1.Text))
            //        {
            //            sc.CourseScore = 0;
            //        }
            //        else
            //        {
            //            sc.CourseScore = decimal.Parse(tb1.Text.Trim());
            //        }
            //        dal.Modstudent_course(sc);
            //    }
            //}
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DALstudent_course dal = new DALstudent_course();
            IList<student_courseEntity> scs = new List<student_courseEntity>();
            if (DropDownList1.SelectedValue.Equals("0"))
            {
                scs = dal.Getstudent_courses();
            }
            else
            {
                scs = dal.Getstudent_coursesbyCondition("CourseId='" + DropDownList1.SelectedValue + "'");
            }
            GridView1.DataSource = scs;
            GridView1.DataBind();
        }
    }
}