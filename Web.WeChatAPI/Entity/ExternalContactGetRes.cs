using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    public class ExternalContactGetRes : BaseRes
    {
        public ExternalContact external_contact { get; set; }
        public List<FollowUser> follow_user { get; set; }
    }
    public class ExternalContact
    {
        //外部联系人的userid
        public string external_userid { get; set; }
        //外部联系人的名称*
        public string name { get; set; }
        //外部联系人头像，第三方不可获取
        public string avatar { get; set; }
        //外部联系人的类型，1表示该外部联系人是微信用户，2表示该外部联系人是企业微信用户
        public int type { get; set; }
        //外部联系人性别 0-未知 1-男性 2-女性
        public int gender { get; set; }
        //外部联系人在微信开放平台的唯一身份标识（微信unionid）
        //通过此字段企业可将外部联系人与公众号/小程序用户关联起来
        //仅当联系人类型是微信用户，且企业或第三方服务商绑定了微信开发者ID有此字段
        public string unionid { get; set; }
        //外部联系人的职位，如果外部企业或用户选择隐藏职位，则不返回，仅当联系人类型是企业微信用户时有此字段
        public string position { get; set; }
        //外部联系人所在企业的简称，仅当联系人类型是企业微信用户时有此字段
        public string corp_name { get; set; }
        //外部联系人所在企业的主体名称，仅当联系人类型是企业微信用户时有此字段
        public string corp_full_name { get; set; }
        //外部联系人的自定义展示信息，可以有多个字段和多种类型，包括文本，网页和小程序，仅当联系人类型是企业微信用户时有此字段，字段详情见对外属性；
        public ExternalProfile external_profile { get; set; }
    }
    public class ExternalProfile
    {
        public List<ExternalAttr> external_attr { get; set; }
    }
    public class ExternalAttr
    {
        public int type { get; set; }
        public string name { get; set; }
        public ExternalAttrText text { get; set; }
        public ExternalAttrWeb web { get; set; }
        public ExternalAttrMiniprogram miniprogram { get; set; }
    }
    public class ExternalAttrText
    {
        public string value { get; set; }
    }
    public class ExternalAttrWeb
    {
        public string url { get; set; }
        public string title { get; set; }
    }
    public class ExternalAttrMiniprogram
    {
        public string appid { get; set; }
        public string pagepath { get; set; }
        public string title { get; set; }
    }
    public class FollowUser
    {
        //添加了此外部联系人的企业成员userid
        public string userid { get; set; }
        //该成员对此外部联系人的备注
        public string remark { get; set; }
        //该成员对此外部联系人的描述
        public string description { get; set; }
        //该成员添加此外部联系人的时间
        public long createtime { get; set; }
        public List<FollowUserTags> tags { get; set; }
        //该成员对此客户备注的企业名称
        public string remark_corp_name { get; set; }
        //该成员对此客户备注的手机号码，第三方不可获取
        public string[] remark_mobiles { get; set; }
        //该成员添加此客户的渠道，由用户通过创建「联系我」方式指定
        public string state { get; set; }
    }
    public class FollowUserTags
    {
        //该成员添加此外部联系人所打标签的分组名称（标签功能需要企业微信升级到2.7.5及以上版本）
        public string group_name { get; set; }
        //该成员添加此外部联系人所打标签名称
        public string tag_name { get; set; }
        //该成员添加此外部联系人所打标签类型, 1-企业设置, 2-用户自定义
        public int type { get; set; }
    }
}
