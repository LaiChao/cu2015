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
using System.Data.Odbc;
using System.Data.OracleClient;
using eWorld.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
using System.Web.Security;
//MySQL数据连接
using MySql.Data;
using MySql.Data.MySqlClient;
public partial class Default_new : System.Web.UI.Page
{
    //private Manager _manager;
    //private ISingleTable _entity;//
    //private ISingleTable _entityPMS;//
    //protected DataTable _dtData;
    protected string inputId="admin";
    protected string inputPwd="admin";
    protected string inputName = "admin";
    protected string signoutURL;
    private const string PK = "USER_ID";
    protected string Menus = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //string strid= Request.QueryString["id"];
            Lbtitle.Text = Session["userRole"].ToString();
            ViewState["flag"] = Session["userRole"].ToString();
            ViewState["strid"] = Request.QueryString["id"];
            if (ViewState["strid"] != null)
            {               
                string str = ViewState["strid"].ToString();
            }
            else 
            {
                ViewState["strid"] = "1";
                string str = ViewState["strid"].ToString();
            }
            load();
        }
        //if (!this.IsPostBack)
        //{
        //    string action = Request.QueryString["action"];
        //    string id = Request.QueryString["userid"];
        //    if (action == "signout")
        //    {
        //        FormsAuthentication.SignOut();
        //        WriteLog("用户注销", id, System.Diagnostics.EventLogEntryType.SuccessAudit);
        //    }
        //}
    }

    private void load()
    {
       
        //Session["UserName"] = "admin";
        ///*
        if (Session["UserName"]==null)
        {
            Response.Redirect("loginnew.aspx");
        }
        //_manager = (Manager)(Managers.Members["NewUtilityOra"]);
        //_entity = (ISingleTable)(_manager.Entities["USER_ROLE_PMS_VIEW"]);
        //_entityPMS = (ISingleTable)(_manager.Entities["PERMISSION_VIEW"]);
        //return;
        //MySQL数据库连接
        //string M_str_sqlcon = "server=localhost;user id=root;password=123456;database=mscsdb";
        //MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
        
        //获取用户名
        string cookieName = FormsAuthentication.FormsCookieName;
        HttpCookie authCookie = Context.Request.Cookies[cookieName];
        if (authCookie == null)
        {
            return;
        }
        FormsAuthenticationTicket authTicket = null;
        authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        if (authTicket == null)
        {
            return;
        }

        string[] IdPwdNameRole = authTicket.UserData.ToString().Split('|');  
        inputId = IdPwdNameRole[0];   
        inputPwd = IdPwdNameRole[1];        
        inputName = IdPwdNameRole[2];
        //*/

        //string inputId = "";
        //string inputPwd = "";
        //string inputName = "";
        //string inputRole = "";

        //LyfHelper.lyf.GetTicket(this, inputId, inputPwd, inputName, inputRole);
      //  DataView dv = new DataView(_dtData);
        //获取权限集合
       // _dtData = _entityPMS.ExecuteDataTable2(CommandType.Text, "select * from e_permission order by PMS_CTG_ID,DISPLAY_ORDER");
      //  string sqlserver = string.Format("select * from e_permission order by DISPLAY_ORDER");
        mysqlconn mysql=new mysqlconn();
        if(ViewState["strid"].ToString()=="1")
       {
           Lbtitle.Text = "基本工具";
           if (ViewState["flag"].ToString() == "1")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod1' and USE_IDT='1' order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               //mysql.getmysqlcon().Close();
               
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "2")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod1' and (USE_IDT='1' or USE_IDT='2')  order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "3")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod1' and ( USE_IDT='1' or USE_IDT='2' or USE_IDT='3') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";
               
               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "4")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod1' and ( USE_IDT='1' or USE_IDT='2' or USE_IDT='3' or USE_IDT='4') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
              
           }
           }
       if (ViewState["strid"].ToString() == "2")
       {
           Lbtitle.Text = "用户与机构管理";
           if (Session["userRole"].ToString() == "1")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod2' and USE_IDT='1' order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "2")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod2' and ( USE_IDT='1' or USE_IDT='2') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "3")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod2' and ( USE_IDT='1' or USE_IDT='2' or USE_IDT='3') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "4")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod2' and  ( USE_IDT='1' or USE_IDT='2' or USE_IDT='3' or USE_IDT='4') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
       }
       if (ViewState["strid"].ToString()== "3")
       {
           Lbtitle.Text = "项目管理";
           if (Session["userRole"].ToString() == "1")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod3' and USE_IDT='1' order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "2")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod3' and ( USE_IDT='1' or USE_IDT='2') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "3")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod3' and (USE_IDT='1' or USE_IDT='2' or USE_IDT='3') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "4")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod3' and ( USE_IDT='1' or USE_IDT='2' or USE_IDT='3' or USE_IDT='4') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
               
           }
       }
       if (ViewState["strid"].ToString() == "4")
       {
           Lbtitle.Text = "捐赠人管理";
           if (Session["userRole"].ToString() == "1")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod4' and USE_IDT='1' order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "2")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod4' and ( USE_IDT='1' or USE_IDT='2') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "3")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod4' and ( USE_IDT='1' or USE_IDT='2' or USE_IDT='3') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "4")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod4' and ( USE_IDT='1' or USE_IDT='2' or USE_IDT='3' or USE_IDT='4') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
       }
       if (ViewState["strid"].ToString() == "5")
       {
           Lbtitle.Text = "受助人管理";
           if (Session["userRole"].ToString() == "1")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod5' and USE_IDT='1' order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "2")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod5' and ( USE_IDT='1' or USE_IDT='2') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "3")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod5' and ( USE_IDT='1' or USE_IDT='2' or USE_IDT='3') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "4")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod5' and ( USE_IDT='1' or USE_IDT='2' or USE_IDT='3' or USE_IDT='4') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
       }
       if (ViewState["strid"].ToString() == "6")
       {
           Lbtitle.Text = "日志管理";
           if (Session["userRole"].ToString() == "1")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod6' and USE_IDT='1' order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "2")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod6' and (USE_IDT='1' or USE_IDT='2') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "3")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod6' and ( USE_IDT='1' or USE_IDT='2' or USE_IDT='3') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "4")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod6' and ( USE_IDT='1' or USE_IDT='2' or USE_IDT='3' or USE_IDT='4') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
       }
       if (ViewState["strid"].ToString()== "7")
       {
           Lbtitle.Text = "统计查询";
           if (Session["userRole"].ToString() == "1")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod7' and USE_IDT='1' order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "2")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod7' and (USE_IDT='1' or USE_IDT='2') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();

           }
           if (Session["userRole"].ToString() == "3")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod7' and (USE_IDT='1' or USE_IDT='2' or USE_IDT='3') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }
           if (Session["userRole"].ToString() == "4")
           {
               string sqlserver = string.Format("select * from e_permission where PMS_CTG_ID='mod7' and (USE_IDT='1' or USE_IDT='2' or USE_IDT='3' or USE_IDT='4') order by DISPLAY_ORDER");
               DataSet dv = MySqlHelper.ExecuteDataset(mysql.getmysqlcon(), sqlserver);
               DataTable ds = dv.Tables[0];
               signoutURL = " <a href=\"Login.aspx?action=signout&userid=" + inputId + "&n=" + inputName + "\" >注销</a> \n";

               //生成页面
               string sPage = "";
               string sBody = "";
               int iMenuNum = 0;
               //sBody = loadUserInfo(userName,userId);
               if (ds.Rows.Count > 0)
               {

                   string sTitle = "";
                   for (int i = 0; i < ds.Rows.Count; i++)
                   {
                       string sT = ds.Rows[i]["PMS_CTG_NAME"].ToString().Trim();//权限类型名称
                       string sPName = ds.Rows[i]["PMS_NAME"].ToString().Trim();//权限名称
                       string sUrl = ds.Rows[i]["URL"].ToString().Trim();//地址
                       bool b = sPName != sTitle;
                       if (b)
                       {
                           if (i > 0)
                           { sBody += "</ul></li>"; }
                           sTitle = sT;
                           //加载标题/权限类别，如：基本数据管理；
                           sBody += loadMenusTitle(sPName, iMenuNum, sUrl);
                           iMenuNum++;
                       }
                       //加载列表/权限
                       // sBody += loadMenusItem(sPName, sUrl);
                       //if (i==dv.Count-1 )
                       //{
                       //    sBody += "</ul>";
                       //};
                   }
               }
               sPage = loadMenusHead(iMenuNum) + sBody + loadFoot();
               Menus = sPage;
               mysql.getmysqlcon().Close();
           }

       }
       


      
    }



    private string loadMenusHead(int j)
    {
        //string s = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"> \n";
        //s += "<html xmlns=\"http://www.w3.org/1999/xhtml\"> \n";
        //s += "<head> \n";
        //s += "<title>目录</title> \n";
        //s += "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" /> \n";
        //s += "<link href=\"css/menus.css\" rel=\"stylesheet\" type=\"text/css\" /> \n";
        //s += "<script src=\"Scripts/jquery-1.4.1.min.js\" type=\"text/javascript\"></script> \n";
        //s += "<script src=\"Scripts/left.js\" type=\"text/javascript\"></script> \n";//引用脚本
        //s += "</head> \n";
        //s += "<body> \n";
        //// s += "<form id=\"Form1\" method=\"post\" runat=\"server\"> \n";
        //s += "<div class=\"menu2\">";
        string s = "<ul> ";
        return s;
    }
    /// <summary>
    /// 加载目录标题
    /// </summary>
    /// <param name="sTitle">标题名称</param>
    /// <param name="i">标题id号</param>
    /// <returns></returns>
    private string loadMenusTitle(string sTitle, int i, string url)
    {
        string s = "<li><p> ";
      //  s += sTitle;
        // s += "</li> \n";
        s += "<a href=\"" + url + "\" target=\"main\" >" + sTitle + "</a> ";
        s += "</li> ";
        s += "</p><ul>";
        return s;
    }
    /// <summary>
    /// 加载列表项
    /// </summary>
    /// <param name="sItem">列表项名称</param>
    /// <param name="url">链接的地址</param>
    /// <returns></returns>
    private string loadMenusItem(string sItem, string url)
    {
        string s = "    <li> ";
        s += "<a href=\"" + url + "\" target=\"main\" >" + sItem + "</a> ";
        s += "</li> \n";
        return s;
    }
    /// <summary>
    /// 加载页脚
    /// </summary>
    /// <returns></returns>
    private string loadFoot()
    {
        string s = "</ul></li>\n</ul>";
       // s+="</div>\n";
        // s+="</form>";
       // s += "</body></html> \n";
        return s;
    }
}