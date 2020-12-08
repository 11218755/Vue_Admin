using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取微信服务器的ip段
    /// </summary>
    public class GetCallBackIpRes : BaseRes
    {
        public List<string> ip_list { get; set; }
    }
}
