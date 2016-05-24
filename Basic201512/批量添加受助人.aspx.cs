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
using System.Data.OleDb;
using System.Diagnostics;

public partial class Basic201512_批量添加受助人 : System.Web.UI.Page
{
    mysqlconn msq = new mysqlconn();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 连接Excel  读取Excel数据   并返回DataSet数据集合
    /// <summary>
    /// 连接Excel  读取Excel数据   并返回DataSet数据集合
    /// </summary>
    /// <param name="filepath">Excel服务器路径</param>
    /// <param name="tableName">Excel表名称</param>
    /// <returns></returns>
    public static System.Data.DataSet ExcelSqlConnection(string filepath, string tableName)
    {
        //string strCon = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
        // string strConn = "Provider=Microsoft.Jet.OleDb.4.0;data source=" + filename + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
        //string strCon = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=" + filepath + ";Extended Properties='Excel 12.0 Xml;HDR=NO'";
        string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';";
        OleDbConnection ExcelConn = new OleDbConnection(strCon);
        try
        {
            string strCom = string.Format("SELECT * FROM [Sheet1$]");
            ExcelConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, ExcelConn);
            DataSet ds = new DataSet();
            //myCommand.Fill(ds, "[" + tableName + "$]");
            myCommand.Fill(ds, tableName);
            return ds;
            ExcelConn.Close();//?
        }
        catch
        {
            ExcelConn.Close();
            return null;
        }
    }
    #endregion

    protected void btnImport_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
        {
            Response.Write("<script>alert('请选择Excel文件')</script> ");
            return;//当无文件时,返回
        }
        string IsXlsx = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
        if (IsXlsx != ".xlsx" && IsXlsx != ".xls")
        {
            Response.Write("<script>alert('只可以选择Excel文件')</script>");
            return;//当选择的不是Excel文件时,返回
        }
        string filename = FileUpload1.FileName;              //获取Excle文件名  DateTime日期函数
        string savePath = Server.MapPath(("upfiles\\") + filename);//Server.MapPath 获得虚拟服务器相对路径
        //检查文件是否存在
        if (File.Exists(savePath))
        {
            Response.Write("<script>alert('使用过的Excel文件')</script>");
            return;
        }
        else
            FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上
        DataSet ds = ExcelSqlConnection(savePath, filename);           //调用自定义方法
        DataRow[] dr = ds.Tables[0].Select();            //定义一个DataRow数组
        int rowsnum = ds.Tables[0].Rows.Count;
        if (rowsnum == 0)
        {
            Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
        }
        else
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<string> SQLStringList = new List<string>();
            for (int i = 0; i < dr.Length; i++)
            {
                //前面除了你需要在建立一个“upfiles”的文件夹外，其他的都不用管了，你只需要通过下面的方式获取Excel的值，然后再将这些值用你的方式去插入到数据库里面
                string benfactorFrom = dr[i]["受助人来源"].ToString();
                string recipientsADD = dr[i]["户籍"].ToString();
                string recipientsName = dr[i]["受助人姓名"].ToString();
                string sex = dr[i]["性别"].ToString();
                string recipientsPIdcard = dr[i]["身份证号"].ToString();
                string recipientsADDnow = dr[i]["现住址"].ToString();
                string incomlowID = dr[i]["低保号"].ToString();
                string telphoneADD = dr[i]["联系电话"].ToString();
                string workplace = dr[i]["工作单位"].ToString();
                string famName1 = dr[i]["家庭成员姓名1"].ToString();
                string famRelation1 = dr[i]["与本人关系1"].ToString();
                string famWorkplace1 = dr[i]["成员工作单位1"].ToString();
                string famTel1 = dr[i]["成员联系方式1"].ToString();
                string famWork1 = dr[i]["成员职业1"].ToString();
                string famIncome1 = dr[i]["成员收入1"].ToString();
                string famName2 = dr[i]["家庭成员姓名2"].ToString();
                string famRelation2 = dr[i]["与本人关系2"].ToString();
                string famWorkplace2 = dr[i]["成员工作单位2"].ToString();
                string famTel2 = dr[i]["成员联系方式2"].ToString();
                string famWork2 = dr[i]["成员职业2"].ToString();
                string famIncome2 = dr[i]["成员收入2"].ToString();
                string famName3 = dr[i]["成员姓名3"].ToString();
                string famRelation3 = dr[i]["与本人关系3"].ToString();
                string famWorkplace3 = dr[i]["成员工作单位3"].ToString();
                string famTel3 = dr[i]["成员联系方式3"].ToString();
                string famWork3 = dr[i]["成员职业3"].ToString();
                string famIncome3 = dr[i]["成员收入3"].ToString();
                string famName4 = dr[i]["家庭成员姓名4"].ToString();
                string famRelation4 = dr[i]["与本人关系4"].ToString();
                string famWorkplace4 = dr[i]["成员工作单位4"].ToString();
                string famTel4 = dr[i]["成员联系方式4"].ToString();
                string famWork4 = dr[i]["成员职业4"].ToString();
                string famIncome4 = dr[i]["成员收入4"].ToString();
                string arrIncome = dr[i]["平均月收入"].ToString();
                string marryNow = dr[i]["婚姻状况"].ToString();
                string canjijibie = dr[i]["残疾级别"].ToString();
                string canjileibie = dr[i]["残疾类别"].ToString();
                string shuoming3 = dr[i]["助残说明"].ToString();
                string illness = dr[i]["大病种类"].ToString();
                string illtime = dr[i]["就诊时间"].ToString();
                string illpay = dr[i]["花费数额"].ToString();
                string shuoming1 = dr[i]["助医说明"].ToString();
                string timeDis = dr[i]["临时说明"].ToString();
                string shiDu = dr[i]["是否失独"].ToString();
                string sonName = dr[i]["子女姓名"].ToString();
                string deathReason = dr[i]["死亡原因"].ToString();
                string shuoming5 = dr[i]["助困说明"].ToString();
                string shiNeng = dr[i]["是否失能"].ToString();
                string shuoming4 = dr[i]["助老说明"].ToString();
                string studySchool = dr[i]["就读学校"].ToString();
                string studyGrade = dr[i]["就读年级"].ToString();
                string guardianName = dr[i]["监护人姓名"].ToString();
                string guardianGuanxi = dr[i]["与被监护人关系"].ToString();
                string guardianTelADD = dr[i]["监护人电话"].ToString();
                string shuoming2 = dr[i]["助学说明"].ToString();
                string army = dr[i]["部队名称"].ToString();
                string title = dr[i]["职位"].ToString();
                string disaster = dr[i]["灾害名称"].ToString();
                string reason = dr[i]["致困原因"].ToString();
                string iscan = dr[i]["是否助残"].ToString();
                string isdoc = dr[i]["是否助医"].ToString();
                string iskun = dr[i]["是否助困"].ToString();
                string isold = dr[i]["是否助老"].ToString();
                string isstu = dr[i]["是否助学"].ToString();
                string isyong = dr[i]["是否双拥"].ToString();
                string isdst = dr[i]["是否重特大灾害"].ToString();

                //string str11 = string.Format("insert into e_info (infoTitle,infoContent,infoDATE,infoFile) VALUES ('{0}','{1}','{2}','{3}')", title, content, DateTime.Now.ToString(), "");
                string str113 = string.Format("insert into e_recipients (benfactorFrom,recipientsADD,recipientsName,sex,recipientsPIdcard,recipientsADDnow,incomlowID,telphoneADD,workplace,famName1,famRelation1,famWorkplace1,famTel1,famWork1,famIncome1,famName2,famRelation2,famWorkplace2,famTel2,famWork2,famIncome2,famName3,famRelation3,famWorkplace3,famTel3,famWork3,famIncome3,famName4,famRelation4,famWorkplace4,famTel4,famWork4,famIncome4,arrIncome,marryNow,canjijibie,canjileibie,shuoming3,illness,illtime,illpay,shuoming1,timeDis,shiDu,sonName,deathReason,shuoming5,shiNeng,shuoming4,studySchool,studyGrade,guardianName,guardianGuanxi,guardianTelADD,shuoming2,reason,iscan,isdoc,iskun,isold,isstu,isyong,army,title,isdst,disaster) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}','{63}','{64}','{65}')", benfactorFrom, recipientsADD, recipientsName, sex, recipientsPIdcard, recipientsADDnow, incomlowID, telphoneADD, workplace, famName1, famRelation1, famWorkplace1, famTel1, famWork1, famIncome1, famName2, famRelation2, famWorkplace2, famTel2, famWork2, famIncome2, famName3, famRelation3, famWorkplace3, famTel3, famWork3, famIncome3, famName4, famRelation4, famWorkplace4, famTel4, famWork4, famIncome4, arrIncome, marryNow, canjijibie, canjileibie, shuoming3, illness, illtime, illpay, shuoming1, timeDis, shiDu, sonName, deathReason, shuoming5, shiNeng, shuoming4, studySchool, studyGrade, guardianName, guardianGuanxi, guardianTelADD, shuoming2, reason, iscan, isdoc, iskun, isold, isstu, isyong, army, title, isdst, disaster);
                SQLStringList.Add(str113);

            }
            ExecuteSqlTran(SQLStringList);    
            //try
                //{
                //    ////msq.getmysqlcom(str113);
                //}
                //catch (MySqlException ex)
                //{
                //    HttpContext.Current.Response.Write("<script>alert('身份证号重复了');</script>");
                //}
            sw.Stop();
            NLogTest nlog = new NLogTest();
            string sss = "批量添加了受助人：" + filename;
            nlog.WriteLog(Session["UserName"].ToString(),sss);
            Response.Write("<script>alert('Excle表导入成功!');</script>");
            TimeSpan timeSpan = sw.Elapsed;
        }
    }

    public static void ExecuteSqlTran(List<string> SQLStringList)
    {
        using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=123456;database=mscsdb;charset=gbk;"))
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            MySqlTransaction tx = conn.BeginTransaction();
            cmd.Transaction = tx;
            try
            {
                for (int n = 0; n < SQLStringList.Count; n++)
                {
                    string strsql = SQLStringList[n].ToString();
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        cmd.ExecuteNonQuery();
                    }
                }
                tx.Commit();//原来一次性提交
            }
            catch (System.Data.SqlClient.SqlException E)
            {
                tx.Rollback();
                HttpContext.Current.Response.Write("<script>alert('身份证号重复了');</script>");
                //throw new Exception(E.Message);
            }
        }
    }
}