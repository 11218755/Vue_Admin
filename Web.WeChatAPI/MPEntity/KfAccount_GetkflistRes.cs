using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 获取客服列表
    /// </summary>
    public class KfAccount_GetkflistRes : BaseRes
    {
        public List<Mp_KF> kf_list { get; set; }
    }

    public class Mp_KF
    {
        public string kf_account { get; set; }
        public string kf_nick { get; set; }
        public string kf_id { get; set; }
        public string kf_headimgurl { get; set; }
    }
}