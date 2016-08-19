using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace WebUI.Admin.service
{
    /// <summary>
    /// FileHandler 的摘要说明
    /// </summary>
    public class FileHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
                fileNewName = DateTime.Now.ToString("yyyyMMddHHmmssff") + "_" + System.IO.Path.GetFileName(files[0].FileName);
                //保存文件
                if (!Directory.Exists(context.Server.MapPath("~/Upfiles/CodeFiles/" + context.Session["myaspxadminuser"])))
                {
                    Directory.CreateDirectory(context.Server.MapPath("~/Upfiles/CodeFiles/" + context.Session["myaspxadminuser"]));
                }
                files[0].SaveAs(context.Server.MapPath("~/Upfiles/CodeFiles/" + context.Session["myaspxadminuser"] + "/" + fileNewName));
                msg = "文件上传成功！";
                result = "~/Upfiles/CodeFiles/" + context.Session["myaspxadminuser"] + "/" + fileNewName;
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