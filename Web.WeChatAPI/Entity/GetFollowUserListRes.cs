using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class GetFollowUserListRes : BaseRes
    {
        //配置了客户联系功能的成员userid列表
        public string[] follow_user { get; set; }
    }
}
