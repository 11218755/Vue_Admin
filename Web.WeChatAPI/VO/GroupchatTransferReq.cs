using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class GroupchatTransferReq
    {
        //must 需要转群主的客户群ID列表。取值范围： 1 ~ 100
        public string[] chat_id_list { get; set; }
        //must 新群主ID
        public string new_owner { get; set; }
    }
}
