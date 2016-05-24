using System;
using DataEntity.Entity;
using DataEntity.EntityManager;

namespace CL.Utility.Web.Common
{
	/// <summary>
	/// PlanManager 的摘要说明。
	/// </summary>
	public sealed class PlanManager
	{
		private static Manager entityManger = null;

		/// <summary>
		/// 获取管理者对象
		/// </summary>
		/// <returns>管理者对象</returns>
		public static Manager GetInstance()
		{
			if(null == entityManger)
			{
				Managers.Load();
				entityManger = Managers.Members["OraPlan"] as Manager;
			}
			return entityManger;
		}

		/// <summary>
		/// 获取操作实体表
		/// </summary>
		/// <param name="strEntityName">实体名称</param>
		/// <returns>操作实体表</returns>
		public static ISingleTable GetEntityTbl(string strEntityName)
		{
			Manager manager = GetInstance();
			ISingleTable entityTbl = manager.Entities[strEntityName] as ISingleTable;
			return entityTbl; 
		}
        
		/// <summary>
		/// 获取操作实体视图
		/// </summary>
		/// <param name="strEntityName">实体名称</param>
		/// <returns>操作实体视图</returns>
		public static ISingleView GetEntityView(string strEntityName)
		{
			Manager manager = GetInstance();
			ISingleView entityView = manager.Entities[strEntityName] as ISingleView;
			return entityView; 
		}
	}
}
