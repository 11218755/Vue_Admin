using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取临时素材文件
    /// </summary>
    public class MediaGetRes : BaseRes
    {
        public string filename { get; set; }
    }
}
