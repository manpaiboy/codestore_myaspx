using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.IO;

namespace MyAspx.Framework.WebUnit.Common
{
    public class UploadHelper
    {
        private static string ImgDomaiName { get { return ConfigurationManager.AppSettings["imgpath"]; } }
        private static int ImageMaxSize = 12000;
        private static string ImageFormat = "jpg,jpeg,gif,png,gif";
        public UploadHelper()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="photo">上传控件</param>
        /// <param name="Folder">路径如:UpFile/ad/</param>
        /// <returns>返回上传后的路径</returns>
        public static string UpLoadFile(HttpPostedFile file, string Folder, string FileName, out int iStatus)
        {
            Folder = ImgDomaiName + Folder;
            iStatus = 0;
            string sImage = "";
            try
            {
                string name = file.FileName;
                string extension = Path.GetExtension(name).ToLower().Trim('.');
                if (extension == "")
                {
                    iStatus = 0;
                    return "";
                }
                else
                {
                    
                    if (Directory.Exists( Folder) == false)
                        Directory.CreateDirectory( Folder);
                    sImage = FileName + "." + extension;
                    file.SaveAs( Folder + sImage);
                    iStatus = 1;
                }
            }
            catch
            {
                iStatus = 0;
            }
            return Folder + sImage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="photo">上传控件</param>
        /// <param name="Folder">路径如:UpFile/ad/</param>
        /// <returns>返回上传后的路径</returns>
        public static string UpLoadFile(FileUpload file, string Folder, string FileName, out int iStatus)
        {
            Folder = ImgDomaiName + Folder;
            iStatus = 0;
            string sImage = "";
            try
            {
                string name = file.FileName;
                string extension = Path.GetExtension(name).ToLower().Trim('.');
                if (extension == "")
                {
                    iStatus = 0;
                    return "";
                }
                else
                {
                   
                    if (Directory.Exists( Folder) == false)
                        Directory.CreateDirectory( Folder);
                    sImage = FileName + "." + extension;
                    file.SaveAs( Folder + sImage);
                    iStatus = 1;
                }
            }
            catch
            {
                iStatus = 0;
            }
            return Folder + sImage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="photo">上传控件</param>
        /// <param name="Folder">路径如:UpFile/ad/</param>
        /// <returns>返回上传后的路径</returns>
        public static string UpFile(HttpPostedFile photo, string Folder, out int iStatus)
        {
            Folder = ImgDomaiName + Folder;
            iStatus = 0;
            string sImage = "";

            try
            {
                string name = photo.FileName;
                //string type2 = name.Substring(name.LastIndexOf(".") + 1);
                string extension = Path.GetExtension(photo.FileName).ToLower().Trim('.');
                int iUploadImageMaxSize = Convert.ToInt32(ImageMaxSize);
                int ImgSize = photo.ContentLength / 1024;
                if (iUploadImageMaxSize < ImgSize)
                {
                    iStatus = -2;//图片太大。
                }
                else
                {
                    string sUploadImageFormat = ImageFormat;
                    if (sUploadImageFormat.ToLower().Contains(extension.ToLower()) == false)
                    {//上传了非设置的图片
                        iStatus = -3;//上传了非设置的图片。
                    }
                    else
                    {
                       

                        sImage = System.DateTime.Now.ToString("yyyyMMddhhmmss") + System.DateTime.Now.Millisecond.ToString("00") + "." + extension;
                        if (Directory.Exists( Folder) == false)
                            Directory.CreateDirectory( Folder);
                        photo.SaveAs(Folder + sImage);
                        iStatus = 1;
                    }
                }
            }
            catch
            {
                iStatus = 0;
            }
            return Folder + sImage;
        }


        public static string UpLoadImage(FileUpload photo, string Folder, string FileName, out int iStatus)
        {
            Folder = ImgDomaiName + Folder;
            iStatus = 0;
            string sImage = "";

            try
            {
                string name = photo.FileName;
                //string type2 = name.Substring(name.LastIndexOf(".") + 1);
                string extension = Path.GetExtension(photo.PostedFile.FileName).ToLower().Trim('.');
                if (extension == "")
                {

                    iStatus = 0;
                    return "";
                }
                else
                {
                    int iUploadImageMaxSize = Convert.ToInt32(ImageMaxSize);
                    int ImgSize = photo.PostedFile.ContentLength / 1024;
                    if (iUploadImageMaxSize < ImgSize)
                    {
                        iStatus = -2;//图片太大。
                    }
                    else
                    {
                        string sUploadImageFormat = ImageFormat;
                        if (sUploadImageFormat.ToLower().Contains(extension.ToLower()) == false)
                        {//上传了非设置的图片
                            iStatus = -3;//上传了非设置的图片。
                        }
                        else
                        {
                           
                            if (Directory.Exists( Folder) == false)
                                Directory.CreateDirectory( Folder);
                            //sImage = System.DateTime.Now.ToString("yyyyMMddhhmmss") + System.DateTime.Now.Millisecond.ToString("00") + "." + extension;
                            sImage = FileName + "." + extension;
                            photo.PostedFile.SaveAs( Folder + sImage);
                            iStatus = 1;
                        }
                    }
                }

            }
            catch
            {
                iStatus = 0;
            }
            return Folder + sImage;
        }
        public static string UpLoadImage(HttpPostedFile photo, string Folder, out int iStatus)
        {
            Folder = ImgDomaiName + Folder;
            iStatus = 0; string sImage = "";
            try
            {
                string name = photo.FileName;
                string extension = Path.GetExtension(photo.FileName).ToLower().Trim('.');
                int iUploadImageMaxSize = Convert.ToInt32(ImageMaxSize);
                int ImgSize = photo.ContentLength / 1024;
                if (iUploadImageMaxSize < ImgSize)
                {
                    iStatus = -2;//图片太大。
                }
                else
                {
                    string sUploadImageFormat = ImageFormat;
                    if (sUploadImageFormat.ToLower().Contains(extension.ToLower()) == false)
                    {//上传了非设置的图片
                        iStatus = -3;//上传了非设置的图片。
                    }
                    else
                    {
                        
                        //photoDestination = HttpContext.Current.Request.PhysicalApplicationPath;
                        if (Directory.Exists(  Folder) == false)
                            Directory.CreateDirectory( Folder);
                        sImage = System.DateTime.Now.ToString("yyyyMMddhhmmss") + System.DateTime.Now.Millisecond.ToString("00") + "." + extension;
                        photo.SaveAs( Folder + sImage);
                        iStatus = 1;
                    }
                }
            }
            catch
            {
                iStatus = 0;
            }
            return Folder + sImage;
        }
    }
}