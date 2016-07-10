using System;
using System.Web;
using System.Web.UI;
namespace MyAspx.Framework.WebUnit.Common
{
    public class Jscript
    {

        public static void Alert(string strMessage)
        {
            Page currentPage = HttpContext.Current.Handler as Page;
            if (currentPage != null)
            {
                currentPage.ClientScript.RegisterStartupScript(
                                  typeof(System.String),
                                  "messagebox",
                                  string.Format("alert(\"{0}\");", strMessage.Replace("\r\n", " ")),
                                  true
                                  );
            }
        }
        public static void RegScripts(string strMessage)
        {
            Page currentPage = HttpContext.Current.Handler as Page;
            if (currentPage != null)
            {
                currentPage.ClientScript.RegisterStartupScript(
                                  typeof(System.String),
                                  "messageboxs",
                                  string.Format("{0}", strMessage.Replace("\r\n", " ")),
                                  true
                                  );
            }
        }
        public static void RegScripts(string strMessage, string name)
        {
            Page currentPage = HttpContext.Current.Handler as Page;
            if (currentPage != null)
            {
                currentPage.ClientScript.RegisterStartupScript(
                                  typeof(System.String),
                                  name,
                                  string.Format("{0}", strMessage.Replace("\r\n", " ")),
                                  true
                                  );
            }
        }

        /// <summary>
        /// 弹出消息框并且转向到新的URL
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="toURL">连接地址</param>
        public static void AlertAndRedirect(string message, string toURL)
        {
            #region
            string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
            #endregion
        }

        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="value">-1/1</param>
        public static void GoHistory(int value)
        {
            #region
            string js = @"<Script language='JavaScript'>
                    history.go({0});  
                  </Script>";
            HttpContext.Current.Response.Write(string.Format(js, value));
            #endregion
        }

        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        public static void CloseWindow()
        {
            #region
            string js = @"<Script language='JavaScript'>
                    parent.opener=null;window.close();  
                  </Script>";
            HttpContext.Current.Response.Write(js);
            HttpContext.Current.Response.End();
            #endregion
        }

        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void RefreshParent(string url)
        {
            #region
            string js = @"<Script language='JavaScript'>
                    window.opener.location.href='" + url + "';window.close();</Script>";
            HttpContext.Current.Response.Write(js);
            #endregion
        }


        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        public static void RefreshOpener()
        {
            #region
            string js = @"<Script language='JavaScript'>
                    opener.location.reload();
                  </Script>";
            HttpContext.Current.Response.Write(js);
            #endregion
        }


        /// <summary>
        /// 打开指定大小的新窗体
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="top">头位置</param>
        /// <param name="left">左位置</param>
        public static void OpenWebFormSize(string url, int width, int heigth, int top, int left)
        {
            #region
            string js = @"<Script language='JavaScript'>window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>";

            HttpContext.Current.Response.Write(js);
            #endregion
        }


        /// <summary>
        /// 转向Url制定的页面
        /// </summary>
        /// <param name="url">连接地址</param>
        public static void JavaScriptLocationHref(string url)
        {
            #region
            string js = @"<Script language='JavaScript'>
                    window.location.replace('{0}');
                  </Script>";
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
            #endregion
        }

        /// <summary>
        /// 打开指定大小位置的模式对话框
        /// </summary>
        /// <param name="webFormUrl">连接地址</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="top">距离上位置</param>
        /// <param name="left">距离左位置</param>
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            #region
            string features = "dialogWidth:" + width.ToString() + "px"
                + ";dialogHeight:" + height.ToString() + "px"
                + ";dialogLeft:" + left.ToString() + "px"
                + ";dialogTop:" + top.ToString() + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
            ShowModalDialogWindow(webFormUrl, features);
            #endregion
        }

        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(js);
        }

        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            #region
            string js = @"<script language=javascript>							
							showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
            return js;
            #endregion
        }
        /// <summary> 
        /// 获取客户端查看控件的脚本 刷新保持原位
        /// </summary> 
        /// <param name="controlName"></param> 
        /// <returns>脚本代码</returns> 
        public static string GetViewControlScript(string controlName)
        {

            //创建客户端函数ViewObj 
            string script = "\n";
            script += "<script language=\"javascript\">\n";
            script += "function ViewObj(objName)\n";
            script += "{\n";
            script += "var obj = document.all.item(objName);\n";
            script += "if (obj != null)\n";
            script += "{\n";
            script += "\tobj.scrollIntoView();\n";
            script += "\tobj.focus();\n";
            script += "}\n";
            script += "}\n";

            //创建客户端函数ToDo 
            script += "function ToDo()";
            script += "{\n";
            script += string.Format("setTimeout(\"ViewObj('{0}')\",1000);\n", controlName);
            script += "}\n";

            script += "window.onload = ToDo;\n";
            script += "</script>\n";

            return script;
        }

    }
}