<%@ Page Language="c#" Inherits="CL.Utility.Web.BasicData.Register" CodeFile="��Ŀ����.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <meta charset="utf-8">
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
        //function ck() {
        //    var txt = document.getElementById("txtID").value;
        //    var txtpwd = document.getElementById("txtPWD");
        //    var lblerr = document.getElementById("lblErr");
        //   // alert(lblerr.innerText);
        //    //alert(isNumberOr_Letter(txt));

        //    if (isNumberOr_Letter(txt)) {
        //        lblerr.innerText = "�û�������";
        //        //txtpwd.value = "�û�������";
        //        document.getElementById("Form1").submit();
        //        alert(11);
        //    }
        //    else {
        //        lblerr.innerText = "�û���������";
        //        //txtpwd.value = "�û���������";
        //    }
        //}
        //function ck2() {
        //    txtpwd.value = "�û�������";
        // }
        function isNumberOr_Letter(s) {//�ж��Ƿ������ֻ���ĸ 

            var regu = "^[0-9a-zA-Z\_]{5,15}$";
            var re = new RegExp(regu);
            if (re.test(s)) {
                return true;
            } else {
                return false;
            }
            
        }
        //function openform(theURL,winName,features) {
        //   // newwin = window.showModalDialog(theURL, winName, features);
        //    newwin = window.showModalDialog(theURL,winName,features);
        //}
        function tdisplay()
        {
            document.getElementById("Panel2").style.visibility = true;
        }
       
    </script>
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
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
    <center>
    <form id="Form1" method="post" runat="server" class="form-inline">
        <input type="hidden" value="0" name="ScrollPos" />
    <div class="body" runat="server">
        
        <div id="div_dynamic" runat="server">
        <style>
        tr{ line-height:30px;height:30px;}
        .td_c1{ width:20px;}
            .auto-style7 {
                height: 30px;
            }
            .auto-style9 {
                width: 293px;
                height: 30px;
                margin-left: 40px;
                text-align: left;
            }
            .auto-style11 {
                width: 293px;
                text-align: left;
            }
            .auto-style13 {
                height: 30px;
                width: 116px;
                text-align: right;
            }
            .auto-style14 {
                width: 116px;
                text-align: right;
            }
            .auto-style15 {
                width: 37px;
            }
        </style>
            <div>
                <h2>
                  <strong>��Ŀ����</strong>  
                </h2>
            </div>
            <table style="width: 800px" class="table" runat="server">
                <thead>
                    <tr>

                        <td></td>
                        <td>      
        <asp:Label ID="labError" runat="server" ForeColor="Red" align="center" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>

                        <td class="auto-style14">
                            ��ĿID��
                        </td>
                        <td class="auto-style11">

                            <asp:Label ID="LbproID" runat="server" Text=""></asp:Label>

                            <asp:Button runat="server" ID="btnGetId" Text="��ȡ��ĿID" OnClick="btnGetId_Click"  CssClass=" btn btn-danger" Width="100px" Height="34px" />

                        </td>
                        
                    </tr>
                </thead>
                <tr>
                    <td class="auto-style14">
                        ��Ŀ���ͣ�</td>
                    <td class="auto-style9">           
                        <asp:DropDownList ID="ddlType" runat="server" class="btn btn-default dropdown-toggle" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" >
                                <asp:ListItem>�ʽ�</asp:ListItem>
                                <asp:ListItem>��Ʒ</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        ���������</td>
                    <td class="auto-style9">           
                        <asp:DropDownList ID="recipientsType" runat="server" class="btn btn-default dropdown-toggle" Width="150px">
                                <asp:ListItem>��ѡ��</asp:ListItem>
                                <asp:ListItem>��ѧ</asp:ListItem>
                                <asp:ListItem>��ҽ</asp:ListItem>
                                <asp:ListItem>����</asp:ListItem>
                                <asp:ListItem>����</asp:ListItem>
                                <asp:ListItem>����</asp:ListItem>
                                <asp:ListItem>˫ӵ</asp:ListItem>
                                <asp:ListItem>���ش�����</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server">

                    <td class="auto-style14">
                        ��Ŀ���ƣ�</td>
                    <td class="auto-style9" runat="server">
                        <asp:TextBox runat="server" ID="projectID"  Width="250px" style="text-align: left" CssClass="form-control"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>

                    <td class="auto-style14">
                        ��Ŀ������
                    </td>
                    <td class="auto-style11">
                        <asp:TextBox ID="projectDir" runat="server" Height="98px" TextMode="MultiLine" Width="400px" CssClass="form-control"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>

                    <td class="auto-style13">
                        ʹ���ƿ��</td>
                    <td class="auto-style9">
                        <asp:TextBox MaxLength="20" runat="server" ID="txtPLAN"  Width="220px" CssClass="form-control"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>

                    <td class="auto-style14">
                        �����������
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox runat="server" ID="txtDIR" MaxLength="20"   Width="400px" Height="90px" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </td>
                    
                </tr>                
                <tr>

                    <td class="auto-style14">
                        ��ϵ�ˣ�</td>
                    <td class="auto-style11">

                        <div class="form-group">

                        <asp:Label ID="Lbtel" runat="server" Text="����:"></asp:Label>
                        <asp:TextBox ID="txttel" runat="server" CssClass="form-control" ></asp:TextBox>
                        <br />
                        <asp:Label ID="Lbteladd" runat="server" Text="�绰:"></asp:Label>
                        <asp:TextBox ID="txtteladd" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        </td>
                </tr>

                <tfoot>
                    <tr>

                        <td class="auto-style14">��Ŀʵʩ��λ�� </td>
                        <td class="auto-style9">
                            <asp:Label ID="lblBranch" runat="server"></asp:Label>
                        </td> 
                                               
                        </tr>
                    <tr>

                       <td class="auto-style13"> 
                        </td>
                        <td class="auto-style9">
                            <asp:Button ID="btntijiao" runat="server" OnClick="btntijiao_Click" Text="�ύ����" Visible="False"  CssClass=" btn btn-danger" Width="80px" Height="34px"/>
                        </td>                                         
                    </tr>                   
                                      
                </tfoot>
                
            </table>

            <table style="width: 800px" id="table1" Visible="False" class="table" >
                <tr>
                    <td></td>
                    <td>
                        <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="����:"></asp:Label>
                                <asp:TextBox ID="tbName" runat="server" Width="75px" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" Text="����:"></asp:Label>
                                <asp:TextBox ID="tbAge" runat="server" Width="38px" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Text="���֤��:"></asp:Label>
                                <asp:TextBox ID="Tbselect" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Button ID="Btselect0" runat="server" OnClick="Btselect_Click" Text="����" CssClass=" btn btn-danger" Height="34px" Width="85px" />
                                &nbsp;<asp:Button ID="btnBatch" runat="server" OnClick="btnBatch_Click" Text="����ѡ��������" CssClass=" btn btn-danger" Height="34px" Width="128px" Visible="False" />  
                        </div>
                    </td>                   
                </tr>
                <tr>
                    <td style="auto-style7" class="auto-style15"></td>
                    <td>
                        <br />

    <asp:DataGrid ID="dgData" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="644px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" >
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <ItemStyle CssClass="dg_item" BackColor="White" ForeColor="#330099"></ItemStyle>
            <EditItemStyle CssClass="dg_item" />
            <Columns>
                <asp:TemplateColumn HeaderText="����">
                    <ItemStyle CssClass="option"></ItemStyle>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit" runat="server" ToolTip="�༭" CommandName="Edit" ImageUrl="../CommUI/Images/icon-pencil.gif">
                        </asp:ImageButton>
                        <asp:ImageButton ID="btnDelete" Visible="false" runat="server" ImageUrl="../CommUI/Images/icon-delete.gif"
                            CommandName="Delete"></asp:ImageButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <font face="����">
                            <asp:ImageButton ID="btnUpdate" runat="server" ToolTip="�����޸�" CommandName="Update"
                                ImageUrl="../CommUI/Images/icon-floppy.gif"></asp:ImageButton>
                            <asp:ImageButton ID="btnCancel" runat="server" ToolTip="�����޸�" CommandName="Cancel"
                                ImageUrl="../CommUI/Images/icon-pencil-x.gif"></asp:ImageButton></font>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="����">
                    <ItemStyle CssClass="id"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsName") %>'>
                        </asp:Label>
                    </ItemTemplate>
