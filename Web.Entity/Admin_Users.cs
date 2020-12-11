using System;
using System.Runtime.Serialization;

/*!
* 文件名称：Admin_Users实体类
*/
namespace Web.Entity
{
	[Serializable]
	[DataContract]
	public partial class Admin_Users
	{
		/// <summary>
		/// 描述：
		/// 可空：不为空
		/// 默认值：
		/// </summary>
		[DataMember]
		public Guid ID { get; set; }

		/// <summary>
		/// 描述：
		/// 可空：空
		/// 默认值：
		/// </summary>
		[DataMember]
		public string Name { get; set; }

		/// <summary>
		/// 描述：
		/// 可空：空
		/// 默认值：
		/// </summary>
		[DataMember]
		public string Password { get; set; }

		/// <summary>
		/// 描述：
		/// 可空：不为空
		/// 默认值：
		/// </summary>
		[DataMember]
		public bool IsDelete { get; set; }

		/// <summary>
		/// 描述：
		/// 可空：空
		/// 默认值：
		/// </summary>
		[DataMember]
		public Nullable<DateTime> CreateTime { get; set; }

		/// <summary>
		/// 描述：
		/// 可空：空
		/// 默认值：
		/// </summary>
		[DataMember]
		public Nullable<Guid> CreateUser { get; set; }

	}
}