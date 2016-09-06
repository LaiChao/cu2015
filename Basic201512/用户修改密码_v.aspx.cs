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
using System.Web.Security;
using luyunfei;

//使用MySQL数据库
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
        //internal static ISingleTable entityUsers = manager.Entities["USERS"] as ISingleTable;//能源节点
        //private DataTable tableUsers;

        private string bindPCKey = "USER_ID";//绑定 能源节点数据的主键

        internal static WriteLog wl = new WriteLog();
        internal static UserInterface ui = new UserInterface();
        private const string PAGE_NAME = "用户";

        public const string sPMS_CTG_ID = "USER_ID";
        public const string sPMS_CTG_NAME = "name";
        public const string sPwd = "password";
        public const string sUSE_IDT = "USE_IDT";
        public const string sCRT_DATE = "CRT_DATE";
        public const string sUPD_DATE = "UPD_DATE";
        public const string sDES = "DES";

        #endregion

        //mysqlconn msq = new mysqlconn();
        //string str111 = "select benfactorFrom from e_handlingunit";

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
            {
                Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
                return;
            }
            if (!IsPostBack)
            {
                loadBaseInf();
                //databind();
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

        private void loadBaseInf()
        {
            string userId = "";
            //获取用户名：方法1
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
            string inputId = "";//用户名
            inputId = IdPwdNameRole[0];
            string inputPwd = "";//密码
            inputPwd = IdPwdNameRole[1];
            //string cookieName = FormsAuthentication.FormsCookieName;
            //HttpCookie authCookie = Context.Request.Cookies[cookieName];
            //FormsAuthenticationTicket authTicket = null;
            //authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            // userId = authTicket.UserData.ToString();

            //获取用户名：方法2
                       
            //if (string.IsNullOrEmpty(Context.Request["userid"]))
            //{
            //    return ;
            //}
            //userId = Context.Request["userid"].ToString().Trim();

            userId = inputId;
            txtID.Text = userId;

            //HybridDictionary hd = new HybridDictionary();
            //hd.Add(sPMS_CTG_ID, userId);
            //tableUsers = entityUsers.ExecuteDataTable2(CommandType.Text, "SelectById", hd);
            //DataView dv = new DataView(tableUsers);
            //txtName.Text = dv[0][sPMS_CTG_NAME].ToString();

            mysqlconn msq = new mysqlconn();
            string str = string.Format("select * from e_user where user='{0}'",inputId);
            DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),str);
            DataView dv = new DataView(ds.Tables[0]);
            txtName.Text = dv[0][sPMS_CTG_NAME].ToString();
            TEL.Text = dv[0]["TEL"].ToString();

            txtPWD.Text = "";
            txtPWD2.Text = "";
            txtPWDOld.Text = "";
        }

        //public void databind()
        //{
        //    MySqlConnection mysqlcon = msq.getmysqlcon();
        //    DataSet ds = MySqlHelper.ExecuteDataset(mysqlcon, str111);
        //    DataView dv = new DataView(ds.Tables[0]);
        //    benfactorFrom.DataSource = dv;
        //    benfactorFrom.DataTextField = "benfactorFrom";
        //    benfactorFrom.DataBind();
        //}


        protected void submit_Click(object sender, EventArgs e)
        {

            labError.Text = "";
            string strID = txtID.Text.Trim();
            if (strID == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "请输入用户名！";
                txtID.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtID.Focus();
                return;
            }
            else
            {
                txtID.BackColor = Color.White;
            }
            string strName = txtName.Text.Trim();
            if (strName == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "请输入姓名！";
                txtName.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtName.Focus();
                return;
            }
            else
            {
                txtName.BackColor = Color.White;
            }
            //string strFrom = benfactorFrom.Text.Trim();
            string errMsg = "";
            if (!luyunfei.lyf_validate.isAZaz09_Ch(strName, 1, 20, out errMsg))
            {
                labError.Text = "输入的" + PAGE_NAME + "名称有误！" + errMsg;
                return;
            }
           
            string strTEL = TEL.Text.Trim();
            if (strTEL=="")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "请输入联系方式！";
                TEL.BackColor = Color.FromArgb((int)0xFFE1FF);
                TEL.Focus();
                return;
            }
            else
            {
                TEL.BackColor = Color.White;
            }

            string strPwdOld = txtPWDOld.Text.Trim();
            if (strPwdOld == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "请输入旧密码！";
                txtPWDOld.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD.BackColor = Color.White;
                txtPWD2.BackColor = Color.White;
                txtPWDOld.Focus();
                return;
            }
            else
            {
                txtPWDOld.BackColor = Color.White;
            }
            //if (!luyunfei.lyf_validate.isAZaz09_(strPwdOld, 5, 20, out errMsg))
            //{
            //    labError.Text = "输入的旧密码有误！" + errMsg;
            //    txtPWDOld.Focus();
            //    return;
            //}
            string strPwd = txtPWD.Text.Trim();
            if (strPwd == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "请输入新密码！";
                txtPWDOld.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD2.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWDOld.Focus();
                return;
            }
            else
            {
                txtPWDOld.BackColor = Color.White;
                txtPWD.BackColor = Color.White;
                txtPWD2.BackColor = Color.White;
            }

            //string errMsg = "";
            if (!luyunfei.lyf_validate.isAZaz09_(strPwd, 5, 20, out errMsg))
            {
                labError.Text = "新密码由5~20位的数字、英文字母或下划线组成！";
                txtPWDOld.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD2.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWDOld.Focus();
                return;
            }
            else
            {
                txtPWDOld.BackColor = Color.White; 
                txtPWD.BackColor = Color.White;
                txtPWD2.BackColor = Color.White;
            }

            string strPwd2 = txtPWD2.Text.Trim();
            if (strPwd2 == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "需要确认新密码！";
                txtPWDOld.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD2.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWDOld.Focus();
                return;
            }
            else
            {
                txtPWDOld.BackColor = Color.White;
                txtPWD.BackColor = Color.White;
                txtPWD2.BackColor = Color.White;
            }
            if (!luyunfei.lyf_validate.isAZaz09_(strPwd2, 5, 20, out errMsg))
            {
                labError.Text = "再次输入的新密码有误！" + errMsg;
                return;
            }
            if (strPwd != strPwd2)
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "两次输入的新密码不一致！";
                txtPWDOld.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD2.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWDOld.Focus();
                return;
            }
            else
            {
                txtPWDOld.BackColor = Color.White;
                txtPWD.BackColor = Color.White;
                txtPWD2.BackColor = Color.White;
            }
            //HybridDictionary hd = new HybridDictionary();
            //hd.Add(sPMS_CTG_ID, strID);
            //tableUsers = entityUsers.ExecuteDataTable2(CommandType.Text, "SelectById", hd);
            //DataView dv = new DataView(tableUsers);

            mysqlconn msq = new mysqlconn();
            string str = string.Format("select * from e_user where user='{0}'", strID);
            DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), str);
            DataView dv = new DataView(ds.Tables[0]);
            txtName.Text = dv[0][sPMS_CTG_NAME].ToString();

            if (dv.Count == 0)
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "用户不存在！";
                return;
            }
            string s = dv[0]["password"].ToString();

            if (strPwdOld !=s )
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "输入的旧密码不正确！";
                txtPWDOld.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD.BackColor = Color.White;
                txtPWD2.BackColor = Color.White;
                txtPWDOld.Focus();
                return;
            }
            else
            {
                txtPWDOld.BackColor = Color.White;
            }
                        
            
            
            try
            {
                HybridDictionary myHd = new HybridDictionary();
                myHd.Add(sPMS_CTG_ID, strID);
                myHd.Add(sPMS_CTG_NAME, strName);     

                myHd.Add(sPwd, strPwd);
                myHd.Add(sUPD_DATE, DateTime.Now);
                string str1 = string.Format("update e_user set name='{0}',password='{1}',TEL='{2}' where user='{3}'", strName, strPwd, strTEL, strID);
                int result = msq.getmysqlcom(str1);
                //bool result = Convert.ToBoolean(entityUsers.Update(myHd));
                if (result>0)
                {
                    labError.ForeColor = System.Drawing.Color.Blue;
                    labError.Text = "资料修改成功! 请牢记！";
                 //   wl.WriteLogData(PAGE_NAME, "修改", strName, System.Diagnostics.EventLogEntryType.Information);
                    NLogTest nlog = new NLogTest();
                    string sss = "修改了用户"+Session["UserName"].ToString()+"的信息" ;
                    nlog.WriteLog(Session["UserName"].ToString(), sss);
                }
                else
                {
                    labError.ForeColor = System.Drawing.Color.Red;
                    labError.Text = "未找到对应记录,修改资料失败";
                   // wl.WriteLogData(PAGE_NAME, "修改", strName + "未找到对应记录,修改记录失败", System.Diagnostics.EventLogEntryType.Warning);
                }

            }
            catch (Exception ex)
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "修改资料失败" + ui.ExceptionMsg(ex);
               // wl.WriteLogData(PAGE_NAME, "修改", strName + ":" + ex.Message + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }
            loadBaseInf();
        }
    }
}
