using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model;
using MyAspx.EasyFramework.DAL; 

namespace MyAspx.EasyFramework.BLL
{
   public class Bllmy_class 
   {
     public static IList<my_class> GetIList(my_class model)
     {
         return Dalmy_class.GetIList(model);
     }

     public static void DeleteData(int id)
     {
          Dalmy_class.DeleteData(id);
     }

     public static void InsertData(my_class model)
     {
         Dalmy_class.InsertData(model);
     }

     public static void UpdateData(my_class model)
     {
         Dalmy_class.UpdateData(model);
     }

   } 
}
