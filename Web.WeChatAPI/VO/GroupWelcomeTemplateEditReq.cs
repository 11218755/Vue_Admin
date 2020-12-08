using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class GroupWelcomeTemplateEditReq
    {
        //must 欢迎语素材id
        public string template_id { get; set; }
        public MsgText text { get; set; }
        public MsgImage image { get; set; }
        public MsgLink link { get; set; }
        public MsgMiniprogram miniprogram { get; set; }
        /*
         image、link和miniprogram只能有一个，如果三者同时填，则按image、link、miniprogram的优先顺序取参，也就是说，如果image与link同时传值，则只有image生效。
         */
    }
}
