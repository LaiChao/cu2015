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
    string str111 = string.Format("select * from e_project where shenpi2<>'1' or shenpi2 is null and shenpi1<>'1' or shenpi1 is null ");
    protected void Page_Load(object sender, EventArgs e)
    {
        //DataSet ds1 = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),str111);
        //DataView dv1 = new DataView(ds1.Tables[0]);
        //dgHeader.DataSource = dv1;
        //dgHeader.DataBind();
      //  ((BoundColumn)dgData.Columns[0]).HeaderText="编辑";
        DataSet dds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),str111);
        DataView ddv = new DataView(dds.Tables[0]);
        dgData.DataSource = dds;
        dgData.DataBind();

    }
   
    protected void Btselect_Click(object sender, EventArgs e)
    {
        string str = string.Format("select * from e_project where projectID='{0}'or projectName='{1}'",TbselectID.Text,TbselectName.Text);
        DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),str);
        DataView dv = new DataView(ds.Tables[0]);
        dgData.DataSource = dv;
        dgData.DataBind();
        
    }

    
}