<%--                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditID" runat="server" MaxLength="8" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsName") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>--%>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="������ID">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="����">
                    <%--<ItemStyle CssClass=""--%>
                    <ItemTemplate>
                        <asp:Label ID="labAge" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.newAge") %>'></asp:Label>
                    </ItemTemplate>
<%--                    <EditItemTemplate>
                        <asp:Label ID="txtEditAge" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.newAge") %>'></asp:Label>

                    </EditItemTemplate>--%>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="���֤��">
                    <ItemStyle CssClass="name"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labName" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsPIdcard") %>'>
                        </asp:Label>
                    </ItemTemplate>
<%--                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditName" runat="server" MaxLength="10" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsPIdcard") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>--%>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="��Դ">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labOrder" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
                        </asp:Label>
                    </ItemTemplate>
<%--                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditOrder" runat="server" MaxLength="6" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>--%>
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
<%--                <asp:TemplateColumn Visible="true" HeaderText="��ĿID">
                    <ItemTemplate>
                        <asp:Label ID="labproid" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtproid" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>
<%--                <asp:TemplateColumn Visible="False" HeaderText="ά��ʱ��">
                    <ItemTemplate>
                        <asp:Label ID="labMaintainDate" runat="server" CssClass="txtbox" Text=''>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditMaintainDate" runat="server" CssClass="txtbox" Text=''
                            Enabled="False">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>
<%--                <asp:TemplateColumn HeaderText="��ע˵��" HeaderStyle-Font-Names="true">

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
                </asp:TemplateColumn>--%>
            </Columns>
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:DataGrid></td>
                </tr>
            </table>
            
    </div>
        </div>
    </form>
    </center>
</body>
</html>
