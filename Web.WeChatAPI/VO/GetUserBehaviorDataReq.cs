using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class GetUserBehaviorDataReq
    {
        //用户ID列表
        public string[] userid { get; set; }
        //部门ID列表
        public int[] partyid { get; set; }
        //must 数据起始时间
        public long start_time { get; set; }
        //must 数据结束时间
        public long end_time { get; set; }
    }
    /*
     * userid和partyid不可同时为空;
    此接口提供的数据以天为维度，查询的时间范围为[start_time,end_time]，即前后均为闭区间，支持的最大查询跨度为30天；
    用户最多可获取最近60天内的数据；
    当传入的时间不为0点时间戳时，会向下取整，如传入1554296400(Wed Apr 3 21:00:00 CST 2019)会被自动转换为1554220800（Wed Apr 3 00:00:00 CST 2019）;
    如传入多个userid，则表示获取这些成员总体的联系客户数据。
     */
}
