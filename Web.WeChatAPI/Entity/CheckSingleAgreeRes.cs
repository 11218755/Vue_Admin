using System.Collections.Generic;

namespace Web.WeChatAPI.Entity
{
    public class CheckSingleAgreeRes : BaseRes
    {
        public List<CheckSingleAgree> agreeinfo { get; set; }
    }
}