using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//使用数据访问层添加的必备引用
using DataEntity.EntityManager;
using DataEntity.Entity;
using System.Text.RegularExpressions;
using CL.Utility.Web.Common;
using System.Configuration;
//

using eWorld.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
using System.Web.Security;
using LyfHelper;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class test3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //
            string action = Request.QueryString["action"];
            string id = Request.QueryString["userid"];
            string name = Request.QueryString["n"];
            //注销
            if (action == "signout")
            {
                Session.Remove("UserName");
                //  WriteLog wrtl=new WriteLog("用户注销", id, System.Diagnostics.EventLogEntryType.SuccessAudit,name);  
                //   WriteLog("用户注销", id, System.Diagnostics.EventLogEntryType.SuccessAudit,name);      
                FormsAuthentication.SignOut();
            }
        }

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.ForeColor = Color.Red;
        string Mstrsqlcon = "server=localhost;user id=root;password=123456;database=mscsdb";
        MySqlConnection myCon = new MySqlConnection(Mstrsqlcon);
        //获取输入的用户名、密码
        string inputID = this.txtID.Text.Trim();
       // string inputID = Request.QueryString["username"].ToString();
        string inputPwd = this.txtPWD.Text.Trim();
       // string inputPwd = Request.QueryString["password"].ToString();

        //判断用户名、密码不能为空
        if (string.IsNullOrEmpty(inputID) || string.IsNullOrEmpty(inputPwd))
        {
            lblMsg.Text = "请输入用户名和密码";
            return;
        }

        bool bAuth = false, bPermission = true;
        string sRole = "";
        string sUserName = "";
        string sbenfactorFrom = "";       

        //判断是否为数据库中用户、且密码是否正确
        //HybridDictionary hd = new HybridDictionary();
        //hd.Add("user", inputID);
        //_dtUserRoleView = _entityUserRoleView.ExecuteDataTable2(CommandType.Text, "select * from e_user where user=hd", hd);
        //DataView dv = new DataView(_dtUserRoleView);
        string sqldate = string.Format("select * from e_user where user='{0}' and password='{1}'", inputID, inputPwd);
        mysqlconn msqlconn = new mysqlconn();

        MySqlDataAdapter sda = new MySqlDataAdapter(sqldate, msqlconn.getmysqlcon());
        DataSet ds = MySqlHelper.ExecuteDataset(msqlconn.getmysqlcon(), sqldate);
        DataView dv = new DataView(ds.Tables[0]);
        //   DataTable dv=ds.Tables[0];
        //   sda.Fill(ds);                            
        if (dv.Count>0)
        {

            DataRowView dr = dv[0];
            if (inputPwd == dr["password"].ToString().Trim())
            {
                bAuth = true;
                sRole = dr["userRole"].ToString().Trim();//权限
                sUserName = dr["user"].ToString().Trim();//用户名
                sbenfactorFrom = dr["benfactorFrom"].ToString().Trim();//所属机构          
                int i = 0;
                int.TryParse(dr["userRole"].ToString().Trim(), out i);//是否被启用
                if (i == 1)
                { bPermission = true; }
            }

            bAuth = true;
         //   sRole = ds.ToString().Trim();


        }

        //
        if (bAuth)
        {
            if (bPermission == false)
            {
               // lblMsg.Text = "您没有开通权限！请联系管理员！";
                // WriteLog("用户登录", inputID, System.Diagnostics.EventLogEntryType.FailureAudit);
                return;
            }
            Session.Add("UserName", sUserName);
            Session.Add("UserID", inputID);
            Session.Add("benfactorFrom", sbenfactorFrom);
            Session.Add("userRole",sRole);
           
            List<string> list = new List<string>();
            if (Application["Users"] != null)
            {
                list = (List<string>)Application["Users"];

            }
            if (!list.Contains(sUserName))
            {
                list.Add(sUserName);
            }
            Application.Add("Users", list);
            //写入日志
            //  WriteLog("用户登录", inputID, System.Diagnostics.EventLogEntryType.SuccessAudit, sUserName);
            //CreatTicket(inputID, inputID + "|" +inputPwd+"|"+ sUserName + "|" + sRole);
            //创建身份验证票
            CreatTicket(inputID, inputPwd, sUserName, sRole, this);

        }
        else
        {

         //   lblMsg.Text = "用户名或者密码不存在";
            //   WriteLog("用户登录", inputID, System.Diagnostics.EventLogEntryType.FailureAudit);
            return;
        }
    }

    private void WriteLog(string strOpertation, string strKeyWord, System.Diagnostics.EventLogEntryType strEventType, string user)
    {
        LogEvent log = new LogEvent(System.Configuration.ConfigurationManager.AppSettings["LogName"], System.Configuration.ConfigurationManager.AppSettings["SourceName"]);
        log.Page = "用户登录";
        log.Operation = strOpertation;
        log.KeyWord = strKeyWord;
        log.EventType = strEventType;
        log.Server = Server.MachineName;
        log.Client = Request.UserHostAddress;
        log.User = user;

        log.WriteLogEvent();
    }
    private void WriteLog(string strOpertation, string strKeyWord, System.Diagnostics.EventLogEntryType strEventType)
    {
        LogEvent log = new LogEvent(System.Configuration.ConfigurationManager.AppSettings["LogName"], System.Configuration.ConfigurationManager.AppSettings["SourceName"]);
        log.Page = "用户登录";
        log.Operation = strOpertation;
        log.KeyWord = strKeyWord;
        log.EventType = strEventType;
        log.Server = Server.MachineName;
        log.Client = Request.UserHostAddress;
        log.User = "";

        log.WriteLogEvent();
    }
    public void CreatTicket(string userID, string userPwd, string userName, string userRole, Page page)
    {
        string userData = userID + "|" + userPwd + "|" + userName + "|" + userRole;
        //构造身份验证票
        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userID, DateTime.Now, DateTime.Now.AddHours(2), false, userData);
        //加密
        string value = FormsAuthentication.Encrypt(ticket);
        string name = FormsAuthentication.FormsCookieName; //.Auth
        //存入cookie
        HttpCookie cook = new HttpCookie(name, value);
        page.Response.Cookies.Add(cook);

        string url = page.Request.QueryString["ReturnUrl"];//ReturnUrl：跳转过来的网页都自动生成
        if (!string.IsNullOrEmpty(url)) //被动登录
        {
            page.Response.Redirect(url, true); //转到目标页面
        }
        else
        {
            //url = FormsAuthentication.DefaultUrl;//Default.aspx
            // url = "Default_new.aspx";//菜单在顶端
            //url = "Default.aspx";//菜单在左侧
            url = "test.aspx";
            page.Response.Redirect(url, true);
        }
    }
}