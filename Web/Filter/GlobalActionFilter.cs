using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Web.Library;

namespace Web
{
    public class GlobalActionFilter : ActionFilterAttribute
    {
        string reqeustParams { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            reqeustParams = GetRequestParamsStr(context);

            //获取ip地址
            string ipaddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
            string path = context.HttpContext.Request.Path.Value.ToString();

            LogHelper.logInfo("Time:"+DateTime.Now.ToString()+ "  Path: "+ path + "  IP: "+ ipaddress);

        }
        /// <summary>
        /// 解析application/json body中的request参数
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        string GetRequestParamsStr(ActionExecutingContext context)
        {
            string strParams = string.Empty;
            string methodType = context.HttpContext.Request.Method.ToLower();
            if (methodType.Equals("post") || methodType.Equals("put") || methodType.Equals("delete"))
            {
                foreach (var arg in context.ActionArguments)
                {
                    strParams += arg.Key + "：" + JsonConvert.SerializeObject(arg.Value) + "，";
                }
                if (strParams.Length != 0)
                {
                    strParams = strParams.Substring(0, strParams.Length - 1);
                }
            }
            else if (methodType.Equals("get"))
            {
                strParams = context.HttpContext.Request.QueryString.Value?.ToString();
            }
            else
            {
                strParams = "未知MethodType:"+ methodType;
            }
            return strParams;
        }

    }
}