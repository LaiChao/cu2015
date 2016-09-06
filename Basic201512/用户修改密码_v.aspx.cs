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

//ʹ�����ݷ��ʲ���ӵıر�����
using DataEntity.EntityManager;
using DataEntity.Entity;
using System.Text.RegularExpressions;
using CL.Utility.Web.Common;
using System.Configuration;
using System.Web.Security;
using luyunfei;

//ʹ��MySQL���ݿ�
using MySql.Data;
using MySql.Data.MySqlClient;


namespace CL.Utility.Web.BasicData
{
    /// <summary>
    /// Meter ��ժҪ˵����
    /// </summary>
    public partial class Register : System.Web.UI.Page
    {
        #region "�Զ�������"
        //internal static Manager manager = Managers.Members["NewUtilityOra"] as Manager;
        //internal static ISingleTable entityUsers = manager.Entities["USERS"] as ISingleTable;//��Դ�ڵ�
        //private DataTable tableUsers;

        private string bindPCKey = "USER_ID";//�� ��Դ�ڵ����ݵ�����

        internal static WriteLog wl = new WriteLog();
        internal static UserInterface ui = new UserInterface();
        private const string PAGE_NAME = "�û�";

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

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion



        #region "ת������"
        //��ֹҳ�����"
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

        //������ʽƥ��
        private bool IsValidNum(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^[0-9]*[1-9][0-9]*$");

            //		^\d+$����//ƥ��Ǹ������������� + 0�� 
            //^[0-9]*[1-9][0-9]*$����//ƥ�������� 
            //^((-\d+)|(0+))$����//ƥ����������������� + 0�� 
            //^-[0-9]*[1-9][0-9]*$����//ƥ�为���� 
            //^-?\d+$��������//ƥ������ 
            //^\d+(\.\d+)?$����//ƥ��Ǹ����������������� + 0�� 
            //^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$����//ƥ���������� 
            //^((-\d+(\.\d+)?)|(0+(\.0+)?))$����//ƥ��������������������� + 0�� 
            //^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$����//ƥ�为������ 
            //^(-?\d+)(\.\d+)?$����//ƥ�両���� 
            //^[A-Za-z]+$����//ƥ����26��Ӣ����ĸ��ɵ��ַ��� 
            //^[A-Z]+$����//ƥ����26��Ӣ����ĸ�Ĵ�д��ɵ��ַ��� 
            //^[a-z]+$����//ƥ����26��Ӣ����ĸ��Сд��ɵ��ַ��� 
            //^[A-Za-z0-9]+$����//ƥ�������ֺ�26��Ӣ����ĸ��ɵ��ַ��� 
            //^\w+$����//ƥ�������֡�26��Ӣ����ĸ�����»�����ɵ��ַ��� 
            //^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$��������//ƥ��email��ַ 
            //^[a-zA-z]+://ƥ��(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$����//ƥ��url 
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
            //��ȡ�û���������1
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
            string inputId = "";//�û���
            inputId = IdPwdNameRole[0];
            string inputPwd = "";//����
            inputPwd = IdPwdNameRole[1];
            //string cookieName = FormsAuthentication.FormsCookieName;
            //HttpCookie authCookie = Context.Request.Cookies[cookieName];
            //FormsAuthenticationTicket authTicket = null;
            //authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            // userId = authTicket.UserData.ToString();

            //��ȡ�û���������2
                       
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
                labError.Text = "�������û�����";
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
                labError.Text = "������������";
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
                labError.Text = "�����" + PAGE_NAME + "��������" + errMsg;
                return;
            }
           
            string strTEL = TEL.Text.Trim();
            if (strTEL=="")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "��������ϵ��ʽ��";
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
                labError.Text = "����������룡";
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
            //    labError.Text = "����ľ���������" + errMsg;
            //    txtPWDOld.Focus();
            //    return;
            //}
            string strPwd = txtPWD.Text.Trim();
            if (strPwd == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "�����������룡";
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
                labError.Text = "��������5~20λ�����֡�Ӣ����ĸ���»�����ɣ�";
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
                labError.Text = "��Ҫȷ�������룡";
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
                labError.Text = "�ٴ����������������" + errMsg;
                return;
            }
            if (strPwd != strPwd2)
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "��������������벻һ�£�";
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
                labError.Text = "�û������ڣ�";
                return;
            }
            string s = dv[0]["password"].ToString();

            if (strPwdOld !=s )
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "����ľ����벻��ȷ��";
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
                    labError.Text = "�����޸ĳɹ�! ���μǣ�";
                 //   wl.WriteLogData(PAGE_NAME, "�޸�", strName, System.Diagnostics.EventLogEntryType.Information);
                    NLogTest nlog = new NLogTest();
                    string sss = "�޸����û�"+Session["UserName"].ToString()+"����Ϣ" ;
                    nlog.WriteLog(Session["UserName"].ToString(), sss);
                }
                else
                {
                    labError.ForeColor = System.Drawing.Color.Red;
                    labError.Text = "δ�ҵ���Ӧ��¼,�޸�����ʧ��";
                   // wl.WriteLogData(PAGE_NAME, "�޸�", strName + "δ�ҵ���Ӧ��¼,�޸ļ�¼ʧ��", System.Diagnostics.EventLogEntryType.Warning);
                }

            }
            catch (Exception ex)
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "�޸�����ʧ��" + ui.ExceptionMsg(ex);
               // wl.WriteLogData(PAGE_NAME, "�޸�", strName + ":" + ex.Message + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }
            loadBaseInf();
        }
    }
}
