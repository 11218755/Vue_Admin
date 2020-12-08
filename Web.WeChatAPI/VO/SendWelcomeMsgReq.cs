using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class SendWelcomeMsgReq
    {
        //msut 通过添加外部联系人事件推送给企业的发送欢迎语的凭证，有效期为20秒
        public string welcome_code { get; set; }
        public MsgText text { get; set; }
        public MsgImage image { get; set; }
        public MsgLink link { get; set; }
        public MsgMiniprogram miniprogram { get; set; }
    }
}
