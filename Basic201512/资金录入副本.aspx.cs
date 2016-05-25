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
        private const string PAGE_NAME = "�ʽ�¼��";

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
        mysqlconn msql = new mysqlconn();
        
        string IDNow = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {

            string urlNow = Request.Url.ToString();
            string[] temp = urlNow.Split('=');

            foreach (string s in temp)
            {
                IDNow = s;
            }
             if (!Page.IsPostBack)
             {
                 confirm.Visible = false;
                 reload();//��ʼ��

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

        private void reload()
        {
            string strread = string.Format("select benfactorID,benfactorName,TEL,handlingunitID from e_benfactor where benfactorID='{0}'", IDNow);//������������������������
            lbcaptID.Text = LbproID.Text = IDNow;
            MySqlDataReader mysqlread = msql.getmysqlread(strread);
            int tempstate=-1;

            while (mysqlread.Read())
            {
                ViewState["myKey"] = mysqlread.GetString(0);
                ViewState["myID"] = mysqlread.GetString(3);
                //  DateTime dt=new DateTime();
                DateTime dt = DateTime.Now;
                //                lbcaptID.Text = mysqlread.GetString(0) + '0' + mysqlread.GetString(3) + mysqlread.GetString(2);
                LbproID.Text = mysqlread.GetString(1);
                lbbenfnadd.Text = mysqlread.GetString(2);
                lbtime.Text = dt.Year.ToString() + '-' + dt.Month.ToString() + '-' + dt.Day.ToString();
            }
            string strreadcap = string.Format("select capitalEarn,state,capitalIn from e_capital where capitalID='{0}'", lbcaptID.Text);
            MySqlDataReader mysqlread1 = msql.getmysqlread(strreadcap);
            while (mysqlread1.Read())
            {
                lbcaptIDown.Text = mysqlread1.GetString(0);
                tempstate = mysqlread1.GetInt32(1);
                txtPLAN.Text = mysqlread1.GetInt32(2).ToString();
            }
            
            if(tempstate==0)
            {
                txtPLAN.Enabled = false;
                btyes.Enabled = false;
                lblErr.InnerText = "����ϵ����ȷ���ʽ�";
                //HttpContext.Current.Response.Write("<script>alert('����ϵ����ȷ���ʽ�');</script>");
            }
            if(txtPLAN.Enabled==true)
                txtPLAN.Text = "";
            //�ж�Ȩ��
            string queryRole = "select userRole from e_user where user='" + Session["UserName"].ToString() + "'";
            MySqlDataReader mysqlread32 = msql.getmysqlread(queryRole);
            int roleOfUser=0;
            while (mysqlread32.Read())
            {
                roleOfUser = mysqlread32.GetInt32(0);
            }
            int result;
            if(roleOfUser>1 && tempstate==0)//�Ƿֻ�Ȩ��
                confirm.Visible = true;
        }

        protected void btyes_Click(object sender, EventArgs e)//�ύ����ʽ�
        {
            ////�ж�״̬
            //string queryState = "select state from e_capital where capitalID='" + lbcaptID.Text.ToString() + "'";
            //MySqlDataReader readState = msql.getmysqlread(queryState);
            //int state = -1;
            //while (readState.Read())
            //{
            //    if(readState.GetInt32(0)==0)
            //    {
            //        HttpContext.Current.Response.Write("<script>alert('�����ȷ���ʽ�');</script>");
            //        return;
            //    }
                
            //}
            //�ж��Ƿ�Ϊ��
            if (txtPLAN.Text == "")
            {
                lblErr.InnerText = "��������";
               // HttpContext.Current.Response.Write("<script>alert('��������');</script>");
                return;
            }

            //�ж�Ȩ��
            string queryRole = "select userRole from e_user where user='" + Session["UserName"].ToString() + "'";
            MySqlDataReader mysqlread32 = msql.getmysqlread(queryRole);
            int roleOfUser=0;
            while (mysqlread32.Read())
            {
                roleOfUser = mysqlread32.GetInt32(0);
            }
            int result;
            if(roleOfUser>1)//�Ƿֻ�Ȩ��
            {
                string strins = string.Format("insert into e_capital (capitalID,benfactorID,capitalIn,capitalEarn,capitalIntime,handlingunitID,benfactorName,state) values('{0}','{1}','{2}',{3},'{4}','{5}','{6}',1)", lbcaptID.Text, (string)ViewState["myKey"], 0, Convert.ToDouble(txtPLAN.Text) + Convert.ToDouble(lbcaptIDown.Text), lbtime.Text, (string)ViewState["myID"], LbproID.Text);
                string strupd = string.Format("update e_capital set benfactorID='{1}',capitalIn='{2}',capitalEarn={3},capitalIntime='{4}',handlingunitID='{5}',benfactorName='{6}',state=1 where capitalID='{0}'", lbcaptID.Text, (string)ViewState["myKey"], 0, Convert.ToDouble(txtPLAN.Text) + Convert.ToDouble(lbcaptIDown.Text), lbtime.Text, (string)ViewState["myID"], LbproID.Text);

                try{
                    result = msq.getmysqlcom(strins);
                }               
                catch{
                    result = msq.getmysqlcom(strupd);
                }
            
                if (result>0)
                {
                    lblErr.InnerText = "����ʽ�ɹ�";
                   // HttpContext.Current.Response.Write("<script>alert('����ʽ�ɹ�');</script>");
                }
                reload();//ˢ��ҳ��
                
                //NLogTest nlog = new NLogTest();
                //string sss = "¼���ʽ�" + lbcaptID.Text;
                //nlog.WriteLog(Session["UserName"].ToString(), sss);
            }
            else if(roleOfUser==1)//�ֻ�Ȩ��
            {
                string strins2 = string.Format("insert into e_capital (capitalID,benfactorID,capitalIn,capitalEarn,capitalIntime,handlingunitID,benfactorName,state) values('{0}','{1}','{2}',{3},'{4}','{5}','{6}',0)", lbcaptID.Text, (string)ViewState["myKey"], double.Parse(txtPLAN.Text), Convert.ToInt32(lbcaptIDown.Text), lbtime.Text, (string)ViewState["myID"], LbproID.Text);
                string strupd2 = string.Format("update e_capital set benfactorID='{1}',capitalIn='{2}',capitalEarn={3},capitalIntime='{4}',handlingunitID='{5}',benfactorName='{6}',state=0 where capitalID='{0}'", lbcaptID.Text, (string)ViewState["myKey"], double.Parse(txtPLAN.Text), Convert.ToInt32(lbcaptIDown.Text), lbtime.Text, (string)ViewState["myID"], LbproID.Text);

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
                    lblErr.InnerText = "�ύ�ɹ�����ȴ���������ȷ��";
                   // HttpContext.Current.Response.Write("<script>alert('�ύ�ɹ�����ȴ���������ȷ��');</script>");
                }
                reload();//ˢ��ҳ��
                //NLogTest nlog = new NLogTest();
                //string sss = "¼���ʽ�" + lbcaptID.Text;
                //nlog.WriteLog(Session["UserName"].ToString(), sss);
            }

        }
        protected void confirm_Click(object sender, EventArgs e)//ȷ�����
        {
            //string updateString = string.Format("update e_capital set capitalEarn={1},capitalIntime='{2}',state=1 where capitalID='{0}'", lbcaptID.Text, Convert.ToInt32(lbcaptIDown.Text) + Convert.ToInt32(txtPLAN.Text), lbtime.Text);
            string updateString = string.Format("update e_capital set capitalEarn={1},capitalIn=0,state=1 where capitalID='{0}'", lbcaptID.Text, Convert.ToInt32(lbcaptIDown.Text) + Convert.ToInt32(txtPLAN.Text));
            int result = msq.getmysqlcom(updateString);
            if(result>0)
            {
               // HttpContext.Current.Response.Write("<script>alert('���ȷ�ϳɹ�');</script>");
                lblErr.InnerText = "���ȷ�ϳɹ�";
                txtPLAN.Enabled = true;
                btyes.Enabled = true;
                confirm.Visible = false;
            }
            reload();
        }
}
}
