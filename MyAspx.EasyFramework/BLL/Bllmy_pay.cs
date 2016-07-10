using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model;
using MyAspx.EasyFramework.DAL; 

namespace MyAspx.EasyFramework.BLL
{
   public class Bllmy_pay 
   {
     public static IList<my_pay> GetIList(my_pay model)
     {
         return Dalmy_pay.GetIList(model);
     }

     public static void DeleteData(int id)
     {
          Dalmy_pay.DeleteData(id);
     }

     public static void InsertData(my_pay model)
     {
         Dalmy_pay.InsertData(model);
     }

     public static void UpdateData(my_pay model)
     {
         Dalmy_pay.UpdateData(model);
     }

   } 
}
