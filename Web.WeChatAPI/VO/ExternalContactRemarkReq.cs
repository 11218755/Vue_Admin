using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class ExternalContactRemarkReq
    {
        //must 企业成员的userid
        public string userid { get; set; }
        //must 外部联系人userid
        public string external_userid { get; set; }
        //此用户对外部联系人的备注
        public string remark { get; set; }
        //此用户对外部联系人的描述
        public string description { get; set; }
        //此用户对外部联系人备注的所属公司名称
        public string remark_company { get; set; }
        //此用户对外部联系人备注的手机号
        public string[] remark_mobiles { get; set; }
        //备注图片的mediaid
        public string remark_mediaid { get; set; }
    }
}
