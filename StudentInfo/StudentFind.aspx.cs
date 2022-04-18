using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using Model;
using System.Text;


namespace StudentInfo
{
    public partial class StudentFind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//首次加载
            {
                LoadStudents();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            //判断班级是否限定、
            if (DropDownList1.SelectedItem.Text.Equals("全部"))
            {

            }
            else
            {
                sb.Append("studentClass='" + DropDownList1.SelectedValue + "'");
            }
            //判断性别是否限定
            if (DropDownList2.SelectedItem.Text.Equals("全部"))
            { }
            else
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("studentSex='" + DropDownList2.SelectedValue + "'");
            }
            //判断姓名
            if (string.IsNullOrEmpty(TextBox1.Text))
            {

            }
            else
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append(" studentName like '%" + TextBox1.Text + "%'");
            }

            DALstudent_info dal = new DALstudent_info();
            IList<student_infoEntity> stus = new List<student_infoEntity>();
            if (sb.Length > 0)
            {
                stus = dal.Getstudent_infosbyCondition(sb.ToString());
            }
            else
            {
                stus = dal.Getstudent_infos();
            }
            GridView1.DataSource = stus;
            GridView1.DataBind();
        
        }

        private void LoadStudents()
        {
            DALstudent_info dal = new DALstudent_info();
            IList<student_infoEntity> stus = new List<student_infoEntity>();

            stus = dal.Getstudent_infos();

            GridView1.DataSource = stus;
            GridView1.DataBind();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());//行号
            int id = int.Parse(GridView1.DataKeys[rowIndex].Value.ToString());//根据行号获得Id主键
            if (e.CommandName.Equals("ComE"))//单击了“编辑”按钮
            {
                Response.Redirect("StudentEdit.aspx?id=" + id);

            }
            else if (e.CommandName.Equals("ComD"))//单击了“删除”按钮
            {

                DALstudent_info dal = new DALstudent_info();
                dal.Delstudent_info(id);
                LoadStudents();//删除之后，重新加载
                this.Page.RegisterStartupScript("key", "<script>alert('删除成功！');</script>");
            }
            else
            {
                this.Page.RegisterStartupScript("key", "<script>alert('非法操作！');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvr = e.Row;
            if (gvr.RowType == DataControlRowType.DataRow)//只有数据行采用操作的必要性
            {
                LinkButton lb1 = (LinkButton)gvr.FindControl("lbE");
                lb1.CommandArgument = gvr.RowIndex.ToString();//当使用的时候，可以将所在的行号带回去进行后续的数据操作。

                LinkButton lb2 = (LinkButton)gvr.FindControl("lbD");
                lb2.CommandArgument = gvr.RowIndex.ToString();//当使用的时候，可以将所在的行号带回去进行后续的数据操作。
            }
        }


    }
}