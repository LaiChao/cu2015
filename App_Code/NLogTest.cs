using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;

using NLog;
//使用数据访问层添加的必备引用
using DataEntity.EntityManager;
using DataEntity.Entity;
using System.Text.RegularExpressions;
using CL.Utility.Web.Common;
using System.Configuration;
using luyunfei;
//mysql数据库连接
using MySql.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// NLogTest 的摘要说明
/// </summary>
public class NLogTest
{
	public NLogTest()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    private static Logger logger = LogManager.GetCurrentClassLogger();

    //public void MyMethod1(string s)
    //{
    //    logger.Info(s);
    //    //logger.Log(LogLevel.Info, "Sample informational message 2");
    //}

    public void WriteLog(string user,string message)
    {
        LogEventInfo lei = new LogEventInfo(LogLevel.Info, "", "");
        lei.Properties["user"] = user;
        lei.Properties["message"] = message;
        logger.Log(lei);
    }
}