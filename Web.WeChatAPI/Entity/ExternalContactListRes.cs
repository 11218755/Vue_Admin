using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class ExternalContactListRes : BaseRes
    {
        //外部联系人的userid列表
        public string[] external_userid { get; set; }
    }
}
