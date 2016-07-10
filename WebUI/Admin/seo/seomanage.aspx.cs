using MyAspx.EasyFramework.DAL3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUI.Admin.UI;

namespace WebUI.Admin.seo
{
    public partial class seomanage : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(true)]
        public static string AddSeoInfo(string sitetitle, string sitekeywords, string sitedescription, string siteremark)
        {
            SeoDAL _seodal = new SeoDAL();
            int resultAdd = _seodal.AddSeo(new MyAspx.EasyFramework.EntityFramework.my_siteconf() {
                sitetitle = sitetitle,
                sitekeywords = sitekeywords,
                sitedescription = sitedescription,
                sitewriter = HttpContext.Current.Session["myaspxadminuser"].ToString(),
                siteremark = siteremark,   
                siteaddtime = DateTime.Now
            });
            if (resultAdd == 1)
            {
                //Session["myaspxadminuser"] = _my_manage.adminname;
                //CookieParameter cookp = new CookieParameter();
                //cookp.CookieName = "myaspxadminuser";
                //cookp.
                //Response.Redirect("admin/index.aspx");
                return "scuess";
            }
            else
            {
                //Response.Write("<script>alert('用户名密码不对！')</script>");
                return "fail";
            }

        }
    }
}