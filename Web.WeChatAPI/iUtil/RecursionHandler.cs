using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.iUtil
{
    public class RecursionHandler<T> where T : class
    {
        /// <summary>
        /// 递归树
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Exec(List<T> list, Func<T, List<T>> fun)
        {
            foreach (T item in list)
            {
                var _list = fun.Invoke(item);
                if (_list != null && _list.Count > 0)
                {
                    Exec(_list, fun);
                }
            }
        }
    }
}
