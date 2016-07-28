using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace CL.Utility.Web.BasicData
{
    public partial class Register : System.Web.UI.Page
    {
        mysqlconn msq = new mysqlconn();       
        protected void Page_Load(object sender, System.EventArgs e)
        {
             if (!Page.IsPostBack)
             {
                 ViewState["queryString"] = string.Format("select * from (select handlingunitID,benfactorFrom,sum(useMoney) as thisMonth from e_moneytrack where DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by handlingunitID) aaa,(select handlingunitID,sum(capitalEarn) as remain from e_capital group by handlingunitID) bbb where aaa.handlingunitID=bbb.handlingunitID ");
                 if (Session["userRole"].ToString()=="1")
                 {//分会用户只能查看自身分会的资金情况
                     ViewState["queryString"] = ViewState["queryString"].ToString() + "and aaa.benfactorFrom='" + Session["benfactorFrom"].ToString() + "'";
                 }
                 BindData(ViewState["queryString"].ToString());                
             }        
        }

        private void BindData(string s)
        {
            DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), s);
            DataView dv = new DataView(ds.Tables[0]);
            GridView1.DataSource = dv;
            GridView1.DataKeyNames = new string[] { "benfactorFrom" };//主键
            GridView1.DataBind();        
        }
}
}
