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
    //string str111 = string.Format("select * from e_moneytrack order by prouseoutTime desc");
   
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
            ViewState["init"] = string.Format("select * from e_moneytrack where 1=1 ");
            if (Request.QueryString.Count > 0)
            {//从其他页面跳转过来
                TbselectName.Text = Request["id"].Trim();
                ViewState["init"] = string.Format("select * from e_moneytrack where benefactorID={0} ", TbselectName.Text);
            }
            ViewState["now"] = ViewState["init"].ToString() + "order by prouseoutTime desc";
            databind();
        }
       

    }

    public void databind()
    {
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
        //this.dgData.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData_EditCommand);
        //this.dgData.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData_UpdateCommand);
        //this.dgData.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData_CancelCommand);
        //this.dgData.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData_DeleteCommand);
        //this.dgData.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgData_ItemDataBound);
        //this.dgHeader.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgHeader_ItemCommand);

    }
    #endregion
    #region "页面操作"

    private void dgData_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
      //  Session["tablename"] = dpdbenf.SelectedValue;
       
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
        //"select * from e_moneytrack order by prouseoutTime desc"
        queryString.Append(ViewState["init"].ToString());
        if (TbselectName.Text.Trim() != "")
            queryString.Append("and benefactorID='" + TbselectName.Text.Trim() + "' ");
        if (txtselectName.Text.Trim() != "")
            queryString.Append("and benfactorName='" + txtselectName.Text.Trim() + "' ");
        if (TbselectID.Text.Trim() != "")
            queryString.Append("and projectID='" + TbselectID.Text.Trim() + "' ");
        if (txtselectproname.Text.Trim() != "")
            queryString.Append("and projectName like '%" + txtselectproname.Text.Trim() + "%' ");
        queryString.Append("order by prouseoutTime desc ");
        //DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),queryString.ToString());
        //DataView dv = new DataView(ds.Tables[0]);
        //dgData.DataSource = dv;
        //dgData.DataBind();
        ViewState["now"] = queryString.ToString();
        dgData.CurrentPageIndex = 0;
        databind();
    }

    protected void btout_Click(object sender, EventArgs e)
    {
        dgData.HeaderStyle.BackColor = Color.White;
        dgData.HeaderStyle.ForeColor = Color.Blue;
        tableTitle = "资金追踪";
        lyf_OutputToExcel.expExcle(this, divPrint, tableTitle);
    }
    protected void dgData_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[0].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
            e.Item.Cells[2].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
        }
    }
    protected void dgData_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgData.CurrentPageIndex = e.NewPageIndex;
        databind();
    }
}