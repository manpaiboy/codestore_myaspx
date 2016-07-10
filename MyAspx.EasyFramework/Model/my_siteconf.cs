using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.Model
{
   public class my_siteconf
   {
     public my_siteconf(){ }

     public int siteid
     {
         set;
         get;
     }

     public string sitetitle
     {
         set;
         get;
     }

     public string sitekeywords
     {
         set;
         get;
     }

     public string sitedescription
     {
         set;
         get;
     }

     public string sitewriter
     {
         set;
         get;
     }

     public string SelectName
     {
         get{ return "my_siteconf.Selectmy_siteconf";}
     }

     public string InsertName
     {
         get{ return "my_siteconf.Insertmy_siteconf";}
     }

     public string DeleteName
     {
         get{ return "my_siteconf.Deletemy_siteconf";}
     }

     public string UpdateName
     {
         get{ return "my_siteconf.Updatemy_siteconf";}
     }

   } 
}
