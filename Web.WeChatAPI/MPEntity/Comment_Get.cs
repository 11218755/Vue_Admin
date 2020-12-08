using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class Comment_Get : BaseRes
    {
        public List<Comment> comment { get; set; }
        public int total { get; set; }
    }
}
