using System.Collections.Generic;

namespace Web.WeChatAPI.Entity
{
    public class WatchStatRes : BaseRes
    {    
        //是否结束。0：表示还有更多数据，需要继续拉取，1：表示已经拉取完所有数据。注意只能根据该字段判断是否已经拉完数据
        public int ending { get; set; }
        
        //当前数据最后一个key值，如果下次调用带上该值则从该key值往后拉，用于实现分页拉取
        public string next_key { get; set; }
        
        public StatInfo stat_info { get; set; }
        
        
        
        public class StatInfo
        {
            public List<LivingUser> users { get; set; }
            
            public List<ExternalUsers> external_users { get; set; }
            
        }

    }
}