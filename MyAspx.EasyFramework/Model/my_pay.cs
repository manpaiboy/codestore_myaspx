using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.Model
{
   public class my_pay
   {
     public my_pay(){ }

     public int payid
     {
         set;
         get;
     }

     public int payuseid
     {
         set;
         get;
     }

     public string SelectName
     {
         get{ return "my_pay.Selectmy_pay";}
     }

     public string InsertName
     {
         get{ return "my_pay.Insertmy_pay";}
     }

     public string DeleteName
     {
         get{ return "my_pay.Deletemy_pay";}
     }

     public string UpdateName
     {
         get{ return "my_pay.Updatemy_pay";}
     }

   } 
}
