using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取部门成员
    /// </summary>
    public class ScheduleGetRes : BaseRes
    {
        public List<Schedule> schedule_list { get; set; } //组织者。注意，暂不支持变更组织者
    }



}
