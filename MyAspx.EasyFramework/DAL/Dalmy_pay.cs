using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.DAL
{
   public class Dalmy_pay :DalBase
   {
     public static IList<my_pay> GetIList(my_pay model)
     {
         return objMapper.GetMapper().QueryForList<my_pay>(model.SelectName, model);
     }

     public static void DeleteData(int id)
     {
         objMapper.GetMapper().Delete("my_pay.Deletemy_pay", id);
     }

     public static void InsertData(my_pay model)
     {
         objMapper.GetMapper().Insert(model.InsertName, model);
     }

     public static void UpdateData(my_pay model)
     {
         objMapper.GetMapper().Update(model.UpdateName, model);
     }

   } 
}
