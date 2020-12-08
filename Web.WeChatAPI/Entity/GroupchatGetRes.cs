using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class GroupchatGetRes : BaseRes
    {
        //客户群详情
        public GroupChatObj group_chat { get; set; }
    }
    public class GroupChatObj
    {
        //客户群ID
        public string chat_id { get; set; }
        //群名
        public string name { get; set; }
        //群主ID
        public string owner { get; set; }
        //群的创建时间
        public long create_time { get; set; }
        //群公告
        public string notice { get; set; }
        //群成员列表
        public List<MemberListObj> member_list { get; set; }
    }
    public class MemberListObj
    {
        //群成员id
        public string userid { get; set; }
        //成员类型。 1 - 企业成员 2 - 外部联系人
        public int type { get; set; }
        //入群时间
        public long join_time { get; set; }
        //入群方式。 1 - 由成员邀请入群（直接邀请入群） 2 - 由成员邀请入群（通过邀请链接入群） 3 - 通过扫描群二维码入群
        public int join_scene { get; set; }
    }
}
