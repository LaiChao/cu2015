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
        if (Request.QueryString.Count > 0)
        {
            ViewState["nameNow"] = nameNow = Request["benfactorName"].Trim();//项目ID
            lblType.Text = Request["type"].Trim();//项目类型
        }

        if (!Page.IsPostBack)
        {
            string strread = string.Format("select projectID,projectName,needMoney from e_project where projectID='{0}' or projectName='{1}'", nameNow, nameNow);
            MySqlDataReader mysqlread = msq.getmysqlread(strread);
            while (mysqlread.Read())
            {
                ViewState["myKey"] = mysqlread.GetInt32(2).ToString();
                DateTime dt = DateTime.Now;
                lbcaptID.Text = mysqlread.GetInt32(2).ToString("f2");//needMoney
                LbproID.Text = mysqlread.GetString(0);
                lbbenfnadd.Text = mysqlread.GetString(1);
            }

            if (Request["type"].Trim() == "物品")
            {
                dgData.Visible = false;
                dgData1.Visible = true;
                ViewState["now"] = string.Format("select * from e_item where state='未使用' and (handlingunitID={0} or benfactorFrom='朝阳区慈善协会') ", nameNow.Substring(0, 3).ToString());
                databind1(ViewState["now"].ToString());
            }
            if (Request["type"].Trim() == "资金")
            {
                dgData.Visible = true;
                dgData1.Visible = false;
                string strplancap = lbcaptID.Text;
                ViewState["strproID"] = string.Format("SELECT * FROM  e_capital where handlingunitID={1} order by abs(capitalEarn - '{0}') asc LIMIT 3", strplancap, nameNow.Substring(0,3).ToString());
                ViewState["now"] = ViewState["strproID"].ToString();
                databind(ViewState["now"].ToString());
            }
        }
        
    }

    public void databind(string s)
    {       
    
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), s);
        DataView dv = new DataView(ds.Tables[0]);            
        dgData.DataSource = dv;
        dgData.DataBind(); 
    }
    public void databind1(string s)
    {//物品
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), s);
        DataView dv = new DataView(ds.Tables[0]);
        dgData1.DataSource = dv;
        dgData1.DataBind(); 
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
        this.dgData1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData1_EditCommand);
        this.dgData1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData1_UpdateCommand);
        this.dgData1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData1_CancelCommand);
        this.dgData1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgData_ItemDataBound);

    }
    #endregion
    #region "页面操作"


    private void dgData_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        dgData.EditItemIndex = -1;
        databind(ViewState["now"].ToString());
    }

    private void dgData1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        dgData1.EditItemIndex = -1;
        databind1(ViewState["now"].ToString());
    }

    private void dgData_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        ViewState["oldMoney"]=((Label)e.Item.FindControl("labemail")).Text.Trim();//拥有资金
        dgData.EditItemIndex = e.Item.ItemIndex;
        databind(ViewState["now"].ToString());
    }

    private void dgData1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        dgData1.EditItemIndex = e.Item.ItemIndex;
        databind1(ViewState["now"].ToString());
    }
    private void dgData_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        //DataSet dds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), str111);
        //DataView ddv = new DataView(dds.Tables[0]);
        //dgData.DataSource = dds;
        //   dgData.DataBind();
       // databind();
        ((TextBox)e.Item.FindControl("txtproid")).Text = LbproID.Text;//项目ID
        if (((TextBox)e.Item.FindControl("txtproid")).Text == "")
        {
            lberror.Text = "项目ID不能为空";
        }
        else 
        {
           // int i = int.Parse(lbcaptID.Text);//计划资金
            double i1 = double.Parse(lbcaptID.Text);
           // int re = int.Parse(((TextBox)e.Item.FindControl("txtemail")).Text);//使用资金
            double re1 = double.Parse(((TextBox)e.Item.FindControl("txtemail")).Text);
         //   int hasM = int.Parse(ViewState["oldMoney"].ToString());//拥有资金
            double hasM1 = double.Parse(ViewState["oldMoney"].ToString());
            if(i1<re1)//使用资金不大于计划资金
            {
                lberror.Text = "使用资金不能大于计划资金";
               
                dgData.EditItemIndex = -1;
                databind(ViewState["now"].ToString());
                return;
            }
            else if(re1>hasM1)//使用资金不大于拥有资金
            {
                lberror.Text = "使用资金不能大于拥有资金";
                dgData.EditItemIndex = -1;
                databind(ViewState["now"].ToString());
                return;
            }
            else
            {

                //if (i > re)
                //{
                //资金表扣除使用资金、项目表修改剩余所需资金
                lbcaptID.Text = (i1 - re1).ToString();//计划资金
                //((TextBox)e.Item.FindControl("txtemail")).Text = "0";//拥有资金               
                string strupdata = string.Format("update e_capital set capitalEarn=capitalEarn-{1},capitalIntime='{2}',projectID='{3}',projectName='{4}' where capitalID='{0}'",
                ((TextBox)e.Item.FindControl("txtteladd")).Text.Trim(),//资金ID
                ((TextBox)e.Item.FindControl("txtemail")).Text.Trim(),//使用资金
                ((TextBox)e.Item.FindControl("txtdirtime")).Text.Trim(),//资金录入时间
                ((TextBox)e.Item.FindControl("txtproid")).Text.Trim(), //项目ID
                lbbenfnadd.Text);//项目名称
                string strupdate = string.Format("update e_project set needMoney=needMoney-{0} where projectID='{1}'",
                    ((TextBox)e.Item.FindControl("txtemail")).Text.Trim(),//使用资金
                    ((TextBox)e.Item.FindControl("txtproid")).Text.Trim() //项目ID
                    );
                msq.getmysqlcom(strupdata);
                msq.getmysqlcom(strupdate);
                //资金追踪表
                 DateTime dt = DateTime.Now;
                 string time = dt.Year.ToString() +'-'+ dt.Month.ToString() + '-'+dt.Day.ToString();
                 string strinsert = string.Format("insert into e_moneytrack(benefactorID,projectID,palnMoney,useMoney,prousein,prouseinTime,prouseoutTime,benfactorName,projectName,benfactorFrom,handlingunitID) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10})",
                 ((TextBox)e.Item.FindControl("bectID")).Text.Trim(),//捐助人ID
                 ((TextBox)e.Item.FindControl("txtproid")).Text.Trim(),//项目ID
                 ViewState["myKey"].ToString(),//计划资金
                 re1,//使用资金
                 re1,//使用资金
                 ((TextBox)e.Item.FindControl("txtdirtime")).Text.Trim(),//资金录入时间
                 time,
                 ((TextBox)e.Item.FindControl("txtdename")).Text.Trim(),//捐助人名称
                 lbbenfnadd.Text,//项目名称
                 Session["benfactorFrom"].ToString(),//经办单位名称
                 ViewState["nameNow"].ToString().Substring(0, 3).ToString()//经办单位ID
                 );
                 msq.getmysqlcom(strinsert);               
                 dgData.EditItemIndex = -1;
                 databind(ViewState["now"].ToString());

                 NLogTest nlog = new NLogTest();
                 string sss = "分配资金：" + ((TextBox)e.Item.FindControl("txtteladd")).Text.Trim();
                 nlog.WriteLog(Session["UserName"].ToString(), sss);
            }
        }
    }

    private void dgData1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        ((TextBox)e.Item.FindControl("tbProjectID")).Text = LbproID.Text;//项目ID
        if (((TextBox)e.Item.FindControl("tbProjectID")).Text == "")
        {
            lberror.Text = "项目ID不能为空";
        }
        else
        {//物品追踪
            string strupdate = string.Format("update e_item set projectID='{1}',projectName='{2}',timeOut='{3}',state='已使用' where itemID='{0}'", ((TextBox)e.Item.FindControl("tbItemID")).Text.Trim(), LbproID.Text.Trim(), lbbenfnadd.Text.Trim(),DateTime.Now.ToString());
                msq.getmysqlcom(strupdate);
                dgData1.EditItemIndex = -1;
                databind1(ViewState["now"].ToString());

                NLogTest nlog = new NLogTest();
                string sss = "分配物品：" + ((TextBox)e.Item.FindControl("tbItemName")).Text.Trim();
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strTable="";
        if (Request["type"].Trim() == "物品")
        {
            strTable = "e_item";
        }
        if (Request["type"].Trim() == "资金")
        {
            strTable = "e_capital";
        }
        if (tbName.Text.Trim() == "")
            ViewState["now"] = "select * from " + strTable;
        else
            ViewState["now"] = "select * from " + strTable + " where benfactorName='" + tbName.Text.Trim() + "'";
        if (strTable == "e_capital")
            databind(ViewState["now"].ToString());
        if(strTable == "e_item")
            databind1(ViewState["now"].ToString());
    }
  
}