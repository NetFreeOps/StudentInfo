using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;

namespace StudentInfo
{
    public partial class CheckCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DrawCheckImage(GenerateCode());
        }

        private string GenerateCode()
        {
            int num;//个数
            char code;//随机变量的内容
            string checkCode = String.Empty;//保存结果字符串
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                num = rand.Next();//声明随机变量rand
                if (i % 2 != 0)
                {
                    code = (char)('0' + (char)(num % 10));
                }
                else
                {
                    code = (char)('A' + (char)(num % 26));
                }
                checkCode += code;
            }
            Response.Cookies.Add(new HttpCookie("CheckCode", "0000"));//客户端缓存cookie字符串
            return checkCode;
        }
        /// <summary>
        ///根据生成的字符串，构造一个验证码
        /// </summary>
        /// <param name="checkCode"></param>
        private void DrawCheckImage(string checkCode)
        {
            if (checkCode == null || checkCode.Trim() == string.Empty)
                return;
            Bitmap image = new Bitmap((int)Math.Ceiling(checkCode.Length * 12.5), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                Random random = new Random();
                g.Clear(Color.White);//清空图片背景色
                for (int i = 0; i < 4; i++)
                {//随机画图片的背景噪音线
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Black), x1, x2, y1, y2);
                }
                Font font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic);
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(checkCode, font, brush, 2, 2);
                for (int i = 0; i < 100; i++)
                {//随机画图片的前景噪音点
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";
                Response.BinaryWrite(ms.ToArray());
            }
            catch (Exception ee)
            { }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }
}