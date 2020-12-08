using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class GetContactWayRes :BaseRes
    {
        public ContactWay contact_way { get; set; }
    }

    public class ContactWay {
        //新增联系方式的配置id
        public string config_id { get; set; }
        //联系方式类型，1-单人，2-多人
        public string type { get; set; }
        //场景，1-在小程序中联系，2-通过二维码联系，3-在线问诊
        public string scene { get; set; }
        //联系方式的备注信息，用于助记
        public string remark { get; set; }
        //外部客户添加时是否无需验证
        public bool skip_verify { get; set; }
        //企业自定义的state参数，用于区分不同的添加渠道，在调用“获取外部联系人详情”时会返回该参数值
        public string state { get; set; }
        //小程序中联系按钮的样式，仅在scene为1时返回，详见附录
        public string style { get; set; }
        //联系二维码的URL，仅在scene为2时返回
        public string qr_code { get; set; }
        //使用该联系方式的用户userID列表
        public string[] user { get; set; }
        //使用该联系方式的部门id列表
        public string[] party { get; set; }
    }
}
