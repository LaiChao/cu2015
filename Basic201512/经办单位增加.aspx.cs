using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

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

public partial class Basic201512_经办单位增加 : System.Web.UI.Page
{

    #region "自定义属性"
    //internal static Manager manager = Managers.Members["NewUtilityOra"] as Manager;
    //internal static ISingleTable entityUsers = manager.Entities["USERS"] as ISingleTable;
    //private DataTable dtUsers;

    private string bindPCKey = "USER_ID";//绑定 能源节点数据的主键

    internal static WriteLog wl = new WriteLog();
    internal static UserInterface ui = new UserInterface();
    private const string PAGE_NAME = "用户";

    public const string sPMS_CTG_ID = "USER_ID";
    public const string sPMS_CTG_NAME = "USER_NAME";
    public const string sPwd = "USER_PWD";
    public const string sUSE_IDT = "USE_IDT";
    public const string sCRT_DATE = "CRT_DATE";
    public const string sUPD_DATE = "UPD_DATE";
    public const string sDES = "DES";


    private const string PK = "projectID";
    public const string sID = "projectID";
    public const string sName = "projectName";//public时页面能引用，private时不可以
    protected System.Data.DataTable _dtData;
    protected System.Data.DataTable _dtData1;
    mysqlconn msq = new mysqlconn();
    string sqldata1 = string.Format("select * from e_project");
    string sqldata = string.Format("select * from e_recipientscan");
    string sqldatadrop = string.Format("select *from e_recipientsfenpei");
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
        {
            Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
            return;
        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        if (benfactorFrom.Text.Length <= 0)
        {
            LabelError.Text = "经办单位名称不能为空";
            return;
        }
        if (benfactorFrom.Text.Length > 0)
        {//判断是否重复
            string sqldate = string.Format("select * from e_handlingunit where benfactorFrom='{0}'", benfactorFrom.Text.ToString());

            mysqlconn mys = new mysqlconn();
            MySqlDataAdapter sda = new MySqlDataAdapter(sqldate, mys.getmysqlcon());
            DataSet ds = MySqlHelper.ExecuteDataset(mys.getmysqlcon(), sqldate);
            DataView dv = new DataView(ds.Tables[0]);
            if (dv.Count > 0)
            {
                //LabelError.ForeColor = System.Drawing.Color.Red;
                LabelError.Text = "该经办单位名称已存在！";
                return;
            }
        }
        if (address.Text.Length <= 0)
        {
            LabelError.Text = "经办单位地址不能为空";
            return;
        }
        if (contactPerson.Text.Length <= 0)
        {
            LabelError.Text = "联系人不能为空";
            return;
        }
        if (TEL.Text.Length <= 0)
        {
            LabelError.Text = "联系方式不能为空";
            return;
        }
        if (TEL.Text.Length > 0 && contactPerson.Text.Length > 0 && address.Text.Length > 0 && benfactorFrom.Text.Length > 0)
        {
            string str11 = string.Format("insert into e_handlingunit (benfactorFrom,address,contactPerson,TEL) VALUES ('{0}','{1}','{2}','{3}')", benfactorFrom.Text, address.Text, contactPerson.Text, TEL.Text);
            int res = msq.getmysqlcom(str11);
            if (res > 0)
            {
                NLogTest nlog = new NLogTest();
                string sss = "管理员增加了经办单位：" + benfactorFrom.Text.ToString();
                nlog.WriteLog(Session["UserName"].ToString(),sss);
                LabelError.Text = "经办单位增加成功";
                TEL.Text = contactPerson.Text = address.Text = benfactorFrom.Text = "";
            }
            else
            {
                LabelError.Text = "经办单位增加失败";
            }
        }
    }
}