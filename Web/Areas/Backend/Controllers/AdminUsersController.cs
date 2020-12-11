using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Entity;
using Web.IServices;

namespace Web.Areas.Backend.Controllers
{
    [Area("Backend")]
    public class AdminUsersController : BaseController
    {
        #region Service注入
        /// <summary>
        /// Service注入
        /// </summary>
        /// <param name="admin_UsersServices"></param>
        public AdminUsersController(IAdmin_UsersServices admin_UsersServices)
        {
            base._IAdmin_UsersServices = admin_UsersServices;
        }
        #endregion

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetList()
        {
            var list = _IAdmin_UsersServices.QueryByWhere(a => true, "CreateTime");
            return Json(new { state = 1 , list });
        }
        #endregion

        #region 根据ID获取详情
        /// <summary>
        /// 根据ID获取详情
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEntity(Guid ID)
        {
            var entity = _IAdmin_UsersServices.QueryByWhere(a => a.ID == ID, "CreateTime").FirstOrDefault();
            return Json(new { state = 1, entity });
        }
        #endregion

        #region 根据ID获取详情
        /// <summary>
        /// 根据ID获取详情
        /// </summary>
        /// <returns></returns>
        public JsonResult Add(Admin_Users admin_Users)
        {
            admin_Users.ID = Guid.NewGuid();
            admin_Users.CreateTime = DateTime.Now;
            _IAdmin_UsersServices.Insert(admin_Users);
            return Json(new { state = 1 });
        }
        #endregion

        #region 根据ID获取详情
        /// <summary>
        /// 根据ID获取详情
        /// </summary>
        /// <returns></returns>
        public JsonResult Update(Admin_Users admin_Users)
        {
            _IAdmin_UsersServices.Update(admin_Users);
            return Json(new { state = 1 });
        }
        #endregion
    }
}