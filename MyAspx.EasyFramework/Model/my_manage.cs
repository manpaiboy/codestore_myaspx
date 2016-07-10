using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.Model
{
   public class my_manage
   {
     public my_manage(){ }

     public int adminid
     {
         set;
         get;
     }

     public string SelectName
     {
         get{ return "my_manage.Selectmy_manage";}
     }

     public string InsertName
     {
         get{ return "my_manage.Insertmy_manage";}
     }

     public string DeleteName
     {
         get{ return "my_manage.Deletemy_manage";}
     }

     public string UpdateName
     {
         get{ return "my_manage.Updatemy_manage";}
     }

   } 
}
