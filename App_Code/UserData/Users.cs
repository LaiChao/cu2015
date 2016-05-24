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
	/// Users 的摘要说明。
	/// </summary>
	public class Users
	{

		private string strEntityName;

		public Users()
		{
			this.strEntityName="Users";
		}

		#region 批量操作集合


		/// <summary>
		/// 获取全部用户数据
		/// </summary>
		/// <returns></returns>
		public DataTable GetAllUsers()
		{
			try
			{
				ISingleTable pl= UserManager.GetEntityTbl(strEntityName);
				return pl.GetDataTable();
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

				ds.Tables[0].TableName="Users";
				dtMerger.TableName="Users";

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

		
		public bool AddUser(string strID,string strName,string strPWD,bool blInUse,string strDescription )
		{		
			bool bResult = false;  

			System.DateTime time =System.DateTime.Now ;
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("USER_ID",strID);
			hTable.Add("USER_NAME",strName);
			hTable.Add("PWD",strPWD);
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
			hTable.Add("USER_ID",strID);
			hTable.Add("USER_NAME",strName);
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

		public bool Authorized(string strUser,string strPWD)
		{
			bool bResult = false; 
 
			string strCommand="Authorized";
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("USER_ID",strUser);
			hTable.Add("PWD",strPWD);

			try
			{
				ISingleTable pl=   UserManager.GetEntityTbl(strEntityName);
				object x=pl.ExecuteScalar(CommandType.Text,strCommand,hTable);
				bResult =Convert.ToInt32(x)>0?true:false;
				return bResult;
			}
			catch(Exception ex)
			{
				throw ex;
			}            


		}

		public bool ChangePWD(string strUser,string strPWD)
		{
			bool bResult = false; 
 
			string strCommand="ChangePWD";
			
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("USER_ID",strUser);
			hTable.Add("PWD",strPWD);

			try
			{
				ISingleTable pl=   UserManager.GetEntityTbl(strEntityName);
				bResult =Convert.ToInt32(pl.ExecuteScalar(CommandType.Text,strCommand,hTable))>0?true:false;
				return bResult;
			}
			catch(Exception ex)
			{
				throw ex;
			}            

		}

		//Added lxf 2004-12-24
		public string GetPwdByUserId(string userId)
		{
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("USER_ID",userId);

			HybridDictionary resultHd;
			resultHd = UserManager.GetEntityTbl(strEntityName).QryByKeysForHD(hTable);

			return resultHd["PWD"].ToString();
		}

		#endregion
	}
}
