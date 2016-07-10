using MyAspx.EasyFramework.DAL3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Session["CheckCode"] != null)
            //        yzmhiddle.Value = Session["CheckCode"].ToString();
            //}
        }
        protected void loginClick(object sender, EventArgs e)
        {
            string yzmstr = Session["CheckCode"] == null ? "" : Session["CheckCode"].ToString();
            if (yzm.Value != yzmstr)
            {
                //Response.Write("<script>layer.alert('验证码不对！')</script>");
                //return "验证码不对！";
                Page.RegisterClientScriptBlock("alertnewmes", "<script>layer.alert('验证码错误!')</script>");
                return;
            }
            AdminDAL _admindal = new AdminDAL();
            MyAspx.EasyFramework.EntityFramework.my_manage _my_manage = new MyAspx.EasyFramework.EntityFramework.my_manage();
            _my_manage.adminname = user.Value;
            _my_manage.adminpwd = pwd.Value;
            if (_admindal.ValidateAdmin(_my_manage) == "find")
            {
                Session["myaspxadminuser"] = _my_manage.adminname;
                CookieParameter cookp = new CookieParameter();
                cookp.CookieName = "myaspxadminuser";
                //cookp.
                Response.Redirect("admin/index.aspx");
                //return "admin/index.aspx";
            }
            else
            {
                //Response.Write("<script>layer.alert('用户名密码不对！')</script>");
                Page.RegisterClientScriptBlock("alertnewmesuser", "<script>layer.alert('用户名密码不对！')</script>");
                //return ;
            }
        }

       [WebMethod(true)]
        public static string LoginAdmin(string user,string pwd)
        {
            //string yzmstr = Session["CheckCode"].ToString();
            //if (yzm.Value != yzmstr)
            //{
            //    //Response.Write("<script>alert('验证码不对！')</script>");
            //    return "验证码不对！";
            //}
            AdminDAL _admindal = new AdminDAL();
            MyAspx.EasyFramework.EntityFramework.my_manage _my_manage = new MyAspx.EasyFramework.EntityFramework.my_manage();
            _my_manage.adminname = user;
            _my_manage.adminpwd = pwd;
            if(_admindal.ValidateAdmin(_my_manage)=="find")
            {
                //Session["myaspxadminuser"] = _my_manage.adminname;
                //CookieParameter cookp = new CookieParameter();
                //cookp.CookieName = "myaspxadminuser";
                //cookp.
                //Response.Redirect("admin/index.aspx");
                return "admin/index.aspx";
            }
            else
            {
                //Response.Write("<script>alert('用户名密码不对！')</script>");
                return "用户名密码不对！";
            }

        }

       protected void yzmbtnhiddle_Click(object sender, EventArgs e)
       {
         if (Session["CheckCode"] != null){
            string yzmvalue= Session["CheckCode"].ToString();
         if(  yzm.Value != yzmvalue)
         {
             Page.RegisterClientScriptBlock("alertnewmes", "layer.alert('验证码错误!')");
         }
         }
       }
    }
}