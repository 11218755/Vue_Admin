using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.iException
{
    public class BaseException : System.Exception
    {
        public const string zh_CN = "zh_CN";
        public const string en_US = "en_US";

        #region 异常定义
        public const string SYSTEMERROR = "100000";
        public const string LOGINFAIL = "100001";
        public const string LOGINFAIL_NONEROLE = "100002";
        public const string SESSIONTIMEOUT = "100003";
        #endregion

        #region 异常配置
        /// <summary>
        /// 异常配置
        /// </summary>
        public static List<ExceptionElement> ListExceptionElement { get; set; }
        #endregion
    }

}
