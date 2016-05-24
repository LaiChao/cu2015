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

namespace CL.Utility.Web.BasicData
{
    /// <summary>
    /// Meter 的摘要说明。
    /// </summary>
    /// 
    public partial class Register : System.Web.UI.Page
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
        string sqldata = string.Format("select * from e_handlingunit");
        string sqldatadrop = string.Format("select *from e_recipientsfenpei");
        #endregion

        string nameNow = "";
        public static string tableTitle = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string urlNow = Request.Url.ToString();
            string[] temp = urlNow.Split('=');
            // string Files="";
            //string[] arrFiles;
            foreach (string s in temp)
            {
                nameNow = s;
            }
            if (!Page.IsPostBack)
            {
                string strpro = string.Format("select projectID,projectName,projectDir,benfactorFrom,palnMoney,recipientsNow,telphoneName,telphoneADD,shenpi1,shenpi2 from e_project where projectID='{0}'", nameNow);
                MySqlDataReader mysqlreader = msq.getmysqlread(strpro);
                while (mysqlreader.Read())
                {
                    LbproID.Text = mysqlreader.GetString(0);
                    Lbproname.Text = mysqlreader.GetString(1);
                    projectDir.Text = mysqlreader.GetString(2);
                    Lbbenfrom.Text = mysqlreader.GetString(3);
                    Lbplan.Text = mysqlreader.GetString(4);
                    Lbrestnow.Text = mysqlreader.GetString(5);
                    Lbtelname.Text = mysqlreader.GetString(6);
                    Lbtelladd.Text = mysqlreader.GetString(7);
                    //if (mysqlreader.GetString(9) == "1")
                    //{
                    //    btchecky2.Visible = false;
                    //}
                    //else
                    //{
                    //    btchecky2.Visible = true;
                    //}
                }
                BindDataSet();
                BindData();
            }

        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion


        #region "转换函数"
        //防止页面滚动"
        //		private void RetainScrollPosition()
        //		{
        //			StringBuilder saveScrollPosition = new StringBuilder ();
        //			StringBuilder setScrollPosition = new StringBuilder ();
        //
        //			RegisterHiddenField("__SCROLLPOS", "0");
        //
        //			saveScrollPosition.Append("<script language='javascript'>");
        //			saveScrollPosition.Append("function saveScrollPosition() {");
        //			saveScrollPosition.Append("    document.forms[0].__SCROLLPOS.value = thebody.scrollTop;");
        //			saveScrollPosition.Append("}");
        //			saveScrollPosition.Append("thebody.onscroll=saveScrollPosition;");
        //			saveScrollPosition.Append("</script>");
        //
        //			RegisterStartupScript("saveScroll", saveScrollPosition.ToString());
        //
        //			if (Page.IsPostBack)
        //			{
        //				setScrollPosition.Append("<script language='javascript'>");
        //				setScrollPosition.Append("function setScrollPosition() {");
        //				setScrollPosition.Append("    thebody.scrollTop = " + Request["__SCROLLPOS"] + ";");
        //				setScrollPosition.Append("}");
        //				setScrollPosition.Append("thebody.onload=setScrollPosition;");
        //				setScrollPosition.Append("</script>");
        //
        //				RegisterStartupScript("setScroll", setScrollPosition.ToString());
        //			}
        //		}

