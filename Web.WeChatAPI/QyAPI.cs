using Web.WeChatAPI.Entity;
using Web.WeChatAPI.iUtil;
using Web.WeChatAPI.PlatformEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using iPathFramework.iUtil;
using Web.WeChatAPI.VO;

namespace Web.WeChatAPI
{
    /// <summary>
    /// 微信企业号API
    /// </summary>
    public class QyAPI : BaseAPI
    {
        #region 获取Token字符串
        /// <summary>
        /// 获取Token字符串
        /// </summary>
        /// <param name="corpid"></param>
        /// <param name="corpsecret"></param>
        /// <returns></returns>
        public static GetTokenRes GetToken(string corpid, string corpsecret)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}";
            url = string.Format(url, corpid, corpsecret);

            return GetObject<GetTokenRes>(url);
        }
        #endregion

        #region 通讯录管理-成员管理-创建成员
        /// <summary>
        /// 通讯录管理-成员管理-创建成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="position"></param>
        /// <param name="mobile"></param>
        /// <param name="gender"></param>
        /// <param name="email"></param>
        /// <param name="weixinid"></param>
        /// <returns></returns>
        public static BaseRes User_Create(string access_token,
            string userid, string name, int[] department, string position,
            string mobile, int gender, string email, string weixinid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/create?access_token=";
            url += access_token;

            var post = new
            {
                userid = userid,
                name = name,
                department = department,
                position = position,
                mobile = mobile,
                gender = gender,
                email = email,
                weixinid = weixinid
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 通讯录管理-成员管理-获取成员 
        /// <summary>
        /// 通讯录管理-成员管理-获取成员 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static UserGetRes User_Get(string access_token, string userid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}";
            url = string.Format(url, access_token, userid);

            return GetObject<UserGetRes>(url);
        }
        #endregion

        #region  通讯录管理-成员管理-更新成员
        /// <summary>
        /// 通讯录管理-成员管理-更新成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="position"></param>
        /// <param name="mobile"></param>
        /// <param name="gender"></param>
        /// <param name="email"></param>
        /// <param name="weixinid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public static BaseRes User_Update(string access_token,
            string userid, string name, int[] department, string position,
            string mobile, int gender, string email, string weixinid, int enable)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/update?access_token=";
            url += access_token;

            var post = new
            {
                userid = userid,
                name = name,
                department = department,
                position = position,
                mobile = mobile,
                gender = gender,
                email = email,
                weixinid = weixinid,
                enable = enable
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 通讯录管理-成员管理-删除成员
        /// <summary>
        /// 通讯录管理-成员管理-删除成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static BaseRes User_Delete(string access_token, string userid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/delete?access_token={0}&userid={1}";
            url = string.Format(url, access_token, userid);

            return GetObject<BaseRes>(url);
        }
        #endregion

        #region 通讯录管理-成员管理-批量删除成员
        /// <summary>
        /// 通讯录管理-成员管理-删除成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="useridlist"></param>
        /// <returns></returns>
        public static BaseRes User_BatchDelete(string access_token, string[] useridlist)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/batchdelete?access_token=";
            url += access_token;

            var post = new
            {
                useridlist = useridlist
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 通讯录管理-成员管理-获取部门成员
        /// <summary>
        /// 通讯录管理-成员管理-获取成员 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="department_id"></param>
        /// <param name="fetch_child">1/0：是否递归获取子部门下面的成员</param>
        /// <param name="status">0获取全部成员，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加</param>
        /// <returns></returns>
        public static UserSimpleListRes User_SimpleList(string access_token,
            int department_id, int fetch_child, int status)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/simplelist?access_token={0}&department_id={1}&fetch_child={2}&status={3}";
            url = string.Format(url, access_token, department_id, fetch_child, status);

            return GetObject<UserSimpleListRes>(url);
        }
        #endregion

        #region 通讯录管理-成员管理-获取部门成员(详情)
        /// <summary>
        /// 通讯录管理-成员管理-获取部门成员(详情)
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="department_id"></param>
        /// <param name="fetch_child">1/0：是否递归获取子部门下面的成员</param>
        /// <param name="status">0获取全部成员，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加</param>
        /// <returns></returns>
        public static UserListRes User_List(string access_token,
            int department_id, int fetch_child, int status)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/list?access_token={0}&department_id={1}&fetch_child={2}&status={3}";
            url = string.Format(url, access_token, department_id, fetch_child, status);

            return GetObject<UserListRes>(url);
        }
        #endregion

        #region 通讯录管理-成员管理-userid转换成openid接口
        /// <summary>
        /// 通讯录管理-成员管理-userid转换成openid接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="agentid"></param>
        /// <param name="openid"></param>
        /// <param name="appid"></param>
        /// <returns></returns>
        public static UseridAndOpenidConvertRes User_ConvertToOpenid(string access_token,
            string userid, string agentid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/convert_to_openid?access_token={0}";
            url = string.Format(url, access_token);

            if (string.IsNullOrEmpty(agentid))
            {
                var post = new
                {
                    userid = userid
                };

                return PostObject<UseridAndOpenidConvertRes>(url, post);
            }
            else
            {
                var post = new
                {
                    userid = userid,
                    agentid = agentid
                };

                return PostObject<UseridAndOpenidConvertRes>(url, post);
            }
        }
        #endregion

        #region 通讯录管理-成员管理-openid转换成userid接口
        /// <summary>
        /// 通讯录管理-成员管理-openid转换成userid接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static UseridAndOpenidConvertRes User_ConvertToUserid(string access_token, string openid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/convert_to_userid?access_token={0}";
            url = string.Format(url, access_token);

            var post = new
            {
                openid = openid
            };

            return PostObject<UseridAndOpenidConvertRes>(url, post);
        }
        #endregion

        #region 通讯录管理-成员管理-Baxter创建成员  ***
        /// <summary>
        /// 通讯录管理-成员管理-Baxter创建成员  ***
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="position"></param>
        /// <param name="mobile"></param>
        /// <param name="gender"></param>
        /// <param name="email"></param>
        /// <param name="weixinid"></param>
        /// <param name="attrs"></param>
        /// <returns></returns>
        public static BaseRes User_Create_Baxter(string access_token,
            string userid, string name, int[] department, string position,
            string mobile, int gender, string email, string weixinid, List<ATTRS_VIEW> attrs)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/create?access_token=";
            url += access_token;

            var post = new
            {
                userid = userid,
                name = name,
                department = department,
                position = position,
                mobile = mobile,
                gender = gender,
                email = email,
                weixinid = weixinid,
                extattr = new
                {
                    attrs = attrs
                }
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region  通讯录管理-成员管理-Baxter更新成员 ***
        /// <summary>
        /// 通讯录管理-成员管理-Baxter更新成员 ***
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="position"></param>
        /// <param name="mobile"></param>
        /// <param name="gender"></param>
        /// <param name="email"></param>
        /// <param name="weixinid"></param>
        /// <param name="enable"></param>
        /// <param name="attrs">拓展字段Json</param>
        /// <returns></returns>
        public static BaseRes User_Update_Baxter(string access_token,
            string userid, string name, int[] department, string position,
            string mobile, int gender, string email, string weixinid, int enable, List<ATTRS_VIEW> attrs)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/update?access_token=";
            url += access_token;

            var post = new
            {
                userid = userid,
                name = name,
                department = department,
                position = position,
                mobile = mobile,
                gender = gender,
                email = email,
                weixinid = weixinid,
                enable = enable,
                extattr = new
                {
                    attrs = attrs
                }
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 通讯录管理-成员管理-企业号二次认证
        /// <summary>
        /// 通讯录管理-成员管理-企业号二次认证
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static BaseRes AuthSuccess(string access_token, string userid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/authsucc?access_token={0}&userid={1}";
            url = string.Format(url, access_token, userid);

            return GetObject<BaseRes>(url);
        }
        #endregion

        #region 通讯录管理-成员管理-邀请成员关注
        /// <summary>
        /// 通讯录管理-成员管理-邀请成员关注
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static InviteSendRes Invite_Send(string access_token, List<string> user, List<string> party, List<string> tag)
        {
            string url = " https://qyapi.weixin.qq.com/cgi-bin/batch/invite?access_token=";
            url += access_token;

            var post = new
            {
                user = user,
                party = party,
                tag = tag
            };

            return PostObject<InviteSendRes>(url, post);
        }
        #endregion

        #region 通讯录管理-成员管理-获取加入企业二维码
        /// <summary>
        /// 通讯录管理-成员管理-获取加入企业二维码
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="size_type"></param>
        /// <returns></returns>
        public static JoinQrCode GetJoinQrCode(string access_token, String size_type)
        {
            string url = " https://qyapi.weixin.qq.com/cgi-bin/corp/get_join_qrcode?access_token=ACCESS_TOKEN&size_type={1}";
            url = String.Format(url, access_token, size_type);
            return GetObject<JoinQrCode>(url);
        }
        #endregion

        #region 通讯录管理-成员管理-获取企业活跃成员数
        /// <summary>
        /// 通讯录管理-成员管理-获取企业活跃成员数
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static ActiveCntRes getActiveStar(string access_token)
        {
            String url = "https://qyapi.weixin.qq.com/cgi-bin/user/get_active_stat?access_token=";
            url += access_token;
            return GetObject<ActiveCntRes>(url);
        }
        #endregion

        #region 通讯录管理-部门管理-创建部门
        /// <summary>
        /// 通讯录管理-部门管理-创建部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="name"></param>
        /// <param name="parentid"></param>
        /// <param name="order"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DeptCreateRep Department_Create(string access_token,
            string name, int parentid, int? order, int? id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/department/create?access_token=";
            url += access_token;

            var post = new
            {
                name = name,
                parentid = parentid,
                order = order,
                id = id
            };

            return PostObject<DeptCreateRep>(url, post);
        }
        #endregion

        #region 通讯录管理-部门管理-更新部门
        /// <summary>
        /// 通讯录管理-部门管理-创建部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="name"></param>
        /// <param name="parentid"></param>
        /// <param name="order"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BaseRes Department_Update(string access_token,
            string name, int? parentid, int? order, int id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/department/update?access_token=";
            url += access_token;

            var post = new
            {
                name = name,
                parentid = parentid,
                order = order,
                id = id
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 通讯录管理-部门管理-删除部门
        /// <summary>
        /// 通讯录管理-部门管理-删除部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BaseRes Department_Delete(string access_token, int id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/department/delete?access_token={0}&id={1}";
            url = string.Format(url, access_token, id); ;

            return GetObject<BaseRes>(url);
        }
        #endregion

        #region 通讯录管理-部门管理-获取部门列表
        /// <summary>
        /// 通讯录管理-部门管理-获取部门列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DeptListRes Department_List(string access_token, int id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={0}&id={1}";
            url = string.Format(url, access_token, id); ;

            return GetObject<DeptListRes>(url);
        }
        #endregion

        #region 通讯录管理-标签管理-创建标签
        /// <summary>
        /// 通讯录管理-标签管理-创建标签
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagname"></param>
        /// <returns></returns>
        public static TagCreateRes Tag_Create(string access_token, string tagname)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/create?access_token=";
            url += access_token;

            var post = new
            {
                tagname = tagname
            };

            return PostObject<TagCreateRes>(url, post);
        }
        #endregion

        #region 通讯录管理-标签管理-更新标签名字
        /// <summary>
        /// 通讯录管理-标签管理-更新标签名字
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagname"></param>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public static BaseRes Tag_Update(string access_token, string tagname, int tagid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/update?access_token=";
            url += access_token;

            var post = new
            {
                tagid = tagid,
                tagname = tagname
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 通讯录管理-标签管理-删除标签
        /// <summary>
        /// 通讯录管理-标签管理-删除标签
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public static BaseRes Tag_Delete(string access_token, int tagid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/delete?access_token={0}&tagid={1}";
            url = string.Format(url, access_token, tagid);

            return GetObject<BaseRes>(url);
        }
        #endregion

        #region 通讯录管理-标签管理-获取标签成员
        /// <summary>
        /// 通讯录管理-标签管理-获取标签成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public static TagGetRes Tag_Get(string access_token, int tagid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/get?access_token={0}&tagid={1}";
            url = string.Format(url, access_token, tagid);

            return GetObject<TagGetRes>(url);
        }
        #endregion

        #region 通讯录管理-标签管理-增加标签成员
        /// <summary>
        /// 通讯录管理-标签管理-增加标签成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagid"></param>
        /// <param name="listUser"></param>
        /// <param name="listDept"></param>
        /// <returns></returns>
        public static TagAddtagUsersRes Tag_AddtagUsers(string access_token, int tagid, string[] listUser, int[] listDept)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/addtagusers?access_token=";
            url += access_token;

            var post = new
            {
                tagid = tagid,
                userlist = listUser,
                partylist = listDept
            };

            return PostObject<TagAddtagUsersRes>(url, post);
        }
        #endregion

        #region 通讯录管理-标签管理-删除标签成员
        /// <summary>
        /// 通讯录管理-标签管理-删除标签成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagid"></param>
        /// <param name="listUser"></param>
        /// <param name="listDept"></param>
        /// <returns></returns>
        public static TagAddtagUsersRes Tag_DeltagUsers(string access_token, int tagid, string[] listUser, int[] listDept)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/deltagusers?access_token=";
            url += access_token;

            var post = new
            {
                tagid = tagid,
                userlist = listUser,
                partylist = listDept
            };

            return PostObject<TagAddtagUsersRes>(url, post);
        }
        #endregion

        #region 通讯录管理-标签管理-获取标签列表
        /// <summary>
        /// 通讯录管理-标签管理-获取标签列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static TagListRes Tag_List(string access_token)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/list?access_token=";
            url += access_token;

            return GetObject<TagListRes>(url);
        }
        #endregion

        #region 通讯录管理-异步完成通知-邀请成员关注 ***
        /// <summary>
        /// 通讯录管理-异步完成通知-邀请成员关注 ***
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="touser"></param>
        /// <param name="toparty"></param>
        /// <param name="totag"></param>
        /// <param name="callbackurl"></param>
        /// <param name="token"></param>
        /// <param name="encodingaeskey"></param>
        /// <returns></returns>
        public static BatchRes Batch_InviteUser(string access_token,
            List<string> touser, List<string> toparty, List<string> totag,
            string callbackurl, string token, string encodingaeskey)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/inviteuser?access_token=";
            url += access_token;

            if (touser == null)
            {
                touser = new List<string>();
            }
            if (toparty == null)
            {
                toparty = new List<string>();
            }
            if (totag == null)
            {
                totag = new List<string>();
            }

            var post = new
            {
                touser = string.Join("|", touser),
                toparty = string.Join("|", toparty),
                totag = string.Join("|", totag),
                callback = new
                {
                    url = callbackurl,
                    token = token,
                    encodingaeskey = encodingaeskey
                }
            };

            return PostObject<BatchRes>(url, post);
        }
        #endregion

        #region 通讯录管理-异步批量接口-增量更新成员
        /// <summary>
        /// 通讯录管理-异步批量接口-增量更新成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id"></param>
        /// <param name="callbackurl"></param>
        /// <param name="token"></param>
        /// <param name="encodingaeskey"></param>
        /// <returns></returns>
        public static BatchRes Batch_SyncUser(string access_token,
            string media_id, string callbackurl, string token, string encodingaeskey)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/syncuser?access_token=";
            url += access_token;

            var post = new
            {
                media_id = media_id,
                callback = new
                {
                    url = callbackurl,
                    token = token,
                    encodingaeskey = encodingaeskey
                }
            };

            return PostObject<BatchRes>(url, post);
        }
        #endregion

        #region 通讯录管理-异步批量接口-全量覆盖成员
        /// <summary>
        /// 通讯录管理-异步批量接口-全量覆盖成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id"></param>
        /// <param name="callbackurl"></param>
        /// <param name="token"></param>
        /// <param name="encodingaeskey"></param>
        /// <returns></returns>
        public static BatchRes Batch_ReplaceUser(string access_token,
            string media_id, string callbackurl, string token, string encodingaeskey)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/replaceuser?access_token=";
            url += access_token;

            var post = new
            {
                media_id = media_id,
                callback = new
                {
                    url = callbackurl,
                    token = token,
                    encodingaeskey = encodingaeskey
                }
            };

            return PostObject<BatchRes>(url, post);
        }
        #endregion

        #region 通讯录管理-异步批量接口-全量覆盖部门
        /// <summary>
        /// 通讯录管理-异步批量接口-全量覆盖部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id"></param>
        /// <param name="callbackurl"></param>
        /// <param name="token"></param>
        /// <param name="encodingaeskey"></param>
        /// <returns></returns>
        public static BatchRes Batch_ReplaceParty(string access_token,
            string media_id, string callbackurl, string token, string encodingaeskey)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/replaceparty?access_token=";
            url += access_token;

            var post = new
            {
                media_id = media_id,
                callback = new
                {
                    url = callbackurl,
                    token = token,
                    encodingaeskey = encodingaeskey
                }
            };

            return PostObject<BatchRes>(url, post);
        }
        #endregion

        #region 通讯录管理-异步批量接口-获取异步任务结果
        /// <summary>
        /// 通讯录管理-异步批量接口-获取异步任务结果
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="jobid"></param>
        /// <returns></returns>
        public static BatchGetResultRes Batch_GetResult(string access_token, string jobid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/getresult?access_token={0}&jobid={1}";
            url = string.Format(url, access_token, jobid);

            return GetObject<BatchGetResultRes>(url);
        }
        #endregion

        #region 通讯录管理-成员管理-更新离职成员标识
        /// <summary>
        /// 通讯录管理-成员管理-更新离职成员标识
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public static BaseRes DisUser_Update(string access_token, string userid, int enable)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/update?access_token=";
            url += access_token;

            var post = new
            {
                userid = userid,
                enable = enable
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion



        #region 外部联系人管理-企业服务人员管理-获取配置了客户联系功能的成员列表
        /// <summary>
        /// 外部联系人管理-企业服务人员管理-获取配置了客户联系功能的成员列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static GetFollowUserListRes GetFollowUserList(string access_token)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/get_follow_user_list?access_token={0}";
            url = string.Format(url, access_token);

            return GetObject<GetFollowUserListRes>(url);
        }
        #endregion

        #region 外部联系人管理-企业服务人员管理-配置客户联系「联系我」方式
        /// <summary>
        /// 企业可以在管理后台-客户联系中配置成员的「联系我」的二维码或者小程序按钮
        /// 客户通过扫描二维码或点击小程序上的按钮，即可获取成员联系方式，主动联系到成员
        /// 企业可通过此接口为具有客户联系功能的成员生成专属的「联系我」二维码或者「联系我」按钮
        /// 如果配置的是「联系我」按钮，需要开发者的小程序接入小程序插件
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="addContactWayReq"></param>
        /// <returns></returns>
        public static AddContactWayRes AddContactWay(string access_token, AddContactWayReq addContactWayReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/add_contact_way?access_token=";
            url += access_token;

            var post = new
            {
                type = addContactWayReq.type,
                scene = addContactWayReq.scene,
                style = addContactWayReq.style,
                remark = addContactWayReq.remark,
                skip_verify = addContactWayReq.skip_verify,
                state = addContactWayReq.state,
                user = addContactWayReq.user,
                party = addContactWayReq.party
            };

            return PostObject<AddContactWayRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-企业服务人员管理-获取企业已配置的「联系我」方式
        /// <summary>
        /// 批量获取企业配置的「联系我」二维码和「联系我」小程序按钮
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="config_id"></param>
        /// <returns></returns>
        public static GetContactWayRes GetContactWay(string access_token, string config_id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/get_contact_way?access_token=";
            url += access_token;

            var post = new
            {
                config_id = config_id
            };

            return PostObject<GetContactWayRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-企业服务人员管理-更新企业已配置的「联系我」方式
        /// <summary>
        /// 更新企业配置的「联系我」二维码和「联系我」小程序按钮中的信息，如使用人员和备注等
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="updateContactWayReq"></param>
        /// <returns></returns>
        public static BaseRes UpdateContactWay(string access_token, UpdateContactWayReq updateContactWayReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/update_contact_way?access_token=";
            url += access_token;

            var post = new
            {
                config_id = updateContactWayReq.config_id,
                remark = updateContactWayReq.remark,
                skip_verify = updateContactWayReq.skip_verify,
                style = updateContactWayReq.style,
                state = updateContactWayReq.state,
                user = updateContactWayReq.user,
                party = updateContactWayReq.party
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-企业服务人员管理-删除企业已配置的「联系我」方式
        /// <summary>
        /// 删除一个已配置的「联系我」二维码或者「联系我」小程序按钮
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="config_id"></param>
        /// <returns></returns>
        public static BaseRes DelContactWay(string access_token, string config_id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/del_contact_way?access_token=";
            url += access_token;

            var post = new
            {
                config_id = config_id
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 外部联系人管理—客户管理-获取客户列表
        /// <summary>
        /// 企业可通过此接口获取指定成员添加的客户列表。客户是指配置了客户联系功能的成员所添加的外部联系人
        /// 没有配置客户联系功能的成员，所添加的外部联系人将不会作为客户返回
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid">企业成员的userid</param>
        /// <returns></returns>
        public static ExternalContactListRes ExternalContactList(string access_token, string userid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/list?access_token={0}&userid={1}";
            url = string.Format(url, access_token, userid);

            return GetObject<ExternalContactListRes>(url);
        }
        #endregion

        #region 外部联系人管理—客户管理-获取客户详情
        /// <summary>
        /// 企业可通过此接口，根据外部联系人的userid（如何获取?），拉取客户详情
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="external_userid">外部联系人的userid，注意不是企业成员的帐号</param>
        /// <returns></returns>
        public static ExternalContactGetRes ExternalContactGet(string access_token, string external_userid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/get?access_token={0}&external_userid={1}";
            url = string.Format(url, access_token, external_userid);

            return GetObject<ExternalContactGetRes>(url);
        }
        #endregion

        #region 外部联系人管理—客户管理-修改客户备注信息
        /// <summary>
        /// 企业可通过此接口修改指定用户添加的客户的备注信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="externalContactRemarkReq"></param>
        /// <returns></returns>
        public static BaseRes ExternalContactRemark(string access_token, ExternalContactRemarkReq externalContactRemarkReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/remark?access_token=";
            url += access_token;

            var post = new
            {
                userid = externalContactRemarkReq.userid,
                external_userid = externalContactRemarkReq.external_userid,
                remark = externalContactRemarkReq.remark,
                description = externalContactRemarkReq.description,
                remark_company = externalContactRemarkReq.remark_company,
                remark_mobiles = externalContactRemarkReq.remark_mobiles,
                remark_mediaid = externalContactRemarkReq.remark_mediaid
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 外部联系人管理—客户标签管理-管理企业标签-获取企业标签库
        /// <summary>
        /// 企业可通过此接口获取企业客户标签详情
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tag_id">要查询的标签id，如果不填则获取该企业的所有客户标签，目前暂不支持标签组id</param>
        /// <returns></returns>
        public static GetCorpTagListRes GetCorpTagList(string access_token, string[] tag_id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/get_corp_tag_list?access_token=";
            url += access_token;

            var post = new
            {
                tag_id = tag_id
            };

            return PostObject<GetCorpTagListRes>(url, post);
        }
        #endregion

        #region 外部联系人管理—客户标签管理-管理企业标签-添加企业客户标签
        /// <summary>
        /// 外部联系人管理—客户标签管理-管理企业标签-添加企业客户标签
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="addCorpTagReq"></param>
        /// <returns></returns>
        public static AddCorpTagRes AddCorpTag(string access_token, AddCorpTagReq addCorpTagReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/add_corp_tag?access_token=";
            url += access_token;

            var post = new
            {
                group_id = addCorpTagReq.group_id,
                group_name = addCorpTagReq.group_name,
                order = addCorpTagReq.order,
                tag = addCorpTagReq.tag
            };

            return PostObject<AddCorpTagRes>(url, post);
        }
        #endregion

        #region 外部联系人管理—客户标签管理-编辑企业客户标签
        /// <summary>
        /// 外部联系人管理—客户标签管理-编辑企业客户标签
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="editCorpTagReq"></param>
        /// <returns></returns>
        public static BaseRes EditCorpTag(string access_token, EditCorpTagReq editCorpTagReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/edit_corp_tag?access_token=";
            url += access_token;

            var post = new
            {
                id = editCorpTagReq.id,
                name = editCorpTagReq.name,
                order = editCorpTagReq.order
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 外部联系人管理—客户标签管理-管理企业标签-删除企业客户标签
        /// <summary>
        /// 外部联系人管理—客户标签管理-管理企业标签-删除企业客户标签
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="delCorpTagReq"></param>
        /// <returns></returns>
        public static BaseRes DelCorpTag(string access_token, DelCorpTagReq delCorpTagReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/del_corp_tag?access_token=";
            url += access_token;

            var post = new
            {
                tag_id = delCorpTagReq.tag_id,
                group_id = delCorpTagReq.group_id
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 外部联系人管理—客户标签管理-管理企业标签-编辑客户企业标签
        /// <summary>
        /// 外部联系人管理—客户标签管理-管理企业标签-编辑客户企业标签
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="markTagReq"></param>
        /// <returns></returns>
        public static BaseRes MarkTag(string access_token, MarkTagReq markTagReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/mark_tag?access_token=";
            url += access_token;

            var post = new
            {
                userid = markTagReq.userid,
                external_userid = markTagReq.external_userid,
                add_tag = markTagReq.add_tag,
                remove_tag = markTagReq.remove_tag
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 外部联系人管理—客户群管理-获取客户群列表
        /// <summary>
        /// 外部联系人管理—客户群管理-获取客户群列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="groupchatListReq"></param>
        /// <returns></returns>
        public static GroupchatListRes GroupchatList(string access_token, GroupchatListReq groupchatListReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/groupchat/list?access_token=";
            url += access_token;

            var post = new
            {
                status_filter = groupchatListReq.status_filter,
                owner_filter = groupchatListReq.owner_filter,
                offset = groupchatListReq.offset,
                limit = groupchatListReq.limit
            };

            return PostObject<GroupchatListRes>(url, post);
        }
        #endregion

        #region 外部联系人管理—客户群管理-获取客户群详情
        /// <summary>
        /// 外部联系人管理—客户群管理-获取客户群详情
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="chat_id">must 	客户群ID</param>
        /// <returns></returns>
        public static GroupchatGetRes GroupchatGet(string access_token, string chat_id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/groupchat/get?access_token=";
            url += access_token;

            var post = new
            {
                chat_id = chat_id
            };

            return PostObject<GroupchatGetRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-消息推送-添加企业群发消息任务
        /// <summary>
        /// 企业可通过此接口添加企业群发消息的任务并通知客服人员发送给相关客户。（注：企业微信终端需升级到2.7.5版本及以上）
        /// 注意：调用该接口并不会直接发送消息给客户，需要相关的客服人员操作以后才会实际发送（客服人员的企业微信需要升级到2.7.5及以上版本）
        /// 同一个企业对一个客户一个自然周内（周一至周日）至多只能发送一条消息，超过限制的用户将会被忽略
        /// text、image、link和miniprogram四者不能同时为空；
        ///text与另外三者可以同时发送，此时将会以两条消息的形式触达客户
        ///image、link和miniprogram只能有一个，如果三者同时填，则按image、link、miniprogram的优先顺序取参，也就是说，如果image与link同时传值，则只有image生效。
        ///media_id和pic_url只需填写一个，两者同时填写时使用media_id，二者不可同时为空。
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="addMsgTemplateReq"></param>
        /// <param name="type"> 0 文本 ，1 图片，4图文</param>
        /// <returns></returns>
        public static AddMsgTemplateRes AddMsgTemplate(string access_token, AddMsgTemplateReq addMsgTemplateReq, int type)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/add_msg_template?access_token=";
            url += access_token;


            if (type == 0)
            {
                var post = new
                {
                    external_userid = addMsgTemplateReq.external_userid,
                    sender = addMsgTemplateReq.sender,
                    text = addMsgTemplateReq.text,
                    //
                    //link = addMsgTemplateReq.link,
                    //miniprogram = addMsgTemplateReq.miniprogram
                };
                return PostObject<AddMsgTemplateRes>(url, post);
            }
            else if (type == 1)
            {
                var post = new
                {
                    external_userid = addMsgTemplateReq.external_userid,
                    sender = addMsgTemplateReq.sender,
                    text = addMsgTemplateReq.text,
                    image = addMsgTemplateReq.image
                };
                return PostObject<AddMsgTemplateRes>(url, post);
            }
            else if (type == 2)
            {
                var post = new
                {
                    external_userid = addMsgTemplateReq.external_userid,
                    sender = addMsgTemplateReq.sender,
                    text = addMsgTemplateReq.text,
                    link = addMsgTemplateReq.link
                };
                return PostObject<AddMsgTemplateRes>(url, post);
            }
            else
            {
                var post = new
                {
                    external_userid = addMsgTemplateReq.external_userid,
                    sender = addMsgTemplateReq.sender,
                    text = addMsgTemplateReq.text,
                    miniprogram = addMsgTemplateReq.miniprogram
                };
                return PostObject<AddMsgTemplateRes>(url, post);
            }


        }
        #endregion

        #region 外部联系人管理-消息推送-获取企业群发消息发送结果
        /// <summary>
        /// 企业可通过该接口获取到添加企业群发消息任务的群发发送结果 外部联系人管理-消息推送-获取企业群发消息发送结果
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="msgid">群发消息的id，通过添加企业群发消息模板接口返回</param>
        /// <returns></returns>
        public static GetGroupMsgResultRes GetGroupMsgResult(string access_token, string msgid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/get_group_msg_result?access_token=";
            url += access_token;

            var post = new
            {
                msgid = msgid
            };

            return PostObject<GetGroupMsgResultRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-消息推送-发送新客户欢迎语
        /// <summary>
        /// 企业微信在向企业推送添加外部联系人事件时，会额外返回一个welcome_code，企业以此为凭据调用接口，即可通过成员向新添加的客户发送个性化的欢迎语。
        /// 为了保证用户体验以及避免滥用，企业仅可在收到相关事件后20秒内调用，且只可调用一次。
        /// 如果企业已经在管理端为相关成员配置了可用的欢迎语，则推送添加外部联系人事件时不会返回welcome_code。
        /// 每次添加新客户时可能有多个企业自建应用/第三方应用收到带有welcome_code的回调事件，但仅有最先调用的可以发送成功。
        /// 后续调用将返回41051（externaluser has started chatting）错误，请用户根据实际使用需求，合理设置应用可见范围，避免冲突
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="sendWelcomeMsgReq"></param>
        /// <returns></returns>
        public static BaseRes SendWelcomeMsg(string access_token, SendWelcomeMsgReq sendWelcomeMsgReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/send_welcome_msg?access_token=";
            url += access_token;

            var post = new
            {
                welcome_code = sendWelcomeMsgReq.welcome_code,
                text = sendWelcomeMsgReq.text,
                image = sendWelcomeMsgReq.image,
                link = sendWelcomeMsgReq.link,
                miniprogram = sendWelcomeMsgReq.miniprogram
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-消息推送-群欢迎语素材管理-添加群欢迎语素材
        /// <summary>
        /// 外部联系人管理-消息推送-群欢迎语素材管理-添加群欢迎语素材
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="groupWelcomeTemplateAddReq"></param>
        /// <returns></returns>
        public static GroupWelcomeTemplateAddRes GroupWelcomeTemplateAdd(string access_token, GroupWelcomeTemplateAddReq groupWelcomeTemplateAddReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/group_welcome_template/add?access_token=";
            url += access_token;

            var post = new
            {
                //text中支持配置多个%NICKNAME%(大小写敏感)形式的欢迎语，当配置了欢迎语占位符后，发送给客户时会自动替换为客户的昵称;
                text = groupWelcomeTemplateAddReq.text,
                image = groupWelcomeTemplateAddReq.image,
                link = groupWelcomeTemplateAddReq.link,
                miniprogram = groupWelcomeTemplateAddReq.miniprogram
            };

            return PostObject<GroupWelcomeTemplateAddRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-消息推送-群欢迎语素材管理-编辑群欢迎语素材
        /// <summary>
        /// 企联系人管理-消息推送-群欢迎语素材管理-编辑群欢迎语素材
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="groupWelcomeTemplateEditReq"></param>
        /// <returns></returns>
        public static BaseRes GroupWelcomeTemplateEdit(string access_token, GroupWelcomeTemplateEditReq groupWelcomeTemplateEditReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/group_welcome_template/edit?access_token=";
            url += access_token;

            var post = new
            {
                template_id = groupWelcomeTemplateEditReq.template_id,
                text = groupWelcomeTemplateEditReq.text,
                image = groupWelcomeTemplateEditReq.image,
                link = groupWelcomeTemplateEditReq.link,
                miniprogram = groupWelcomeTemplateEditReq.miniprogram
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-消息推送-群欢迎语素材管理-获取群欢迎语素材
        /// <summary>
        /// 外部联系人管理-消息推送-群欢迎语素材管理-获取群欢迎语素材
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="template_id">must 群欢迎语的素材id</param>
        /// <returns></returns>
        public static GroupWelcomeTemplateGetRes GroupWelcomeTemplateGet(string access_token, string template_id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/group_welcome_template/get?access_token=";
            url += access_token;

            var post = new
            {
                template_id = template_id
            };

            return PostObject<GroupWelcomeTemplateGetRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-消息推送-群欢迎语素材管理-删除群欢迎语素材
        /// <summary>
        /// 外部联系人管理-消息推送-群欢迎语素材管理-删除群欢迎语素材
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="template_id">must 群欢迎语的素材id</param>
        /// <returns></returns>
        public static BaseRes GroupWelcomeTemplateDel(string access_token, string template_id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/group_welcome_template/del?access_token=";
            url += access_token;

            var post = new
            {
                template_id = template_id
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-离职管理-获取离职成员的客户列表
        /// <summary>
        /// 外部联系人管理-离职管理-获取离职成员的客户列表
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="getUnassignedListReq"></param>
        /// <returns></returns>
        public static GetUnassignedListRes GetUnassignedList(string access_token, GetUnassignedListReq getUnassignedListReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/get_unassigned_list?access_token=";
            url += access_token;

            var post = new
            {
                page_id = getUnassignedListReq.page_id,
                page_size = getUnassignedListReq.page_size
            };

            return PostObject<GetUnassignedListRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-离职管理-离职成员的外部联系人再分配
        /// <summary>
        /// 外部联系人管理-离职管理-离职成员的外部联系人再分配
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="transferReq"></param>
        /// <returns></returns>
        public static BaseRes Transfer(string access_token, TransferReq transferReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/transfer?access_token=";
            url += access_token;

            var post = new
            {
                external_userid = transferReq.external_userid,
                handover_userid = transferReq.handover_userid,
                takeover_userid = transferReq.takeover_userid
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-离职管理-离职成员的群再分配
        /// <summary>
        /// 外部联系人管理-离职管理-离职成员的群再分配
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="groupchatTransferReq"></param>
        /// <returns></returns>
        public static GroupchatTransferRes GroupchatTransfer(string access_token, GroupchatTransferReq groupchatTransferReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/groupchat/transfer?access_token=";
            url += access_token;

            var post = new
            {
                chat_id_list = groupchatTransferReq.chat_id_list,
                new_owner = groupchatTransferReq.new_owner
            };

            return PostObject<GroupchatTransferRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-统计管理-获取联系客户统计数据
        /// <summary>
        /// 外部联系人管理-统计管理-获取联系客户统计数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="getUserBehaviorDataReq"></param>
        /// <returns></returns>
        public static GetUserBehaviorDataRes GetUserBehaviorData(string access_token, GetUserBehaviorDataReq getUserBehaviorDataReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/get_user_behavior_data?access_token=";
            url += access_token;

            var post = new
            {
                userid = getUserBehaviorDataReq.userid,
                partyid = getUserBehaviorDataReq.partyid,
                start_time = getUserBehaviorDataReq.start_time,
                end_time = getUserBehaviorDataReq.end_time
            };

            return PostObject<GetUserBehaviorDataRes>(url, post);
        }
        #endregion

        #region 外部联系人管理-统计管理-获取客户群统计数据
        /// <summary>
        /// 外部联系人管理-统计管理-获取客户群统计数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="groupchatStatisticReq"></param>
        /// <returns></returns>
        public static GroupchatStatisticRes GroupchatStatistic(string access_token, GroupchatStatisticReq groupchatStatisticReq)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/externalcontact/groupchat/statistic?access_token=";
            url += access_token;

            var post = new
            {
                day_begin_time = groupchatStatisticReq.day_begin_time,
                owner_filter = groupchatStatisticReq.owner_filter,
                order_by = groupchatStatisticReq.order_by,
                order_asc = groupchatStatisticReq.order_asc,
                offset = groupchatStatisticReq.offset,
                limit = groupchatStatisticReq.limit
            };

            return PostObject<GroupchatStatisticRes>(url, post);
        }
        #endregion


        #region 应用管理-获取access_token对应的应用列表
        /// <summary>
        /// 应用管理-获取access_token对应的应用列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static AgentListRes Agent_List(string access_token)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/agent/list?access_token=";
            url += access_token;

            return GetObject<AgentListRes>(url);
        }
        #endregion

        #region 应用管理-获取指定应用详情
        /// <summary>
        /// 应用管理-获取指定应用详情
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public static AgentGetRes Agent_Get(string access_token, string agentid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/agent/get?access_token={0}&agentid={1}";
            url = string.Format(url, access_token, agentid);

            return GetObject<AgentGetRes>(url);
        }
        #endregion

        #region 应用管理-设置企业号应用
        /// <summary>
        ///  应用管理-设置企业号应用
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <param name="report_location_flag"></param>
        /// <param name="logo_mediaid"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="redirect_domain"></param>
        /// <param name="isreportuser"></param>
        /// <param name="isreportenter"></param>
        /// <returns></returns>
        public static BaseRes Agent_Set(string access_token,
            string agentid, string report_location_flag, string logo_mediaid, string name,
            string description, string redirect_domain, int isreportuser, int isreportenter)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/agent/set?access_token=";
            url += access_token;

            var post = new
            {
                agentid = agentid,
                report_location_flag = report_location_flag,
                logo_mediaid = logo_mediaid,
                name = name,
                description = description,
                redirect_domain = redirect_domain,
                isreportuser = isreportuser,
                isreportenter = isreportenter
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 应用管理-自定义菜单-创建菜单
        /// <summary>
        /// 应用管理-自定义菜单-创建菜单
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <param name="listButton"></param>
        /// <returns></returns>
        public static BaseRes Menu_Create(string access_token, string agentid, string json)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/menu/create?access_token={0}&agentid={1}";
            url = string.Format(url, access_token, agentid);

            return PostObject<BaseRes>(url, json);
        }
        #endregion

        #region 应用管理-自定义菜单-删除菜单
        /// <summary>
        /// 应用管理-自定义菜单-删除菜单
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public static BaseRes Menu_Delete(string access_token, string agentid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/menu/delete?access_token={0}&agentid={1}";
            url = string.Format(url, access_token, agentid);

            return GetObject<BaseRes>(url);
        }
        #endregion

        #region 应用管理-自定义菜单-获取菜单列表
        /// <summary>
        /// 应用管理-自定义菜单-获取菜单列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public static MenuGetRes Menu_Get(string access_token, string agentid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/menu/get?access_token={0}&agentid={1}";
            url = string.Format(url, access_token, agentid);

            return GetObject<MenuGetRes>(url);
        }
        #endregion


        #region 消息推送-发送应用消息
        /// <summary>
        ///  消息推送-发送应用消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="msgSend"></param>
        /// <returns></returns>
        public static MessageSendRes Message_Send(string access_token, MessageSend msgSend)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=";
            url += access_token;

            string ps = "";
            #region 转换成所所需要的json
            switch (msgSend.msgtype)
            {
                case "text":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            text = new
                            {
                                content = msgSend.content
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

                case "image":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            image = new
                            {
                                media_id = msgSend.media_id
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

                case "voice":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            voice = new
                            {
                                media_id = msgSend.media_id
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

                case "video":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            video = new
                            {
                                media_id = msgSend.media_id,
                                title = msgSend.title,
                                description = msgSend.description
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

                case "file":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            file = new
                            {
                                media_id = msgSend.media_id
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

                case "news":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            news = new
                            {
                                articles = msgSend.articles
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

                case "mpnews":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            mpnews = new
                            {
                                articles = msgSend.articlesMp
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

            }
            #endregion

            return PostObject<MessageSendRes>(url, ps);

        }
        #endregion

        #region 消息推送-发送消息到群聊会话-更新任务卡片消息状态
        /// <summary>
        /// 消息推送-发送消息到群聊会话-更新任务卡片消息状态
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userids"></param>
        /// <param name="agentid"></param>
        /// <param name="task_id"></param>
        /// <param name="clicked_key"></param>
        /// <returns></returns>
        public static BaseRes updateTaskcard(string access_token, List<string> userids, int agentid, string task_id, string clicked_key)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/message/update_taskcard?access_token=ACCESS_TOKEN";
            url += access_token;
            var post = new
            {
                userids = userids,
                agentid = agentid,
                task_id = task_id,
                clicked_key = clicked_key
            };
            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 消息会话-发送消息到群聊会话-创建群聊会话
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"> 调用接口凭证 </param>
        /// <param name="name">群聊名，最多50个utf8字符，超过将截断</param>
        /// <param name="owner">指定群主的id。如果不指定，系统会随机从userlist中选一人作为群主</param>
        /// <param name="userlist">群成员id列表。至少2人，至多2000人</param>
        /// <param name="chatid">群聊的唯一标志，不能与已有的群重复；字符串类型，最长32个字符。只允许字符0-9及字母a-zA-Z。如果不填，系统会随机生成群id</param>
        /// <returns></returns>
        public static BaseRes createChatRoom(string access_token, string name, string owner, List<string> userlist,
            string chatid)
        {
            string url = " https://qyapi.weixin.qq.com/cgi-bin/appchat/create?access_token=";
            url += access_token;
            var post = new
            {
                name = name,
                owner = owner,
                userlist = userlist
            };
            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 消息会话-发送消息到群聊会话-修改群聊会话
        /// <summary>
        /// 消息会话-发送消息到群聊会话-修改群聊会话
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="chatid"></param>
        /// <param name="name"></param>
        /// <param name="owner"></param>
        /// <param name="add_user_list"></param>
        /// <param name="del_user_list"></param>
        /// <returns></returns>
        public static BaseRes updataChatRoom(string access_token, string chatid, string name, string owner, List<string> add_user_list, List<string> del_user_list)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/appchat/update?access_token=";
            url += access_token;
            var post = new
            {
                chatid = chatid,
                name = name,
                owner = owner,
                add_user_list = add_user_list,
                del_user_list = del_user_list
            };
            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 消息推送-发送消息到群聊会话-获取群聊会话
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="chatid">群聊id</param>
        /// <returns></returns>
        public static BaseRes getRoomChat(string access_token, string chatid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/appchat/get?access_token={0}&chatid={1}";
            url = string.Format(url, access_token, chatid);
            return GetObject<BaseRes>(url);
        }
        #endregion


        #region 素材管理-上传临时素材文件
        /// <summary>
        ///  素材管理-上传临时素材文件
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="type"></param>
        /// <param name="file"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MediaUploadRes Media_Upload(string access_token, EnumUploadType type, string file, string name)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";
            url = string.Format(url, access_token, type);

            TimeoutWebClient wc = ThreadWebClientFactory.GetWebClient();
            wc.Encoding = Encoding.UTF8;
            //wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            byte[] bytes = null;
            if (string.IsNullOrEmpty(name))
            {
                bytes = wc.UploadFile(url, "POST", file);
            }
            else
            {
                bytes = wc.PostFile(url, file, name, "media");
            }
            string json = Encoding.UTF8.GetString(bytes);

            MediaUploadRes res = JsonConvert.DeserializeObject<MediaUploadRes>(json);
            if (string.IsNullOrEmpty(res.errcode))
            {
                res.errcode = "0";
            }
            return res;
        }
        #endregion

        #region 素材管理-获取临时素材文件
        /// <summary>
        /// 素材管理-获取临时素材文件
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static MediaGetRes Media_Get(string access_token, string media_id, string filepath)
        {
            string filename = null;

            string url = "https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";
            url = string.Format(url, access_token, media_id);

            TimeoutWebClient wc = ThreadWebClientFactory.GetWebClient();
            wc.DownloadFile(url, filepath);

            string disposition = wc.ResponseHeaders["Content-disposition"];
            if (string.IsNullOrEmpty(disposition))
            {
                string json = System.IO.File.ReadAllText(filepath);
                return JsonConvert.DeserializeObject<MediaGetRes>(json);
            }
            else
            {
                filename = StringHelper.SubString(disposition, "filename=\"", "\"");
            }

            return new MediaGetRes() { errcode = "0", filename = filename };
        }
        #endregion


        #region 消息推送-素材管理-获取高清语音素材
        /// <summary>
        /// 消息推送-素材管理-获取高清语音素材
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id"></param>
        /// <returns></returns>
        public static BaseRes getJssdk(string access_token, string media_id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/media/get/jssdk?access_token={0}&media_id={1}";
            url = string.Format(url, access_token, media_id);
            return GetObject<BaseRes>(url);
        }
        #endregion


        #region 身份验证-扫码授权登录- 获取访问用户身份
        /// <summary>
        /// 身份验证-扫码授权登录- 获取访问用户身份
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static UserGetUserInfoRes User_GetUserInfo(string access_token, string code)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}";
            url = string.Format(url, access_token, code);

            return GetObject<UserGetUserInfoRes>(url);
        }
        #endregion

        #region 开发指南-回调配置-获取微信服务器的ip段
        /// <summary>
        /// 开发指南-回调配置-获取微信服务器的ip段
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static GetCallBackIpRes GetCallBackIp(string access_token)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/getcallbackip?access_token=";
            url += access_token;

            return GetObject<GetCallBackIpRes>(url);
        }
        #endregion

        #region 附录-JS-SDK使用权限签名算法
        /// <summary>
        /// JS-附录-JS-SDK使用权限签名算法
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static Get_jsapi_ticketRes Get_jsapi_ticket(string access_token)
        {
            var url = "https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token=";
            url += access_token;

            return GetObject<Get_jsapi_ticketRes>(url);
        }
        #endregion


        #region 日程-日程-创建日程
        /// <summary>
        /// 日程-日程-创建日程
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public static ScheduleAddRes AddSchedule(string access_token, Schedule schedule)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/oa/schedule/add?access_token=";
            url += access_token;
            var post = new
            {
                schedule = schedule
            };

            return PostObject<ScheduleAddRes>(url, post);
        }
        #endregion

        #region 日程-日程-更新日程
        /// <summary>
        /// 日程-日程-更新日程
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public static BaseRes UpdateSchedule(string access_token, Schedule schedule)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/oa/schedule/update?access_token=";
            url += access_token;
            var post = new
            {
                schedule = schedule
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 日程-日程-获取日程
        /// <summary>
        /// 日程-日程-获取日程
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public static ScheduleGetRes GetSchedule(string access_token, ScheduleList scheduleIDList)
        {
            string url = " https://qyapi.weixin.qq.com/cgi-bin/oa/schedule/get?access_token=";
            url += access_token;
            var post = new
            {
                schedule_id_list = scheduleIDList.schedule_id_list
            };

            return PostObject<ScheduleGetRes>(url, post);
        }
        #endregion

        #region 日程-日程-取消日程
        /// <summary>
        /// 日程-日程-取消日程
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public static BaseRes DelSchedule(string access_token, string schedule_id)
        {
            string url = " https://qyapi.weixin.qq.com/cgi-bin/oa/schedule/del?access_token=";
            url += access_token;
            var post = new
            {
                schedule_id = schedule_id
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 日程-日程-获取日历下的日程列表
        /// <summary>
        /// 日程-日程-获取日历下的日程列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public static ScheduleGetRes GetByCalendar(string access_token, string cal_id, int offset, int limit)
        {
            string url = " https://qyapi.weixin.qq.com/cgi-bin/oa/schedule/get_by_calendar?access_token=";
            url += access_token;
            var post = new
            {
                cal_id = cal_id,
                offset = offset,
                limit = limit,
            };

            return PostObject<ScheduleGetRes>(url, post);
        }
        #endregion

        #region 日程-日历-创建日历
        /// <summary>
        /// 日程-日历-创建日历
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public static CalendarAddRes AddCalendar(string access_token, Calendar calendar)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/oa/calendar/add?access_token=";
            url += access_token;
            var post = new
            {
                calendar = calendar

            };

            return PostObject<CalendarAddRes>(url, post);
        }
        #endregion

        #region 日程-日历-更新日历
        /// <summary>
        /// 日程-日历-更新日历
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public static BaseRes UpdataCalendar(string access_token, Calendar calendar)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/oa/calendar/update?access_token=";
            url += access_token;
            var post = new
            {
                calendar = calendar

            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 日程-日历-获取日历
        /// <summary>
        /// 日程-日历-获取日历
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public static CalendarGetRes GetCalendar(string access_token, CalendarList cal_id_list)
        {
            string url = " https://qyapi.weixin.qq.com/cgi-bin/oa/calendar/get?access_token=";
            url += access_token;
            var post = new
            {
                cal_id_list = cal_id_list.cal_id_list

            };

            return PostObject<CalendarGetRes>(url, post);
        }
        #endregion

        #region 日程-日历-删除日历
        /// <summary>
        /// 日程-日历-删除日历
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public static BaseRes DelCalendar(string access_token, string cal_id)
        {
            string url = " https://qyapi.weixin.qq.com/cgi-bin/oa/calendar/del?access_token=";
            url += access_token;
            var post = new
            {
                cal_id = cal_id

            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion
        
        
        #region 会话内容存档——获取会话内容存档开启成员列表
        /// <summary>
        /// 会话内容存档——获取会话内容存档开启成员列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static PermitRes MsgauditGetPermit(string access_token)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/msgaudit/get_permit_user_list?access_token=";
            url += access_token;
            return GetObject<PermitRes>(url);
        }
        #endregion

        #region 会话内容存档——获取会话内容同意情况——单聊
        /// <summary>
        /// 会话内容存档——获取会话内容同意情况——单聊
        /// 此接口可以批量查询userid与externalopenid之间的会话同意情况
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public static CheckSingleAgreeRes CheckSingleAgree(string access_token, List<CheckSingleAgreeReq> info)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/msgaudit/check_single_agree?access_token=";
            url += access_token;
            var post = new
            {
                info = info
            };
            return PostObject<CheckSingleAgreeRes>(url, post);
        }
        #endregion

        #region 会话内容存档——获取会话内容同意情况——群聊
        /// <summary>
        /// 会话内容存档——获取会话内容同意情况——群聊
        /// 此接口可以批量查询userid与externalopenid之间的会话同意情况
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public static CheckGroupAgreeRes CheckGroupAgree(string access_token, string roomid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/msgaudit/check_room_agree?access_token=";
            url += access_token;
            var post = new
            {
                roomid = roomid
            };
            return PostObject<CheckGroupAgreeRes>(url, post);
        }
        #endregion

        #region 会话内容存档——获取会话内容存档内部群消息
        /// <summary>
        /// 会话内容存档——获取会话内容存档内部群消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public static GroupchatRes GetGroupchatMsg(string access_token, string roomid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/msgaudit/groupchat/get?access_token=";
            url += access_token;
            var post = new
            {
                roomid = roomid
            };
            return PostObject<GroupchatRes>(url, post);
        }
        #endregion


        #region 企业直播——获取成员直播ID列表
        /// <summary>
        /// 企业直播——获取成员直播ID列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="begin_time"></param>
        /// <param name="end_time"></param>
        /// <param name="next_key"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static UserLivingidRes GetUserLivingid(string access_token, string userid, long begin_time, long end_time,
            string next_key, int limit)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/living/get_user_livingid?access_token=";
            url += access_token;
            var post = new
            {
                userid = userid,
                begin_time = begin_time,
                end_time = end_time,
                next_key = next_key,
                limit = limit
            };
            return PostObject<UserLivingidRes>(url, post);
        }
        #endregion

        #region 企业直播——获取直播详情
        /// <summary>
        /// 企业直播——获取直播详情
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="livingid"></param>
        /// <returns></returns>
        public static LivingInfoRes GetLivingInfo(string access_token, string livingid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/living/get_living_info?access_token={0}&livingid={1}";
            url = string.Format(url, access_token, livingid);
            return GetObject<LivingInfoRes>(url);
        }

        #endregion

        #region 企业直播——获取看直播统计
        /// <summary>
        /// 企业直播——获取看直播统计
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="livingid"></param>
        /// <param name="next_key"></param>
        /// <returns></returns>
        public static WatchStatRes GetWatchStat(string access_token, string livingid, string next_key)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/living/get_watch_stat?access_token=";
            url += access_token;
            var post = new
            {
                livingid = livingid,
                next_key = next_key
            };
            return PostObject<WatchStatRes>(url, post);
        }
        

        #endregion
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}
