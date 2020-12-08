using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 获取模版Iid
    /// </summary>
    public class Template_Api_add_templateRes : BaseRes
    {
        public string template_id { get; set; }
    }
}