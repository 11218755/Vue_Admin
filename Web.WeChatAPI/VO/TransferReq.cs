using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class TransferReq
    {
        //must 外部联系人的userid，注意不是企业成员的帐号
        public string external_userid { get; set; }
        //must 离职成员的userid
        public string handover_userid { get; set; }
        //msut 接替成员的userid
        public string takeover_userid { get; set; }
    }
}
