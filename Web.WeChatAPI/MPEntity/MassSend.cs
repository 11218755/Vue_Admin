using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    /// <summary>
    /// 群发
    /// </summary>
    public class MassSend
    {
        public List<string> touser { get; set; }
        public bool is_to_all { get; set; }
        public string group_id { get; set; }
        public string msgtype { get; set; }

        #region mpnews voice image mpvideo
        public string media_id { get; set; }
        #endregion

        #region text
        public string content { get; set; }
        #endregion

        #region mpvideo
        public string base_media_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        #endregion

        #region wxcard
        public string card_id { get; set; }
        public CardExt card_ext { get; set; }
        #endregion




    }
}