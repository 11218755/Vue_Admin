using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class GroupchatTransferRes : BaseRes
    {
        //没能成功继承的群
        public List<FailedChatListObj> failed_chat_list { get; set; }
    }
    public class FailedChatListObj
    {
        //没能成功继承的群ID
        public string chat_id { get; set; }
        //没能成功继承的群，错误码
        public int errcode { get; set; }
        //没能成功继承的群，错误描述
        public string errmsg { get; set; }
    }
}
