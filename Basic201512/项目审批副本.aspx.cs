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
    /// 
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


        private const string PK = "projectID";
        public const string sID = "projectID";
        public const string sName = "projectName";//publicʱҳ�������ã�privateʱ������
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
            string strinsert = string.Format("update e_project set shenpi1='1',proschedule='ִ��',prodatatimeshen='{1}' where projectID='{0}'", LbproID.Text,prodatatimeshen);         
            int reslut = msq.getmysqlcom(strinsert);
            if (reslut > 0)
            {
               labError.Text= "�᳤����ͨ��";       
            }

            NLogTest nlog = new NLogTest();
            string sss = "�᳤������Ŀ��" + Lbproname.Text;
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
                 labError.Text= "��������ͨ��";
            }

            NLogTest nlog = new NLogTest();
            string sss = "����������Ŀ��" + Lbproname.Text;
            nlog.WriteLog(Session["UserName"].ToString(), sss);

        }
        protected void btcheckn_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string prodatatimeshen = dt.ToShortDateString().ToString();
            string strinsert = string.Format("update e_project set shenpi2='1',proschedule='δͨ��',prodatatimeshen='{1}' where projectID='{0}'", LbproID.Text, prodatatimeshen);
            int reslut = msq.getmysqlcom(strinsert);
            if (reslut > 0)
            {
                labError.Text = "����δͨ��";
                NLogTest nlog = new NLogTest();
                string sss = "δͨ��������Ŀ��" + Lbproname.Text;
                nlog.WriteLog(Session["UserName"].ToString(), sss);
                Response.Redirect("��Ϣ����.aspx?title=" + Server.UrlEncode(Lbproname.Text.Trim()) + "&branchName=" + Server.UrlEncode(Lbbenfrom.Text.Trim()));
            }


        }
        protected void btout_Click(object sender, EventArgs e)
        {
            btcheckn.Visible = false;
            btchecky1.Visible = false;
            btchecky2.Visible = false;
            btout.Visible = false;
            tableTitle = "���쵥λ��Ϣ";
            lyf_OutputToExcel.expExcle(this, divPrint, tableTitle);
        }
    
}
}
        
        
        
   

      
