using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Security;
using System.Security.Cryptography;
namespace MyAspx.Framework.WebUnit.Common
{
    /// <summary>
    /// Helper 的摘要说明
    /// </summary>
    public class BFPayHelper
    {
        public BFPayHelper()
        {
        }
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


        /// <summary>
        /// 通过两个状态获取订单结果的中文描述
        /// </summary>
        /// <param name="result"></param>
        /// <param name="resultDesc"></param>
        /// <returns></returns>
        public static string GetErrorInfo(string result, string resultDesc)
        {
            string retInfo = "";
            if (result == "1")
                return "支付成功";
            else
            {
                switch (resultDesc)
                {
                    case "0000":
                        retInfo = "充值失败";
                        break;
                    case "0001":
                        retInfo = "系统错误";
                        break;
                    case "0002":
                        retInfo = "订单超时";
                        break;
                    case "0003":
                        retInfo = "订单状态异常";
                        break;
                    case "0004":
                        retInfo = "无效商户";
                        break;
                    case "0015":
                        retInfo = "卡号或卡密错误";
                        break;
                    case "0016":
                        retInfo = "不合法的IP地址";
                        break;
                    case "0018":
                        retInfo = "卡密已被使用";
                        break;
                    case "0019":
                        retInfo = "订单金额错误";
                        break;
                    case "0020":
                        retInfo = "支付的类型错误";
                        break;
                    case "0021":
                        retInfo = "卡类型有误";
                        break;
                    case "0022":
                        retInfo = "卡信息不完整";
                        break;
                    case "0023":
                        retInfo = "卡号，卡密，金额不正确";
                        break;
                    case "0024":
                        retInfo = "不能用此卡继续做交易";
                        break;
                    case "0025":
                        retInfo = "订单无效";
                        break;
                    default:
                        retInfo = "支付失败";
                        break;
                }
                return retInfo;
            }
        }
        public static bool GetOrderStatus(string MemberID, string TerminalID, string TransID, string md5key)
        {
            bool bFlag = false;
            string Md5Sign = Md5Encrypt(MemberID + "|" + TerminalID + "|" + TransID + "|" + md5key);

            string Postdata = "MemberID=" + MemberID + "&TerminalID=" + TerminalID + "&TransID=" + TransID + "&Md5Sign=" + Md5Sign + "";
            HttpHelper httphelper = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://gw.baofoo.com/order/query",//URL   
                Method = "POST",//URL     可选项 默认为Get      
                ContentType = "application/x-www-form-urlencoded",
                Postdata = Postdata
            };
            HttpResult result = httphelper.GetHtml(item);
            string html3 = result.Html;
            string[] sids = html3.Split('|');//MemberID|TerminalID|TransID|CheckResult|factMoney|SuccTime|Md5Sign
            MemberID = sids[0];
            TerminalID = sids[1];
            TransID = sids[2];
            string CheckResult = sids[3];
            string succMoney = sids[4];
            string SuccTime = sids[5];
            Md5Sign = sids[6];

            string Md5SignVail = Md5Encrypt(MemberID + "|" + TerminalID + "|" + TransID + "|" + CheckResult + "|" + succMoney + "|" + SuccTime + "|" + md5key);
            if (Md5Sign.ToLower() == Md5SignVail.ToLower())
            {
                if (CheckResult == "Y")
                {
                    bFlag = true;
                }
            }
            return bFlag;
        }
    }
}