using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model;
using MyAspx.EasyFramework.DAL; 

namespace MyAspx.EasyFramework.BLL
{
   public class Bllmy_users 
   {
     public static IList<my_users> GetIList(my_users model)
     {
         return Dalmy_users.GetIList(model);
     }

     public static void DeleteData(int id)
     {
          Dalmy_users.DeleteData(id);
     }

     public static void InsertData(my_users model)
     {
         Dalmy_users.InsertData(model);
     }

     public static void UpdateData(my_users model)
     {
         Dalmy_users.UpdateData(model);
     }

   } 
}
