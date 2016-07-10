using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.Model
{
   public class my_role
   {
     public my_role(){ }

     public int roleid
     {
         set;
         get;
     }

     public int roleclose
     {
         set;
         get;
     }

     public string SelectName
     {
         get{ return "my_role.Selectmy_role";}
     }

     public string InsertName
     {
         get{ return "my_role.Insertmy_role";}
     }

     public string DeleteName
     {
         get{ return "my_role.Deletemy_role";}
     }

     public string UpdateName
     {
         get{ return "my_role.Updatemy_role";}
     }

   } 
}
