using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyAspx.EasyFramework.EntityFramework;

namespace MyAspx.EasyFramework.DAL3
{
    /// <summary>
    /// 新源码的基础信息DAL
    /// </summary>
    public class FileInfoDAL
    {
        commyaspxdbEntities _myaspxentities = new commyaspxdbEntities();

        /// <summary>
        /// 增加一条新上传的源代码的基础信息
        /// </summary>
        /// <param name="_my_fileinfo"></param>
        /// <returns></returns>
        public int AddNewCodeBaseInfo(my_fileinfo _my_fileinfo)
        {
            var fFileName = _my_fileinfo.filename;
            if (_myaspxentities.my_fileinfo.Count(SELECT => SELECT.filename == fFileName) > 0)
            {
                //同名的不插入
                return -1;
            }
            _myaspxentities.my_fileinfo.Add(new MyAspx.EasyFramework.EntityFramework.my_fileinfo()
            {
                filename =  _my_fileinfo.filename,
                filedatabase = _my_fileinfo.filedatabase,
                filedevlan = _my_fileinfo.filedevlan,
                filevstype = _my_fileinfo.devtool,
                filepics = _my_fileinfo.filepics,
                codedes = _my_fileinfo.codedes,
                codelang =  _my_fileinfo.codelang,
                contract = _my_fileinfo.contract,
                createuser =  _my_fileinfo.createuser,
                codeplftype = _my_fileinfo.frameworkversion,
            });
            _myaspxentities.SaveChanges();
            return 1;
        }
        public my_fileinfo HasEqualsCodeName(string fName)
        {
            var _myfileinfoobject = from _myfo in _myaspxentities.my_fileinfo where _myfo.filename.Equals(fName) select _myfo;
            if (_myfileinfoobject.Count() > 0)
                return new my_fileinfo { filename = fName };
            else
                return null;
        }
    }
}
