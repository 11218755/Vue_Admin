using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取标签成员
    /// </summary>
    public class TagGetRes : BaseRes
    {
        public List<UserSimple> userlist { get; set; }
        public List<int> partylist { get; set; }
    }
}
