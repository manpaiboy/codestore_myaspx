using MyAspx.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebUI.Admin.UI
{
    public partial class AdminUiBase : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //加载公共easyui的css
            HtmlLink CssGrayEasyui = new HtmlLink();
            CssGrayEasyui.Attributes["type"] = "text/css";
            CssGrayEasyui.Attributes["rel"] = "Stylesheet";
            CssGrayEasyui.Href = "../../Admin/UI/JQueryEasyUI/themes/gray/easyui.css";
            Page.Header.Controls.Add(CssGrayEasyui);
            HtmlLink CssGrayEasyuiExt = new HtmlLink();
            CssGrayEasyuiExt.Attributes["type"] = "text/css";
            CssGrayEasyuiExt.Attributes["rel"] = "Stylesheet";
            CssGrayEasyuiExt.Href = "../../Admin/UI/JQueryEasyUI/demo/demo.css";
            Page.Header.Controls.Add(CssGrayEasyuiExt);
            //加载公共easyui的js
            
            HtmlGenericControl jsJquery = new HtmlGenericControl("script");
            jsJquery.Attributes["type"] = "text/javascript";
            jsJquery.Attributes["src"] = "../../Admin/UI/JQueryEasyUI/jquery.min.js";
            Page.Header.Controls.Add(jsJquery);
            HtmlGenericControl jsEasyUI = new HtmlGenericControl("script");
            jsEasyUI.Attributes["type"] = "text/javascript";
            jsEasyUI.Attributes["src"] = "../../Admin/UI/JQueryEasyUI/jquery.easyui.min.js";
            Page.Header.Controls.Add(jsEasyUI);
            
            //base.OnLoad(e);
            if (Session["myaspxadminuser"] == null)
            {
                //MessageBox.Show(this, "登录过期，跳转到登录页面！");
                Thread.Sleep(1800);
                Response.Redirect("~/login.aspx");
            }
        }
    }
}