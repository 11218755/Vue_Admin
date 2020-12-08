using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Web.Library
{
    public class LogHelper
    {
        private static log4net.ILog logger = null;

        public static void logInfo(string format, params object[] args)
        {
            if (initLog4net())
                logger.InfoFormat(format, args);
        }

        public static void logInfo(string logstr)
        {
            if (initLog4net())
                logger.Info(logstr);
        }
        public static void logError(string format)
        {
            if (initLog4net())
                logger.Error(format);
        }

        public static void logError(string format, Exception exception)
        {
            if (initLog4net())
                logger.Error(format, exception);
        }

        private static object objlock = new object();//初始化log用的锁  
        private static bool initLog4net()
        {
            if (logger != null)
                return true;
            lock (objlock)
            {
                if (logger == null)
                {
                    ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
                    XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
                    logger = LogManager.GetLogger(repository.Name, "NETCorelog4net");
                    return true;
                }
            }
            return false;
        }
    }
}
