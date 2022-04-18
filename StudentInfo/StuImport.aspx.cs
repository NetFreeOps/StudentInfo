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



using DAL;
using Model;
using System.Collections.Generic;
using System.Data.OleDb;//操纵Excel格式的数据
using System.IO;
using System.Text;

namespace StudentInfo
{
    public partial class StuImport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("./Data/");

            if (FileUpload1.HasFile)//是否已经选择了文件，只有选择了，才能上传，进而才能导入。
            {
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);//如果保存文件的文件夹不存在，则创建。

                string filename = FileUpload1.FileName.ToLower();
                string extName = filename.Substring(filename.LastIndexOf('.'));//获取扩展名字
                if (extName.ToLower().Equals(".xls") || extName.ToLower().Equals(".xlsx"))
                {
                    int file_size = FileUpload1.FileName.Length;
                    string saveName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string mappath = path + "\\" + saveName + extName;//构造在服务器上存储的文件名
                    FileUpload1.SaveAs(mappath);//实现文件上传

                    if (File.Exists(mappath))
                    {
                        #region 打开文件，取出数据到内存
                        //连接对象
                        OleDbConnection oledbconn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Server.MapPath("~/Data/" + saveName + extName + "") + ";Persist Security Info=False;Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'");
                        //新建ole命令对象
                        oledbconn.Open();
                        ///因为需要在运行的过程中，增加数据列，并对数据进行修正。
                        ///所以，需要首先读入数据进入内存datatable中然后进行操作。
                        ///执行对象 Sheet1存放数据的工作表的名字，末尾加$
                        OleDbCommand commandSourceData = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbconn);
                        //离线操作数据
                        OleDbDataAdapter oleda = new OleDbDataAdapter();
                        oleda.SelectCommand = commandSourceData;
                        DataTable tb = new DataTable();
                        oleda.Fill(tb);
                        oledbconn.Close();
                        #endregion

                        //数据规整部分。
                        int successNumber = 0;
                        int failureNumber = 0;
                        //数据处理
                        StringBuilder resultsb = new StringBuilder();

                        DALstudent_info dal = new DALstudent_info();
                        student_infoEntity stu = new student_infoEntity();