        //正则表达式匹配
        private bool IsValidNum(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^[0-9]*[1-9][0-9]*$");

            //		^\d+$　　//匹配非负整数（正整数 + 0） 
            //^[0-9]*[1-9][0-9]*$　　//匹配正整数 
            //^((-\d+)|(0+))$　　//匹配非正整数（负整数 + 0） 
            //^-[0-9]*[1-9][0-9]*$　　//匹配负整数 
            //^-?\d+$　　　　//匹配整数 
            //^\d+(\.\d+)?$　　//匹配非负浮点数（正浮点数 + 0） 
            //^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$　　//匹配正浮点数 
            //^((-\d+(\.\d+)?)|(0+(\.0+)?))$　　//匹配非正浮点数（负浮点数 + 0） 
            //^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$　　//匹配负浮点数 
            //^(-?\d+)(\.\d+)?$　　//匹配浮点数 
            //^[A-Za-z]+$　　//匹配由26个英文字母组成的字符串 
            //^[A-Z]+$　　//匹配由26个英文字母的大写组成的字符串 
            //^[a-z]+$　　//匹配由26个英文字母的小写组成的字符串 
            //^[A-Za-z0-9]+$　　//匹配由数字和26个英文字母组成的字符串 
            //^\w+$　　//匹配由数字、26个英文字母或者下划线组成的字符串 
            //^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$　　　　//匹配email地址 
            //^[a-zA-z]+://匹配(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$　　//匹配url 
        }
        public bool Checked(object obj)
        {
            if (obj.ToString() == "0")
            {
                return false;
            }
            else return true;
        }
        #endregion

        private void BindDataSet()
        {
            
        }
        private void BindData()
        {
            string proid = string.Format("select * from e_recipients where projectID='{0}'",LbproID.Text);
            DataSet dds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), proid);
            DataView ddv = new DataView(dds.Tables[0]);
            dgData.DataSource = dds;
            dgData.DataBind();
            string capid = string.Format("select * from e_moneytrack where projectID='{0}'",LbproID.Text);
            DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), capid);
            DataView dv = new DataView(ds.Tables[0]);
            dgData0.DataSource = ds;
            dgData0.DataBind();
        }
        protected void btchecky1_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string prodatatimeshen = dt.ToShortDateString().ToString();
            string strinsert = string.Format("update e_project set shenpi1='1',proschedule='执行',prodatatimeshen='{1}' where projectID='{0}'", LbproID.Text,prodatatimeshen);         
            int reslut = msq.getmysqlcom(strinsert);
            if (reslut > 0)
            {
               labError.Text= "会长审批通过";       
            }

            NLogTest nlog = new NLogTest();
            string sss = "会长审批项目：" + Lbproname.Text;
            nlog.WriteLog(Session["UserName"].ToString(), sss);

        }
        protected void btchecky2_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string prodatatimeshen = dt.ToShortDateString().ToString();
            string strinsert = string.Format("update e_project set shenpi2='1',proschedule='1',prodatatimeshen='{1}' where projectID='{0}'", LbproID.Text,prodatatimeshen);        
            int reslut = msq.getmysqlcom(strinsert);
            if (reslut > 0)
            {                
                 labError.Text= "科室审批通过";
            }

            NLogTest nlog = new NLogTest();
            string sss = "科室审批项目：" + Lbproname.Text;
            nlog.WriteLog(Session["UserName"].ToString(), sss);

        }
        protected void btcheckn_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string prodatatimeshen = dt.ToShortDateString().ToString();
            string strinsert = string.Format("update e_project set shenpi2='1',proschedule='未通过',prodatatimeshen='{1}' where projectID='{0}'", LbproID.Text, prodatatimeshen);
            int reslut = msq.getmysqlcom(strinsert);
            if (reslut > 0)
            {
                labError.Text = "审批未通过";
                NLogTest nlog = new NLogTest();
                string sss = "未通过审批项目：" + Lbproname.Text;
                nlog.WriteLog(Session["UserName"].ToString(), sss);
                Response.Redirect("信息发布.aspx?title=" + Server.UrlEncode(Lbproname.Text.Trim()) + "&branchName=" + Server.UrlEncode(Lbbenfrom.Text.Trim()));
            }


        }
        protected void btout_Click(object sender, EventArgs e)
        {
            btcheckn.Visible = false;
            btchecky1.Visible = false;
            btchecky2.Visible = false;
            btout.Visible = false;
            tableTitle = "经办单位信息";
            lyf_OutputToExcel.expExcle(this, divPrint, tableTitle);
        }
    
}
}
        
        
        
   

      
