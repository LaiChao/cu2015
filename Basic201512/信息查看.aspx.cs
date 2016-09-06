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
using System.Text;

public partial class Basic201512_信息查看 : System.Web.UI.Page
{

    #region "自定义属性"
    //internal static Manager manager = Managers.Members["NewUtilityOra"] as Manager;
    //internal static ISingleTable entityUsers = manager.Entities["USERS"] as ISingleTable;
    //private DataTable dtUsers;

    private string bindPCKey = "USER_ID";//绑定 能源节点数据的主键

    internal static WriteLog wl = new WriteLog();
    internal static UserInterface ui = new UserInterface();
    private const string PAGE_NAME = "用户";

    public const string sPMS_CTG_ID = "USER_ID";
    public const string sPMS_CTG_NAME = "USER_NAME";
    public const string sPwd = "USER_PWD";
    public const string sUSE_IDT = "USE_IDT";
    public const string sCRT_DATE = "CRT_DATE";
    public const string sUPD_DATE = "UPD_DATE";
    public const string sDES = "DES";


    private const string PK = "projectID";
    public const string sID = "projectID";
    public const string sName = "projectName";//public时页面能引用，private时不可以
    protected System.Data.DataTable _dtData;
    protected System.Data.DataTable _dtData1;
    mysqlconn msq = new mysqlconn();
    string sqldata1 = string.Format("select * from e_project");
    string sqldata = string.Format("select * from e_recipientscan");
    string sqldatadrop = string.Format("select *from e_recipientsfenpei");
    #endregion

    mysqlconn msq11 = new mysqlconn();
    //string IDNow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
        {
            Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
            return;
        }
        string urlNow = Request.Url.ToString();
        string[] temp = urlNow.Split('=');
        string Files="";
        string receive = "";
        string[] arrFiles;
        foreach (string s in temp)
        {
            ViewState["IDNow"] = s;
            //IDNow = s;
        }
        if (!Page.IsPostBack)//页面首次加载
        {
            publicProject.Visible = false;
            btnBatch.Visible = false;
            //btnBatchAdd.Visible = false;
            btnchoic.Visible = false;

            string iniSql = string.Format("select infoTitle,infoContent,infoFile,infoTo,infoFrom,projectID,infoRead from e_info where infoID='{0}'", ViewState["IDNow"].ToString());
            MySqlDataReader mysqlread = msq11.getmysqlread(iniSql);
            while (mysqlread.Read())
            {
                infoTitle.Text = mysqlread.GetString("infoTitle");
                infoContent.Text = mysqlread.GetString("infoContent");
                Files = mysqlread.GetString("infoFile");
                receive = mysqlread.GetString("infoTo");
                tbID.Text = mysqlread.GetString("projectID");
                ViewState["sender"] = mysqlread.GetString("infoFrom");//发件人
                DropDownList1.SelectedValue = mysqlread.GetString("infoRead");
            }
            arrFiles = Files.Split('|');
            foreach(string s in arrFiles)
            {
                ListBox1.Items.Add(s);
            }
            infoTitle.Enabled = false;
            infoContent.Enabled = false;
            if(tbID.Text.Trim()!="")
            {
                publicProject.Visible = true;
                btnBatch.Visible = true;
                //btnBatchAdd.Visible = true;
                btnchoic.Visible = true;
            }
            if(receive=="所有机构")
            {//群发信息不显示未读/已读标记
                Label3.Visible = false;
                DropDownList1.Visible = false;
                if (Session["benfactorFrom"].ToString() == ViewState["sender"].ToString())//除非是发件人才显示
                {
                    Label3.Visible = true;
                    DropDownList1.Visible = true;
                }
            }
            else
            {//非群发信息 
                Label3.Visible = false;
                DropDownList1.Visible = false;
                if (Session["benfactorFrom"].ToString() == receive)//只有收件人可以标记
                {
                    Label3.Visible = true;
                    DropDownList1.Visible = true;
                }
            }
            
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("信息接收.aspx");
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SelectedFile"] = ListBox1.SelectedValue.ToString();
    }

