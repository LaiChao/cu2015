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
	/// UserRole 的摘要说明。
	/// </summary>
	public class UserRole
	{
		
		private string strEntityName;
		public UserRole()
		{
			strEntityName="UserRole";
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

		
		public bool AssignUser(string strRole,string strUser)
		{		
			bool bResult = false;  

			string strCommand="AssignUser";
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("ROLE_ID",strRole);
			hTable.Add("USER_ID",strUser);

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

		public bool UnAssignUser(string strRole,string strUser)
		{		
			bool bResult = false;  

			string strCommand="UnAssignUser";
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("ROLE_ID",strRole);
			hTable.Add("USER_ID",strUser);

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

		public bool ChckUser(string strRole,string strUser)
		{
			bool bResult = false;  

			string strCommand="CheckUser";
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("ROLE_ID",strRole);
			hTable.Add("USER_ID",strUser);

			try
			{
				ISingleView pl=   UserManager.GetEntityView(strEntityName);
				
				int a=Convert.ToInt32(pl.ExecuteScalar(CommandType.Text,strCommand,hTable));

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
