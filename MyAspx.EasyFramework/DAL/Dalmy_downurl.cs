using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.DAL
{
   public class Dalmy_downurl :DalBase
   {
     public static IList<my_downurl> GetIList(my_downurl model)
     {
         return objMapper.GetMapper().QueryForList<my_downurl>(model.SelectName, model);
     }

     public static void DeleteData(int id)
     {
         objMapper.GetMapper().Delete("my_downurl.Deletemy_downurl", id);
     }

     public static void InsertData(my_downurl model)
     {
         objMapper.GetMapper().Insert(model.InsertName, model);
     }

     public static void UpdateData(my_downurl model)
     {
         objMapper.GetMapper().Update(model.UpdateName, model);
     }

   } 
}
