using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.PlatformEntity
{
    /// <summary>
    /// 企业成员拓展字段类
    /// </summary>
    public class QYUSER_VIEW
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
    }
}
