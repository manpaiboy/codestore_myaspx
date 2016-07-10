using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.DAL
{
   public class Dalmy_class :DalBase
   {
     public static IList<my_class> GetIList(my_class model)
     {
         return objMapper.GetMapper().QueryForList<my_class>(model.SelectName, model);
     }

     public static void DeleteData(int id)
     {
         objMapper.GetMapper().Delete("my_class.Deletemy_class", id);
     }

     public static void InsertData(my_class model)
     {
         objMapper.GetMapper().Insert(model.InsertName, model);
     }

     public static void UpdateData(my_class model)
     {
         objMapper.GetMapper().Update(model.UpdateName, model);
     }

   } 
}
