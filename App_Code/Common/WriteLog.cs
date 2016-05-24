using System;
using System.Configuration;
using System.Web;

namespace CL.Utility.Web.Common
{
	/// <summary>
	/// WriteLog 的摘要说明。
	/// </summary>
	public class WriteLog
	{
		public void WriteLogData(string strLogpage,string strOpertation,string strKeyWord,System.Diagnostics.EventLogEntryType strEventType)
		{


            LogEvent log = new LogEvent(ConfigurationManager.AppSettings["LogName"], ConfigurationManager.AppSettings["SourceName"]);
			log.Page=strLogpage;
			log.Operation=strOpertation;
			log.KeyWord =strKeyWord;
			log.EventType = strEventType;
			log.Server=HttpContext.Current.Server.MachineName;
			log.Client=HttpContext.Current.Request.UserHostAddress;
			log.User =HttpContext.Current.User.Identity.Name;

			log.WriteLogEvent();
		}
	}
}
