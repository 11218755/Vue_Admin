using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.VO
{
    public class AddMsgTemplateReq
    {
        //客户的外部联系人id列表，不可与sender同时为空，最多可传入1万个客户
        public string[] external_userid { get; set; }
        //发送企业群发消息的成员userid，不可与external_userid同时为空
        public string chat_type { get; set; }
        public string sender { get; set; }
        public MsgText text { get; set; }
        public MsgImage image { get; set; }
        public MsgLink link { get; set; }
        public MsgMiniprogram miniprogram { get; set; }
    }
    public class MsgText
    {
        //消息文本内容，最多4000个字节
        public string content { get; set; }
    }
    public class MsgImage
    {
        //must 图片的media_id
        public string media_id { get; set; }
    }
    public class MsgLink
    {
        //must 图文消息标题
        public string title { get; set; }
        //图文消息封面的url
        public string picurl { get; set; }
        //图文消息的描述，最多512个字节
        public string desc { get; set; }
        //msut 图文消息的链接
        public string url { get; set; }
    }
    public class MsgMiniprogram
    {
        //must 小程序消息标题，最多64个字节
        public string title { get; set; }
        //must 小程序消息封面的mediaid，封面图建议尺寸为520*416
        public string pic_media_id { get; set; }
        //msut 小程序appid，必须是关联到企业的小程序应用
        public string appid { get; set; }
        //must 小程序page路径
        public string page { get; set; }
    }
    /*
     text、image、link和miniprogram四者不能同时为空；
    text与另外三者可以同时发送，此时将会以两条消息的形式触达客户
    image、link和miniprogram只能有一个，如果三者同时填，则按image、link、miniprogram的优先顺序取参，也就是说，如果image与link同时传值，则只有image生效。
    media_id可以通过素材管理接口获得。
     */
}
