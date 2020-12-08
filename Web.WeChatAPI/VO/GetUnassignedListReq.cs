using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class GetUnassignedListReq
    {
        //分页查询，要查询页号，从0开始
        public int? page_id { get; set; }
        //每次返回的最大记录数，默认为1000，最大值为1000
        public int? page_size { get; set; }
    }
}
