<%@ Page Language="c#" Inherits="CL.Utility.Web.BasicData.Register" CodeFile="��Ŀ��������.aspx.cs" EnableEventValidation="false" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- ����3��meta��ǩ*����*������ǰ�棬�κ��������ݶ�*����*������� -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>��Ŀ����</title>

    <!-- Bootstrap core CSS -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
    <%-- <link href="../../dist/css/bootstrap-theme.min.css" rel="stylesheet">--%>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="theme.css" rel="stylesheet">

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="../../assets/js/ie-emulation-modes-warning.js"></script>
    <style type="text/css">
        tr { padding: 0; margin: 0; border: 0; }
        td { text-align: center; }
        .data_Option { width: 50px; }
        .data_Id { width: 180px; }
        .data_Name { width: 300px; }
        .data_ShortName { width: 300px; }
        .data_Energy { width: 80px; }
        .data_SubItem { width: 140px; }
        .data_Purpose { width: 80px; }
        .data_Business { width: 80px; }
        .data_Index { width: 50px; }
        .data_Open { width: 40px; }
        .data_Beizhu { width: 230px; }
    </style>
    <script language="javascript" type="text/javascript">
        var currentFocus;
        var currentScrollTop;
        //window.onload = function () {
        //    document.all.item('div_dynamic').scrollTop = currentScrollTop;
        //    var ctl;
        //}
        function ck() {
            var txt = document.getElementById("txtID").value;
            var txtpwd = document.getElementById("txtPWD");
            var lblerr = document.getElementById("lblErr");
           // alert(lblerr.innerText);
            //alert(isNumberOr_Letter(txt));

            if (isNumberOr_Letter(txt)) {
                lblerr.innerText = "�û�������";
                //txtpwd.value = "�û�������";
                document.getElementById("Form1").submit();
                alert(11);
            }
            else {
                lblerr.innerText = "�û���������";
                //txtpwd.value = "�û���������";
            }
        }
        function ck2() {
            txtpwd.value = "�û�������";
         }
        function isNumberOr_Letter(s) {//�ж��Ƿ������ֻ���ĸ 

            var regu = "^[0-9a-zA-Z\_]{5,15}$";
            var re = new RegExp(regu);
            if (re.test(s)) {
                return true;
            } else {
                return false;
            }
            
        }
        function openform(theURL,winName,features) {
           // newwin = window.showModalDialog(theURL, winName, features);
            newwin = window.showModalDialog(theURL,winName,features);
        }
        function tdisplay()
        {
            document.getElementById("Panel2").style.visibility = true;
        }
       
    </script>
    
    <style type="text/css">
        #nav { width: 1200px; height: 60px; line-height: 30px; }
        
       /* .body { width: 1660px; }*/
        .short_name, .energy, .meter_type, .xishu, .upper_limit { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }

        .energy { width: 80px; }
        .meter_type { width: 80px; }
        .xishu { width: 60px; }
        .upper_limit { width: 80px; }
        
        #divTitle { height: 60px; line-height: 60px; font-size: 26px; border: #cc9966 0px solid; text-align: center; font-weight: bold; }
        #div_dynamic {  border: #cc9966 0px solid;  }
        #divTitle, #div_dynamic { width: 800px; margin:0 auto; }
        .option, .id, .name, .order, .state, .description, .area { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
        .option { width: 50px; }
        .data_Id { width: 130px; }
        .name { width: 170px; }
        .data_Index { width: 170px; }
        .state { width: 60px; }
        .description { width: 200px; }
        .txtbox { width: 95%; padding: 0; margin: 0; }
        .area { width: 100px; }
    </style>
</head>
    
<body id="thebody">
     <div id="divPrint" runat="server">
         <center>
    <form id="Form1" method="post" runat="server" onsubmit="ck2()">
        <div id="div_dynamic" >
        <style>
        tr{ line-height:30px;height:30px;}
        .td_c1{ width:20px;}
            .auto-style6 {
                width: 200px;
                text-align:right;
            }
            .auto-style8 {
                width: 100px;
                height: 30px;
            }
            .auto-style9 {
                width: 293px;
                height: 30px;
                margin-left: 40px;
                text-align:left;
            }
            .auto-style11 {
                width: 293px;
                text-align:left;
            }
            .auto-style12 {
                width: 800px;
            }
            </style>
            <div>
                <h2>
                  <strong>��Ŀ����</strong>  
                </h2>
            </div>
        
            <table style="width: 800px" align="center" class="table">
                <thead>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="labError" runat="server" align="center" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                            �� Ŀ ID��
                        </td>
                        <td class="auto-style11">
                            <asp:Label ID="LbproID" runat="server" Text=""></asp:Label>
                        </td>                     
                    </tr>
                </thead>
                <tr>
                    <td class="auto-style6">
                        �� Ŀ �� �� </td>
                    <td class="auto-style9">
                        <asp:Label ID="lblLeibie" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        �� Ŀ �� �ƣ� </td>
                    <td class="auto-style9">
                        <asp:Label ID="Lbproname" runat="server"></asp:Label>
                    </td>            
                </tr>
                <tr>
                    <td class="auto-style6">
                        �� Ŀ �� ����
                    </td>
                    <td class="auto-style11">
                        <asp:Label ID="projectDir" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style6">
                        �ƻ�ʹ���ƿ </td>
                    <td class="auto-style9">
                        <asp:Label ID="Lbplan" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style6">
                        ����������������
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="Lbrestnow" runat="server"></asp:Label>
                    </td>
                    
                </tr>
             
                
                <tr>
                    <td class="auto-style6">
                        �� ϵ �ˣ�</td>
                    <td class="auto-style9">
                        <asp:Label ID="Lbtel" runat="server" Text="��ϵ��������"></asp:Label>
                        <asp:Label ID="Lbtelname" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Lbteladd" runat="server" Text="��ϵ�˵绰��"></asp:Label>
                        <asp:Label ID="Lbtelladd" runat="server"></asp:Label>

                        </td>
                </tr>

                <tfoot>
                    <tr>
                        <td class="auto-style6">��Ŀʵʩ��λ:</td>
                        <td class="auto-style9">
                            <asp:Label ID="Lbbenfrom" runat="server"></asp:Label>
                        </td>                        
                        </tr>
                    <tr>
                       <td class="auto-style8"> 
                        </td>
                        <td class="auto-style9">
                    <asp:Button ID="btchecky1" runat="server" Text="�᳤����ͨ��" OnClick="btchecky1_Click" CssClass=" btn btn-danger" />
                    <asp:Button ID="btchecky2" runat="server" Text="��������ͨ��" OnClick="btchecky2_Click" CssClass=" btn btn-danger " />
                    <asp:Button ID="btcheckn" runat="server" Text="����δͨ��" Width="116px"  CssClass=" btn btn-danger" OnClick="btcheckn_Click" />
                    <asp:Button ID="btnReapply" runat="server" Text="��������" CssClass=" btn btn-danger " OnClick="btnReapply_Click" />
                            <br />
                            ѡ��ģ�壺
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>��1�����г���������Э�������Ŀ�����</asp:ListItem>
                                <asp:ListItem>��2�������ƾ�����ʹ����Ŀ��</asp:ListItem>
                                <asp:ListItem>��3�����г���������Э�������Ŀ��</asp:ListItem>
                            </asp:DropDownList>
                    <asp:Button ID="btout" runat="server" OnClick="btout_Click" Text="����" CssClass=" btn btn-danger" />
                        </td>                                         
                    </tr>
                </tfoot>
                
            </table>
              
            <table style="width: 800px" align="center" class="table">
            <tr>
                    <td class="auto-style12">
    <asp:DataGrid ID="dgData0" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="676px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <ItemStyle CssClass="dg_item" BackColor="White" ForeColor="#330099"></ItemStyle>
            <EditItemStyle CssClass="dg_item" />
            <Columns>
                
                <asp:TemplateColumn HeaderText="������ID">
                    <ItemStyle CssClass="id"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labID0" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benefactorID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditID0" runat="server" MaxLength="8" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benefactorID") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="����������">
                    <ItemStyle CssClass="id"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labname" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtname" runat="server" MaxLength="8" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                
                <asp:TemplateColumn HeaderText="��ϵ��ʽ">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labteladd" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benefactorID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtteladd" runat="server" MaxLength="6" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benefactorID") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <%--<asp:TemplateColumn HeaderText="����">
                    <ItemStyle CssClass="idt"></ItemStyle>
                    <ItemTemplate>
                        <asp:CheckBox ID="ckState" runat="server" ToolTip="���ñ�ʾ������Ϊ����" CssClass="txtbox"
                            Checked=''
                            Enabled="False"></asp:CheckBox>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <font face="����">
                            <asp:CheckBox ID="ckEditState" runat="server" CssClass="txtbox" Checked=''
                                oolTip="���ñ�ʾ������Ϊ����"></asp:CheckBox></font>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>                         
                <asp:TemplateColumn HeaderText="�����ʽ�" HeaderStyle-Font-Names="true">

                   <HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle CssClass="des"></ItemStyle>
                    
                    <ItemTemplate>
                        <asp:Label ID="labguanming" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.useMoney") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditguanming" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.useMoney") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="����ʱ��" HeaderStyle-Font-Names="true">

                   <HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle CssClass="des"></ItemStyle>
                    
                    <ItemTemplate>
                        <asp:Label ID="labwuzhu" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.prouseoutTime") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditwuzhu" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.prouseoutTime") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
               
                
 
            </Columns>
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:DataGrid>                       
                    </td>
                </tr>
            <tr>
                    <td class="auto-style12">               
    <asp:DataGrid ID="dgData" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="677px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" DataKeyField="recipientsID" OnItemCommand="dgData_ItemCommand" OnItemDataBound="dgData_ItemDataBound" >
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <ItemStyle CssClass="dg_item" BackColor="White" ForeColor="#330099"></ItemStyle>
            <EditItemStyle CssClass="dg_item" />
            <Columns>
                <asp:TemplateColumn HeaderText="ɾ��">
                    <ItemStyle CssClass="option"></ItemStyle>
                    <ItemTemplate>
<%--                        <asp:ImageButton ID="btnEdit1" runat="server" ToolTip="����" CommandName="Edit1" ImageUrl="../CommUI/Images/icon-pencil.gif">
                        </asp:ImageButton>--%>
                        <asp:ImageButton ID="btnDelete1" runat="server" ToolTip="ɾ��������" ImageUrl="../CommUI/Images/icon-delete.gif"
                            CommandName="Delete1"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateColumn>
            
                <asp:TemplateColumn HeaderText="����������">
                    <ItemStyle CssClass="id"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditID" runat="server" MaxLength="8" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsName") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="���֤��">
                    <ItemStyle CssClass="name"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labName" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsPIdcard") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditName" runat="server" MaxLength="10" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsPIdcard") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="��Դ">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labOrder" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditOrder" runat="server" MaxLength="6" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <%--<asp:TemplateColumn HeaderText="����">
                    <ItemStyle CssClass="idt"></ItemStyle>
                    <ItemTemplate>
                        <asp:CheckBox ID="ckState" runat="server" ToolTip="���ñ�ʾ������Ϊ����" CssClass="txtbox"
                            Checked=''
                            Enabled="False"></asp:CheckBox>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <font face="����">
                            <asp:CheckBox ID="ckEditState" runat="server" CssClass="txtbox" Checked=''
                                oolTip="���ñ�ʾ������Ϊ����"></asp:CheckBox></font>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>              
                <asp:TemplateColumn Visible="False" HeaderText="ά��ʱ��">
                    <ItemTemplate>
                        <asp:Label ID="labMaintainDate" runat="server" CssClass="txtbox" Text=''>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditMaintainDate" runat="server" CssClass="txtbox" Text=''
                            Enabled="False">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="��ע˵��" HeaderStyle-Font-Names="true">

<HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle CssClass="des"></ItemStyle>
                    
                    <ItemTemplate>
                        <asp:Label ID="labBtw" runat="server" CssClass="txtbox" Text=''>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditBtw" runat="server" MaxLength="40" CssClass="txtbox" Text=''>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:DataGrid>
                      
                    </td>
                </tr>      
                <tr>
                    <td class="auto-style12">
                       
    <asp:DataGrid ID="dgData1" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="676px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <ItemStyle CssClass="dg_item" BackColor="White" ForeColor="#330099"></ItemStyle>
            <EditItemStyle CssClass="dg_item" />
            <Columns>
                
                <asp:TemplateColumn HeaderText="������ID">
                    <ItemStyle CssClass="id"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labID1" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditID1" runat="server" MaxLength="8" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorID") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="����������">
                    <ItemStyle CssClass="id"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labname1" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtname1" runat="server" MaxLength="8" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                
<%--                <asp:TemplateColumn HeaderText="��ϵ��ʽ">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labteladd" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benefactorID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtteladd" runat="server" MaxLength="6" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benefactorID") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>
                <%--<asp:TemplateColumn HeaderText="����">
                    <ItemStyle CssClass="idt"></ItemStyle>
                    <ItemTemplate>
                        <asp:CheckBox ID="ckState" runat="server" ToolTip="���ñ�ʾ������Ϊ����" CssClass="txtbox"
                            Checked=''
                            Enabled="False"></asp:CheckBox>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <font face="����">
                            <asp:CheckBox ID="ckEditState" runat="server" CssClass="txtbox" Checked=''
                                oolTip="���ñ�ʾ������Ϊ����"></asp:CheckBox></font>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>                         
                <asp:TemplateColumn HeaderText="������Ʒ" HeaderStyle-Font-Names="true">

                   <HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle CssClass="des"></ItemStyle>
                    
                    <ItemTemplate>
                        <asp:Label ID="lblItem" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.item") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbItem" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.item") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="ʹ��ʱ��" HeaderStyle-Font-Names="true">

                   <HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle CssClass="des"></ItemStyle>
                    
                    <ItemTemplate>
                        <asp:Label ID="lblTime" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.timeOut") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbTime" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.timeOut") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
               
            </Columns>
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:DataGrid>
                          
                    </td>
                </tr>
            </table>
        
    </div>
    </form>
         </center>
         </div>
</body>
</html>
