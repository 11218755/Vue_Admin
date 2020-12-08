using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class GroupchatListRes : BaseRes
    {
        //客户群列表
        public List<GroupChatList> group_chat_list { get; set; }
    }
    public class GroupChatList
    {
        //客户群ID
        public string chat_id { get; set; }
        //客户群状态。 0 - 正常 1 - 跟进人离职 2 - 离职继承中 3 - 离职继承完成
        public string status { get; set; }
    }
}
