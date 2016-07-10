using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyAspx.Framework.Common;
using System.Web.UI.HtmlControls;
using System.Threading;
namespace WebUI
{
    public class PageBase:System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            HtmlGenericControl jsJquery = new HtmlGenericControl("script");
            jsJquery.Attributes["type"] = "text/javascript";
            jsJquery.Attributes["src"] = "../../Scripts/jquery-2.2.3.js";
            Page.Header.Controls.Add(jsJquery);
            HtmlGenericControl jsLayer = new HtmlGenericControl("script");
            jsLayer.Attributes["type"] = "text/javascript";
            jsLayer.Attributes["src"] = "../../Scripts/layer/layer.js";
            Page.Header.Controls.Add(jsLayer);
            base.OnLoad(e);
            if (Session["myaspxadminuser"] == null)
            {
                MessageBox.Show(this, "登录过期，跳转到登录页面！");
                Thread.Sleep(1800);
                Response.Redirect("../../login.aspx");
            }
        }
    }
}
