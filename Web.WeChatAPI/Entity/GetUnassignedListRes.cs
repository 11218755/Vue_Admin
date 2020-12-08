using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class GetUnassignedListRes : BaseRes
    {
        public List<InfoObj> info { get; set; }
        //是否是最后一条记录
        public bool is_last { get; set; }
    }
    public class InfoObj
    {
        //离职成员的userid
        public string handover_userid { get; set; }
        //外部联系人userid
        public string external_userid { get; set; }
        //成员离职时间
        public long dimission_time { get; set; }
    }
}
