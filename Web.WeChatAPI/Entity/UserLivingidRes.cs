using System.Collections.Generic;

namespace Web.WeChatAPI.Entity
{
    public class UserLivingidRes : BaseRes
    {
        public string ending { get; set; }
        
        public string next_key { get; set;  }
        
        public List<string> livingid_list { get; set; }
        
    }
}