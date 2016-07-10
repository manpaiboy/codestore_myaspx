using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.DAL
{
   public class Dalmy_gold :DalBase
   {
     public static IList<my_gold> GetIList(my_gold model)
     {
         return objMapper.GetMapper().QueryForList<my_gold>(model.SelectName, model);
     }

     public static void DeleteData(int id)
     {
         objMapper.GetMapper().Delete("my_gold.Deletemy_gold", id);
     }

     public static void InsertData(my_gold model)
     {
         objMapper.GetMapper().Insert(model.InsertName, model);
     }

     public static void UpdateData(my_gold model)
     {
         objMapper.GetMapper().Update(model.UpdateName, model);
     }

   } 
}
