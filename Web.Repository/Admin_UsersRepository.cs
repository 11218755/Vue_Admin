using System;
using Web.Entity;
using Web.IRepository;

/*!
* 文件名称：Admin_UsersRepository仓储类
*/
namespace Web.Repository
{
	public partial class Admin_UsersRepository : BaseRepository<Admin_Users> , IAdmin_UsersRepository
	{
	}
}