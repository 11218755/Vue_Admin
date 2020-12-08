using Web.WeChatAPI.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.MPEntity
{
    public class Media_NewsItem : BaseRes
    {
        public List<ArticlesMp> news_item { get; set; }
    }
}
