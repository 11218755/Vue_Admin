using Web.WeChatAPI.VO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class GroupWelcomeTemplateGetRes : BaseRes
    {
        public MsgText text { get; set; }
        public MsgImage image { get; set; }
        public MsgLink link { get; set; }
        public MsgMiniprogram miniprogram { get; set; }
    }
}
