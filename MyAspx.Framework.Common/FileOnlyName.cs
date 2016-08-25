using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAspx.Framework.Common
{
    public class FileOnlyName
    {
        const string preA = "file_";
        public static string GetName()
        {
            return
                Guid.NewGuid().ToString().Replace("-", "_").Substring(1, 10) + "_" + DateTime.Now.ToString("yyyMMddhhmmsss");
        }
    }
}