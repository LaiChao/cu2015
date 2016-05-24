using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using DataEntity.Entity;
using DataEntity.EntityManager;
using CL.Utility.Web.Common;


namespace CL.Utility.Web.UserData
{
	/// <summary>
	/// UserPermission 的摘要说明。
	/// </summary>
	public class UserPermission
	{
		private string strEntityName;

		public UserPermission()
		{
			strEntityName="UserPermission";
		}

		#region 批量操作集合


		public DataTable ListUserPMSByCategory(string strUser,string strCategory)
		{
			try
			{
				string strCommand="GetPMSByCategory";

				HybridDictionary hTable = new HybridDictionary();
				hTable.Add("USER_ID",strUser);
				hTable.Add("PMS_CTG_NAME",strCategory);


				ISingleView  pl= UserManager.GetEntityView(strEntityName);
				return pl.ExecuteDataTable2(CommandType.Text,strCommand,hTable);
			}
			catch(Exception e)
			{
				throw e;
			}			
		}
		public DataTable ListUserByPMS(string strPms)
		{
			try
			{
				string strCommand="GetUserByPMS";

				HybridDictionary hTable = new HybridDictionary();
				hTable.Add("PMS_ID",strPms);


				ISingleView  pl= UserManager.GetEntityView(strEntityName);
				return pl.ExecuteDataTable2(CommandType.Text,strCommand,hTable);
			}
			catch(Exception e)
			{
				throw e;
			}			
		}
		#endregion
	}
}
