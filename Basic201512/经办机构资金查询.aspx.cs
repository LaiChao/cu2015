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

namespace CL.Utility.Web.BasicData
{
    /// <summary>
    /// Meter ��ժҪ˵����
    /// </summary>
    public partial class Register : System.Web.UI.Page
    {
        //#region "�Զ�������"
        //internal static Manager manager = Managers.Members["NewUtilityOra"] as Manager;
        //internal static ISingleTable entityUsers = manager.Entities["USERS"] as ISingleTable;
        //private DataTable dtUsers;

        //private string bindPCKey = "USER_ID";//�� ��Դ�ڵ����ݵ�����

        //internal static WriteLog wl = new WriteLog();
        //internal static UserInterface ui = new UserInterface();
        //private const string PAGE_NAME = "�ʽ�¼��";

        //public const string sPMS_CTG_ID = "USER_ID";
        //public const string sPMS_CTG_NAME = "USER_NAME";
        //public const string sPwd = "USER_PWD";
        //public const string sUSE_IDT = "USE_IDT";
        //public const string sCRT_DATE = "CRT_DATE";
        //public const string sUPD_DATE = "UPD_DATE";
        //public const string sDES = "DES";


        //private const string PK = "projectID";
        //public const string sID = "projectID";
        //public const string sName = "projectName";//publicʱҳ�������ã�privateʱ������
        //protected System.Data.DataTable _dtData;
        //protected System.Data.DataTable _dtData1;
        //mysqlconn msq = new mysqlconn();
        //string sqldata1 = string.Format("select * from e_project");
        //string sqldata = string.Format("select * from e_handlingunit");
        //string sqldatadrop = string.Format("select *from e_recipientsfenpei");
        //#endregion
        mysqlconn msq = new mysqlconn();
        
        string nameNow = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
             if (!Page.IsPostBack)
             {
                 //string strhand = string.Format("select (select sum(useMoney) from e_moneytrack where DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by handlingunitID) as thisMonth,benfactorFrom,(sum(capitalIn)-sum(capitalEarn)) as useUp,sum(capitalEarn) as remain from e_capital group by handlingunitID");
                 //string strhand = string.Format("(select benfactorFrom,(sum(capitalIn)-sum(capitalEarn)) as useUp,sum(capitalEarn) as remain from e_capital group by handlingunitID) aaa join (select handlingunitID,sum(useMoney) as thisMonth from e_moneytrack where DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by handlingunitID) bbb on bbb.handlingunitID=aaa.handlingunitID");
                 //string strhand = string.Format("select sum(useMoney) as thisMonth,e_capital.benfactorFrom,(sum(capitalIn)-sum(capitalEarn)) as useUp,sum(capitalEarn) as remain from e_capital,e_moneytrack where e_capital.handlingunitID=e_moneytrack.handlingunitID and DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by e_capital.handlingunitID");
                 //(select sum(useMoney) from e_moneytrack where DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by handlingunitID) as thisMonth,
                 string strhand = string.Format("select * from (select handlingunitID,benfactorFrom,sum(useMoney) as thisMonth from e_moneytrack where DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by handlingunitID) aaa,(select handlingunitID,sum(capitalEarn) as remain from e_capital group by handlingunitID) bbb where aaa.handlingunitID=bbb.handlingunitID");
                 //"(select handlingunitID,sum(useMoney) as monthUse from e_moneytrack where DATE_FORMAT(prouseoutTime,'%Y%m')=DATE_FORMAT(CURDATE(),'%Y%m') group by handlingunitID) aaa"
                 //"(select handlingunitID,benfactorFrom,(sum(capitalIn)-sum(capitalEarn)) as useUp,sum(capitalEarn) as remain from e_capital group by handlingunitID) bbb"
                 BindData(strhand);
                
             }        
        }

        //#region Web ������������ɵĴ���
        //override protected void OnInit(EventArgs e)
        //{
        //    //
        //    // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
        //    //
        //    InitializeComponent();
        //    base.OnInit(e);
        //}

        ///// <summary>
        ///// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        ///// �˷��������ݡ�
        ///// </summary>
        //private void InitializeComponent()
        //{
           
        //}
        //#endregion
        //#region "ת������"
        ////��ֹҳ�����"
        ////		private void RetainScrollPosition()
        ////		{
        ////			StringBuilder saveScrollPosition = new StringBuilder ();
        ////			StringBuilder setScrollPosition = new StringBuilder ();
        ////
        ////			RegisterHiddenField("__SCROLLPOS", "0");
        ////
        ////			saveScrollPosition.Append("<script language='javascript'>");
        ////			saveScrollPosition.Append("function saveScrollPosition() {");
        ////			saveScrollPosition.Append("    document.forms[0].__SCROLLPOS.value = thebody.scrollTop;");
        ////			saveScrollPosition.Append("}");
        ////			saveScrollPosition.Append("thebody.onscroll=saveScrollPosition;");
        ////			saveScrollPosition.Append("</script>");
        ////
        ////			RegisterStartupScript("saveScroll", saveScrollPosition.ToString());
        ////
        ////			if (Page.IsPostBack)
        ////			{
        ////				setScrollPosition.Append("<script language='javascript'>");
        ////				setScrollPosition.Append("function setScrollPosition() {");
        ////				setScrollPosition.Append("    thebody.scrollTop = " + Request["__SCROLLPOS"] + ";");
        ////				setScrollPosition.Append("}");
        ////				setScrollPosition.Append("thebody.onload=setScrollPosition;");
        ////				setScrollPosition.Append("</script>");
        ////
        ////				RegisterStartupScript("setScroll", setScrollPosition.ToString());
        ////			}
        ////		}

