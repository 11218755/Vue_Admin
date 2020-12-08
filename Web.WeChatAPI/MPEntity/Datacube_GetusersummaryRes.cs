using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class Datacube_GetusersummaryRes : BaseRes
    {
        public List<Datacube> list { get; set; }
    }

    public class Datacube
    {
        public string ref_date { get; set; }
        public int user_source { get; set; }
        public int new_user { get; set; }
        public int cancel_user { get; set; }
        public int cumulate_user { get; set; }
    }
}