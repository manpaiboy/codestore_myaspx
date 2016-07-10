using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyAspx.Framework.WebUnit.Common
{
    /// <summary>
    /// Cookie类
    /// </summary>
    public class CookieHelper
    {
        #region 写Cookie
        /// <summary>
        /// 写Cookie值
        /// </summary>
        /// <param name="strName">对象名称</param>
        /// <param name="strValue">对象值</param>
        public static void Set(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = CookieEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写Cookie值
        /// </summary>
        /// <param name="strName">对象名称</param>
        /// <param name="key">对象Key</param>
        /// <param name="strValue">对象值</param>
        public static void Set(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = CookieEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写Cookie值
        /// </summary>
        /// <param name="strName">对象名称</param>
        /// <param name="strValue">对象值</param>
        /// <param name="iexpires">有效值(0和负数无效,1表示永久有效)</param>
        public static void Set(string strName, string strValue, int iexpires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = CookieEncode(strValue);
            if (iexpires > 0)
            {
                if (iexpires == 1)
                    cookie.Expires = DateTime.MaxValue;
                else
                    cookie.Expires = DateTime.Now.AddSeconds(iexpires);
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写Cookie值
        /// </summary>
        /// <param name="strName">对象名称</param>
        /// <param name="key">对象Key</param>
        /// <param name="strValue">对象值</param>
        /// <param name="iexpires">有效值(0和负数无效,1表示永久有效)</param>
        public static void Set(string strName, string key, string strValue, int iexpires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = CookieEncode(strValue);
            if (iexpires > 0)
            {
                if (iexpires == 1)
                    cookie.Expires = DateTime.MaxValue;
                else
                    cookie.Expires = DateTime.Now.AddSeconds(iexpires);
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        #endregion

        #region 读Cookie
        /// <summary>
        /// 读Cookie值
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static string Get(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName].Value != null && HttpContext.Current.Request.Cookies[strName].Value != "")
                return CookieDecode(HttpContext.Current.Request.Cookies[strName].Value.ToString());
            return "";
        }

        /// <summary>
        /// 读Cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strKey">key值</param>
        /// <returns></returns>
        public static string GetCookie(string strName, string strKey)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][strKey] != null && HttpContext.Current.Request.Cookies[strName][strKey] != "")
                return CookieDecode(HttpContext.Current.Request.Cookies[strName][strKey].ToString());
            return "";
        }
        #endregion

        #region 删Cookie
        /// <summary>
        /// 删Cookie
        /// </summary>
        /// <param name="strName">对象名称</param>
        public static void Dele(string strName)
        {
            HttpCookie cookie = new HttpCookie(strName.Trim());
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-5);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// 删Cookie
        /// </summary>
        /// <param name="strName">对象名称</param>
        /// <param name="strValue">对象值</param>
        /// <param name="iexpires">有效值(0和负数无效,1表示永久有效)</param>
        /// <returns></returns>
        public static bool Dele(string strName, string strValue, int iexpires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                return false;
            }
            cookie.Values.Remove(strValue);
            if (iexpires > 0)
            {
                if (iexpires == 1)
                    cookie.Expires = DateTime.MaxValue;
                else
                    cookie.Expires = DateTime.Now.AddSeconds(iexpires);
            }
            HttpContext.Current.Response.AppendCookie(cookie);
            return true;
        }
        #endregion

        #region URL处理
        /// <summary>
        /// URL字符编码
        /// </summary>
        public static string UrlEncode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            str = str.Replace("'", "");
            return HttpContext.Current.Server.UrlEncode(str);
        }

        /// <summary>
        /// URL字符解码
        /// </summary>
        public static string UrlDecode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            return HttpContext.Current.Server.UrlDecode(str);
        }
        #endregion

        #region Cookie加密/解密
        /// <summary>
        /// Cookie加密
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string CookieEncode(string message)
        {
            SBase64 sbase = new SBase64();
            return sbase.Encode(message);
        }

        /// <summary>
        /// Cookie解密
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string CookieDecode(string message)
        {
            SBase64 sbase = new SBase64();
            return sbase.Decode(message);
        }
        #endregion
    }
    public class SBase64
    {
        /// <summary>
        /// 转换表
        /// </summary>
        string Base64CodeString = "HIOPQKvGLRST9+FAUE7uwxWoXYMraBbz01VDJe6ypCNnsZtklfcdghiq8jm3452/=";
        private const string PUBLICKEY = "winintech";

        char[] Base64CodeChar
        {
            get
            {
                return Base64CodeString.ToCharArray();
            }
        }
        /// <summary>
        /// 混淆Base64CodeString
        /// </summary>
        void Confusion(string md5)
        {
            List<string> listString = new List<string>();
            foreach (char eachString in md5.ToCharArray())//排除重复
            {
                if (!listString.Contains(eachString.ToString()))
                    listString.Add(eachString.ToString());
            }
            foreach (string eachString in listString)
            {
                Base64CodeString = eachString + Base64CodeString.Remove(Base64CodeString.IndexOf(eachString), 1);
            }
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="Message">加密的信息</param>
        /// <param name="userkey">这里建议每一个帐号有一个独立的userKey，这个KEY可以用GUid的MD5做位值</param>
        /// <param name="userkey">每个帐号有同的userkey，这样每个帐号的转换表也会不同</param>
        /// <returns></returns>
        public string Encode(string Message, string userkey)
        {
            Confusion(userkey);//混淆Base64CodeString  如果需要降低安全性，提高性能可以屏蔽这句

            var ss = Base64CodeString.Length;
            byte empty = (byte)0;
            System.Collections.ArrayList byteMessage = new System.Collections.ArrayList(System.Text.Encoding.Default.GetBytes(Message));
            System.Text.StringBuilder outmessage;
            int messageLen = byteMessage.Count;
            //将字符分成3个字节一组，如果不足，则以0补齐
            int page = messageLen / 3;
            int use = 0;
            if ((use = messageLen % 3) > 0)
            {
                for (int i = 0; i < 3 - use; i++)
                    byteMessage.Add(empty);
                page++;
            }
            //将3个字节的每组字符转换成4个字节一组的。3个一组，一组一组变成4个字节一组
            //方法是：转换成ASCII码，按顺序排列24 位数据，再把这24位数据分成4组，即每组6位。再在每组的的最高位前补两个0凑足一个字节。
            outmessage = new System.Text.StringBuilder(page * 4);
            for (int i = 0; i < page; i++)
            {
                //取一组3个字节的组
                byte[] instr = new byte[3];
                instr[0] = (byte)byteMessage[i * 3];
                instr[1] = (byte)byteMessage[i * 3 + 1];
                instr[2] = (byte)byteMessage[i * 3 + 2];
                //六个位为一组，补0变成4个字节
                int[] outstr = new int[4];
                //第一个输出字节：取第一输入字节的前6位，并且在高位补0，使其变成8位（一个字节）
                outstr[0] = instr[0] >> 2;
                //第二个输出字节：取第一输入字节的后2位和第二个输入字节的前4位（共6位），并且在高位补0，使其变成8位（一个字节）
                outstr[1] = ((instr[0] & 0x03) << 4) ^ (instr[1] >> 4);
                //第三个输出字节：取第二输入字节的后4位和第三个输入字节的前2位（共6位），并且在高位补0，使其变成8位（一个字节）
                if (!instr[1].Equals(empty))
                    outstr[2] = ((instr[1] & 0x0f) << 2) ^ (instr[2] >> 6);
                else
                    outstr[2] = 64;
                //第四个输出字节：取第三输入字节的后6位，并且在高位补0，使其变成8位（一个字节）
                if (!instr[2].Equals(empty))
                    outstr[3] = (instr[2] & 0x3f);
                else
                    outstr[3] = 64;
                outmessage.Append(Base64CodeChar[outstr[0]]);
                outmessage.Append(Base64CodeChar[outstr[1]]);
                outmessage.Append(Base64CodeChar[outstr[2]]);
                outmessage.Append(Base64CodeChar[outstr[3]]);
            }
            return outmessage.ToString();
        }
        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="userkey">必须和加密的UserKey相同</param>
        /// <returns></returns>
        public string Decode(string Message, string userkey)
        {
            Confusion(userkey);//混淆Base64CodeString  如果需要降低安全性，提高性能可以屏蔽这句
            if ((Message.Length % 4) != 0 || Message.Length == 0)
            {
                return Message;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(Message, "^[A-Z0-9/+=]*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                return Message;
            }
            string Base64Code = Base64CodeString;
            int page = Message.Length / 4;
            System.Collections.ArrayList outMessage = new System.Collections.ArrayList(page * 3);
            char[] message = Message.ToCharArray();
            for (int i = 0; i < page; i++)
            {
                byte[] instr = new byte[4];
                instr[0] = (byte)Base64Code.IndexOf(message[i * 4]);
                instr[1] = (byte)Base64Code.IndexOf(message[i * 4 + 1]);
                instr[2] = (byte)Base64Code.IndexOf(message[i * 4 + 2]);
                instr[3] = (byte)Base64Code.IndexOf(message[i * 4 + 3]);
                byte[] outstr = new byte[3];
                outstr[0] = (byte)((instr[0] << 2) ^ ((instr[1] & 0x30) >> 4));
                if (instr[2] != 64)
                {
                    outstr[1] = (byte)((instr[1] << 4) ^ ((instr[2] & 0x3c) >> 2));
                }
                else
                {
                    outstr[2] = 0;
                }
                if (instr[3] != 64)
                {
                    outstr[2] = (byte)((instr[2] << 6) ^ instr[3]);
                }
                else
                {
                    outstr[2] = 0;
                }
                outMessage.Add(outstr[0]);
                if (outstr[1] != 0)
                    outMessage.Add(outstr[1]);
                if (outstr[2] != 0)
                    outMessage.Add(outstr[2]);
            }
            byte[] outbyte = (byte[])outMessage.ToArray(Type.GetType("System.Byte"));
            return System.Text.Encoding.Default.GetString(outbyte);
        }

        public string GetMD5(string strPwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);//将字符编码为一个字节序列 
            byte[] md5data = md5.ComputeHash(data);//计算data字节数组的哈希值 
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5data.Length - 1; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');
            }
            return str;
        }

        public string GetUserKey(Guid guid)
        {
            return guid.ToString().Substring(0, 8);
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="Message">加密的信息</param>
        /// <returns></returns>
        public string Encode(string Message)
        {
            if (string.IsNullOrEmpty(Message))
            {
                return "";
            }
            string userkey = PUBLICKEY;
            Confusion(userkey);//混淆Base64CodeString  如果需要降低安全性，提高性能可以屏蔽这句

            var ss = Base64CodeString.Length;
            byte empty = (byte)0;
            System.Collections.ArrayList byteMessage = new System.Collections.ArrayList(System.Text.Encoding.Default.GetBytes(Message));
            System.Text.StringBuilder outmessage;
            int messageLen = byteMessage.Count;
            //将字符分成3个字节一组，如果不足，则以0补齐
            int page = messageLen / 3;
            int use = 0;
            if ((use = messageLen % 3) > 0)
            {
                for (int i = 0; i < 3 - use; i++)
                    byteMessage.Add(empty);
                page++;
            }
            //将3个字节的每组字符转换成4个字节一组的。3个一组，一组一组变成4个字节一组
            //方法是：转换成ASCII码，按顺序排列24 位数据，再把这24位数据分成4组，即每组6位。再在每组的的最高位前补两个0凑足一个字节。
            outmessage = new System.Text.StringBuilder(page * 4);
            for (int i = 0; i < page; i++)
            {
                //取一组3个字节的组
                byte[] instr = new byte[3];
                instr[0] = (byte)byteMessage[i * 3];
                instr[1] = (byte)byteMessage[i * 3 + 1];
                instr[2] = (byte)byteMessage[i * 3 + 2];
                //六个位为一组，补0变成4个字节
                int[] outstr = new int[4];
                //第一个输出字节：取第一输入字节的前6位，并且在高位补0，使其变成8位（一个字节）
                outstr[0] = instr[0] >> 2;
                //第二个输出字节：取第一输入字节的后2位和第二个输入字节的前4位（共6位），并且在高位补0，使其变成8位（一个字节）
                outstr[1] = ((instr[0] & 0x03) << 4) ^ (instr[1] >> 4);
                //第三个输出字节：取第二输入字节的后4位和第三个输入字节的前2位（共6位），并且在高位补0，使其变成8位（一个字节）
                if (!instr[1].Equals(empty))
                    outstr[2] = ((instr[1] & 0x0f) << 2) ^ (instr[2] >> 6);
                else
                    outstr[2] = 64;
                //第四个输出字节：取第三输入字节的后6位，并且在高位补0，使其变成8位（一个字节）
                if (!instr[2].Equals(empty))
                    outstr[3] = (instr[2] & 0x3f);
                else
                    outstr[3] = 64;
                outmessage.Append(Base64CodeChar[outstr[0]]);
                outmessage.Append(Base64CodeChar[outstr[1]]);
                outmessage.Append(Base64CodeChar[outstr[2]]);
                outmessage.Append(Base64CodeChar[outstr[3]]);
            }
            return outmessage.ToString();
        }
        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public string Decode(string Message)
        {
            if (string.IsNullOrEmpty(Message))
            {
                return "";
            }
            string userkey = PUBLICKEY;
            Confusion(userkey);//混淆Base64CodeString  如果需要降低安全性，提高性能可以屏蔽这句
            if ((Message.Length % 4) != 0 || Message.Length == 0)
            {
                return Message;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(Message, "^[A-Z0-9/+=]*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                return Message;
            }
            string Base64Code = Base64CodeString;
            int page = Message.Length / 4;
            System.Collections.ArrayList outMessage = new System.Collections.ArrayList(page * 3);
            char[] message = Message.ToCharArray();
            for (int i = 0; i < page; i++)
            {
                byte[] instr = new byte[4];
                instr[0] = (byte)Base64Code.IndexOf(message[i * 4]);
                instr[1] = (byte)Base64Code.IndexOf(message[i * 4 + 1]);
                instr[2] = (byte)Base64Code.IndexOf(message[i * 4 + 2]);
                instr[3] = (byte)Base64Code.IndexOf(message[i * 4 + 3]);
                byte[] outstr = new byte[3];
                outstr[0] = (byte)((instr[0] << 2) ^ ((instr[1] & 0x30) >> 4));
                if (instr[2] != 64)
                {
                    outstr[1] = (byte)((instr[1] << 4) ^ ((instr[2] & 0x3c) >> 2));
                }
                else
                {
                    outstr[2] = 0;
                }
                if (instr[3] != 64)
                {
                    outstr[2] = (byte)((instr[2] << 6) ^ instr[3]);
                }
                else
                {
                    outstr[2] = 0;
                }
                outMessage.Add(outstr[0]);
                if (outstr[1] != 0)
                    outMessage.Add(outstr[1]);
                if (outstr[2] != 0)
                    outMessage.Add(outstr[2]);
            }
            byte[] outbyte = (byte[])outMessage.ToArray(Type.GetType("System.Byte"));
            return System.Text.Encoding.Default.GetString(outbyte);
        }
    }
}
