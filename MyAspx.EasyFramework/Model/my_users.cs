using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.Model
{
   public class my_users
   {
     public my_users(){ }

     public int userid
     {
         set;
         get;
     }

     public int usersex
     {
         set;
         get;
     }

     public string SelectName
     {
         get{ return "my_users.Selectmy_users";}
     }

     public string InsertName
     {
         get{ return "my_users.Insertmy_users";}
     }

     public string DeleteName
     {
         get{ return "my_users.Deletemy_users";}
     }

     public string UpdateName
     {
         get{ return "my_users.Updatemy_users";}
     }

   } 
}
