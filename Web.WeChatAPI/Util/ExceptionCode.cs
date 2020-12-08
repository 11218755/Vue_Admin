using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Util
{
    public class ExceptionCode
    {
        public const string InvalidLibraryID = "200001";
        public const string WechatCannotDelete = "200002";
        public const string WechatApiError = "200003";
        public const string ExistsAdminUser = "200004";
        public const string NoPermission = "200005";
        public const string ChangeUserPwdFail = "200006";
        public const string ResetUserPwdFail = "200007";
        public const string NoDataPermission = "200008";
        public const string REFTHISROLE = "200009";
        public const string InvalidCredentials = "200010";
    }
}
