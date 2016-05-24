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
    //string str111 = string.Format("select * from e_recipientsdoc ");
    protected void Page_Load(object sender, EventArgs e)
    {
        //DataSet ds1 = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),str111);
        //DataView dv1 = new DataView(ds1.Tables[0]);
        //dgHeader.DataSource = dv1;
        //dgHeader.DataBind();
      //  ((BoundColumn)dgData.Columns[0]).HeaderText="编辑";
        if (!Page.IsPostBack)
        {
            Button1.Visible = false;
            //判断权限
            string queryRole = "select userRole from e_user where user='" + Session["UserName"].ToString() + "'";
            MySqlDataReader mysqlread32 = msq.getmysqlread(queryRole);
            int roleOfUser = 0;
            while (mysqlread32.Read())
            {
                roleOfUser = mysqlread32.GetInt32(0);
            }
            int result;
            if (roleOfUser > 1)//非分会权限
                Button1.Visible = true;
            //绑定数据
            StringBuilder queryString = new StringBuilder();
            queryString.Append("select * from e_benfactor where 1=1 ");
            DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), queryString.ToString());
            DataView dv = new DataView(ds.Tables[0]);
            dgData.DataSource = dv;
            dgData.DataBind();
        }
       

    }

    //public void databind()
    //{
    //    DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), str111);
    //    DataView dv = new DataView(ds.Tables[0]);
    //    dgData.DataSource = dv;
    //    dgData.DataBind();
 
    //}
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

    #region "注释代码"
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
    #endregion

    private void dgData_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        Session["tablename"] = benfactorType.SelectedValue;
       
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
        dgData1.Visible = false;
        dgData.Visible = true;

        StringBuilder queryString = new StringBuilder();
        queryString.Append("select * from e_benfactor where 1=1 ");
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
            queryString.Append("and benfactorName='" + TbselectName.Text.ToString() + "' ");
        if (TbselectID.Text.Trim() != "")
            queryString.Append("and TEL='" + TbselectID.Text.ToString() + "'");
        //string str = string.Format("select * from {0} where benfactorName='{2}'or telphoneADD='{1}'", benfactorType.SelectedValue, TbselectID.Text, TbselectName.Text);

        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), queryString.ToString());
        DataView dv = new DataView(ds.Tables[0]);
        dgData.DataSource = dv;
        dgData.DataBind();
        
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

    protected void dgData1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if(e.CommandName=="confirm")
        {
            string capitalID = ((Label)e.Item.FindControl("capitalID")).Text.Trim();
            int capitalEarn = Convert.ToInt32(((Label)e.Item.FindControl("capitalEarn")).Text.Trim()) + Convert.ToInt32(((Label)e.Item.FindControl("capitalIn")).Text.Trim());
            string updateString = string.Format("update e_capital set capitalEarn={1},capitalIn=0,state=1 where capitalID='{0}'", capitalID, capitalEarn);
            int result = msq.getmysqlcom(updateString);
            if (result > 0)
            {
                HttpContext.Current.Response.Write("<script>alert('金额确认成功');</script>");
                confirmRoad();
            }
        }
    }
}