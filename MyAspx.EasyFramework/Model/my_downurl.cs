using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.Model
{
   public class my_downurl
   {
     public my_downurl(){ }

     public int downid
     {
         set;
         get;
     }

     public int downfileid
     {
         set;
         get;
     }

     public string SelectName
     {
         get{ return "my_downurl.Selectmy_downurl";}
     }

     public string InsertName
     {
         get{ return "my_downurl.Insertmy_downurl";}
     }

     public string DeleteName
     {
         get{ return "my_downurl.Deletemy_downurl";}
     }

     public string UpdateName
     {
         get{ return "my_downurl.Updatemy_downurl";}
     }

   } 
}
