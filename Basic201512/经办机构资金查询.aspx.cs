using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace CL.Utility.Web.BasicData
{
    /// <summary>
    /// Meter 的摘要说明。
    /// </summary>
    public partial class Register : System.Web.UI.Page
    {
        //#region "自定义属性"
        //internal static Manager manager = Managers.Members["NewUtilityOra"] as Manager;
        //internal static ISingleTable entityUsers = manager.Entities["USERS"] as ISingleTable;
        //private DataTable dtUsers;

        //private string bindPCKey = "USER_ID";//绑定 能源节点数据的主键

        //internal static WriteLog wl = new WriteLog();
        //internal static UserInterface ui = new UserInterface();
        //private const string PAGE_NAME = "资金录入";

        //public const string sPMS_CTG_ID = "USER_ID";
        //public const string sPMS_CTG_NAME = "USER_NAME";
        //public const string sPwd = "USER_PWD";
        //public const string sUSE_IDT = "USE_IDT";
        //public const string sCRT_DATE = "CRT_DATE";
        //public const string sUPD_DATE = "UPD_DATE";
        //public const string sDES = "DES";


        //private const string PK = "projectID";
        //public const string sID = "projectID";
        //public const string sName = "projectName";//public时页面能引用，private时不可以
        //protected System.Data.DataTable _dtData;
        //protected System.Data.DataTable _dtData1;
        //mysqlconn msq = new mysqlconn();
        //string sqldata1 = string.Format("select * from e_project");
        //string sqldata = string.Format("select * from e_handlingunit");
        //string sqldatadrop = string.Format("select *from e_recipientsfenpei");
        //#endregion
        mysqlconn msq = new mysqlconn();
        
        string nameNow = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
             if (!Page.IsPostBack)
             {
                 //string strhand = string.Format("select (select sum(useMoney) from e_moneytrack where DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by handlingunitID) as thisMonth,benfactorFrom,(sum(capitalIn)-sum(capitalEarn)) as useUp,sum(capitalEarn) as remain from e_capital group by handlingunitID");
                 //string strhand = string.Format("(select benfactorFrom,(sum(capitalIn)-sum(capitalEarn)) as useUp,sum(capitalEarn) as remain from e_capital group by handlingunitID) aaa join (select handlingunitID,sum(useMoney) as thisMonth from e_moneytrack where DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by handlingunitID) bbb on bbb.handlingunitID=aaa.handlingunitID");
                 //string strhand = string.Format("select sum(useMoney) as thisMonth,e_capital.benfactorFrom,(sum(capitalIn)-sum(capitalEarn)) as useUp,sum(capitalEarn) as remain from e_capital,e_moneytrack where e_capital.handlingunitID=e_moneytrack.handlingunitID and DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by e_capital.handlingunitID");
                 //(select sum(useMoney) from e_moneytrack where DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by handlingunitID) as thisMonth,
                 string strhand = string.Format("select * from (select handlingunitID,benfactorFrom,sum(useMoney) as thisMonth from e_moneytrack where DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by handlingunitID) aaa,(select handlingunitID,sum(capitalEarn) as remain from e_capital group by handlingunitID) bbb where aaa.handlingunitID=bbb.handlingunitID");
                 //"(select handlingunitID,sum(useMoney) as monthUse from e_moneytrack where DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by handlingunitID) aaa"
                 //"(select handlingunitID,benfactorFrom,(sum(capitalIn)-sum(capitalEarn)) as useUp,sum(capitalEarn) as remain from e_capital group by handlingunitID) bbb"
                 BindData(strhand);
                
             }        
        }

        //#region Web 窗体设计器生成的代码
        //override protected void OnInit(EventArgs e)
        //{
        //    //
        //    // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
        //    //
        //    InitializeComponent();
        //    base.OnInit(e);
        //}

        ///// <summary>
        ///// 设计器支持所需的方法 - 不要使用代码编辑器修改
        ///// 此方法的内容。
        ///// </summary>
        //private void InitializeComponent()
        //{
           
        //}
        //#endregion
        //#region "转换函数"
        ////防止页面滚动"
        ////		private void RetainScrollPosition()
        ////		{
        ////			StringBuilder saveScrollPosition = new StringBuilder ();
        ////			StringBuilder setScrollPosition = new StringBuilder ();
        ////
        ////			RegisterHiddenField("__SCROLLPOS", "0");
        ////
        ////			saveScrollPosition.Append("<script language='javascript'>");
        ////			saveScrollPosition.Append("function saveScrollPosition() {");
        ////			saveScrollPosition.Append("    document.forms[0].__SCROLLPOS.value = thebody.scrollTop;");
        ////			saveScrollPosition.Append("}");
        ////			saveScrollPosition.Append("thebody.onscroll=saveScrollPosition;");
        ////			saveScrollPosition.Append("</script>");
        ////
        ////			RegisterStartupScript("saveScroll", saveScrollPosition.ToString());
        ////
        ////			if (Page.IsPostBack)
        ////			{
        ////				setScrollPosition.Append("<script language='javascript'>");
        ////				setScrollPosition.Append("function setScrollPosition() {");
        ////				setScrollPosition.Append("    thebody.scrollTop = " + Request["__SCROLLPOS"] + ";");
        ////				setScrollPosition.Append("}");
        ////				setScrollPosition.Append("thebody.onload=setScrollPosition;");
        ////				setScrollPosition.Append("</script>");
        ////
        ////				RegisterStartupScript("setScroll", setScrollPosition.ToString());
        ////			}
        ////		}

        ////正则表达式匹配
        //private bool IsValidNum(string strIn)
        //{
        //    // Return true if strIn is in valid e-mail format.
        //    return Regex.IsMatch(strIn, @"^[0-9]*[1-9][0-9]*$");

        //    //		^\d+$　　//匹配非负整数（正整数 + 0） 
        //    //^[0-9]*[1-9][0-9]*$　　//匹配正整数 
        //    //^((-\d+)|(0+))$　　//匹配非正整数（负整数 + 0） 
        //    //^-[0-9]*[1-9][0-9]*$　　//匹配负整数 
        //    //^-?\d+$　　　　//匹配整数 
        //    //^\d+(\.\d+)?$　　//匹配非负浮点数（正浮点数 + 0） 
        //    //^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$　　//匹配正浮点数 
        //    //^((-\d+(\.\d+)?)|(0+(\.0+)?))$　　//匹配非正浮点数（负浮点数 + 0） 
        //    //^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$　　//匹配负浮点数 
        //    //^(-?\d+)(\.\d+)?$　　//匹配浮点数 
        //    //^[A-Za-z]+$　　//匹配由26个英文字母组成的字符串 
        //    //^[A-Z]+$　　//匹配由26个英文字母的大写组成的字符串 
        //    //^[a-z]+$　　//匹配由26个英文字母的小写组成的字符串 
        //    //^[A-Za-z0-9]+$　　//匹配由数字和26个英文字母组成的字符串 
        //    //^\w+$　　//匹配由数字、26个英文字母或者下划线组成的字符串 
        //    //^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$　　　　//匹配email地址 
        //    //^[a-zA-z]+://匹配(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$　　//匹配url 
        //}
        //public bool Checked(object obj)
        //{
        //    if (obj.ToString() == "0")
        //    {
        //        return false;
        //    }
        //    else return true;
        //}
        //#endregion

        //private void BindDataSet()
        //{
        //    string strhand = string.Format("select benfactorFrom,handlingunitID from e_handlingunit");
        //    DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),strhand);
        //    DataView dv = new DataView(ds.Tables[0]);
        //    dpdhand.DataSource = dv;
            
        //    dpdhand.DataTextField = "benfactorFrom";
        //    dpdhand.DataBind(); 
        //}
        private void BindData(string s)
        {
            DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), s);
            DataView dv = new DataView(ds.Tables[0]);
            GridView1.DataSource = dv;
            GridView1.DataKeyNames = new string[] { "benfactorFrom" };//主键
            GridView1.DataBind();
         
        }

        //protected void btyes_Click(object sender, EventArgs e)
        //{
        //    string strcapall = string.Format("select sum(capitalIn) from e_capital where handlingunitID=(select handlingunitID from e_handlingunit where benfactorFrom='{0}')", dpdhand.Text);
        //    MySqlDataReader sqldatareader = msq.getmysqlread(strcapall);
        //    string strcapnow = string.Format("select sum(capitalEarn) from e_capital where handlingunitID=(select handlingunitID from e_handlingunit where benfactorFrom='{0}')", dpdhand.Text);
        //    MySqlDataReader sqldatareader1 = msq.getmysqlread(strcapnow);
            
        //    while (sqldatareader1.Read())
        //    {
        //        lbcaptIDnow.Text = sqldatareader1.GetString(0);
        //    }
            
        //    while (sqldatareader.Read())
        //    {
        //        int i = int.Parse(sqldatareader.GetString(0));
        //        int ia = int.Parse(lbcaptIDnow.Text);
        //        lbcaptIDall.Text = (i - ia).ToString();
               
        //    }
            
        //    NLogTest nlog = new NLogTest();
        //    string sss = "查询经办机构财政情况：" + dpdhand.Text;
        //    nlog.WriteLog(Session["UserName"].ToString(), sss);
            
            
        //}
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    //string queryString="select benfactorFrom,(sum(capitalIn)-sum(capitalEarn)) as useUp,sum(capitalEarn) as remain from e_capital where group by handlingunitID";
        //    //BindData(queryString);

        //}
}
}
