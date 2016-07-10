using MyAspx.EasyFramework.DAL3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyAspx.Json;
namespace WebUI.Admin.service
{
    /// <summary>
    /// seo 的摘要说明
    /// </summary>
    public class seo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            SeoDAL _seodal = new SeoDAL();
            //JsonArray _ja = new JsonArray();
            string _ja=_seodal.GetJsonSeoIntoString();
            //if (_ja != "")
            //{
            //    context.Response.Write("{\"total\":16,\"rows\":"+_ja+"}");
               
            //} 
            //context.Response.End();
            context.Response.Clear();
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.ContentType = "application/json";
            context.Response.Write(_ja);
            context.Response.Flush();
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