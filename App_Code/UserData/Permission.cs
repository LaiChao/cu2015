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
	/// Permission 的摘要说明。
	/// </summary>
	public class Permission
	{
		private string strEntityName;

		public Permission()
		{
			strEntityName="Permission";
		}

		#region 批量操作集合

		/// <summary>
		/// 读取所有权限
		/// </summary>
		/// <returns></returns>
		public DataTable GetAllPermission()
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

		public DataTable GetAcitivePermissions()
		{
			try
			{
				string strCommand="GetAllActive";

				ISingleTable  pl= UserManager.GetEntityTbl(strEntityName);
				return pl.ExecuteDataTable2(CommandType.Text,strCommand);
			}
			catch(Exception e)
			{
				throw e;
			}			
		}

		public DataTable GetByCategory(string strCategory)
		{
			try
			{
				string strCommand="GetByCategory";

				HybridDictionary hTable = new HybridDictionary();
				hTable.Add("PMS_CTG_NAME",strCategory);

				ISingleTable  pl= UserManager.GetEntityTbl(strEntityName);
				return pl.ExecuteDataTable2(CommandType.Text,strCommand,hTable);
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

				ds.Tables[0].TableName="Permission";
				dtMerger.TableName="Permission";

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

		
		public bool AddPermission(string strID,string strName,string strCategory,bool blInUse,string strDescription )
		{		
			bool bResult = false;  

			System.DateTime time =System.DateTime.Now ;
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("PMS_ID",strID);
			hTable.Add("PMS_NAME",strName);
			hTable.Add("PMS_CTG_NAME",strCategory);
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

		public bool UpdateByID(string strID,string strName,string strCategory,bool blInUse,string strDescription)
		{		
			bool bResult = false; 
 
			string strCommand="UpdateByID";

			System.DateTime time =System.DateTime.Now ;
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("PMS_ID",strID);
			hTable.Add("PMS_NAME",strName);
			hTable.Add("PMS_CTG_NAME",strCategory);
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
