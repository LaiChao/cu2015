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
            if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
            {
                Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
                return;
            }
            if (!Page.IsPostBack)
            {
                loadPage();
                //��ʼ����������
                DateTime dt = DateTime.Now;
                ViewState["startDate"] = dt.ToString();
                deadline.Text = DateTime.Now.AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToLongDateString().ToString();
                ViewState["deadline"] = DateTime.Now.AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToString();
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
            trStartDate.Visible = false;
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
            //����ʼ����Ϊ��ʱ��Ĭ�ϴӽ��쿪ʼ
            if (tbStartDate.Text.Trim() == "")
            {
                deadline.Text = DateTime.Now.AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToLongDateString().ToString();
                ViewState["deadline"] = DateTime.Now.AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToString();
            }
            else//����д�˿�ʼ����
            {
                deadline.Text = (Convert.ToDateTime(ViewState["startDate"].ToString())).AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToLongDateString().ToString();
                ViewState["deadline"] = (Convert.ToDateTime(ViewState["startDate"].ToString())).AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToString();
            }

        }
        protected void tbStartDate_TextChanged(object sender, EventArgs e)
        {
            ViewState["startDate"] = tbStartDate.Text.ToString() + " 00:00:00";
            deadline.Text = (Convert.ToDateTime(ViewState["startDate"].ToString())).AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToLongDateString().ToString();
            ViewState["deadline"] = (Convert.ToDateTime(ViewState["startDate"].ToString())).AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToString();
        }

        protected void benfactorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(benfactorType.SelectedValue=="1")
            {
                Lb11.Text = "������֯���ƣ�";
                //����
                trRcpType.Visible = false;
                trDesc.Visible = false;
                rdbDirect.Checked = rdbUndirect.Checked = false;
                //����
                trFundName.Visible = false;
                rdbNaming.Checked = rdbUnNaming.Checked = false;
            }
            if(benfactorType.SelectedValue=="2")
            {
                Lb11.Text = "��λ���ƣ�";

                trRcpType.Visible = false;
                trDesc.Visible = false;
                rdbDirect.Checked = rdbUndirect.Checked = false;

                trFundName.Visible = false;
                rdbNaming.Checked = rdbUnNaming.Checked = false;
            }
            if(benfactorType.SelectedValue=="3")
            {
                Lb11.Text = "������";
                //�Ա�
                trSex.Visible = true;
                //����ʾ��ϵ��
                trContact.Visible = false;

                trRcpType.Visible = false;
                trDesc.Visible = false;
                rdbDirect.Checked = rdbUndirect.Checked = false;

                trFundName.Visible = false;
                rdbNaming.Checked = rdbUnNaming.Checked = false;
            }
            else
            {
                trSex.Visible = false;
                trContact.Visible = true;
            }

            if(benfactorType.SelectedValue=="4")
            {
                Lb11.Text = "ļ�������ƣ�";
                //ļ������
                trMoneyboxNo.Visible = true;

                trRcpType.Visible = false;
                trDesc.Visible = false;
                rdbDirect.Checked = rdbUndirect.Checked = false;

                trFundName.Visible = false;
                rdbNaming.Checked = rdbUnNaming.Checked = false;
            }
            else
            {
                trMoneyboxNo.Visible = false;
            }

            if(benfactorType.SelectedValue=="5")
            {
                Lb11.Text = "�������ƾ��������ƣ�";
                //��ʼ����
                trStartDate.Visible = true;
                //��������
                trAge.Visible = true;
                //������ֹ����
                trDeadline.Visible = true;
                //ʹ�÷�Χ
                trRange.Visible = true;
                //��������
                trRemark.Visible = true;
                //�������������ٶ�����߹�����
                tbDirect.Visible = false;
                tbNaming.Visible = false;
                //����������������
                trRemind.Visible = true;
            }
            else
            {
                trStartDate.Visible = false;
                trAge.Visible = false;
                trDeadline.Visible = false;
                trRange.Visible = false;
                trRemark.Visible = false;
                tbDirect.Visible = true;
                tbNaming.Visible = true;
                trRemind.Visible = false;
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
            switch (int.Parse(benfactorType.SelectedValue))
            {
                case 1:
                    if (benfactorName.Text.Trim() == "")
                    {
                        labError.Text = "������֯���Ʋ���Ϊ�գ�";
                        benfactorName.BackColor = Color.FromArgb((int)0xFFE1FF);
                        benfactorName.Focus();
                        return;
                    }
                    else
                    {
                        benfactorName.BackColor = Color.White;                                          
                    }
                    if (Contacts.Text.Trim() == "")
                    {
                        labError.Text = "��ϵ����������Ϊ�գ�";
                        Contacts.BackColor = Color.FromArgb((int)0xFFE1FF);
                        Contacts.Focus();
                        return;
                    }
                    else
                    {
                        Contacts.BackColor = Color.White;
                    }
                    if (Contacts.Text.Trim() == "")
                    {
                        labError.Text = "��ϵ����������Ϊ�գ�";
                        Contacts.BackColor = Color.FromArgb((int)0xFFE1FF);
                        Contacts.Focus();
                        return;
                    }
                    else
                    {
                        Contacts.BackColor = Color.White;
                    }
                    break; 

                case 2:
                    if (benfactorName.Text.Trim() == "")
                    {
                        labError.Text = "��λ���Ʋ���Ϊ�գ�";
                        benfactorName.BackColor = Color.FromArgb((int)0xFFE1FF);
                        benfactorName.Focus();
                        return;
                    }
                    else
                    {
                        benfactorName.BackColor = Color.White;
                    }
                    break;

                case 3:
                    if (benfactorName.Text.Trim() == "")
                    {
                        labError.Text = "��������Ϊ�գ�";
                        benfactorName.BackColor = Color.FromArgb((int)0xFFE1FF);
                        benfactorName.Focus();
                        return;
                    }
                    else
                    {
                        benfactorName.BackColor = Color.White;                       
                    }
                    break;

                case 4:
                    if (benfactorName.Text.Trim() == "")
                    {
                        labError.Text = "ļ�������Ʋ���Ϊ�գ�";
                        benfactorName.BackColor = Color.FromArgb((int)0xFFE1FF);
                        benfactorName.Focus();
                        return;
                    }
                    else
                    {
                        benfactorName.BackColor = Color.White;
                    }
                    break;

                case 5:
                    if (benfactorName.Text.Trim() == "")
                    {
                        labError.Text = "�������ƾ��������Ʋ���Ϊ�գ�";
                        benfactorName.BackColor = Color.FromArgb((int)0xFFE1FF);
                        benfactorName.Focus();
                        return;
                    }
                    else
                    {
                        benfactorName.BackColor = Color.White;
                    }
                    break;
            }

			
            //ʹ��������ʽ��֤11λ�ֻ�������11λ�������
            Regex mobileReg = new Regex("^[0-9]{11,11}$");
            if (TEL.Text.Trim() == "")
            {
                labError.Text = "�������ֻ���";
                TEL.BackColor = Color.FromArgb((int)0xFFE1FF);
                TEL.Focus();
                return;
            }
            else if (TEL.Text.Trim().Length!=11)
            {
                labError.Text = "11λ�ֻ���λ������";
                TEL.BackColor = Color.FromArgb((int)0xFFE1FF);
                TEL.Focus();
                return;
            }
            else if (mobileReg.IsMatch(TEL.Text.Trim()))
            {//��֤ͨ��
                TEL.BackColor = Color.White;
            }
            else
            {
                labError.Text = "�ֻ�����11λ�������";
                TEL.BackColor = Color.FromArgb((int)0xFFE1FF);
                TEL.Focus();
                return;
            }

            strbranchID = ddlBranch.SelectedValue.ToString();
            if (strbranchID=="")
            {
                labError.Text = "δ�ҵ��þ��쵥λ��ID��";
                return;
            }

            strBenfactorType = benfactorType.SelectedValue;
            strTEL = TEL.Text.ToString();
            strBenfactorID = strbranchID + strBenfactorType + strTEL;

            try
            {
                string strName =  Regex.Replace(benfactorName.Text.ToString(), @"\s", "");
                if (benfactorType.SelectedValue == "1")//������֯
                {
                    string strgongyi = string.Format("insert into e_benfactor (benfactorID,benfactorName,handlingunitID,benfactorFrom,benfactorType,Contacts,TEL,email,remainMoney) values('{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}',{8})", strBenfactorID, strName, strbranchID, ddlBranch.SelectedItem.Text.ToString(), strBenfactorType, Contacts.Text.ToString(), strTEL, email.Text.ToString(), "0");
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
                }
                if (benfactorType.SelectedValue == "2")//��λ
                {
                    string strfaren = string.Format("insert into e_benfactor (benfactorID,benfactorName,handlingunitID,benfactorFrom,benfactorType,Contacts,TEL,email,remainMoney) values('{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}',{8})", strBenfactorID, strName, strbranchID, ddlBranch.SelectedItem.Text.ToString(), strBenfactorType, Contacts.Text.ToString(), strTEL, email.Text.ToString(), "0");
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
                }
                if (benfactorType.SelectedValue == "3")//����
                {
                    string strziran = string.Format("insert into e_benfactor (benfactorID,benfactorName,handlingunitID,benfactorFrom,benfactorType,sex,TEL,email,remainMoney) values('{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}',{8})", strBenfactorID, strName, strbranchID, ddlBranch.SelectedItem.Text.ToString(), strBenfactorType, ddlSex.SelectedItem.Text.ToString(), strTEL, email.Text.ToString(), "0");
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
                }
                if (benfactorType.SelectedValue == "4")//ļ����
                {
                    string strmujuan = string.Format("insert into e_benfactor (benfactorID,benfactorName,handlingunitID,benfactorFrom,benfactorType,Contacts,TEL,email,moneyboxNo,remainMoney) values('{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}','{8}',{9})", strBenfactorID, strName, strbranchID, ddlBranch.SelectedItem.Text.ToString(), strBenfactorType, Contacts.Text.ToString(), strTEL, email.Text.ToString(), moneyboxNo.Text.ToString(), "0");
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
                }
                if (benfactorType.SelectedValue == "5")//����������
                {
                    string strgongyi = string.Format("insert into e_benfactor (benfactorID,benfactorName,handlingunitID,benfactorFrom,benfactorType,Contacts,TEL,email,namingAge,deadline,bftRange,bftRemark,remainMoney) values('{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}',{8},'{9}','{10}','{11}',{12})", strBenfactorID, strName, strbranchID, ddlBranch.SelectedItem.Text.ToString(), strBenfactorType, Contacts.Text.ToString(), strTEL, email.Text.ToString(), ddlAge.Text.ToString(), ViewState["deadline"].ToString(), txtRange.Text.ToString(), txtRemark.Text.ToString(), "0");
                    msq.getmysqlcom(strgongyi);
                    if (ddlCycle.SelectedValue!="0")
                    {
                        string strRemind = string.Format("insert into e_remind (benfactorID,cycle,flag) values ('{0}',{1},{2})", strBenfactorID, ddlCycle.SelectedValue.ToString(), ddlAge.SelectedValue.ToString());
                        msq.getmysqlcom(strRemind);
                    }
                }
                    NLogTest nlog = new NLogTest();
                    string sss = "����˾����ˣ�" + strName;
                    nlog.WriteLog(Session["UserName"].ToString(), sss);
                    tbReset();
                    labError.Text = "��ӳɹ���";
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
        }


}
//}
