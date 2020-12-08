using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取部门成员
    /// </summary>
    public class ScheduleGetbyCalendar
    {
        public string cal_id { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }

    }



}
