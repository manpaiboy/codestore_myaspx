using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace HttpHelpers
{
    /// <summary>
    /// 模仿http客户端
    /// </summary>
    public class MyHttpClient
    {
        /// <summary>
        /// Cookie
        /// </summary>
        private CookieContainer Cookie;

        /// <summary>
        /// 目标url
        /// </summary>
        private string Url;

        /// <summary>
        /// post数据
        /// </summary>
        private MyPostData PostData;

        public CookieContainer cookie
        {
            get { return Cookie; }
            set { Cookie = value; }
        }

        public string url
        {
            get { return Url; }
            set { Url = value; }
        }

        public MyPostData postdata
        {
            get { return PostData; }
            set { PostData = value; }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            /*初始化cookie*/
            Cookie = new CookieContainer();
            url = "";
            PostData = new MyPostData();
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="Url">目标url</param>
        /// <param name="postDataStr">post数据</param>
        /// <param name="cookie">cookie</param>
        /// <returns></returns>
        /// 
        private string SendDataByPost(string Url, string postDataStr, ref CookieContainer cookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataStr.Length;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        private string SendDataByGet(string Url, string DataStr, ref CookieContainer cookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + "?" + DataStr);
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            //myStreamReader.Close();
            //myResponseStream.Close();
            return retString;
        }

        public string Post()
        {
            string ret = "";
            try
            {
                ret = SendDataByPost(Url, PostData.ToString(), ref Cookie); ;
            }
            catch (Exception ex)
            {

            }
            return ret;
        }
        public string Get()
        {
            string ret = "";
            try
            {
                ret = SendDataByGet(Url, PostData.ToString(), ref Cookie);
            }
            catch (Exception ex)
            {

            }
            return ret;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public MyHttpClient()
        {
            Init();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pd">Post参数</param>
        public MyHttpClient(MyPostData pd)
        {
            Init();
            PostData = pd;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">目标url</param>
        public MyHttpClient(string url)
        {
            Init();
            this.url = url;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pd">Post参数</param>
        /// <param name="url">目标url</param>
        public MyHttpClient(MyPostData pd, string url)
        {
            Init();
            PostData = pd;
            this.url = url;
        }


    }

    /// <summary>
    /// post数据
    /// </summary>
    public class MyPostData
    {
        private Dictionary<string, string> PostData;
        public MyPostData()
        {
            PostData = new Dictionary<string, string>();
        }
        public string this[string index]
        {
            get
            {
                /*判断key是否存在*/
                if (PostData.ContainsKey(index))
                {
                    return PostData[index];
                }
                else
                {
                    return "";
                }

            }
            set
            {
                /*判断key是否存在*/
                if (PostData.ContainsKey(index))
                {
                    PostData[index] = value;
                }
                else
                {
                    PostData.Add(index, value);
                }
            }
        }
        public override string ToString()
        {
            string ret = "";
            int index = 0;
            foreach (KeyValuePair<string, string> item in PostData)
            {
                if (index != 0)
                {
                    ret += "&";
                }
                ret += item.Key;
                ret += "=";
                ret += item.Value;
                index++;
            }
            return ret;
        }
    }
}