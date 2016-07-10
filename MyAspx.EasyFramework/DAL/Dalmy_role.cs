using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.DAL
{
   public class Dalmy_role :DalBase
   {
     public static IList<my_role> GetIList(my_role model)
     {
         return objMapper.GetMapper().QueryForList<my_role>(model.SelectName, model);
     }

     public static void DeleteData(int id)
     {
         objMapper.GetMapper().Delete("my_role.Deletemy_role", id);
     }

     public static void InsertData(my_role model)
     {
         objMapper.GetMapper().Insert(model.InsertName, model);
     }

     public static void UpdateData(my_role model)
     {
         objMapper.GetMapper().Update(model.UpdateName, model);
     }

   } 
}
