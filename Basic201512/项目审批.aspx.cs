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
        //DataSet ds1 = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),str111);
        //DataView dv1 = new DataView(ds1.Tables[0]);
        //dgHeader.DataSource = dv1;
        //dgHeader.DataBind();
      //  ((BoundColumn)dgData.Columns[0]).HeaderText="编辑";
        StringBuilder queryString = new StringBuilder();
        queryString.Append("select * from e_project where (proschedule='申请中' or proschedule='执行') ");
        if(Session["userRole"].ToString()=="1")
            queryString.Append("and benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ");
        queryString.Append("order by proschedule desc");
        //string str111 = string.Format("select * from e_project where proschedule='申请中' or proschedule='执行' order by proschedule desc");//shenpi2<>'1' or shenpi2 is null and shenpi1<>'1' or shenpi1 is null

        DataSet dds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),queryString.ToString());
        DataView ddv = new DataView(dds.Tables[0]);
        dgData.DataSource = dds;
        dgData.DataBind();

    }
   
    protected void Btselect_Click(object sender, EventArgs e)
    {
        string str = string.Format("select * from e_project where (projectID='{0}'or projectName='{1}') ",TbselectID.Text,TbselectName.Text);
        StringBuilder queryString2 = new StringBuilder();
        queryString2.Append(str);
        if (Session["userRole"].ToString() == "1")
            queryString2.Append("and benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ");

        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),queryString2.ToString());
        DataView dv = new DataView(ds.Tables[0]);
        dgData.DataSource = dv;
        dgData.DataBind();
        
    }

    
}