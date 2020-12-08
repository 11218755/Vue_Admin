using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class GroupchatStatisticRes : BaseRes
    {
        //命中过滤条件的记录总个数
        public int total { get; set; }
        //当前分页的下一个offset。当next_offset和total相等时，说明已经取完所有
        public int next_offset { get; set; }
        //记录列表。表示某个群主所拥有的客户群的统计数据
        public List<GroupchatStatisticItems> items { get; set; }
    }
    public class GroupchatStatisticItems
    {
        //群主ID
        public string owner { get; set; }
        //详情
        public GroupchatStatisticItemsData data { get; set; }

    }
    public class GroupchatStatisticItemsData
    {
        //新增客户群数量
        public int new_chat_cnt { get; set; }
        //截至当天客户群总数量
        public int chat_total { get; set; }
        //截至当天有发过消息的客户群数量
        public int chat_has_msg { get; set; }
        //客户群新增群人数
        public int new_member_cnt { get; set; }
        //截至当天客户群总人数
        public int member_total { get; set; }
        //截至当天有发过消息的群成员数
        public int member_has_msg { get; set; }
        //截至当天客户群消息总数
        public int msg_total { get; set; }
    }
}
