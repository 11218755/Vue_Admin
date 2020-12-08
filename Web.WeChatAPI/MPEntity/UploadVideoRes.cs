using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 获取视频资源ID
    /// </summary>
    public class UploadVideoRes : BaseRes
    {
        public string type { get; set; }
        public string media_id { get; set; }
        public string created_at { get; set; }
    }
}