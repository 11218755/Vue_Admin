using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class MaterialCount : BaseRes
    {
        public int voice_count { get; set; }
        public int video_count { get; set; }
        public int image_count { get; set; }
        public int news_count { get; set; }
    }
}
