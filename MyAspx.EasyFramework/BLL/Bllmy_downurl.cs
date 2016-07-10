using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model;
using MyAspx.EasyFramework.DAL; 

namespace MyAspx.EasyFramework.BLL
{
   public class Bllmy_downurl 
   {
     public static IList<my_downurl> GetIList(my_downurl model)
     {
         return Dalmy_downurl.GetIList(model);
     }

     public static void DeleteData(int id)
     {
          Dalmy_downurl.DeleteData(id);
     }

     public static void InsertData(my_downurl model)
     {
         Dalmy_downurl.InsertData(model);
     }

     public static void UpdateData(my_downurl model)
     {
         Dalmy_downurl.UpdateData(model);
     }

   } 
}
