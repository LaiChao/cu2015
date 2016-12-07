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
        #region "自定义属性"
        //internal static Manager manager = Managers.Members["NewUtilityOra"] as Manager;
        //internal static ISingleTable entityUsers = manager.Entities["USERS"] as ISingleTable;
        //private DataTable dtUsers;

        private string bindPCKey = "USER_ID";//绑定 能源节点数据的主键

        internal static WriteLog wl = new WriteLog();
        internal static UserInterface ui = new UserInterface();
        private const string PAGE_NAME = "资金录入";

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
        mysqlconn msql = new mysqlconn();
        
        string IDNow = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
            {
                Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
                return;
            }
            string urlNow = Request.Url.ToString();
            string[] temp = urlNow.Split('=');

            foreach (string s in temp)
            {
                IDNow = s;
            }
             if (!Page.IsPostBack)
             {
                 confirm.Visible = false;
                 btnCancel.Visible = false;
                 reload();//初始化

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

        private void reload()
        {
            string strread = string.Format("select benfactorID,benfactorName,TEL,handlingunitID,benfactorFrom from e_benfactor where benfactorID='{0}'", IDNow);//捐助人姓名？？？？？？？
            lbcaptID.Text = LbproID.Text = IDNow;
            MySqlDataReader mysqlread = msql.getmysqlread(strread);
            int tempstate=-1;
            lbtime.Text = DateTime.Now.ToString();
            while (mysqlread.Read())
            {
                ViewState["myKey"] = mysqlread.GetString(0);//捐赠人ID
                ViewState["myID"] = mysqlread.GetString(3);//经办单位ID
                //  DateTime dt=new DateTime();
                //DateTime dt = DateTime.Now;
                //                lbcaptID.Text = mysqlread.GetString(0) + '0' + mysqlread.GetString(3) + mysqlread.GetString(2);
                LbproID.Text = mysqlread.GetString(1);//捐赠人名称
                lbbenfnadd.Text = mysqlread.GetString(2);//电话
                //lbtime.Text = dt.Year.ToString() + '-' + dt.Month.ToString() + '-' + dt.Day.ToString();
                lblBranch.Text = mysqlread.GetString("benfactorFrom");//经办单位
            }
            string strreadcap = string.Format("select capitalEarn,state,capitalIn from e_capital where capitalID='{0}'", lbcaptID.Text);
            MySqlDataReader mysqlread1 = msql.getmysqlread(strreadcap);
            while (mysqlread1.Read())
            {
                lbcaptIDown.Text = mysqlread1.GetString(0);//已有资金
                tempstate = mysqlread1.GetInt32(1);//资金状态
                txtPLAN.Text = mysqlread1.GetDouble(2).ToString();//录入资金
            }
            
            if(tempstate==0)
            {
                txtPLAN.Enabled = false;
                btyes.Enabled = false;
                lblErr.Text = "请联系捐助科确认资金";
                //HttpContext.Current.Response.Write("<script>alert('请联系科室确认资金');</script>");
            }
            if(txtPLAN.Enabled==true)
                txtPLAN.Text = "";
            ////判断权限
            //string queryRole = "select userRole from e_user where user='" + Session["UserName"].ToString() + "'";
            //MySqlDataReader mysqlread32 = msql.getmysqlread(queryRole);
            //int roleOfUser=0;
            //while (mysqlread32.Read())
            //{
            //    roleOfUser = mysqlread32.GetInt32(0);
            //}
            //int result;
            if ((tempstate == 0) && (Session["benfactorFrom"].ToString() == "北京市朝阳区慈善协会捐助科"))
            {//捐助科可以确认或者撤回
                confirm.Visible = true;
                //btnCancel.Visible = true;
            }
            //if((tempstate==0)&&(Session["benfactorFrom"].ToString()==lblBranch.Text.Trim()))
            //{//申请单位可以撤回
            //    //btnCancel.Visible = true;
            //}
        }

        protected void btyes_Click(object sender, EventArgs e)//提交添加资金
        {
            ////判断状态
            //string queryState = "select state from e_capital where capitalID='" + lbcaptID.Text.ToString() + "'";
            //MySqlDataReader readState = msql.getmysqlread(queryState);
            //int state = -1;
            //while (readState.Read())
            //{
            //    if(readState.GetInt32(0)==0)
            //    {
            //        HttpContext.Current.Response.Write("<script>alert('请科室确认资金');</script>");
            //        return;
            //    }
                
            //}

            //判断是否为空
            //if ((txtPLAN.Text == "")||(txtPLAN.Text=="0"))
            //{
            //    lblErr.InnerText = "请输入金额";
            //   // HttpContext.Current.Response.Write("<script>alert('请输入金额');</script>");
            //    return;
            //}
            //else if(Convert.ToDouble(txtPLAN.Text)<=0)
            //{
            //    lblErr.InnerText = "请输入正数";
            //    return;
            //}

            if (txtPLAN.Text.Trim() == "")
            {
                lblErr.Text = "请输入金额！";
                txtPLAN.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPLAN.Focus();
               // HttpContext.Current.Response.Write("<script>alert('请输入金额');</script>");
                return;
            }
            else
            {
                try
                {
                    Convert.ToDouble(txtPLAN.Text.Trim());
                }
                catch
                {
                	lblErr.Text = "请输入正数";
                	txtPLAN.BackColor = Color.FromArgb((int)0xFFE1FF);
                	txtPLAN.Focus();
                    return;
                }
                if (Convert.ToDouble(txtPLAN.Text.Trim()) <= 0)
                {
                    lblErr.Text = "请输入正数";
                	txtPLAN.BackColor = Color.FromArgb((int)0xFFE1FF);
                	txtPLAN.Focus();
                    return;
                }
				txtPLAN.BackColor = Color.White;
            }

            ////判断权限
            //string queryRole = "select userRole from e_user where user='" + Session["UserName"].ToString() + "'";
            //MySqlDataReader mysqlread32 = msql.getmysqlread(queryRole);
            //int roleOfUser=0;
            //while (mysqlread32.Read())
            //{
            //    roleOfUser = mysqlread32.GetInt32(0);
            //}
            int result;
            //捐助科不用确认有误操作风险，2016-8-28注释
            //if(Session["benfactorFrom"].ToString() == "北京市朝阳区慈善协会捐助科")//捐助科
            //{
            //    string strins = string.Format("insert into e_capital (capitalID,benfactorID,capitalIn,capitalEarn,capitalIntime,handlingunitID,benfactorName,state,benfactorFrom) values('{0}','{1}','{2}',{3},'{4}','{5}','{6}',1,'{7}')", lbcaptID.Text, (string)ViewState["myKey"], 0, Convert.ToDouble(txtPLAN.Text) + Convert.ToDouble(lbcaptIDown.Text), lbtime.Text, (string)ViewState["myID"], LbproID.Text,lblBranch.Text);
            //    string strupd = string.Format("update e_capital set benfactorID='{1}',capitalIn='{2}',capitalEarn={3},capitalIntime='{4}',handlingunitID='{5}',benfactorName='{6}',state=1,benfactorFrom='{7}' where capitalID='{0}'", lbcaptID.Text, (string)ViewState["myKey"], 0, Convert.ToDouble(txtPLAN.Text) + Convert.ToDouble(lbcaptIDown.Text), lbtime.Text, (string)ViewState["myID"], LbproID.Text, lblBranch.Text);

            //    try{
            //        result = msq.getmysqlcom(strins);
            //    }               
            //    catch{
            //        result = msq.getmysqlcom(strupd);
            //    }
            
            //    if (result>0)
            //    {
            //        lblErr.InnerText = "添加资金成功";
            //        NLogTest nlog = new NLogTest();
            //        string sss = "捐助科为" + lblBranch.Text+"的"+LbproID.Text+ "录入了捐赠金额"+txtPLAN.Text+"元。资金ID：" + lbcaptID.Text;
            //        nlog.WriteLog(Session["UserName"].ToString(), sss);
            //       // HttpContext.Current.Response.Write("<script>alert('添加资金成功');</script>");
            //    }
            //    reload();//刷新页面
            //}
            //else
            //{//非捐助科权限
                string strins2 = string.Format("insert into e_capital (capitalID,benfactorID,capitalIn,capitalEarn,capitalIntime,handlingunitID,benfactorName,state,benfactorFrom) values('{0}','{1}','{2}',{3},'{4}','{5}','{6}',0,'{7}')", lbcaptID.Text, (string)ViewState["myKey"], double.Parse(txtPLAN.Text.Trim()), Convert.ToDouble(lbcaptIDown.Text), lbtime.Text, (string)ViewState["myID"], LbproID.Text, lblBranch.Text);
                string strupd2 = string.Format("update e_capital set benfactorID='{1}',capitalIn='{2}',capitalEarn={3},capitalIntime='{4}',handlingunitID='{5}',benfactorName='{6}',state=0,benfactorFrom='{7}' where capitalID='{0}'", lbcaptID.Text, (string)ViewState["myKey"], double.Parse(txtPLAN.Text.Trim()), Convert.ToDouble(lbcaptIDown.Text), lbtime.Text, (string)ViewState["myID"], LbproID.Text, lblBranch.Text);
                string insertString = string.Format("insert into e_capital_detail (detailID,benefactorName,branchName,operator,opType,income,remain,opTime,opBranchName) values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}')", lbcaptID.Text, LbproID.Text, lblBranch.Text, Session["UserName"].ToString(), "申请录入", double.Parse(txtPLAN.Text), Convert.ToDouble(lbcaptIDown.Text), DateTime.Now.ToString(), Session["benfactorFrom"].ToString());
                try
                {
                    result = msq.getmysqlcom(strins2);
                }
                catch
                {
                    result = msq.getmysqlcom(strupd2);
                }

                if (result > 0)
                {
                    msq.getmysqlcom(insertString);
                    lblErr.Text = "提交成功，请等待捐助科审批确认";
                    NLogTest nlog = new NLogTest();
                    string sss = "为"+lblBranch.Text + "的" + LbproID.Text + "录入了捐赠金额" + txtPLAN.Text + "元。资金ID：" + lbcaptID.Text;
                    nlog.WriteLog(Session["UserName"].ToString(), sss);

                   // HttpContext.Current.Response.Write("<script>alert('提交成功，请等待科室审批确认');</script>");
                }
                reload();//刷新页面
            //}

        }
        protected void confirm_Click(object sender, EventArgs e)//确认添加
        {
            //string updateString = string.Format("update e_capital set capitalEarn={1},capitalIntime='{2}',state=1 where capitalID='{0}'", lbcaptID.Text, Convert.ToInt32(lbcaptIDown.Text) + Convert.ToInt32(txtPLAN.Text), lbtime.Text);
            string updateString = string.Format("update e_capital set capitalEarn={1},capitalIn=0,state=1 where capitalID='{0}'", lbcaptID.Text, Convert.ToDouble(lbcaptIDown.Text) + Convert.ToDouble(txtPLAN.Text));
            string insertString = string.Format("insert into e_capital_detail (detailID,benefactorName,branchName,operator,opType,income,remain,opTime,opBranchName) values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}')", lbcaptID.Text, LbproID.Text, lblBranch.Text, Session["UserName"].ToString(), "确认录入", double.Parse(txtPLAN.Text), Convert.ToDouble(lbcaptIDown.Text), DateTime.Now.ToString(), Session["benfactorFrom"].ToString());
            int result = msq.getmysqlcom(updateString);
            if(result>0)
            {
                msq.getmysqlcom(insertString);
                // HttpContext.Current.Response.Write("<script>alert('金额确认成功');</script>");
                lblErr.Text = "金额确认成功";
                NLogTest nlog = new NLogTest();
                string sss = "捐助科确认：为" + lblBranch.Text + "的" + LbproID.Text + "录入了捐赠金额" + txtPLAN.Text + "元。资金ID：" + lbcaptID.Text;
                nlog.WriteLog(Session["UserName"].ToString(), sss);
                txtPLAN.Enabled = true;
                btyes.Enabled = true;
                confirm.Visible = false;
                btnCancel.Visible = false;
            }
            reload();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //撤回语句
            string updateString = string.Format("update e_capital set capitalIn=0,state=1 where capitalID='{0}'", lbcaptID.Text);
            string insertString = string.Format("insert into e_capital_detail (detailID,benefactorName,branchName,operator,opType,income,remain,opTime,opBranchName) values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}')", lbcaptID.Text, LbproID.Text, lblBranch.Text, Session["UserName"].ToString(), "撤回申请", double.Parse(txtPLAN.Text), Convert.ToDouble(lbcaptIDown.Text), DateTime.Now.ToString(), Session["benfactorFrom"].ToString());            
            int result = msq.getmysqlcom(updateString);
            if(result>0)
            {
                msq.getmysqlcom(insertString);
                lblErr.Text = "金额撤回成功";
                NLogTest nlog = new NLogTest();
                string sss = "撤回了" + lblBranch.Text + "的" + LbproID.Text + "申请捐赠金额" + txtPLAN.Text + "元。资金ID：" + lbcaptID.Text;
                nlog.WriteLog(Session["UserName"].ToString(), sss);
                txtPLAN.Enabled = true;
                btyes.Enabled = true;
                confirm.Visible = false;
                btnCancel.Visible = false;

            }
            reload();
        }
    }
}
