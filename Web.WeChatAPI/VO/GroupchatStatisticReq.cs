using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class GroupchatStatisticReq
    {
        //msut 开始时间，填当天开始的0分0秒（否则系统自动处理为当天的0分0秒）。取值范围：昨天至前60天
        public long day_begin_time { get; set; }
        //群主过滤，如果不填，表示获取全部群主的数据
        public OwnerFilterObj owner_filter { get; set; }
        //排序方式。 1 - 新增群的数量 2 - 群总数 3 - 新增群人数 4 - 群总人数 默认为1
        public int? order_by { get; set; }
        //是否升序。0-否；1-是。默认降序
        public int? order_asc { get; set; }
        //分页，偏移量, 默认为0
        public int? offset { get; set; }
        //分页，预期请求的数据量，默认为500，取值范围 1 ~ 1000
        public int? limit { get; set; }
    }
    public class OwnerFilterObj
    {
        //群主ID列表。最多100个
        public string[] userid_list { get; set; }
        //群主所属部门ID列表。最多100个
        public int[] partyid_list { get; set; }
    }
}
