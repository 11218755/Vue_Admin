using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class MarkTagReq
    {
        //must 添加外部联系人的userid
        public string userid { get; set; }
        //must 外部联系人userid
        public string external_userid { get; set; }
        //要标记的标签列表
        public string[] add_tag { get; set; }
        //要移除的标签列表
        public string[] remove_tag { get; set; }
    }
}
