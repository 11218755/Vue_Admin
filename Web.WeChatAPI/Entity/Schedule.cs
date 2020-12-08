using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取部门成员
    /// </summary>
    public class Schedule : BaseRes
    {
        public string organizer { get; set; } //组织者。注意，暂不支持变更组织者
        public string schedule_id { get; set; }//
        public int start_time { get; set; }//日程开始时间，Unix时间戳
        public int end_time { get; set; }//日程结束时间，Unix时间戳
        public List<SUserInfo> attendees { get; set; }//日程参与者列表。最多支持2000人
        public string summary { get; set; }//	日程标题。0 ~ 128 字符。不填会默认显示为“新建事件
        public string description { get; set; }//	日程描述。0 ~ 512 字符
        public Reminders reminders { get; set; }
        public string location { get; set; }//日程地址。0 ~ 128 字符
        public string cal_id { get; set; }//日程所属日历ID。注意，这个日历必须是属于组织者(organizer)的日历；如果不填，那么插入到组织者的默认日历上
        public string[] userid { get; set; }//日历共享成员的id
    }
    public class Reminders
    {
        public int is_remind { get; set; }//是否需要提醒。0-否；1-是
        public int repeat_type { get; set; }//重复类型，当is_repeat为1时有效。目前支持如下类型：0 - 每日;1 - 每周;2 - 每月;5 - 每年;7 - 工作日;
        public int remind_before_event_secs { get; set; }//
        public int is_repeat { get; set; }//是否重复日程。0-否；1-是
    }


    public class SUserInfo
    {
        public string userid { get; set; }

    }



}
