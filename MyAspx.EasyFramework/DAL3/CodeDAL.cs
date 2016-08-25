using MyAspx.EasyFramework.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAspx.EasyFramework.DAL3
{
    public class CodeDAL
    {
        commyaspxdbEntities _myaspxentities = new commyaspxdbEntities();

        public void ClientSendCode()
        {

        }

        public int AddCode(my_fileinfo _my_fileinfo)
        {
              //                                                      name: $("#txtCodeName").val(),
              //                                                      paynub: $("#txtCodePayNub").val(),
              //                                                      codeserverurl: $("#txt_filePath").val(),
              //                                                      codepics: $(".upimgspanel").html(),
              //                                                      //5
              //                                                      CodeType: $("#CodeTypeId").val(),
              //                                                      DevelopTool: $("#DevelopToolId").val(),
              //                                                      Language: $("#LanguageId").val(),
              //                                                      Database: $("#DatabaseId").val(),
              //                                                      Framework: $("#FrameworkId").val(),
              //                                                      Tags: $("#Tags").val(),
              //                                                      LinkUrl: $("#LinkUrl").val(),
              //                                                      Author: $("#Author").val(),
              //                                                      Contract: $("#Contract").val(),
              //                                                      UserMsg: $("#UserMsg").val(),
              //                                                      preview: $("#preview").val()
            var name = _my_fileinfo.filename;
            var paynub = _myaspxentities.my_gold.Select(s=>s.goldid == );
            if (_myaspxentities.my_manage.Count(SELECT => SELECT.adminname == pUser) > 0)
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
    }
}
