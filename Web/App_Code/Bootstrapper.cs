using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Web
{
    public class Bootstrapper
    {

        #region 获取程序集中的实现类对应的多个接口/反射机制
        /// <summary>  
        /// 获取程序集中的实现类对应的多个接口
        /// </summary>  
        /// <param name="assemblyName">程序集</param>
        public static Dictionary<Type, Type[]> GetClassName()
        {
            var result = new Dictionary<Type, Type[]>();
            Assembly r_assembly = Assembly.Load("Web.Services");
            List<Type> r_ts = r_assembly.GetTypes().ToList();
            foreach (var r_item in r_ts.Where(s => !s.IsInterface))
            {
                if (r_item.Name.EndsWith("Services") && !r_item.Name.StartsWith("II"))
                {
                    var interfaceType = r_item.GetInterfaces();
                    result.Add(r_item, interfaceType);
                }
            }

            Assembly s_assembly = Assembly.Load("Web.Repository");
            List<Type> s_ts = s_assembly.GetTypes().ToList();
            foreach (var s_item in s_ts.Where(s => !s.IsInterface))
            {
                if (s_item.Name.EndsWith("Repository") && !s_item.Name.StartsWith("II"))
                {
                    var interfaceType = s_item.GetInterfaces();
                    result.Add(s_item, interfaceType);
                }
            }
            return result;
        }
        #endregion
    }
}
