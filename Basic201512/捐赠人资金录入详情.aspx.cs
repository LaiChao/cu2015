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

public partial class Basic201512_捐赠人资金录入详情 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
        {
            Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
            return;
        }
        if(!Page.IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                string strID = Request["id"].Trim();
                ViewState["now"] = "select * from e_capital_detail where detailID='" + strID + "' ";
            }
            databind();
        }
    }

    protected void databind()
    {
        mysqlconn msq = new mysqlconn();
        MySqlConnection mysqlcon = msq.getmysqlcon();
        DataSet ds = MySqlHelper.ExecuteDataset(mysqlcon, ViewState["now"].ToString());
        DataView dv = new DataView(ds.Tables[0]);
        GridView1.DataSource = dv;
        //GridView1.DataKeyNames = new string[] { "user" };//主键
        GridView1.DataBind();
    }
}