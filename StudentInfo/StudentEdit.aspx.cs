using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.IO;

using DAL;
using DB;
using Model;

namespace StudentInfo
{
    public partial class StudentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            if (!IsPostBack)//首次加载
            {
                LoadStudent(id);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            LoadStudents(id);
        }
        public void LoadStudent(int id)
        {
            DALstudent_info dal = new DALstudent_info();
            student_infoEntity stu = dal.Getstudent_info(id);

            stuid.Value = stu.StudentId;
            pwd.Value = stu.StudentPassword;
            name.Value = stu.StudentName;
            sex.Value = stu.StudentSex;
            nation.Value = stu.StudentNation;
            telephone.Value = stu.StudentTelephone;
            qq.Value = stu.StudentQQ;
            StudentClass.Value = stu.StudentClass;
            dormitory.Value = stu.StudentDormitory;
            address.Value = stu.StudentAddress;
        }
        public void LoadStudents(int id)
        {
            DALstudent_info dal = new DALstudent_info();
            student_infoEntity stu = dal.Getstudent_info(id);
            string filename = imgUpLoad(Fileimg);
            stu.StudentId = stuid.Value.Trim();
            stu.StudentName = name.Value.Trim();
            stu.StudentPhoto = filename;
            stu.StudentPassword = pwd.Value.Trim();
            stu.StudentSex = sex.Value.Trim();
            stu.StudentNation = nation.Value.Trim();
            stu.StudentTelephone = telephone.Value.Trim();
            stu.StudentQQ = qq.Value.Trim();
            stu.StudentClass = StudentClass.Value.Trim();
            stu.StudentDormitory = dormitory.Value.Trim();
            stu.StudentAddress = address.Value.Trim();
            if (dal.Modstudent_info(stu) > 0)
            {
                Response.Write("<script>alert('编辑成功!');window.location.href='StudentManage.aspx';</script>");
                //this.Page.RegisterStartupScript("key", "<script>alert('编辑成功!');</script>");
            }
            else
            {
                Response.Write("<script>alert('编辑失败!');window.location.href='StudentManage.aspx';</script>");
                //this.Page.RegisterStartupScript("key", "<script>alert('编辑失败!');</script>");
            }

        }
        public string imgUpLoad(FileUpload fUpload)
        {
            string fileName = "";
            if (fUpload.HasFile)
            {
                string fileExt = Path.GetExtension(fUpload.FileName).ToLower();
                string uploadFileExt = ".gif|.jpg|.png|.bmp";
                if (("|" + uploadFileExt + "|").IndexOf(("|" + fileExt + "|")) >= 0)
                {
                    try
                    {
                        fileName = DateTime.Now.ToString("yyyymmddhhmmss").ToString() + fileExt;
                        fUpload.SaveAs(Server.MapPath("imgs/stu/") + fileName);
                    }
                    catch (Exception ee)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('" + ee.Message + "')</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请上传gif|jpg|png|bmp的文件')</script>");
                }
            }
            return fileName;
        }

    }
}