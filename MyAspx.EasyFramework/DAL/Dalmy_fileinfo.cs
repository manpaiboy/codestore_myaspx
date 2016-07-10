using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.DAL
{
   public class Dalmy_fileinfo :DalBase
   {
     public static IList<my_fileinfo> GetIList(my_fileinfo model)
     {
         return objMapper.GetMapper().QueryForList<my_fileinfo>(model.SelectName, model);
     }

     public static void DeleteData(int id)
     {
         objMapper.GetMapper().Delete("my_fileinfo.Deletemy_fileinfo", id);
     }

     public static void InsertData(my_fileinfo model)
     {
         objMapper.GetMapper().Insert(model.InsertName, model);
     }

     public static void UpdateData(my_fileinfo model)
     {
         objMapper.GetMapper().Update(model.UpdateName, model);
     }

   } 
}
