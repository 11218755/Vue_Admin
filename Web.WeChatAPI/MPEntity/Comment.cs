using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class Comment
    {
        public int user_comment_id { get; set; }
        public string openid { get; set; }
        public DateTime create_time { get; set; }
        public string content { get; set; }
        public int comment_type { get; set; }
        public List<Reply> reply { get; set; }
    }
    
}
