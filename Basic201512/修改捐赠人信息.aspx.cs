using System;
using System.Collections;
using System.Collections.Specialized;
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

public partial class Basic201512_修改捐赠人信息 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();
    string strBranchID;
    string strBenfactorType;
    string strTEL;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            //初始化
            string urlNow = Request.Url.ToString();
            string[] temp = urlNow.Split('=');
            foreach (string s in temp)
            {
                ViewState["IDNow"] = s;
            }
            strBranchID = ViewState["IDNow"].ToString().Substring(0, 3);//经办单位ID
            strBenfactorType = ViewState["IDNow"].ToString().Substring(3, 1);//捐助人类型

            BindData();
            //loadPage();
        }

    }

    protected void BindData()//绑定数据
    {
        //捐助人ID
        lblID.Text = ViewState["IDNow"].ToString();
        //冠名慈善捐助金列表
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), "select * from e_benfactor where benfactorType=5");
        DataView dv = new DataView(ds.Tables[0]);
        ddlNaming.DataSource = ds;
        ddlNaming.DataTextField = "benfactorName";
        ddlNaming.DataBind();
        //经办单位
        string strh = string.Format("select * from e_handlingunit where handlingunitID=" + strBranchID);
        DataSet ds1 = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), strh);
        DataView dv1 = new DataView(ds1.Tables[0]);
        ddlBranch.DataSource = dv1;
        ddlBranch.DataValueField = "handlingunitID";
        ddlBranch.DataTextField = "benfactorFrom";
        ddlBranch.DataBind();
        //捐助人类型
        benfactorType.SelectedValue = strBenfactorType;
        if(strBenfactorType!="3")//不是个人
        {
            trSex.Visible = false;
        }
        else//是个人
        {
            trContact.Visible = false;
        }
        if(strBenfactorType!="4")//不是募捐箱
        {
            trMoneyboxNo.Visible = false;
        }
        if(strBenfactorType!="5")//不是冠名慈善捐助金
        {
            tbNaming.Visible = false;
            trAge.Visible = false;
            trDeadline.Visible = false;
        }
        else//是冠名慈善捐助金
        {
            tbNaming.Visible = false;
            tbDirect.Visible = false;
        }
        //绑定其他信息
        string str113 = "select * from e_benfactor where benfactorID='" + ViewState["IDNow"].ToString() + "'";
        MySqlDataReader mysqlread = msq.getmysqlread(str113);
        while (mysqlread.Read())
        {
            benfactorName.Text = mysqlread.GetString("benfactorName");
            TEL.Text = strTEL = mysqlread.GetString("TEL");
            email.Text = mysqlread.GetString("email");
        }
        if (!string.IsNullOrEmpty(mysqlread["Contacts"].ToString()))
        {
            Contacts.Text = mysqlread.GetString("Contacts");
        }
        if (!string.IsNullOrEmpty(mysqlread["sex"].ToString()))
        {
            ddlSex.SelectedValue = mysqlread.GetString("sex");
        }
        if (!string.IsNullOrEmpty(mysqlread["moneyboxNo"].ToString()))
        {
            moneyboxNo.Text = mysqlread.GetString("moneyboxNo");
        }
        if (!string.IsNullOrEmpty(mysqlread["namingAge"].ToString()))
        {//保存未修改前的冠名年限
            ViewState["namingAge"] = lblAge.Text = mysqlread.GetString("namingAge");
            if (ViewState["namingAge"].ToString() == "1")
                btnMinus.Enabled = false;
            deadline.Text = mysqlread.GetString("deadline");
        }
        //绑定是否选择冠名/定向
        if (mysqlread["naming"].ToString()=="1")
        {
            rdbNaming.Checked = true;
            ddlNaming.Text = mysqlread["namingSelected"].ToString();
            tbNaming.Visible = true;

            tbDirect.Visible = false;
        }
        if (mysqlread["direction"].ToString()=="1")
        {
            rdbDirect.Checked = true;
            recipientsType.SelectedValue = mysqlread["recipientsType"].ToString();
            tbDirect.Visible = true;

            tbNaming.Visible = false;
        }

        benfactorName.Enabled = false;
        ddlBranch.Enabled = false;
        benfactorType.Enabled = false;
        //TEL.Enabled = false;
    }

    //private void loadPage()//控制页面显示
    //{
    //    trSex.Visible = false;
    //    trAge.Visible = false;
    //    trContact.Visible = true;
    //    trMoneyboxNo.Visible = false;
    //    trDeadline.Visible = false;
    //    //定向
    //    tbDirect.Visible = true;
    //    trRcpType.Visible = false;
    //    //rdbDirect.Checked = rdbUndirect.Checked = false;

    //    //冠名
    //    tbNaming.Visible = true;
    //    trFundName.Visible = false;
    //    //rdbNaming.Checked = rdbUnNaming.Checked = false;


    //}

    private void tbReset()
    {
        benfactorName.Text = moneyboxNo.Text = Contacts.Text = TEL.Text = email.Text = "";
    }

    protected void rdoDirect_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbDirect.Checked)
        {
            trRcpType.Visible = true;
            tbNaming.Visible = false;
        }
        if (rdbUndirect.Checked)
        {
            trRcpType.Visible = false;
            tbNaming.Visible = true;
            trFundName.Visible = false;
        }
    }

    protected void rdoNaming_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbNaming.Checked)
        {
            trFundName.Visible = true;
            tbDirect.Visible = false;
        }
        if (rdbUnNaming.Checked)
        {
            trFundName.Visible = false;
            tbDirect.Visible = true;
        }
    }

    //protected void ddlAge_SelectedIndexChanged(object sender, EventArgs e)
    //{//更改截止日期
    //    deadline.Text = Convert.ToDateTime(deadline.Text.ToString()).AddYears(Convert.ToInt16(ddlAge.SelectedValue) - Convert.ToInt16(ViewState["namingAge"].ToString())).ToString();
    //    ViewState["namingAge"] = ddlAge.SelectedValue;//更改年限
    //}

    //protected void benfactorType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (benfactorType.SelectedValue == "1")
    //    {
    //        Lb11.Text = "公益组织名称：";
    //        trSex.Visible = false;
    //        trAge.Visible = false;
    //        trContact.Visible = true;
    //        trMoneyboxNo.Visible = false;
    //        trDeadline.Visible = false;
    //        //定向
    //        tbDirect.Visible = true;
    //        trRcpType.Visible = false;
    //        rdbDirect.Checked = rdbUndirect.Checked = false;
    //        //冠名
    //        tbNaming.Visible = true;
    //        trFundName.Visible = false;
    //        rdbNaming.Checked = rdbUnNaming.Checked = false;
    //        return;
    //    }
    //    if (benfactorType.SelectedValue == "2")
    //    {
    //        Lb11.Text = "单位名称：";
    //        trSex.Visible = false;
    //        trAge.Visible = false;
    //        trContact.Visible = true;
    //        trMoneyboxNo.Visible = false;
    //        trDeadline.Visible = false;

    //        tbDirect.Visible = true;
    //        trRcpType.Visible = false;
    //        rdbDirect.Checked = rdbUndirect.Checked = false;

    //        tbNaming.Visible = true;
    //        trFundName.Visible = false;
    //        rdbNaming.Checked = rdbUnNaming.Checked = false;
    //        return;
    //    }
    //    if (benfactorType.SelectedValue == "3")
    //    {
    //        Lb11.Text = "姓名：";
    //        trSex.Visible = true;
    //        trAge.Visible = false;
    //        trContact.Visible = false;
    //        trMoneyboxNo.Visible = false;
    //        trDeadline.Visible = false;

    //        tbDirect.Visible = true;
    //        trRcpType.Visible = false;
    //        rdbDirect.Checked = rdbUndirect.Checked = false;

    //        tbNaming.Visible = true;
    //        trFundName.Visible = false;
    //        rdbNaming.Checked = rdbUnNaming.Checked = false;
    //        return;
    //    }
    //    if (benfactorType.SelectedValue == "4")
    //    {
    //        Lb11.Text = "募捐箱名称：";
    //        trSex.Visible = false;
    //        trAge.Visible = false;
    //        trContact.Visible = true;
    //        trMoneyboxNo.Visible = true;
    //        trDeadline.Visible = false;

    //        tbDirect.Visible = true;
    //        trRcpType.Visible = false;
    //        rdbDirect.Checked = rdbUndirect.Checked = false;

    //        tbNaming.Visible = true;
    //        trFundName.Visible = false;
    //        rdbNaming.Checked = rdbUnNaming.Checked = false;
    //        return;
    //    }
    //    if (benfactorType.SelectedValue == "5")
    //    {
    //        Lb11.Text = "冠名慈善捐助金名称：";
    //        trSex.Visible = false;
    //        trAge.Visible = true;
    //        trContact.Visible = true;
    //        trMoneyboxNo.Visible = false;
    //        trDeadline.Visible = true;
    //        tbDirect.Visible = false;
    //        tbNaming.Visible = false;
    //        return;
    //    }
    //}

    protected void Btinput_Click(object sender, EventArgs e)//提交修改
    {
        //经办单位ID
        //strBranchID
        //捐助人类型
        //strBenfactorType
        //手机号
        //strTEL
        //捐赠人ID
        //ViewState["IDNow"].ToString()
        //以上是不变的
        try
        {
            if (benfactorType.SelectedValue == "1")//公益组织
            {
                string strgongyi = string.Format("update e_benfactor set Contacts='{0}',email='{1}',TEL='{3}' where benfactorID='{2}'", Contacts.Text.ToString(), email.Text.ToString(), ViewState["IDNow"].ToString(),TEL.Text.Trim());
                msq.getmysqlcom(strgongyi);
                if (rdbNaming.Checked)
                {
                    string strUpdNaming = "update e_benfactor set naming=1,namingSelected='" + ddlNaming.SelectedItem.Text.ToString() + "' where benfactorID='" + ViewState["IDNow"].ToString() + "'";
                    msq.getmysqlcom(strUpdNaming);
                }
                if (rdbDirect.Checked)
                {
                    string strUpdDirect = "update e_benfactor set direction=1,recipientsType='" + recipientsType.SelectedItem.Text.ToString() + "' where benfactorID='" + ViewState["IDNow"].ToString() + "'";
                    msq.getmysqlcom(strUpdDirect);
                }
                labError.Text = "修改成功";
            }
            if (benfactorType.SelectedValue == "2")//单位
            {
                string strfaren = string.Format("update e_benfactor set Contacts='{0}',email='{1}',TEL='{3}' where benfactorID='{2}'", Contacts.Text.ToString(), email.Text.ToString(), ViewState["IDNow"].ToString(), TEL.Text.Trim());
                msq.getmysqlcom(strfaren);
                if (rdbNaming.Checked)
                {
                    string strUpdNaming = "update e_benfactor set naming=1,namingSelected='" + ddlNaming.SelectedItem.Text.ToString() + "' where benfactorID='" + ViewState["IDNow"].ToString() + "'";
                    msq.getmysqlcom(strUpdNaming);
                }
                if (rdbDirect.Checked)
                {
                    string strUpdDirect = "update e_benfactor set direction=1,recipientsType='" + recipientsType.SelectedItem.Text.ToString() + "' where benfactorID='" + ViewState["IDNow"].ToString() + "'";
                    msq.getmysqlcom(strUpdDirect);
                }
                labError.Text = "修改成功";
            }
            if (benfactorType.SelectedValue == "3")//个人
            {
                string strziran = string.Format("update e_benfactor set sex='{0}',email='{1}',TEL='{3}' where benfactorID='{2}'", ddlSex.SelectedValue.ToString(), email.Text.ToString(), ViewState["IDNow"].ToString(), TEL.Text.Trim());
                msq.getmysqlcom(strziran);
                if (rdbNaming.Checked)
                {
                    string strUpdNaming = "update e_benfactor set naming=1,namingSelected='" + ddlNaming.SelectedItem.Text.ToString() + "' where benfactorID='" + ViewState["IDNow"].ToString() + "'";
                    msq.getmysqlcom(strUpdNaming);
                }
                if (rdbDirect.Checked)
                {
                    string strUpdDirect = "update e_benfactor set direction=1,recipientsType='" + recipientsType.SelectedItem.Text.ToString() + "' where benfactorID='" + ViewState["IDNow"].ToString() + "'";
                    msq.getmysqlcom(strUpdDirect);
                }
                labError.Text = "修改成功";
            }
            if (benfactorType.SelectedValue == "4")//募捐箱
            {
                string strmujuan = string.Format("update e_benfactor set Contacts='{0}',email='{1}',moneyboxNo='{2}',TEL='{4}' where benfactorID='{3}'", Contacts.Text.ToString(), email.Text.ToString(), moneyboxNo.Text.ToString(), ViewState["IDNow"].ToString(), TEL.Text.Trim());
                msq.getmysqlcom(strmujuan);
                if (rdbNaming.Checked)
                {
                    string strUpdNaming = "update e_benfactor set naming=1,namingSelected='" + ddlNaming.SelectedItem.Text.ToString() + "' where benfactorID='" + ViewState["IDNow"].ToString() + "'";
                    msq.getmysqlcom(strUpdNaming);
                }
                if (rdbDirect.Checked)
                {
                    string strUpdDirect = "update e_benfactor set direction=1,recipientsType='" + recipientsType.SelectedItem.Text.ToString() + "' where benfactorID='" + ViewState["IDNow"].ToString() + "'";
                    msq.getmysqlcom(strUpdDirect);
                }
                labError.Text = "修改成功";
            }
            if (benfactorType.SelectedValue == "5")//冠名慈善捐助金
            {//更改年限
                string strgongyi = string.Format("update e_benfactor set Contacts='{0}',email='{1}',namingAge='{2}',deadline='{3}',TEL='{5}' where benfactorID='{4}'", Contacts.Text.ToString(), email.Text.ToString(), lblAge.Text.Trim(), deadline.Text.ToString(), ViewState["IDNow"].ToString(), TEL.Text.Trim());
                msq.getmysqlcom(strgongyi);
                labError.Text = "修改成功";
            }

        }
        catch
        {
            labError.Text = "添加失败";
        }





        //NLogTest nlog = new NLogTest();
        //string sss = "修改了捐助人信息：" + gongyizuzhi.Text;
        //nlog.WriteLog(Session["UserName"].ToString(), sss);

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int tempint = Convert.ToInt16(lblAge.Text.Trim()) + 1;
        lblAge.Text = tempint.ToString();
        if (lblAge.Text.Trim() == "2")
            btnMinus.Enabled = true;
        deadline.Text = Convert.ToDateTime(deadline.Text.ToString()).AddYears(1).ToString();
    }
    protected void btnMinus_Click(object sender, EventArgs e)
    {
        int tempint = Convert.ToInt16(lblAge.Text.Trim()) - 1;
        lblAge.Text = tempint.ToString();
        if (lblAge.Text.Trim() == "1")
            btnMinus.Enabled = false;
        deadline.Text = Convert.ToDateTime(deadline.Text.ToString()).AddYears(-1).ToString();
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("捐赠人信息管理.aspx");
    }
}