        ////������ʽƥ��
        //private bool IsValidNum(string strIn)
        //{
        //    // Return true if strIn is in valid e-mail format.
        //    return Regex.IsMatch(strIn, @"^[0-9]*[1-9][0-9]*$");

        //    //		^\d+$����//ƥ��Ǹ������������� + 0�� 
        //    //^[0-9]*[1-9][0-9]*$����//ƥ�������� 
        //    //^((-\d+)|(0+))$����//ƥ����������������� + 0�� 
        //    //^-[0-9]*[1-9][0-9]*$����//ƥ�为���� 
        //    //^-?\d+$��������//ƥ������ 
        //    //^\d+(\.\d+)?$����//ƥ��Ǹ����������������� + 0�� 
        //    //^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$����//ƥ���������� 
        //    //^((-\d+(\.\d+)?)|(0+(\.0+)?))$����//ƥ��������������������� + 0�� 
        //    //^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$����//ƥ�为������ 
        //    //^(-?\d+)(\.\d+)?$����//ƥ�両���� 
        //    //^[A-Za-z]+$����//ƥ����26��Ӣ����ĸ��ɵ��ַ��� 
        //    //^[A-Z]+$����//ƥ����26��Ӣ����ĸ�Ĵ�д��ɵ��ַ��� 
        //    //^[a-z]+$����//ƥ����26��Ӣ����ĸ��Сд��ɵ��ַ��� 
        //    //^[A-Za-z0-9]+$����//ƥ�������ֺ�26��Ӣ����ĸ��ɵ��ַ��� 
        //    //^\w+$����//ƥ�������֡�26��Ӣ����ĸ�����»�����ɵ��ַ��� 
        //    //^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$��������//ƥ��email��ַ 
        //    //^[a-zA-z]+://ƥ��(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$����//ƥ��url 
        //}
        //public bool Checked(object obj)
        //{
        //    if (obj.ToString() == "0")
        //    {
        //        return false;
        //    }
        //    else return true;
        //}
        //#endregion

        //private void BindDataSet()
        //{
        //    string strhand = string.Format("select benfactorFrom,handlingunitID from e_handlingunit");
        //    DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(),strhand);
        //    DataView dv = new DataView(ds.Tables[0]);
        //    dpdhand.DataSource = dv;
            
        //    dpdhand.DataTextField = "benfactorFrom";
        //    dpdhand.DataBind(); 
        //}
        private void BindData(string s)
        {
            DataSet ds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), s);
            DataView dv = new DataView(ds.Tables[0]);
            GridView1.DataSource = dv;
            GridView1.DataKeyNames = new string[] { "benfactorFrom" };//����
            GridView1.DataBind();
         
        }

        //protected void btyes_Click(object sender, EventArgs e)
        //{
        //    string strcapall = string.Format("select sum(capitalIn) from e_capital where handlingunitID=(select handlingunitID from e_handlingunit where benfactorFrom='{0}')", dpdhand.Text);
        //    MySqlDataReader sqldatareader = msq.getmysqlread(strcapall);
        //    string strcapnow = string.Format("select sum(capitalEarn) from e_capital where handlingunitID=(select handlingunitID from e_handlingunit where benfactorFrom='{0}')", dpdhand.Text);
        //    MySqlDataReader sqldatareader1 = msq.getmysqlread(strcapnow);
            
        //    while (sqldatareader1.Read())
        //    {
        //        lbcaptIDnow.Text = sqldatareader1.GetString(0);
        //    }
            
        //    while (sqldatareader.Read())
        //    {
        //        int i = int.Parse(sqldatareader.GetString(0));
        //        int ia = int.Parse(lbcaptIDnow.Text);
        //        lbcaptIDall.Text = (i - ia).ToString();
               
        //    }
            
        //    NLogTest nlog = new NLogTest();
        //    string sss = "��ѯ����������������" + dpdhand.Text;
        //    nlog.WriteLog(Session["UserName"].ToString(), sss);
            
            
        //}
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    //string queryString="select benfactorFrom,(sum(capitalIn)-sum(capitalEarn)) as useUp,sum(capitalEarn) as remain from e_capital where group by handlingunitID";
        //    //BindData(queryString);

        //}
}
}
