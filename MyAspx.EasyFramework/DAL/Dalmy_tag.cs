using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.DAL
{
   public class Dalmy_tag :DalBase
   {
     public static IList<my_tag> GetIList(my_tag model)
     {
         return objMapper.GetMapper().QueryForList<my_tag>(model.SelectName, model);
     }

     public static void DeleteData(int id)
     {
         objMapper.GetMapper().Delete("my_tag.Deletemy_tag", id);
     }

     public static void InsertData(my_tag model)
     {
         objMapper.GetMapper().Insert(model.InsertName, model);
     }

     public static void UpdateData(my_tag model)
     {
         objMapper.GetMapper().Update(model.UpdateName, model);
     }

   } 
}
