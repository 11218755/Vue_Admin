using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class EditCorpTagReq
    {
        //must 标签或标签组的id列表
        public string id { get; set; }
        //新的标签或标签组名称，最长为30个字符
        public string name { get; set; }
        //标签排序的次序值，order值大的排序靠前。有效的值范围是[0, 2^32)
        public int? order { get; set; }
    }
}
