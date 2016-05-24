using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//mysql数据库连接
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class Basic201512_待办事项 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            //查看未读信息
            StringBuilder infoQuery = new StringBuilder();
            infoQuery.Append("select count(*) from e_info where infoRead='未读' ");
            if (Session["UserName"].ToString() == "admin")
            {
                ;
            }
            else
            {
                infoQuery.Append("and infoTo='" + Session["UserName"].ToString() + "' or infoTo='所有机构'");
            }
            MySqlDataReader mysqlread = msq.getmysqlread(infoQuery.ToString());
            while (mysqlread.Read())
                Label1.Text = "（" + mysqlread.GetString(0) + "）";

            //分配权限
            MySqlDataReader mysqlread1 = msq.getmysqlread("select count(*) from e_user where userRole is null");
            while (mysqlread1.Read())
                Label2.Text = "（" + mysqlread1.GetString(0) + "）";
            //申请的项目
            MySqlDataReader mysqlread2 = msq.getmysqlread("select count(*) from e_project where proschedule='申请'");
            while (mysqlread2.Read())
                Label3.Text = "（" + mysqlread2.GetString(0) + "）";

            //确认添加的资金
            MySqlDataReader mysqlread3 = msq.getmysqlread("select count(*) from e_capital where state=0");
            while (mysqlread3.Read())
                Label4.Text = "（" + mysqlread3.GetString(0) + "）";

            //冠名捐助金到期日期
            MySqlDataReader mysqlread4 = msq.getmysqlread("select count(*) from e_benfactor where deadline<now()");
            while (mysqlread4.Read())
                Label5.Text = "（" + mysqlread4.GetString(0) + "）";
        }
    }
}