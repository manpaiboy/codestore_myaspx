using MyAspx.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI.HtmlControls;

namespace WebUI.Admin.UI
{
    public class AdminPageBase : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            //<link rel="stylesheet" type="text/css" href="../../themes/default/easyui.css">
            //<link rel="stylesheet" type="text/css" href="../../themes/icon.css">
            //<link rel="stylesheet" type="text/css" href="../demo.css">
            //<script type="text/javascript" src="../../jquery.min.js"></script>
            //<script type="text/javascript" src="../../jquery.easyui.min.js"></script>
            
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
            base.OnLoad(e);
            if (Session["myaspxadminuser"] == null)
            {
                MessageBox.Show(this, "登录过期，跳转到登录页面！");
                Thread.Sleep(1800);
                Response.Redirect("~/login.aspx");
            }
        }
    }
}