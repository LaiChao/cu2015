
//写log日志的通用类

using System;
using System.Data;
using System.Diagnostics ;
using DataEntity.EntityManager;
using DataEntity.Entity;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace CL.Utility.Web.Common
{
	/// <summary>
	/// LogEvent 的摘要说明。
	/// </summary>
	public class LogEvent
	{
		private string LogName;
		private string EventSource;

		public string Page;
		public string Operation;
		public string Server;
		public string Client;
		public string User;
		public string KeyWord;
		public EventLogEntryType EventType;
		public DateTime  Time;

		#region "自定义属性"
		public static Manager manager = Managers.Members["LogOra"] as Manager;
		public static ISingleTable logrecordTable = manager.Entities["LOGRECORD"] as ISingleTable;
		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="strLogName"></param>
		/// <param name="strEventSource"></param>
		public LogEvent(string strLogName,string strEventSource)
		{
			this.LogName =strLogName;
			this.EventSource=strEventSource;
			this.Page ="";
			this.Operation ="default";
			this.Server ="";
			this.Client ="";
			this.KeyWord ="";
			this.EventType = EventLogEntryType.Warning;
			this.User ="";
			this.Time =System.DateTime.Now;
		}

		
		/// <summary>
		/// 写Log
		/// </summary>
		public void  WriteLogEvent()
		{
			try
			{
				DataTable schemaTable = logrecordTable.GetSchema();
				DataRow myRow = schemaTable.NewRow();
				myRow["RECORDTIME"] = System.DateTime.Now;
				switch (this.EventType)
				{
					case EventLogEntryType.Error:
						myRow["RECORDTYPE"] = "Error";
						break;
					case EventLogEntryType.FailureAudit:
						myRow["RECORDTYPE"] = "FailureAudit";
						break;
					case EventLogEntryType.Information:
						myRow["RECORDTYPE"] = "Information";
						break;
					case EventLogEntryType.SuccessAudit:
						myRow["RECORDTYPE"] = "SuccessAudit";
						break;	
					case EventLogEntryType.Warning:
						myRow["RECORDTYPE"] = "Warning";
						break;	
				}
				myRow["APPROGRAME"] = this.LogName;
				myRow["PAGE"] = this.Page;
				myRow["OPERATION"] = this.Operation;
                //this.User = System.Web.HttpContext.Current.User.Identity.Name;

				if (this.User == "")
				{
					myRow["USERNAME"] = "Anonymity";
				}
				else
				{
					myRow["USERNAME"] = this.User;
				}
				myRow["CLIENT"] = this.Client;
				myRow["SERVER"] = this.Server;
				if (this.KeyWord.Length >= 300)
				{
					myRow["KEYRECDMSG"] = this.KeyWord.Substring(0, 300);
				}
				else
				{
					myRow["KEYRECDMSG"] = this.KeyWord;
				}

			//	int result = logrecordTable.ExecuteNonQuery(CommandType.Text, "AddLog", myRow);
                string sqldate=string.Format("");
                mysqlconn msq=new mysqlconn();
                int result1 = MySqlHelper.ExecuteNonQuery(msq.getmysqlcon(),sqldate);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			
		}
		

//		/// <summary>
//		/// 写Log
//		/// </summary>
//		public void  WriteLogEvent()
//		{
//			try
//			{
//				if(EventLog.SourceExists(EventSource)&&EventLog.Exists(LogName))
//				{
//					string Message;
//					Message=Page+"|";
//					Message+=Operation+"|";
//					Message+=User+"|";
//					Message+=Client+"|";
//					Message+=Server+"|";
//					Message+=KeyWord+"|";
//
//					EventLog msg = new EventLog (LogName);
//					msg.Source =EventSource ;
//					msg.WriteEntry(Message,EventType);
//				}
//			 
//			}
//			catch(Exception ex)
//			{
//				throw ex;
//			}
//			
//
//
//		}

		
//		public DataTable GetAllLog()
//		{
//			DataTable dtLog=new DataTable();
//
//			dtLog.Columns.Add("Source", System.Type.GetType("System.String"));
//			dtLog.Columns.Add("Type", System.Type.GetType("System.String"));
//			dtLog.Columns.Add("Page", System.Type.GetType("System.String"));
//			dtLog.Columns.Add("Operation", System.Type.GetType("System.String"));
//			dtLog.Columns.Add("User", System.Type.GetType("System.String"));
//			dtLog.Columns.Add("Client", System.Type.GetType("System.String"));
//			dtLog.Columns.Add("Server", System.Type.GetType("System.String"));
//			dtLog.Columns.Add("Time", System.Type.GetType("System.String"));
//			dtLog.Columns.Add("KeyWord", System.Type.GetType("System.String"));
//
//
//			EventLog myNewLog = new EventLog();
//			myNewLog.Log = LogName;          
//			foreach(EventLogEntry entry in myNewLog.Entries)
//			{
//				DataRow newRow = dtLog.NewRow();
//
//				string[] Message = entry.Message.Split('|'); 
//				// Set values in the columns:
//				newRow["Source"] = entry.Source.ToString();
//				newRow["Type"] = entry.EntryType.ToString();
//				newRow["Page"]=Message[0].ToString();
//				newRow["Operation"]=Message[1].ToString();
//				newRow["User"]=Message[2].ToString();
//				newRow["Client"]=Message[3].ToString();
//				newRow["Server"]=Message[4].ToString();
//				newRow["Time"]=entry.TimeWritten.ToString();
//				newRow["KeyWord"]=Message[5].ToString();
//				// Add the row to the rows collection.
//				dtLog.Rows.Add(newRow);
//
//			}
//
//			return dtLog;
//		}

	}
}
