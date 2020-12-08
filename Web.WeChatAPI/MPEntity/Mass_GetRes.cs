using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 群发进度
    /// </summary>
    public class Mass_GetRes : BaseRes
    {
        public string msg_id { get; set; }
        public string msg_status { get; set; }
    }
}