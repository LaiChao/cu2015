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
	/// PermissionCategory 的摘要说明。
	/// </summary>
	public class PermissionCategory
	{

		private string strEntityName;

		public PermissionCategory()
		{
			strEntityName="PermissionCateory";
		}

		#region 批量操作集合

		/// <summary>
		/// 读取所有权限类别
		/// </summary>
		/// <returns></returns>
		public DataTable GetAllCategory()
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

		public DataTable GetAllName()
		{
			string strCommand = "GetAllCategory";
			try
			{
				ISingleTable pl= UserManager.GetEntityTbl(strEntityName);
				return pl.ExecuteDataTable(CommandType.Text,strCommand) ;
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
				ISingleTable pl= UserManager.GetEntityTbl(strEntityName);;
				DataSet ds= new DataSet();
				ds.Tables.Add(pl.GetDataTable());
				ds.Tables[0].TableName="PermissionCategory";
				dtMerger.TableName="PermissionCategory";
//				ds.EnforceConstraints =false;
				ds.Merge(dtMerger,false,MissingSchemaAction.Ignore);
				pl.UpdateDataTable(ds.Tables[0]);
//				return ds.Tables[0];
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}



		#endregion

		#region 单操作集合

		
		public bool AddCategory(string strName,bool blInUse,string strDescription )
		{		
			bool bResult = false;  

			System.DateTime time =System.DateTime.Now ;
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("PMS_CTG_NAME",strName);
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

		public bool UpdateByName(string strName,bool blInUse,string strDescription )
		{		
			bool bResult = false; 
 
			string strCommand="UpdateByName";

			System.DateTime time =System.DateTime.Now ;
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("PMS_CTG_NAME",strName);
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
