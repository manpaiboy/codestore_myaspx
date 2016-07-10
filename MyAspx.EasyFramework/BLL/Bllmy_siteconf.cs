using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model;
using MyAspx.EasyFramework.DAL; 

namespace MyAspx.EasyFramework.BLL
{
   public class Bllmy_siteconf 
   {
     public static IList<my_siteconf> GetIList(my_siteconf model)
     {
         return Dalmy_siteconf.GetIList(model);
     }

     public static void DeleteData(int id)
     {
          Dalmy_siteconf.DeleteData(id);
     }

     public static void InsertData(my_siteconf model)
     {
         Dalmy_siteconf.InsertData(model);
     }

     public static void UpdateData(my_siteconf model)
     {
         Dalmy_siteconf.UpdateData(model);
     }

   } 
}
