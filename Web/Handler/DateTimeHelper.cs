using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Handler
{
    public class DateTimeHelper
    {
        #region 当前时间转换成java时间毫秒数值
        /// <summary>
        /// 当前时间转换成java时间毫秒数值
        /// </summary>
        /// <returns></returns>
        public static long NowToJavaTimeMillis()
        {
            TimeSpan ts = new TimeSpan(System.DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1, 0, 0, 0).Ticks);
            return (long)ts.TotalMilliseconds;
        }
        #endregion

        #region Java毫秒数转.Net时间
        /// <summary>
        /// Java毫秒数转.Net时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime JavaTimeMillisToDateTime(long time)
        {
            var baseTime = new DateTime(1970, 1, 1, 0, 0, 0);
            return baseTime.AddSeconds(time);
        }

        public static object JavaTimeMillisToDateTime(DateTime vaccinationTime)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
