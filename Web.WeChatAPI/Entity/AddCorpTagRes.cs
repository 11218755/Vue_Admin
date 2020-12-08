using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class AddCorpTagRes : BaseRes
    {
        public AddTagGroupRes tag_group { get; set; }
    }
    public class AddTagGroupRes
    {
        //标签组id
        public string group_id { get; set; }
        //标签组名称
        public string group_name { get; set; }
        //标签组创建时间
        public long create_time { get; set; }
        //标签组排序的次序值，order值大的排序靠前。有效的值范围是[0, 2^32)
        public int order { get; set; }
        //标签组内的标签列表
        public List<AddTagArrRes> tag { get; set; }
    }
    public class AddTagArrRes
    {
        //标签id
        public string id { get; set; }
        //标签名称
        public string name { get; set; }
        //标签创建时间
        public long create_time { get; set; }
        //标签排序的次序值，order值大的排序靠前。有效的值范围是[0, 2^32)
        public int order { get; set; }
    }
}
