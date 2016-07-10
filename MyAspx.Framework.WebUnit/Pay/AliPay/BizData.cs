using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAspx.Framework.WebUnit.Common.Alipay
{
    public class BizData
    {
        public string trade_type { get; set; }
        public string need_address { get; set; }
        public goods_info goods_info { get; set; }
        public string return_url { get; set; }
        public string notify_url { get; set; }
        public string query_url { get; set; }
        public ext_info ext_info { get; set; }
        public string memo { get; set; }
        public string url { get; set; }
    
    }
    public class goods_info
    {
        public string id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string inventory { get; set; }
        public string sku_title { get; set; }
        public List<sku> sku { get; set; }
        public string expiry_date { get; set; }
        public string desc { get; set; }
      
    }
    public class sku
    {
        public string sku_id { get; set; }
        public string sku_name { get; set; }
        public string sku_price { get; set; }
        public string sku_inventory { get; set; }
    }
    public class ext_info
    {
        public string single_limit { get; set; }
        public string user_limit { get; set; }
        public string pay_timeout { get; set; }
        public string logo_name { get; set; }
        public ext_field ext_field { get; set; }
      
    }
    public class ext_field
    {
        public string input_title { get; set; }
        public string input_regex { get; set; }
    }
}
