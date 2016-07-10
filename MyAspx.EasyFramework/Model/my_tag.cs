using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.Model
{
   public class my_tag
   {
     public my_tag(){ }

     public int tagid
     {
         set;
         get;
     }

     public string tagname
     {
         set;
         get;
     }

     public string tagcreatedate
     {
         set;
         get;
     }

     public int fileinfoid
     {
         set;
         get;
     }

     public string SelectName
     {
         get{ return "my_tag.Selectmy_tag";}
     }

     public string InsertName
     {
         get{ return "my_tag.Insertmy_tag";}
     }

     public string DeleteName
     {
         get{ return "my_tag.Deletemy_tag";}
     }

     public string UpdateName
     {
         get{ return "my_tag.Updatemy_tag";}
     }

   } 
}
