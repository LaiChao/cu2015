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
    //string str111 = string.Format("select * from e_project ");
    public static string tableTitle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            putout.Visible = false;
            StringBuilder queryString = new StringBuilder();
            queryString.Append("select * from e_project where 1=1 ");
            if (Session["userRole"].ToString() == "1")
                queryString.Append("and benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ");
            ViewState["init"] = queryString.ToString();//初始查询语句
            ViewState["now"] = ViewState["init"].ToString();

            databind();
            CheckBox0.Checked = CheckBox1.Checked = CheckBox2.Checked = CheckBox3.Checked = CheckBox4.Checked = CheckBox5.Checked = CheckBox6.Checked = true;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void databind()
    {
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), ViewState["now"].ToString());
        DataView dv = new DataView(ds.Tables[0]);
        dgData.DataSource = dv;
        dgData.DataKeyField =  "projectID" ;
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
         DateTime dt = DateTime.Now;
         string prodatatimefinsh = dt.ToShortDateString().ToString();
         string tempID = ((Label)e.Item.FindControl("labID")).Text.Trim();
         string str = string.Format("update e_project set proschedule='归档',prodatatimefinsh='{0}' where projectID='" + tempID + "'", prodatatimefinsh);
         msq.getmysqlcom(str);
         databind();


         NLogTest nlog = new NLogTest();
         string sss = "归档：" + tempID;
         nlog.WriteLog(Session["UserName"].ToString(), sss);
    }

    protected void dgData_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if(e.CommandName=="Edit1")
        {
            DateTime dt = DateTime.Now;
            string prodatatimefinsh = dt.ToShortDateString().ToString();
            string tempID = ((Label)e.Item.FindControl("labID")).Text.Trim();
            string str = string.Format("update e_project set proschedule='结项',prodatatimeguid='{0}' where projectID='" + tempID + "'", prodatatimefinsh);
            msq.getmysqlcom(str);
            databind();


            NLogTest nlog = new NLogTest();
            string sss = "结项：" + tempID;
            nlog.WriteLog(Session["UserName"].ToString(), sss);
        }
    }

    private void dgData_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        string strupdata = string.Format("update e_project set projectID='{0}',projectName='{1}',benfactorFrom='{2}',proschedule='{3}',telphoneName='{4}',projectDir='{5}' where projectID='{0}'",
            ((TextBox)e.Item.FindControl("txtEditID")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtEditName")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtEditOrder")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txttimer")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtteladdname")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtdes")).Text.Trim());
            msq.getmysqlcom(strupdata);
            dgData.EditItemIndex = -1;
            databind();

            NLogTest nlog = new NLogTest();
            string sss = "修改项目信息情况：" + ((TextBox)e.Item.FindControl("txtEditName")).Text.Trim();
            nlog.WriteLog(Session["UserName"].ToString(), sss);       
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
    {//搜索
        string str = string.Format("and (projectID='{0}'or projectName='{1}')",TbselectID.Text,TbselectName.Text);       
        StringBuilder queryString = new StringBuilder();
        queryString.Append(ViewState["init"].ToString());
        queryString.Append(str);
        ViewState["now"] = queryString.ToString();
        databind();
    }
    protected void btout_Click(object sender, EventArgs e)
    {
        dgData.Columns[7].Visible = false;
        dgData.Columns[8].Visible = false;
        DateTime dt = DateTime.Now;
        tableTitle =illtimebe.Text + "至"+illtimeend.Text+"项目信息";
        string dttime=dt.ToShortDateString().ToString();        
        lyf_OutputToExcel.expExcle(this,divPrint,tableTitle);
    }
    protected void Btselectout_Click(object sender, EventArgs e)
    {//搜索
        string stringpromonth = string.Format("and (prodatatime between '{0}' and '{1}')", illtimebe.Text, illtimeend.Text);
        StringBuilder queryString = new StringBuilder();
        queryString.Append(ViewState["init"].ToString());
        queryString.Append(stringpromonth);
        ViewState["now"] = queryString.ToString();
        databind();
    }
    protected void CheckBox0_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox0.Checked)
            dgData.Columns[0].Visible = true;
        else
            dgData.Columns[0].Visible = false;
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
            dgData.Columns[1].Visible = true;
        else
            dgData.Columns[1].Visible = false;
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox2.Checked)
            dgData.Columns[2].Visible = true;
        else
            dgData.Columns[2].Visible = false;
    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox3.Checked)
            dgData.Columns[3].Visible = true;
        else
            dgData.Columns[3].Visible = false;
    }
    protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox4.Checked)
            dgData.Columns[4].Visible = true;
        else
            dgData.Columns[4].Visible = false;
    }
    protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox5.Checked)
            dgData.Columns[5].Visible = true;
        else
            dgData.Columns[5].Visible = false;
    }
    protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox6.Checked)
            dgData.Columns[6].Visible = true;
        else
            dgData.Columns[6].Visible = false;
    }
    protected void dgData_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[0].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
            //初始设置全部项目无法结项、归档
            ((ImageButton)e.Item.Cells[7].FindControl("btnEdit1")).Enabled = false;//无法结项
            ((ImageButton)e.Item.Cells[8].FindControl("btnEdit")).Enabled = false;//无法归档
            if (Session["benfactorFrom"].ToString() == "北京市朝阳区慈善协会捐助科")
            {
                if (((Label)(e.Item.Cells[3].FindControl("labtimer"))).Text.ToString() == "会长审批通过")
                {//((Label)(e.Item.Cells[3].Controls[0])).Text.ToString()
                    
                    ((ImageButton)e.Item.Cells[7].FindControl("btnEdit1")).Enabled = true;//结项
                    ((ImageButton)e.Item.Cells[7].FindControl("btnEdit1")).Attributes.Add("onclick", "return confirm('确认结项吗?');");
                }
                if (((Label)(e.Item.Cells[3].FindControl("labtimer"))).Text.ToString() == "结项")
                {
                    ((ImageButton)e.Item.Cells[8].FindControl("btnEdit")).Enabled = true;//归档
                    ((ImageButton)e.Item.Cells[8].FindControl("btnEdit")).Attributes.Add("onclick", "return confirm('确认归档吗?');");
                }
            }
        }
    }
    protected void btputout_Click(object sender, EventArgs e)
    {
        putout.Visible = true;
    }
}