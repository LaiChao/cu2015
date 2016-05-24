using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
//using System.Configuration;
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

public partial class Basic201512_修改受助人信息 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();
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

            MySqlConnection mysqlcon = msq.getmysqlcon();
            DataSet ds = MySqlHelper.ExecuteDataset(mysqlcon, "select benfactorFrom from e_handlingunit");
            DataView dv = new DataView(ds.Tables[0]);
            benfactorFrom.DataSource = dv;
            benfactorFrom.DataTextField = "benfactorFrom";
            benfactorFrom.DataBind();

            databind();

            mask();
            if(CheckBox1.Checked)
            {
                CheckBox4.Enabled = false;
                studySchool.Enabled = true;
                studyGrade.Enabled = true;
                guardianName.Enabled = true;
                guardianGuanxi.Enabled = true;
                guardianTelADD.Enabled = true;
                shuoming2.Enabled = true;
            }
            if(CheckBox2.Checked)
            {
                illness.Enabled = true;
                illtime.Enabled = true;
                illpay.Enabled = true;
                shuoming1.Enabled = true;
            }
            if(CheckBox3.Checked)
            {
                canjijibie.Enabled = true;
                canjileibie.Enabled = true;
                shuoming3.Enabled = true;
            }
            if(CheckBox4.Checked)
            {
                CheckBox1.Enabled = false;
                shiNeng.Enabled = true;
                shuoming4.Enabled = true;
            }
            if(CheckBox5.Checked)
            {
                timeDis.Enabled = true;
                shiDu.Enabled = true;
                //sonName.Enabled = true;
                //deathReason.Enabled = true;
                shuoming5.Enabled = true;
            }
            if(CheckBox6.Checked)
            {
                army.Enabled = true;
                title.Enabled = true;
            }
            if (CheckBox7.Checked)
                disaster.Enabled = true;
        }
    }
    protected void databind()
    {
        string str113 = "select * from e_recipients where recipientsID=" + ViewState["IDNow"].ToString();
        MySqlDataReader mysqlread = msq11.getmysqlread(str113);
        while (mysqlread.Read())
        {
            benfactorFrom.SelectedValue = mysqlread.GetString(1);
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
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
        {
            CheckBox4.Enabled = false;
            studySchool.Enabled = true;
            studyGrade.Enabled = true;
            guardianName.Enabled = true;
            guardianGuanxi.Enabled = true;
            guardianTelADD.Enabled = true;
            shuoming2.Enabled = true;
        }
        if (!CheckBox1.Checked)
        {
            CheckBox4.Enabled = true;
            studySchool.Text = "";
            studyGrade.Text = "";
            guardianName.Text = "";
            guardianGuanxi.Text = "";
            guardianTelADD.Text = "";
            shuoming2.Text = "";
            studySchool.Enabled = false;
            studyGrade.Enabled = false;
            guardianName.Enabled = false;
            guardianGuanxi.Enabled = false;
            guardianTelADD.Enabled = false;
            shuoming2.Enabled = false;

        }

    }
    protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox4.Checked)
        {
            CheckBox1.Enabled = false;
            shiNeng.Enabled = true;
            shuoming4.Enabled = true;
        }
        if (!CheckBox4.Checked)
        {
            CheckBox1.Enabled = true;
            shiNeng.Text = "否";
            shuoming4.Text = "";
            shiNeng.Enabled = false;
            shuoming4.Enabled = false;
        }
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox2.Checked)
        {
            illness.Enabled = true;
            illtime.Enabled = true;
            illpay.Enabled = true;
            shuoming1.Enabled = true;
        }
        if (!CheckBox2.Checked)
        {
            illness.Text = "";
            illtime.Text = "";
            illpay.Text = "";
            shuoming1.Text = "";
            illness.Enabled = false;
            illtime.Enabled = false;
            illpay.Enabled = false;
            shuoming1.Enabled = false;
        }
    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox3.Checked)
        {
            canjijibie.Enabled = true;
            canjileibie.Enabled = true;
            shuoming3.Enabled = true;
        }
        if (!CheckBox3.Checked)
        {
            canjijibie.Text = "";
            canjileibie.Text = "";
            shuoming3.Text = "";
            canjijibie.Enabled = false;
            canjileibie.Enabled = false;
            shuoming3.Enabled = false;
        }
    }
    protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox5.Checked)
        {
            timeDis.Enabled = true;
            shiDu.Enabled = true;
            //sonName.Enabled = true;
            //deathReason.Enabled = true;
            shuoming5.Enabled = true;
        }
        if (!CheckBox5.Checked)
        {
            timeDis.Text = "";
            shuoming5.Text = "";
            sonName.Text = "";
            deathReason.Text = "";
            shiDu.Text = "否";
            timeDis.Enabled = false;
            shiDu.Enabled = false;
            sonName.Enabled = false;
            deathReason.Enabled = false;
            shuoming5.Enabled = false;
        }
    }
    protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox6.Checked)
        {
            army.Enabled = true;
            title.Enabled = true;
        }
        if (!CheckBox6.Checked)
        {
            army.Text = "";
            title.Text = "";
            army.Enabled = false;
            title.Enabled = false;
        }
    }
    protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox7.Checked)
        {
            disaster.Enabled = true;
        }
        if (!CheckBox7.Checked)
        {
            disaster.Text = "";
            disaster.Enabled = false;
        }
    }
    protected void shiDu_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (shiDu.Text == "是")
        {
            sonName.Enabled = true;
            deathReason.Enabled = true;
        }
        if (shiDu.Text == "否")
        {
            sonName.Text = "";
            deathReason.Text = "";
            sonName.Enabled = false;
            deathReason.Enabled = false;
        }
    }
    public void mask()
    {
        //助医
        illness.Enabled = false;
        illtime.Enabled = false;
        illpay.Enabled = false;
        shuoming1.Enabled = false;
        //助学
        studySchool.Enabled = false;
        studyGrade.Enabled = false;
        guardianName.Enabled = false;
        guardianGuanxi.Enabled = false;
        guardianTelADD.Enabled = false;
        shuoming2.Enabled = false;
        //助残
        canjijibie.Enabled = false;
        canjileibie.Enabled = false;
        shuoming3.Enabled = false;
        //助老
        shiNeng.Enabled = false;
        shuoming4.Enabled = false;
        //助困
        timeDis.Enabled = false;
        shiDu.Enabled = false;
        sonName.Enabled = false;
        deathReason.Enabled = false;
        shuoming5.Enabled = false;

        army.Enabled = false;
        title.Enabled = false;

        disaster.Enabled = false;
    }

    protected void mod_Click(object sender, EventArgs e)
    {
 //int flag = 1;
        if (!CheckBox1.Checked && !CheckBox2.Checked && !CheckBox3.Checked && !CheckBox4.Checked && !CheckBox5.Checked)
        {
            //LabelError.Text = "请选择受助类型";
            HttpContext.Current.Response.Write("<script>alert('请选择受助类型');</script>");
            return;
            //flag = 0;
        }
        else
        {
            //LabelError.Text = "";
            if (recipientsADD.Text.Length <= 0)
            {
                //LabelError.Text = "未填写受助人户籍";
                HttpContext.Current.Response.Write("<script>alert('未填写受助人户籍');</script>");
                return;
                //flag = 0;
            }
            if (recipientsName.Text.Length <= 0)
            {
                //LabelError.Text = "未填写受助人姓名";
                HttpContext.Current.Response.Write("<script>alert('未填写受助人姓名');</script>");
                return;
                //flag = 0;
            }
            if (recipientsPIdcard.Text.Length <= 0)
            {
                //LabelError.Text = "未填写身份证号";
                HttpContext.Current.Response.Write("<script>alert('未填写身份证号');</script>");
                return;
                //flag = 0;
            }
            if (recipientsADDnow.Text.Length <= 0)
            {
                //LabelError.Text = "未填写现住址";
                HttpContext.Current.Response.Write("<script>alert('未填写现住址');</script>");
                return;
                //flag = 0;
            }
            if (telphoneADD.Text.Length <= 0)
            {
                //LabelError.Text = "未填写联系电话";
                HttpContext.Current.Response.Write("<script>alert('未填写联系电话');</script>");
                return;
                //flag = 0;
            }
            if (workplace.Text.Length <= 0)
            {
                HttpContext.Current.Response.Write("<script>alert('未填写工作单位');</script>");
                return;
            }
            if (arrIncome.Text.Length <= 0)
            {
                //LabelError.Text = "未填写平均月收入";
                HttpContext.Current.Response.Write("<script>alert('未填写平均月收入');</script>");
                return;
                //flag = 0;
            }
            if (CheckBox2.Checked)
            {
                if (illness.Text.Length <= 0)
                {
                    //LabelError.Text = "未填写大病种类";
                    HttpContext.Current.Response.Write("<script>alert('未填写大病种类');</script>");
                    return;
                    //flag = 0;
                }
                if (illtime.Text.Length <= 0)
                {
                    //LabelError.Text = "未填写就诊时间";
                    HttpContext.Current.Response.Write("<script>alert('未填写就诊时间');</script>");
                    return;
                    //flag = 0;
                }
                if (illpay.Text.Length <= 0)
                {
                    //LabelError.Text = "未填写花费数额";
                    HttpContext.Current.Response.Write("<script>alert('未填写花费数额');</script>");
                    return;
                    //flag = 0;
                }
            }
            if (CheckBox1.Checked)
            {
                if (studySchool.Text.Length <= 0)
                {
                    //LabelError.Text = "未填写就读学校";
                    HttpContext.Current.Response.Write("<script>alert('未填写就读学校');</script>");
                    return;
                    //flag = 0;
                }
                if (studyGrade.Text.Length <= 0)
                {
                    //LabelError.Text = "未填写就读年级";
                    HttpContext.Current.Response.Write("<script>alert('未填写就读年级');</script>");
                    return;
                    //flag = 0;
                }
                if (guardianName.Text.Length <= 0)
                {
                    //LabelError.Text = "未填写与被监护人姓名";
                    HttpContext.Current.Response.Write("<script>alert('未填写与被监护人姓名');</script>");
                    return;
                    //flag = 0;
                }
                if (guardianGuanxi.Text.Length <= 0)
                {
                    //LabelError.Text = "未填写与被监护人关系";
                    HttpContext.Current.Response.Write("<script>alert('未填写与被监护人关系');</script>");
                    return;
                    //flag = 0;
                }
                if (guardianTelADD.Text.Length <= 0)
                {
                    //LabelError.Text = "未填写监护人电话";
                    HttpContext.Current.Response.Write("<script>alert('未填写监护人电话');</script>");
                    return;
                    //flag = 0;
                }
            }
            if (CheckBox3.Checked)
            {
                if (canjijibie.Text.Length <= 0)
                {
                    //LabelError.Text = "未填写残疾级别";
                    HttpContext.Current.Response.Write("<script>alert('未填写残疾级别');</script>");
                    return;
                    //flag = 0;
                }
                if (canjileibie.Text.Length <= 0)
                {
                    //LabelError.Text = "未填写残疾类别";
                    HttpContext.Current.Response.Write("<script>alert('未填写残疾类别');</script>");
                    return;
                    //flag = 0;
                }
            }
            if (CheckBox5.Checked)
            {
                if (shiDu.Text == "是")
                {
                    if (sonName.Text.Length <= 0)
                    {
                        //LabelError.Text = "未填写子女姓名";
                        HttpContext.Current.Response.Write("<script>alert('未填写子女姓名');</script>");
                        return;
                        //flag = 0;
                    }
                    if (deathReason.Text.Length <= 0)
                    {
                        //LabelError.Text = "未填写死亡原因";
                        HttpContext.Current.Response.Write("<script>alert('未填写死亡原因');</script>");
                        return;
                        //flag = 0;
                    }
                }
            }
            if (CheckBox6.Checked)
            {
                if (army.Text.Length <= 0)
                {
                    HttpContext.Current.Response.Write("<script>alert('未填写部队名称');</script>");
                    return;
                }
                if (title.Text.Length <= 0)
                {
                    HttpContext.Current.Response.Write("<script>alert('未填写职位');</script>");
                    return;
                }
            }
            if (CheckBox7.Checked)
            {
                if (disaster.Text.Length <= 0)
                {
                    HttpContext.Current.Response.Write("<script>alert('未填写灾害名称');</script>");
                    return;
                }
            }
            #region
            //if(famIncome1.Text.Length<=0)
            //{
            //    LabelError.Text = "未填写成员收入1";
            //    flag = 0;
            //}
            //if(famWork1.Text.Length<=0)
            //{
            //    LabelError.Text = "未填写成员职业1";
            //    flag = 0;
            //}
            //if(famTel1.Text.Length <= 0)
            //{     
            //    LabelError.Text = "未填写成员联系方式1";
            //    flag = 0;
            //}
            ////if (famWorkplace1.Text.Length <= 0)
            ////{
            ////    LabelError.Text = "未填写成员工作单位1";
            ////}
            //if (famRelation1.Text.Length <= 0)
            //{
            //    LabelError.Text = "未填写与本人关系1";
            //    flag = 0;
            //}
            //if (famName1.Text.Length <= 0)
            //{
            //    LabelError.Text = "未填写家庭成员姓名1";
            //    flag = 0;
            //}
            #endregion
        }
        //if(flag==1)//信息填写完
        //{ 
        #region
        //数据入库
        string str113 = string.Format("update e_recipients set benfactorFrom='{0}',recipientsADD='{1}',recipientsName='{2}',sex='{3}',recipientsPIdcard='{4}',recipientsADDnow='{5}',incomlowID='{6}',telphoneADD='{7}',workplace='{8}',famName1='{9}',famRelation1='{10}',famWorkplace1='{11}',famTel1='{12}',famWork1='{13}',famIncome1='{14}',famName2='{15}',famRelation2='{16}',famWorkplace2='{17}',famTel2='{18}',famWork2='{19}',famIncome2='{20}',famName3='{21}',famRelation3='{22}',famWorkplace3='{23}',famTel3='{24}',famWork3='{25}',famIncome3='{26}',famName4='{27}',famRelation4='{28}',famWorkplace4='{29}',famTel4='{30}',famWork4='{31}',famIncome4='{32}',arrIncome='{33}',marryNow='{34}',canjijibie='{35}',canjileibie='{36}',shuoming3='{37}',illness='{38}',illtime='{39}',illpay='{40}',shuoming1='{41}',timeDis='{42}',shiDu='{43}',sonName='{44}',deathReason='{45}',shuoming5='{46}',shiNeng='{47}',shuoming4='{48}',studySchool='{49}',studyGrade='{50}',guardianName='{51}',guardianGuanxi='{52}',guardianTelADD='{53}',shuoming2='{54}',reason='{55}' where recipientsID='{56}'", benfactorFrom.SelectedValue.Trim(), recipientsADD.Text, recipientsName.Text, sex.Text, recipientsPIdcard.Text, recipientsADDnow.Text, incomlowID.Text, telphoneADD.Text, workplace.Text, famName1.Text, famRelation1.Text, famWorkplace1.Text, famTel1.Text, famWork1.Text, famIncome1.Text, famName2.Text, famRelation2.Text, famWorkplace2.Text, famTel2.Text, famWork2.Text, famIncome2.Text, famName3.Text, famRelation3.Text, famWorkplace3.Text, famTel3.Text, famWork3.Text, famIncome3.Text, famName4.Text, famRelation4.Text, famWorkplace4.Text, famTel4.Text, famWork4.Text, famIncome4.Text, arrIncome.Text, marryNow.Text, canjijibie.Text, canjileibie.Text, shuoming3.Text, illness.Text, illtime.Text, illpay.Text, shuoming1.Text, timeDis.Text, shiDu.Text, sonName.Text, deathReason.Text, shuoming5.Text, shiNeng.Text, shuoming4.Text, studySchool.Text, studyGrade.Text, guardianName.Text, guardianGuanxi.Text, guardianTelADD.Text, shuoming2.Text, reason.Text, ViewState["IDNow"].ToString());
        int res = msq.getmysqlcom(str113);
        if (CheckBox1.Checked)
        {
            string str114 = string.Format("update e_recipients set isstu=1 where recipientsID='{0}'", ViewState["IDNow"].ToString());
            msq.getmysqlcom(str114);
        }
        else
        {
            string str1141 = string.Format("update e_recipients set isstu=0 where recipientsID='{0}'", ViewState["IDNow"].ToString());
            msq.getmysqlcom(str1141);
        }

        if (CheckBox2.Checked)
        {
            string str115 = string.Format("update e_recipients set isdoc=1 where recipientsID='{0}'", ViewState["IDNow"].ToString());
            msq.getmysqlcom(str115);
        }
        else
        {
            string str1151 = string.Format("update e_recipients set isdoc=0 where recipientsID='{0}'", ViewState["IDNow"].ToString());
            msq.getmysqlcom(str1151);
        }

        if (CheckBox3.Checked)
        {
            string str116 = string.Format("update e_recipients set iscan=1 where recipientsID='{0}'", ViewState["IDNow"].ToString());
            msq.getmysqlcom(str116);
        }
        else
        {
            string str1161 = string.Format("update e_recipients set iscan=0 where recipientsID='{0}'", ViewState["IDNow"].ToString());
            msq.getmysqlcom(str1161);
        }

        if (CheckBox4.Checked)
        {
            string str117 = string.Format("update e_recipients set isold=1 where recipientsID='{0}'", ViewState["IDNow"].ToString());
            msq.getmysqlcom(str117);
        }
        else
        {
            string str1171 = string.Format("update e_recipients set isold=0 where recipientsID='{0}'", ViewState["IDNow"].ToString());
            msq.getmysqlcom(str1171);
        }

        if (CheckBox5.Checked)
        {
            string str118 = string.Format("update e_recipients set iskun=1 where recipientsID='{0}'", ViewState["IDNow"].ToString());
            msq.getmysqlcom(str118);
        }
        else
        {
            string str1181 = string.Format("update e_recipients set iskun=0 where recipientsID='{0}'", ViewState["IDNow"].ToString());
            msq.getmysqlcom(str1181);
        }

        if (res > 0)
        {
            NLogTest nlog = new NLogTest();
            string sss = "修改了受助人信息：" + recipientsName.Text.ToString();
            nlog.WriteLog(Session["UserName"].ToString(),sss);
            HttpContext.Current.Response.Write("<script>alert('受助人信息修改成功');</script>");
        }
        else
        {
            HttpContext.Current.Response.Write("<script>alert('受助人信息修改失败');</script>");
        }
        ////数据入库之后的操作
        //foreach (System.Web.UI.Control stl in this.Form.Controls)
        //{
        //    if (stl is System.Web.UI.WebControls.TextBox)
        //    {
        //        TextBox tb = (TextBox)stl;
        //        tb.Text = "";
        //    }
        //}
        //CheckBox1.Checked = CheckBox2.Checked = CheckBox3.Checked = CheckBox4.Checked = CheckBox5.Checked = false;
        //CheckBox1.Enabled = CheckBox4.Enabled = true;
        //shiNeng.Text = shiDu.Text = "否";
        //mask();
        #endregion


        //}
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


    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("查询受助人.aspx");
    }
}