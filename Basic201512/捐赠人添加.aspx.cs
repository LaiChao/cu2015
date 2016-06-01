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
using System.Text;

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

//namespace CL.Utility.Web.BasicData
//{
    /// <summary>
    /// Meter ��ժҪ˵����
    /// </summary>
public partial class Basic201512_��������� : System.Web.UI.Page
    {
        mysqlconn msq = new mysqlconn();

        protected void Page_Load(object sender, System.EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                loadPage();
                deadline.Text = DateTime.Now.AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToLongDateString().ToString();
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

        //public bool Checked(object obj)
        //{
        //    if (obj.ToString() == "0")
        //    {
        //        return false;
        //    }
        //    else return true;
        //}

        private void loadPage()
        {
            trSex.Visible = false;
            trAge.Visible = false;
            trContact.Visible = true;
            trMoneyboxNo.Visible = false;
            trDeadline.Visible = false;
            trRange.Visible = false;
            trRemark.Visible = false;
            //����
            tbDirect.Visible = true;
            trRcpType.Visible = false;
            trDesc.Visible = false;
            rdbDirect.Checked = rdbUndirect.Checked = false;
            
            //����
            tbNaming.Visible = true;
            trFundName.Visible = false;
            rdbNaming.Checked = rdbUnNaming.Checked = false;

            //����������������
            trRemind.Visible = false;

        }

        private void tbReset()
        {
            txtRange.Text = txtRemark.Text = description.Text = benfactorName.Text = moneyboxNo.Text = Contacts.Text = TEL.Text = email.Text = "";
        }

        private void BindData()
        {
            string str = string.Format("select * from e_benfactor where benfactorType=5");
            DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),str);
            DataView dv = new DataView(ds.Tables[0]);
            ddlNaming.DataSource = ds;
            ddlNaming.DataTextField = "benfactorName";
            ddlNaming.DataBind();
            string strh = string.Format("select * from e_handlingunit where benfactorFrom ='" + Session["benfactorFrom"].ToString() + "'");
            DataSet ds1 = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),strh);
            DataView dv1 = new DataView(ds1.Tables[0]);
            ddlBranch.DataSource = dv1;
            ddlBranch.DataValueField = "handlingunitID";
            ddlBranch.DataTextField = "benfactorFrom";
            ddlBranch.DataBind();
        }

        protected void rdoDirect_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDirect.Checked)
            {
                trRcpType.Visible = true;
                trDesc.Visible = true;
                tbNaming.Visible = false;
            }
            if (rdbUndirect.Checked)
            {
                trRcpType.Visible = false;
                trDesc.Visible = false;
                tbNaming.Visible = true;
            }
        }

        protected void rdoNaming_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbNaming.Checked)
            {
                trFundName.Visible = true;
                tbDirect.Visible = false;
            }
            if(rdbUnNaming.Checked)
            {
                trFundName.Visible = false;
                tbDirect.Visible = true;
            }
        }

        protected void ddlAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            deadline.Text = DateTime.Now.AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToLongDateString().ToString();
        }

        protected void benfactorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(benfactorType.SelectedValue=="1")
            {
                Lb11.Text = "������֯���ƣ�";
                trSex.Visible = false;
                trAge.Visible = false;
                trContact.Visible = true;
                trMoneyboxNo.Visible = false;
                trDeadline.Visible = false;
                trRange.Visible = false;
                trRemark.Visible = false;
                //����
                tbDirect.Visible = true;
                trRcpType.Visible = false;
                trDesc.Visible = false;
                rdbDirect.Checked = rdbUndirect.Checked = false;
                //����
                tbNaming.Visible = true;
                trFundName.Visible = false;
                rdbNaming.Checked = rdbUnNaming.Checked = false;
                //����������������
                trRemind.Visible = false;
                return;
            }
            if(benfactorType.SelectedValue=="2")
            {
                Lb11.Text = "��λ���ƣ�";
                trSex.Visible = false;
                trAge.Visible = false;
                trContact.Visible = true;
                trMoneyboxNo.Visible = false;
                trDeadline.Visible = false;
                trRange.Visible = false;
                trRemark.Visible = false;

                tbDirect.Visible = true;
                trRcpType.Visible = false;
                trDesc.Visible = false;
                rdbDirect.Checked = rdbUndirect.Checked = false;

                tbNaming.Visible = true;
                trFundName.Visible = false;
                rdbNaming.Checked = rdbUnNaming.Checked = false;
                //����������������
                trRemind.Visible = false;
                return;
            }
            if(benfactorType.SelectedValue=="3")
            {
                Lb11.Text = "������";
                trSex.Visible = true;
                trAge.Visible = false;
                trContact.Visible = false;
                trMoneyboxNo.Visible = false;
                trDeadline.Visible = false;
                trRange.Visible = false;
                trRemark.Visible = false;

                tbDirect.Visible = true;
                trRcpType.Visible = false;
                trDesc.Visible = false;
                rdbDirect.Checked = rdbUndirect.Checked = false;

                tbNaming.Visible = true;
                trFundName.Visible = false;
                rdbNaming.Checked = rdbUnNaming.Checked = false;
                //����������������
                trRemind.Visible = false;
                return;
            }
            if(benfactorType.SelectedValue=="4")
            {
                Lb11.Text = "ļ�������ƣ�";
                trSex.Visible = false;
                trAge.Visible = false;
                trContact.Visible = true;
                trMoneyboxNo.Visible = true;
                trDeadline.Visible = false;
                trRange.Visible = false;
                trRemark.Visible = false;

                tbDirect.Visible = true;
                trRcpType.Visible = false;
                trDesc.Visible = false;
                rdbDirect.Checked = rdbUndirect.Checked = false;

                tbNaming.Visible = true;
                trFundName.Visible = false;
                rdbNaming.Checked = rdbUnNaming.Checked = false;
                //����������������
                trRemind.Visible = false;
                return;
            }
            if(benfactorType.SelectedValue=="5")
            {
                Lb11.Text = "�������ƾ��������ƣ�";
                trSex.Visible = false;
                trAge.Visible = true;
                trContact.Visible = true;
                trMoneyboxNo.Visible = false;
                trDeadline.Visible = true;
                trRange.Visible = true;
                trRemark.Visible = true;
                tbDirect.Visible = false;
                tbNaming.Visible = false;
                //����������������
                trRemind.Visible = true;
                return;
            }
        }

        protected void Btinput_Click(object sender, EventArgs e)
        {
            string strbranchID="";//���쵥λID
            string strBenfactorType;//����������
            string strTEL;//�ֻ���
            string strBenfactorID;//������ID
            //string selectBranchID = "select handlingunitID from e_handlingunit where benfactorFrom='" + ddlBranch.Text.ToString() + "'";
            //MySqlDataReader mysqlread1 = msq.getmysqlread(selectBranchID);
            //while (mysqlread1.Read())
            if (TEL.Text.Trim() == "")
            {
                labError.Text = "�������ֻ���";
                return;
            }
            strbranchID = ddlBranch.SelectedValue.ToString();
            if (strbranchID=="")
            {
                labError.Text = "δ�ҵ��þ��쵥λ��ID";
                return;
            }
            strBenfactorType = benfactorType.SelectedValue;
            strTEL = TEL.Text.ToString();
            strBenfactorID = strbranchID + strBenfactorType + strTEL;

            try
            {
                if (benfactorType.SelectedValue == "1")//������֯
                {
                    string strgongyi = string.Format("insert into e_benfactor (benfactorID,benfactorName,handlingunitID,benfactorFrom,benfactorType,Contacts,TEL,email,remainMoney) values('{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}',{8})", strBenfactorID, benfactorName.Text.ToString(), strbranchID, ddlBranch.SelectedItem.Text.ToString(), strBenfactorType, Contacts.Text.ToString(), strTEL, email.Text.ToString(), "0");
                    msq.getmysqlcom(strgongyi);
                    if (rdbNaming.Checked)
                    {
                        string strUpdNaming = "update e_benfactor set naming=1,namingSelected='" + ddlNaming.SelectedItem.Text.ToString() + "' where benfactorID='" + strBenfactorID + "'";
                        msq.getmysqlcom(strUpdNaming);
                    }
                    if (rdbDirect.Checked)
                    {
                        string strUpdDirect = "update e_benfactor set direction=1,recipientsType='" + recipientsType.SelectedItem.Text.ToString() + "',recipientsDescription='" + description.Text.ToString() + "' where benfactorID='" + strBenfactorID + "'";
                        msq.getmysqlcom(strUpdDirect);
                    }
                    tbReset();
                    labError.Text = "��ӳɹ�";
                }
                if (benfactorType.SelectedValue == "2")//��λ
                {
                    string strfaren = string.Format("insert into e_benfactor (benfactorID,benfactorName,handlingunitID,benfactorFrom,benfactorType,Contacts,TEL,email,remainMoney) values('{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}',{8})", strBenfactorID, benfactorName.Text.ToString(), strbranchID, ddlBranch.SelectedItem.Text.ToString(), strBenfactorType, Contacts.Text.ToString(), strTEL, email.Text.ToString(), "0");
                    msq.getmysqlcom(strfaren);
                    if (rdbNaming.Checked)
                    {
                        string strUpdNaming = "update e_benfactor set naming=1,namingSelected='" + ddlNaming.SelectedItem.Text.ToString() + "',recipientsDescription='" + description.Text.ToString() + "' where benfactorID='" + strBenfactorID + "'";
                        msq.getmysqlcom(strUpdNaming);
                    }
                    if (rdbDirect.Checked)
                    {
                        string strUpdDirect = "update e_benfactor set direction=1,recipientsType='" + recipientsType.SelectedItem.Text.ToString() + "' where benfactorID='" + strBenfactorID + "'";
                        msq.getmysqlcom(strUpdDirect);
                    }
                    tbReset();
                    labError.Text = "��ӳɹ�";
                }
                if (benfactorType.SelectedValue == "3")//��Ȼ��
                {
                    string strziran = string.Format("insert into e_benfactor (benfactorID,benfactorName,handlingunitID,benfactorFrom,benfactorType,sex,TEL,email,remainMoney) values('{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}',{8})", strBenfactorID, benfactorName.Text.ToString(), strbranchID, ddlBranch.SelectedItem.Text.ToString(), strBenfactorType, ddlSex.SelectedItem.Text.ToString(), strTEL, email.Text.ToString(), "0");
                    msq.getmysqlcom(strziran);
                    if (rdbNaming.Checked)
                    {
                        string strUpdNaming = "update e_benfactor set naming=1,namingSelected='" + ddlNaming.SelectedItem.Text.ToString() + "' where benfactorID='" + strBenfactorID + "'";
                        msq.getmysqlcom(strUpdNaming);
                    }
                    if (rdbDirect.Checked)
                    {
                        string strUpdDirect = "update e_benfactor set direction=1,recipientsType='" + recipientsType.SelectedItem.Text.ToString() + "',recipientsDescription='" + description.Text.ToString() + "' where benfactorID='" + strBenfactorID + "'";
                        msq.getmysqlcom(strUpdDirect);
                    }
                    tbReset();
                    labError.Text = "��ӳɹ�";
                }
                if (benfactorType.SelectedValue == "4")//ļ����
                {
                    string strmujuan = string.Format("insert into e_benfactor (benfactorID,benfactorName,handlingunitID,benfactorFrom,benfactorType,Contacts,TEL,email,moneyboxNo,remainMoney) values('{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}','{8}',{9})", strBenfactorID, benfactorName.Text.ToString(), strbranchID, ddlBranch.SelectedItem.Text.ToString(), strBenfactorType, Contacts.Text.ToString(), strTEL, email.Text.ToString(), moneyboxNo.Text.ToString(), "0");
                    msq.getmysqlcom(strmujuan);
                    if (rdbNaming.Checked)
                    {
                        string strUpdNaming = "update e_benfactor set naming=1,namingSelected='" + ddlNaming.SelectedItem.Text.ToString() + "' where benfactorID='" + strBenfactorID + "'";
                        msq.getmysqlcom(strUpdNaming);
                    }
                    if (rdbDirect.Checked)
                    {
                        string strUpdDirect = "update e_benfactor set direction=1,recipientsType='" + recipientsType.SelectedItem.Text.ToString() + "',recipientsDescription='" + description.Text.ToString() + "' where benfactorID='" + strBenfactorID + "'";
                        msq.getmysqlcom(strUpdDirect);
                    }
                    tbReset();
                    labError.Text = "��ӳɹ�";
                }
                if (benfactorType.SelectedValue == "5")//����������
                {
                    string strgongyi = string.Format("insert into e_benfactor (benfactorID,benfactorName,handlingunitID,benfactorFrom,benfactorType,Contacts,TEL,email,namingAge,deadline,bftRange,bftRemark,remainMoney) values('{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}',{8},'{9}','{10}','{11}',{12})", strBenfactorID, benfactorName.Text.ToString(), strbranchID, ddlBranch.SelectedItem.Text.ToString(), strBenfactorType, Contacts.Text.ToString(), strTEL, email.Text.ToString(), ddlAge.Text.ToString(), DateTime.Now.AddYears(Convert.ToInt16(ddlAge.SelectedValue)), txtRange.Text.ToString(), txtRemark.Text.ToString(), "0");
                    msq.getmysqlcom(strgongyi);
                    if (ddlCycle.SelectedValue!="0")
                    {
                        string strRemind = string.Format("insert into e_remind (benfactorID,cycle,flag) values ('{0}',{1},{2})", strBenfactorID, ddlCycle.SelectedValue.ToString(), ddlAge.SelectedValue.ToString());
                        msq.getmysqlcom(strRemind);
                    }
                    tbReset();
                    labError.Text = "��ӳɹ�";
                }
                //loadPage();
                //foreach (System.Web.UI.Control stl in this.Form.Controls)
                //{
                //    if (stl is System.Web.UI.WebControls.TextBox)
                //    {
                //        TextBox tb = (TextBox)stl;
                //        tb.Text = "";
                //    }
                //}
            }
            catch
            {
                labError.Text = "���ʧ�ܣ��ֻ����ظ���";
            }





            //NLogTest nlog = new NLogTest();
            //string sss = "��Ӿ����ˣ�" + gongyizuzhi.Text;
            //nlog.WriteLog(Session["UserName"].ToString(), sss);

            
        }

    }
//}
