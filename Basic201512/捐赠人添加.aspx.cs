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
            if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
            {
                Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
                return;
            }
            if (!Page.IsPostBack)
            {
                loadPage();
                //初始化到期日期
                DateTime dt = DateTime.Now;
                ViewState["startDate"] = dt.ToString();
                deadline.Text = DateTime.Now.AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToLongDateString().ToString();
                ViewState["deadline"] = DateTime.Now.AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToString();
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
            trStartDate.Visible = false;
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

            //冠名分期周期提醒
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
            //当开始日期为空时，默认从今天开始
            if (tbStartDate.Text.Trim() == "")
            {
                deadline.Text = DateTime.Now.AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToLongDateString().ToString();
                ViewState["deadline"] = DateTime.Now.AddYears(Convert.ToInt16(ddlAge.SelectedValue)).ToString();
            }
            else//当填写了开始日期
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
                Lb11.Text = "公益组织名称：";
                //定向
                trRcpType.Visible = false;
                trDesc.Visible = false;
                rdbDirect.Checked = rdbUndirect.Checked = false;
                //冠名
                trFundName.Visible = false;
                rdbNaming.Checked = rdbUnNaming.Checked = false;
            }
            if(benfactorType.SelectedValue=="2")
            {
                Lb11.Text = "单位名称：";

                trRcpType.Visible = false;
                trDesc.Visible = false;
                rdbDirect.Checked = rdbUndirect.Checked = false;

                trFundName.Visible = false;
                rdbNaming.Checked = rdbUnNaming.Checked = false;
            }
            if(benfactorType.SelectedValue=="3")
            {
                Lb11.Text = "姓名：";
                //性别
                trSex.Visible = true;
                //不显示联系人
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
                Lb11.Text = "募捐箱名称：";
                //募捐箱编号
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
                Lb11.Text = "冠名慈善捐助金名称：";
                //开始日期
                trStartDate.Visible = true;
                //冠名年限
                trAge.Visible = true;
                //冠名截止日期
                trDeadline.Visible = true;
                //使用范围
                trRange.Visible = true;
                //冠名提醒
                trRemark.Visible = true;
                //冠名捐助金不能再定向或者冠名了
                tbDirect.Visible = false;
                tbNaming.Visible = false;
                //冠名分期周期提醒
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
            string strbranchID="";//经办单位ID
            string strBenfactorType;//捐助人类型
            string strTEL;//手机号
            string strBenfactorID;//捐助人ID
            //string selectBranchID = "select handlingunitID from e_handlingunit where benfactorFrom='" + ddlBranch.Text.ToString() + "'";
            //MySqlDataReader mysqlread1 = msq.getmysqlread(selectBranchID);
            //while (mysqlread1.Read())
            switch (int.Parse(benfactorType.SelectedValue))
            {
                case 1:
                    if (benfactorName.Text.Trim() == "")
                    {
                        labError.Text = "公益组织名称不能为空！";
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
                        labError.Text = "联系人姓名不能为空！";
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
                        labError.Text = "联系人姓名不能为空！";
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
                        labError.Text = "单位名称不能为空！";
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
                        labError.Text = "姓名不能为空！";
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
                        labError.Text = "募捐箱名称不能为空！";
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
                        labError.Text = "冠名慈善捐助金名称不能为空！";
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

			
            //使用正则表达式验证11位手机号是由11位数字组成
            Regex mobileReg = new Regex("^[0-9]{11,11}$");
            if (TEL.Text.Trim() == "")
            {
                labError.Text = "请输入手机号";
                TEL.BackColor = Color.FromArgb((int)0xFFE1FF);
                TEL.Focus();
                return;
            }
            else if (TEL.Text.Trim().Length!=11)
            {
                labError.Text = "11位手机号位数不对";
                TEL.BackColor = Color.FromArgb((int)0xFFE1FF);
                TEL.Focus();
                return;
            }
            else if (mobileReg.IsMatch(TEL.Text.Trim()))
            {//验证通过
                TEL.BackColor = Color.White;
            }
            else
            {
                labError.Text = "手机号由11位数字组成";
                TEL.BackColor = Color.FromArgb((int)0xFFE1FF);
                TEL.Focus();
                return;
            }

            strbranchID = ddlBranch.SelectedValue.ToString();
            if (strbranchID=="")
            {
                labError.Text = "未找到该经办单位的ID！";
                return;
            }

            strBenfactorType = benfactorType.SelectedValue;
            strTEL = TEL.Text.ToString();
            strBenfactorID = strbranchID + strBenfactorType + strTEL;

            try
            {
                string strName =  Regex.Replace(benfactorName.Text.ToString(), @"\s", "");
                if (benfactorType.SelectedValue == "1")//公益组织
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
                if (benfactorType.SelectedValue == "2")//单位
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
                if (benfactorType.SelectedValue == "3")//个人
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
                if (benfactorType.SelectedValue == "4")//募捐箱
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
                if (benfactorType.SelectedValue == "5")//冠名捐助金
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
                    string sss = "添加了捐赠人：" + strName;
                    nlog.WriteLog(Session["UserName"].ToString(), sss);
                    tbReset();
                    labError.Text = "添加成功！";
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
                labError.Text = "添加失败，手机号重复！";
            }            
        }


}
//}
