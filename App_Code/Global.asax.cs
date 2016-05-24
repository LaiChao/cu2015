using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Security.Principal;
using System.Collections.Specialized;
using CL.Utility.Web.AuditService;　
using System.Xml;
using System.Configuration;
using DataEntity.EntityManager;

namespace Clpec_Utility 
{
	/// <summary>
	/// Global 的摘要说明。
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
            return; 
			//			获取用户名
			string cookieName = FormsAuthentication.FormsCookieName;
			HttpCookie authCookie = Context.Request.Cookies[cookieName];
			if(null == authCookie)
			{
                Response.Redirect("http://Main.mes.clpec/clpec_main/LogonNew.aspx");
				return;
			}
			FormsAuthenticationTicket authTicket = null;
			try
			{
				authTicket = FormsAuthentication.Decrypt(authCookie.Value);
			}
			catch (Exception ex)
			{
				Response.Redirect("http://Main.mes.clpec/clpec_main/LogonNew.aspx");
				return;
			}
		
			if (null == authTicket)
			{
				Response.Redirect("http://Main.mes.clpec/clpec_main/LogonNew.aspx");
				return;
			}
		
			if(authTicket.Expired)
			{
				Response.Redirect("http://Main.mes.clpec/clpec_main/LogonNew.aspx");
				return;
			}
					
			string userId;
			userId = authTicket.UserData.ToString();
		
			int index = userId.IndexOf("|");
			userId = userId.Substring(0,index);
		
			if (Context.Request.HttpMethod.ToUpper() != "POST")
			{
				string strURL =Context.Request.Path.ToString();
				string strPermission = "";
				if ( strURL.EndsWith("MainFrame.aspx") || strURL.EndsWith("Left1.aspx"))
					return;
				//获取权限集合
				AuditService userAuth = new AuditService();
				string strCategory=System.Configuration.ConfigurationSettings.AppSettings["PermissionCategory"];
				DataSet  dsPermission= new DataSet();
				dsPermission = userAuth.ListUserPMSByCate(userId,strCategory) as DataSet;
			
				//读取配置文件
				System.Xml.XmlDocument document = new System.Xml.XmlDataDocument();
				document.Load(AppDomain.CurrentDomain.SetupInformation.ApplicationBase+"Menu.xml");
		
				XmlNodeList myList = document.GetElementsByTagName("MenuItem");
				foreach(XmlNode myNode in myList)
				{
					string strHref = myNode.Attributes["href"].Value;
					if (strHref.EndsWith(strURL))
						strPermission =  myNode.Attributes["permission"].Value;
				}
				//check permission
				DataTable myTable;
				myTable = dsPermission.Tables[0];
				// Presuming the DataTable has a column named Date.
				string strExpr;
				strExpr = "PMS_ID= "+"'"+strPermission+"'";
				DataRow[] foundRows;
				// Use the Select method to find all rows matching the filter.
				foundRows = myTable.Select(strExpr);
				// Print column 0 of each returned row.
				if (foundRows.Length<1)
				{
					Response.Redirect("http://main.mes.clpec/Clpec_Main/LogonNew.aspx");
					return;
				}
			}
					
			string[] Roles = authTicket.UserData.Split('|'); 
			FormsIdentity id = new FormsIdentity( authTicket ); 
			// This principal will flow throughout the request.
			GenericPrincipal principal = new GenericPrincipal(id, Roles);
			// Attach the new principal object to the current HttpContext object
			Context.User = principal;
			//			// Extract the forms authentication cookie
			//			string cookieName = FormsAuthentication.FormsCookieName;
			//			HttpCookie authCookie = Context.Request.Cookies[cookieName];
			//
			//			if(null == authCookie)
			//			{
			//				// There is no authentication cookie.
			//				return;
			//			}
			//
			//			FormsAuthenticationTicket authTicket = null;
			//			try
			//			{
			//				authTicket = FormsAuthentication.Decrypt(authCookie.Value);
			//			}
			//			catch (Exception ex)
			//			{
			//				// Log exception details (omitted for simplicity)
			//				return;
			//			}
			//
			//			if (null == authTicket)
			//			{
			//				// Cookie failed to decrypt.
			//				return;
			//			}
			//
			//			if(authTicket.Expired)
			//			{
			//				return;
			//			}
			//
			//			// When the ticket was created, the UserData property was assigned a
			//			// pipe delimited string of role names.
			//            
			//			
			//
			//			//			DataSet ds =new DataSet();
			//			//			AuditService Audit= new AuditService();
			//			//			string strCategory=System.Configuration.ConfigurationSettings.AppSettings["PMSCategory"];
			//			//			ds=Audit.ListUserPMSByCate(authTicket.UserData.ToString(),strCategory);
			//
			//			//			StringCollection myCol = new StringCollection();
			//			//			
			//			//			foreach(DataRow myRow in ds.Tables[0].Rows)
			//			//			{
			//			//				myCol.Add(myRow["PMS_ID"].ToString());
			//			//			}
			//			//			String[] Roles = new String[myCol.Count];
			//			//			myCol.CopyTo( Roles, 0 );
			//
			//
			//			string[] Roles = authTicket.UserData.Split('|'); 
			//
			//
			//			FormsIdentity id = new FormsIdentity( authTicket ); 
			//
			//			// This principal will flow throughout the request.
			//			GenericPrincipal principal = new GenericPrincipal(id, Roles);
			//			// Attach the new principal object to the current HttpContext object
			//			Context.User = principal;
		
		}
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		
		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

