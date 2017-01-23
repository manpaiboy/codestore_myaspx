using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAspx.Framework.Common
{
    public class GuidString
    {
        public static string CreateNewGuidStr()
        {
            string s = "";
            string guid = Guid.NewGuid().ToString();
            guid = guid.Replace("-", "");

            string d = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() +
                       DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            return guid + "_" + d
                ;
        }
    }
}