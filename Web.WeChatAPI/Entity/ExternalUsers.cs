namespace Web.WeChatAPI.Entity
{
    public class ExternalUsers
    {
        public string external_userid { get; set; }
        
        public int? type { get; set; }
        
        public string name { get; set; }
        public long watch_time { get; set; }
        public int is_comment { get; set; }
        public int is_mic { get; set; }
        
    }
}