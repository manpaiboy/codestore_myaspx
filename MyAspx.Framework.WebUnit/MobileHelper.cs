using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyAspx.Framework.WebUnit.Common
{
    public  class MobileHelper
    {
        //将字符串经过md5加密，返回加密后的字符串的小写表示
        public static string Md5Encrypt(string strToBeEncrypt)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] FromData = System.Text.Encoding.GetEncoding("utf-8").GetBytes(strToBeEncrypt);
            Byte[] TargetData = md5.ComputeHash(FromData);
            string Byte2String = "";
            for (int i = 0; i < TargetData.Length; i++)
            {
                Byte2String += TargetData[i].ToString("x2");
            }
            return Byte2String.ToLower();
        }
        public static bool SendMobilePost(string agentCode, string orderId, string mobileNo, int amount, string notifyUrl,string key,out string msg)
        {
            CookieContainer MyCookieContainer = new CookieContainer();
            bool bFlag = false;
            HttpHelper httphelper = new HttpHelper();
            string sendTime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            amount = amount * 1000;
            string paras = "agentCode=" + agentCode + "&orderId=" + orderId + "&mobileNo=" + mobileNo + "&amount=" + amount + "&sendTime=" + sendTime + "&notifyUrl=" + notifyUrl + "&key=" + key + "";
            string sign = Md5Encrypt(paras);
            HttpItem item = new HttpItem()
            {
                URL = "http://112.124.22.28/gateway/mobile/topup.htm",//URL   
                Method = "POST",//URL     可选项 默认为Get     
                CookieCollection = MyCookieContainer.GetCookies(new Uri("http://112.124.22.28/gateway/mobile/topup.htm")),//调用webBrowser1登陆的cookie   
                ContentType = "application/x-www-form-urlencoded",
                Postdata = "agentCode=" + agentCode + "&orderId=" + orderId + "&mobileNo=" + mobileNo + "&amount=" + amount + "&sendTime=" + sendTime + "&notifyUrl=" + notifyUrl + "&sign=" + sign + ""
            };


            HttpResult result = httphelper.GetHtml(item);
            string html3 = result.Html;
            msg = html3;
            if (html3.Contains("NOTICE RECEIVE SUCCESS") == true || html3.Contains("0000") == true || html3.Contains("2000") == true)
            {
                bFlag = true;
            }
            return bFlag;
        }
    }
}
