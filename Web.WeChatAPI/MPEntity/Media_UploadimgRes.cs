using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 上传图文消息内的图片获取URL
    /// </summary>
    public class Media_UploadimgRes : BaseRes
    {
        public string url { get; set; }
    }
}