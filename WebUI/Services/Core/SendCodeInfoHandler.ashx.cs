using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Services.Core
{
    /// <summary>
    /// 无刷新上传源码的一般处理程序
    /// </summary>
    public class SendCodeInfoHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //主要处理逻辑
            
            //结束
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