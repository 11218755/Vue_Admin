namespace Web.WeChatAPI.Entity
{
    public class LivingInfo
    {    
        //	直播主题
        public string theme { get; set; }
        //直	直播开始时间戳
        public long living_start { get; set; }
        //	直播时长，单位为秒
        public long living_duration { get; set; }
        //主播的userid
        public string anchor_userid { get; set; }
        //主播所在主部门id
        public int main_department { get; set; }
        //观看直播总人数
        public long viewer_num { get; set; }
        
        //	评论数
        public int comment_num { get; set; }
        
        //	连麦发言人数
        public int mic_num { get; set; }
        
        // 是否开启回放，1表示开启，0表示关闭
        public int open_replay { get; set; }
        
        
    }
}