using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class Datacube_GetupstreammsgweekRes : BaseRes
    {
        public List<Upstreammsgweek> list { get; set; }
    }

    public class Upstreammsgweek
    {
        public string ref_date { get; set; }
        public int msg_type { get; set; }
        public int msg_user { get; set; }
        public int msg_count { get; set; }
    }
}