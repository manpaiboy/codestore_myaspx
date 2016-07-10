using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUI.Admin.UI;

namespace WebUI.Admin
{
    public partial class index :AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void exitLogin_Click(object sender, EventArgs e)
        {
            Session["CheckCode"] = null;
            Session["myaspxadminuser"] = null;
            Session.Clear();
            
        }
    }
}