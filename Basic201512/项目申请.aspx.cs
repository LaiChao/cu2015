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
using System.Text;

namespace CL.Utility.Web.BasicData
{
    /// <summary>
    /// Meter ��ժҪ˵����
    /// </summary>
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
        string str111 = string.Format("select *,date_format(from_days(to_days(now())-to_days(SUBSTRING(recipientsPIdcard,7,8))),'%Y')+0 as newAge from e_recipients where 1=1");
        string sqldata1 = string.Format("select * from e_project");
        string sqldatadrop = string.Format("select *from e_recipientsfenpei");     
        #endregion
        string sqldata = string.Format("select * from e_handlingunit");
        
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["init"] = "select *,date_format(from_days(to_days(now())-to_days(SUBSTRING(recipientsPIdcard,7,8))),'%Y')+0 as newAge from e_recipients where benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ";
                ViewState["now"] = ViewState["init"];
                databind(ViewState["now"].ToString());

                lblBranch.Text = Session["benfactorFrom"].ToString();
            }          
        }
        private void databind(string s)
        {
            
            DataSet dds = MySqlHelper.ExecuteDataset(msq.getmysqlcon(), s);
            DataView ddv = new DataView(dds.Tables[0]);
            dgData.DataSource = dds;
            dgData.DataBind();
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


            this.dgData.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData_EditCommand);
            this.dgData.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData_UpdateCommand);
            this.dgData.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData_CancelCommand);
            this.dgData.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgData_ItemDataBound);
            //this.dgData.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgData_DeleteCommand);
            //this.dgData.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgData_ItemDataBound);
            //this.dgHeader.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgHeader_ItemCommand);

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
       
        #region "ҳ�����"


        private void dgData_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            dgData.EditItemIndex = -1;
            databind(ViewState["now"].ToString());
        }

        //private void dgData_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{


        //}

        private void dgData_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {

            dgData.EditItemIndex = e.Item.ItemIndex;
            databind(ViewState["now"].ToString());
        }

        private void dgData_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            //string strupdata = string.Format("insert into e_recipients_project (branchID,branchName,projectID,recipientID,recipientName) values ({0},'{1}','{2}',{3},'{4}')", ViewState["BranchID"].ToString(), ViewState["BranchName"], Session["ProjectID"].ToString(), ((Label)e.Item.FindControl("lblID")).Text.Trim(), ((Label)e.Item.FindControl("labID")).Text.Trim());            
            if(Session["ProjectID"]==null)
            {
                labError.Text = "���Ȼ�ȡ��ĿID";
                return;
            }
            string strupdata = string.Format("insert into e_pr (projectID,recipientID) values ({0},{1})", Session["ProjectID"].ToString(), ((Label)e.Item.FindControl("lblID")).Text.Trim());
            msq.getmysqlcom(strupdata);

            dgData.EditItemIndex = -1;
            databind(ViewState["now"].ToString());
   
            NLogTest nlog = new NLogTest();
            string sss = "���������ˣ�" + LbproID.Text;
            nlog.WriteLog(Session["UserName"].ToString(), sss);
        }

        private void dgData_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.AlternatingItem:
                case ListItemType.Item:
                    {
                        e.Item.Attributes.Add

                            ("onmouseover", "this.style.backgroundColor='Silver'");
                        e.Item.Attributes.Add

                            ("onmouseout", "this.style.backgroundColor='white'");

                        // ImageButton btn = (ImageButton)e.Item.FindControl("btnDelete");
                        // btn.Attributes.Add("onclick", "return confirm('ɾ�����ݿ��ܵ������صĺ�������Ƿ�ȷ��ɾ��?');");
                        break;
                    }


                case ListItemType.EditItem:
                    {
                        break;
                    }
            }
        }
        #endregion 
  
        #region "������ĿID"
        protected void btnGetId_Click(object sender, EventArgs e)
        {
            string sqldata12 = string.Format("select handlingunitID,benfactorFrom from e_handlingunit where benfactorFrom='{0}'", Session["benfactorFrom"].ToString());
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sqldata12;
            cmd.Connection = msq.getmysqlcon();
            cmd.Connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                ViewState["BranchID"] = reader.GetString(0);
                ViewState["BranchName"] = reader.GetString(1);
                LbproID.Text = reader.GetString(0) + DateTime.Now.ToString("yyyyMMddHHmm");
                labError.Text = "��������ĿID";
                btntijiao.Visible = true;
                btnBatch.Visible = true;
                btnBatchAdd.Visible = true;
                btnGetId.Visible = false;
            }
            else
            {
                LbproID.Text = "������ĿIDʧ��";
            }
            cmd.Connection.Close();
            Session["ProjectID"] = LbproID.Text.ToString();

        }
        #endregion

        private void dgHeader_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                string strID = ((TextBox)e.Item.FindControl("txtAddID")).Text.Trim();
                if (strID == "")
                {
                    labError.ForeColor = System.Drawing.Color.Red;
                    labError.Text = "�����룺" + PAGE_NAME + "ID";
                    return;
                }
                string errMsg = "";
                if (!luyunfei.lyf_validate.isAZaz09_(strID, 1, 8, out errMsg))
                {
                    labError.Text = "�����ID����" + errMsg;
                    return;
                }
                string strName = ((TextBox)e.Item.FindControl("txtAddName")).Text.Trim();
                if (strName == "")
                {
                    labError.ForeColor = System.Drawing.Color.Red;  
                    labError.Text = "�����룺" + PAGE_NAME + "����";
                    return;
                }
                if (!luyunfei.lyf_validate.isAZaz09_Ch(strName, 1, 10, out errMsg))
                {
                    labError.Text = "�����" + PAGE_NAME + "��������" + errMsg;
                    return;
                }
                string strOrder = ((TextBox)e.Item.FindControl("txtAddOrder")).Text.Trim();
                if (string.IsNullOrEmpty(strOrder))
                {
                    strOrder = "1";
                }
                int Order = 1;
                if (!int.TryParse(strOrder, out Order))
                {
                    labError.Text = "��������������Ϊ���!";
                    return;
                }
                bool bState = ((CheckBox)e.Item.FindControl("ckAddState")).Checked;
                int State;
                if (bState == false)
                {
                    State = 0;
                }
                else
                {
                    State = 1;
                }
                string strBtw = ((TextBox)e.Item.FindControl("txtAddBtw")).Text.Trim();
                databind(ViewState["now"].ToString());
               
                try
                {
                    DataRow dr = _dtData.NewRow();
                    dr[sID] = strID;
                    dr[sName] = strName;
                    dr["DISPLAY_ORDER"] = Order;
                    dr["USE_IDENTIFIER"] = State;
                    dr["CREATE_TIME"] = DateTime.Now;
                    dr["DESCRIPTION"] = strBtw;
             //     bool result = Convert.ToBoolean(_entitySubentry.Insert(dr));
                    string sqldata1 = string.Format("select * from e_recipientsfenpei where from ");///////////////
                    int result1 = msq.getmysqlcom(sqldata1);
                    if (result1>0)
                    {
                        labError.ForeColor = System.Drawing.Color.Blue;
                        labError.Text = "�ɹ����һ����¼";
                 //     wl.WriteLogData(PAGE_NAME, "����", strID, System.Diagnostics.EventLogEntryType.Information);
                    }
                    else
                    {
                        labError.Text = "��Ӽ�¼ʧ��";
                  //    wl.WriteLogData(PAGE_NAME, "����", strID, System.Diagnostics.EventLogEntryType.Warning);
                    }
                }
                catch (Exception ex)
                {
                    labError.Text = "��Ӽ�¼ʧ��" + ui.ExceptionMsg(ex);
                //  wl.WriteLogData(PAGE_NAME, "����", strID + ":" + ex.Message + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
                }
                databind(ViewState["now"].ToString());
            }
        }

        #region "�ύ��Ŀ����"
        protected void btntijiao_Click(object sender, EventArgs e)
        {
            if (LbproID.Text.Trim() == "")
            {
                labError.Text = "���ȡ��ĿID";
                return;
            }
            if (recipientsType.SelectedValue == "��ѡ��")
            {
                labError.Text = "��ѡ����Ŀ���";
                return;
            }
            if (projectID.Text.Trim().Length <= 0)
            {
                labError.Text = "��Ŀ���Ʋ���Ϊ��";
                return;
            }
            if (projectDir.Text.Trim().Length <= 0)
            {
                labError.Text = "��Ŀ��������Ϊ��";
                return;
            }
            if (txtPLAN.Text.Trim().Length <= 0)
            {
                labError.Text = "��ĿԤ�㲻��Ϊ��";
                return;
            }
            if (txtDIR.Text.Trim().Length <= 0)
            {
                labError.Text = "��������������Ϊ��";
                return;
            }
            else
            {
                DateTime dt = DateTime.Now;
                string prodatatime = dt.ToShortDateString().ToString();
                string str11 = string.Format("insert into e_project (projectID,projectName,projectDir,palnMoney,recipientsNow,benfactorFrom,telphoneName,telphoneADD,prodatatime,proschedule,shenpi1,shenpi2,projectLei,needMoney,projectType) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','������','0','0','{9}',{10},'{11}')", LbproID.Text, projectID.Text, projectDir.Text, txtPLAN.Text, txtDIR.Text, Session["benfactorFrom"].ToString(), txttel.Text, txtteladd.Text, prodatatime, recipientsType.SelectedValue.ToString(), txtPLAN.Text, ddlType.SelectedValue.ToString());
                int res = msq.getmysqlcom(str11);
                if (res > 0)
                {
                    labError.Text = "�����Ŀ�ɹ�";
                }
                else
                {
                    labError.Text = "�����Ŀʧ��";
                }
            }

            NLogTest nlog = new NLogTest();
            string sss = "�����Ŀ��" + projectID.Text;
            nlog.WriteLog(Session["UserName"].ToString(), sss);


        }
        #endregion

        #region "����������"
        protected void Btselect_Click(object sender, EventArgs e)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.Append("select newtable.* from (select *,date_format(from_days(to_days(now())-to_days(SUBSTRING(recipientsPIdcard,7,8))),'%Y')+0 as newAge from e_recipients) newtable where benfactorFrom='" + Session["benfactorFrom"].ToString() + "' ");
            if(tbName.Text != "")
                queryString.Append("and recipientsName='" + tbName.Text.ToString() + "' ");
            if (tbAge.Text != "")
                queryString.Append("and newAge=" + tbAge.Text.ToString() + " ");
            if (Tbselect.Text != "")
                queryString.Append("and recipientsPIdcard='" + Tbselect.Text.ToString() + "'");
            //string str11 = string.Format("select * from e_recipients where recipientsPIdcard='{0}'", Tbselect.Text.Trim());
            ViewState["query"] = queryString.ToString();
            ViewState["now"] = ViewState["query"];
            databind(ViewState["now"].ToString());
        }
        #endregion
        protected void dgData_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgData.CurrentPageIndex = e.NewPageIndex;
            databind(ViewState["now"].ToString());
        }
        protected void btnBatch_Click(object sender, EventArgs e)
        {
            Response.Redirect("����ѡ��������.aspx?id=" + Session["ProjectID"].ToString().Trim());
        }

        protected void btnBatchAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("�������������.aspx?id=" + Session["ProjectID"].ToString().Trim());
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedValue == "��Ʒ")
            {
                txtPLAN.Text = "0";
                txtPLAN.Enabled = false;
            }
            if(ddlType.SelectedValue=="�ʽ�")
            {
                txtPLAN.Enabled = true;
            }
        }

}
}
