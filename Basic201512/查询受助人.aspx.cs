﻿using System;
using System.Collections;
using System.Collections.Specialized;
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

public partial class Basic201512_查询受助人 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();
    //string str111 = "select * from e_recipients order by recipientsID DESC";
    mysqlconn msq2 = new mysqlconn();
    string str222 = "select benfactorFrom from e_handlingunit order by handlingunitID";
    public static string tableTitle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)//页面首次加载
        {
            ViewState["init"] = "select *, date_format(from_days(to_days(now())-to_days(SUBSTRING(recipientsPIdcard,7,8))),'%Y')+0 as newAge,concat(if(isstu=1,' 助学',''),if(isdoc=1,' 助医',''),if(iscan=1,' 助残',''),if(isold=1,' 助老',''),if(iskun=1,' 助困',''),if(isyong=1,' 双拥',''),if(isdst=1,' 重特大灾难','')) as leibie from e_recipients ";
            //ViewState["Query"] = str111;
            if (Session["userRole"].ToString() == "1")//分会权限
            {
                Label3.Visible = false;
                benfactorFrom.Visible = false;
                ViewState["init"] = ViewState["init"].ToString() + "where benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ";
            }
            ViewState["init"] = ViewState["init"].ToString() + "order by recipientsID DESC ";
            ViewState["now"] = ViewState["init"];
            databind(ViewState["init"].ToString());
            
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void databind(string s)
    {
        DataSet ds2 = MySqlHelper.ExecuteDataset(msq2.getmysqlcon(), str222);
        DataView dv2 = new DataView(ds2.Tables[0]);
        benfactorFrom.AppendDataBoundItems = true;
        benfactorFrom.DataSource = dv2;
        benfactorFrom.DataTextField = "benfactorFrom";
        benfactorFrom.DataBind();

        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), s);
        DataView dv = new DataView(ds.Tables[0]);
        GridView1.DataSource = dv;
        GridView1.DataKeyNames = new string[] { "recipientsID" };//主键
        GridView1.DataBind();
    }
    protected void btnQuery2_Click(object sender, EventArgs e)
    {
        int flag2 = -1;
        StringBuilder queryString2 = new StringBuilder();
        queryString2.Append("select newtable.* from (select *, date_format(from_days(to_days(now())-to_days(SUBSTRING(recipientsPIdcard,7,8))),'%Y')+0 as newAge,concat(if(isstu=1,' 助学',''),if(isdoc=1,' 助医',''),if(iscan=1,' 助残',''),if(isold=1,' 助老',''),if(iskun=1,' 助困',''),if(isyong=1,' 双拥',''),if(isdst=1,' 重特大灾难','')) as leibie from e_recipients) newtable where 1=1 ");
        if (Session["userRole"].ToString() == "1")//分会权限
        {
            queryString2.Append("and benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ");
        }
        if (txtID.Text.Trim() != "")
        {
            flag2 = 1;
            queryString2.Append("and recipientsID in (select distinct recipientID from e_pr where projectID='" + txtID.Text.Trim() + "') ");
        }
        if(flag2==1)
        {
            if(txtName.Text.Trim()!="")
            {
                queryString2.Append("or ");
            }
        }
        else
        {
            if (txtName.Text.Trim() != "")
            {
                queryString2.Append("and ");
            }
        }
        if(txtName.Text.Trim() != "")
        {//recipientsID in (select distinct recipientID from e_pr where projectID in (select projectID from e_project where projectName='导出测试'))
            queryString2.Append("recipientsID in (select distinct recipientID from e_pr where projectID in (select projectID from e_project where projectName like '%" + txtName.Text.Trim() + "%')) ");
        }
        //queryString2.Append("order by recipientsID DESC");
        ViewState["Query"] = queryString2.ToString();
        ViewState["now"] = ViewState["Query"];
        databind(ViewState["Query"].ToString());

    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        StringBuilder queryString = new StringBuilder();
        //        queryString.Append("select *, date_format(from_days(to_days(now())-to_days(SUBSTRING(recipientsPIdcard,7,8))),'%Y')+0 as newAge,concat(if(isstu=1,' 助学',''),if(isdoc=1,' 助医',''),if(iscan=1,' 助残',''),if(isold=1,' 助老',''),if(iskun=1,' 助困',''),if(isyong=1,' 双拥',''),if(isdst=1,' 重特大灾难','')) as leibie from e_recipients where 1=1 ");
        queryString.Append("select newtable.* from (select *, date_format(from_days(to_days(now())-to_days(SUBSTRING(recipientsPIdcard,7,8))),'%Y')+0 as newAge,concat(if(isstu=1,' 助学',''),if(isdoc=1,' 助医',''),if(iscan=1,' 助残',''),if(isold=1,' 助老',''),if(iskun=1,' 助困',''),if(isyong=1,' 双拥',''),if(isdst=1,' 重特大灾难','')) as leibie from e_recipients) newtable where 1=1 ");
        if (Session["userRole"].ToString() == "1")//分会权限
        {
            queryString.Append("and benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ");
        }

        if (benfactorFrom.Text != "所有机构")
            queryString.Append("and benfactorFrom='" + benfactorFrom.Text.ToString() + "' ");
        if (TextBoxName.Text != "")
            queryString.Append("and recipientsName='" + TextBoxName.Text.ToString() + "' ");
        if (sex.Text != "未指定")
            queryString.Append("and sex='" + sex.Text.ToString() + "' ");
        if (age.Text != "")
            queryString.Append("and newAge=" + age.Text.ToString() + " ");
        if (reason.Text != "未指定")
            queryString.Append("and reason='" + reason.Text.ToString() + "' ");
        if (DropDownList1.Text !="未指定")
        {
            if (DropDownList1.Text == "助学")
            {
                queryString.Append("and isstu=1 ");
            }
            else if (DropDownList1.Text == "助医")
            {
                queryString.Append("and isdoc=1 ");
            }
            else if (DropDownList1.Text == "助老")
            {
                queryString.Append("and isold=1 ");
            }
            else if (DropDownList1.Text == "助残")
            {
                queryString.Append("and iscan=1 ");
            }
            else if (DropDownList1.Text == "助困")
            {
                queryString.Append("and iskun=1 ");
            }
            else if (DropDownList1.Text == "双拥")
            {
                queryString.Append("and isyong=1 ");
            }
            else if (DropDownList1.Text == "重特大灾害")
            {
                queryString.Append("and isdst=1 ");
            }
        }
        queryString.Append("order by recipientsID DESC");

        //ViewState["Query"] = "select *, date_format(from_days(to_days(now())-to_days(SUBSTRING(recipientsPIdcard,7,8))),'%Y')+0 as newAge,concat(if(isstu=1,' 助学',''),if(isdoc=1,' 助医',''),if(iscan=1,' 助残',''),if(isold=1,' 助老',''),if(iskun=1,' 助困',''),if(isyong=1,' 双拥',''),if(isdst=1,' 重特大灾难','')) as leibie from e_recipients" + temp + temp2 + "order by recipientsID DESC";
        ViewState["Query"] = queryString.ToString();
        ViewState["now"] = ViewState["Query"];
        databind(ViewState["Query"].ToString());
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int count = GridView1.Rows.Count;
        string ID = "";
        //如果是绑定数据行 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //鼠标经过时，行背景色变 
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
            //鼠标移出时，行背景色变 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[10].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('确认要删除吗?')");
            }
            e.Row.Cells[7].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
        }
        for (int i = 0; i < count; i++)
        {
            ID = GridView1.DataKeys[i].Value.ToString();
            ((HyperLink)GridView1.Rows[i].Cells[1].Controls[0]).Attributes.Add("onclick", "window.showModalDialog('查看受助人信息.aspx?ID=" + ID + "','查看受助人信息','toolbar=yes,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600')");
            //((HyperLink)GridView1.Rows[i].Cells[9].Controls[0]).Attributes.Add("onclick", "window.showModalDialog('修改受助人信息.aspx?ID=" + ID + "','修改受助人信息','toolbar=yes,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600')");
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        databind(ViewState["now"].ToString());
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NLogTest nlog = new NLogTest();
        string sss = "删除了受助人：" + ((HyperLink)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString();
        nlog.WriteLog(Session["UserName"].ToString(),sss);
        //删除记录
        string str112 = "delete from e_recipients where recipientsID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        msq.getmysqlcom(str112);
        databind(ViewState["now"].ToString());
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //switch (e.Row.RowType)
        //{
        //    case DataControlRowType.Header:
        //        //第一行表头
        //        TableCellCollection tcHeader = e.Row.Cells;
        //        tcHeader.Clear();
        //        tcHeader.Add(new TableHeaderCell());
        //        tcHeader[0].Text = "受助人来源";
        //        tcHeader.Add(new TableHeaderCell());
        //        tcHeader[1].Text = "姓名";
        //        tcHeader.Add(new TableHeaderCell());
        //        tcHeader[2].Text = "性别";
        //        tcHeader.Add(new TableHeaderCell());
        //        tcHeader[3].Text = "年龄";
        //        tcHeader.Add(new TableHeaderCell());
        //        tcHeader[4].Text = "致困原因";
        //        tcHeader.Add(new TableHeaderCell());
        //        tcHeader[5].Text = "受助类别";
        //        tcHeader.Add(new TableHeaderCell());
        //        tcHeader[6].Text = "联系电话";
        //        tcHeader.Add(new TableHeaderCell());
        //        tcHeader[7].Text = "身份证号";
        //        tcHeader.Add(new TableHeaderCell());
        //        tcHeader[8].Text = "低保低收入号";
        //        tcHeader.Add(new TableHeaderCell());
        //        tcHeader[9].Attributes.Add("colspan", "2");
        //        tcHeader[9].Text = "操作";

        //        break;
        //}
    }
    protected void btnExp_Click(object sender, EventArgs e)
    {
        GridView1.Columns[9].Visible = false;
        GridView1.Columns[10].Visible = false;
        GridView1.HeaderStyle.BackColor = Color.White;
        GridView1.HeaderStyle.ForeColor = Color.Blue;
        GridView1.HeaderRow.Cells[9].Visible = false;
        GridView1.BottomPagerRow.Visible = false;
        tableTitle = "受助人信息" + DateTime.Now.ToShortDateString().ToString();
        lyf_OutputToExcel.expExcle(this, divPrint, tableTitle);
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
            GridView1.Columns[0].Visible = true;
        else
            GridView1.Columns[0].Visible = false;
    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox3.Checked)
            GridView1.Columns[2].Visible = true;
        else
            GridView1.Columns[2].Visible = false;
    }
    protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox4.Checked)
            GridView1.Columns[3].Visible = true;
        else
            GridView1.Columns[3].Visible = false;
    }
    protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox5.Checked)
            GridView1.Columns[4].Visible = true;
        else
            GridView1.Columns[4].Visible = false;
    }
    protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox6.Checked)
            GridView1.Columns[5].Visible = true;
        else
            GridView1.Columns[5].Visible = false;
    }
    protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox7.Checked)
            GridView1.Columns[6].Visible = true;
        else
            GridView1.Columns[6].Visible = false;
    }
    protected void CheckBox8_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox8.Checked)
            GridView1.Columns[7].Visible = true;
        else
            GridView1.Columns[7].Visible = false;
    }
    protected void CheckBox9_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox9.Checked)
            GridView1.Columns[8].Visible = true;
        else
            GridView1.Columns[8].Visible = false;
    }
}