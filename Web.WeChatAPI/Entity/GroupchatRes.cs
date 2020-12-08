using System.Collections.Generic;

namespace Web.WeChatAPI.Entity
{
    public class GroupchatRes : BaseRes
    {
        public string roomname { get; set; }
        
        public string creator { get; set; }
        
        public long room_create_time { get; set; }
        
        public string notice { get; set; }
        
        public List<Member> members { get; set; }
    }
}