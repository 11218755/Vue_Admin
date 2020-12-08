using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取部门成员
    /// </summary>
    public class CalendarAddRes : BaseRes
    {
       public string cal_id { get; set; } //组织者。注意，暂不支持变更组织者

    }

}
