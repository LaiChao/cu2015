<%@ Page Language="C#" Inherits="Basic201512_���������" CodeFile="���������.aspx.cs"  AutoEventWireup="true"%>

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

    <title>���������</title>

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
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        tr { padding: 0; margin: 0; border: 0; }
        /*td { text-align: center; }*/
        td { text-align: left }
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

        tr{ line-height:30px;height:30px;}
        .td_c1{ width:20px;}
        .auto-style8 {
            width: 170px;
            font-size: 16px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        }
        .lb11_style {
            text-align: right;
            font-family: 'Microsoft YaHei';
        }
        .auto-style9 {          
            height: 50px;
            margin-left: 40px;
            vertical-align: middle;
            text-align: left;
        }
        .dropDownList_style {
            width: 340px !important;
        }
        .yahei_style {
            font-family: 'Microsoft YaHei';
        }
        .link_style {
            font-family: 'Microsoft YaHei';           
        }
        .link_style:link {
            text-decoration: none;
        }
        .link_style:hover {
            color: #d60808;
            transition: 0.2s;
        }
        .labError_style {
            text-align: left;
            font-family: 'Microsoft YaHei';
            font-size: 15px;
            color: #e8a1eb;
            height: 50px;
        }
    </style>
</head>
    
<body id="thebody">
    <center>
    <form id="Form1" runat="server" class="form-inline">
    <div style="height: 41px">
        <h2>
           <strong>��Ӿ�����</strong> 
        </h2>
    </div>
    <div class="body">
        
        <div id="div_dynamic" >                                                              
             <div class="form-group">
            <table width="550px" runat="server">
                <tr>                  
                        <td class="auto-style8">��&nbsp;��&nbsp;��&nbsp;λ��&nbsp;</td>
                        <td class="auto-style9">
                            <asp:DropDownList ID="ddlBranch" runat="server" class="btn btn-default dropdown-toggle dropDownList_style">
                            </asp:DropDownList>
                        </td>                                          
                </tr>             
                <tr>
                        <td class="auto-style8">���������ͣ�&nbsp;</td>
                        <td class="auto-style9">

