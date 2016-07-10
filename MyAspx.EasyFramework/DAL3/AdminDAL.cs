using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyAspx.EasyFramework.EntityFramework;
namespace MyAspx.EasyFramework.DAL3
{
    public class AdminDAL
    {
        commyaspxdbEntities _myaspxentities = new commyaspxdbEntities();
        public string ValidateAdmin(my_manage _my_manage)
        {
            if (_myaspxentities.my_manage.Count(
                                                 p => p.adminname == _my_manage.adminname &&
                                                 p.adminpwd == _my_manage.adminpwd)
                                                 > 0)
                return "find";
            
            else
                return "nofind";
        }
        public int AddAdmin(my_manage _my_manage)
        {
            var pUser = _my_manage.adminname;
            var pPwd = _my_manage.adminpwd;
            if(_myaspxentities.my_manage.Count(SELECT=>SELECT.adminname==pUser)>0)
            {
                return -1;
            }
            _myaspxentities.my_manage.Add(new MyAspx.EasyFramework.EntityFramework.my_manage()
            {
                adminname = pUser,
                adminpwd = pPwd
            });
            _myaspxentities.SaveChanges();
            return 1;
        }
        public my_manage HasEqualsAdminName(string sName)
        {
            var _mymanageobject = from _mymo in _myaspxentities.my_manage where _mymo.adminname.Equals(sName) select _mymo;
            if (_mymanageobject.Count() > 0)
                return new my_manage() { adminname = sName };
            else
                return null;
        }
    }
}
