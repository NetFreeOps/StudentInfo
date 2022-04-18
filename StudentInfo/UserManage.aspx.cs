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
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//首次加载
            {
                LoadUsers();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());//行号
            int id = int.Parse(GridView1.DataKeys[rowIndex].Value.ToString());//根据行号获得Id主键
            if (e.CommandName.Equals("comE"))//单击了“编辑”按钮
            {
                Response.Redirect("UserEdit.aspx?id=" + id);

            }
            else if (e.CommandName.Equals("comD"))//单击了“删除”按钮
            {

                DALadmin_user dal = new DALadmin_user();
                dal.Deladmin_user(id);
                LoadUsers();//删除之后，重新加载
                this.Page.RegisterStartupScript("key", "<script>alert('删除成功！');</script>");
            }
            else
            {
                this.Page.RegisterStartupScript("key", "<script>alert('非法操作！');</script>");
            }
        }

        private void LoadUsers()
        {
            DALadmin_user dal = new DALadmin_user();
            IList<admin_userEntity> users = new List<admin_userEntity>();

            users = dal.Getadmin_users();

            GridView1.DataSource = users;
            GridView1.DataBind();

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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }


    }
}