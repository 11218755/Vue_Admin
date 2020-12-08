using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class GetUserBehaviorDataRes : BaseRes
    {
        //用户ID列表
        public List<BehaviorDataObj> behavior_data { get; set; }
    }
    public class BehaviorDataObj
    {
        //数据日期，为当日0点的时间戳
        public long stat_time { get; set; }
        //聊天总数， 成员有主动发送过消息的聊天数，包括单聊和群聊
        public int chat_cnt { get; set; }
        //发送消息数，成员在单聊和群聊中发送的消息总数
        public int message_cnt { get; set; }
        //已回复聊天占比，客户主动发起聊天后，成员在一个自然日内有回复过消息的聊天数/客户主动发起的聊天数比例，不包括群聊，仅在确有回复时返回
        public double reply_percentage { get; set; }
        //平均首次回复时长，单位为分钟，即客户主动发起聊天后，成员在一个自然日内首次回复的时长间隔为首次回复时长
        //所有聊天的首次回复总时长/已回复的聊天总数即为平均首次回复时长，不包括群聊，仅在确有回复时返回
        public int avg_reply_time { get; set; }
        //删除/拉黑成员的客户数，即将成员删除或加入黑名单的客户数
        public int negative_feedback_cnt { get; set; }
        //发起申请数，成员通过「搜索手机号」、「扫一扫」、「从微信好友中添加」、「从群聊中添加」、「添加共享、分配给我的客户」、
        //「添加单向、双向删除好友关系的好友」、「从新的联系人推荐中添加」等渠道主动向客户发起的好友申请数量
        public int new_apply_cnt { get; set; }
        //新增客户数，成员新添加的客户数量
        public int new_contact_cnt { get; set; }
    }
}
