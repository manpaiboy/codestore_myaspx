using MyAspx.EasyFramework.EntityFramework;
using MyAspx.Framework.Common;
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
            //var name = _my_fileinfo.filename;
            //if (_myaspxentities.my_fileinfo.Count(SELECT => SELECT.adminname == pUser) > 0)
            //{
            //    return -1;
            //}


            _myaspxentities.my_fileinfo.Add(new MyAspx.EasyFramework.EntityFramework.my_fileinfo()
            {
                 fileid = FileOnlyName.GetName(),
                 filename = _my_fileinfo.filename,
                 filepics = _my_fileinfo.filepics,
                 codeplftype = _my_fileinfo.codeplftype,
                 devtool = _my_fileinfo.devtool,
                 codelang = _my_fileinfo.codelang,
                 filedatabase =_my_fileinfo.filedatabase,
                 frameworkversion = _my_fileinfo.frameworkversion,
                 linkurl = _my_fileinfo.linkurl,
                 createuser = _my_fileinfo.createuser,
                 contract = _my_fileinfo.contract,
                 usermsg = _my_fileinfo.usermsg,
                 codedes = _my_fileinfo.codedes
            });
            _myaspxentities.SaveChanges();
            return 1;
        }
    }
}
