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
        if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
        {
            Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
            return;
        }
        if (!Page.IsPostBack)//页面首次加载
        {
            //databind();
            benfactorFrom.Items.Add(Session["benfactorFrom"].ToString());
            mask();
            tablefamily.Visible = false;
            if(Session["userRole"].ToString()!="4")//不是管理员
            {//不能批量添加受助人
                Label2.Visible = Button2.Visible = false;
            }
        }
    }
    public void mask()
    {
        //不显示其他扩展信息
        trold.Visible = trcan1.Visible = trcan2.Visible = trdoc1.Visible = trdoc2.Visible = trstu1.Visible = trstu2.Visible = trstu3.Visible = trkun1.Visible = trkun2.Visible = trkun3.Visible = tryong1.Visible = tryong2.Visible = trdst.Visible = false;

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
        canjiID.Enabled = false;
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
        tbOfficerID.Enabled = false;

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
    {//助学
        if (CheckBox1.Checked)
        {
            trstu1.Visible = trstu2.Visible = trstu3.Visible = true;
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
            trstu1.Visible = trstu2.Visible = trstu3.Visible = false;
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
    {//助老
        if (CheckBox4.Checked)
        {
            trold.Visible = true;
            CheckBox1.Enabled = false;
            shiNeng.Enabled = true;
            shuoming4.Enabled = true;
        }
        if (!CheckBox4.Checked)
        {
            trold.Visible = false;
            CheckBox1.Enabled = true;
            shiNeng.Text = "否";
            shuoming4.Text = "";
            shiNeng.Enabled = false;
            shuoming4.Enabled = false;
        }
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {//助医
        if(CheckBox2.Checked)
        {
            trdoc1.Visible = trdoc2.Visible = true;
            illness.Enabled = true;
            illtime.Enabled = true;
            illpay.Enabled = true;
            shuoming1.Enabled = true;
        }
        if(!CheckBox2.Checked)
        {
            trdoc1.Visible = trdoc2.Visible = false;
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
    {//助残
        if(CheckBox3.Checked)
        {
            trcan1.Visible = trcan2.Visible = true;
            canjijibie.Enabled = true;
            canjileibie.Enabled = true;
            shuoming3.Enabled = true;
            canjiID.Enabled = true;
        }
        if(!CheckBox3.Checked)
        {
            trcan1.Visible = trcan2.Visible = false;
            canjijibie.Text = "";
            canjileibie.Text = "";
            shuoming3.Text = "";
            canjiID.Text = "";
            canjijibie.Enabled = false;
            canjileibie.Enabled = false;
            shuoming3.Enabled = false;
            canjiID.Enabled = false;
        }
    }
    protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
    {//助困
        if(CheckBox5.Checked)
        {
            trkun1.Visible = trkun2.Visible = trkun3.Visible = true;
            timeDis.Enabled = true;
            shiDu.Enabled = true;
            //sonName.Enabled = true;
            //deathReason.Enabled = true;
            shuoming5.Enabled = true;
        }
        if(!CheckBox5.Checked)
        {
            trkun1.Visible = trkun2.Visible = trkun3.Visible = false;
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
    {//双拥
        if(CheckBox6.Checked)
        {
            tryong1.Visible = tryong2.Visible = true;
            army.Enabled = true;
            title.Enabled = true;
            tbOfficerID.Enabled = true;
        }
        if(!CheckBox6.Checked)
        {
            tryong1.Visible = tryong2.Visible = false;
            army.Text = "";
            title.Text = "";
            tbOfficerID.Text = "";
            army.Enabled = false;
            title.Enabled = false;
            tbOfficerID.Enabled = false;
        }
    }
    protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
    {//重特大灾害
        if(CheckBox7.Checked)
        {
            trdst.Visible = true;
            disaster.Enabled = true;
        }
        if(!CheckBox7.Checked)
        {
            trdst.Visible = false;
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
    private void ClearText(ControlCollection Controls)
    {
        foreach (Control item in Controls)
        {
            if (item.Controls.Count > 0)
            {
                ClearText(item.Controls);
            }

            if (item is TextBox)
            {
                ((TextBox)item).Text = "";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //int flag = 1;
        if (!CheckBox1.Checked && !CheckBox2.Checked && !CheckBox3.Checked && !CheckBox4.Checked && !CheckBox5.Checked && !CheckBox6.Checked && !CheckBox7.Checked)
        {
            //LabelError.Text = "请选择受助类型";
            HttpContext.Current.Response.Write("<script>alert('请选择受助类型');</script>");
            return;
            //flag = 0;
        }
        else
        {
            //LabelError.Text = "";
            if (recipientsADD.Text.Trim() == "")
            {
                //LabelError.Text = "未填写受助人户籍";
                HttpContext.Current.Response.Write("<script>alert('未填写受助人户籍');</script>");
                recipientsADD.BackColor = Color.FromArgb((int)0xFFE1FF);
                recipientsADD.Focus();
                return;
                //flag = 0;
            }
            else 
            {
                recipientsADD.BackColor = Color.White;
            }

            if (recipientsName.Text.Trim() == "")
            {
                //LabelError.Text = "未填写受助人姓名";
                HttpContext.Current.Response.Write("<script>alert('未填写受助人姓名');</script>");
                recipientsName.BackColor = Color.FromArgb((int)0xFFE1FF);
                recipientsName.Focus();
                return;
                //flag = 0;
            }
            else
            {
                recipientsName.BackColor = Color.White;
            }
            //验证第二代身份证，共18位
            Regex pidReg = new Regex("(^\\d{18}$)|(^\\d{17}(\\d|X)$)");
            if (recipientsPIdcard.Text.Trim()=="")
            {
                //LabelError.Text = "未填写身份证号";
                HttpContext.Current.Response.Write("<script>alert('未填写身份证号');</script>");
                recipientsPIdcard.BackColor = Color.FromArgb((int)0xFFE1FF);
                recipientsPIdcard.Focus();
                return;
                //flag = 0;
            }
            else
            {
                if(pidReg.IsMatch(recipientsPIdcard.Text.Trim()))
                    recipientsPIdcard.BackColor = Color.White;//验证通过
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('身份证号格式不对，第二代身份证由18位组成（最后一位的X为大写）');</script>");
                	recipientsPIdcard.BackColor = Color.FromArgb((int)0xFFE1FF);
                	recipientsPIdcard.Focus();
					return;
                }
            }
            if (recipientsADDnow.Text.Trim() == "")
            {
                //LabelError.Text = "未填写现住址";
                HttpContext.Current.Response.Write("<script>alert('未填写现住址');</script>");
                recipientsPIdcard.BackColor = Color.FromArgb((int)0xFFE1FF);
                recipientsPIdcard.Focus();
                return;
                //flag = 0;
            }
            else
            {
                recipientsPIdcard.BackColor = Color.White;
            }

            if (telphoneADD.Text.Trim() == "")
            {
                //LabelError.Text = "未填写联系电话";
                HttpContext.Current.Response.Write("<script>alert('未填写联系电话');</script>");
                telphoneADD.BackColor = Color.FromArgb((int)0xFFE1FF);
                telphoneADD.Focus();
                return;
                //flag = 0;
            }
            else
            {
                telphoneADD.BackColor = Color.White;
            }

            if (workplace.Text.Trim() == "")
            {
                HttpContext.Current.Response.Write("<script>alert('未填写工作单位');</script>");
                workplace.BackColor = Color.FromArgb((int)0xFFE1FF);
                workplace.Focus();
                return;
            }
            else
            {
                workplace.BackColor = Color.White;
            }

            if (arrIncome.Text.Trim() == "")
            {
                //LabelError.Text = "未填写平均月收入";
                HttpContext.Current.Response.Write("<script>alert('未填写平均月收入');</script>");
                arrIncome.BackColor = Color.FromArgb((int)0xFFE1FF);
                arrIncome.Focus();
                return;
                //flag = 0;
            }
            else
            {
                arrIncome.BackColor = Color.White;
            }

            if (CheckBox2.Checked)
            {
                if (illness.Text.Trim() == "")
                {
                    //LabelError.Text = "未填写大病种类";
                    HttpContext.Current.Response.Write("<script>alert('未填写大病种类');</script>");
                    illness.BackColor = Color.FromArgb((int)0xFFE1FF);
                    illness.Focus();
                    return;
                    //flag = 0;
                }
                else
                {
                    illness.BackColor = Color.White;
                }

                if (illtime.Text.Trim() == "")
                {
                    //LabelError.Text = "未填写就诊时间";
                    HttpContext.Current.Response.Write("<script>alert('未填写就诊时间');</script>");
                    illtime.BackColor = Color.FromArgb((int)0xFFE1FF);
                    illtime.Focus();
                    return;
                    //flag = 0;
                }
                else
                {
                    illtime.BackColor = Color.White;
                }

                if (illpay.Text.Trim() == "")
                {
                    //LabelError.Text = "未填写花费数额";
                    HttpContext.Current.Response.Write("<script>alert('未填写花费数额');</script>");
                    illpay.BackColor = Color.FromArgb((int)0xFFE1FF);
                    illpay.Focus();
                    return;
                    //flag = 0;
                }
                else
                {
                    illpay.BackColor = Color.White;
                }
            }
            if (CheckBox1.Checked)
            {
                if (studySchool.Text.Trim() == "")
                {
                    //LabelError.Text = "未填写就读学校";
                    HttpContext.Current.Response.Write("<script>alert('未填写就读学校');</script>");
                    studySchool.BackColor = Color.FromArgb((int)0xFFE1FF);
                    studySchool.Focus();
                    return;
                    //flag = 0;
                }
                else
                {
                    studySchool.BackColor = Color.White;
                }

                if (studyGrade.Text.Trim() == "")
                {
                    //LabelError.Text = "未填写就读年级";
                    HttpContext.Current.Response.Write("<script>alert('未填写就读年级');</script>");
                    studyGrade.BackColor = Color.FromArgb((int)0xFFE1FF);
                    studyGrade.Focus();
                    return;
                    //flag = 0;
                }
                else
                {
                    studyGrade.BackColor = Color.White;
                }

                if (guardianName.Text.Trim() == "")
                {
                    //LabelError.Text = "未填写与被监护人姓名";
                    HttpContext.Current.Response.Write("<script>alert('未填写与被监护人姓名');</script>");
                    guardianName.BackColor = Color.FromArgb((int)0xFFE1FF);
                    guardianName.Focus();
                    return;
                    //flag = 0;
                }
                else
                {
                    guardianName.BackColor = Color.White;
                }

                if (guardianGuanxi.Text.Trim() == "")
                {
                    //LabelError.Text = "未填写与被监护人关系";
                    HttpContext.Current.Response.Write("<script>alert('未填写与被监护人关系');</script>");
                    guardianGuanxi.BackColor = Color.FromArgb((int)0xFFE1FF);
                    guardianGuanxi.Focus();
                    return;
                    //flag = 0;
                }
                else
                {
                    guardianGuanxi.BackColor = Color.White;
                }

                if (guardianTelADD.Text.Trim() == "")
                {
                    //LabelError.Text = "未填写监护人电话";
                    HttpContext.Current.Response.Write("<script>alert('未填写监护人电话');</script>");
                    guardianTelADD.BackColor = Color.FromArgb((int)0xFFE1FF);
                    guardianTelADD.Focus();
                    return;
                    //flag = 0;
                }
                else
                {
                    guardianTelADD.BackColor = Color.White;
                }
            }

            if (CheckBox3.Checked)
            {
                if (canjijibie.Text.Trim() == "")
                {
                    //LabelError.Text = "未填写残疾级别";
                    HttpContext.Current.Response.Write("<script>alert('未填写残疾级别');</script>");
                    canjijibie.BackColor = Color.FromArgb((int)0xFFE1FF);
                    canjijibie.Focus();
                    return;
                    //flag = 0;
                }
                else
                {
                    canjijibie.BackColor = Color.White;
                }

                if (canjileibie.Text.Trim() == "")
                {
                    //LabelError.Text = "未填写残疾类别";
                    HttpContext.Current.Response.Write("<script>alert('未填写残疾类别');</script>");
                    canjileibie.BackColor = Color.FromArgb((int)0xFFE1FF);
                    canjileibie.Focus();
                    return;
                    //flag = 0;
                }
                else
                {
                    canjileibie.BackColor = Color.White;
                }
            }
            if (CheckBox5.Checked)
            {
                if (shiDu.Text == "是")
                {
                    if (sonName.Text.Trim() == "")
                    {
                        //LabelError.Text = "未填写子女姓名";
                        HttpContext.Current.Response.Write("<script>alert('未填写子女姓名');</script>");
                        sonName.BackColor = Color.FromArgb((int)0xFFE1FF);
                        sonName.Focus();
                        return;
                        //flag = 0;
                    }
                    else
                    {
                        sonName.BackColor = Color.White;
                    }

                    if (deathReason.Text.Trim() == "")
                    {
                        //LabelError.Text = "未填写死亡原因";
                        HttpContext.Current.Response.Write("<script>alert('未填写死亡原因');</script>");
                        deathReason.BackColor = Color.FromArgb((int)0xFFE1FF);
                        deathReason.Focus();
                        return;
                        //flag = 0;
                    }
                    else
                    {
                        deathReason.BackColor = Color.White;
                    }
                }
            }
            if(CheckBox6.Checked)
            {
                if (army.Text.Trim() == "")
                {
                    HttpContext.Current.Response.Write("<script>alert('未填写部队名称');</script>");
                    army.BackColor = Color.FromArgb((int)0xFFE1FF);
                    army.Focus();
                    return;
                }
                else
                {
                    army.BackColor = Color.White;
                }

                if (title.Text.Trim() == "")
                {
                    HttpContext.Current.Response.Write("<script>alert('未填写职位');</script>");
                    title.BackColor = Color.FromArgb((int)0xFFE1FF);
                    title.Focus();
                    return;
                }
                else
                {
                    title.BackColor = Color.White;
                }
            }

            if(CheckBox7.Checked)
            {
                if (disaster.Text.Trim() == "")
                {
                    HttpContext.Current.Response.Write("<script>alert('未填写灾害名称');</script>");
                    disaster.BackColor = Color.FromArgb((int)0xFFE1FF);
                    disaster.Focus();
                    return;
                }
                else
                {
                    disaster.BackColor = Color.White;
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
        string strName = Regex.Replace(recipientsName.Text.ToString(), @"\s", "");
        string str113 = string.Format("insert into e_recipients (benfactorFrom,recipientsADD,recipientsName,sex,recipientsPIdcard,recipientsADDnow,incomlowID,telphoneADD,workplace,famName1,famRelation1,famWorkplace1,famTel1,famWork1,famIncome1,famName2,famRelation2,famWorkplace2,famTel2,famWork2,famIncome2,famName3,famRelation3,famWorkplace3,famTel3,famWork3,famIncome3,famName4,famRelation4,famWorkplace4,famTel4,famWork4,famIncome4,arrIncome,marryNow,canjijibie,canjileibie,shuoming3,illness,illtime,illpay,shuoming1,timeDis,shiDu,sonName,deathReason,shuoming5,shiNeng,shuoming4,studySchool,studyGrade,guardianName,guardianGuanxi,guardianTelADD,shuoming2,reason,army,title,disaster,canID,officerID) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}')", benfactorFrom.Text.Trim(), recipientsADD.Text.Trim(), strName, sex.Text.Trim(), recipientsPIdcard.Text.Trim(), recipientsADDnow.Text.Trim(), incomlowID.Text.Trim(), telphoneADD.Text.Trim(), workplace.Text.Trim(), famName1.Text.Trim(), famRelation1.Text.Trim(), famWorkplace1.Text.Trim(), famTel1.Text.Trim(), famWork1.Text.Trim(), famIncome1.Text.Trim(), famName2.Text.Trim(), famRelation2.Text.Trim(), famWorkplace2.Text.Trim(), famTel2.Text.Trim(), famWork2.Text.Trim(), famIncome2.Text.Trim(), famName3.Text.Trim(), famRelation3.Text.Trim(), famWorkplace3.Text.Trim(), famTel3.Text.Trim(), famWork3.Text.Trim(), famIncome3.Text.Trim(), famName4.Text.Trim(), famRelation4.Text.Trim(), famWorkplace4.Text.Trim(), famTel4.Text.Trim(), famWork4.Text.Trim(), famIncome4.Text.Trim(), arrIncome.Text.Trim(), marryNow.Text.Trim(), canjijibie.Text.Trim(), canjileibie.Text.Trim(), shuoming3.Text.Trim(), illness.Text.Trim(), illtime.Text.Trim(), illpay.Text.Trim(), shuoming1.Text.Trim(), timeDis.Text.Trim(), shiDu.Text.Trim(), sonName.Text.Trim(), deathReason.Text.Trim(), shuoming5.Text.Trim(), shiNeng.Text.Trim(), shuoming4.Text.Trim(), studySchool.Text.Trim(), studyGrade.Text.Trim(), guardianName.Text.Trim(), guardianGuanxi.Text.Trim(), guardianTelADD.Text.Trim(), shuoming2.Text.Trim(), reason.Text.Trim(), army.Text.Trim(), title.Text.Trim(), disaster.Text.Trim(), canjiID.Text.Trim(),tbOfficerID.Text.Trim());
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
            string str114 = string.Format("update e_recipients set isstu=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text.Trim());
            msq.getmysqlcom(str114);
        }
        if (CheckBox2.Checked)
        {
            string str115 = string.Format("update e_recipients set isdoc=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text.Trim());
            msq.getmysqlcom(str115);
        }
        if (CheckBox3.Checked)
        {
            string str116 = string.Format("update e_recipients set iscan=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text.Trim());
            msq.getmysqlcom(str116);
        }
        if (CheckBox4.Checked)
        {
            string str117 = string.Format("update e_recipients set isold=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text.Trim());
            msq.getmysqlcom(str117);
        }
        if (CheckBox5.Checked)
        {
            string str118 = string.Format("update e_recipients set iskun=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text.Trim());
            msq.getmysqlcom(str118);
        }
        if(CheckBox6.Checked)
        {
            string str119 = string.Format("update e_recipients set isyong=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text.Trim());
            msq.getmysqlcom(str119);
        }
        if (CheckBox7.Checked)
        {
            string str120 = string.Format("update e_recipients set isdst=1 where recipientsPIdcard='{0}'", recipientsPIdcard.Text.Trim());
            msq.getmysqlcom(str120);
        }
        if (res > 0)
        {
            NLogTest nlog = new NLogTest();
            string sss = "添加了受助人：" + strName;
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
        ClearText(Controls);
        //foreach (System.Web.UI.Control stl in this.Controls)//this.Form.Controls
        //{
        //    if (stl is System.Web.UI.WebControls.TextBox)
        //    {
        //        TextBox tb = (TextBox)stl;
        //        tb.Text = "";
        //    }
        //}
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

    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("批量添加受助人.aspx");
    }
}