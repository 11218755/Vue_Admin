using System;
using Web.Entity;
using Web.IServices;
using Web.IRepository;

/*!
* 文件名称：Admin_UsersServices服务类
*/
namespace Web.Services
{
	public partial class Admin_UsersServices : BaseServices<Admin_Users> , IAdmin_UsersServices
	{
		IAdmin_UsersRepository _IAdmin_UsersRepository;
		public Admin_UsersServices(IAdmin_UsersRepository __IAdmin_UsersRepository)
		{
			this._IAdmin_UsersRepository = __IAdmin_UsersRepository;
			base._IBaseRepository = __IAdmin_UsersRepository;
		}
	}
}