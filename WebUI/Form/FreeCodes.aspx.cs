using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyAspx.EasyFramework.DAL;

namespace WebUI.Form
{
    public partial class FreeCodes : System.Web.UI.Page
    {
        DBAccess db = new DBAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { BindGrid(); }
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

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
        public void BindGrid()
        {
            AspNetPager1.RecordCount = Int32.Parse(db.GetAllCount("my_fileinfo").ToString());
            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            int pageSize = AspNetPager1.PageSize = 20;
            RepeaterCodeLists.DataSource = db.GetCurrentPage(pageIndex, pageSize,"my_fileinfo","addtime");
            RepeaterCodeLists.DataBind();
        }
    }
}
