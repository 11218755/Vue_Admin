using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 上传多图文素材
    /// </summary>
    public class Media_UploadnewsRes : BaseRes
    {
        public string type { get; set; }
        public string media_id { get; set; }
        public string created_at { get; set; }
    }
}