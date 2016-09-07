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
using luyunfei;
//mysql���ݿ�����
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
        //internal static ISingleTable entityUsers = manager.Entities["USERS"] as ISingleTable;
        //private DataTable dtUsers;

        private string bindPCKey = "USER_ID";//�� ��Դ�ڵ����ݵ�����

        internal static WriteLog wl = new WriteLog();
        internal static UserInterface ui = new UserInterface();
        private const string PAGE_NAME = "�û�";

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
            if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
            {
                Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
                return;
            }
            if (!Page.IsPostBack)//ҳ���״μ���
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


        protected void btyes_Click(object sender, EventArgs e)
        {

            labError.Text = "";
            string strID = txtID.Text.Trim();
            if (strID == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "�������û���";
                txtID.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtID.Focus();
                return;
            }
            else
            {
                txtID.BackColor = Color.White;
            }

            string errMsg = "";
            if (!luyunfei.lyf_validate.isAZaz09_(strID, 5, 8, out errMsg))
            {
                labError.Text = "�û�����5~8λ�����֡�Ӣ����ĸ���»�����ɣ�";
                txtID.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtID.Focus();
                return;
            }
            else
            {
                txtID.BackColor = Color.White;
            }

            //bool isMatch = lyf_validate.isIDorPwd(strID);
            //if (!isMatch)
            //{
            //    labError.ForeColor = System.Drawing.Color.Red;
            //    labError.Text = "������û�����ʽ����ȷ���û�IDֻ�ܰ�����ĸ�����֡��»��ߣ��Ҳ��������ֿ�ͷ��5~16λ��";
            //    benfactorFrom.BackColor = Color.FromArgb((int)0xFFE1FF);
            //    benfactorFrom.Focus();
            //    return;
            //}

            string strName = txtName.Text.Trim();
            if (strName == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "����������";
                txtName.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtName.Focus();
                return;
            }
            else
            {
                txtName.BackColor = Color.White;
            }

            string strUserRole = ddlRole.SelectedValue.ToString();
            if (ddlRole.SelectedValue == "��ѡ��")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "��ѡ��Ȩ��";
                return;
            }

            string strTEL = TEL.Text.Trim();
            if(strTEL == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "��������ϵ��ʽ";
                TEL.BackColor = Color.FromArgb((int)0xFFE1FF);
                TEL.Focus();
                return;
            }
            else
            {
                TEL.BackColor = Color.White;
            }

            string strPwd = txtPWD.Text.Trim();
            if (strPwd == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "����������";
                txtPWD.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD2.BackColor = Color.White;
                txtPWD.Focus();
                return;
            }
            else
            {
                txtPWD.BackColor = Color.White;
            }

            if (!luyunfei.lyf_validate.isAZaz09_(strPwd, 5, 20, out errMsg))
            {
                labError.Text = "������5~20λ�����֡�Ӣ����ĸ���»�����ɣ�";
                txtPWD.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD.Focus();
                return;
            }
            else
            {
                txtPWD.BackColor = Color.White;
            }

            string strPwd2 = txtPWD2.Text.Trim();
            if (strPwd2 == "")
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "���ٴ���������";
                txtPWD.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD2.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD.Focus();
                return;
            }
            else
            {
                txtPWD.BackColor = Color.White;
                txtPWD2.BackColor = Color.White;
            }

            if (strPwd != strPwd2)
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "������������벻һ�£�";
                txtPWD.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD2.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPWD.Focus();
                return;            
            }
            else
            {
                txtPWD.BackColor = Color.White;
                txtPWD2.BackColor = Color.White;
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
                labError.Text = "���û��Ѵ��ڣ�";
                return;
            }
            try
            {
                //DataTable schemaMeter = entityUsers.GetSchema();
                //DataRow dr = schemaMeter.NewRow();
                //dr[sPMS_CTG_ID] = strID;
                //dr[sPMS_CTG_NAME] = strName;
                //dr[sUSE_IDT] = 0;//�û����Ϊδ����
                //dr[sPwd] = strPwd;
                //dr[sDES] = "";
                //dr[sCRT_DATE] = DateTime.Now;
                string sqldate1 = string.Format("insert into e_user(user,password,benfactorFrom,name,TEL,userRole) values('{0}','{1}','{2}','{3}','{4}',{5})", strID, strPwd, strFrom, strName, strTEL,strUserRole);
           //     bool result = Convert.ToBoolean(entityUsers.Insert(dr));

                int result1 = mys.getmysqlcom(sqldate1);
                
                if (result1>0)
                {
                    labError.ForeColor = System.Drawing.Color.Red;
                    labError.Text = "ע��ɹ���";
                  //  wl.WriteLogData(PAGE_NAME, "����", strName, System.Diagnostics.EventLogEntryType.Information);
                    NLogTest nlog = new NLogTest();
                    string sss = "����Ա���������û���" + strID + "(" + strName + ")";
                    nlog.WriteLog(Session["UserName"].ToString(), sss);
                }
                else
                {
                    labError.ForeColor = System.Drawing.Color.Red;
                    labError.Text = "ע��ʧ�ܣ�";
                  //  wl.WriteLogData(PAGE_NAME, "����", strName, System.Diagnostics.EventLogEntryType.Warning);
                }
            }
            catch (Exception ex)
            {
                labError.ForeColor = System.Drawing.Color.Red;
                labError.Text = "��Ӽ�¼ʧ��" + ui.ExceptionMsg(ex);
             //   wl.WriteLogData(PAGE_NAME, "����", strName + ":" + ex.Message + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

        }
    }
}
