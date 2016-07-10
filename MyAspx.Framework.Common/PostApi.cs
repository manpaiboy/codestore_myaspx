using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace MyAspx.Framework.Common
{
    public class PostApi
    {
        public static string RequestPost(string postData, string uriStr, string action)
        {
            HttpWebRequest requestScore = (HttpWebRequest)WebRequest.Create(uriStr);
            StringBuilder postContent = new StringBuilder();
            Encoding myEncoding = Encoding.GetEncoding("gb2312");
            postContent.Append(HttpUtility.UrlEncode("message", myEncoding));
            postContent.Append("=");
            postContent.Append(HttpUtility.UrlEncode(postData, myEncoding));
            postContent.Append("&");
            postContent.Append(HttpUtility.UrlEncode("type", myEncoding));
            postContent.Append("=");
            postContent.Append(HttpUtility.UrlEncode("sync", myEncoding));
            postContent.Append("&");
            postContent.Append(HttpUtility.UrlEncode("action", myEncoding));
            postContent.Append("=");
            postContent.Append(HttpUtility.UrlEncode(action, myEncoding));


            byte[] data = Encoding.ASCII.GetBytes(postContent.ToString());
            requestScore.Method = "Post";
            requestScore.ContentType = "application/x-www-form-urlencoded;charset=utf8";
            requestScore.ContentLength = data.Length;
            requestScore.KeepAlive = true;
            Stream stream = requestScore.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            HttpWebResponse responseSorce;
            try
            {
                responseSorce = (HttpWebResponse)requestScore.GetResponse();
            }
            catch (WebException ex)
            {
                responseSorce = (HttpWebResponse)ex.Response;//得到请求网站的详细错误提示
            }
            StreamReader reader = new StreamReader(responseSorce.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            requestScore.Abort();
            responseSorce.Close();
            responseSorce.Close();
            reader.Dispose();
            stream.Dispose();
            return content;
        }
        // MyAspx.com 提供类
    }
}