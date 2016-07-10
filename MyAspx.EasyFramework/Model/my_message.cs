using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.Model
{
   public class my_message
   {
     public my_message(){ }

     public int mesid
     {
         set;
         get;
     }

     public int meshasguest
     {
         set;
         get;
     }

     public int mespid
     {
         set;
         get;
     }

     public string SelectName
     {
         get{ return "my_message.Selectmy_message";}
     }

     public string InsertName
     {
         get{ return "my_message.Insertmy_message";}
     }

     public string DeleteName
     {
         get{ return "my_message.Deletemy_message";}
     }

     public string UpdateName
     {
         get{ return "my_message.Updatemy_message";}
     }

   } 
}
