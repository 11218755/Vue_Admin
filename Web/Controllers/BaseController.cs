using Microsoft.AspNetCore.Mvc;
using Web.IServices;

/*!
* 文件名称：BaseController父控制器类
*/
namespace Web
{
	public partial class BaseController : Controller
	{
		protected IAdmin_UsersServices _IAdmin_UsersServices;
	}
}