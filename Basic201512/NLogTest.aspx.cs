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

public partial class Basic201512_NLogTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            MyClass mc = new MyClass();
            mc.MyMethod1();
        }

    }

    public class MyClass
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void MyMethod1()
        {
            logger.Info("Sample informational message 1");
            logger.Log(LogLevel.Info, "Sample informational message 2");
        }
    }
}