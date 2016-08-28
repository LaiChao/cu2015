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
        if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
        {
            Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
            return;
        }
        if(!Page.IsPostBack)
        {
            putout.Visible = false;
            //DropDownList绑定数据
            DataSet ds2 = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), "select benfactorFrom from e_handlingunit order by handlingunitID");
            DataView dv2 = new DataView(ds2.Tables[0]);
            ddlBranchName.AppendDataBoundItems = true;
            ddlBranchName.DataSource = dv2;
            ddlBranchName.DataTextField = "benfactorFrom";
            ddlBranchName.DataBind();

            //GridView与DetailsView绑定数据
            ViewState["init"] = "select e_benfactor.benfactorID,e_benfactor.benfactorName,e_benfactor.benfactorFrom,benfactorType,case when benfactorType=1 then '公益组织' when benfactorType=2 then '单位' when benfactorType=3 then '个人' when benfactorType=4 then '募捐箱' when benfactorType=5 then '冠名慈善捐助金' end as donorType,TEL,bftRange,bftRemark,Contacts,email,sex,moneyboxNo,namingAge,deadline,namingSelected,recipientsType,recipientsDescription,ifnull(capitalEarn,0) as remain from e_benfactor left join e_capital on e_benfactor.benfactorID=e_capital.capitalID where 1=1 ";
            if (Session["userRole"].ToString()=="1")
            {//分会只能查看该分会的捐赠人
                Label1.Visible = false;
                ddlBranchName.Visible = false;
                ViewState["init"] = ViewState["init"].ToString() + "and e_benfactor.benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ";
            }
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
            if ((dcf.HeaderText == "使用范围") || (dcf.HeaderText == "备注") || (dcf.HeaderText == "联系人") || (dcf.HeaderText == "性别") || (dcf.HeaderText == "募捐箱编号") || (dcf.HeaderText == "冠名年限") || (dcf.HeaderText == "冠名到期日期") || (dcf.HeaderText == "冠名慈善捐助金") || (dcf.HeaderText == "受助人描述"))//前提条件是列名要与对应列的HeadText一致 (dcf.HeaderText == "受助人类型") || 
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
        if (Session["userRole"].ToString() == "1")
        {//分会
            queryString.Append("and e_benfactor.benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ");
        }
        if (ddlBranchName.Text != "所有机构")
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
            queryString.Append("and e_benfactor.benfactorName like '%" + tbName.Text.Trim() + "%' ");
        }
        if(tbTEL.Text.Trim() != "")
        {
            queryString.Append("and TEL='" + tbTEL.Text.Trim() + "' ");
        }
        if (tbRemain.Text.Trim() != "")
        {
            queryString.Append("and ifnull(capitalEarn,0)>=" + tbRemain.Text.Trim());
        }
        if(ddlDirect.SelectedValue.ToString()!="未指定")
        {
            if(ddlDirect.SelectedValue.ToString()=="非定向")
            {
                queryString.Append("and direction=0");
            }
            else
            {
                queryString.Append("and recipientsType='" + ddlDirect.SelectedValue.ToString() + "' ");
            }
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
    {//判断当前登录用户是否和该捐赠人属于同一机构
        if(Session["benfactorFrom"].ToString()!=GridView1.Rows[e.RowIndex].Cells[4].Text.Trim())
        {
            HttpContext.Current.Response.Write("<script>alert('不能删除其他机构的捐赠人');</script>");
            return;
        }
        //判断捐赠人是否有资金
        int countNum = 0;
        MySqlDataReader mysqlread = msq.getmysqlread("select count(*) as num from e_capital where capitalID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'");
        while (mysqlread.Read())
        {
            countNum = mysqlread.GetInt32("num");
        }
        if(countNum==0)
        {//没有资金
            string str112 = "delete from e_benfactor where benfactorID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
            NLogTest nlog = new NLogTest();
            string sss = "删除了捐赠人：" + ((HyperLink)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
            nlog.WriteLog(Session["UserName"].ToString(), sss);
            msq.getmysqlcom(str112);
            databind(ViewState["now"].ToString());
            //DetailsView1.Visible = false;

        }
        else
        {//有资金，不能删除
            HttpContext.Current.Response.Write("<script>alert('不能删除有资金（申请）的捐赠人');</script>");
        }

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
                if (Session["userRole"].ToString() == "3")//会长
                {
                    ((HyperLink)(e.Row.Cells[0].Controls[0])).Enabled = false;
                    ((HyperLink)(e.Row.Cells[0].Controls[0])).Attributes.Add("onclick", "javascript:return confirm('会长不能编辑捐赠人')");
                    ((LinkButton)e.Row.Cells[1].Controls[0]).Enabled = false;
                    ((LinkButton)e.Row.Cells[1].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('会长不能删除捐赠人')");
                }
                else
                    ((LinkButton)e.Row.Cells[1].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('确认要删除吗?')");
                //会长不能修改捐赠人信息

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
        GridView1.Columns[19].Visible = false;
        GridView1.Columns[20].Visible = false;
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
    #region 选择列导出
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
            GridView1.Columns[3].Visible = true;
        else
            GridView1.Columns[3].Visible = false;
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox2.Checked)
            GridView1.Columns[4].Visible = true;
        else
            GridView1.Columns[4].Visible = false;
    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox3.Checked)
            GridView1.Columns[5].Visible = true;
        else
            GridView1.Columns[5].Visible = false;
    }
    protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox4.Checked)
            GridView1.Columns[6].Visible = true;
        else
            GridView1.Columns[6].Visible = false;
    }
    protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox5.Checked)
            GridView1.Columns[7].Visible = true;
        else
            GridView1.Columns[7].Visible = false;
    }
    protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox6.Checked)
            GridView1.Columns[8].Visible = true;
        else
            GridView1.Columns[8].Visible = false;
    }
    protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox7.Checked)
            GridView1.Columns[9].Visible = true;
        else
            GridView1.Columns[9].Visible = false;
    }
    protected void CheckBox8_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox8.Checked)
            GridView1.Columns[10].Visible = true;
        else
            GridView1.Columns[10].Visible = false;
    }
    protected void CheckBox9_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox9.Checked)
            GridView1.Columns[11].Visible = true;
        else
            GridView1.Columns[11].Visible = false;
    }
    protected void CheckBox10_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox10.Checked)
            GridView1.Columns[12].Visible = true;
        else
            GridView1.Columns[12].Visible = false;
    }
    protected void CheckBox11_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox11.Checked)
            GridView1.Columns[13].Visible = true;
        else
            GridView1.Columns[13].Visible = false;
    }
    protected void CheckBox12_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox12.Checked)
            GridView1.Columns[14].Visible = true;
        else
            GridView1.Columns[14].Visible = false;
    }
    protected void CheckBox13_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox13.Checked)
            GridView1.Columns[15].Visible = true;
        else
            GridView1.Columns[15].Visible = false;
    }
    protected void CheckBox14_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox14.Checked)
            GridView1.Columns[16].Visible = true;
        else
            GridView1.Columns[16].Visible = false;
    }
    protected void CheckBox15_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox15.Checked)
            GridView1.Columns[17].Visible = true;
        else
            GridView1.Columns[17].Visible = false;
    }
    protected void CheckBox16_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox16.Checked)
            GridView1.Columns[18].Visible = true;
        else
            GridView1.Columns[18].Visible = false;
    }
    #endregion
    protected void btputout_Click(object sender, EventArgs e)
    {
        putout.Visible = true;
    }
}