using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class Datacube_GetupstreammsgdistRes : BaseRes
    {
        public List<Upstreammsgdist> list { get; set; }
    }

    public class Upstreammsgdist
    {
        public string ref_date { get; set; }
        public int count_interval { get; set; }
        public int msg_user { get; set; }
    }
}