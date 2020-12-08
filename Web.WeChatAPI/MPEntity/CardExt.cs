using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class CardExt
    {
        public string code { get; set; }
        public string openid { get; set; }
        public string timestamp { get; set; }
        public string signature { get; set; }
    }
}