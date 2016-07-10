using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.Model
{
   public class my_class
   {
     public my_class(){ }

     public int classid
     {
         set;
         get;
     }

     public int pclassid
     {
         set;
         get;
     }

     public string SelectName
     {
         get{ return "my_class.Selectmy_class";}
     }

     public string InsertName
     {
         get{ return "my_class.Insertmy_class";}
     }

     public string DeleteName
     {
         get{ return "my_class.Deletemy_class";}
     }

     public string UpdateName
     {
         get{ return "my_class.Updatemy_class";}
     }

   } 
}
