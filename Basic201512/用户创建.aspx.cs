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

        #endregion

        mysqlconn msq = new mysqlconn();
        string str111 = "select benfactorFrom from e_handlingunit";

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)//页面首次加载
            {
                databind();
            }
        }

        public void databind()
        {
            MySqlConnection mysqlcon = msq.getmysqlcon();
            DataSet ds = MySqlHelper.ExecuteDataset(mysqlcon, str111);
            DataView dv = new DataView(ds.Tables[0]);
            benfactorFrom.DataSource = dv;
            benfactorFrom.DataTextField = "benfactorFrom";
            benfactorFrom.DataBind();
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


        protected void btyes_Click(object sender, EventArgs e)
        {

            labError.Text = "";
            string strID = txtID.Text.Trim();
            if (strID == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "请输入用户名";
                return;
            }
            string errMsg = "";
            if (!luyunfei.lyf_validate.isAZaz09_(strID, 5, 8, out errMsg))
            {
                labError.Text = "输入的用户名称有误！" + errMsg;
                return;
            }
            bool isMatch = lyf_validate.isIDorPwd(strID);
            if (!isMatch)
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "输入的用户名格式不正确！用户ID只能包含字母、数字、下划线，且不能以数字开头，5~16位。";
                return;
            }
            string strName = txtName.Text.Trim();
            if (strName == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "请输入姓名";
                return;
            }

            string strUserRole = ddlRole.SelectedValue.ToString();
            if (ddlRole.SelectedValue == "请选择")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "请选择权限";
                return;
            }

            string strTEL = TEL.Text.Trim();
            if(strTEL == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "请输入联系方式";
                return;
            }
            string strPwd = txtPWD.Text.Trim();
            if (strPwd == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "请输入密码";
                return;
            }
            if (!luyunfei.lyf_validate.isAZaz09_(strPwd, 5, 20, out errMsg))
            {
                labError.Text = "输入的新密码有误！" + errMsg;
                return;
            }
            string strPwd2 = txtPWD2.Text.Trim();
            if (strPwd2 == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "请再次输入密码";
                return;
            }
            if (strPwd != strPwd2)
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "两次输入的密码不一致！";
                return;            
            }
            string strFrom = benfactorFrom.Text.Trim();
            HybridDictionary hd = new HybridDictionary();
            hd.Add(sPMS_CTG_ID, strID);
        //      dtUsers = entityUsers.ExecuteDataTable2(CommandType.Text, "SelectById", hd);
            string sqldate = string.Format("select * from e_user where user='{0}'", strID);
         
            mysqlconn mys= new mysqlconn();
            MySqlDataAdapter sda = new MySqlDataAdapter(sqldate,mys.getmysqlcon());
            DataSet ds = MySqlHelper.ExecuteDataset(mys.getmysqlcon(),sqldate);            
            DataView dv = new DataView(ds.Tables[0]);            
            if (dv.Count > 0)
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "该用户已存在！";
                return;
            }
            try
            {
                //DataTable schemaMeter = entityUsers.GetSchema();
                //DataRow dr = schemaMeter.NewRow();
                //dr[sPMS_CTG_ID] = strID;
                //dr[sPMS_CTG_NAME] = strName;
                //dr[sUSE_IDT] = 0;//用户标记为未启用
                //dr[sPwd] = strPwd;
                //dr[sDES] = "";
                //dr[sCRT_DATE] = DateTime.Now;
                string sqldate1 = string.Format("insert into e_user(user,password,benfactorFrom,name,TEL,userRole) values('{0}','{1}','{2}','{3}','{4}',{5})", strID, strPwd, strFrom, strName, strTEL,strUserRole);
           //     bool result = Convert.ToBoolean(entityUsers.Insert(dr));

                int result1 = mys.getmysqlcom(sqldate1);
                
                if (result1>0)
                {
                    labError.ForeColor = System.Drawing.Color.Red;
                    labError.Text = "注册成功！";
                  //  wl.WriteLogData(PAGE_NAME, "创建", strName, System.Diagnostics.EventLogEntryType.Information);
                    NLogTest nlog = new NLogTest();
                    string sss = "注册了新用户：" + strID + "(" + strName + ")";
                    nlog.WriteLog(Session["UserName"].ToString(), sss);
                }
                else
                {
                    labError.ForeColor = System.Drawing.Color.Red;
                    labError.Text = "注册失败！";
                  //  wl.WriteLogData(PAGE_NAME, "创建", strName, System.Diagnostics.EventLogEntryType.Warning);
                }
            }
            catch (Exception ex)
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "添加记录失败" + ui.ExceptionMsg(ex);
             //   wl.WriteLogData(PAGE_NAME, "创建", strName + ":" + ex.Message + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

        }
    }
}
