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

public partial class Basic201512_信息修改 : System.Web.UI.Page
{

    #region "自定义属性"
    internal static Manager manager = Managers.Members["NewUtilityOra"] as Manager;
    internal static ISingleTable entityUsers = manager.Entities["USERS"] as ISingleTable;
    private DataTable dtUsers;

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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)//页面首次加载
        {
            //初始化
            ViewState["myFilename"] = "";
            string urlNow = Request.Url.ToString();
            string[] temp = urlNow.Split('=');
            foreach (string s in temp)
            {
                ViewState["IDNow"] = s;
            }
            pageload();
        }
    }
    //刷新ListBox  
    protected void pageload()
    {
        string Files = "";
        string[] arrFiles;
        if(ListBox1.Items.Count > 0 )
        {
            //清空所有项
            ListBox1.Items.Clear();
        }
        //读取数据库
        string iniSql = string.Format("select infoTitle,infoContent,infoFile from e_info where infoID='{0}'", ViewState["IDNow"].ToString());
        mysqlconn msq11 = new mysqlconn();
        MySqlDataReader mysqlread = msq11.getmysqlread(iniSql);
        while (mysqlread.Read())
        {
            infoTitle.Text = mysqlread.GetString(0);
            ViewState["infoTitle"] = infoTitle.Text.ToString();
            infoContent.Text = mysqlread.GetString(1);
            Files = mysqlread.GetString(2);
            ViewState["myFilename"] = Files;
        }
        arrFiles = Files.Split('|');
        foreach (string s in arrFiles)
        {
            ListBox1.Items.Add(s);
        }
    }
    //提交、写入数据库
    protected void submit()
    {
        if (infoContent.Text.Length <= 0)
        {
            HttpContext.Current.Response.Write("<script>alert('信息内容不能为空');</script>");
        }
        else
            if (infoTitle.Text.Length <= 0)
            {
                HttpContext.Current.Response.Write("<script>alert('信息标题不能为空');</script>");
            }
            else
            {

                string str11 = string.Format("update e_info set infoTitle='{0}',infoContent='{1}',infoFile='{2}' where infoID='{3}'", infoTitle.Text, infoContent.Text, ViewState["myFilename"].ToString(), ViewState["IDNow"].ToString());
                int res = msq.getmysqlcom(str11);
                if (res > 0)
                {
                    NLogTest nlog = new NLogTest();
                    string sss = "修改了信息：" + ViewState["infoTitle"].ToString();
                    nlog.WriteLog(Session["UserName"].ToString(),sss);
                    HttpContext.Current.Response.Write("<script>alert('信息修改成功');</script>");
                    //infoTitle.Text = infoContent.Text = "";
                    //重置？
                    //ViewState["myFilename"] = "";
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('信息修改失败');</script>");

                }
            }
    }
    //提交修改信息按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        submit();
        pageload();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");// 会弹出询问是否关闭
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
        {
            // 将文件保存到本机
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(FI.Name));
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
    // 上传文件类
    public bool UpLoadFile(FileUpload FU, string NewFileName)
    {
        if (FU.HasFile)  // 判断是否有文件上传
        {
            // 原来的扩展名（取得的扩展名包括“.”）
            string OldExtensionName = Path.GetExtension(FU.FileName).ToLower();
            // 保存文件的虚拟路径
            string Url = "File\\" + NewFileName + OldExtensionName;
            // 保存文件的物理路径
            string FullPath = HttpContext.Current.Server.MapPath(Url);
            try
            {
                // 检查文件是否存在
                if (File.Exists(FullPath))
                {
                    HttpContext.Current.Response.Write("<script>alert('文件已存在，请重新上传。');</script>");
                    return false;
                }
                else
                {
                    FU.SaveAs(FullPath);
                    if (ViewState["myFilename"].ToString() == "")
                        ViewState["myFilename"] = NewFileName + OldExtensionName;
                    else
                        ViewState["myFilename"] = ViewState["myFilename"].ToString() + "|" + NewFileName + OldExtensionName;
                    HttpContext.Current.Response.Write("<script>alert('文件已成功上传。');</script>");
                    return true;
                }
            }
            catch {
                return false;           
            }
        }
        else
        {
            HttpContext.Current.Response.Write("<script>alert('请选择上传的文件');</script>");
            return false;
        }
    }

    // “上传文件”按钮事件
    protected void Button3_Click(object sender, EventArgs e)
    {
        // 原来的文件名
        string OldFileName = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
        if(UpLoadFile(FileUpload1, OldFileName))
        {
            submit();
            pageload();
        }        
        //Response.Redirect(Request.Url.PathAndQuery.ToString());
    }
    ////刷新按钮
    //protected void Button6_Click(object sender, EventArgs e)
    //{
    //    //Response.Redirect(Request.Url.PathAndQuery.ToString());
    //    pageload();
    //}
    // 删除文件类
    public bool DeleteFile(string FullFileName)
    {
        // 保存文件的虚拟路径
        string Url = "File\\" + FullFileName;
        // 保存文件的物理路径
        string FullPath = HttpContext.Current.Server.MapPath(Url);
        // 去除文件的只读属性
        File.SetAttributes(FullPath, FileAttributes.Normal);
        // 初始化FileInfo类的实例，作为文件路径的包装
        FileInfo FI = new FileInfo(FullPath);
        // 判断文件是否存在
        if (FI.Exists)
        {
            FI.Delete();
            return true;
        }
        else
            return false;
    }

    // “删除文件”按钮事件
    protected void Button5_Click(object sender, EventArgs e)
    {
        // 判断是否选择了文件名
        if (ListBox1.SelectedValue != "")
        {
            if (Session["SelectedFile"] != "")
            {
                string FullFileName = Session["SelectedFile"].ToString();
                if(DeleteFile(FullFileName))
                {   
                    string[] temps = ViewState["myFilename"].ToString().Split('|');
                    string newFilelist = "";
                    foreach(string s in temps)
                    {
                        if(s!=FullFileName)
                        {
                            newFilelist = newFilelist + "|" + s;
                        }
                    }
                    newFilelist = newFilelist.Trim('|');
                    //修改ViewState
                    ViewState["myFilename"] = newFilelist;
                    //写入数据库
                    submit();
                    //Response.Redirect(Request.Url.PathAndQuery.ToString());
                    pageload();
                }

            }
        }
        else
        {
            Response.Write("<script>alert('请先选择要删除的文件');</script>");
        }
    }
}