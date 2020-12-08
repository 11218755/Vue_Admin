using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class GetGroupMsgResultRes : BaseRes
    {
        //模板消息的审核状态 0-审核中 1-审核成功 2-审核失败
        public int check_status { get; set; }
        public List<DetailListObj> detail_list { get; set; }
    }
    public class DetailListObj
    {
        //外部联系人userid
        public string external_userid { get; set; }
        //企业服务人员的userid
        public string userid { get; set; }
        //发送状态 0-未发送 1-已发送 2-因客户不是好友导致发送失败 3-因客户已经收到其他群发消息导致发送失败
        public int status { get; set; }
        //发送时间，发送状态为1时返回
        public long send_time { get; set; }
    }
}
