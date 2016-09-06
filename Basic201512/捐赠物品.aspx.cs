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

public partial class Basic201512_捐赠物品 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();
    //string strBranchID;//经办单位ID
    //string strBranchName;//经办单位名称
    //string strName;//捐赠人名称

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
        {
            Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
            return;
        }
        if (!Page.IsPostBack)
        {
            //初始化
            string urlNow = Request.Url.ToString();
            string[] temp = urlNow.Split('=');
            foreach (string s in temp)
            {
                ViewState["IDNow"] = s;//捐赠人ID
            }
            //strBranchID = ViewState["IDNow"].ToString().Substring(0, 3);//经办单位ID

            string strSelectBranch = "select benfactorFrom from e_handlingunit where handlingunitID=" + ViewState["IDNow"].ToString().Substring(0, 3);
            MySqlDataReader mysqlread = msq.getmysqlread(strSelectBranch);
            while (mysqlread.Read())
            {
                ViewState["branchName"] = mysqlread.GetString("benfactorFrom");
            }
            lblBranch.Text = ViewState["branchName"].ToString();
            string strSelectName = "select benfactorName from e_benfactor where benfactorID=" + ViewState["IDNow"].ToString();
            MySqlDataReader mysqlread2 = msq.getmysqlread(strSelectName);
            while(mysqlread2.Read())
            {
                ViewState["name"] = mysqlread2.GetString("benfactorName");
            }
            lblName.Text = ViewState["name"].ToString();

        }
    }

    //protected void BindData()//绑定数据
    //{

    //}

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (tbItem.Text.Trim() == "")
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "请填入捐赠物品!";
            tbItem.BackColor = Color.FromArgb((int)0xFFE1FF);
            tbItem.Focus();
            return;
        }
        else
        {
            tbItem.BackColor = Color.White;
        }

        if (tbValue.Text.Trim() == "")
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "请输入公允值（元）!";
            tbValue.BackColor = Color.FromArgb((int)0xFFE1FF);
            tbValue.Focus();
            return;
        }
        else
        {
            try
            {
                Convert.ToDouble(tbValue.Text.Trim());
            }
            catch
            {
            	lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "公允值为正数";
            	tbValue.BackColor = Color.FromArgb((int)0xFFE1FF);
            	tbValue.Focus();
                return;
            }
            if(Convert.ToDouble(tbValue.Text.Trim())<=0)
            {
            	lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "公允值为正数";
            	tbValue.BackColor = Color.FromArgb((int)0xFFE1FF);
            	tbValue.Focus();
                return;
            }
            tbValue.BackColor = Color.White;
        }
        string insertString = string.Format("insert into e_item (handlingunitID,benfactorFrom,benfactorID,benfactorName,item,fairValue,state,timeIn) values({0},'{1}',{2},'{3}','{4}',{5},'{6}','{7}')", ViewState["IDNow"].ToString().Substring(0, 3), ViewState["branchName"].ToString(), ViewState["IDNow"].ToString(), ViewState["name"].ToString(), tbItem.Text.Trim(), tbValue.Text.Trim(), "未使用", DateTime.Now.ToString());
        //try
        //{
            msq.getmysqlcom(insertString);
            lblError.Text = "提交成功";
            NLogTest nlog = new NLogTest();
            string sss = "为" + lblBranch.Text + "的" + lblName.Text + "录入了物品：" + tbItem.Text + "，公允值：" + tbValue.Text + "元。";
            nlog.WriteLog(Session["UserName"].ToString(), sss);
        //}
        //catch
        //{
        //    lblError.Text = "提交失败";
        //}
    }
}