using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace iPathFramework.iUtil
{
    public static class WebClientUploadFile
    {
        public static byte[] PostFile(this WebClient wc, string url, string filepath, string filename, string fieldname)
        {
            var contentType = "application/octet-stream";

            var fieldData = new List<byte[]>() { CreateFieldData(wc.Encoding, filepath, filename, fieldname, contentType) };
            var postData = JoinBytes(fieldData, wc.Encoding);


            wc.Headers.Add("Content-Type", ContentType);

            return wc.UploadData(url, "POST", postData);
        }

        public static byte[] CreateFieldData(Encoding encoding, string filepath, string filename, string fieldName, string contentType)
        {
            var fileBytes = System.IO.File.ReadAllBytes(filepath);

            string end = "\r\n";
            string textTemplate = Boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";

            // 头数据
            string data = String.Format(textTemplate, fieldName, filename, contentType);
            byte[] bytes = encoding.GetBytes(data);

            // 尾数据
            byte[] endBytes = encoding.GetBytes(end);

            // 合成后的数组
            byte[] fieldData = new byte[bytes.Length + fileBytes.Length + endBytes.Length];

            bytes.CopyTo(fieldData, 0); // 头数据
            fileBytes.CopyTo(fieldData, bytes.Length); // 文件的二进制数据
            endBytes.CopyTo(fieldData, bytes.Length + fileBytes.Length); // \r\n

            return fieldData;
        }

        public static byte[] JoinBytes(List<byte[]> byteArrays, Encoding encoding)
        {
            int length = 0;
            int readLength = 0;

            // 加上结束边界
            string endBoundary = Boundary + "--\r\n"; //结束边界
            byte[] endBoundaryBytes = encoding.GetBytes(endBoundary);
            byteArrays.Add(endBoundaryBytes);

            foreach (byte[] b in byteArrays)
            {
                length += b.Length;
            }
            byte[] bytes = new byte[length];

            // 遍历复制
            //
            foreach (byte[] b in byteArrays)
            {
                b.CopyTo(bytes, readLength);
                readLength += b.Length;
            }

            return bytes;
        }

        public static string Boundary
        {
            get
            {
                string[] bArray, ctArray;
                string contentType = ContentType;
                ctArray = contentType.Split(';');
                if (ctArray[0].Trim().ToLower() == "multipart/form-data")
                {
                    bArray = ctArray[1].Split('=');
                    return "--" + bArray[1];
                }
                return null;
            }
        }

        public static string ContentType
        {
            get
            {
                //if (HttpContext.Current == null)
                //{
                    return "multipart/form-data; boundary=---------------------------7d5b915500cee";
                //}
                //return HttpContext.Current.Request.ContentType;
            }
        }

        public static string HttpUploadFile(string url, string path)
        {
            var content = "1";
            return content;
        }
    }
}
