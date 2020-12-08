using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 平台消息发送结果
    /// </summary>
    public class Template_SendRes : BaseRes
    {
        public string msgid { get; set; }
    }
}