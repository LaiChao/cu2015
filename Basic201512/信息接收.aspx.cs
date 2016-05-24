using System;
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

public partial class Basic201512_信息接收 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)//页面首次加载
        {
            StringBuilder queryString = new StringBuilder();
            queryString.Append("select * from e_info where 1=1 ");
            if(Session["UserName"].ToString()=="admin")
            {//管理员可以查看所有用户的全部信息
                ;
            }
            else
            {//只显示 接收到的信息、群发信息 和 当前用户已发送信息
                queryString.Append("and (infoTo='" + Session["benfactorFrom"].ToString() + "' or infoTo='" + Session["UserName"].ToString() + "' or infoTo='所有机构' or infoFrom='" + Session["UserName"].ToString() + "') ");
                //"select * from e_info where infoTo='" + Session["UserName"].ToString() + "' or infoTo='所有机构' or infoFrom='" + Session["UserName"].ToString() + "' order by infoDATE DESC";
            }
            ViewState["init"] = queryString.ToString();
            ViewState["now"] = ViewState["init"].ToString() + "and infoRead='未读' ";
            databind(ViewState["now"].ToString());
        }
    }
    public void databind(string s)
    {

        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), s);
        DataView dv = new DataView(ds.Tables [0]);
        GridView1.DataSource = dv;
        GridView1.DataKeyNames = new string[] { "infoID" };//主键
        GridView1.DataBind();
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
                    ((LinkButton)e.Row.Cells[4].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('确认要删除吗?')");
            }
        }
        for(int i=0;i<count;i++)
        {
                ID = GridView1.DataKeys[i].Value.ToString();
                //GridView1.Rows[i].Attributes.Add("onclick", "window.open('信息修改.aspx?ID=" + ID + "','信息修改','')");
                //((HyperLink)GridView1.Rows[i].Cells[0].Controls[0]).Attributes.Add("onclick", "window.showModalDialog('信息查看.aspx?ID=" + ID + "','信息查看','toolbar=yes,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=600,height=300')");
                if (Session["UserName"].ToString() != GridView1.Rows[i].Cells[2].Text.ToString())
                {
                    //HttpContext.Current.Response.Write("<script>alert('只有寄件人可以编辑信息');</script>");
                    continue;
                }
                ((HyperLink)GridView1.Rows[i].Cells[5].Controls[0]).Attributes.Add("onclick", "window.showModalDialog('信息修改.aspx?ID=" + ID + "','信息修改','toolbar=yes,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=300')");
        }
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    str111 = "select * from e_info order by infoDATE DESC";

    //}
    //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    GridView1.EditIndex = -1;

    //}
    //删除信息
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Session["UserName"].ToString() != GridView1.Rows[e.RowIndex].Cells[2].Text.ToString() && Session["UserName"].ToString()!="admin")
        {
            HttpContext.Current.Response.Write("<script>alert('只有寄件人和管理员可以删除信息');</script>");
            return;
        }
        NLogTest nlog = new NLogTest();
        string sss = "删除了信息：" + ((HyperLink)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text.ToString();
        nlog.WriteLog(Session["UserName"].ToString(),sss);
        //删除服务器里的附件
        //读取附件列表并删除附件
        string str113 = string.Format("select infoFile from e_info where infoID='{0}'", GridView1.DataKeys[e.RowIndex].Value.ToString());
        mysqlconn msq11 = new mysqlconn();
        MySqlDataReader mysqlread = msq11.getmysqlread(str113);
        string Files = "";
        string[] arrFiles;
        while (mysqlread.Read())
        {
            Files = mysqlread.GetString(0);
        }
        arrFiles = Files.Split('|');
        foreach(string s in arrFiles)
        {
            DeleteFile(s);
        }
        //删除记录
        string str112 = "delete from e_info where infoID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        msq.getmysqlcom(str112);
        databind(ViewState["now"].ToString());
    }
    //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    string str113 = "update e_info set infoTitle='"
    //        + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim() + "',infoContent='"
    //        + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim() + "',infoDATE='"
    //        + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim() + "' where infoID='"
    //        + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
    //    msq.getmysqlcom(str113);
    //    GridView1.EditIndex = -1;

    //}
    //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    GridView1.EditIndex = e.NewEditIndex;

    //}

    //翻页
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        databind(ViewState["now"].ToString());
    }
    // 删除文件类
    public void DeleteFile(string FullFileName)
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
                tcHeader[0].Text = "标题";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[1].Text = "时间";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[2].Text = "发件人";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[3].Text = "收件人";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[4].Attributes.Add("colspan", "2");
                tcHeader[4].Text = "操作";
                break;
        }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlType.SelectedValue=="未读信息")
        {
            ViewState["now"] = ViewState["init"].ToString() + "and infoRead='未读' ";
            databind(ViewState["now"].ToString());
        }
        if(ddlType.SelectedValue=="全部信息")
        {
            ViewState["now"] = ViewState["init"].ToString();
            databind(ViewState["now"].ToString());
        }
        if(ddlType.SelectedValue=="收件箱")
        {
            string strmailbox = ViewState["now"].ToString() + "and (infoTo='" + Session["benfactorFrom"].ToString() + "' or infoTo='" + Session["UserName"].ToString() + "') ";
            databind(strmailbox);
        }
        if(ddlType.SelectedValue=="发件箱")
        {
            string strmailSent = ViewState["now"].ToString() + "and infoFrom='" + Session["UserName"].ToString() + "' ";
            databind(strmailSent);
        }
        if(ddlType.SelectedValue=="群发信息")
        {
            string strgroupSent = ViewState["now"].ToString() + "and infoTo='所有机构'";
            databind(strgroupSent);
        }
    }
}