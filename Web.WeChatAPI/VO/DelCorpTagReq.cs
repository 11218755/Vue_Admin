using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class DelCorpTagReq
    {
        //标签的id列表
        public string[] tag_id { get; set; }
        //标签组的id列表
        public string[] group_id { get; set; }
    }
}
