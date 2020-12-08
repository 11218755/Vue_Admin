using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class AddContactWayReq
    {
        //must 联系方式类型,1-单人, 2-多人
        public int type { get; set; }
        //must 场景，1-在小程序中联系，2-通过二维码联系，3-在线问诊
        public int scene { get; set; }
        //在小程序中联系时使用的控件样式，详见附表
        public int? style { get; set; }
        //联系方式的备注信息，用于助记，不超过30个字符
        public string remark { get; set; }
        //外部客户添加时是否无需验证，默认为true
        public bool? skip_verify { get; set; }
        //企业自定义的state参数，用于区分不同的添加渠道，在调用“获取外部联系人详情”时会返回该参数值，不超过30个字符
        public string state { get; set; }
        //使用该联系方式的用户userID列表，在type为1时为必填，且只能有一个
        public string[] user { get; set; }
        //使用该联系方式的部门id列表，只在type为2时有效
        public int[] party { get; set; }
    }
}
