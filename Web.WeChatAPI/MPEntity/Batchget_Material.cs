using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class Batchget_Material : BaseRes
    {
        public int total_count { get; set; }
        public int item_count { get; set; }
        public List<item> item { get; set; }
    }

    public class item
    {
        public string media_id { get; set; }
        public Media_NewsItem content { get; set; }
        public string update_time { get; set; }
    }
}
