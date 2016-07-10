using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model;
using MyAspx.EasyFramework.DAL; 

namespace MyAspx.EasyFramework.BLL
{
   public class Bllmy_manage 
   {
     public static IList<my_manage> GetIList(my_manage model)
     {
         return Dalmy_manage.GetIList(model);
     }

     public static void DeleteData(int id)
     {
          Dalmy_manage.DeleteData(id);
     }

     public static void InsertData(my_manage model)
     {
         Dalmy_manage.InsertData(model);
     }

     public static void UpdateData(my_manage model)
     {
         Dalmy_manage.UpdateData(model);
     }

   } 
}
