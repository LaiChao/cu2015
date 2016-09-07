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
            if (Request.QueryString.Count > 0)
            {
                string strID = Request["id"].Trim();
                ViewState["now"] = "select * from e_capital_detail where detailID='" + strID + "' ";
            }
            databind();
            if(Session["benfactorFrom"].ToString() != "北京市朝阳区慈善协会捐助科")
            {
                GridView1.Columns[9].Visible = false;
            }
        }
    }

    protected void databind()
    {
        MySqlConnection mysqlcon = msq.getmysqlcon();
        DataSet ds = MySqlHelper.ExecuteDataset(mysqlcon, ViewState["now"].ToString());
        DataView dv = new DataView(ds.Tables[0]);
        GridView1.DataSource = dv;
        GridView1.DataKeyNames = new string[] { "ID" };//主键
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string updateString = string.Format("update e_capital set capitalEarn=capitalEarn-{1} where capitalID='{0}'", GridView1.Rows[e.RowIndex].Cells[1].Text, GridView1.Rows[e.RowIndex].Cells[6].Text);
        string update2String = string.Format("update e_capital_detail set operator='{1}',opType='撤回录入',opTime='{2}',opBranchName='{3}' where ID='{0}'", GridView1.DataKeys[e.RowIndex].Value.ToString(), Session["UserName"].ToString(), DateTime.Now.ToString(), Session["benfactorFrom"].ToString());
        HttpContext.Current.Response.Write("<script>alert('金额撤回成功');</script>");
        NLogTest nlog = new NLogTest();
        string sss = "捐助科撤回了" + GridView1.Rows[e.RowIndex].Cells[0].Text + "的" + GridView1.Rows[e.RowIndex].Cells[2].Text + "的捐赠金额" + GridView1.Rows[e.RowIndex].Cells[6].Text + "元。资金ID：" + GridView1.Rows[e.RowIndex].Cells[1].Text;
        nlog.WriteLog(Session["UserName"].ToString(), sss);
        msq.getmysqlcom(updateString);
        msq.getmysqlcom(update2String);
        databind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //int count = GridView1.Rows.Count;
        //如果是绑定数据行 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //鼠标经过时，行背景色变 
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
            //鼠标移出时，行背景色变 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[9].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('确认要撤回吗?')");
                if (e.Row.Cells[5].Text != "确认录入")//((Label)(e.Row.Cells[5].Controls[0])).Text != "确认录入"
                {
                    ((LinkButton)e.Row.Cells[9].Controls[0]).Visible = false;
                }
            }
        }
        //for (int i = 0; i < count; i++)
        //{
        //    if (((Label)(GridView1.Rows[i].Cells[5].Controls[0])).Text.Trim() != "确认录入")
        //    {
        //        ((LinkButton)GridView1.Rows[i].Cells[9].Controls[0]).Visible = false;
        //        continue;
        //    }
        //}
    }
}