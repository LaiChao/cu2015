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

public partial class Basic201512_受助人 : System.Web.UI.Page
{
    mysqlconn msq=new mysqlconn();
    string str111 = string.Format("select * from e_project ");
    string str112 = string.Format("select * from e_handlingunit");
    string nameNow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!Page.IsPostBack)
        {
           
            databind();
        }
        
    }

    public void databind()
    {
     //   string proID = Session["proID"].ToString();
       // string strplancap = LbproID.Text;
       // Lbearn.Text=strplancap;
        string strproID = string.Format("SELECT capitalID,capitalEarn,capitalIntime,projectID,projectName FROM  e_capital where projectID='{0}' or projectName='{1}'", txtproID.Text,txtName.Text);      
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), strproID);
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
        //DataSet dds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), str111);
        //DataView ddv = new DataView(dds.Tables[0]);
        //dgData.DataSource = dds;
        //   dgData.DataBind();
       // databind();
        
        if (((TextBox)e.Item.FindControl("txtproid")).Text == "")
        {
            lberror.Text = "项目ID不能为空";
        }
        else 
        { 
             int i = int.Parse(lbcaptID.Text);          
             int re = int.Parse(((TextBox)e.Item.FindControl("txtemail")).Text);
             if (i > re)
             {
                 lbcaptID.Text = (i - re).ToString();
                 ((TextBox)e.Item.FindControl("txtemail")).Text = "0";
             }
             else
             {

                 ((TextBox)e.Item.FindControl("txtemail")).Text = (re - i).ToString();
                 lbcaptID.Text = "0";

             }
            string strupdata = string.Format("update e_capital set capitalID='{0}',capitalEarn='{1}',capitalIntime='{2}',projectID='{3}',projectName='{4}' where capitalID='{0}'",
            ((TextBox)e.Item.FindControl("txtteladd")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtemail")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtdir")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtproid")).Text.Trim(),
            ((TextBox)e.Item.FindControl("txtproname")).Text.Trim());            
             msq.getmysqlcom(strupdata);
             dgData.EditItemIndex = -1;
             databind();

             NLogTest nlog = new NLogTest();
             string sss = "申请资金分配审批：" + ((TextBox)e.Item.FindControl("txtteladd")).Text.Trim();
             nlog.WriteLog(Session["UserName"].ToString(), sss);
 
        }
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
        databind();
        string strproID = string.Format("SELECT palnMoney FROM  e_project where projectID='{0}' or projectName='{1}' ", txtproID.Text,txtName.Text);
        MySqlDataReader mysqlreader = msq.getmysqlread(strproID);
        while (mysqlreader.Read())
        {
            lbcaptID.Text = mysqlreader.GetString(0);                    
        }
    }
    
}