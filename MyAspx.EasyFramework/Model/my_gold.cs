using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.Model
{
   public class my_gold
   {
     public my_gold(){ }

     public int goldid
     {
         set;
         get;
     }

     public int golduserid
     {
         set;
         get;
     }

     public int goldpaynum
     {
         set;
         get;
     }

     public string SelectName
     {
         get{ return "my_gold.Selectmy_gold";}
     }

     public string InsertName
     {
         get{ return "my_gold.Insertmy_gold";}
     }

     public string DeleteName
     {
         get{ return "my_gold.Deletemy_gold";}
     }

     public string UpdateName
     {
         get{ return "my_gold.Updatemy_gold";}
     }

   } 
}
