using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Web.IServices;
using Web.WeChatAPI.Entity;
using Pomelo.AspNetCore.TimedJob;
using Microsoft.AspNetCore.Hosting;
using Web.WeChatAPI.MPEntity;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using Web.Library;

namespace Web.Jobs
{
    public class SendMessageTimeJob : IJob
    {    
        
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IServiceProvider _provider;
            
        public SendMessageTimeJob(IWebHostEnvironment hostingEnvironment,IServiceProvider provider)
        {
            this._hostingEnvironment = hostingEnvironment;
            _provider = provider;
        }

        
        public Task Execute(IJobExecutionContext context)
        {
            using (
                var scope = _provider.CreateScope())
            {
                LogHelper.logInfo("SendMessageTimeJob 定时任务开始执行");
                Run();
                LogHelper.logInfo("SendMessageTimeJob 定时任务执行完毕");
            }
            
            return Task.CompletedTask;
        }
        
        
        #region 定时发送 
        public void Run()
        {
            
            
        }
        #endregion
    }
}
