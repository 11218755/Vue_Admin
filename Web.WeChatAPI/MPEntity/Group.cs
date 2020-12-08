using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 用户分组
    /// </summary>
    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
    }
}