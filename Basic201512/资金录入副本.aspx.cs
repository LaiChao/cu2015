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
            string strread = string.Format("select benfactorID,benfactorName,TEL,handlingunitID,benfactorFrom from e_benfactor where benfactorID='{0}'", IDNow);//������������������������
            lbcaptID.Text = LbproID.Text = IDNow;
            MySqlDataReader mysqlread = msql.getmysqlread(strread);
            int tempstate=-1;
            lbtime.Text = DateTime.Now.ToString();
            while (mysqlread.Read())
            {
                ViewState["myKey"] = mysqlread.GetString(0);//������ID
                ViewState["myID"] = mysqlread.GetString(3);//���쵥λID
                //  DateTime dt=new DateTime();
                //DateTime dt = DateTime.Now;
                //                lbcaptID.Text = mysqlread.GetString(0) + '0' + mysqlread.GetString(3) + mysqlread.GetString(2);
                LbproID.Text = mysqlread.GetString(1);//����������
                lbbenfnadd.Text = mysqlread.GetString(2);//�绰
                //lbtime.Text = dt.Year.ToString() + '-' + dt.Month.ToString() + '-' + dt.Day.ToString();
                lblBranch.Text = mysqlread.GetString("benfactorFrom");//���쵥λ
            }
            string strreadcap = string.Format("select capitalEarn,state,capitalIn from e_capital where capitalID='{0}'", lbcaptID.Text);
            MySqlDataReader mysqlread1 = msql.getmysqlread(strreadcap);
            while (mysqlread1.Read())
            {
                lbcaptIDown.Text = mysqlread1.GetString(0);//�����ʽ�
                tempstate = mysqlread1.GetInt32(1);//�ʽ�״̬
                txtPLAN.Text = mysqlread1.GetDouble(2).ToString();//¼���ʽ�
            }
            
            if(tempstate==0)
            {
                txtPLAN.Enabled = false;
                btyes.Enabled = false;
                lblErr.Text = "����ϵ������ȷ���ʽ�";
                //HttpContext.Current.Response.Write("<script>alert('����ϵ����ȷ���ʽ�');</script>");
            }
            if(txtPLAN.Enabled==true)
                txtPLAN.Text = "";
            ////�ж�Ȩ��
            //string queryRole = "select userRole from e_user where user='" + Session["UserName"].ToString() + "'";
            //MySqlDataReader mysqlread32 = msql.getmysqlread(queryRole);
            //int roleOfUser=0;
            //while (mysqlread32.Read())
            //{
            //    roleOfUser = mysqlread32.GetInt32(0);
            //}
            //int result;
            if ((tempstate == 0) && (Session["benfactorFrom"].ToString() == "�����г���������Э�������"))
            {//�����ƿ���ȷ�ϻ��߳���
                confirm.Visible = true;
                //btnCancel.Visible = true;
            }
            //if((tempstate==0)&&(Session["benfactorFrom"].ToString()==lblBranch.Text.Trim()))
            //{//���뵥λ���Գ���
            //    //btnCancel.Visible = true;
            //}
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
            //if ((txtPLAN.Text == "")||(txtPLAN.Text=="0"))
            //{
            //    lblErr.InnerText = "��������";
            //   // HttpContext.Current.Response.Write("<script>alert('��������');</script>");
            //    return;
            //}
            //else if(Convert.ToDouble(txtPLAN.Text)<=0)
            //{
            //    lblErr.InnerText = "����������";
            //    return;
            //}

            if (txtPLAN.Text.Trim() == "")
            {
                lblErr.Text = "�������";
                txtPLAN.BackColor = Color.FromArgb((int)0xFFE1FF);
                txtPLAN.Focus();
               // HttpContext.Current.Response.Write("<script>alert('��������');</script>");
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
                	lblErr.Text = "����������";
                	txtPLAN.BackColor = Color.FromArgb((int)0xFFE1FF);
                	txtPLAN.Focus();
                    return;
                }
                if (Convert.ToDouble(txtPLAN.Text.Trim()) <= 0)
                {
                    lblErr.Text = "����������";
                	txtPLAN.BackColor = Color.FromArgb((int)0xFFE1FF);
                	txtPLAN.Focus();
                    return;
                }
				txtPLAN.BackColor = Color.White;
            }

            ////�ж�Ȩ��
            //string queryRole = "select userRole from e_user where user='" + Session["UserName"].ToString() + "'";
            //MySqlDataReader mysqlread32 = msql.getmysqlread(queryRole);
            //int roleOfUser=0;
            //while (mysqlread32.Read())
            //{
            //    roleOfUser = mysqlread32.GetInt32(0);
            //}
            int result;
            //�����Ʋ���ȷ������������գ�2016-8-28ע��
            //if(Session["benfactorFrom"].ToString() == "�����г���������Э�������")//������
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
            //        lblErr.InnerText = "����ʽ�ɹ�";
            //        NLogTest nlog = new NLogTest();
            //        string sss = "������Ϊ" + lblBranch.Text+"��"+LbproID.Text+ "¼���˾������"+txtPLAN.Text+"Ԫ���ʽ�ID��" + lbcaptID.Text;
            //        nlog.WriteLog(Session["UserName"].ToString(), sss);
            //       // HttpContext.Current.Response.Write("<script>alert('����ʽ�ɹ�');</script>");
            //    }
            //    reload();//ˢ��ҳ��
            //}
            //else
            //{//�Ǿ�����Ȩ��
                string strins2 = string.Format("insert into e_capital (capitalID,benfactorID,capitalIn,capitalEarn,capitalIntime,handlingunitID,benfactorName,state,benfactorFrom) values('{0}','{1}','{2}',{3},'{4}','{5}','{6}',0,'{7}')", lbcaptID.Text, (string)ViewState["myKey"], double.Parse(txtPLAN.Text.Trim()), Convert.ToDouble(lbcaptIDown.Text), lbtime.Text, (string)ViewState["myID"], LbproID.Text, lblBranch.Text);
                string strupd2 = string.Format("update e_capital set benfactorID='{1}',capitalIn='{2}',capitalEarn={3},capitalIntime='{4}',handlingunitID='{5}',benfactorName='{6}',state=0,benfactorFrom='{7}' where capitalID='{0}'", lbcaptID.Text, (string)ViewState["myKey"], double.Parse(txtPLAN.Text.Trim()), Convert.ToDouble(lbcaptIDown.Text), lbtime.Text, (string)ViewState["myID"], LbproID.Text, lblBranch.Text);
                string insertString = string.Format("insert into e_capital_detail (detailID,benefactorName,branchName,operator,opType,income,remain,opTime,opBranchName) values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}')", lbcaptID.Text, LbproID.Text, lblBranch.Text, Session["UserName"].ToString(), "����¼��", double.Parse(txtPLAN.Text), Convert.ToDouble(lbcaptIDown.Text), DateTime.Now.ToString(), Session["benfactorFrom"].ToString());
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
                    lblErr.Text = "�ύ�ɹ�����ȴ�����������ȷ��";
                    NLogTest nlog = new NLogTest();
                    string sss = "Ϊ"+lblBranch.Text + "��" + LbproID.Text + "¼���˾������" + txtPLAN.Text + "Ԫ���ʽ�ID��" + lbcaptID.Text;
                    nlog.WriteLog(Session["UserName"].ToString(), sss);

                   // HttpContext.Current.Response.Write("<script>alert('�ύ�ɹ�����ȴ���������ȷ��');</script>");
                }
                reload();//ˢ��ҳ��
            //}

        }
        protected void confirm_Click(object sender, EventArgs e)//ȷ�����
        {
            //string updateString = string.Format("update e_capital set capitalEarn={1},capitalIntime='{2}',state=1 where capitalID='{0}'", lbcaptID.Text, Convert.ToInt32(lbcaptIDown.Text) + Convert.ToInt32(txtPLAN.Text), lbtime.Text);
            string updateString = string.Format("update e_capital set capitalEarn={1},capitalIn=0,state=1 where capitalID='{0}'", lbcaptID.Text, Convert.ToDouble(lbcaptIDown.Text) + Convert.ToDouble(txtPLAN.Text));
            string insertString = string.Format("insert into e_capital_detail (detailID,benefactorName,branchName,operator,opType,income,remain,opTime,opBranchName) values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}')", lbcaptID.Text, LbproID.Text, lblBranch.Text, Session["UserName"].ToString(), "ȷ��¼��", double.Parse(txtPLAN.Text), Convert.ToDouble(lbcaptIDown.Text), DateTime.Now.ToString(), Session["benfactorFrom"].ToString());
            int result = msq.getmysqlcom(updateString);
            if(result>0)
            {
                msq.getmysqlcom(insertString);
                // HttpContext.Current.Response.Write("<script>alert('���ȷ�ϳɹ�');</script>");
                lblErr.Text = "���ȷ�ϳɹ�";
                NLogTest nlog = new NLogTest();
                string sss = "������ȷ�ϣ�Ϊ" + lblBranch.Text + "��" + LbproID.Text + "¼���˾������" + txtPLAN.Text + "Ԫ���ʽ�ID��" + lbcaptID.Text;
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
            //�������
            string updateString = string.Format("update e_capital set capitalIn=0,state=1 where capitalID='{0}'", lbcaptID.Text);
            string insertString = string.Format("insert into e_capital_detail (detailID,benefactorName,branchName,operator,opType,income,remain,opTime,opBranchName) values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}')", lbcaptID.Text, LbproID.Text, lblBranch.Text, Session["UserName"].ToString(), "��������", double.Parse(txtPLAN.Text), Convert.ToDouble(lbcaptIDown.Text), DateTime.Now.ToString(), Session["benfactorFrom"].ToString());            
            int result = msq.getmysqlcom(updateString);
            if(result>0)
            {
                msq.getmysqlcom(insertString);
                lblErr.Text = "���سɹ�";
                NLogTest nlog = new NLogTest();
                string sss = "������" + lblBranch.Text + "��" + LbproID.Text + "����������" + txtPLAN.Text + "Ԫ���ʽ�ID��" + lbcaptID.Text;
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
