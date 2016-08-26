using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Office;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop;

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
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace CL.Utility.Web.BasicData
{
    /// <summary>
    /// Meter 的摘要说明。
    /// </summary>
    /// 
    public partial class Register : System.Web.UI.Page
    {
        #region "自定义属性"
        //internal static Manager manager = Managers.Members["NewUtilityOra"] as Manager;
        //internal static ISingleTable entityUsers = manager.Entities["USERS"] as ISingleTable;
        //private DataTable dtUsers;

        private string bindPCKey = "USER_ID";//绑定 能源节点数据的主键

        internal static WriteLog wl = new WriteLog();
        internal static UserInterface ui = new UserInterface();
        private const string PAGE_NAME = "用户";

        public const string sPMS_CTG_ID = "USER_ID";
        public const string sPMS_CTG_NAME = "USER_NAME";
        public const string sPwd = "USER_PWD";
        public const string sUSE_IDT = "USE_IDT";
        public const string sCRT_DATE = "CRT_DATE";
        public const string sUPD_DATE = "UPD_DATE";
        public const string sDES = "DES";


        private const string PK = "projectID";
        public const string sID = "projectID";
        public const string sName = "projectName";//public时页面能引用，private时不可以
        protected System.Data.DataTable _dtData;
        protected System.Data.DataTable _dtData1;
        mysqlconn msq = new mysqlconn();
        string sqldata1 = string.Format("select * from e_project");
        string sqldata = string.Format("select * from e_handlingunit");
        string sqldatadrop = string.Format("select *from e_recipientsfenpei");
        #endregion

        string nameNow = "";
        public static string tableTitle = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserName"].ToString().Equals(""))
            {
                Response.Write("<script>window.open('../loginnew.aspx','_top')</script>");
                return;
            }
            string urlNow = Request.Url.ToString();
            string[] temp = urlNow.Split('=');
            // string Files="";
            //string[] arrFiles;
            foreach (string s in temp)
            {
                nameNow = s;
            }
            if (!Page.IsPostBack)
            {
                string strState = "";
                string strType = "";
                string strpro = string.Format("select projectID,projectName,projectDir,benfactorFrom,palnMoney,recipientsNow,telphoneName,telphoneADD,projectLei,proschedule,projectType from e_project where projectID='{0}'", nameNow);
                MySqlDataReader mysqlreader = msq.getmysqlread(strpro);
                while (mysqlreader.Read())
                {
                    LbproID.Text = mysqlreader.GetString("projectID");
                    Lbproname.Text = mysqlreader.GetString("projectName");
                    projectDir.Text = mysqlreader.GetString("projectDir");
                    Lbbenfrom.Text = mysqlreader.GetString("benfactorFrom");
                    Lbplan.Text = mysqlreader.GetString("palnMoney");
                    Lbrestnow.Text = mysqlreader.GetString("recipientsNow");
                    Lbtelname.Text = mysqlreader.GetString("telphoneName");
                    Lbtelladd.Text = mysqlreader.GetString("telphoneADD");
                    lblLeibie.Text = mysqlreader.GetString("projectLei");
                    lblState.Text = strState = mysqlreader.GetString("proschedule");
                    strType = mysqlreader.GetString("projectType");
                }
                BindData();
                //默认隐藏全部按钮
                btchecky1.Visible = false;//会长审批通过
                btchecky2.Visible = false;//科室审批通过
                btcheckn.Visible = false;//审批未通过
                btnReapply.Visible = false;//未通过时，显示重新申请按钮
                if (Session["benfactorFrom"].ToString() == "北京市朝阳区慈善协会捐助科")//捐助科
                {
                    if (strState == "申请中")//初始状态——申请中
                        btchecky2.Visible = btcheckn.Visible = true;//显示通过、未通过按钮
                }
                if(Session["userRole"].ToString()=="3")//会长
                {
                    if (strState == "科室审批通过")
                        btchecky1.Visible = btcheckn.Visible = true;//显示通过、未通过按钮
                }
                if (strState=="未通过")
                {
                    if (Lbbenfrom.Text.Trim() == Session["benfactorFrom"].ToString())//当前用户为执行单位
                        btnReapply.Visible = true;
                }
                if (strType == "资金")
                    dgData1.Visible = false;
                else if (strType == "物品")
                    dgData0.Visible = false;
                dgData.Columns[0].Visible=false;
                if(strState == "申请中")
                {
                    if((Lbbenfrom.Text==Session["benfactorFrom"].ToString())||(Session["benfactorFrom"].ToString() == "北京市朝阳区慈善协会捐助科")||(Session["UserName"].ToString()=="admin"))
                    {//项目实施单位 或者 捐助科 或者 管理员
                        dgData.Columns[0].Visible = true;
                    }
                }

            }
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion


        #region "转换函数"
        //防止页面滚动"
        //		private void RetainScrollPosition()
        //		{
        //			StringBuilder saveScrollPosition = new StringBuilder ();
        //			StringBuilder setScrollPosition = new StringBuilder ();
        //
        //			RegisterHiddenField("__SCROLLPOS", "0");
        //
        //			saveScrollPosition.Append("<script language='javascript'>");
        //			saveScrollPosition.Append("function saveScrollPosition() {");
        //			saveScrollPosition.Append("    document.forms[0].__SCROLLPOS.value = thebody.scrollTop;");
        //			saveScrollPosition.Append("}");
        //			saveScrollPosition.Append("thebody.onscroll=saveScrollPosition;");
        //			saveScrollPosition.Append("</script>");
        //
        //			RegisterStartupScript("saveScroll", saveScrollPosition.ToString());
        //
        //			if (Page.IsPostBack)
        //			{
        //				setScrollPosition.Append("<script language='javascript'>");
        //				setScrollPosition.Append("function setScrollPosition() {");
        //				setScrollPosition.Append("    thebody.scrollTop = " + Request["__SCROLLPOS"] + ";");
        //				setScrollPosition.Append("}");
        //				setScrollPosition.Append("thebody.onload=setScrollPosition;");
        //				setScrollPosition.Append("</script>");
        //
        //				RegisterStartupScript("setScroll", setScrollPosition.ToString());
        //			}
        //		}

        //正则表达式匹配
        private bool IsValidNum(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^[0-9]*[1-9][0-9]*$");

            //		^\d+$　　//匹配非负整数（正整数 + 0） 
            //^[0-9]*[1-9][0-9]*$　　//匹配正整数 
            //^((-\d+)|(0+))$　　//匹配非正整数（负整数 + 0） 
            //^-[0-9]*[1-9][0-9]*$　　//匹配负整数 
            //^-?\d+$　　　　//匹配整数 
            //^\d+(\.\d+)?$　　//匹配非负浮点数（正浮点数 + 0） 
            //^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$　　//匹配正浮点数 
            //^((-\d+(\.\d+)?)|(0+(\.0+)?))$　　//匹配非正浮点数（负浮点数 + 0） 
            //^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$　　//匹配负浮点数 
            //^(-?\d+)(\.\d+)?$　　//匹配浮点数 
            //^[A-Za-z]+$　　//匹配由26个英文字母组成的字符串 
            //^[A-Z]+$　　//匹配由26个英文字母的大写组成的字符串 
            //^[a-z]+$　　//匹配由26个英文字母的小写组成的字符串 
            //^[A-Za-z0-9]+$　　//匹配由数字和26个英文字母组成的字符串 
            //^\w+$　　//匹配由数字、26个英文字母或者下划线组成的字符串 
            //^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$　　　　//匹配email地址 
            //^[a-zA-z]+://匹配(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$　　//匹配url 
        }
        public bool Checked(object obj)
        {
            if (obj.ToString() == "0")
            {
                return false;
            }
            else return true;
        }
        #endregion

        private void BindDataSet()
        {
            
        }
        private void BindData()
        {
            string proid = string.Format("select * from e_recipients where recipientsID in (select recipientID from e_pr where projectID='{0}')", LbproID.Text);
            DataSet dds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), proid);
            DataView ddv = new DataView(dds.Tables[0]);
            dgData.DataSource = dds;
            //dgData.DataKeyField = "recipientsID";
            dgData.DataBind();

            string capid = string.Format("select * from e_moneytrack where projectID='{0}'",LbproID.Text);
            DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), capid);
            DataView dv = new DataView(ds.Tables[0]);
            dgData0.DataSource = ds;
            dgData0.DataBind();

            string strItem = string.Format("select * from e_item where projectID='{0}'", LbproID.Text);
            DataSet ds1 = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), strItem);
            DataView dv1 = new DataView(ds.Tables[0]);
            dgData1.DataSource = ds1;
            dgData1.DataBind();
        }
        protected void dgData_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if(e.CommandName=="Delete1")
            {
                string rcpidStr = (dgData.DataKeys[e.Item.ItemIndex]).ToString();
                NLogTest nlog = new NLogTest();
                string sss = "删除了项目：" + LbproID.Text.Trim() + "中的受助人：" + rcpidStr;
                nlog.WriteLog(Session["UserName"].ToString(), sss);

                
                string deleteStr = string.Format("delete from e_pr where projectID='{0}' and recipientID={1}",LbproID.Text.Trim(),rcpidStr);
                msq.getmysqlcom(deleteStr);
                BindData();

            }

        }
        protected void btchecky1_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string prodatatimeshen = dt.ToShortDateString().ToString();
            string strinsert = string.Format("update e_project set proschedule='会长审批通过',prodatatimeshen1='{1}' where projectID='{0}'", LbproID.Text,prodatatimeshen);         
            int reslut = msq.getmysqlcom(strinsert);
            if (reslut > 0)
            {
                labError.Text= "会长审批通过";
                NLogTest nlog = new NLogTest();
                string sss = "会长审批通过项目：" + Lbproname.Text;
                nlog.WriteLog(Session["UserName"].ToString(), sss);
                string str11 = string.Format("insert into e_info (infoTitle,infoContent,infoDATE,infoFile,infoFrom,infoTo,infoRead) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", "会长审批通过项目：" + Lbproname.Text.Trim(), "", DateTime.Now.ToString(), "", Session["UserName"].ToString(), Lbbenfrom.Text.Trim(), "未读");
                msq.getmysqlcom(str11);
                if(Lbbenfrom.Text.Trim()!="朝阳区慈善协会")
                {
                    string str12 = string.Format("insert into e_info (infoTitle,infoContent,infoDATE,infoFile,infoFrom,infoTo,infoRead) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", "会长审批通过项目：" + Lbproname.Text.Trim(), "", DateTime.Now.ToString(), "", Session["UserName"].ToString(), "朝阳区慈善协会", "未读");
                    msq.getmysqlcom(str12);
                }
            }
        }
        protected void btchecky2_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string prodatatimeshen = dt.ToShortDateString().ToString();
            string strinsert = string.Format("update e_project set prodatatimeshen='{1}',proschedule='科室审批通过' where projectID='{0}'", LbproID.Text, prodatatimeshen);        
            int reslut = msq.getmysqlcom(strinsert);
            if (reslut > 0)
            {                
                labError.Text= "科室审批通过";
                NLogTest nlog = new NLogTest();
                string sss = "科室审批通过项目：" + Lbproname.Text;
                nlog.WriteLog(Session["UserName"].ToString(), sss);
                string str11 = string.Format("insert into e_info (infoTitle,infoContent,infoDATE,infoFile,infoFrom,infoTo,infoRead) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", "科室审批通过项目：" + Lbproname.Text.Trim(), "", DateTime.Now.ToString(), "", Session["UserName"].ToString(), Lbbenfrom.Text.Trim(), "未读");
                msq.getmysqlcom(str11);
            }

        }
        protected void btcheckn_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string prodatatimeshen = dt.ToShortDateString().ToString();
            string strinsert = string.Format("update e_project set proschedule='未通过',prodatatimeshen='{1}' where projectID='{0}'", LbproID.Text, prodatatimeshen);
            int reslut = msq.getmysqlcom(strinsert);
            if (reslut > 0)
            {
                labError.Text = "审批未通过";
                NLogTest nlog = new NLogTest();
                string sss = "未通过审批项目：" + Lbproname.Text;
                nlog.WriteLog(Session["UserName"].ToString(), sss);
                Response.Redirect("信息发布.aspx?title=" + Server.UrlEncode(Lbproname.Text.Trim()) + "&branchName=" + Server.UrlEncode(Lbbenfrom.Text.Trim()));
            }
        }
        protected void btout_Click(object sender, EventArgs e)
        {
            ViewState["model"] = DropDownList1.SelectedValue.ToString();//选择的模板
            //遍历dgData
            if (Lbproname.Text.Trim() != "")//项目名称非空
            {
                if(ViewState["model"].ToString()=="附1北京市朝阳区慈善协会救助项目申请表")//多受助人，多文件压缩包
                {
                    MemoryStream ms = new MemoryStream();
                    byte[] buffer = null;
                    using (ZipFile file = ZipFile.Create(ms))
                    {
                        file.BeginUpdate();
                        file.NameTransform = new MyNameTransfom();//通过这个名称格式化器，可以将里面的文件名进行一些处理。默认情况下，会自动根据文件的路径在zip中创建有关的文件夹。
                        for (int i = 0; i < dgData.Items.Count;i++ )
                        {
                            Toprint(ViewState["model"].ToString(), dgData.DataKeys[i].ToString(),i);
                            file.Add(Server.MapPath("template\\" + ViewState["model"].ToString() + i.ToString() + ".pdf"));
                        }                    
                        file.CommitUpdate();
                        buffer = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(buffer, 0, buffer.Length);
                    }
                    //下载
                    Response.AddHeader("content-disposition", "attachment;filename=Test.zip");
                    Response.BinaryWrite(buffer);
                    Response.Flush();
                    Response.End();
                }
                else
                {//单受助人，单文件
                    Toprint(ViewState["model"].ToString(), "", -1);
                }


            }
        }
        public class MyNameTransfom : ICSharpCode.SharpZipLib.Core.INameTransform
        {

            #region INameTransform 成员
            public string TransformDirectory(string name)
            {
                return null;
            }
            public string TransformFile(string name)
            {
                return Path.GetFileName(name);
            }
            #endregion
        }
        public void Toprint(string strFileName,string pid,int index)
        {
            WriteIntoWord wiw = new WriteIntoWord();
            string FilePath = Server.MapPath("template\\" + strFileName + ".dot");//模板路径
 
            string FillProjectName = Lbproname.Text.Trim();//项目名称
            string FillPlanMoney = Lbplan.Text.Trim();//计划使用资金
            double RMB = Convert.ToDouble(FillPlanMoney);
            RMBCapitalization numClass = new RMBCapitalization();
            string FillRMB = numClass.RMBAmount(RMB);//大写资金

            string FillName = "";
            string FillSex = "";
            string FillAge = "";
            string FillRecipientsADD = "";
            string FillWorkplace = "";
            string FillIncomlowID = "";
            string FillRecipientsADDnow = "";
            string FillTelphoneADD = "";
            string FillArrIncome = "";
            string FillCanjiID = "";
            string FillOfficerID = "";
            string FillRequest = "";
            string FillComefrom = "";
            string FillPersons = "";
            string FillGuanming = "";
            string FillPidCard = "";

            string FillAddress = "";//经办单位地址


            #region "家庭成员"
            string FillFamName1 = "";
            string FillFamRelation1 = "";
            string FillFamWorkplace1 = "";
            string FillFamWork1 = "";
            string FillFamIncome1 = "";

            string FillFamName2 = "";
            string FillFamRelation2 = "";
            string FillFamWorkplace2 = "";
            string FillFamWork2 = "";
            string FillFamIncome2 = "";

            string FillFamName3 = "";
            string FillFamRelation3 = "";
            string FillFamWorkplace3 = "";
            string FillFamWork3 = "";
            string FillFamIncome3 = "";

            string FillFamName4 = "";
            string FillFamRelation4 = "";
            string FillFamWorkplace4 = "";
            string FillFamWork4 = "";
            string FillFamIncome4 = "";
            #endregion

            double sumIncome = 0;
            double incomePerPerson = 0;

            string SaveDocPath = "";//word保存路径
            string SavePdfPath = "";//pdf保存路径


            string strselect2 = string.Format("select address from e_handlingunit where benfactorFrom='{0}'", Lbbenfrom.Text.Trim());
            MySqlDataReader mysqlreader2 = msq.getmysqlread(strselect2);
            while(mysqlreader2.Read())
            {
                FillAddress = mysqlreader2.GetString("address");
            }
            if(pid!="")
            {//多受助人，生成多个文件并打包
                string strselect = string.Format("select *,date_format(from_days(to_days(now())-to_days(SUBSTRING(recipientsPIdcard,7,8))),'%Y')+0 as newAge from e_recipients where recipientsID={0}", pid);//受助人ID recipientsPIdcard='{0}'
                MySqlDataReader mysqlreader = msq.getmysqlread(strselect);
                while (mysqlreader.Read())
                {
                    FillName = mysqlreader.GetString("recipientsName");//受助人名称
                    FillSex = mysqlreader.GetString("sex");//性别
                    FillAge = mysqlreader.GetString("newAge");//年龄
                    FillRecipientsADD = mysqlreader.GetString("recipientsADD");//籍贯
                    FillWorkplace = mysqlreader.GetString("workplace");//工作地点
                    FillIncomlowID = mysqlreader.GetString("incomlowID");//低保低收入号
                    FillRecipientsADDnow = mysqlreader.GetString("recipientsADDnow");//现居住地
                    FillTelphoneADD = mysqlreader.GetString("telphoneADD");//手机号
                    FillArrIncome = mysqlreader.GetString("arrIncome");//平均收入
                    FillCanjiID = mysqlreader.GetString("canID");//助残ID
                    FillOfficerID = mysqlreader.GetString("officerID");//军官证号
                    FillPidCard = mysqlreader.GetString("recipientsPIdcard");//身份证号
                    #region "家庭成员"
                    FillFamName1 = mysqlreader.GetString("famName1");
                    FillFamRelation1 = mysqlreader.GetString("famRelation1");
                    FillFamWorkplace1 = mysqlreader.GetString("famWorkplace1");
                    FillFamWork1 = mysqlreader.GetString("famWork1");
                    FillFamIncome1 = mysqlreader.GetString("famIncome1");

                    FillFamName2 = mysqlreader.GetString("famName2");
                    FillFamRelation2 = mysqlreader.GetString("famRelation2");
                    FillFamWorkplace2 = mysqlreader.GetString("famWorkplace2");
                    FillFamWork2 = mysqlreader.GetString("famWork2");
                    FillFamIncome2 = mysqlreader.GetString("famIncome2");

                    FillFamName3 = mysqlreader.GetString("famName3");
                    FillFamRelation3 = mysqlreader.GetString("famRelation3");
                    FillFamWorkplace3 = mysqlreader.GetString("famWorkplace3");
                    FillFamWork3 = mysqlreader.GetString("famWork3");
                    FillFamIncome3 = mysqlreader.GetString("famIncome3");

                    FillFamName4 = mysqlreader.GetString("famName4");
                    FillFamRelation4 = mysqlreader.GetString("famRelation4");
                    FillFamWorkplace4 = mysqlreader.GetString("famWorkplace4");
                    FillFamWork4 = mysqlreader.GetString("famWork4");
                    FillFamIncome4 = mysqlreader.GetString("famIncome4");
                    #endregion
                }
                string selectRequest = string.Format("select request from e_pr where recipientID={0}", pid);//受助人ID (select recipientsID from e_recipients where recipientsPIdcard='{0}')
                mysqlreader = msq.getmysqlread(selectRequest);
                while (mysqlreader.Read())
                    FillRequest = mysqlreader.GetString("request");//救助申请


                int numPerson = 1;
                if ((FillArrIncome != "") && (FillArrIncome != "0"))
                {
                    sumIncome += Convert.ToDouble(FillArrIncome);
                }
                if (FillFamIncome1 != "")
                {
                    numPerson++;
                    if (FillFamIncome1 != "0")
                        sumIncome += Convert.ToDouble(FillFamIncome1);
                }
                if (FillFamIncome2 != "")
                {
                    numPerson++;
                    if (FillFamIncome2 != "0")
                        sumIncome += Convert.ToDouble(FillFamIncome2);
                }
                if (FillFamIncome3 != "")
                {
                    numPerson++;
                    if (FillFamIncome3 != "0")
                        sumIncome += Convert.ToDouble(FillFamIncome3);
                }
                if (FillFamIncome4 != "")
                {
                    numPerson++;
                    if (FillFamIncome4 != "0")
                        sumIncome += Convert.ToDouble(FillFamIncome4);
                }
                incomePerPerson = Math.Round((sumIncome / numPerson), 2);
                SaveDocPath = Server.MapPath("template\\" + strFileName + index.ToString() + ".doc");
                SavePdfPath = Server.MapPath("template\\" + strFileName + index.ToString() + ".pdf");

            }
            else
            {
                SaveDocPath = Server.MapPath("template\\" + strFileName + ".doc");
                SavePdfPath = Server.MapPath("template\\" + strFileName + ".pdf");
            }




            wiw.OpenDocument(FilePath);//打开模板
            if(strFileName=="附1北京市朝阳区慈善协会救助项目申请表")//多受助人模板
            {
                wiw.WriteIntoDocument("leibieMark", lblLeibie.Text.ToString());//项目类别
                wiw.WriteIntoDocument("projectNameMark", FillProjectName);//项目名称
                wiw.WriteIntoDocument("planMoneyMark", FillPlanMoney);//救助金额
                wiw.WriteIntoDocument("pidMark", FillPidCard);//身份证号
                wiw.WriteIntoDocument("nameMark", FillName);//姓名
                wiw.WriteIntoDocument("sexMark", FillSex);//性别
                wiw.WriteIntoDocument("ageMark", FillAge);//年龄
                wiw.WriteIntoDocument("recipientsADDMark", FillRecipientsADD);//户籍所在地
                wiw.WriteIntoDocument("workplaceMark", FillWorkplace);//工作单位
                wiw.WriteIntoDocument("incomlowIDMark", FillIncomlowID);//低收入/低保号
                wiw.WriteIntoDocument("recipientsADDnowMark", FillRecipientsADDnow);//现家庭地址
                wiw.WriteIntoDocument("telphoneADDMark", FillTelphoneADD);//联系电话
                wiw.WriteIntoDocument("arrIncomeMark", FillArrIncome);//月收入
                wiw.WriteIntoDocument("RMBMark", FillRMB);//大写金额
                wiw.WriteIntoDocument("generalIncomeMark", sumIncome.ToString());//家庭月总收入
                wiw.WriteIntoDocument("incomePerPersonMark", incomePerPerson.ToString());//家庭人均月收入
                wiw.WriteIntoDocument("canjiIDMark", FillCanjiID);//残疾人证号
                wiw.WriteIntoDocument("officerIDMark", FillOfficerID);//军官证号
                wiw.WriteIntoDocument("requestMark", FillRequest);//救助申请

                #region "家庭成员"
                wiw.WriteIntoDocument("famName1Mark", FillFamName1);
                wiw.WriteIntoDocument("famRelation1Mark", FillFamRelation1);
                wiw.WriteIntoDocument("famWorkplace1Mark", FillFamWorkplace1);
                wiw.WriteIntoDocument("famWork1Mark", FillFamWork1);
                wiw.WriteIntoDocument("famIncome1Mark", FillFamIncome1);

                wiw.WriteIntoDocument("famName2Mark", FillFamName2);
                wiw.WriteIntoDocument("famRelation2Mark", FillFamRelation2);
                wiw.WriteIntoDocument("famWorkplace2Mark", FillFamWorkplace2);
                wiw.WriteIntoDocument("famWork2Mark", FillFamWork2);
                wiw.WriteIntoDocument("famIncome2Mark", FillFamIncome2);

                wiw.WriteIntoDocument("famName3Mark", FillFamName3);
                wiw.WriteIntoDocument("famRelation3Mark", FillFamRelation3);
                wiw.WriteIntoDocument("famWorkplace3Mark", FillFamWorkplace3);
                wiw.WriteIntoDocument("famWork3Mark", FillFamWork3);
                wiw.WriteIntoDocument("famIncome3Mark", FillFamIncome3);

                wiw.WriteIntoDocument("famName4Mark", FillFamName4);
                wiw.WriteIntoDocument("famRelation4Mark", FillFamRelation4);
                wiw.WriteIntoDocument("famWorkplace4Mark", FillFamWorkplace4);
                wiw.WriteIntoDocument("famWork4Mark", FillFamWork4);
                wiw.WriteIntoDocument("famIncome4Mark", FillFamIncome4);
                #endregion
            }
            if (strFileName == "附2冠名慈善捐助金使用项目书")
            {
                wiw.WriteIntoDocument("projectNameMark", FillProjectName);//救助项目
                wiw.WriteIntoDocument("planMoneyMark", FillPlanMoney);//救助金额
                wiw.WriteIntoDocument("RMBMark", FillRMB);//大写金额
                wiw.WriteIntoDocument("conditionMark", Lbrestnow.Text.ToString());//受助方情况
                wiw.WriteIntoDocument("descMark", projectDir.Text.ToString());//救助方案
                for (int i = 0; i < dgData.Items.Count;i++ )
                {
                    FillPersons = FillPersons + ((Label)(dgData.Items[i].FindControl("labID"))).Text.ToString() + "；";
                }
                wiw.WriteIntoDocument("personsMark", FillPersons);//救助对象
                wiw.WriteIntoDocument("numMark", dgData.Items.Count.ToString());//救助人数
                for (int i = 0; i < dgData0.Items.Count; i++)
                {
                    FillGuanming = FillGuanming + ((Label)(dgData0.Items[i].FindControl("labname"))).Text.ToString() + "；";
                }
                wiw.WriteIntoDocument("guanmingMark", FillGuanming);//冠名捐助金名称

            }
            if (strFileName == "附3北京市朝阳区慈善协会救助项目书")
            {
                wiw.WriteIntoDocument("projectNameMark", FillProjectName);//项目名称
                wiw.WriteIntoDocument("leibieMark", lblLeibie.Text.ToString());//项目类别
                wiw.WriteIntoDocument("planMoneyMark", FillPlanMoney);//救助金额
                wiw.WriteIntoDocument("RMBMark", FillRMB);//大写金额
                wiw.WriteIntoDocument("descMark", projectDir.Text.ToString());//项目方案
                for (int i = 0; i < dgData0.Items.Count; i++)
                {
                    FillComefrom = FillComefrom + (i + 1).ToString() + "、" + ((Label)(dgData0.Items[i].FindControl("labname"))).Text.ToString() + "：￥" + ((Label)(dgData0.Items[i].FindControl("labguanming"))).Text.ToString() + "；";
                }

                wiw.WriteIntoDocument("comefromMark", FillComefrom);//资金来源

                wiw.WriteIntoDocument("branchNameMark", Lbbenfrom.Text.Trim());//项目实施单位名称
                wiw.WriteIntoDocument("addressMark", FillAddress);//地址
                wiw.WriteIntoDocument("contactMark", Lbtelname.Text.Trim());//联系人
                wiw.WriteIntoDocument("TELMark", Lbtelladd.Text.Trim());//电话
            }

            wiw.Save_CloseDocument(SaveDocPath);
            WordToPdf(SaveDocPath, SavePdfPath);
            if(pid=="")//单文件直接下载
                DownLoadFile("template\\" + strFileName + ".pdf");
        }
        public class WriteIntoWord
        {
            ApplicationClass app = null;   //定义应用程序对象 
            Document doc = null;   //定义 word 文档对象
            Object missing = System.Reflection.Missing.Value; //定义空变量
            Object isReadOnly = false;
            // 向 word 文档写入数据 
            public void OpenDocument(string FilePath)
            {
                object filePath = FilePath;//文档路径
                app = new ApplicationClass(); //打开文档 
                doc = app.Documents.Open(ref filePath, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing);
                doc.Activate();//激活文档
            }
            /// <summary> 
            /// </summary> 
            ///<param name="parLableName">域标签</param> 
            /// <param name="parFillName">写入域中的内容</param> 
            /// 
            //打开word，将对应数据写入word里对应书签域

            public void WriteIntoDocument(string BookmarkName, string FillName)
            {
                object bookmarkName = BookmarkName;
                Bookmark bm = doc.Bookmarks.get_Item(ref bookmarkName);//返回书签 
                bm.Range.Text = FillName;//设置书签域的内容
            }
            /// <summary> 
            /// 保存并关闭 
            /// </summary> 
            /// <param name="parSaveDocPath">文档另存为的路径</param>
            /// 
            public void Save_CloseDocument(string SaveDocPath)
            {
                object savePath = SaveDocPath;  //文档另存为的路径 
                Object saveChanges = app.Options.BackgroundSave;//文档另存为 
                doc.SaveAs(ref savePath, ref missing, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                doc.Close(ref saveChanges, ref missing, ref missing);//关闭文档
                app.Quit(ref missing, ref missing, ref missing);//关闭应用程序

            }
        }
        //  下载文件类
        public void DownLoadFile(string FullFileName)
        {
            // 保存文件的虚拟路径
            string Url = FullFileName;
            // 保存文件的物理路径
            string FullPath = HttpContext.Current.Server.MapPath(Url);
            // 初始化FileInfo类的实例，作为文件路径的包装
            FileInfo FI = new FileInfo(FullPath);
            // 判断文件是否存在
            if (FI.Exists)
            {
                // 将文件保存到本机
                string outputFilename = null;
                Response.Clear();

                string browser = HttpContext.Current.Request.UserAgent.ToUpper();
                if (browser.Contains("MS") == true && browser.Contains("IE") == true)
                {
                    outputFilename = Server.UrlEncode(FI.Name);
                }
                else if (browser.Contains("FIREFOX") == true)
                {
                    outputFilename = "\"" + FI.Name + "\"";
                }
                else
                {
                    outputFilename = Server.UrlEncode(FI.Name);
                }

                Response.AddHeader("Content-Disposition", "attachment;filename=" + outputFilename);
                Response.AddHeader("Content-Length", FI.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Filter.Close();
                Response.WriteFile(FI.FullName);
                Response.End();
            }
        }
        /// <summary>

        /// 把Word文件转换成pdf文件

        /// </summary>

        /// <param name="sourcePath">需要转换的文件路径和文件名称</param>

        /// <param name="targetPath">转换完成后的文件的路径和文件名名称</param>

        /// <returns>成功返回true,失败返回false</returns>
        public static bool WordToPdf(string sourcePath, string targetPath)
        {
            bool result = false;

            WdExportFormat wdExportFormatPDF = WdExportFormat.wdExportFormatPDF;//转换格式1.wdExportFormatPDF转换成pdf格式 2.wdExportFormatXPS转换成xps格式

            object missing = Type.Missing;

            Microsoft.Office.Interop.Word.ApplicationClass applicationClass = null;

            Document document = null;

            try
            {
                applicationClass = new Microsoft.Office.Interop.Word.ApplicationClass();

                object inputfileName = sourcePath;//需要转格式的文件路径

                string outputFileName = targetPath;//转换完成后PDF或XPS文件的路径和文件名名称

                WdExportFormat exportFormat = wdExportFormatPDF;//导出文件所使用的格式

                bool openAfterExport = false;//转换完成后是否打开

                WdExportOptimizeFor wdExportOptimizeForPrint = WdExportOptimizeFor.wdExportOptimizeForPrint;//导出方式1.wdExportOptimizeForPrint针对打印进行导出，质量较高，生成的文件大小较大。2.wdExportOptimizeForOnScreen 针对屏幕显示进行导出，质量较差，生成的文件大小较小。

                WdExportRange wdExportAllDocument = WdExportRange.wdExportAllDocument;//导出全部内容（枚举）

                int from = 0;//起始页码

                int to = 0;//结束页码

                WdExportItem wdExportDocumentContent = WdExportItem.wdExportDocumentContent;//指定导出过程中是否只包含文本或包含文本的标记.1.wdExportDocumentContent:导出文件没有标记,2.导出文件有标记

                bool includeDocProps = true;//指定是否包含新导出的文件在文档属性

                bool keepIRM = true;//

                WdExportCreateBookmarks wdExportCreateWordBookmarks = WdExportCreateBookmarks.wdExportCreateWordBookmarks;//1.wdExportCreateNoBookmarks:不要在导出文件中创建书签,2.wdExportCreateHeadingBookmarks：标题和文本框导出的文件中创建一个书签，3.wdExportCreateWordBookmarks每个字的书签，其中包括除包含页眉和页脚中的所有书签导出的文件中创建一个书签。

                bool docStructureTags = true;

                bool bitmapMissingFonts = true;

                bool UseISO19005_1 = false;//生成的文档是否符合 ISO 19005-1 (PDF/A)

                document = applicationClass.Documents.Open(ref inputfileName, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                if (document != null)
                {
                    document.ExportAsFixedFormat(outputFileName, exportFormat, openAfterExport, wdExportOptimizeForPrint, wdExportAllDocument, from, to, wdExportDocumentContent, includeDocProps, keepIRM, wdExportCreateWordBookmarks, docStructureTags, bitmapMissingFonts, UseISO19005_1, ref missing);
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (document != null)
                {
                    document.Close(ref missing, ref missing, ref missing);
                    document = null;
                }
                if (applicationClass != null)
                {
                    applicationClass.Quit(ref missing, ref missing, ref missing);
                    applicationClass = null;
                }
            }
            return result;
        }

        protected void dgData_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
            {
                ((ImageButton)e.Item.Cells[0].FindControl("btnDelete1")).Attributes.Add("onclick", "return confirm('确定要删除这个受助人吗?');");
            }

        }
        protected void btnReapply_Click(object sender, EventArgs e)
        {
            Response.Redirect("项目申请.aspx?id=" + LbproID.Text.Trim());
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("项目审批.aspx?id=" + LbproID.Text.Trim());
        }
}
    /// <summary>
    /// 人民币大小写金额转换
    /// </summary>
    class RMBCapitalization
    {
        private const string DXSZ = "零壹贰叁肆伍陆柒捌玖";
        private const string DXDW = "毫厘分角元拾佰仟萬拾佰仟亿拾佰仟萬兆拾佰仟萬亿京拾佰仟萬亿兆垓";
        private const string SCDW = "元拾佰仟萬亿京兆垓";

        /// <summary>
        /// 转换整数为大写金额
        /// 最高精度为垓，保留小数点后4位，实际精度为亿兆已经足够了，理论上精度无限制，如下所示：
        /// 序号:...30.29.28.27.26.25.24  23.22.21.20.19.18  17.16.15.14.13  12.11.10.9   8 7.6.5.4  . 3.2.1.0
        /// 单位:...垓兆亿萬仟佰拾        京亿萬仟佰拾       兆萬仟佰拾      亿仟佰拾     萬仟佰拾元 . 角分厘毫
        /// 数值:...1000000               000000             00000           0000         00000      . 0000
        /// 下面列出网上搜索到的数词单位：
        /// 元、十、百、千、万、亿、兆、京、垓、秭、穰、沟、涧、正、载、极
        /// </summary>
        /// <param name="capValue">整数值</param>
        /// <returns>返回大写金额</returns>
        private string ConvertIntToUppercaseAmount(string capValue)
        {
            string currCap = "";    //当前金额
            string capResult = "";  //结果金额
            string currentUnit = "";//当前单位
            string resultUnit = ""; //结果单位           
            int prevChar = -1;      //上一位的值
            int currChar = 0;       //当前位的值
            int posIndex = 4;       //位置索引，从"元"开始

            if (Convert.ToDouble(capValue) == 0) return "";
            for (int i = capValue.Length - 1; i >= 0; i--)
            {
                currChar = Convert.ToInt16(capValue.Substring(i, 1));
                if (posIndex > 30)
                {
                    //已超出最大精度"垓"。注：可以将30改成22，使之精确到兆亿就足够了
                    break;
                }
                else if (currChar != 0)
                {
                    //当前位为非零值，则直接转换成大写金额
                    currCap = DXSZ.Substring(currChar, 1) + DXDW.Substring(posIndex, 1);
                }
                else
                {
                    //防止转换后出现多余的零,例如：3000020
                    switch (posIndex)
                    {
                        case 4: currCap = "元"; break;
                        case 8: currCap = "萬"; break;
                        case 12: currCap = "亿"; break;
                        case 17: currCap = "兆"; break;
                        case 23: currCap = "京"; break;
                        case 30: currCap = "垓"; break;
                        default: break;
                    }
                    if (prevChar != 0)
                    {
                        if (currCap != "")
                        {
                            if (currCap != "元") currCap += "零";
                        }
                        else
                        {
                            currCap = "零";
                        }
                    }
                }
                //对结果进行容错处理               
                if (capResult.Length > 0)
                {
                    resultUnit = capResult.Substring(0, 1);
                    currentUnit = DXDW.Substring(posIndex, 1);
                    if (SCDW.IndexOf(resultUnit) > 0)
                    {
                        if (SCDW.IndexOf(currentUnit) > SCDW.IndexOf(resultUnit))
                        {
                            capResult = capResult.Substring(1);
                        }
                    }
                }
                capResult = currCap + capResult;
                prevChar = currChar;
                posIndex += 1;
                currCap = "";
            }
            return capResult;
        }

        /// <summary>
        /// 转换小数为大写金额
        /// </summary>
        /// <param name="capValue">小数值</param>
        /// <param name="addZero">是否增加零位</param>
        /// <returns>返回大写金额</returns>
        private string ConvertDecToUppercaseAmount(string capValue, bool addZero)
        {
            string currCap = "";
            string capResult = "";
            int prevChar = addZero ? -1 : 0;
            int currChar = 0;
            int posIndex = 3;

            if (Convert.ToInt16(capValue) == 0) return "";
            for (int i = 0; i < capValue.Length; i++)
            {
                currChar = Convert.ToInt16(capValue.Substring(i, 1));
                if (currChar != 0)
                {
                    currCap = DXSZ.Substring(currChar, 1) + DXDW.Substring(posIndex, 1);
                }
                else
                {
                    if (Convert.ToInt16(capValue.Substring(i)) == 0)
                    {
                        break;
                    }
                    else if (prevChar != 0)
                    {
                        currCap = "零";
                    }
                }
                capResult += currCap;
                prevChar = currChar;
                posIndex -= 1;
                currCap = "";
            }
            return capResult;
        }

        /// <summary>
        /// 人民币大写金额
        /// </summary>
        /// <param name="value">人民币数字金额值</param>
        /// <returns>返回人民币大写金额</returns>
        public string RMBAmount(double value)
        {
            string capResult = "";
            string capValue = string.Format("{0:f4}", value);       //格式化
            int dotPos = capValue.IndexOf(".");                     //小数点位置
            bool addInt = (Convert.ToInt32(capValue.Substring(dotPos + 1)) == 0);//是否在结果中加"整"
            bool addMinus = (capValue.Substring(0, 1) == "-");      //是否在结果中加"负"
            int beginPos = addMinus ? 1 : 0;                        //开始位置
            string capInt = capValue.Substring(beginPos, dotPos);   //整数
            string capDec = capValue.Substring(dotPos + 1);         //小数

            if (dotPos > 0)
            {
                capResult = ConvertIntToUppercaseAmount(capInt) +
                    ConvertDecToUppercaseAmount(capDec, Convert.ToDouble(capInt) != 0 ? true : false);
            }
            else
            {
                capResult = ConvertIntToUppercaseAmount(capDec);
            }
            if (addMinus) capResult = "负" + capResult;
            if (addInt) capResult += "整";
            return capResult;
        }
    }
}