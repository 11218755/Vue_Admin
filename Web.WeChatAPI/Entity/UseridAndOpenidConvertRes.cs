using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// userid与openid互转接口
    /// </summary>
    public class UseridAndOpenidConvertRes : BaseRes
    {
        public string openid { get; set; }
        public string appid { get; set; }
        public string userid { get; set; }
    }
}
