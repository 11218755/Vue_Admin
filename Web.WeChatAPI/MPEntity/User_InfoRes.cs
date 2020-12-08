using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 获取用户消息
    /// </summary>
    public class User_InfoRes : BaseRes
    {
        public int subscribe { get; set; }
        public string openid { get; set; }
        public string nickname { get; set; }
        public int sex { get; set; }
        public string language { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        public int subscribe_time { get; set; }
        public string unionid { get; set; }
        public string remark { get; set; }
        public int groupid { get; set; }
        public List<int> tagid_list { get; set; }
        public string subscribe_scene { get; set; }
        public string qr_scene { get; set; }
        public string qr_scene_str { get; set; }

    }
}