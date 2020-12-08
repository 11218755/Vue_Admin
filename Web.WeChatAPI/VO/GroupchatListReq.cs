using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class GroupchatListReq
    {
        //群状态过滤。 0 - 普通列表 1 - 离职待继承 2 - 离职继承中 3 - 离职继承完成 默认为0
        public int? status_filter { get; set; }
        //群主过滤。如果不填，表示获取全部群主的数据
        public OwnerFilter owner_filter { get; set; }
        //must 分页，偏移量
        public int offset { get; set; }
        //must 分页，预期请求的数据量，取值范围 1 ~ 1000
        public int limit { get; set; }
    }
    public class OwnerFilter
    {
        //用户ID列表。最多100个
        public string[] userid_list { get; set; }
        //部门ID列表。最多100个
        public int[] partyid_list { get; set; }
    }
}
