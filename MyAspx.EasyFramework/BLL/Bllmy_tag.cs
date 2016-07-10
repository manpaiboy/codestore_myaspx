using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model;
using MyAspx.EasyFramework.DAL; 

namespace MyAspx.EasyFramework.BLL
{
   public class Bllmy_tag 
   {
     public static IList<my_tag> GetIList(my_tag model)
     {
         return Dalmy_tag.GetIList(model);
     }

     public static void DeleteData(int id)
     {
          Dalmy_tag.DeleteData(id);
     }

     public static void InsertData(my_tag model)
     {
         Dalmy_tag.InsertData(model);
     }

     public static void UpdateData(my_tag model)
     {
         Dalmy_tag.UpdateData(model);
     }

   } 
}
