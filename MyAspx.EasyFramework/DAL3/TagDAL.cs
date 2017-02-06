using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyAspx.EasyFramework.EntityFramework;

namespace MyAspx.EasyFramework.DAL3
{
    /// <summary>
    /// 新增的源码标签信息
    /// </summary>
    public  class TagDAL
    {
        commyaspxdbEntities _myaspxentities = new commyaspxdbEntities();
        public int AddNewCodeTagInfo(my_tag _myTag)
        {
            //[tagname],[tagcreatedate],[fileinfoid]
            _myaspxentities.my_tag.Add(new my_tag()
            { 
                tagname = _myTag.tagname,
                tagcreatedate = _myTag.tagcreatedate,
                fileinfoid =  _myTag.fileinfoid
                
            });
           return _myaspxentities.SaveChanges();
        }

    }
}
