using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Web.Library
{
    public class ConfigManger
    {
        #region 获取appSettings值
        public static IConfiguration GetAppSettings()
        {
            var builder = new ConfigurationBuilder();
            //项目根目录
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            return configuration.GetSection("Config");
        }
        #endregion

    }
}
