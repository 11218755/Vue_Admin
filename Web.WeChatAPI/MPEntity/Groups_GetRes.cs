using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 获取全部用户分组
    /// </summary>
    public class Groups_GetRes : BaseRes
    {
        public List<Group> tags { get; set; }
    }
}