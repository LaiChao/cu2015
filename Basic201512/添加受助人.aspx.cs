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

public partial class Basic201512_添加受助人 : System.Web.UI.Page
{

    mysqlconn msq = new mysqlconn();
    //string str111 = "select benfactorFrom from e_handlingunit where benfactorFrom='" + Session["benfactorFrom"] + "'";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)//页面首次加载
        {
            //databind();
            benfactorFrom.Items.Add(Session["benfactorFrom"].ToString());
            mask();
            tablefamily.Visible = false;
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
    //public void databind()
    //{
    //    MySqlConnection mysqlcon = msq.getmysqlcon();
    //    DataSet ds = MySqlHelper.ExecuteDataset(mysqlcon, str111);
    //    DataView dv = new DataView(ds.Tables[0]);
    //    benfactorFrom.DataSource = dv;
    //    benfactorFrom.DataTextField = "benfactorFrom"; 
    //    benfactorFrom.DataBind();
    //}
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
        if(!CheckBox1.Checked)
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
        if(CheckBox2.Checked)
        {
            illness.Enabled = true;
            illtime.Enabled = true;
            illpay.Enabled = true;
            shuoming1.Enabled = true;
        }
        if(!CheckBox2.Checked)
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
        if(CheckBox3.Checked)
        {
            canjijibie.Enabled = true;
            canjileibie.Enabled = true;
            shuoming3.Enabled = true;
        }
        if(!CheckBox3.Checked)
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
        if(CheckBox5.Checked)
        {
            timeDis.Enabled = true;
            shiDu.Enabled = true;
            //sonName.Enabled = true;
            //deathReason.Enabled = true;
            shuoming5.Enabled = true;
        }
        if(!CheckBox5.Checked)
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
        if(CheckBox6.Checked)
        {
            army.Enabled = true;
            title.Enabled = true;
        }
        if(!CheckBox6.Checked)
        {
            army.Text = "";
            title.Text = "";
            army.Enabled = false;
            title.Enabled = false;
        }
    }
    protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
    {
        if(CheckBox7.Checked)
        {
            disaster.Enabled = true;
        }
        if(!CheckBox7.Checked)
        {
            disaster.Text = "";
            disaster.Enabled = false;
        }
    }
    protected void shiDu_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(shiDu.Text=="是")
        {
            sonName.Enabled = true;
            deathReason.Enabled = true;
        }
        if(shiDu.Text=="否")
        {
            sonName.Text = "";
            deathReason.Text = "";
            sonName.Enabled = false;
            deathReason.Enabled = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
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
            if(workplace.Text.Length<=0)
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
            if(CheckBox6.Checked)
            {
                if(army.Text.Length<=0)
                {
                    HttpContext.Current.Response.Write("<script>alert('未填写部队名称');</script>");
                    return;
                }
                if(title.Text.Length<=0)
                {
                    HttpContext.Current.Response.Write("<script>alert('未填写职位');</script>");
                    return;
                }
            }
            if(CheckBox7.Checked)
            {
                if(disaster.Text.Length<=0)
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
        string str113 = string.Format("insert into e_recipients (benfactorFrom,recipientsADD,recipientsName,sex,recipientsPIdcard,recipientsADDnow,incomlowID,telphoneADD,workplace,famName1,famRelation1,famWorkplace1,famTel1,famWork1,famIncome1,famName2,famRelation2,famWorkplace2,famTel2,famWork2,famIncome2,famName3,famRelation3,famWorkplace3,famTel3,famWork3,famIncome3,famName4,famRelation4,famWorkplace4,famTel4,famWork4,famIncome4,arrIncome,marryNow,canjijibie,canjileibie,shuoming3,illness,illtime,illpay,shuoming1,timeDis,shiDu,sonName,deathReason,shuoming5,shiNeng,shuoming4,studySchool,studyGrade,guardianName,guardianGuanxi,guardianTelADD,shuoming2,reason,army,title,disaster) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}')", benfactorFrom.Text, recipientsADD.Text, recipientsName.Text, sex.Text, recipientsPIdcard.Text, recipientsADDnow.Text, incomlowID.Text, telphoneADD.Text, workplace.Text, famName1.Text, famRelation1.Text, famWorkplace1.Text, famTel1.Text, famWork1.Text, famIncome1.Text, famName2.Text, famRelation2.Text, famWorkplace2.Text, famTel2.Text, famWork2.Text, famIncome2.Text, famName3.Text, famRelation3.Text, famWorkplace3.Text, famTel3.Text, famWork3.Text, famIncome3.Text, famName4.Text, famRelation4.Text, famWorkplace4.Text, famTel4.Text, famWork4.Text, famIncome4.Text, arrIncome.Text, marryNow.Text, canjijibie.Text, canjileibie.Text, shuoming3.Text, illness.Text, illtime.Text, illpay.Text, shuoming1.Text, timeDis.Text, shiDu.Text, sonName.Text, deathReason.Text, shuoming5.Text, shiNeng.Text, shuoming4.Text, studySchool.Text, studyGrade.Text, guardianName.Text, guardianGuanxi.Text, guardianTelADD.Text, shuoming2.Text, reason.Text, army.Text, title.Text, disaster.Text);
        int res = -1;
        try
        {
            res = msq.getmysqlcom(str113);
        }
        catch(MySqlException ex)
        {
            HttpContext.Current.Response.Write("<script>alert('身份证号重复了');</script>");
            //throw ex;
            return;
        }
        if (CheckBox1.Checked)
        {
            string str114 = string.Format("update e_recipients set isstu=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text);
            msq.getmysqlcom(str114);
        }
        if (CheckBox2.Checked)
        {
            string str115 = string.Format("update e_recipients set isdoc=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text);
            msq.getmysqlcom(str115);
        }
        if (CheckBox3.Checked)
        {
            string str116 = string.Format("update e_recipients set iscan=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text);
            msq.getmysqlcom(str116);
        }
        if (CheckBox4.Checked)
        {
            string str117 = string.Format("update e_recipients set isold=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text);
            msq.getmysqlcom(str117);
        }
        if (CheckBox5.Checked)
        {
            string str118 = string.Format("update e_recipients set iskun=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text);
            msq.getmysqlcom(str118);
        }
        if(CheckBox6.Checked)
        {
            string str119 = string.Format("update e_recipients set isyong=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text);
            msq.getmysqlcom(str119);
        }
        if (CheckBox7.Checked)
        {
            string str120 = string.Format("update e_recipients set isdst=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text);
            msq.getmysqlcom(str120);
        }
        if (res > 0)
        {
            NLogTest nlog = new NLogTest();
            string sss = "添加了受助人：" + recipientsName.Text.ToString();
            nlog.WriteLog(Session["UserName"].ToString(),sss);
            //LabelError.Text = "受助人添加成功";
            HttpContext.Current.Response.Write("<script>alert('受助人添加成功');</script>");
        }
        else
        {
            //LabelError.Text = "受助人添加失败";
            HttpContext.Current.Response.Write("<script>alert('受助人添加失败');</script>");
        }
        //数据入库之后的操作
        foreach (System.Web.UI.Control stl in this.Form.Controls)
        {
            if (stl is System.Web.UI.WebControls.TextBox)
            {
                TextBox tb = (TextBox)stl;
                tb.Text = "";
            }
        }
        CheckBox1.Checked = CheckBox2.Checked = CheckBox3.Checked = CheckBox4.Checked = CheckBox5.Checked = CheckBox6.Checked = CheckBox7.Checked = false;
        CheckBox1.Enabled = CheckBox4.Enabled = true;
        shiNeng.Text = shiDu.Text = "否";
        mask();
        #endregion


        //}
    }
    //protected void Button3_Click(object sender, EventArgs e)
    //{
    //    this.tablefamily.Visible = false;
    //}
    //protected void Button4_Click(object sender, EventArgs e)
    //{
    //    this.tablefamily.Visible = true;
    //}


    protected void familylist_Click(object sender, EventArgs e)
    {
        if(familylist.Text=="-")
        {
            familylist.Text = "+";
            this.tablefamily.Visible = false;
            return;
        }
        if(familylist.Text=="+")
        {
            familylist.Text = "-";
            this.tablefamily.Visible = true;
            return;
        }
    }
}