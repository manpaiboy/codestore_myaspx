using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model;
using MyAspx.EasyFramework.DAL; 

namespace MyAspx.EasyFramework.BLL
{
   public class Bllmy_fileinfo 
   {
     public static IList<my_fileinfo> GetIList(my_fileinfo model)
     {
         return Dalmy_fileinfo.GetIList(model);
     }

     public static void DeleteData(int id)
     {
          Dalmy_fileinfo.DeleteData(id);
     }

     public static void InsertData(my_fileinfo model)
     {
         Dalmy_fileinfo.InsertData(model);
     }

     public static void UpdateData(my_fileinfo model)
     {
         Dalmy_fileinfo.UpdateData(model);
     }

   } 
}
