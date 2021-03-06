﻿using System;
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
    string str111 = string.Format("select * from e_project where proschedule='申请中' and (needMoney>0 or projectType='物品')");
    string str112 = string.Format("select * from e_handlingunit");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
        {
            Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
            return;
        }
        //DataSet ds1 = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),str111);
        //DataView dv1 = new DataView(ds1.Tables[0]);
        //dgHeader.DataSource = dv1;
        //dgHeader.DataBind();
      //  ((BoundColumn)dgData.Columns[0]).HeaderText="编辑";
        if (!Page.IsPostBack)
        {
            databind();
            if (Session["benfactorFrom"].ToString() != "北京市朝阳区慈善协会捐助科")
            {
                dgData.Columns[0].Visible = false;
            }
        }
    }

    public void databind()
    {
        DataSet ds1 = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),str112);
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), str111);
        DataView dv = new DataView(ds.Tables[0]);
        DataView dv1 = new DataView(ds1.Tables[0]);
        dpdhud.AppendDataBoundItems = true;
        dpdhud.DataSource = ds1;
        dpdhud.DataTextField = "benfactorFrom";
        dpdhud.DataBind();
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


    //private void dgData_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    //{
    //    dgData.EditItemIndex = -1;
    //    databind();
    //}

    //private void dgData_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    //{


    //}

    //private void dgData_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    //{

    //    dgData.EditItemIndex = e.Item.ItemIndex;
    //    databind();
    //}

    //private void dgData_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    //{
    //    //DataSet dds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), str111);
    //    //DataView ddv = new DataView(dds.Tables[0]);
    //    //dgData.DataSource = dds;
    //    //   dgData.DataBind();
    //    databind();
    //    string strupdata = string.Format("update {0} set benfactorID='{1}'and benfactorName='{2}'and telphoneADD='{3}' and e_mail='{4}' and directionlBef='{5}' and guanming='{6}' and wuzhu='{7}'", dpdbenfactor.SelectedValue,
    //        ((TextBox)e.Item.FindControl("txtEditID")).Text.Trim(),
    //        ((TextBox)e.Item.FindControl("txtEditName")).Text.Trim(),
    //        ((TextBox)e.Item.FindControl("txtADD")).Text.Trim(),
    //        ((TextBox)e.Item.FindControl("txtemail")).Text.Trim(),
    //        ((TextBox)e.Item.FindControl("txtdir")).Text.Trim(),
    //        ((TextBox)e.Item.FindControl("txtguanming")).Text.Trim(),
    //        ((TextBox)e.Item.FindControl("txtwuzhu")).Text.Trim());
    //    msq.getmysqlcom(strupdata);
    //    dgData.EditItemIndex = -1;
    //    databind();

    //}

    private void dgData_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        Session["tablename"] = dpdhud.SelectedValue;
       
        //Label lbl = e.Item.FindControl("labID") as Label;
        //lbl.Text = dgData.DataMember[0].ToString();
        switch (e.Item.ItemType)
        {
            case ListItemType.AlternatingItem:
            case ListItemType.Item:
                {
                    e.Item.Attributes.Add

                        ("onmouseover", "this.style.backgroundColor='#E6F5FA'");
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
        queryString.Append("select * from e_project where proschedule='申请中' and (needMoney>0 or projectType='物品') ");
        if(txtproid.Text.Trim()!="")
        {
            queryString.Append("and projectID='" + txtproid.Text.Trim() + "' ");
        }
        if(txttelname.Text.Trim()!="")
        {
            queryString.Append("and telphoneName='" + txttelname.Text.Trim() + "' ");
        }
        if(TbselectName.Text.Trim()!="")
        {
            queryString.Append("and projectName like '%" + TbselectName.Text.Trim() + "%' ");
        }
        if(dpdhud.SelectedItem.Text!="全部")
        {
            queryString.Append("and benfactorFrom='" + dpdhud.SelectedItem.Text + "' ");
        }
        //string str = string.Format("select * from e_project where projectName='{0}'or benfactorFrom='{1}' or projectID='{2}' or telphoneName='{3}'", TbselectName.Text, dpdhud.DataTextField, txtproid.Text,txttelname.Text);
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),queryString.ToString());
        DataView dv = new DataView(ds.Tables[0]);
        dgData.DataSource = dv;
        dgData.DataBind();        
    }
    
}