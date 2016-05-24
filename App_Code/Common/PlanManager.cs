using System;
using DataEntity.Entity;
using DataEntity.EntityManager;

namespace CL.Utility.Web.Common
{
	/// <summary>
	/// PlanManager ��ժҪ˵����
	/// </summary>
	public sealed class PlanManager
	{
		private static Manager entityManger = null;

		/// <summary>
		/// ��ȡ�����߶���
		/// </summary>
		/// <returns>�����߶���</returns>
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
		/// ��ȡ����ʵ���
		/// </summary>
		/// <param name="strEntityName">ʵ������</param>
		/// <returns>����ʵ���</returns>
		public static ISingleTable GetEntityTbl(string strEntityName)
		{
			Manager manager = GetInstance();
			ISingleTable entityTbl = manager.Entities[strEntityName] as ISingleTable;
			return entityTbl; 
		}
        
		/// <summary>
		/// ��ȡ����ʵ����ͼ
		/// </summary>
		/// <param name="strEntityName">ʵ������</param>
		/// <returns>����ʵ����ͼ</returns>
		public static ISingleView GetEntityView(string strEntityName)
		{
			Manager manager = GetInstance();
			ISingleView entityView = manager.Entities[strEntityName] as ISingleView;
			return entityView; 
		}
	}
}
