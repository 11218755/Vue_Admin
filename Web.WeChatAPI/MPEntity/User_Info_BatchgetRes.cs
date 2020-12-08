using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class User_Info_BatchgetRes : BaseRes
    {
        public List<User_InfoRes> user_info_list { get; set; }
    }
}