using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.Form
{
    public partial class FreeCodes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public string ImgUrl(string imgs)
        {
            //<br>~/Upfiles/CodePics/admin/2017012318362093_india  flag orb.bmp<br>~/Upfiles/CodePics/admin/2017012318362301_110255_230124ef_355590.png
            string[] imgArray = imgs.Split('>');
            string firImg = imgs[0].ToString();
            firImg = firImg.Replace("<br", "");
            return Server.MapPath(firImg);
        }

        protected void RepeaterCodeLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
             
        }
    }
}
