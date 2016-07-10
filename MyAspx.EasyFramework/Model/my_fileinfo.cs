using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyAspx.EasyFramework.Model; 

namespace MyAspx.EasyFramework.Model
{
   public class my_fileinfo
   {
     public my_fileinfo(){ }

     public int fileid
     {
         set;
         get;
     }

     public int fileclassid
     {
         set;
         get;
     }

     public int downid
     {
         set;
         get;
     }

     public int filedownnum
     {
         set;
         get;
     }

     public string SelectName
     {
         get{ return "my_fileinfo.Selectmy_fileinfo";}
     }

     public string InsertName
     {
         get{ return "my_fileinfo.Insertmy_fileinfo";}
     }

     public string DeleteName
     {
         get{ return "my_fileinfo.Deletemy_fileinfo";}
     }

     public string UpdateName
     {
         get{ return "my_fileinfo.Updatemy_fileinfo";}
     }

   } 
}
