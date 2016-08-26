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

//ʹ�����ݷ��ʲ���ӵıر�����
using DataEntity.EntityManager;
using DataEntity.Entity;
using System.Text.RegularExpressions;
using CL.Utility.Web.Common;
using System.Configuration;
using luyunfei;
//mysql���ݿ�����
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace CL.Utility.Web.BasicData
{
    /// <summary>
    /// Meter ��ժҪ˵����
    /// </summary>
    /// 
    public partial class Register : System.Web.UI.Page
    {
        #region "�Զ�������"
        //internal static Manager manager = Managers.Members["NewUtilityOra"] as Manager;
        //internal static ISingleTable entityUsers = manager.Entities["USERS"] as ISingleTable;
        //private DataTable dtUsers;

        private string bindPCKey = "USER_ID";//�� ��Դ�ڵ����ݵ�����

        internal static WriteLog wl = new WriteLog();
        internal static UserInterface ui = new UserInterface();
        private const string PAGE_NAME = "�û�";

        public const string sPMS_CTG_ID = "USER_ID";
        public const string sPMS_CTG_NAME = "USER_NAME";
        public const string sPwd = "USER_PWD";
        public const string sUSE_IDT = "USE_IDT";
        public const string sCRT_DATE = "CRT_DATE";
        public const string sUPD_DATE = "UPD_DATE";
        public const string sDES = "DES";


        private const string PK = "projectID";
        public const string sID = "projectID";
        public const string sName = "projectName";//publicʱҳ�������ã�privateʱ������
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
                //Ĭ������ȫ����ť
                btchecky1.Visible = false;//�᳤����ͨ��
                btchecky2.Visible = false;//��������ͨ��
                btcheckn.Visible = false;//����δͨ��
                btnReapply.Visible = false;//δͨ��ʱ����ʾ�������밴ť
                if (Session["benfactorFrom"].ToString() == "�����г���������Э�������")//������
                {
                    if (strState == "������")//��ʼ״̬����������
                        btchecky2.Visible = btcheckn.Visible = true;//��ʾͨ����δͨ����ť
                }
                if(Session["userRole"].ToString()=="3")//�᳤
                {
                    if (strState == "��������ͨ��")
                        btchecky1.Visible = btcheckn.Visible = true;//��ʾͨ����δͨ����ť
                }
                if (strState=="δͨ��")
                {
                    if (Lbbenfrom.Text.Trim() == Session["benfactorFrom"].ToString())//��ǰ�û�Ϊִ�е�λ
                        btnReapply.Visible = true;
                }
                if (strType == "�ʽ�")
                    dgData1.Visible = false;
                else if (strType == "��Ʒ")
                    dgData0.Visible = false;
                dgData.Columns[0].Visible=false;
                if(strState == "������")
                {
                    if((Lbbenfrom.Text==Session["benfactorFrom"].ToString())||(Session["benfactorFrom"].ToString() == "�����г���������Э�������")||(Session["UserName"].ToString()=="admin"))
                    {//��Ŀʵʩ��λ ���� ������ ���� ����Ա
                        dgData.Columns[0].Visible = true;
                    }
                }

            }
        }

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion


        #region "ת������"
        //��ֹҳ�����"
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

        //������ʽƥ��
        private bool IsValidNum(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^[0-9]*[1-9][0-9]*$");

            //		^\d+$����//ƥ��Ǹ������������� + 0�� 
            //^[0-9]*[1-9][0-9]*$����//ƥ�������� 
            //^((-\d+)|(0+))$����//ƥ����������������� + 0�� 
            //^-[0-9]*[1-9][0-9]*$����//ƥ�为���� 
            //^-?\d+$��������//ƥ������ 
            //^\d+(\.\d+)?$����//ƥ��Ǹ����������������� + 0�� 
            //^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$����//ƥ���������� 
            //^((-\d+(\.\d+)?)|(0+(\.0+)?))$����//ƥ��������������������� + 0�� 
            //^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$����//ƥ�为������ 
            //^(-?\d+)(\.\d+)?$����//ƥ�両���� 
            //^[A-Za-z]+$����//ƥ����26��Ӣ����ĸ��ɵ��ַ��� 
            //^[A-Z]+$����//ƥ����26��Ӣ����ĸ�Ĵ�д��ɵ��ַ��� 
            //^[a-z]+$����//ƥ����26��Ӣ����ĸ��Сд��ɵ��ַ��� 
            //^[A-Za-z0-9]+$����//ƥ�������ֺ�26��Ӣ����ĸ��ɵ��ַ��� 
            //^\w+$����//ƥ�������֡�26��Ӣ����ĸ�����»�����ɵ��ַ��� 
            //^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$��������//ƥ��email��ַ 
            //^[a-zA-z]+://ƥ��(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$����//ƥ��url 
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
                string sss = "ɾ������Ŀ��" + LbproID.Text.Trim() + "�е������ˣ�" + rcpidStr;
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
            string strinsert = string.Format("update e_project set proschedule='�᳤����ͨ��',prodatatimeshen1='{1}' where projectID='{0}'", LbproID.Text,prodatatimeshen);         
            int reslut = msq.getmysqlcom(strinsert);
            if (reslut > 0)
            {
                labError.Text= "�᳤����ͨ��";
                NLogTest nlog = new NLogTest();
                string sss = "�᳤����ͨ����Ŀ��" + Lbproname.Text;
                nlog.WriteLog(Session["UserName"].ToString(), sss);
                string str11 = string.Format("insert into e_info (infoTitle,infoContent,infoDATE,infoFile,infoFrom,infoTo,infoRead) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", "�᳤����ͨ����Ŀ��" + Lbproname.Text.Trim(), "", DateTime.Now.ToString(), "", Session["UserName"].ToString(), Lbbenfrom.Text.Trim(), "δ��");
                msq.getmysqlcom(str11);
                if(Lbbenfrom.Text.Trim()!="����������Э��")
                {
                    string str12 = string.Format("insert into e_info (infoTitle,infoContent,infoDATE,infoFile,infoFrom,infoTo,infoRead) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", "�᳤����ͨ����Ŀ��" + Lbproname.Text.Trim(), "", DateTime.Now.ToString(), "", Session["UserName"].ToString(), "����������Э��", "δ��");
                    msq.getmysqlcom(str12);
                }
            }
        }
        protected void btchecky2_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string prodatatimeshen = dt.ToShortDateString().ToString();
            string strinsert = string.Format("update e_project set prodatatimeshen='{1}',proschedule='��������ͨ��' where projectID='{0}'", LbproID.Text, prodatatimeshen);        
            int reslut = msq.getmysqlcom(strinsert);
            if (reslut > 0)
            {                
                labError.Text= "��������ͨ��";
                NLogTest nlog = new NLogTest();
                string sss = "��������ͨ����Ŀ��" + Lbproname.Text;
                nlog.WriteLog(Session["UserName"].ToString(), sss);
                string str11 = string.Format("insert into e_info (infoTitle,infoContent,infoDATE,infoFile,infoFrom,infoTo,infoRead) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", "��������ͨ����Ŀ��" + Lbproname.Text.Trim(), "", DateTime.Now.ToString(), "", Session["UserName"].ToString(), Lbbenfrom.Text.Trim(), "δ��");
                msq.getmysqlcom(str11);
            }

        }
        protected void btcheckn_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string prodatatimeshen = dt.ToShortDateString().ToString();
            string strinsert = string.Format("update e_project set proschedule='δͨ��',prodatatimeshen='{1}' where projectID='{0}'", LbproID.Text, prodatatimeshen);
            int reslut = msq.getmysqlcom(strinsert);
            if (reslut > 0)
            {
                labError.Text = "����δͨ��";
                NLogTest nlog = new NLogTest();
                string sss = "δͨ��������Ŀ��" + Lbproname.Text;
                nlog.WriteLog(Session["UserName"].ToString(), sss);
                Response.Redirect("��Ϣ����.aspx?title=" + Server.UrlEncode(Lbproname.Text.Trim()) + "&branchName=" + Server.UrlEncode(Lbbenfrom.Text.Trim()));
            }
        }
        protected void btout_Click(object sender, EventArgs e)
        {
            ViewState["model"] = DropDownList1.SelectedValue.ToString();//ѡ���ģ��
            //����dgData
            if (Lbproname.Text.Trim() != "")//��Ŀ���Ʒǿ�
            {
                if(ViewState["model"].ToString()=="��1�����г���������Э�������Ŀ�����")//�������ˣ����ļ�ѹ����
                {
                    MemoryStream ms = new MemoryStream();
                    byte[] buffer = null;
                    using (ZipFile file = ZipFile.Create(ms))
                    {
                        file.BeginUpdate();
                        file.NameTransform = new MyNameTransfom();//ͨ��������Ƹ�ʽ���������Խ�������ļ�������һЩ����Ĭ������£����Զ������ļ���·����zip�д����йص��ļ��С�
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
                    //����
                    Response.AddHeader("content-disposition", "attachment;filename=Test.zip");
                    Response.BinaryWrite(buffer);
                    Response.Flush();
                    Response.End();
                }
                else
                {//�������ˣ����ļ�
                    Toprint(ViewState["model"].ToString(), "", -1);
                }


            }
        }
        public class MyNameTransfom : ICSharpCode.SharpZipLib.Core.INameTransform
        {

            #region INameTransform ��Ա
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
            string FilePath = Server.MapPath("template\\" + strFileName + ".dot");//ģ��·��
 
            string FillProjectName = Lbproname.Text.Trim();//��Ŀ����
            string FillPlanMoney = Lbplan.Text.Trim();//�ƻ�ʹ���ʽ�
            double RMB = Convert.ToDouble(FillPlanMoney);
            RMBCapitalization numClass = new RMBCapitalization();
            string FillRMB = numClass.RMBAmount(RMB);//��д�ʽ�

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

            string FillAddress = "";//���쵥λ��ַ


            #region "��ͥ��Ա"
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

            string SaveDocPath = "";//word����·��
            string SavePdfPath = "";//pdf����·��


            string strselect2 = string.Format("select address from e_handlingunit where benfactorFrom='{0}'", Lbbenfrom.Text.Trim());
            MySqlDataReader mysqlreader2 = msq.getmysqlread(strselect2);
            while(mysqlreader2.Read())
            {
                FillAddress = mysqlreader2.GetString("address");
            }
            if(pid!="")
            {//�������ˣ����ɶ���ļ������
                string strselect = string.Format("select *,date_format(from_days(to_days(now())-to_days(SUBSTRING(recipientsPIdcard,7,8))),'%Y')+0 as newAge from e_recipients where recipientsID={0}", pid);//������ID recipientsPIdcard='{0}'
                MySqlDataReader mysqlreader = msq.getmysqlread(strselect);
                while (mysqlreader.Read())
                {
                    FillName = mysqlreader.GetString("recipientsName");//����������
                    FillSex = mysqlreader.GetString("sex");//�Ա�
                    FillAge = mysqlreader.GetString("newAge");//����
                    FillRecipientsADD = mysqlreader.GetString("recipientsADD");//����
                    FillWorkplace = mysqlreader.GetString("workplace");//�����ص�
                    FillIncomlowID = mysqlreader.GetString("incomlowID");//�ͱ��������
                    FillRecipientsADDnow = mysqlreader.GetString("recipientsADDnow");//�־�ס��
                    FillTelphoneADD = mysqlreader.GetString("telphoneADD");//�ֻ���
                    FillArrIncome = mysqlreader.GetString("arrIncome");//ƽ������
                    FillCanjiID = mysqlreader.GetString("canID");//����ID
                    FillOfficerID = mysqlreader.GetString("officerID");//����֤��
                    FillPidCard = mysqlreader.GetString("recipientsPIdcard");//���֤��
                    #region "��ͥ��Ա"
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
                string selectRequest = string.Format("select request from e_pr where recipientID={0}", pid);//������ID (select recipientsID from e_recipients where recipientsPIdcard='{0}')
                mysqlreader = msq.getmysqlread(selectRequest);
                while (mysqlreader.Read())
                    FillRequest = mysqlreader.GetString("request");//��������


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




            wiw.OpenDocument(FilePath);//��ģ��
            if(strFileName=="��1�����г���������Э�������Ŀ�����")//��������ģ��
            {
                wiw.WriteIntoDocument("leibieMark", lblLeibie.Text.ToString());//��Ŀ���
                wiw.WriteIntoDocument("projectNameMark", FillProjectName);//��Ŀ����
                wiw.WriteIntoDocument("planMoneyMark", FillPlanMoney);//�������
                wiw.WriteIntoDocument("pidMark", FillPidCard);//���֤��
                wiw.WriteIntoDocument("nameMark", FillName);//����
                wiw.WriteIntoDocument("sexMark", FillSex);//�Ա�
                wiw.WriteIntoDocument("ageMark", FillAge);//����
                wiw.WriteIntoDocument("recipientsADDMark", FillRecipientsADD);//�������ڵ�
                wiw.WriteIntoDocument("workplaceMark", FillWorkplace);//������λ
                wiw.WriteIntoDocument("incomlowIDMark", FillIncomlowID);//������/�ͱ���
                wiw.WriteIntoDocument("recipientsADDnowMark", FillRecipientsADDnow);//�ּ�ͥ��ַ
                wiw.WriteIntoDocument("telphoneADDMark", FillTelphoneADD);//��ϵ�绰
                wiw.WriteIntoDocument("arrIncomeMark", FillArrIncome);//������
                wiw.WriteIntoDocument("RMBMark", FillRMB);//��д���
                wiw.WriteIntoDocument("generalIncomeMark", sumIncome.ToString());//��ͥ��������
                wiw.WriteIntoDocument("incomePerPersonMark", incomePerPerson.ToString());//��ͥ�˾�������
                wiw.WriteIntoDocument("canjiIDMark", FillCanjiID);//�м���֤��
                wiw.WriteIntoDocument("officerIDMark", FillOfficerID);//����֤��
                wiw.WriteIntoDocument("requestMark", FillRequest);//��������

                #region "��ͥ��Ա"
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
            if (strFileName == "��2�������ƾ�����ʹ����Ŀ��")
            {
                wiw.WriteIntoDocument("projectNameMark", FillProjectName);//������Ŀ
                wiw.WriteIntoDocument("planMoneyMark", FillPlanMoney);//�������
                wiw.WriteIntoDocument("RMBMark", FillRMB);//��д���
                wiw.WriteIntoDocument("conditionMark", Lbrestnow.Text.ToString());//���������
                wiw.WriteIntoDocument("descMark", projectDir.Text.ToString());//��������
                for (int i = 0; i < dgData.Items.Count;i++ )
                {
                    FillPersons = FillPersons + ((Label)(dgData.Items[i].FindControl("labID"))).Text.ToString() + "��";
                }
                wiw.WriteIntoDocument("personsMark", FillPersons);//��������
                wiw.WriteIntoDocument("numMark", dgData.Items.Count.ToString());//��������
                for (int i = 0; i < dgData0.Items.Count; i++)
                {
                    FillGuanming = FillGuanming + ((Label)(dgData0.Items[i].FindControl("labname"))).Text.ToString() + "��";
                }
                wiw.WriteIntoDocument("guanmingMark", FillGuanming);//��������������

            }
            if (strFileName == "��3�����г���������Э�������Ŀ��")
            {
                wiw.WriteIntoDocument("projectNameMark", FillProjectName);//��Ŀ����
                wiw.WriteIntoDocument("leibieMark", lblLeibie.Text.ToString());//��Ŀ���
                wiw.WriteIntoDocument("planMoneyMark", FillPlanMoney);//�������
                wiw.WriteIntoDocument("RMBMark", FillRMB);//��д���
                wiw.WriteIntoDocument("descMark", projectDir.Text.ToString());//��Ŀ����
                for (int i = 0; i < dgData0.Items.Count; i++)
                {
                    FillComefrom = FillComefrom + (i + 1).ToString() + "��" + ((Label)(dgData0.Items[i].FindControl("labname"))).Text.ToString() + "����" + ((Label)(dgData0.Items[i].FindControl("labguanming"))).Text.ToString() + "��";
                }

                wiw.WriteIntoDocument("comefromMark", FillComefrom);//�ʽ���Դ

                wiw.WriteIntoDocument("branchNameMark", Lbbenfrom.Text.Trim());//��Ŀʵʩ��λ����
                wiw.WriteIntoDocument("addressMark", FillAddress);//��ַ
                wiw.WriteIntoDocument("contactMark", Lbtelname.Text.Trim());//��ϵ��
                wiw.WriteIntoDocument("TELMark", Lbtelladd.Text.Trim());//�绰
            }

            wiw.Save_CloseDocument(SaveDocPath);
            WordToPdf(SaveDocPath, SavePdfPath);
            if(pid=="")//���ļ�ֱ������
                DownLoadFile("template\\" + strFileName + ".pdf");
        }
        public class WriteIntoWord
        {
            ApplicationClass app = null;   //����Ӧ�ó������ 
            Document doc = null;   //���� word �ĵ�����
            Object missing = System.Reflection.Missing.Value; //����ձ���
            Object isReadOnly = false;
            // �� word �ĵ�д������ 
            public void OpenDocument(string FilePath)
            {
                object filePath = FilePath;//�ĵ�·��
                app = new ApplicationClass(); //���ĵ� 
                doc = app.Documents.Open(ref filePath, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing);
                doc.Activate();//�����ĵ�
            }
            /// <summary> 
            /// </summary> 
            ///<param name="parLableName">���ǩ</param> 
            /// <param name="parFillName">д�����е�����</param> 
            /// 
            //��word������Ӧ����д��word���Ӧ��ǩ��

            public void WriteIntoDocument(string BookmarkName, string FillName)
            {
                object bookmarkName = BookmarkName;
                Bookmark bm = doc.Bookmarks.get_Item(ref bookmarkName);//������ǩ 
                bm.Range.Text = FillName;//������ǩ�������
            }
            /// <summary> 
            /// ���沢�ر� 
            /// </summary> 
            /// <param name="parSaveDocPath">�ĵ����Ϊ��·��</param>
            /// 
            public void Save_CloseDocument(string SaveDocPath)
            {
                object savePath = SaveDocPath;  //�ĵ����Ϊ��·�� 
                Object saveChanges = app.Options.BackgroundSave;//�ĵ����Ϊ 
                doc.SaveAs(ref savePath, ref missing, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                doc.Close(ref saveChanges, ref missing, ref missing);//�ر��ĵ�
                app.Quit(ref missing, ref missing, ref missing);//�ر�Ӧ�ó���

            }
        }
        //  �����ļ���
        public void DownLoadFile(string FullFileName)
        {
            // �����ļ�������·��
            string Url = FullFileName;
            // �����ļ�������·��
            string FullPath = HttpContext.Current.Server.MapPath(Url);
            // ��ʼ��FileInfo���ʵ������Ϊ�ļ�·���İ�װ
            FileInfo FI = new FileInfo(FullPath);
            // �ж��ļ��Ƿ����
            if (FI.Exists)
            {
                // ���ļ����浽����
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

        /// ��Word�ļ�ת����pdf�ļ�

        /// </summary>

        /// <param name="sourcePath">��Ҫת�����ļ�·�����ļ�����</param>

        /// <param name="targetPath">ת����ɺ���ļ���·�����ļ�������</param>

        /// <returns>�ɹ�����true,ʧ�ܷ���false</returns>
        public static bool WordToPdf(string sourcePath, string targetPath)
        {
            bool result = false;

            WdExportFormat wdExportFormatPDF = WdExportFormat.wdExportFormatPDF;//ת����ʽ1.wdExportFormatPDFת����pdf��ʽ 2.wdExportFormatXPSת����xps��ʽ

            object missing = Type.Missing;

            Microsoft.Office.Interop.Word.ApplicationClass applicationClass = null;

            Document document = null;

            try
            {
                applicationClass = new Microsoft.Office.Interop.Word.ApplicationClass();

                object inputfileName = sourcePath;//��Ҫת��ʽ���ļ�·��

                string outputFileName = targetPath;//ת����ɺ�PDF��XPS�ļ���·�����ļ�������

                WdExportFormat exportFormat = wdExportFormatPDF;//�����ļ���ʹ�õĸ�ʽ

                bool openAfterExport = false;//ת����ɺ��Ƿ��

                WdExportOptimizeFor wdExportOptimizeForPrint = WdExportOptimizeFor.wdExportOptimizeForPrint;//������ʽ1.wdExportOptimizeForPrint��Դ�ӡ���е����������ϸߣ����ɵ��ļ���С�ϴ�2.wdExportOptimizeForOnScreen �����Ļ��ʾ���е����������ϲ���ɵ��ļ���С��С��

                WdExportRange wdExportAllDocument = WdExportRange.wdExportAllDocument;//����ȫ�����ݣ�ö�٣�

                int from = 0;//��ʼҳ��

                int to = 0;//����ҳ��

                WdExportItem wdExportDocumentContent = WdExportItem.wdExportDocumentContent;//ָ�������������Ƿ�ֻ�����ı�������ı��ı��.1.wdExportDocumentContent:�����ļ�û�б��,2.�����ļ��б��

                bool includeDocProps = true;//ָ���Ƿ�����µ������ļ����ĵ�����

                bool keepIRM = true;//

                WdExportCreateBookmarks wdExportCreateWordBookmarks = WdExportCreateBookmarks.wdExportCreateWordBookmarks;//1.wdExportCreateNoBookmarks:��Ҫ�ڵ����ļ��д�����ǩ,2.wdExportCreateHeadingBookmarks��������ı��򵼳����ļ��д���һ����ǩ��3.wdExportCreateWordBookmarksÿ���ֵ���ǩ�����а���������ҳü��ҳ���е�������ǩ�������ļ��д���һ����ǩ��

                bool docStructureTags = true;

                bool bitmapMissingFonts = true;

                bool UseISO19005_1 = false;//���ɵ��ĵ��Ƿ���� ISO 19005-1 (PDF/A)

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
                ((ImageButton)e.Item.Cells[0].FindControl("btnDelete1")).Attributes.Add("onclick", "return confirm('ȷ��Ҫɾ�������������?');");
            }

        }
        protected void btnReapply_Click(object sender, EventArgs e)
        {
            Response.Redirect("��Ŀ����.aspx?id=" + LbproID.Text.Trim());
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("��Ŀ����.aspx?id=" + LbproID.Text.Trim());
        }
}
    /// <summary>
    /// ����Ҵ�Сд���ת��
    /// </summary>
    class RMBCapitalization
    {
        private const string DXSZ = "��Ҽ��������½��ƾ�";
        private const string DXDW = "����ֽ�Ԫʰ��Ǫ�fʰ��Ǫ��ʰ��Ǫ�f��ʰ��Ǫ�f�ھ�ʰ��Ǫ�f������";
        private const string SCDW = "Ԫʰ��Ǫ�f�ھ�����";

        /// <summary>
        /// ת������Ϊ��д���
        /// ��߾���Ϊ�򣬱���С�����4λ��ʵ�ʾ���Ϊ�����Ѿ��㹻�ˣ������Ͼ��������ƣ�������ʾ��
        /// ���:...30.29.28.27.26.25.24  23.22.21.20.19.18  17.16.15.14.13  12.11.10.9   8 7.6.5.4  . 3.2.1.0
        /// ��λ:...�������fǪ��ʰ        �����fǪ��ʰ       ���fǪ��ʰ      ��Ǫ��ʰ     �fǪ��ʰԪ . �Ƿ����
        /// ��ֵ:...1000000               000000             00000           0000         00000      . 0000
        /// �����г����������������ʵ�λ��
        /// Ԫ��ʮ���١�ǧ�����ڡ��ס�����������𦡢�������������ء���
        /// </summary>
        /// <param name="capValue">����ֵ</param>
        /// <returns>���ش�д���</returns>
        private string ConvertIntToUppercaseAmount(string capValue)
        {
            string currCap = "";    //��ǰ���
            string capResult = "";  //������
            string currentUnit = "";//��ǰ��λ
            string resultUnit = ""; //�����λ           
            int prevChar = -1;      //��һλ��ֵ
            int currChar = 0;       //��ǰλ��ֵ
            int posIndex = 4;       //λ����������"Ԫ"��ʼ

            if (Convert.ToDouble(capValue) == 0) return "";
            for (int i = capValue.Length - 1; i >= 0; i--)
            {
                currChar = Convert.ToInt16(capValue.Substring(i, 1));
                if (posIndex > 30)
                {
                    //�ѳ�����󾫶�"��"��ע�����Խ�30�ĳ�22��ʹ֮��ȷ�����ھ��㹻��
                    break;
                }
                else if (currChar != 0)
                {
                    //��ǰλΪ����ֵ����ֱ��ת���ɴ�д���
                    currCap = DXSZ.Substring(currChar, 1) + DXDW.Substring(posIndex, 1);
                }
                else
                {
                    //��ֹת������ֶ������,���磺3000020
                    switch (posIndex)
                    {
                        case 4: currCap = "Ԫ"; break;
                        case 8: currCap = "�f"; break;
                        case 12: currCap = "��"; break;
                        case 17: currCap = "��"; break;
                        case 23: currCap = "��"; break;
                        case 30: currCap = "��"; break;
                        default: break;
                    }
                    if (prevChar != 0)
                    {
                        if (currCap != "")
                        {
                            if (currCap != "Ԫ") currCap += "��";
                        }
                        else
                        {
                            currCap = "��";
                        }
                    }
                }
                //�Խ�������ݴ���               
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
        /// ת��С��Ϊ��д���
        /// </summary>
        /// <param name="capValue">С��ֵ</param>
        /// <param name="addZero">�Ƿ�������λ</param>
        /// <returns>���ش�д���</returns>
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
                        currCap = "��";
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
        /// ����Ҵ�д���
        /// </summary>
        /// <param name="value">��������ֽ��ֵ</param>
        /// <returns>��������Ҵ�д���</returns>
        public string RMBAmount(double value)
        {
            string capResult = "";
            string capValue = string.Format("{0:f4}", value);       //��ʽ��
            int dotPos = capValue.IndexOf(".");                     //С����λ��
            bool addInt = (Convert.ToInt32(capValue.Substring(dotPos + 1)) == 0);//�Ƿ��ڽ���м�"��"
            bool addMinus = (capValue.Substring(0, 1) == "-");      //�Ƿ��ڽ���м�"��"
            int beginPos = addMinus ? 1 : 0;                        //��ʼλ��
            string capInt = capValue.Substring(beginPos, dotPos);   //����
            string capDec = capValue.Substring(dotPos + 1);         //С��

            if (dotPos > 0)
            {
                capResult = ConvertIntToUppercaseAmount(capInt) +
                    ConvertDecToUppercaseAmount(capDec, Convert.ToDouble(capInt) != 0 ? true : false);
            }
            else
            {
                capResult = ConvertIntToUppercaseAmount(capDec);
            }
            if (addMinus) capResult = "��" + capResult;
            if (addInt) capResult += "��";
            return capResult;
        }
    }
}