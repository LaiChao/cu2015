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

public partial class Basic201512_捐赠人信息管理 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();
    public static string tableTitle = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            //DropDownList绑定数据
            DataSet ds2 = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), "select benfactorFrom from e_handlingunit order by handlingunitID");
            DataView dv2 = new DataView(ds2.Tables[0]);
            ddlBranchName.AppendDataBoundItems = true;
            ddlBranchName.DataSource = dv2;
            ddlBranchName.DataTextField = "benfactorFrom";
            ddlBranchName.DataBind();

            //GridView与DetailsView绑定数据
            ViewState["init"] = "select e_benfactor.benfactorID,e_benfactor.benfactorName,e_benfactor.benfactorFrom,benfactorType,case when benfactorType=1 then '公益组织' when benfactorType=2 then '单位' when benfactorType=3 then '个人' when benfactorType=4 then '募捐箱' when benfactorType=5 then '冠名慈善捐助金' end as donorType,TEL,bftRange,bftRemark,Contacts,email,sex,moneyboxNo,namingAge,deadline,namingSelected,recipientsType,recipientsDescription,ifnull(capitalEarn,0) as remain from e_benfactor left join e_capital on e_benfactor.benfactorID=e_capital.capitalID where 1=1 ";
            ViewState["now"] = ViewState["init"];
            databind(ViewState["now"].ToString());

            mask();

            //DetailsView1.Visible = false;
        }
    }
    protected void mask()
    {
        //不显示全部扩展信息
        foreach (DataControlField dcf in GridView1.Columns)
        {
            if ((dcf.HeaderText == "使用范围") || (dcf.HeaderText == "备注") || (dcf.HeaderText == "联系人") || (dcf.HeaderText == "性别") || (dcf.HeaderText == "募捐箱编号") || (dcf.HeaderText == "冠名年限") || (dcf.HeaderText == "冠名到期日期") || (dcf.HeaderText == "选择的冠名慈善捐助金") || (dcf.HeaderText == "受助人类型") || (dcf.HeaderText == "受助人描述"))//前提条件是列名要与对应列的HeadText一致
            {
                dcf.Visible = false;
            }
        }
    }
    public void databind(string s)
    {
        //GridView与DetailsView绑定数据
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), s);
        DataView dv = new DataView(ds.Tables[0]);
        //GridView绑定数据
        GridView1.DataSource = dv;
        GridView1.DataKeyNames = new string[] { "benfactorID" };//主键
        GridView1.DataBind();
        //DetailsView绑定数据
        //DetailsView1.DataSource = dv;
        //DetailsView1.DataKeyNames = new string[] { "benfactorID" };
        //DetailsView1.DataBind();

    }
    //protected void btnReload_Click(object sender, EventArgs e)
    //{
    //    databind(ViewState["now"].ToString());
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {//按条件查询捐赠人
        StringBuilder queryString = new StringBuilder();
        queryString.Append("select e_benfactor.benfactorID,e_benfactor.benfactorName,e_benfactor.benfactorFrom,benfactorType,case when benfactorType=1 then '公益组织' when benfactorType=2 then '单位' when benfactorType=3 then '个人' when benfactorType=4 then '募捐箱' when benfactorType=5 then '冠名慈善捐助金' end as donorType,TEL,bftRange,bftRemark,Contacts,email,sex,moneyboxNo,namingAge,deadline,namingSelected,recipientsType,recipientsDescription,ifnull(capitalEarn,0) as remain from e_benfactor left join e_capital on e_benfactor.benfactorID=e_capital.capitalID where 1=1 ");
        if(ddlBranchName.Text != "所有机构")
        {
            queryString.Append("and e_benfactor.benfactorFrom='" + ddlBranchName.Text.ToString() + "' ");
        }
        mask();
        if(ddlBenfactorType.SelectedValue != "0")
        {
            queryString.Append("and benfactorType=" + ddlBenfactorType.SelectedValue.ToString() + " ");
            //不同类型的捐赠人显示的扩展信息不同
            if ((ddlBenfactorType.SelectedValue == "1") || (ddlBenfactorType.SelectedValue == "2"))
            {
                foreach (DataControlField dcf in GridView1.Columns)//公益组织和单位
                {
                    if ((dcf.HeaderText == "联系人")  || (dcf.HeaderText == "选择的冠名慈善捐助金") || (dcf.HeaderText == "受助人类型") || (dcf.HeaderText == "受助人描述"))//前提条件是列名要与对应列的HeadText一致
                    {
                        dcf.Visible = true;
                    }
                }
            }
            if (ddlBenfactorType.SelectedValue == "3")//个人
            {
                foreach (DataControlField dcf in GridView1.Columns)
                {
                    if ((dcf.HeaderText == "性别") || (dcf.HeaderText == "选择的冠名慈善捐助金") || (dcf.HeaderText == "受助人类型") || (dcf.HeaderText == "受助人描述"))//前提条件是列名要与对应列的HeadText一致
                    {
                        dcf.Visible = true;
                    }
                }
            }
            if (ddlBenfactorType.SelectedValue == "4")//募捐箱
            {
                foreach (DataControlField dcf in GridView1.Columns)
                {
                    if ((dcf.HeaderText == "联系人")|| (dcf.HeaderText == "募捐箱编号") || (dcf.HeaderText == "选择的冠名慈善捐助金") || (dcf.HeaderText == "受助人类型") || (dcf.HeaderText == "受助人描述"))//前提条件是列名要与对应列的HeadText一致
                    {
                        dcf.Visible = true;
                    }
                }
            }
            if (ddlBenfactorType.SelectedValue == "5")
            {
                foreach (DataControlField dcf in GridView1.Columns)
                {
                    if ((dcf.HeaderText == "使用范围") || (dcf.HeaderText == "备注") || (dcf.HeaderText == "联系人") || (dcf.HeaderText == "冠名年限") || (dcf.HeaderText == "冠名到期日期") )//前提条件是列名要与对应列的HeadText一致
                    {
                        dcf.Visible = true;
                    }
                }
            }
        }
        if(tbID.Text.Trim() != "")
        {
            queryString.Append("and e_benfactor.benfactorID='" + tbID.Text.Trim() + "' ");
        }
        if(tbName.Text.Trim() != "")
        {
            queryString.Append("and e_benfactor.benfactorName='" + tbName.Text.Trim() + "' ");
        }
        if(tbTEL.Text.Trim() != "")
        {
            queryString.Append("and TEL='" + tbTEL.Text.Trim() + "' ");
        }
        if (tbRemain.Text.Trim() != "")
        {
            queryString.Append("and ifnull(capitalEarn,0)>=" + tbRemain.Text.Trim());
        }
        ViewState["now"] = ViewState["query"] = queryString.ToString();
        databind(ViewState["now"].ToString());
        //DetailsView1.Visible = false;
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        databind(ViewState["now"].ToString());
        //DetailsView1.Visible = false;
    }
    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    //{//查看捐赠人信息
    //    //GridView与DetailsView的联动
    //    //DetailsView1.PageIndex = GridView1.SelectedIndex;
    //    databind(ViewState["now"].ToString());
    //    //DetailsView1.Visible = true;
    //}
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string str112 = "delete from e_benfactor where benfactorID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        msq.getmysqlcom(str112);
        databind(ViewState["now"].ToString());
        //DetailsView1.Visible = false;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int count = GridView1.Rows.Count;
        //如果是绑定数据行 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //鼠标经过时，行背景色变 
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
            //鼠标移出时，行背景色变 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[1].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('确认要删除吗?')");
            }
        }
        //for (int i = 0; i < count; i++)
        //{
        //    ((HyperLink)GridView1.Rows[i].Cells[0].Controls[0]).Attributes.Add("onclick", "window.showModalDialog('修改捐赠人信息.aspx?ID=" + GridView1.DataKeys[i].Value.ToString() + "','修改捐赠人信息','toolbar=yes,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600')");
        //}
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.Header:
                TableCellCollection tcHeader = e.Row.Cells;
                tcHeader.RemoveAt(0);
                tcHeader.RemoveAt(1);
                tcHeader[0].Attributes.Add("colspan", "2");
                tcHeader[0].Text = "操作";
                break;
        }
    }


    //protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    //{
    //    //DetailsView分页
    //    DetailsView1.PageIndex = e.NewPageIndex;
    //    databind(ViewState["now"].ToString());
    //}

    //protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    //{
    //        DetailsView1.ChangeMode(e.NewMode);
    //        databind(ViewState["now"].ToString());
    //        DetailsView1.Visible = true;
    //}
    //protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    //{
    //    for (int i = 0; i < e.NewValues.Count; i++)
    //    {
    //        if (e.NewValues[i] != null)
    //        {
    //            e.NewValues[i] = Server.HtmlEncode(e.NewValues[i].ToString());
    //        }
    //    } 
    //}
    //protected void DetailsView1_DataBound(object sender, EventArgs e)
    //{
    //    string strnull = "";
    //    if(DetailsView1.Rows.Count>0)
    //    {
    //        for (int i = 0; i < DetailsView1.Rows.Count; i++)
    //        {
    //            strnull = DetailsView1.Rows[i].Cells[1].Text.Trim();
    //            if (strnull == "" || strnull == "0" || strnull == "&nbsp;")
    //            {//空数据不显示
    //                DetailsView1.Rows[i].Visible = false;
    //            }
    //        }
    //    }

    //}
    protected void btnExp_Click(object sender, EventArgs e)
    {
        GridView1.Columns[0].Visible = false;
        GridView1.Columns[1].Visible = false;
        GridView1.HeaderStyle.BackColor = Color.White;
        GridView1.HeaderStyle.ForeColor = Color.Blue;
        GridView1.HeaderRow.Cells[0].Visible = false;
        GridView1.BottomPagerRow.Visible = false;

        tableTitle = "捐赠人信息" + DateTime.Now.ToShortDateString().ToString();
        lyf_OutputToExcel.expExcle(this, divOut, tableTitle);
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    } 
}