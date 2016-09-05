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

public partial class Basic201512_受助人 : System.Web.UI.Page
{
    mysqlconn msq=new mysqlconn();
    //string str111 = string.Format("select *,datediff(prodatatimeshen,prodatatime) as keshispend,datediff(prodatatimeshen1,prodatatimeshen) huizhangspend,datediff(prodatatimefinsh,prodatatimeshen1) zhixingspend,datediff(prodatatimeguid,prodatatimefinsh) jiexiangspend from e_project where 1=1 ");

    protected const string bandtime = "prodatatime";//项目申请时间
    protected const string bandtimeshen = "prodatatimeshen";//科室审批时间
    protected const string bandtimeshen1 = "prodatatimeshen1";//会长审批时间
    protected const string bandtimefinsh = "prodatatimefinsh";//结项时间
    public static string tableTitle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
        {
            Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
            return;
        }
        if (!Page.IsPostBack)
        {
            ViewState["init"] = string.Format("select *,datediff(prodatatimeshen,prodatatime) as keshispend,datediff(prodatatimeshen1,prodatatimeshen) huizhangspend,datediff(prodatatimefinsh,prodatatimeshen1) zhixingspend,datediff(prodatatimeguid,prodatatimefinsh) jiexiangspend from e_project where 1=1 ");
            ViewState["now"] = ViewState["init"].ToString();

            //绑定下拉框
            string strhand = string.Format("select benfactorFrom from e_handlingunit");
            DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),strhand);
            DataView dv = new DataView(ds.Tables[0]);
            dpdhand.DataSource = ds;
            dpdhand.DataTextField = "benfactorFrom";
            dpdhand.DataBind();

            dpdhand.SelectedValue = Session["benfactorFrom"].ToString();
            if (Session["userRole"].ToString() == "1")//分会不能查看其它经办单位
                dpdhand.Enabled = false;

            //绑定datagrid
            //判断是否从受助人信息管理页面跳转过来
            if(Request.QueryString.Count>0)
            {//and projectID in (select projectID from e_pr where recipientID=4247);
                ViewState["init"] = ViewState["init"].ToString() + "and projectID in (select projectID from e_pr where recipientID=" + Request["id"].Trim() + ") ";
                ViewState["now"] = ViewState["init"].ToString();
            }
            databind();
        }
    }

    public void databind()
    {
        //绑定datagrid
        //   string proID = Session["proID"].ToString();
        // string strplancap = LbproID.Text;
        // Lbearn.Text=strplancap;
        //string strproID = string.Format("SELECT *,datediff(prodatatimeshen,prodatatime) as keshispend,datediff(prodatatimeshen1,prodatatimeshen) huizhangspend,datediff(prodatatimeguid,prodatatimeshen1) zhixingspend,datediff(prodatatimefinsh,prodatatimeguid) jiexiangspend FROM  e_project where projectID='{0}' or projectName='{1}'", TbselectID.Text, TbselectName.Text);
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), ViewState["now"].ToString());
        DataView dv = new DataView(ds.Tables[0]);
        dgData.DataSource = dv;
        dgData.DataBind();
    }
	 public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
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


        this.dgData.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData_EditCommand);
        this.dgData.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData_UpdateCommand);
        this.dgData.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData_CancelCommand);
        this.dgData.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgData_ItemDataBound);
        //this.dgData.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData_DeleteCommand);
        //this.dgData.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgData_ItemDataBound);
        //this.dgHeader.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgHeader_ItemCommand);

    }
    #endregion
    #region "页面操作"


    private void dgData_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        dgData.EditItemIndex = -1;
        databind();
    }

    //private void dgData_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    //{


    //}

    private void dgData_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {

        dgData.EditItemIndex = e.Item.ItemIndex;
        databind();
    }

    private void dgData_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        string strupdata = string.Format("update e_project set projectID='{0}',projectName='{1}',benfactorFrom='{2}',telphoneName='{3}',telphoneADD='{4}',projectDir='{5}' where projectID='{0}'",
            ((TextBox)e.Item.FindControl("txtEditID")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtEditName")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtEditOrder")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtteladdname")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtteladd")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtdes")).Text.Trim());
            msq.getmysqlcom(strupdata);
            dgData.EditItemIndex = -1;
            databind();       
    }

    private void dgData_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        //Label lbl = e.Item.FindControl("labID") as Label;
        //lbl.Text = dgData.DataMember[0].ToString();
        switch (e.Item.ItemType)
        {
            case ListItemType.AlternatingItem:
            case ListItemType.Item:
                {
                    e.Item.Attributes.Add

                        ("onmouseover", "this.style.backgroundColor='Silver'");
                    e.Item.Attributes.Add

                        ("onmouseout", "this.style.backgroundColor='white'");

                    // ImageButton btn = (ImageButton)e.Item.FindControl("btnDelete");
                    // btn.Attributes.Add("onclick", "return confirm('删除数据可能导致严重的后果，你是否确定删除?');");
                    break;
                }


            case ListItemType.EditItem:
                {
                    break;
                }
        }
    }
    #endregion 

   
    protected void Btselect_Click(object sender, EventArgs e)
    {
        StringBuilder queryString = new StringBuilder();
        queryString.Append(ViewState["init"].ToString());
        if (TbselectID.Text.Trim() != "")
            queryString.Append("and projectID='" + TbselectID.Text.Trim() + "' ");
        if (TbselectName.Text.Trim() != "")
            queryString.Append("and projectName like '%" + TbselectName.Text.Trim() + "%' ");
        queryString.Append("and benfactorFrom='" + dpdhand.Text.Trim() + "' ");
        //string str = string.Format("select * from e_project where projectID='{0}'or projectName='{1}' or benfactorFrom='{2}'", TbselectID.Text, TbselectName.Text,dpdhand.Text);
        ViewState["now"] = queryString.ToString();
        dgData.CurrentPageIndex = 0;
        databind();
        
    }

    protected void btoutexl_Click(object sender, EventArgs e)
    {
        //dgData.Columns[0].Visible = false;
        dgData.HeaderStyle.BackColor = Color.White;
        dgData.HeaderStyle.ForeColor = Color.Blue;
        tableTitle = "业务流程统计";
        lyf_OutputToExcel.expExcle(this, divPrint, tableTitle);
    }
    protected void dgData_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[1].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
        }
    }
    protected void dgData_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        //设置DataGrid当前页的索引值为用户选择的页的索引
        dgData.CurrentPageIndex = e.NewPageIndex;
        databind();
    }
}