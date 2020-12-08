using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class UpdateContactWayReq
    {
        //must 企业联系方式的配置id
        public string config_id { get; set; }
        //联系方式的备注信息，不超过30个字符，将覆盖之前的备注
        public string remark { get; set; }
        //外部客户添加时是否无需验证
        public bool? skip_verify { get; set; }
        //样式，只针对“在小程序中联系”的配置生效
        public int? style { get; set; }
        //企业自定义的state参数，用于区分不同的添加渠道，在调用“获取外部联系人详情”时会返回该参数值
        public string state { get; set; }
        //使用该联系方式的用户列表，将覆盖原有用户列表
        public string[] user { get; set; }
        //使用该联系方式的部门列表，将覆盖原有部门列表，只在配置的type为2时有效
        public int[] party { get; set; }

    }
}
