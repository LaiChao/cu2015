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
	/// Role 的摘要说明。
	/// </summary>
	public class Role
	{
		private string strEntityName;

		public Role()
		{
			strEntityName="Role";
		}

		#region 批量操作集合

		/// <summary>
		/// 读取所有角色
		/// </summary>
		/// <returns></returns>
		public DataTable GetAllRoles()
		{
			try
			{
				ISingleTable  pl= UserManager.GetEntityTbl(strEntityName);
				return pl.GetDataTable();
			}
			catch(Exception e)
			{
				throw e;
			}			
		}

		public DataTable GetAcitiveRoles()
		{
			try
			{
				string strCommand="GetAllAcitve";

				ISingleTable  pl= UserManager.GetEntityTbl(strEntityName);
				return pl.ExecuteDataTable2(CommandType.Text,strCommand);
			}
			catch(Exception e)
			{
				throw e;
			}			
		}

		public void UpdateAll(DataTable dtMerger)
		{
			try
			{
				ISingleTable pl= CoreDataManager.GetEntityTbl(strEntityName);;
				
				DataSet ds= new DataSet();
				
				ds.Tables.Add(pl.GetDataTable());

				ds.Tables[0].TableName="Role";
				dtMerger.TableName="Role";

				ds.Merge(dtMerger,false,MissingSchemaAction.Ignore);
				pl.UpdateDataTable(ds.Tables[0]);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 单操作集合

		
		public bool AddRole(string strID,string strName,bool blInUse,string strDescription )
		{		
			bool bResult = false;  

			System.DateTime time =System.DateTime.Now ;
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("ROLE_ID",strID);
			hTable.Add("ROLE_NAME",strName);
			hTable.Add("USE_IDT",blInUse);
			hTable.Add("CRT_DATE",time);
			hTable.Add("UPD_DATE",time);
			hTable.Add("DES",strDescription);

			try
			{
				ISingleTable pl=   UserManager.GetEntityTbl(strEntityName);
				bResult = pl.Insert(hTable)>0?true:false;
				return bResult;
			}
			catch(Exception ex)
			{
				throw ex;
			}            
		}

		public bool UpdateByID(string strID,string strName,bool blInUse,string strDescription)
		{		
			bool bResult = false; 
 
			string strCommand="UpdateByID";

			System.DateTime time =System.DateTime.Now ;
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("ROLE_ID",strID);
			hTable.Add("ROLE_NAME",strName);
			hTable.Add("USE_IDT",blInUse);
			hTable.Add("UPD_DATE",time);
			hTable.Add("DES",strDescription);

			try
			{
				ISingleTable pl=   UserManager.GetEntityTbl(strEntityName);
				bResult =pl.ExecuteNonQuery(CommandType.Text,strCommand,hTable)>0?true:false;
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
