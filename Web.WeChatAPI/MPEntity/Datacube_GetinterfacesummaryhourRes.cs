using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class Datacube_GetinterfacesummaryhourRes : BaseRes
    {
        public List<Interfacesummaryhour> list { get; set; }
    }

    public class Interfacesummaryhour
    {
        public string ref_date { get; set; }
        public int ref_hour { get; set; }
        public int callback_count { get; set; }
        public int fail_count { get; set; }
        public int total_time_cost { get; set; }
        public int max_time_cost { get; set; }
    }
}