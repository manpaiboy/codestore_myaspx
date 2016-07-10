using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;


namespace MyAspx.Framework.WebUnit.Common
{
    public class Identifying_code
    {
        public class VerifyCode
        {

            #region 验证码长度(默认4个验证码的长度)
            int length = 4;
            public int Length
            {
                get { return length; }
                set { length = value; }
            }
            #endregion

            #region 验证码字体大小(默认10像素)
            int fontSize = 10;
            public int FontSize
            {
                get { return fontSize; }
                set { fontSize = value; }
            }
            #endregion

            #region 边框补(默认1像素)
            int padding = 1;
            public int Padding
            {
                get { return padding; }
                set { padding = value; }
            }
            #endregion

            #region 是否输出燥点(默认输出)
            bool chaos = true;
            public bool Chaos
            {
                get { return chaos; }
                set { chaos = value; }
            }
            #endregion

            #region 输出燥点的颜色(默认灰色)
            Color chaosColor = Color.LightGray;
            public Color ChaosColor
            {
                get { return chaosColor; }
                set { chaosColor = value; }
            }
            #endregion

            #region 自定义背景色(默认白色)
            Color backgroundColor = Color.White;
            public Color BackgroundColor
            {
                get { return backgroundColor; }
                set { backgroundColor = value; }
            }
            #endregion

            #region 自定义随机颜色数组
            Color[] colors = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            public Color[] Colors
            {
                get { return colors; }
                set { colors = value; }
            }
            #endregion

            #region 自定义字体数组
            string[] fonts = { "Arial", "Georgia" };
            public string[] Fonts
            {
                get { return fonts; }
                set { fonts = value; }
            }
            #endregion

            #region 自定义随机码字符串序列(使用逗号分隔)
            string codeSerial = "0,1,2,3,4,5,6,7,8,9";
            public string CodeSerial
            {
                get { return codeSerial; }
                set { codeSerial = value; }
            }
            #endregion

            #region 生成校验码图片
            public Bitmap CreateImageCode(string code)
            {
                int fSize = FontSize;
                int fWidth = fSize + Padding;

                int imageWidth = (int)(code.Length * fWidth) + 4 + Padding * 2;
                int imageHeight = fSize * 2 + Padding;

                System.Drawing.Bitmap image = new System.Drawing.Bitmap(imageWidth, imageHeight);

                Graphics g = Graphics.FromImage(image);

                g.Clear(BackgroundColor);

                Random rand = new Random();

                //给背景添加随机生成的燥点
                if (this.Chaos)
                {

                    Pen pen = new Pen(ChaosColor, 0);
                    int c = Length * 10;

                    for (int i = 0; i < c; i++)
                    {
                        int x = rand.Next(image.Width);
                        int y = rand.Next(image.Height);

                        g.DrawRectangle(pen, x, y, 1, 1);
                    }
                }

                int left = 0, top = 1, top1 = 1, top2 = 1;

                int n1 = (imageHeight - FontSize - Padding * 2);
                int n2 = n1 / 4;
                top1 = n2;
                top2 = n2 * 2;

                Font f;
                Brush b;

                int cindex, findex;

                //随机字体和颜色的验证码字符
                for (int i = 0; i < code.Length; i++)
                {
                    cindex = rand.Next(Colors.Length - 1);
                    findex = rand.Next(Fonts.Length - 1);

                    f = new System.Drawing.Font(Fonts[findex], fSize, System.Drawing.FontStyle.Bold);
                    b = new System.Drawing.SolidBrush(Colors[cindex]);

                    if (i % 2 == 1)
                    {
                        top = top2;
                    }
                    else
                    {
                        top = top1;
                    }

                    left = i * fWidth;

                    g.DrawString(code.Substring(i, 1), f, b, left, top);
                }

                //画一个边框 边框颜色为Color.Gainsboro
                g.DrawRectangle(new Pen(Color.Gainsboro, 0), 0, 0, image.Width - 1, image.Height - 1);
                g.Dispose();
                return image;
            }
            #endregion

            #region 将创建好的图片输出到页面
            public void CreateImageOnPage(string code, HttpContext context)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                Bitmap image = this.CreateImageCode(code);

                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                context.Response.ClearContent();
                context.Response.ContentType = "image/Jpeg";
                context.Response.BinaryWrite(ms.GetBuffer());



                ms.Close();
                ms = null;
                image.Dispose();
                image = null;
            }
            #endregion

            #region 生成随机字符码
            public string CreateVerifyCode(int codeLen)
            {
                if (codeLen == 0)
                {
                    codeLen = Length;
                }

                string[] arr = CodeSerial.Split(',');

                string code = "";

                int randValue = -1;

                Random rand = new Random(unchecked((int)DateTime.Now.Ticks));

                for (int i = 0; i < codeLen; i++)
                {
                    randValue = rand.Next(0, arr.Length - 1);

                    code += arr[randValue];
                }

                return code;
            }
            public string CreateVerifyCode()
            {
                return CreateVerifyCode(0);
            }
            #endregion

        }
    }
}
