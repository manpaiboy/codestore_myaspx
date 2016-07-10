using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MyAspx.Framework.WebUnit.Common
{
    public class Regexlib
    {
        /// <summary>
        /// 判断字符串是否是a-zA-Z0-9_范围内（3-50位范围内）
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidUserName(string strIn)
        {
            return Regex.IsMatch(strIn, @"^[A-Za-z0-9_]{3,50}$");
        }
        /// <summary>
        /// 验证邮箱
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }
        /// <summary>
        /// 验证手机
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidMobile(string strIn)
        {
            return Regex.IsMatch(strIn, @"^[1]+[3,5,8]+\d{9}");
        }
       /// <summary>
       /// 验证手机号
       /// </summary>
        /// <param name="strIn"></param>
       /// <returns></returns>
        public static bool IsValidTelPhone(string strIn)
        {
            return Regex.IsMatch(strIn, @"^(\d{3,4}-)?\d{6,8}$");

        }
        /// <summary>
        /// 判断对象是否为Int32类型的数字
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(object expression)
        {
            if (expression != null)
                return IsNumeric(expression.ToString());

            return false;

        }

        /// <summary>
        /// 判断对象是否为Int32类型的数字
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(string expression)
        {
            if (expression != null)
            {
                string str = expression;
                if (str.Length > 0 && str.Length <= 11 && Regex.IsMatch(str, @"^[-]?[0-9]*[.]?[0-9]*$"))
                {
                    if ((str.Length < 10) || (str.Length == 10 && str[0] == '1') || (str.Length == 11 && str[0] == '-' && str[1] == '1'))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否为Double类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsDouble(object expression)
        {
            if (expression != null)
                return Regex.IsMatch(expression.ToString(), @"^([0-9])[0-9]*(\.\w*)?$");

            return false;
        }

        /// <summary>
        /// 判断给定的字符串数组(strNumber)中的数据是不是都为数值型
        /// </summary>
        /// <param name="strNumber">要确认的字符串数组</param>
        /// <returns>是则返加true 不是则返回 false</returns>
        public static bool IsNumericArray(string[] strNumber)
        {
            if (strNumber == null)
                return false;

            if (strNumber.Length < 1)
                return false;

            foreach (string id in strNumber)
            {
                if (!IsNumeric(id))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// （正整数 >0）
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsIntPlus(string strIn)
        {
            if (Regex.IsMatch(strIn, @"^[0-9]*[1-9][0-9]*$"))
                return true;
            return false;
        }
        /// <summary>
        /// （正整数 包括 0）
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsInteger(string strIn)
        {
            if (Regex.IsMatch(strIn, @"^[0-9]+$"))
                return true;
            return false;
        }
        /// <summary>
        /// （正整数 包括 0）
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsIntPlusAndZero(string strIn)
        {
            if (Regex.IsMatch(strIn, @"^[0-9]+$"))
                return true;
            return false;
        }
        /// <summary>
        /// 匹配负整数,不包括0
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsIntNegative(string strIn)
        {
            if (Regex.IsMatch(strIn, @"^-[0-9]*[1-9][0-9]*$"))
                return true;
            return false;
        }
        /// <summary>
        /// 匹配整数,正数和负数，不包括0
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsIntAllNotZero(string strIn)
        {
            if (Regex.IsMatch(strIn, @"^-?[1-9]\d*$"))
                return true;
            return false;
        }
        /// <summary>
        /// 匹配整数,正数和负数，包括0
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsIntAll(string strIn)
        {
            if (Regex.IsMatch(strIn, @"^-?\d+$"))
                return true;
            return false;
        }
        /// <summary>
        ///（负整数 包括 0）
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsIntNegativeAndZero(string strIn)
        {
            if (Regex.IsMatch(strIn, @"^-[1-9]d*|0$"))
                return true;
            return false;
        }


        /// <summary>
        /// 非负浮点数（正浮点数 + 0）  
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsPosNumber(string strIn)
        {
            if (Regex.IsMatch(strIn, @"^\d+(\.\d+)?$"))
                return true;
            return false;
        }
        /// <summary>
        /// 匹配正浮点数>0
        /// </summary>
        public static bool IsFloatPlus(string strIn)
        {
            if (Regex.IsMatch(strIn, @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"))
                return true;
            return false;
        }
        /// <summary>
        /// 非负浮点数（正浮点数 + 0）  
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsFloatPlusAndZero(string strIn)
        {
            if (Regex.IsMatch(strIn, @"^\d+(\.\d+)?$"))
                return true;
            return false;
        }
        /// <summary>
        /// 匹配负浮点数<0
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsFloatNegative(string strIn)
        {
            if (Regex.IsMatch(strIn, @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$"))
                return true;
            return false;
        }
        /// <summary>
        /// 非正浮点数（负浮点数 + 0）  
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsFloatNegativeAndZero(string strIn)
        {
            if (Regex.IsMatch(strIn, @"^((-\d+(\.\d+)?)|(0+(\.0+)?))$"))
                return true;
            return false;
        }
        /// <summary>
        /// 验证身份证号码
        /// </summary>
        /// <param name="Id">身份证号码</param>
        /// <returns>验证成功为True，否则为False</returns>
        public static bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证18位身份证号
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns>验证成功为True，否则为False</returns>
        private static bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        /// <summary>
        /// 验证15位身份证号
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns>验证成功为True，否则为False</returns>
        private static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }
    }
}
