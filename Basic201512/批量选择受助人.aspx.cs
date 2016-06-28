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
using System.Data.OleDb;
using System.Diagnostics;

public partial class Basic201512_批量选择受助人 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if(Request.QueryString.Count>0)
            {
                lblID.Text = Request["id"].Trim();
            }
            else
            {

            }
        }
    }

    #region 连接Excel  读取Excel数据   并返回DataSet数据集合
    /// <summary>
    /// 连接Excel  读取Excel数据   并返回DataSet数据集合
    /// </summary>
    /// <param name="filepath">Excel服务器路径</param>
    /// <param name="tableName">Excel表名称</param>
    /// <returns></returns>
    public static System.Data.DataSet ExcelSqlConnection(string filepath, string tableName)
    {
        //string strCon = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
        // string strConn = "Provider=Microsoft.Jet.OleDb.4.0;data source=" + filename + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
        //string strCon = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=" + filepath + ";Extended Properties='Excel 12.0 Xml;HDR=NO'";
        string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';";
        OleDbConnection ExcelConn = new OleDbConnection(strCon);
        try
        {
            string strCom = string.Format("SELECT * FROM [Sheet1$]");
            ExcelConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, ExcelConn);
            DataSet ds = new DataSet();
            //myCommand.Fill(ds, "[" + tableName + "$]");
            myCommand.Fill(ds, tableName);
            return ds;
        }
        catch
        {
            return null;
        }
        finally
        {
            ExcelConn.Close();
        }
    }
    #endregion

    protected void btnImport_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        if(lblID.Text.Trim()=="")
        {
            lblError.Text = "请输入项目ID";
            return;
        }
        int idNum = 0;
        string selectIdString = "select count(*) as countNum from e_project where projectID='" + lblID.Text.Trim() + "'";
        MySqlDataReader mysqlreadID = msq.getmysqlread(selectIdString);
        while(mysqlreadID.Read())
        {
            idNum = mysqlreadID.GetInt32("countNum");
        }
        if(idNum==0)
        {
            lblError.Text = "请输入正确的项目ID";
            return;
        }
        if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
        {
            Response.Write("<script>alert('请选择Excel文件')</script> ");
            return;//当无文件时,返回
        }
        string IsXlsx = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
        if (IsXlsx != ".xlsx" && IsXlsx != ".xls")
        {
            Response.Write("<script>alert('只可以选择Excel文件')</script>");
            return;//当选择的不是Excel文件时,返回
        }
        string filename = FileUpload1.FileName;              //获取Excle文件名  DateTime日期函数
        string savePath = Server.MapPath(("selectRecipients\\") + filename);//Server.MapPath 获得虚拟服务器相对路径
        //检查文件是否存在
        if (File.Exists(savePath))
        {
            Response.Write("<script>alert('使用过的Excel文件')</script>");
            return;
        }
        else
            FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上
        DataSet ds = ExcelSqlConnection(savePath, filename);           //调用自定义方法
        DataRow[] dr = ds.Tables[0].Select();            //定义一个DataRow数组
        int rowsnum = ds.Tables[0].Rows.Count;
        if (rowsnum == 0)
        {
            Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
        }
        else
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            List<string> SQLStringList = new List<string>();
            string strSelectID = "select recipientsID from e_recipients where recipientsPIdcard=";
            MySqlDataReader mysqlread;
            //while (mysqlread.Read())

            for (int i = 0; i < dr.Length; i++)
            {
                //前面除了你需要在建立一个“selectRecipients”的文件夹外，其他的都不用管了，你只需要通过下面的方式获取Excel的值，然后再将这些值用你的方式去插入到数据库里面
                string strIdCard = dr[i]["身份证号"].ToString();
                string strReadId = strSelectID + "'" + strIdCard + "'";
                mysqlread = msq.getmysqlread(strReadId);
                string strRcptId="";
                while(mysqlread.Read())
                {
                    strRcptId = mysqlread.GetString(0);
                }
                string str113 = string.Format("insert into e_pr (projectID,recipientID,request) values ({0},{1},'{2}')", lblID.Text.Trim(), strRcptId, dr[i]["救助申请"].ToString());
                SQLStringList.Add(str113);
            }
            ExecuteSqlTran(SQLStringList);
            //sw.Stop();
            NLogTest nlog = new NLogTest();
            string sss = "批量选择了受助人：" + filename;
            nlog.WriteLog(Session["UserName"].ToString(), sss);
            Response.Write("<script>alert('Excle表导入成功!');</script>");
            //TimeSpan timeSpan = sw.Elapsed;
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
}