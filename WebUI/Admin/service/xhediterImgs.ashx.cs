using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebUI.Admin.service
{
    /// <summary>
    /// xhediterImgs 的摘要说明
    /// </summary>
    public class xhediterImgs : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = string.Empty;
            string error = string.Empty;
            string result = string.Empty;
            string filePath = string.Empty;
            string fileNewName = string.Empty;
            //这里只能用<input type="file" />才能有效果,因为服务器控件是HttpInputFile类型
            HttpFileCollection files = context.Request.Files;
            if (files.Count > 0)
            {
                //设置文件名
                fileNewName = DateTime.Now.ToString("yyyyMMddHHmmssff") + "_" + System.IO.Path.GetFileName(files[2].FileName);
                files[2].SaveAs(context.Server.MapPath("~/Upfiles/xheditorPics" + "/" + fileNewName));
                msg = "图片上传成功！";
                result = "~/Upfiles/xheditorPics"  + "/" + fileNewName;
            }
            else
            {
                error = "图片上传失败！";
                result = "{ error:'" + error + "'}";
            }
            context.Response.Write(result);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}