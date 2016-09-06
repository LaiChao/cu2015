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
using System.Text;

public partial class Basic201512_受助人 : System.Web.UI.Page
{
    mysqlconn msq=new mysqlconn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
        {
            Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
            return;
        }
        if (!Page.IsPostBack)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.Append("select *,concat(if(benfactorType=1,'公益组织',''),if(benfactorType=2,'单位',''),if(benfactorType=3,'个人 ',''),if(benfactorType=4,'募捐箱',''),if(benfactorType=5,'冠名捐助金','')) as sbenfactorType,concat(if(naming=1,'是',''),if(naming=0,'否','')) as snaming,concat(if(direction=1,'是',''),if(direction=0,'否','')) as sdirection from e_benfactor where 1=1 ");
            if (Session["benfactorFrom"].ToString() != "北京市朝阳区慈善协会捐助科")
            {
                Button1.Visible = false;//待确认金额按钮不显示
            }
            if (Session["userRole"].ToString() == "1")//分会权限
            {
                queryString.Append("and benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ");
            }
            ViewState["now"] = queryString.ToString();
            databind();
        }
    }

    protected void databind()
    {
        //绑定数据
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), ViewState["now"].ToString());
        DataView dv = new DataView(ds.Tables[0]);
        dgData.DataSource = dv;
        dgData.DataBind();
    }

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// 设计器支持所需的方法 - 不要使用代码编辑器修改
    /// 此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
        this.dgData.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgData_ItemDataBound);
    }
    #endregion

    private void dgData_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        Session["tablename"] = benfactorType.SelectedValue;       
        switch (e.Item.ItemType)
        {
            case ListItemType.AlternatingItem:
            case ListItemType.Item:
                {
                    e.Item.Attributes.Add

                        ("onmouseover", "this.style.backgroundColor='#E6F5FA'");
                    e.Item.Attributes.Add

                        ("onmouseout", "this.style.backgroundColor='white'");
                    break;
                }
            case ListItemType.EditItem:
                {
                    break;
                }
        }
    }

    protected void Btselect_Click(object sender, EventArgs e)
    {//搜索按钮
        dgData1.Visible = false;
        dgData.Visible = true;

        StringBuilder queryString = new StringBuilder();
        queryString.Append("select *,concat(if(benfactorType=1,'公益组织',''),if(benfactorType=2,'单位',''),if(benfactorType=3,'个人 ',''),if(benfactorType=4,'募捐箱',''),if(benfactorType=5,'冠名捐助金','')) as sbenfactorType,concat(if(naming=1,'是',''),if(naming=0,'否','')) as snaming,concat(if(direction=1,'是',''),if(direction=0,'否','')) as sdirection from e_benfactor where 1=1 ");
        if (benfactorType.SelectedValue != "0")
        {
            if (benfactorType.SelectedValue == "1")
            {
                queryString.Append("and benfactorType=1 ");
            }
            if (benfactorType.SelectedValue == "2")
            {
                queryString.Append("and benfactorType=2 ");
            }
            if (benfactorType.SelectedValue == "3")
            {
                queryString.Append("and benfactorType=3 ");
            }
            if (benfactorType.SelectedValue == "4")
            {
                queryString.Append("and benfactorType=4 ");
            }
            if (benfactorType.SelectedValue == "5")
            {
                queryString.Append("and benfactorType=5 ");
            }
        }
        if (TbselectName.Text.Trim() != "")
            queryString.Append("and benfactorName like '%" + TbselectName.Text.ToString() + "%' ");
        if (TbselectID.Text.Trim() != "")
            queryString.Append("and TEL='" + TbselectID.Text.ToString() + "' ");
        //string str = string.Format("select * from {0} where benfactorName='{2}'or telphoneADD='{1}'", benfactorType.SelectedValue, TbselectID.Text, TbselectName.Text);
        if (Session["userRole"].ToString() == "1")//分会权限
        {
            queryString.Append("and benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ");
        }
        ViewState["now"] = queryString.ToString();
        dgData.CurrentPageIndex = 0;
        databind();
    }

    #region "显示待确认金额"
    protected void Button1_Click(object sender, EventArgs e)
    {
        confirmRoad();
    }

    protected void confirmRoad()//显示全部待确认金额
    {
        dgData.Visible = false;
        dgData1.Visible = true;

        string str = "select * from e_benfactor,e_capital where state=0 and e_benfactor.benfactorID=e_capital.benfactorID";
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), str);
        DataView dv = new DataView(ds.Tables[0]);
        dgData1.DataSource = dv;
        dgData1.DataBind();
 
    }
    #endregion

    //protected void dgData1_ItemCommand(object source, DataGridCommandEventArgs e)
    //{
    //    if(e.CommandName=="confirm")
    //    {
    //        string capitalID = ((Label)e.Item.FindControl("capitalID")).Text.Trim();
    //        double capitalEarn = Convert.ToDouble(((Label)e.Item.FindControl("capitalEarn")).Text.Trim()) + Convert.ToDouble(((Label)e.Item.FindControl("capitalIn")).Text.Trim());
    //        string updateString = string.Format("update e_capital set capitalEarn={1},capitalIn=0,state=1 where capitalID='{0}'", capitalID, capitalEarn);
    //        int result = msq.getmysqlcom(updateString);
    //        if (result > 0)
    //        {
    //            HttpContext.Current.Response.Write("<script>alert('金额确认成功');</script>");
    //            confirmRoad();
    //        }
    //    }
    //}
    //protected void dgData1_ItemDataBound(object sender, DataGridItemEventArgs e)
    //{
    //    if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
    //    {
    //        ((LinkButton)(e.Item.Cells[6].Controls[0])).Attributes.Add("onclick", "return confirm('确认该资金吗?');");
    //    }
    //}
    protected void dgData_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgData.CurrentPageIndex = e.NewPageIndex;
        databind();
    }
}