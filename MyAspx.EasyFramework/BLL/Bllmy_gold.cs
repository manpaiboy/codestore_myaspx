using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model;
using MyAspx.EasyFramework.DAL; 

namespace MyAspx.EasyFramework.BLL
{
   public class Bllmy_gold 
   {
     public static IList<my_gold> GetIList(my_gold model)
     {
         return Dalmy_gold.GetIList(model);
     }

     public static void DeleteData(int id)
     {
          Dalmy_gold.DeleteData(id);
     }

     public static void InsertData(my_gold model)
     {
         Dalmy_gold.InsertData(model);
     }

     public static void UpdateData(my_gold model)
     {
         Dalmy_gold.UpdateData(model);
     }

   } 
}
