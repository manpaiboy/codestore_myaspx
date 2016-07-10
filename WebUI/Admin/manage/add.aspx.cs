using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyAspx.EasyFramework;
using MyAspx.EasyFramework.EntityFramework;
using MyAspx.EasyFramework.DAL3;
using MyAspx.Framework.Common;
namespace WebUI.Admin.manage
{
    public partial class add : WebUI.PageBase
    {
        AdminDAL _admindal = new AdminDAL();
        // MessageBox mesBox = new MessageBox();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void AddAdmin(object sender,EventArgs e)
        {
           
            if (_admindal.HasEqualsAdminName(user.Value) == null)
            {
               if(_admindal.AddAdmin(new MyAspx.EasyFramework.EntityFramework.my_manage(){adminname = user.Value,adminpwd=pwd.Value})==1)
               {
                   MessageBox.LayerShow(this, "管理员添加成功！");
               
               }
            }
            else
                MessageBox.LayerShow(this, "管理员用户名重复，请重新填写！");
        }
    }
}