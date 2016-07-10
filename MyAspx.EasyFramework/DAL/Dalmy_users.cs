using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.DAL
{
   public class Dalmy_users :DalBase
   {
     public static IList<my_users> GetIList(my_users model)
     {
         return objMapper.GetMapper().QueryForList<my_users>(model.SelectName, model);
     }

     public static void DeleteData(int id)
     {
         objMapper.GetMapper().Delete("my_users.Deletemy_users", id);
     }

     public static void InsertData(my_users model)
     {
         objMapper.GetMapper().Insert(model.InsertName, model);
     }

     public static void UpdateData(my_users model)
     {
         objMapper.GetMapper().Update(model.UpdateName, model);
     }

   } 
}
