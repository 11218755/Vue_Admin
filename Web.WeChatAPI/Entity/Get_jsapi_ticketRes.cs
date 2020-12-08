using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// JS-SDK使用权限签名算法
    /// </summary>
    public class Get_jsapi_ticketRes : BaseRes
    {
        public string ticket { get; set; }
        public int expires_in { get; set; }
    }
}
