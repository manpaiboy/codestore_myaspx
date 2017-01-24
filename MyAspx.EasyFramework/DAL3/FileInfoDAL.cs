using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using MyAspx.EasyFramework.EntityFramework;
using System.Data.Entity.Validation;
using MyAspx.Framework.Common;

namespace MyAspx.EasyFramework.DAL3
{
    /// <summary>
    /// 新源码的基础信息DAL
    /// </summary>
    public class FileInfoDAL
    {
        commyaspxdbEntities _myaspxentities = new commyaspxdbEntities();

        public string ImgUrl(string imgs)
        {
            //<br>~/Upfiles/CodePics/admin/2017012318362093_india  flag orb.bmp<br>~/Upfiles/CodePics/admin/2017012318362301_110255_230124ef_355590.png
            string[] imgArray = imgs.Split('>');
            string firImg = imgArray[1].ToString();
            firImg = firImg.Replace("<br", "");
            firImg = firImg.Replace("~", "");
            return firImg;
        }
        /// <summary>
        /// 增加一条新上传的源代码的基础信息
        /// </summary>
        /// <param name="_my_fileinfo"></param>
        /// <returns></returns>
        public int AddNewCodeBaseInfo(my_fileinfo _my_fileinfo, out string errMes)
        {
            errMes = "";
            var fFileName = _my_fileinfo.filename;
            if (_myaspxentities.my_fileinfo.Count(select => select.filename == fFileName) > 0)
            {
                //同名的不插入
                errMes = "存在相同的源码条目。";
                return -1;
            }
            my_fileinfo S =  _myaspxentities.my_fileinfo.Add(new my_fileinfo()
            {
                fileid = _my_fileinfo.fileid,
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
                filefirimg = ImgUrl(_my_fileinfo.filepics),
                addtime = DateTime.Now.ToString()
            });
            //S.
            try
            {
                DbEntityEntry<my_fileinfo> oldEntry = _myaspxentities.Entry(S);
                if (oldEntry.State == EntityState.Detached)
                {
                    _myaspxentities.Set<my_fileinfo>().Attach(oldEntry.Entity);
                }
                oldEntry.CurrentValues.SetValues(S);
                oldEntry.State = EntityState.Added;

                _myaspxentities.SaveChanges();
                //_myaspxentities.Database.Log.
            }
            catch (DbEntityValidationException erException)
            {
                //ef内部异常获取
                errMes = erException.EntityValidationErrors.First().ValidationErrors.ToString();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                var entry = exception.Entries.Single();
                entry.OriginalValues.SetValues(entry.GetDatabaseValues()); 
            }
            catch (Exception err)
            {
                errMes = err.Message;
            }
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
