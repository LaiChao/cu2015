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

public partial class Permission_用户权限 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();
    string str111 = "select benfactorFrom from e_handlingunit";
    //string str112 = "select * from e_user";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)//页面首次加载
        {
            DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), str111);
            DataView dv = new DataView(ds.Tables[0]);
            branchName.AppendDataBoundItems = true;
            branchName.DataSource = dv;
            branchName.DataTextField = "benfactorFrom";
            branchName.DataBind();
            ViewState["init"] = "select * from e_user";
            ViewState["now"] = ViewState["init"];
            databind(ViewState["init"].ToString());
        }
    }

    //public MySqlDataReader ddlBind()
    //{
    //    string sqlstr = "SELECT benfactorFrom FROM e_user";
    //    return msq.getmysqlread(sqlstr);
    //}

    protected void databind(string sss)
    {
        
        MySqlConnection mysqlcon2 = msq.getmysqlcon();
        DataSet ds2 = MySqlHelper.ExecuteDataset(mysqlcon2, sss);
        DataView dv2 = new DataView(ds2.Tables[0]);
        GridView1.DataSource = dv2;
        GridView1.DataKeyNames = new string[] { "user" };//主键
        GridView1.DataBind();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (branchName.Text.ToString() != "所有机构")
        {
            string temp = "";
            temp = "where benfactorFrom='" + branchName.Text.ToString() + "'";
            ViewState["Query"] = "select * from e_user " + temp;
            ViewState["now"] = ViewState["Query"];
            databind(ViewState["now"].ToString());
        }
        else
        {
            databind(ViewState["init"].ToString());
        }
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
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {              
                ((LinkButton)e.Row.Cells[4].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[0].Text + "\"吗?')");
            }
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        databind(ViewState["now"].ToString());
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NLogTest nlog = new NLogTest();
        string s = "删除了用户：" + GridView1.Rows[e.RowIndex].Cells[0].Text.ToString();
        nlog.WriteLog(Session["UserName"].ToString(), s);
        string str113 = "delete from e_user where user='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        msq.getmysqlcom(str113);
        databind(ViewState["now"].ToString());
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strNewRole = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
        if (strNewRole == "1" || strNewRole == "2" || strNewRole == "3" || strNewRole == "4")
        {
            string str114 = "update e_user set userRole='"
                + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim() + "' where user='"
                + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
            msq.getmysqlcom(str114);
            NLogTest nlog = new NLogTest();
            string s = "修改了用户信息：" + GridView1.Rows[e.RowIndex].Cells[0].Text.ToString().Trim();
            nlog.WriteLog(Session["UserName"].ToString(), s);
            GridView1.EditIndex = -1;
            databind(ViewState["now"].ToString());
        }
        else
        {
            GridView1.EditIndex = -1;
            databind(ViewState["now"].ToString());
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        databind(ViewState["now"].ToString());
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "resetPWD")
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string str115 = "update e_user set password='12345' where user='" + GridView1.DataKeys[index].Value.ToString() + "'";
            msq.getmysqlcom(str115);
            HttpContext.Current.Response.Write("<script>alert('密码已重置为12345');</script>");
            NLogTest nlog = new NLogTest();
            string s = "重置了用户：" + GridView1.DataKeys[index].Value.ToString() + "的密码";
            nlog.WriteLog(Session["UserName"].ToString(), s);
        }
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.Header:
                //第一行表头
                TableCellCollection tcHeader = e.Row.Cells;
                tcHeader.Clear();
                tcHeader.Add(new TableHeaderCell());
                tcHeader[0].Text = "用户名";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[1].Text = "权限";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[2].Text = "所属机构";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[3].Attributes.Add("colspan", "2");
                tcHeader[3].Text = "操作";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[4].Text = "重置密码";
                break;
        }
    }
}