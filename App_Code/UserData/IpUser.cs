//Added lxf 2004-12-24
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
	public class IpUser
	{

		private string strEntityName;

		public IpUser()
		{
			this.strEntityName="IpUser";
		}

		public DataTable GetDataTable()
		{
			return UserManager.GetEntityTbl(strEntityName).GetDataTable();
		}
		public DataTable QueryUserIdDes()
		{
			return UserManager.GetEntityTbl(strEntityName).ExecuteDataTable2(CommandType.Text,"QueryUserIdDes");
		}

		public string GetUserIdByIp(string ipAddress)
		{
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("IP",ipAddress);

			HybridDictionary resultHd;
			resultHd = UserManager.GetEntityTbl(strEntityName).QryByKeysForHD(hTable);

			return resultHd["USER_ID"].ToString();
		}

		public bool IsExistByIp(string ipAddress)
		{
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("IP", ipAddress);

			return UserManager.GetEntityTbl(strEntityName).IsExistByKeys(hTable);
		}

		public bool DeleteByUserId(string userId)
		{
			HybridDictionary myHd = new HybridDictionary();
			myHd.Add("USER_ID", userId);
			return Convert.ToBoolean(UserManager.GetEntityTbl(strEntityName).ExecuteNonQuery(CommandType.Text,"DeleteByUserId",myHd));
		}

		public bool UpdateByUserId(string userId, string des)
		{
			HybridDictionary myHd = new HybridDictionary();
			myHd.Add("USER_ID", userId);
			myHd.Add("DES", des);
			return Convert.ToBoolean(UserManager.GetEntityTbl(strEntityName).ExecuteNonQuery(CommandType.Text,"UpdateByUserId",myHd));
		}

		public bool Insert(string ip, string userId, string des)
		{
			HybridDictionary myHd = new HybridDictionary();
			myHd.Add("IP", ip);
			myHd.Add("USER_ID", userId);
			myHd.Add("DES", des);
			return Convert.ToBoolean(UserManager.GetEntityTbl(strEntityName).Insert(myHd));
		}

	}
}
