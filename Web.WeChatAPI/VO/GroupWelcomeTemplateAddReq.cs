using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class GroupWelcomeTemplateAddReq
    {
        public MsgText text { get; set; }
        public MsgImage image { get; set; }
        public MsgLink link { get; set; }
        public MsgMiniprogram miniprogram { get; set; }
    }
}
