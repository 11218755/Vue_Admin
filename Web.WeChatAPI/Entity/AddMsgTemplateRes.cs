using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class AddMsgTemplateRes : BaseRes
    {
        //无效或无法发送的external_userid列表
        public string[] fail_list { get; set; }
        //企业群发消息的id，可用于获取群发消息发送结果
        public string msgid { get; set; }
    }
}
