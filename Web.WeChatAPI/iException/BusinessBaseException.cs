using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.iException
{
    public class BusinessBaseException : BaseException
    {
        new public System.Exception InnerException { get; set; }
        public string ExceptionCode { get; set; }

        public BusinessBaseException(System.Exception exp)
        {
            ExceptionCode = SYSTEMERROR;
            InnerException = exp;
        }

        public BusinessBaseException(string code)
        {
            ExceptionCode = code;
            InnerException = new System.Exception();
        }

        public BusinessBaseException(string code, System.Exception exp)
        {
            ExceptionCode = code;
            InnerException = exp;
        }

        public string GetExceptionText()
        {
            return GetExceptionText(zh_CN);
        }

        public string GetExceptionText(string lang)
        {
            ExceptionElement el = ListExceptionElement.Find(a => a.Code == ExceptionCode);
            if (el != null)
            {
                switch (lang)
                {
                    case zh_CN:
                        return el.MsgCn;
                    case en_US:
                        return el.MsgEn;
                    default:
                        return el.MsgCn;
                }
            }

            return string.Empty;
        }

    }
}
