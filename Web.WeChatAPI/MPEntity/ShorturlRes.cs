using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 长连接转短连接
    /// </summary>
    public class ShorturlRes : BaseRes
    {
        public string short_url { get; set; }
    }
}