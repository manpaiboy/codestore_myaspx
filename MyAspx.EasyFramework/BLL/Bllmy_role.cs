using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model;
using MyAspx.EasyFramework.DAL; 

namespace MyAspx.EasyFramework.BLL
{
   public class Bllmy_role 
   {
     public static IList<my_role> GetIList(my_role model)
     {
         return Dalmy_role.GetIList(model);
     }

     public static void DeleteData(int id)
     {
          Dalmy_role.DeleteData(id);
     }

     public static void InsertData(my_role model)
     {
         Dalmy_role.InsertData(model);
     }

     public static void UpdateData(my_role model)
     {
         Dalmy_role.UpdateData(model);
     }

   } 
}
