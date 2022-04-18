using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using DAL;
using DB;
using Model;

namespace StudentInfo
{
    public partial class StudentAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DALstudent_info dal = new DALstudent_info();
            student_infoEntity stu = new student_infoEntity();
            string filename = imgUpLoad(Fileimg);
            stu.StudentId = id.Value.Trim();
            stu.StudentName = name.Value.Trim();
            stu.StudentPassword = pwd.Value.Trim();
            stu.StudentPhoto = filename;
            stu.StudentSex = sex.Value.Trim();
            stu.StudentNation = nation.Value.Trim();
            stu.StudentTelephone = telephone.Value.Trim();
            stu.StudentQQ = qq.Value.Trim();
            stu.StudentClass = StudentClass.Value.Trim();
            stu.StudentDormitory = dormitory.Value.Trim();
            stu.StudentAddress = address.Value.Trim();

            if (dal.Addstudent_info(stu) > 0)
            {
                Response.Write("<script>alert('添加成功!');window.location.href='StudentManage.aspx';</script>");
                //this.Page.RegisterStartupScript("key", "<script>alert('编辑成功!');</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败!');window.location.href='StudentManage.aspx';</script>");
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