<%--                            <asp:CheckBox ID="Chboxgongyi" runat="server" AutoPostBack="true" OnCheckedChanged="Chboxgongyi_CheckedChanged" Text="������֯" />
                            <asp:CheckBox ID="Chboxfaren" runat="server" AutoPostBack="True" OnCheckedChanged="Chboxfaren_CheckedChanged" Text="����" />
                            <asp:CheckBox ID="Chboxziran" runat="server" AutoPostBack="True" OnCheckedChanged="Chboxziran_CheckedChanged" Text="��Ȼ��" />
                            <asp:CheckBox ID="Chboxmojuan" runat="server" AutoPostBack="True" OnCheckedChanged="Chboxmojuan_CheckedChanged" Text="ļ����" />
                            <asp:CheckBox ID="Chboxguanming" runat="server" AutoPostBack="True" OnCheckedChanged="Chboxguanming_CheckedChanged" Text="����������" />--%>
                            <asp:DropDownList ID="benfactorType" runat="server" OnSelectedIndexChanged="benfactorType_SelectedIndexChanged" AutoPostBack="True" class="btn btn-default dropdown-toggle dropDownList_style">                                
                                <asp:ListItem Value="1">������֯</asp:ListItem>
                                <asp:ListItem Value="3">����</asp:ListItem>
                                 <asp:ListItem Value="2">��λ</asp:ListItem>
                                <asp:ListItem Value="4">ļ����</asp:ListItem>
                                <asp:ListItem Value="5">�������ƾ�����</asp:ListItem>
                            </asp:DropDownList>
                        </td>                        
                    </tr>          
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="Lb11" runat="server" Text="������֯���ƣ�"></asp:Label>
                        <asp:Label ID="Label1" runat="server">&nbsp;</asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox runat="server" ID="benfactorName" CssClass="form-control dropDownList_style"></asp:TextBox>                       
                    </td>
                </tr>
                <tr id="trSex" runat="server">
                        <td class="auto-style8">��&nbsp;&nbsp;��&nbsp;</td>
                        <td class="auto-style9">
                            <asp:DropDownList ID="ddlSex" runat="server" class="btn btn-default dropdown-toggle dropDownList_style" >
                            <asp:ListItem>��</asp:ListItem>
                            <asp:ListItem>Ů</asp:ListItem>
                        </asp:DropDownList>

                        </td>                   
                </tr>
                <tr id="trMoneyboxNo" runat="server">
                        <td class="auto-style8">ļ�����ţ�&nbsp;</td>
                        <td class="auto-style9">                            
                            <asp:TextBox ID="moneyboxNo" runat="server" CssClass="form-control dropDownList_style"></asp:TextBox>
                        </td>
                </tr>
                <tr id="trStartDate" runat="server">
                    <td class="auto-style8">��&nbsp;ʼ&nbsp;��&nbsp;�ڣ�&nbsp;</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="tbStartDate" runat="server" onClick="WdatePicker()" CssClass="form-control dropDownList_style" AutoPostBack="True" OnTextChanged="tbStartDate_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr id="trAge" runat="server">
                        <td class="auto-style8">��&nbsp;&nbsp;�ޣ�&nbsp;</td>
                        <td class="auto-style9">
                            
                        <asp:DropDownList ID="ddlAge" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAge_SelectedIndexChanged" class="btn btn-default dropdown-toggle" Width="70px">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                        
                            <asp:Label ID="Label5" runat="server" Text="��"></asp:Label>
                        
                        </td>                
                </tr>
                <tr id="trDeadline" runat="server">
                        <td class="auto-style8">��&nbsp;��&nbsp;��&nbsp;�ڣ�&nbsp;</td>
                        <td class="auto-style9">
                        <asp:Label ID="deadline" runat="server" Text="����"></asp:Label>
                            &nbsp;&nbsp; </td>
                </tr>
                <tr id="trContact" runat="server">
                    <td class="auto-style8">��ϵ��������&nbsp;</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="Contacts" runat="server" CssClass="form-control dropDownList_style"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                        <td class="auto-style8">��&nbsp;��&nbsp;�ţ�&nbsp;</td>
                        <td class="auto-style9">
                            
                            <asp:TextBox ID="TEL" runat="server" MaxLength="11" CssClass="form-control dropDownList_style"></asp:TextBox>
                            
                        </td>                   
                </tr>

                <tr>
                    <td class="auto-style8">��&nbsp;��&nbsp;��&nbsp;�䣺&nbsp;</td>
                    <td class="auto-style9">
                        <asp:TextBox MaxLength="20" runat="server" ID="email" CssClass="form-control" Width="340px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="trRange" runat="server">
                        <td class="auto-style8">ʹ&nbsp;��&nbsp;��&nbsp;Χ��&nbsp;</td>
                        <td class="auto-style9">
                            <asp:TextBox ID="txtRange" runat="server" TextMode="MultiLine" Height="80px" CssClass="form-control dropDownList_style" Width="340px"></asp:TextBox>
                        </td>
                </tr> 

                <tr id="trRemark" runat="server">
                        <td class="auto-style8">��&nbsp;&nbsp;ע��&nbsp;</td>
                        <td class="auto-style9">
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control dropDownList_style" ></asp:TextBox>
                            </td>
                </tr> 
                <tr id="trRemind" runat="server">
                    <td class="auto-style8">��&nbsp;��&nbsp;��&nbsp;�ڣ�&nbsp;</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddlCycle" runat="server" class="btn btn-default dropdown-toggle dropDownList_style">
                            <asp:ListItem Value="0">������</asp:ListItem>
                            <asp:ListItem Value="12">һ��</asp:ListItem>
                        </asp:DropDownList>
                        <%--<br />--%>
                        </td>
                </tr> 
            
            </table>
            <table id="tbDirect"  style="width: 556px" runat="server" >
                <tr>
                    <td class="auto-style8">�Ƿ��������&nbsp;</td>
                    <td class="auto-style9 yahei_style">                        
                          <asp:RadioButton ID="rdbDirect" runat="server" AutoPostBack="True" GroupName="rdoDirect" OnCheckedChanged="rdoDirect_CheckedChanged" Text="&nbsp;��" CssClass="checkbox" Width="60px" Height="30px"/>
                          <asp:RadioButton ID="rdbUndirect" runat="server" AutoPostBack="True" GroupName="rdoDirect" Text="&nbsp;��" OnCheckedChanged="rdoDirect_CheckedChanged" CssClass="checkbox" Width="60px" Height="30px"/>                       
                   </td>
               </tr>
                <tr id="trRcpType" runat="server">
                    <td class="auto-style8">���������ͣ�&nbsp;</td>
                    <td class="auto-style9">
                            <asp:DropDownList ID="recipientsType" runat="server" class="btn btn-default dropdown-toggle dropDownList_style">
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
                <tr id="trDesc" runat="server">
                    <td class="auto-style8">������������&nbsp;</td>
                    <td class="auto-style9">
                        <asp:TextBox runat="server" ID="description" Height="80px" TextMode="MultiLine" CssClass="form-control dropDownList_style"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table id="tbNaming"  style="width: 556px" runat="server" >


                <tr>
                    <td class="auto-style8">�Ƿ����������&nbsp;</td>
                    <td class="auto-style9 yahei_style">
                            <asp:RadioButton ID="rdbNaming" runat="server" Text="&nbsp;��" AutoPostBack="True" GroupName="rdoNaming" OnCheckedChanged="rdoNaming_CheckedChanged" CssClass="checkbox" Width="60px" Height="30px"/>
                            <asp:RadioButton ID="rdbUnNaming" runat="server" Text="&nbsp;��" AutoPostBack="True" GroupName="rdoNaming" OnCheckedChanged="rdoNaming_CheckedChanged" CssClass="checkbox" Width="60px" Height="30px"/>
                    </td>                  
                    </tr>
                <tr id="trFundName" runat="server">
                    <td class="auto-style8">�������ƾ��������ƣ�&nbsp;</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddlNaming" runat="server" class="btn btn-default dropdown-toggle dropDownList_style">
                        </asp:DropDownList>
                        <br />
                        </td>
                </tr>
            </table>
            <table  style="width: 556px" runat="server">
                    <tr>
                       <td class="auto-style8"></td>
                        <td class="labError_style">
                            <asp:Label ID="labError" runat="server" ForeColor="Red" Text=""></asp:Label>                        
                        </td>                                       
                    </tr>
                <tr>
                    <td>

                    </td>
                    <td>
                        <asp:Button ID="Btinput" runat="server" OnClick="Btinput_Click" Text="��&nbsp;��" CssClass=" btn btn-danger" Width="80px" Height="34px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="ǰ����" CssClass="yahei_style"></asp:Label>
                        <a href="�ʽ�¼��.aspx" class="link_style">�������¼��</a>
                    </td>
                </tr>
                
            </table>
             </div> 
                         
        </div>      
    </div>
    </form>
    </center>
</body>
</html>
