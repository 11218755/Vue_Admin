using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取部门列表
    /// </summary>
    public class DeptListRes : BaseRes
    {
        public List<Department> department { get; set; }
    }

    /// <summary>
    /// 微信端组织结构
    /// </summary>
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentid { get; set; }
        public long order { get; set; }
    }
}
