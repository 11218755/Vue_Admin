using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class Datacube_GetuserreadhourRes : BaseRes
    {
        public List<Userreadhour> list { get; set; }
    }

    public class Userreadhour
    {
        public string ref_date { get; set; }
        public int ref_hour { get; set; }
        public int user_source { get; set; }
        public int int_page_read_user { get; set; }
        public int int_page_read_count { get; set; }
        public int ori_page_read_user { get; set; }
        public int ori_page_read_count { get; set; }
        public int share_user { get; set; }
        public int share_count { get; set; }
        public int add_to_fav_user { get; set; }
        public int add_to_fav_count { get; set; }
    }
}