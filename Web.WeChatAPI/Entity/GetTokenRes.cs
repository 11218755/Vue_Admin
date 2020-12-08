using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取AccessToken
    /// </summary>
    public class GetTokenRes : BaseRes
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
