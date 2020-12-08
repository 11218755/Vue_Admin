using Web.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;


namespace Web
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// 发生异常时进入
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                System.Exception exp = context.Exception;
                // 记录日志
                string controllerName = context.RouteData.Values["controller"].ToString();
                string actionName = context.RouteData.Values["action"].ToString();
                string txt = "访问[{0}/{1}]";
                txt = string.Format(txt, controllerName, actionName);
                LogHelper.logError(txt,exp);

                if (context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    context.Result = new JsonResult(new
                    {
                        msg = "系统内部错误",
                        success = false,
                        state = -9999
                    });
                    context.ExceptionHandled = true;
                }
                else
                {
                    context.ExceptionHandled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// 异步发生异常时进入
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }
    }
}
