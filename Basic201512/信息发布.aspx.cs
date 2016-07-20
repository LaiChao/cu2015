using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
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
using luyunfei;
//mysql数据库连接
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class Basic201512_信息发布 : System.Web.UI.Page
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

    string str111 = "select benfactorFrom from e_handlingunit";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)  // 页面首次加载
        {
            //初始化
            int intRole = Convert.ToInt32(Session["userRole"].ToString());
            if(intRole==1)
            {
                CheckBox1.Visible = false;
            }
            publicProject.Visible = false;
            ViewState["myFilename"] = "";
            MySqlConnection mysqlcon = msq.getmysqlcon();
            DataSet ds = MySqlHelper.ExecuteDataset(mysqlcon, str111);
            DataView dv = new DataView(ds.Tables[0]);
            //DropDownList1.AppendDataBoundItems = true;
            //DropDownList1.DataSource = dv;
            //DropDownList1.DataTextField = "benfactorFrom";
            //DropDownList1.DataBind();
            DropDownCheckBoxList1.DataSource = dv;
            DropDownCheckBoxList1.DataTextField = "benfactorFrom";
            DropDownCheckBoxList1.DataBind();
            DropDownCheckBoxList1.Visible = false;
            if(Request.QueryString.Count>0)//如果是从审批未通过跳转过来的
            {
                infoTitle.Text = "项目：" + Request["title"].Trim() + " 审批未通过";
                //DropDownList1.SelectedValue = Request["branchName"].Trim();
                DropDownList1.SelectedValue = "选择机构";
                DropDownCheckBoxList1.Visible = true;
                //DropDownCheckBoxList1.SelectedValue = Request["branchName"].Trim();
                DropDownCheckBoxList1.SelectedText = Request["branchName"].Trim();
            }


        }

    }
    //刷新ListBox  
    protected void pageload()
    {
        //string Files = "";
        string[] arrFiles;
        if (ListBox1.Items.Count > 0)
        {
            //清空所有项
            ListBox1.Items.Clear();
        }
        //读取数据库
        //string iniSql = string.Format("select infoTitle,infoContent,infoFile from e_info where infoID='{0}'", ViewState["IDNow"].ToString());
        //mysqlconn msq11 = new mysqlconn();
        //MySqlDataReader mysqlread = msq11.getmysqlread(iniSql);
        //while (mysqlread.Read())
        //{
        //    infoTitle.Text = mysqlread.GetString(0);
        //    infoContent.Text = mysqlread.GetString(1);
        //    Files = mysqlread.GetString(2);
        //    ViewState["myFilename"] = Files;
        //}
        arrFiles = ViewState["myFilename"].ToString().Split('|');
        foreach (string s in arrFiles)
        {
            ListBox1.Items.Add(s);
        }
    }

    //发布信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (infoTitle.Text.Length <= 0)
        {
            lblError.Text = "信息标题不能为空";
            //HttpContext.Current.Response.Write("<script>alert('信息标题不能为空');</script>");
            return;
        }
        else
            if (infoContent.Text.Length <= 0)
        {
          //  HttpContext.Current.Response.Write("<script>alert('信息内容不能为空');</script>");
            lblError.Text = "信息内容不能为空";
            return;
        }
        else
        //if(infoTitle.Text.Length>0 && infoContent.Text.Length>0)
        {
            string zerostr = "未读";
            if(DropDownList1.SelectedValue=="所有机构")
            {
                string str11 = string.Format("insert into e_info (infoTitle,infoContent,infoDATE,infoFile,infoFrom,infoTo,infoRead,projectID) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", infoTitle.Text, infoContent.Text, DateTime.Now.ToString(), ViewState["myFilename"].ToString(), Session["UserName"].ToString(), DropDownList1.Text.Trim(), zerostr,tbID.Text.Trim());
                int res = msq.getmysqlcom(str11);
                //写入数据库
                if (res > 0)
                {
                    NLogTest nlog = new NLogTest();
                    string s = "发布了信息：" + infoTitle.Text.ToString();
                    nlog.WriteLog(Session["UserName"].ToString(),s);
                    //HttpContext.Current.Response.Write("<script>alert('信息发布成功');</script>");
                    lblError.Text = "信息发布成功";
                    //重置
                    infoTitle.Text = infoContent.Text = "";
                    ViewState["myFilename"] = "";
                    pageload();
                }
                else
                {
                    //HttpContext.Current.Response.Write("<script>alert('信息发布失败');</script>");
                    lblError.Text = "信息发布失败";
                }
            }
            else//多收件人n>0
            {//事务
                List<string> SQLStringList = new List<string>();
                string insertString = "";
                string[] recs = DropDownCheckBoxList1.SelectedValue.ToString().Split(',');
                foreach(string s in recs)
                {
                    insertString = string.Format("insert into e_info (infoTitle,infoContent,infoDATE,infoFile,infoFrom,infoTo,infoRead,projectID) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", infoTitle.Text, infoContent.Text, DateTime.Now.ToString(), ViewState["myFilename"].ToString(), Session["UserName"].ToString(), s, zerostr,tbID.Text.Trim());
                    SQLStringList.Add(insertString);
                }
                ExecuteSqlTran(SQLStringList);
                lblError.Text = "信息发布成功";
            }
        }
    }

    public static void ExecuteSqlTran(List<string> SQLStringList)
    {
        using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=123456;database=mscsdb;charset=gbk;"))
        {
            //MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=123456;database=mscsdb;charset=gbk;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            MySqlTransaction tx = conn.BeginTransaction();
            cmd.Transaction = tx;
            try
            {
                for (int n = 0; n < SQLStringList.Count; n++)
                {
                    string strsql = SQLStringList[n].ToString();
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        cmd.ExecuteNonQuery();
                    }
                }
                tx.Commit();//一次性提交
            }
            //catch (System.Data.SqlClient.SqlException E)
            //{//身份证号重复将直接忽略，捕获不到异常
            //    tx.Rollback();
            //    HttpContext.Current.Response.Write("<script>alert('身份证号重复了');</script>");
            //    //throw new Exception(E.Message);
            //}
            finally
            {
                conn.Close();
            }
        }
    }

    // 上传文件类
    public void UpLoadFile(FileUpload FU, string NewFileName)
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
                  //  HttpContext.Current.Response.Write("<script>alert('文件已存在，请重新上传。');</script>");
                    lblError.Text = "文件已存在，请重新上传。";
                    return;
                }
                else
                {
                    FU.SaveAs(FullPath);
                    //赋值
                    if (ViewState["myFilename"].ToString() == "")
                        ViewState["myFilename"] = NewFileName + OldExtensionName;
                    else
                        ViewState["myFilename"] = ViewState["myFilename"].ToString() + "|" + NewFileName + OldExtensionName;
                    //HttpContext.Current.Response.Write("<script>alert('文件已成功上传。');</script>");
                    lblError.Text = "文件已成功上传。";
                }
            }
            catch { }
        }
        else
        {
            //HttpContext.Current.Response.Write("<script>alert('请选择上传的文件');</script>");
            lblError.Text = "请选择上传的文件";
        }
    }

    // “上传文件”按钮事件
    protected void Button3_Click(object sender, EventArgs e)
    {
        // 原来的文件名
        string OldFileName = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
        UpLoadFile(FileUpload1, OldFileName);
        //Response.Redirect(Request.Url.PathAndQuery.ToString());
        pageload();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "所有机构")
            DropDownCheckBoxList1.Visible = false;
        else
            DropDownCheckBoxList1.Visible = true;
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if(CheckBox1.Checked)
        {
            publicProject.Visible = true;
        }
        else
        {
            tbID.Text = "";
            publicProject.Visible = false;

        }
    }
}