                        foreach (DataRow dr in tb.Rows)
                        {
                            try
                            {
                                string xh = dr["xh"].ToString().Trim();
                                string xm = dr["xm"].ToString().Trim();
                                string xb = dr["xb"].ToString().Trim();
                                string mz = dr["mz"].ToString().Trim();
                                string dh = dr["dh"].ToString().Trim();
                                string qq = dr["qq"].ToString().Trim();
                                string bj = dr["bj"].ToString().Trim();
                                string ss = dr["ss"].ToString().Trim();
                                string jg = dr["jg"].ToString().Trim();

                                stu = new student_infoEntity();
                                stu.StudentAddress = jg;
                                stu.StudentClass = bj;
                                stu.StudentDormitory = "";
                                stu.StudentId = xh;
                                stu.StudentName = xm;
                                stu.StudentNation = mz;
                                stu.StudentPassword = "123";
                                stu.StudentSex = xb;
                                stu.StudentTelephone = dh;
                                stu.StudentQQ = qq;
                                stu.StudentClass = bj;
                                stu.StudentDormitory = ss;
                                stu.StudentAddress = jg;
                                dal.Addstudent_info(stu);

                                successNumber++;
                            }
                            catch (Exception Error)
                            {
                                resultsb.Append(dr["xm"].ToString().Trim());
                                resultsb.Append("导入失败；原因：");
                                resultsb.Append(Error.Message);
                                resultsb.Append("\r\n");
                                failureNumber++;
                            }
                        }//endforeach
                        resultsb.Insert(0, successNumber + " 条信息成功导入！\r\n" + failureNumber + "条信息无法导入！\r\n");
                        ltshow.Text = "<div class=\"valid_box\">" + resultsb.ToString() + "</div>";
                    }
                    else
                    {
                        ltshow.Text = "<div class=\"valid_box\">没有可以导入的文件！</div>";
                    }
                }
                else
                {
                    ltshow.Text = "<div class=\"error_box\">必须上传Excel格式的文件！</div>";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DALstudent_info dal = new DALstudent_info();
            IList<student_infoEntity> stus = dal.Getstudent_infos();
            DataTable dt = new DataTable();
            dt.Columns.Add("xh");
            dt.Columns.Add("xm");
            dt.Columns.Add("xb");
            dt.Columns.Add("mz");
            dt.Columns.Add("dh");
            dt.Columns.Add("qq");
            dt.Columns.Add("bj");
            dt.Columns.Add("ss");
            dt.Columns.Add("jg");
            dt.AcceptChanges();
            foreach (student_infoEntity stu in stus)
            {
                DataRow dr = dt.NewRow();
                dr[0] = stu.StudentId;
                dr["xm"] = stu.StudentName;
                dr[2] = stu.StudentSex;
                dr[3] = stu.StudentNation;
                dr[4] = stu.StudentTelephone;
                dr[5] = stu.StudentQQ;
                dr[6] = stu.StudentClass;
                dr[7] = stu.StudentDormitory;
                dr[8] = stu.StudentAddress;
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            string[] fileds = { "学号", "姓名", "性别", "籍贯", "电话", "QQ", "班级", "宿舍", "籍贯" };
            ExportToExcel_NoFormat(dt, fileds, "学生信息导出列表");
        }

        public static bool ExportToExcel_NoFormat(System.Data.DataTable table, string[] FieldName, string title)
        {
            HttpServerUtility _server = HttpContext.Current.Server;
            string TemplateFiletop = _server.MapPath("~\\Data\\top.txt");
            string TemplateFileend = _server.MapPath("~\\Data\\end.txt");
            StringBuilder str = new StringBuilder();

            try
            {
                StreamReader sr = new StreamReader(TemplateFiletop, Encoding.GetEncoding("GB2312"));
                str.Append(sr.ReadToEnd());
                sr.Dispose();
                sr.Close();
            }
            catch
            {
                return false;
            }
            //输出标题

            str.Append("<Row ss:AutoFitHeight=\"0\">\r\n");
            str.Append("<Cell ss:StyleID=\"s75\"><Data ss:Type=\"String\">");
            str.Append(title);
            str.Append("</Data></Cell>\r\n");
            for (int i = 1; i < FieldName.Length; i++)
            {
                str.Append("<Cell ss:StyleID=\"s76\"/>\r\n");
            }
            str.Append("</Row>\r\n");

            //输出列字段
            str.Append("<Row ss:AutoFitHeight=\"0\">\r\n");
            foreach (string Field in FieldName)
            {
                str.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">");
                str.Append(Field);
                str.Append("</Data></Cell>\r\n");
            }
            str.Append("</Row>\r\n");
            //输出行记录
            foreach (DataRow row in table.Rows)
            {
                int i = 0;
                str.Append("<Row ss:AutoFitHeight=\"0\">\r\n");
                foreach (DataColumn col in table.Columns)
                {
                    i++;
                    if (i > FieldName.Length)
                        break;
                    str.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + (string.IsNullOrEmpty(row[col.ColumnName].ToString()) ? " " : row[col.ColumnName].ToString()) + "</Data></Cell>\r\n");
                }
                str.Append("</Row>\r\n");
            }
            try
            {
                StreamReader sr = new StreamReader(TemplateFileend, Encoding.GetEncoding("GB2312"));
                str.Append(sr.ReadToEnd());
                sr.Dispose();
                sr.Close();
            }
            catch
            {
                return false;
            }
            //替换输出的列数和行数
            str.Replace("ss:ExpandedColumnCount=\"5\"", "ss:ExpandedColumnCount=\"" + FieldName.Length + "\"");
            str.Replace("ss:ExpandedRowCount=\"2\"", "ss:ExpandedRowCount=\"" + (table.Rows.Count + 20) + "\"");
            //输出文档
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Data.xls");
            //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF7;
            HttpContext.Current.Response.ContentType = "application/excel";
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
            return true;

        }

    }
}