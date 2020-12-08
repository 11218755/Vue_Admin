using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class Datacube_GetupstreammsgRes : BaseRes
    {
        public List<Upstreammsg> list { get; set; }
    }

    public class Upstreammsg
    {
        public string ref_date { get; set; }
        public int msg_type { get; set; }
        public int msg_user { get; set; }
        public int msg_count { get; set; }
    }
}