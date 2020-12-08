using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class Datacube_GetupstreammsgdistweekRes : BaseRes
    {
        public List<Upstreammsgdistweek> list { get; set; }
    }

    public class Upstreammsgdistweek
    {
        public string ref_date { get; set; }
        public int count_interval { get; set; }
        public int msg_user { get; set; }
    }
}