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
	/// RolePermission 的摘要说明。
	/// </summary>
	public class RolePermission
	{
		private string strEntityName;

		public RolePermission()
		{
				strEntityName="RolePermission";
		}

		#region 批量操作集合


		public DataTable GetByRoleID(string strRoleID)
		{
			try
			{
				string strCommand="GetByRoleID";

				HybridDictionary hTable = new HybridDictionary();
				hTable.Add("ROLE_ID",strRoleID);

				ISingleView  pl= UserManager.GetEntityView(strEntityName);
				return pl.ExecuteDataTable2(CommandType.Text,strCommand,hTable);
			}
			catch(Exception e)
			{
				throw e;
			}			
		}

		#endregion

		#region 单操作集合

		
		public bool AssignPermission(string strRole,string strPermission)
		{		
			bool bResult = false;  

			string strCommand="AssignPermission";
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("ROLE_ID",strRole);
			hTable.Add("PMS_ID",strPermission);

			try
			{
				
				ISingleView pl=   UserManager.GetEntityView(strEntityName);

				
				bResult =pl.ExecuteNonQuery(CommandType.Text,strCommand,hTable)>0?true:false;
				return bResult;
			}
			catch(Exception ex)
			{
				throw ex;
			}            
		}

		public bool UnAssignPermission(string strRole,string strPermission)
		{		
			bool bResult = false;  

			string strCommand="UnAssignPermission";
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("ROLE_ID",strRole);
			hTable.Add("PMS_ID",strPermission);

			try
			{
				ISingleView pl=   UserManager.GetEntityView(strEntityName);
				bResult =pl.ExecuteNonQuery(CommandType.Text,strCommand,hTable)>0?true:false;
				return bResult;
			}
			catch(Exception ex)
			{
				throw ex;
			}            
		}

		public bool ChckPermission(string strRole,string strPermission)
		{
			bool bResult = false;  

			string strCommand="CheckPermission";
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("ROLE_ID",strRole);
			hTable.Add("PMS_ID",strPermission);

			try
			{
				ISingleView pl=   UserManager.GetEntityView(strEntityName);

				bResult = Convert.ToInt32(pl.ExecuteScalar(CommandType.Text,strCommand,hTable))>0?true:false;

				return bResult;
			}
			catch(Exception ex)
			{
				throw ex;
			}            

		}

		

		#endregion
	}
}
