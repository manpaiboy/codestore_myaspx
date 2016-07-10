using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyAspx.EasyFramework.EntityFramework;
using System.Collections;
namespace MyAspx.EasyFramework.DAL3
{
    public class SeoDAL
    {
        commyaspxdbEntities _myaspxentities = new commyaspxdbEntities();
        public int AddSeo(my_siteconf _my_siteconf)
        {
            var pSiteTitle = _my_siteconf.sitetitle;
            var pSiteKeyWorks = _my_siteconf.sitekeywords;
            var pSiteDescription = _my_siteconf.sitedescription;
            var pSiteWriter = _my_siteconf.sitewriter ;
            var pSiteRemark = _my_siteconf.siteremark;
            var pSiteAddTime = _my_siteconf.siteaddtime;
            _myaspxentities.my_siteconf.Add(new MyAspx.EasyFramework.EntityFramework.my_siteconf()
            {
                sitetitle = pSiteTitle,
                sitekeywords =pSiteKeyWorks,
                sitedescription = pSiteDescription,
                sitewriter = pSiteWriter,
                siteremark= pSiteRemark,
                siteaddtime = pSiteAddTime
            });
            _myaspxentities.SaveChanges();
            return 1;
        }
        public MyAspx.Json.JsonArray GetJsonSeo()
        {
            using(_myaspxentities)
            {
                MyAspx.Json.JsonArray _jsonarray = new Json.JsonArray();
               _jsonarray.Put(_myaspxentities.my_siteconf.OrderByDescending(p => p.siteid).ToList());
               return _jsonarray;
            }
        }
        public string GetJsonSeoIntoString()
        {
            using (_myaspxentities)
            {
                var _data = _myaspxentities.my_siteconf;
                int count = _data.Count();
                Hashtable ht = new Hashtable();
                ht.Add("total", count);
                ht.Add("rows", _myaspxentities.my_siteconf);
                string strJson = Newtonsoft.Json.JsonConvert.SerializeObject(ht);//序列化datatable
                //string _jstring = Newtonsoft.Json.JsonConvert.SerializeObject(_myaspxentities.my_siteconf.OrderByDescending(p => p.siteid).ToList());
                return strJson;
            }
        }
    }
}
