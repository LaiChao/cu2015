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

public partial class Basic201512_查看受助人信息 : System.Web.UI.Page
{
    mysqlconn msq11 = new mysqlconn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)//页面首次加载
        {
            //初始化
            string urlNow = Request.Url.ToString();
            string[] temp = urlNow.Split('=');
            foreach (string s in temp)
            {
                ViewState["IDNow"] = s;
            }
            IterateThroughChildren(this);
            databind();
        }
    }
    protected void databind()
    {
        string str113 = "select * from e_recipients where recipientsID=" + ViewState["IDNow"].ToString();
        MySqlDataReader mysqlread = msq11.getmysqlread(str113);
        while (mysqlread.Read())
        {
            benfactorFrom.Text = mysqlread.GetString(1);
            recipientsADD.Text = mysqlread.GetString(2);
            recipientsName.Text = mysqlread.GetString(3);
            sex.Text = mysqlread.GetString(4);
            recipientsPIdcard.Text = mysqlread.GetString(5);
            recipientsADDnow.Text = mysqlread.GetString(6);
            incomlowID.Text = mysqlread.GetString(7);
            telphoneADD.Text = mysqlread.GetString(8);
            workplace.Text = mysqlread.GetString(9);
            famName1.Text = mysqlread.GetString(10);
            famRelation1.Text = mysqlread.GetString(11);
            famWorkplace1.Text = mysqlread.GetString(12);
            famTel1.Text = mysqlread.GetString(13);
            famWork1.Text = mysqlread.GetString(14);
            famIncome1.Text = mysqlread.GetString(15);
            famName2.Text = mysqlread.GetString(16);
            famRelation2.Text = mysqlread.GetString(17);
            famWorkplace2.Text = mysqlread.GetString(18);
            famTel2.Text = mysqlread.GetString(19);
            famWork2.Text = mysqlread.GetString(20);
            famIncome2.Text = mysqlread.GetString(21);
            famName3.Text = mysqlread.GetString(22);
            famRelation3.Text = mysqlread.GetString(23);
            famWorkplace3.Text = mysqlread.GetString(24);
            famTel3.Text = mysqlread.GetString(25);
            famWork3.Text = mysqlread.GetString(26);
            famIncome3.Text = mysqlread.GetString(27);
            famName4.Text = mysqlread.GetString(28);
            famRelation4.Text = mysqlread.GetString(29);
            famWorkplace4.Text = mysqlread.GetString(30);
            famTel4.Text = mysqlread.GetString(31);
            famWork4.Text = mysqlread.GetString(32);
            famIncome4.Text = mysqlread.GetString(33);
            arrIncome.Text = mysqlread.GetString(34);
            marryNow.Text = mysqlread.GetString(35);
            reason.Text = mysqlread.GetString(36);
            //iscan.Text = mysqlread.GetString(37);
            CheckBox3.Checked = mysqlread.GetBoolean(37);
            canjijibie.Text = mysqlread.GetString(38);
            canjileibie.Text = mysqlread.GetString(39);
            shuoming3.Text = mysqlread.GetString(40);
            //isdoc.Text = mysqlread.GetString(41);
            CheckBox2.Checked = mysqlread.GetBoolean(41);
            illness.Text = mysqlread.GetString(42);
            illtime.Text = mysqlread.GetString(43);
            illpay.Text = mysqlread.GetString(44);
            shuoming1.Text = mysqlread.GetString(45);
            //iskun.Text = mysqlread.GetString(46);
            CheckBox5.Checked = mysqlread.GetBoolean(46);
            timeDis.Text = mysqlread.GetString(47);
            shiDu.Text = mysqlread.GetString(48);
            sonName.Text = mysqlread.GetString(49);
            deathReason.Text = mysqlread.GetString(50);
            shuoming5.Text = mysqlread.GetString(51);
            //isold.Text = mysqlread.GetString(52);
            CheckBox4.Checked = mysqlread.GetBoolean(52);
            shiNeng.Text = mysqlread.GetString(53);
            shuoming4.Text = mysqlread.GetString(54);
            //isstu.Text = mysqlread.GetString(55);
            CheckBox1.Checked = mysqlread.GetBoolean(55);
            studySchool.Text = mysqlread.GetString(56);
            studyGrade.Text = mysqlread.GetString(57);
            guardianName.Text = mysqlread.GetString(58);
            guardianGuanxi.Text = mysqlread.GetString(59);
            guardianTelADD.Text = mysqlread.GetString(60);
            shuoming2.Text = mysqlread.GetString(61);
            CheckBox6.Checked = mysqlread.GetBoolean(62);
            army.Text = mysqlread.GetString(63);
            title.Text = mysqlread.GetString(64);
            CheckBox7.Checked = mysqlread.GetBoolean(65);
            disaster.Text = mysqlread.GetString(66);
        }
    }
    protected void IterateThroughChildren(Control parent)
    {
      foreach (Control stl in parent.Controls)
      {
            if (stl is System.Web.UI.WebControls.TextBox)
            {
                TextBox tb = (TextBox)stl;
                //tb.Text = "";
                tb.Enabled = false;
            }
            if(stl is System.Web.UI.WebControls.DropDownList)
            {
                DropDownList ddl = (DropDownList)stl;
                ddl.Enabled = false;
            }
            if(stl is System.Web.UI.WebControls.CheckBox)
            {
                CheckBox cb = (CheckBox)stl;
                cb.Enabled = false;

            }

        if (stl.Controls.Count > 0)       // 判断该控件是否有下属控件。
        {
            IterateThroughChildren(stl);    //递归，访问该控件的下属控件集。
        }
      }
    }
    protected void familylist_Click(object sender, EventArgs e)
    {
        if (familylist.Text == "-")
        {
            familylist.Text = "+";
            this.tablefamily.Visible = false;
            return;
        }
        if (familylist.Text == "+")
        {
            familylist.Text = "-";
            this.tablefamily.Visible = true;
            return;
        }
    }
}