using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
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

public partial class Basic201512_实体信息日志 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)//页面首次加载
        {
            ViewState["init"] = "select * from e_log where Message like'%项目%'or Message like'%资金%' order by ID DESC";
            //ViewState["Query"] = str111;
            ViewState["now"] = ViewState["init"];
            databind(ViewState["init"].ToString());
        }
    }
    public void databind(string s)
    {
        MySqlConnection mysqlcon = msq.getmysqlcon();
        DataSet ds = MySqlHelper.ExecuteDataset(mysqlcon, s);
        DataView dv = new DataView(ds.Tables[0]);
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //如果是绑定数据行 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //鼠标经过时，行背景色变 
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
            //鼠标移出时，行背景色变 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        databind(ViewState["now"].ToString());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string temp = " where ";
        string temp2 = "";
        string user = TextBox1.Text.ToString();
        if(user=="")
        {
            if (TextBox2.Text.ToString().Length == 0 && TextBox3.Text.ToString().Length == 0)
            {
                ViewState["now"] = "select * from e_log where Message like'%项目%'or Message like'%资金%' order by ID DESC";
                databind(ViewState["now"].ToString());
                return;
            }
            if(TextBox2.Text.ToString().Length!=0&& TextBox3.Text.ToString().Length == 0)
            {
                temp = temp + "CreateDate>'" + TextBox2.Text.ToString() + "'";
                ViewState["now"] = "select * from e_log" + temp + "and Message like'%项目%'or Message like'%资金%' order by ID DESC";
                databind(ViewState["now"].ToString());
                return;
            }
            if (TextBox2.Text.ToString().Length == 0 && TextBox3.Text.ToString().Length != 0)
            {
                temp = temp + "CreateDate<'" + TextBox3.Text.ToString() + " 23:59:59'";
                ViewState["now"] = "select * from e_log" + temp + "and Message like'%项目%'or Message like'%资金%' order by ID DESC";
                databind(ViewState["now"].ToString());
                return;
            }
            if (TextBox2.Text.ToString().Length != 0 && TextBox3.Text.ToString().Length != 0)
            {
                temp = temp + "CreateDate>'" + TextBox2.Text.ToString() + "' and " + "CreateDate<'" + TextBox3.Text.ToString() + " 23:59:59'";
                ViewState["now"] = "select * from e_log" + temp + "and Message like'%项目%'or Message like'%资金%' order by ID DESC";
                databind(ViewState["now"].ToString());
                return;
            }
        }
        else//user!=""
        {
            temp = temp + "user = '" + user + "' ";
            if (TextBox2.Text.ToString().Length == 0 && TextBox3.Text.ToString().Length == 0)
            {
                ViewState["now"] = "select * from e_log" + temp + "and Message like'%项目%'or Message like'%资金%' order by ID DESC";
                databind(ViewState["now"].ToString());
                return;
            }
            else
                temp = temp + "and ";
            if (TextBox2.Text.ToString().Length != 0 && TextBox3.Text.ToString().Length == 0)
            {
                temp = temp + "CreateDate>'" + TextBox2.Text.ToString() + "'";
                ViewState["now"] = "select * from e_log" + temp + "and Message like'%项目%'or Message like'%资金%' order by ID DESC";
                databind(ViewState["now"].ToString());
                return;
            }
            if (TextBox2.Text.ToString().Length == 0 && TextBox3.Text.ToString().Length != 0)
            {
                temp = temp + "CreateDate<'" + TextBox3.Text.ToString() + " 23:59:59'";
                ViewState["now"] = "select * from e_log" + temp + "and Message like'%项目%'or Message like'%资金%' order by ID DESC";
                databind(ViewState["now"].ToString());
                return;
            }
            if (TextBox2.Text.ToString().Length != 0 && TextBox3.Text.ToString().Length != 0)
            {
                temp = temp + "CreateDate>'" + TextBox2.Text.ToString() + "' and " + "CreateDate<'" + TextBox3.Text.ToString() + " 23:59:59'";
                ViewState["now"] = "select * from e_log" + temp + "and Message like'%项目%'or Message like'%资金%' order by ID DESC";
                databind(ViewState["now"].ToString());
                return;
            }
        }



    }
}