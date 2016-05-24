using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Data.OracleClient;
using DataEntity.EntityManager;
using DataEntity.Entity;
using IEL.Data.OracleClient;
using IEL.Data;

namespace CL.Utility.Web.Common
{
	/// <summary>
	/// GetRegionByRole 的摘要说明。
	/// </summary>
	public class RoleRegion
	{
		public RoleRegion()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region "自定义属性"
		public static Manager oraUserCfgManager = Managers.Members["UserOra"] as Manager;
		public static Manager oraUtilityManager = Managers.Members["UtilityOra"] as Manager;

		public static ISingleTable roleInputTable = oraUtilityManager.Entities["ROLE_INPUT"] as ISingleTable;
		public static ISingleTable userRoleTable = oraUserCfgManager.Entities["USER_ROLE"] as ISingleTable;
		#endregion

		public DataTable GetAuthorizedInputRegion(string userId)
		{
			
			ArrayList roleIds = GetRoleIdsByUserId(userId);

			//根据角色去绑定装置
			string strSql = "";
			bool isStarted = false;
			foreach(string roleId in roleIds)
			{
				if (isStarted)
				{
					strSql = strSql + " OR ROLE_ID = " + roleId;
				}
				else
				{
					strSql = "WHERE (ROLE_ID = " + roleId;
					isStarted = true;
				}
			}
			//
			if (!isStarted) return null; 
			strSql = strSql + ")";
			strSql = "SELECT DISTINCT role_input.input_region_id FROM role_input " + strSql;
			strSql = "SELECT region_input.input_region_id, input_region_short_name, input_region_name, display_order " +
				     "FROM region_input, (" + strSql + ") role " +
				     "WHERE region_input.input_region_id = role.input_region_id " +
				     "AND region_input.use_identifier != 0 " +
				     "ORDER BY region_input.display_order";

			OracleHelper helper=new OracleHelper();
			IDbConnection oraConn = roleInputTable.GetConnection();
			return helper.ExecuteDatatable(oraConn ,CommandType.Text,strSql) ; 
		}
		public ArrayList GetRoleIdsByUserId(string strUserId)
		{
			HybridDictionary hTable = new HybridDictionary();
			hTable.Add("USER_ID",strUserId);
			ArrayList GetRoleIdsByUserId = new ArrayList();
			
			OracleDataReader myReader = (OracleDataReader)userRoleTable.ExecuteReader
				(CommandType.Text,"SelectRoleIdsByUserId",hTable);
			while (myReader.Read()) 
			{
				GetRoleIdsByUserId.Add(myReader.GetString(0));
			}
			myReader.Close();
			OracleConnection myConnection = (OracleConnection)userRoleTable.GetConnection();
			myConnection.Close();
			return GetRoleIdsByUserId;
		}
		//-----王渤2005-7-19------
		public DataTable GetAuthorizedItemrepRegion(string userId)
		{		
			ArrayList roleIds = GetRoleIdsByUserId(userId);

			//根据角色去绑定装置
			string strSql = "";
			bool isStarted = false;
			foreach(string roleId in roleIds)
			{
				if (isStarted)
				{
					strSql = strSql + " OR ROLE_ID = " + roleId;
				}
				else
				{
					strSql = "AND (ROLE_ID = " + roleId;
					isStarted = true;
				}
			}
			//
			if (!isStarted) return null; 
			strSql = strSql + ")";
			strSql = "SELECT DISTINCT REGION_ITEMREP.source_id, source.source_name, ROLE_ITEMREP.itemrep_region_id itemrep_region_id ,REGION_ITEMREP.itemrep_region_short_name itemrep_region_short_name,REGION_ITEMREP.itemrep_region_name itemrep_region_name,source.display_order,REGION_ITEMREP.display_order " + 
				" FROM ROLE_ITEMREP, REGION_ITEMREP, source " +
				" WHERE REGION_ITEMREP.source_id = source.source_id AND ROLE_ITEMREP.itemrep_region_id = REGION_ITEMREP.itemrep_region_id AND REGION_ITEMREP.use_identifier !=0 AND source.use_identifier !=0 " + 
				strSql + " ORDER BY source.display_order, REGION_ITEMREP.display_order";	
			OracleHelper helper=new OracleHelper();
			IDbConnection oraConn = roleInputTable.GetConnection();
			return helper.ExecuteDatatable(oraConn ,CommandType.Text,strSql); 
		}
		public DataTable GetAuthorizedItemrepRegion(string userId, string sourceId)
		{
			
			ArrayList roleIds = GetRoleIdsByUserId(userId);

			//根据角色去绑定装置
			string strSql = "";
			bool isStarted = false;
			foreach(string roleId in roleIds)
			{
				if (isStarted)
				{
					strSql = strSql + " OR ROLE_ID = " + roleId;
				}
				else
				{
					strSql = "AND (ROLE_ID = " + roleId;
					isStarted = true;
				}
			}
			//
			if (!isStarted) return null; 
			strSql = strSql + ")";
			strSql = "SELECT DISTINCT REGION_ITEMREP.source_id, source.source_name, ROLE_ITEMREP.itemrep_region_id itemrep_region_id,REGION_ITEMREP.itemrep_region_short_name itemrep_region_short_name,REGION_ITEMREP.itemrep_region_name itemrep_region_name,REGION_ITEMREP.display_order " + 
				"FROM ROLE_ITEMREP, REGION_ITEMREP, source  " +
				"WHERE REGION_ITEMREP.source_id = source.source_id AND ROLE_ITEMREP.itemrep_region_id = REGION_ITEMREP.itemrep_region_id AND REGION_ITEMREP.use_identifier !=0 AND source.use_identifier !=0  AND source.source_id = '" + sourceId + "' " +
				strSql + " ORDER BY REGION_ITEMREP.display_order";	

			OracleHelper helper=new OracleHelper();
			IDbConnection oraConn = roleInputTable.GetConnection();
			return helper.ExecuteDatatable(oraConn ,CommandType.Text,strSql) ; 
		}
		//----------
		public DataTable GetAuthorizedBalanceRegion(string userId)
		{		
			ArrayList roleIds = GetRoleIdsByUserId(userId);

			//根据角色去绑定装置
			string strSql = "";
			bool isStarted = false;
			foreach(string roleId in roleIds)
			{
				if (isStarted)
				{
					strSql = strSql + " OR ROLE_ID = " + roleId;
				}
				else
				{
					strSql = "AND (ROLE_ID = " + roleId;
					isStarted = true;
				}
			}
			//
			if (!isStarted) return null; 
			strSql = strSql + ")";
			strSql = "SELECT DISTINCT region_balance.source_id, source.source_name, role_balance.balance_region_id balance_region_id,region_balance.balance_region_short_name balance_region_short_name,region_balance.balance_region_name balance_region_name,source.display_order,region_balance.display_order " + 
				"FROM role_balance, region_balance, source " +
				"WHERE region_balance.source_id = source.source_id AND role_balance.balance_region_id = region_balance.balance_region_id AND region_balance.use_identifier !=0 AND source.use_identifier !=0 " + 
				strSql + " ORDER BY source.display_order, region_balance.display_order";	
			OracleHelper helper=new OracleHelper();
			IDbConnection oraConn = roleInputTable.GetConnection();
			return helper.ExecuteDatatable(oraConn ,CommandType.Text,strSql); 
		}
		public DataTable GetAuthorizedBalanceRegion(string userId, string sourceId)
		{
			
			ArrayList roleIds = GetRoleIdsByUserId(userId);

			//根据角色去绑定装置
			string strSql = "";
			bool isStarted = false;
			foreach(string roleId in roleIds)
			{
				if (isStarted)
				{
					strSql = strSql + " OR ROLE_ID = " + roleId;
				}
				else
				{
					strSql = "AND (ROLE_ID = " + roleId;
					isStarted = true;
				}
			}
			//
			if (!isStarted) return null; 
			strSql = strSql + ")";
			strSql = "SELECT DISTINCT region_balance.source_id, source.source_name, role_balance.balance_region_id balance_region_id,region_balance.balance_region_short_name balance_region_short_name,region_balance.balance_region_name balance_region_name,region_balance.display_order " + 
				"FROM role_balance, region_balance, source " +
				"WHERE region_balance.source_id = source.source_id AND role_balance.balance_region_id = region_balance.balance_region_id AND region_balance.use_identifier !=0 AND source.use_identifier !=0 AND source.source_id = '" + sourceId + "' " +
				strSql + " ORDER BY region_balance.display_order";	

			OracleHelper helper=new OracleHelper();
			IDbConnection oraConn = roleInputTable.GetConnection();
			return helper.ExecuteDatatable(oraConn ,CommandType.Text,strSql) ; 
		}
	}
}
