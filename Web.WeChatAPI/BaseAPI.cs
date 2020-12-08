using Web.WeChatAPI.Entity;
using Web.WeChatAPI.iUtil;
using Microsoft.Azure.KeyVault.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace Web.WeChatAPI
{
    public class BaseAPI
    {
        #region Get请求并反馈解码后的Json对象
        /// <summary>
        /// Get请求并反馈解码后的Json对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T GetObject<T>(string url, string param = "")
            where T : BaseRes
        {
            TimeoutWebClient wc = ThreadWebClientFactory.GetWebClient();
            wc.Encoding = Encoding.UTF8;
            var json = wc.GetLoadString(url, param);
            var rel = JsonConvert.DeserializeObject<T>(json);
            if (string.IsNullOrEmpty(rel.errcode))
            {
                rel.errcode = "0";
            }
            return rel;
        }
        #endregion

        #region Post请求并反馈解码后的Json对象
        /// <summary>
        /// Post请求并反馈解码后的Json对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        public static T PostObject<T>(string url, string post)
            where T : BaseRes
        {
            TimeoutWebClient wc = ThreadWebClientFactory.GetWebClient();

            #pragma warning disable CS0618 // 类型或成员已过时
            // ServicePointManager.CertificatePolicy = new CertPolicy();
            #pragma warning restore CS0618 // 类型或成员已过时

            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var json = wc.PostLoadString(url, post);
            // LogHelper.Info($"url:{url},post:{post}");
            var rel = JsonConvert.DeserializeObject<T>(json);
            if (string.IsNullOrEmpty(rel.errcode))
            {
                rel.errcode = "0";
            }
            return rel;
        }
        #endregion

        #region Post请求并反馈解码后的Json对象
        /// <summary>
        /// Post请求并反馈解码后的Json对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        public static T PostObject<T>(string url, dynamic post)
            where T : BaseRes
        {
            string ps = JsonConvert.SerializeObject(post);
            return PostObject<T>(url, ps);
        }
        #endregion

        #region 上传文件
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T UploadFile<T>(string file, string url)
            where T : BaseRes
        {
            Process p = new Process();
            string fileargs = " -k -F media=@" + file + " \"" + url + "\"";
            p.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + @"Static\curl.exe";
            p.StartInfo.Arguments = fileargs;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();

            using (StreamReader reader = p.StandardOutput)
            {
                string json = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
                T res = JsonConvert.DeserializeObject<T>(json);
                if (string.IsNullOrEmpty(res.errcode))
                {
                    res.errcode = "0";
                }
                reader.Close();
                return res;
            }

            


        }
        #endregion

        class CertPolicy : CertificatePolicy
        {
            public bool CheckValidationResult(ServicePoint srvpt, X509Certificate cert, WebRequest req, int certprb)
            { return true; }
        }
    }
}
