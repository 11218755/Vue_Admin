using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class AddCorpTagReq
    {
        //标签组id
        public string group_id { get; set; }
        //标签组名称，最长为30个字符
        public string group_name { get; set; }
        //标签组次序值。order值大的排序靠前。有效的值范围是[0, 2^32)
        public int? order { get; set; }
        //标签组内的标签列表
        public List<AddTagArrReq> tag { get; set; }
    }
    public class AddTagArrReq
    {
        //must 添加的标签名称，最长为30个字符
        public string name { get; set; }
        //标签次序值。order值大的排序靠前。有效的值范围是[0, 2^32)
        public string order { get; set; }
    }
}
