using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 查询用户所在分组
    /// </summary>
    public class Groups_GetidRes : BaseRes
    {
        public int groupid { get; set; }
    }
}