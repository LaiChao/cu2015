﻿using System;
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
        if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
        {
            Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
            return;
        }
        if(!Page.IsPostBack)
        {
            int intRole = Convert.ToInt32(Session["userRole"].ToString());
            
            //查看未读信息
            StringBuilder infoQuery = new StringBuilder();
            infoQuery.Append("select count(*) from e_info where infoRead='未读' ");
            if (Session["UserName"].ToString() == "admin")
            {
                ;
            }
            else
            {
                infoQuery.Append("and (infoTo='" + Session["benfactorFrom"].ToString() + "' or infoTo='所有机构')");
            }
            MySqlDataReader mysqlread = msq.getmysqlread(infoQuery.ToString());
            while (mysqlread.Read())
                Label1.Text = "（" + mysqlread.GetString(0) + "）";
            mysqlread.Close();
            mysqlread.Dispose();
            if(intRole==4)
            {//分配权限
                MySqlDataReader mysqlread1 = msq.getmysqlread("select count(*) from e_user where userRole is null");
                while (mysqlread1.Read())
                    Label2.Text = "（" + mysqlread1.GetString(0) + "）";
                mysqlread1.Close();
                mysqlread1.Dispose();
            }
            else
            {
                tr2.Visible = false;
            }
            
            if(intRole==1)
            {
                tr3.Visible = false;
            }
            else
            { //申请的项目
                MySqlDataReader mysqlread2 = msq.getmysqlread("select count(*) from e_project where proschedule='申请中'");
                while (mysqlread2.Read())
                    Label3.Text = "（" + mysqlread2.GetString(0) + "）";
                mysqlread2.Close();
                mysqlread2.Dispose();
            }

            if (intRole == 1 || intRole==3)//分会与会长不显示
            {
                tr4.Visible = false;
            }
            else
            {
                //确认添加的资金
                MySqlDataReader mysqlread3 = msq.getmysqlread("select count(*) from e_capital where state=0");
                while (mysqlread3.Read())
                    Label4.Text = "（" + mysqlread3.GetString(0) + "）";
                mysqlread3.Close();
                mysqlread3.Dispose();
            }

            //冠名捐助金到期日期
            MySqlDataReader mysqlread4 = msq.getmysqlread("select count(*) from e_benfactor where deadline<now()");
            while (mysqlread4.Read())
                Label5.Text = "（" + mysqlread4.GetString(0) + "）";
            mysqlread4.Close();
            mysqlread4.Dispose();
			
			//冠名捐助金分期提醒
            MySqlDataReader mysqlread5 = msq.getmysqlread("select count(*) from e_remind,e_benfactor where e_remind.flag>0 and e_remind.benfactorID=e_benfactor.benfactorID and now()>date_sub(deadline,interval cycle*flag month)");
            while(mysqlread5.Read())
                Label6.Text = "（" + mysqlread5.GetString(0) + "）";
            mysqlread5.Close();
            mysqlread5.Dispose();
        }
    }
}