    //  下载文件类
    public void DownLoadFile(string FullFileName)
    {
        // 保存文件的虚拟路径
        string Url = "File\\" + FullFileName;
        // 保存文件的物理路径
        string FullPath = HttpContext.Current.Server.MapPath(Url);
        // 初始化FileInfo类的实例，作为文件路径的包装
        FileInfo FI = new FileInfo(FullPath);
        // 判断文件是否存在
        if (FI.Exists)
        {// 将文件保存到本机
            string outputFilename = null;
            Response.Clear();

            string browser = HttpContext.Current.Request.UserAgent.ToUpper();
            if (browser.Contains("MS") == true && browser.Contains("IE") == true)
            {
                outputFilename = Server.UrlEncode(FI.Name);
            }
            else if (browser.Contains("FIREFOX") == true)
            {
                outputFilename = "\""+FI.Name+"\"";
            }
            else
            {
                outputFilename = Server.UrlEncode(FI.Name);
            }

            Response.AddHeader("Content-Disposition", "attachment;filename=" + outputFilename);
            Response.AddHeader("Content-Length", FI.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.Filter.Close();
            Response.WriteFile(FI.FullName);
            Response.End();
        }
    }

    // “下载文件”按钮事件
    protected void Button4_Click(object sender, EventArgs e)
    {
        // 判断是否选择了文件名
        if (ListBox1.SelectedValue != "")
        {
            if (Session["SelectedFile"] != "")
            {
                string FullFileName = Session["SelectedFile"].ToString();
                DownLoadFile(FullFileName);

            }
        }
        else
        {
            Response.Write("<script>alert('请先选择要下载的文件');</script>");
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        StringBuilder updateString = new StringBuilder();
        updateString.Append("update e_info set infoRead='");
        updateString.Append(DropDownList1.Text.ToString());
        updateString.Append("' where infoID='");
        updateString.Append(ViewState["IDNow"].ToString() + "'");

        
        int res = msq.getmysqlcom(updateString.ToString());
        //写入数据库
        if (res > 0)
        {
            //NLogTest nlog = new NLogTest();
            //string s = "发布了信息：" + infoTitle.Text.ToString();
            //nlog.WriteLog(Session["UserName"].ToString(), s);
            HttpContext.Current.Response.Write("<script>alert('标记成功');</script>");
        }
        else
        {
            HttpContext.Current.Response.Write("<script>alert('标记失败');</script>");

        }
    }
    protected void btnReceipt_Click(object sender, EventArgs e)
    {
        string zerostr = "未读";
        string str11 = string.Format("insert into e_info (infoTitle,infoContent,infoDATE,infoFile,infoFrom,infoTo,infoRead) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", Session["benfactorFrom"].ToString() + "的回执：" + infoTitle.Text, "原始信息：" + infoContent.Text, DateTime.Now.ToString(), "", Session["benfactorFrom"].ToString(), ViewState["sender"].ToString(), zerostr);
        int res = msq.getmysqlcom(str11);
        //写入数据库
        if (res > 0)
        {
            NLogTest nlog = new NLogTest();
            string s = "发布了信息：“" + infoTitle.Text.ToString()+"”的回执";
            nlog.WriteLog(Session["UserName"].ToString(), s);
            lblErr.Text = "发送成功！";
        }
        else
        {
            lblErr.Text = "发送失败！";
        }
    }
    protected void btnBatch_Click(object sender, EventArgs e)
    {
        Response.Redirect("批量选择受助人.aspx?id=" + tbID.Text.Trim());
    }
    protected void btnchoic_Click(object sender, EventArgs e)
    {
        Response.Redirect("查询受助人.aspx?id=" + tbID.Text.Trim());
    }
    //protected void btnBatchAdd_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("批量添加受助人.aspx?id=" + tbID.Text.Trim());
    //}
}