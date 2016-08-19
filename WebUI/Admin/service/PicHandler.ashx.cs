using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebUI.Admin.service
{
    /// <summary>
    /// PicHandler 的摘要说明
    /// </summary>
    public class PicHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
                fileNewName = DateTime.Now.ToString("yyyyMMddHHmmssff") + "_" + System.IO.Path.GetFileName(files[1].FileName);
                //保存文件
                if (!Directory.Exists(context.Server.MapPath("~/Upfiles/CodePics/" + context.Session["myaspxadminuser"])))
                {
                    Directory.CreateDirectory(context.Server.MapPath("~/Upfiles/CodePics/" + context.Session["myaspxadminuser"]));
                }
                files[1].SaveAs(context.Server.MapPath("~/Upfiles/CodePics/" + context.Session["myaspxadminuser"] + "/" + fileNewName));
                msg = "源码图片上传成功！";
                result = "~/Upfiles/CodePics/" + context.Session["myaspxadminuser"] + "/" + fileNewName;
            }
            else
            {
                error = "文件上传失败！";
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