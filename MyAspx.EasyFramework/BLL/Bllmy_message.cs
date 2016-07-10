using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model;
using MyAspx.EasyFramework.DAL; 

namespace MyAspx.EasyFramework.BLL
{
   public class Bllmy_message 
   {
     public static IList<my_message> GetIList(my_message model)
     {
         return Dalmy_message.GetIList(model);
     }

     public static void DeleteData(int id)
     {
          Dalmy_message.DeleteData(id);
     }

     public static void InsertData(my_message model)
     {
         Dalmy_message.InsertData(model);
     }

     public static void UpdateData(my_message model)
     {
         Dalmy_message.UpdateData(model);
     }

   } 
}
