using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MyAspx.Framework.WebUnit.Common
{



    public static class UploadFile
    {
        public static  Encoding DEFAULTENCODE = Encoding.UTF8;
        public static string FileControlName = "file";
        public static string ContentType = "image/png";//image/jpeg   application/octet-stream
        public static string Boundary = "---------------------------";

        /// <summary>
        /// HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string file, NameValueCollection data, CookieContainer cookie)
        {
            return HttpUploadFile(url, file, data, DEFAULTENCODE,cookie);
        }
        public static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = Path.GetExtension(fileName).ToLower();
            RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
            {
                mimeType = regKey.GetValue("Content Type").ToString();
            }
            return mimeType;
        }
        /// <summary>
        /// HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string file, NameValueCollection data, Encoding encoding, CookieContainer cookie)
        {
            return HttpUploadFile(url, new string[] { file }, data, encoding,cookie);
        }

        /// <summary>
        /// HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="files"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string[] files, NameValueCollection data, CookieContainer cookie, string certificatePath = "", string certificatePwd = "")
        {
            return HttpUploadFile(url, files, data, DEFAULTENCODE, cookie, certificatePath, certificatePwd);
        }

        /// <summary>
        /// HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="files"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string[] files, NameValueCollection data, Encoding encoding, CookieContainer cookie, string certificatePath = "", string certificatePwd = "")
        {
            //string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            string boundary = DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endbytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

            //1.HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            //request.CookieContainer = cookie;
            request.KeepAlive = true;
            //request.Credentials = CredentialCache.DefaultCredentials;

            if (certificatePath!="")
                request.ClientCertificates.Add(new X509Certificate(certificatePath, certificatePwd));

            using (Stream stream = request.GetRequestStream())
            {
                //1.1 key/value
                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                if (data != null)
                {
                    foreach (string key in data.Keys)
                    {
                        stream.Write(boundarybytes, 0, boundarybytes.Length);
                        string formitem = string.Format(formdataTemplate, key, data[key]);
                        byte[] formitembytes = encoding.GetBytes(formitem);
                        stream.Write(formitembytes, 0, formitembytes.Length);
                    }
                }

                //1.2 file
              
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                for (int i = 0; i < files.Length; i++)
                {//ContentType    GetMimeType(files[i].Split('#')[1]) 
                    string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: " + ContentType + "\r\n\r\n";
                    stream.Write(boundarybytes, 0, boundarybytes.Length);
                    string header = string.Format(headerTemplate, files[i].Split('#')[0], Path.GetFileName(files[i].Split('#')[1]));
                    byte[] headerbytes = encoding.GetBytes(header);
                    stream.Write(headerbytes, 0, headerbytes.Length);
                    using (FileStream fileStream = new FileStream(files[i].Split('#')[1], FileMode.Open, FileAccess.Read))
                    {
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            stream.Write(buffer, 0, bytesRead);
                        }
                    }
                    if (i < files.Count()-1)
                        stream.Write(boundarybytes, 0, boundarybytes.Length);
                }

                //1.3 form end
                stream.Write(endbytes, 0, endbytes.Length);
            }
            //2.WebResponse
            FileControlName = "file";
            DEFAULTENCODE = Encoding.Default;
            ContentType = "application/octet-stream";
            boundary = "---------------------------";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                return stream.ReadToEnd();
            }
        }
    }

}
