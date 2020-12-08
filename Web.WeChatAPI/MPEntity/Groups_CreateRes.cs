using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 创建组
    /// </summary>
    public class Groups_CreateRes : BaseRes
    {
        public Group group { get; set; }
    }
}