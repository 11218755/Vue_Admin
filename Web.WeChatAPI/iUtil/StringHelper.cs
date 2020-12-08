using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Web.WeChatAPI.iUtil
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringHelper
    {
        #region 截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string SubString(this string str, string start, string end)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            int startIndex = 0;
            startIndex = str.IndexOf(start);
            if (startIndex != -1)
            {
                startIndex += start.Length;
            }
            else
            {
                return string.Empty;
            }

            int endIndex = 0;
            endIndex = str.IndexOf(end, startIndex);
            if (endIndex != -1)
            {
                return str.Substring(startIndex, endIndex - startIndex);
            }
            return string.Empty;
        }
        #endregion

        #region 如果字符串是Null返回空串，否则原样返回
        /// <summary>
        /// 如果字符串是Null返回空串，否则原样返回
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string IsNullEmptyIt(string text)
        {
            return string.IsNullOrEmpty(text) ? string.Empty : text;
        }
        #endregion

        #region 计算字符串MD5
        /// <summary>
        /// 计算字符串MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5(this string str)
        {
            byte[] result = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
        #endregion

        #region 计算字符串MD5
        /// <summary>
        /// 计算字符串MD5
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Encoding"></param>
        /// <returns></returns>
        public static string MD5(this string str, Encoding Encoding)
        {
            byte[] result = Encoding.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
        #endregion

        #region 反馈10位长度随机数
        /// <summary>
        /// 反馈10位长度随机数
        /// </summary>
        /// <returns></returns>
        public static string RandomTenLength()
        {
            return string.Format("{0:D5}{1:D5}", new Random().Next(0, 99999), new Random().Next(0, 99999));
        }
        #endregion
    }
}
