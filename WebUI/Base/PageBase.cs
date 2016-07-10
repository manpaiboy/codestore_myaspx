using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyAspx.Framework.Common;
using System.Web.UI.HtmlControls;
using System.Threading;
namespace WebUI.Base
{
    public partial class PageBase : System.Web.UI.Page
    {
        public override void OnLoad(EventArgs e)
        {
            //HtmlGenericControl js = new HtmlGenericControl("script");
            //js.Attributes["type"] = "text/javascript";
            //js.Attributes["src"] = "../Scripts/layer/layer.js";
            //Page.Header.Controls.Add(js);
            base.OnLoad(e);
            if(Session["CheckCode"] == null)
            {
                MessageBox.LayerShow(this, "登录过期，跳转到登录页面！");
                Thread.Sleep(1800);
                Response.Redirect("../login.aspx");
            }
        }
    }
}