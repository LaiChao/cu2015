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

//namespace CL.Utility.Web.BasicData
//{
    /// <summary>
    /// Meter 的摘要说明。
    /// </summary>
public partial class Basic201512_捐助人添加 : System.Web.UI.Page
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
            //定向
            tbDirect.Visible = true;
            trRcpType.Visible = false;
            trDesc.Visible = false;
            rdbDirect.Checked = rdbUndirect.Checked = false;
            
            //冠名
            tbNaming.Visible = true;
            trFundName.Visible = false;
            rdbNaming.Checked = rdbUnNaming.Checked = false;


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
                Lb11.Text = "公益组织名称：";
                trSex.Visible = false;
                trAge.Visible = false;
                trContact.Visible = true;
                trMoneyboxNo.Visible = false;
                trDeadline.Visible = false;
                trRange.Visible = false;
                trRemark.Visible = false;
                //定向
                tbDirect.Visible = true;
                trRcpType.Visible = false;
                trDesc.Visible = false;
                rdbDirect.Checked = rdbUndirect.Checked = false;
                //冠名
                tbNaming.Visible = true;
                trFundName.Visible = false;
                rdbNaming.Checked = rdbUnNaming.Checked = false;
                return;
            }
            if(benfactorType.SelectedValue=="2")
            {
                Lb11.Text = "单位名称：";
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
                return;
            }
            if(benfactorType.SelectedValue=="3")
            {
                Lb11.Text = "姓名：";
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
                return;
            }
            if(benfactorType.SelectedValue=="4")
            {
                Lb11.Text = "募捐箱名称：";
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
                return;
            }
            if(benfactorType.SelectedValue=="5")
            {
                Lb11.Text = "冠名慈善捐助金名称：";
                trSex.Visible = false;
                trAge.Visible = true;
                trContact.Visible = true;
                trMoneyboxNo.Visible = false;
                trDeadline.Visible = true;
                trRange.Visible = true;
                trRemark.Visible = true;
                tbDirect.Visible = false;
                tbNaming.Visible = false;
                return;
            }
        }

        protected void Btinput_Click(object sender, EventArgs e)
        {
            string strbranchID="";//经办单位ID
            string strBenfactorType;//捐助人类型
            string strTEL;//手机号
            string strBenfactorID;//捐助人ID
            //string selectBranchID = "select handlingunitID from e_handlingunit where benfactorFrom='" + ddlBranch.Text.ToString() + "'";
            //MySqlDataReader mysqlread1 = msq.getmysqlread(selectBranchID);
            //while (mysqlread1.Read())
            if (TEL.Text.Trim() == "")
            {
                labError.Text = "请输入手机号";
                return;
            }
            strbranchID = ddlBranch.SelectedValue.ToString();
            if (strbranchID=="")
            {
                labError.Text = "未找到该经办单位的ID";
                return;
            }
            strBenfactorType = benfactorType.SelectedValue;
            strTEL = TEL.Text.ToString();
            strBenfactorID = strbranchID + strBenfactorType + strTEL;

            try
            {
                if (benfactorType.SelectedValue == "1")//公益组织
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
                    labError.Text = "添加成功";
                }
                if (benfactorType.SelectedValue == "2")//单位
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
                    labError.Text = "添加成功";
                }
                if (benfactorType.SelectedValue == "3")//自然人
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
                    labError.Text = "添加成功";
                }
                if (benfactorType.SelectedValue == "4")//募捐箱
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
                    labError.Text = "添加成功";
                }
                if (benfactorType.SelectedValue == "5")//冠名捐助金
                {
                    string strgongyi = string.Format("insert into e_benfactor (benfactorID,benfactorName,handlingunitID,benfactorFrom,benfactorType,Contacts,TEL,email,namingAge,deadline,bftRange,bftRemark,remainMoney) values('{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}',{8},'{9}','{10}','{11}',{12})", strBenfactorID, benfactorName.Text.ToString(), strbranchID, ddlBranch.SelectedItem.Text.ToString(), strBenfactorType, Contacts.Text.ToString(), strTEL, email.Text.ToString(), ddlAge.Text.ToString(), DateTime.Now.AddYears(Convert.ToInt16(ddlAge.SelectedValue)), txtRange.Text.ToString(), txtRemark.Text.ToString(), "0");
                    msq.getmysqlcom(strgongyi);
                    tbReset();
                    labError.Text = "添加成功";
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
                labError.Text = "添加失败，手机号重复了";
            }





            //NLogTest nlog = new NLogTest();
            //string sss = "添加捐助人：" + gongyizuzhi.Text;
            //nlog.WriteLog(Session["UserName"].ToString(), sss);

            
        }

    }
//}
