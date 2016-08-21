using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.Admin.service
{
    public partial class xhediterUpImgs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            savefile();
        }
        private void savefile()
        {
            Response.ClearHeaders();
            Response.Clear();
            Response.Expires = 0;
            Response.ClearContent();
            Data d = new Data();

            try
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[1];
                    string filename = file.FileName;
                    string fileNewName = DateTime.Now.ToString("yyyyMMddHHmmssff") + "_" + filename;
                    string path = Server.MapPath("Upfiles\\xheditorPics\\" + filename);
                    d.msg = "Upfiles/xheditorPics/" + filename;
                    file.SaveAs(path);
                }
            }
            catch (Exception e)
            {
                d.err = e.Message;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Response.Write(serializer.Serialize(d));
            Response.Flush();
            Response.End();
        }
    }
    public class Data
    {
        private string _err;
        private string _msg;
        public string err
        {
            get
            {
                if (_err == null)
                    return string.Empty;
                return _err;
            }
            set
            {
                _err = value;
            }
        }
        public string msg
        {
            get
            {
                if (_msg == null)
                    return string.Empty;
                return _msg;
            }
            set
            {
                _msg = value;
            }
        }
    }
}