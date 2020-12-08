using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 获取用户列表反馈
    /// </summary>
    public class User_GetRes : BaseRes
    {
        public int total { get; set; }
        public int count { get; set; }
        public User_Get_Data data { get; set; }
        public string next_openid { get; set; }
    }

    public class User_Get_Data
    {
        public List<string> openid { get; set; }
    }
}