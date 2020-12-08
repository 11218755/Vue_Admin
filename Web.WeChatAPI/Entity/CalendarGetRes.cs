using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取部门成员
    /// </summary>
    public class CalendarGetRes : BaseRes
    {
        public List<Calendar> calendar_list { get; set; } //组织者。注意，暂不支持变更组织者
    }



}
