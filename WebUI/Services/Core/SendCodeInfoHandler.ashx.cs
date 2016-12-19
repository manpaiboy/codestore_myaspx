using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using MyAspx.EasyFramework.DAL3;
using MyAspx.EasyFramework.EntityFramework;

namespace WebUI.Services.Core
{
    /// <summary>
    /// 无刷新上传源码的一般处理程序
    /// </summary>
    public class SendCodeInfoHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        FileInfoDAL _fileInfoDal = new FileInfoDAL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //主要处理逻辑
            var result = new []
            {
                //源码名称 0
                context.Request.Form["name"],            //1
                //源码的价格 1
                context.Request.Form["paynub"],       
                //源码下载的服务端地址 2
                context.Request.Form["codeserverurl"],    
                //源码图片集合 3
                context.Request.Form["codepics"],        //1
                //源码的类别 4
                context.Request.Form["codetype"],        
                //源码开发工具 5
                context.Request.Form["developtool"],      //1
                //源码的编程语言 6
                context.Request.Form["language"],        //1
                //源码使用的数据库 7
                context.Request.Form["database"],        //1
                //源码的.NET 框架 8
                context.Request.Form["framework"],        //1
                //源码标签 9
                context.Request.Form["tags"],            
                //源码外连接地址 10
                context.Request.Form["linkurl"],          
                //源码作者 11
                context.Request.Form["author"],           //1
                //源码作者联系方式 12
                context.Request.Form["contract"],        //1
                //源码的作者留言 13
                context.Request.Form["usermsg"],        
                //源码详细描述 14
                context.Request.Form["preview"]          //1

            };
            //源码基础详细入库
            int exec = _fileInfoDal.AddNewCodeBaseInfo(new my_fileinfo()
            {
                filename = result[0],
                filedatabase = result[7],
                filedevlan = result[6],
                filevstype = result[5],
                filepics = result[3],
                codedes = result[14],
                codelang = result[6],
                contract = result[12],
                createuser = result[11],
                codeplftype = result[5],
                devtool = result[5],
                frameworkversion = result[8],
              }); 
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