using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取部门成员(详情)
    /// </summary>
    public class UserListRes : BaseRes
    {
        public List<UserGetRes> userlist { get; set; }
    }
}
