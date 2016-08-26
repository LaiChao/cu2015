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

public partial class Basic201512_经办单位信息调整 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();
    //string str111= "select * from e_handlingunit where 1=1 ";
    public static string tableTitle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
        {
            Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
            return;
        }
        if (!Page.IsPostBack)//页面首次加载
        {
            ViewState["queryString"] = "select * from e_handlingunit where 1=1 ";
            //判断是否分会权限
            if (Session["userRole"].ToString()=="1")
            {
                ViewState["queryString"] = ViewState["queryString"].ToString() + "and benfactorFrom='" + Session["benfactorFrom"].ToString() + "'";
            }
            databind(ViewState["queryString"].ToString());
        }
       
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void databind(string s)
    {
        MySqlConnection mysqlcon = msq.getmysqlcon();
        DataSet ds = MySqlHelper.ExecuteDataset(mysqlcon, s);
        DataView dv = new DataView(ds.Tables[0]);
        GridView1.DataSource = dv;
        GridView1.DataKeyNames = new string[] { "handlingunitID" };//主键
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
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[1].Text + "\"吗?')");
                //分会、科室可以修改自己机构的信息
                //科室、会长不能修改其他机构的信息
                //管理员可以修改所有机构的信息
                if (Session["userRole"].ToString()=="2" || Session["userRole"].ToString()=="3")
                {//不能修改其他机构的信息
                    if (e.Row.Cells[1].Text.Trim() != Session["benfactorFrom"].ToString())
                    {
                        ((LinkButton)e.Row.Cells[5].Controls[0]).Enabled = false;
                        ((LinkButton)e.Row.Cells[5].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('不能修改其他机构的信息')");
                    }
                        
                }
                if (Session["userRole"].ToString()!="4")
                {//只有管理员可以删除分会
                    ((LinkButton)e.Row.Cells[6].Controls[0]).Enabled = false;
                    ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('只有管理员可以删除分会')");
                }
            }
        }
        if(e.Row.RowType==DataControlRowType.Header)
        {
            for (int i = 0; i < 6;i++ )
                e.Row.Cells[i].Attributes.Add("style", "background:#ce2c27;");
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        databind(ViewState["queryString"].ToString());
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NLogTest nlog = new NLogTest();
        string s = "删除了经办单位：" + GridView1.Rows[e.RowIndex].Cells[1].Text.ToString();
        nlog.WriteLog(Session["UserName"].ToString(),s);
        string str112 = "delete from e_handlingunit where handlingunitID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        msq.getmysqlcom(str112);
        databind(ViewState["queryString"].ToString());
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //sqlcon = new SqlConnection(strCon);
        NLogTest nlog = new NLogTest();
        string s = "修改了经办单位信息：" + GridView1.Rows[e.RowIndex].Cells[1].Text.ToString().Trim();
        nlog.WriteLog(Session["UserName"].ToString(),s);
        string str113 = "update e_handlingunit set address='"
            //+ ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim() + "',address='"
            + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim() + "',contactPerson='"
            + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim() + "',TEL='"
            + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim() + "' where handlingunitID='"          
            + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        msq.getmysqlcom(str113);
        GridView1.EditIndex = -1;
        databind(ViewState["queryString"].ToString());
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        databind(ViewState["queryString"].ToString());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //GridView1.Columns[4].Visible = false;
        GridView1.Columns[5].Visible = false;
        GridView1.Columns[6].Visible = false;
        GridView1.HeaderRow.Cells[5].Visible = false;
        //GridView1.BottomPagerRow.Visible = false;
        tableTitle ="经办单位信息";
        lyf_OutputToExcel.expExcle(this, divPrint, tableTitle);
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
                tcHeader[0].Text = "经办单位ID";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[1].Text = "经办单位名称";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[2].Text = "经办单位地址";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[3].Text = "联系人";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[4].Text = "联系方式";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[5].Attributes.Add("colspan", "2");
                tcHeader[5].Text = "操作";
                break;
        }

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        databind(ViewState["queryString"].ToString());
    }
}