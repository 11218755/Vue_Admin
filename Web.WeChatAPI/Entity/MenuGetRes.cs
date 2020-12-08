﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Web.WeChatAPI.Entity
{
    /// <summary>
    /// 获取菜单列表
    /// </summary>
    public class MenuGetRes : BaseRes
    {
        public Menu menu { get; set; }
    }

    public class Menu
    {
        public List<Button> button { get; set; }
    }
}
