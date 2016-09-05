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
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
            {
                Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
                return;
            }
            StringBuilder queryString = new StringBuilder();
            queryString.Append("select * from e_project where (proschedule='申请中' or proschedule='科室审批通过') ");
            if(Session["userRole"].ToString()=="1")
                queryString.Append("and benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ");
            ViewState["init"] = queryString.ToString();
            queryString.Append("order by proschedule desc");
            //string str111 = string.Format("select * from e_project where proschedule='申请中' or proschedule='执行' order by proschedule desc");//shenpi2<>'1' or shenpi2 is null and shenpi1<>'1' or shenpi1 is null
            ViewState["now"] = queryString.ToString();
            databind();
        }
    }
    protected void databind()
    {
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), ViewState["now"].ToString());
        DataView dv = new DataView(ds.Tables[0]);
        dgData.DataSource = dv;
        dgData.DataBind();
    }
    protected void Btselect_Click(object sender, EventArgs e)
    {
        string str = string.Format("select * from e_project where (projectID='{0}'or projectName like '%{1}%') ",TbselectID.Text,TbselectName.Text);
        StringBuilder queryString2 = new StringBuilder();
        queryString2.Append(ViewState["init"].ToString());
        if(TbselectID.Text.Trim()!="")
        {
            queryString2.Append("and projectID='" + TbselectID.Text.Trim() + "' ");
        }
        if(TbselectName.Text.Trim()!="")
        {
            queryString2.Append("and projectName like '%" + TbselectName.Text.Trim() + "%' ");
        }
        ViewState["now"] = queryString2.ToString();
        dgData.CurrentPageIndex = 0;
        databind();      
    }
    protected void dgData_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgData.CurrentPageIndex = e.NewPageIndex;
        databind();
    }
}