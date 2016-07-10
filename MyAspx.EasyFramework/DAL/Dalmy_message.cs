using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.DAL
{
   public class Dalmy_message :DalBase
   {
     public static IList<my_message> GetIList(my_message model)
     {
         return objMapper.GetMapper().QueryForList<my_message>(model.SelectName, model);
     }

     public static void DeleteData(int id)
     {
         objMapper.GetMapper().Delete("my_message.Deletemy_message", id);
     }

     public static void InsertData(my_message model)
     {
         objMapper.GetMapper().Insert(model.InsertName, model);
     }

     public static void UpdateData(my_message model)
     {
         objMapper.GetMapper().Update(model.UpdateName, model);
     }

   } 
}
