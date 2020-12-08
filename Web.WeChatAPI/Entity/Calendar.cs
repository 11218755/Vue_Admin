using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取部门成员
    /// </summary>
    public class Calendar
    {
       public string organizer { get; set; } //组织者。注意，暂不支持变更组织者
       public string cal_id { get; set; }
       public string color { get; set; }//	日历颜色，RGB颜色编码16进制表示，例如：”#0000FF” 表示纯蓝色
       public string summary { get; set; }//	日程标题。0 ~ 128 字符。不填会默认显示为“新建事件
       public string description { get; set; }//	日程描述。0 ~ 512 字符
       public List<CUserInfo> shares { get; set; }//日历共享成员列表。最多2000人
       public string[] userid { get; set; }//日历共享成员的id
    }

    public class CUserInfo {
        public string userid { get; set; }

    }

}
