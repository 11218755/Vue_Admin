using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class GetCorpTagListRes : BaseRes
    {
        //标签组列表
        public List<TagGroup> tag_group { get; set; }
    }
    public class TagGroup
    {
        //标签组id
        public string group_id { get; set; }
        //标签组名称
        public string group_name { get; set; }
        //标签组创建时间
        public long create_time { get; set; }
        //标签组排序的次序值，order值大的排序靠前。有效的值范围是[0, 2^32)
        public int order { get; set; }
        //标签组是否已经被删除，只在指定tag_id进行查询时返回
        public bool deleted { get; set; }
        //标签组内的标签列表
        public List<TagArr> tag { get; set; }
    }
    public class TagArr
    {
        //标签id
        public string id { get; set; }
        //标签名称
        public string name { get; set; }
        //标签创建时间
        public long create_time { get; set; }
        //标签排序的次序值，order值大的排序靠前。有效的值范围是[0, 2^32)
        public int order { get; set; }
        //标签是否已经被删除，只在指定tag_id进行查询时返回
        public bool deleted { get; set; }
    }

    public class TagArrExt : TagArr
    {
        //标签组名称
        public string group_name { get; set; }
    }
}
