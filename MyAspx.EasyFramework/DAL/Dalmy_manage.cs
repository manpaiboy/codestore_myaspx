using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.DAL
{
   public class Dalmy_manage :DalBase
   {
     public static IList<my_manage> GetIList(my_manage model)
     {
         return objMapper.GetMapper().QueryForList<my_manage>(model.SelectName, model);
     }

     public static void DeleteData(int id)
     {
         objMapper.GetMapper().Delete("my_manage.Deletemy_manage", id);
     }

     public static void InsertData(my_manage model)
     {
         objMapper.GetMapper().Insert(model.InsertName, model);
     }

     public static void UpdateData(my_manage model)
     {
         objMapper.GetMapper().Update(model.UpdateName, model);
     }

   } 
}
