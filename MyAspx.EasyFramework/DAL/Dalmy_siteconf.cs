using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.DAL
{
   public class Dalmy_siteconf :DalBase
   {
     public static IList<my_siteconf> GetIList(my_siteconf model)
     {
         return objMapper.GetMapper().QueryForList<my_siteconf>(model.SelectName, model);
     }

     public static void DeleteData(int id)
     {
         objMapper.GetMapper().Delete("my_siteconf.Deletemy_siteconf", id);
     }

     public static void InsertData(my_siteconf model)
     {
         objMapper.GetMapper().Insert(model.InsertName, model);
     }

     public static void UpdateData(my_siteconf model)
     {
         objMapper.GetMapper().Update(model.UpdateName, model);
     }

   } 
}
