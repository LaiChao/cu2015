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

public partial class Basic201512_冠名分期 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
        {
            Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
            return;
        }
        if(!Page.IsPostBack)
        {
            databind();
        }
    }
    public void databind()
    {
        string s = "select e_remind.benfactorID as ID,cycle,flag,benfactorName,handlingunitID,benfactorFrom,deadline from e_remind,e_benfactor where e_remind.flag>0 and e_remind.benfactorID=e_benfactor.benfactorID and now()>date_sub(deadline,interval cycle*flag month)";
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), s);
        DataView dv = new DataView(ds.Tables[0]);
        //GridView绑定数据
        GridView1.DataSource = dv;
        GridView1.DataKeyNames = new string[] { "ID" };//主键
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="cancelRemind")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string strupdate = string.Format("update e_remind set flag=flag-1 where benfactorID={0}", GridView1.DataKeys[index].Value.ToString());
            msq.getmysqlcom(strupdate);
            databind();
        }
    }
}