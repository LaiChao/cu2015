<%@ Page Language="c#" Inherits="CL.Utility.Web.BasicData.Register" CodeFile="项目审批副本.aspx.cs" %>
<%-- EnableEventValidation="false" --%>
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
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>项目审批</title>

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
                lblerr.innerText = "用户名正常";
                //txtpwd.value = "用户名正常";
                document.getElementById("Form1").submit();
                alert(11);
            }
            else {
                lblerr.innerText = "用户名不正常";
                //txtpwd.value = "用户名不正常";
            }
        }
        function ck2() {
            txtpwd.value = "用户名正常";
         }
        function isNumberOr_Letter(s) {//判断是否是数字或字母 

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

        .auto-style8 {
            width: 160px;
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
            font-family: 'Microsoft YaHei';
        }
        .btn-right{
            text-align:right;
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
        #dgData1 a, #dgData a, #dgData0 a {
            text-decoration: none !important;
        }
        #dgData1 a:hover, #dgData a:hover, #dgData0 a:hover {
            color: #0a1e58 !important;
            transition: 0.2s;
        }
        .labError_style {
            text-align: left;
            font-family: 'Microsoft YaHei';
            font-size: 15px;
            color: #e8a1eb;
            height: 50px;
        }
        #dgData1 td, #dgData td, #dgData0 td {
            height: 35px;
            vertical-align: middle;
            padding: 0px 10px 0px 10px;
            white-space: nowrap;
            border: #cc9966 1px solid;
        }
        #dgData1 th, #dgData td, #dgData0 td {
            padding: 0px 10px 0px 10px;
            text-align:center;
            white-space: nowrap;
        }
        .gridView_style {
            font-family: 'Microsoft YaHei';
            font-size: 14px;
        }
        .label_style {
            font-size: 15px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        } 
        .link_style {
            font-family: 'Microsoft YaHei'; 
            font-size: 15px;          
        }
        .link_style:link {
            text-decoration: none;
        }
        .link_style:hover {
            color: #d60808;
            transition: 0.2s;
        }
    </style>
</head>
    
<body id="thebody">
     <div id="divPrint" runat="server">
         <center>
    <form id="Form1" method="post" runat="server" onsubmit="ck2()">
        <div>
            <div>
                <h2>
                    <strong>项目审批</strong>  
                </h2>
            </div>
            <table width="580px" runat="server">
                <tr>
                    <td class="auto-style8">
                        <asp:Button ID="familylist" style=" border:0px none" runat="server" Height="30px" OnClick="familylist_Click" Text="-" Width="30px" BackColor="#c2c2c2" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="auto-style9 btn-right">
                        <asp:Label ID="labError" runat="server" align="center" ForeColor="Red" Text=""></asp:Label>                    
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                    
                        <asp:Button ID="btnReturn" runat="server" Text="返回项目审批页面" CssClass=" btn btn-danger" OnClick="btnReturn_Click" Width="159px" />
                    </td>
                </tr>
            </table>        
            <table style="width: 580px" align="center" id="applyTable" runat="server" class="table">
                <thead>                  
                    <tr>
                        <td class="auto-style8">项 目 ID：</td>
                        <td class="auto-style9">
                            <asp:Label ID="LbproID" runat="server" Text=""></asp:Label>
                        </td>                     
                    </tr>
                </thead>
                <tr>
                    <td class="auto-style8">项 目 类 别： </td>
                    <td class="auto-style9">
                        <asp:Label ID="lblLeibie" runat="server"></asp:Label>
                    &nbsp;&nbsp;<asp:Label ID="lblNaming" runat="server"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:Label ID="lblDirect" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">项 目 名 称： </td>
                    <td class="auto-style9">
                        <asp:Label ID="Lbproname" runat="server"></asp:Label>
                    </td>            
                </tr>
                <tr>
                    <td class="auto-style8">项 目 状 态： </td>
                    <td class="auto-style9">
                        <asp:Label ID="lblState" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">项 目 方 案： </td>
                    <td class="auto-style9">
                        <asp:Label ID="projectDir" runat="server"></asp:Label>
                    </td>                    
                </tr>
                <tr>
                    <td class="auto-style8">计划使用善款(元)： </td>
                    <td class="auto-style9">
                        <asp:Label ID="Lbplan" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                <tr id="trNaming" runat="server">
                    <td class="auto-style8">受助人情况： </td>
                    <td class="auto-style9">
                        <asp:Label ID="Lbrestnow" runat="server"></asp:Label>
                    </td>                    
                </tr>                          
                <tr>
                    <td class="auto-style8">联系人姓名： </td>
                    <td class="auto-style9">
                        <asp:Label ID="Lbtelname" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">联系人电话： </td>
                    <td class="auto-style9">
                        <asp:Label ID="Lbtelladd" runat="server"></asp:Label>
                    </td>
                </tr>
                <tfoot>
                    <tr>
                        <td class="auto-style8">项目实施单位： </td>
                        <td class="auto-style9">
                            <asp:Label ID="Lbbenfrom" runat="server"></asp:Label>
                        </td>                        
                    </tr>
                    <tr>
                        <td class="auto-style8">选择模板：</td>
                        <td class="auto-style9">
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>附1北京市朝阳区慈善协会救助项目申请表</asp:ListItem>
                            <asp:ListItem>附2冠名慈善捐助金使用项目书</asp:ListItem>
                            <asp:ListItem>附3北京市朝阳区慈善协会救助项目书</asp:ListItem>
                            </asp:DropDownList>&nbsp;
                            <asp:Button ID="btout" runat="server" OnClick="btout_Click" Text="导出" CssClass=" btn btn-danger" />
                        </td>
                    </tr>               
                </tfoot>              
            </table>
            <div>
                <p>
                    <asp:Button ID="btchecky1" runat="server" Text="会长审批通过" OnClick="btchecky1_Click" CssClass=" btn btn-danger" />
                            <asp:Button ID="btchecky2" runat="server" Text="科室审批通过" OnClick="btchecky2_Click" CssClass=" btn btn-danger " />
                            <asp:Button ID="btcheckn" runat="server" Text="审批未通过" Width="116px"  CssClass=" btn btn-danger" OnClick="btcheckn_Click" />
                            <asp:Button ID="btnReapply" runat="server" Text="重新申请" CssClass=" btn btn-danger " OnClick="btnReapply_Click" />
                </p>
            </div>
            <div class="table">
                <asp:DataGrid ID="dgData0" runat="server" CssClass="gridView_style" AutoGenerateColumns="False" CellPadding="4" Width="700px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" OnItemCommand="dgData0_ItemCommand" OnItemDataBound="dgData0_ItemDataBound">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <EditItemStyle CssClass="dg_item" />
            <Columns>
                
<%--                <asp:ButtonColumn CommandName="CancelMoney" Text="撤回"  HeaderText="撤回资金"></asp:ButtonColumn>
                <asp:ButtonColumn CommandName="rollbackMoney" Text="撤回"  HeaderText="撤回资金"></asp:ButtonColumn>--%>
                <asp:TemplateColumn HeaderText="撤回资金">
                    <ItemStyle CssClass="id" />
                    <ItemTemplate>
                        <asp:Button ID="btnRollback" runat="server" CssClass="txtbox" Text="撤回" CommandName="rollbackMoney" />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="捐赠人ID">
                    <ItemStyle></ItemStyle>
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
                <asp:TemplateColumn HeaderText="捐助人姓名">
                    <ItemStyle ></ItemStyle>
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
                
                <asp:TemplateColumn HeaderText="联系方式">
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
                <%--<asp:TemplateColumn HeaderText="启用">
                    <ItemStyle CssClass="idt"></ItemStyle>
                    <ItemTemplate>
                        <asp:CheckBox ID="ckState" runat="server" ToolTip="启用标示，点中为启用" CssClass="txtbox"
                            Checked=''
                            Enabled="False"></asp:CheckBox>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <font face="宋体">
                            <asp:CheckBox ID="ckEditState" runat="server" CssClass="txtbox" Checked=''
                                oolTip="启用标示，点中为启用"></asp:CheckBox></font>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>                         
                <asp:TemplateColumn HeaderText="已用资金(元)" HeaderStyle-Font-Names="true">

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
                <asp:TemplateColumn HeaderText="出账时间" HeaderStyle-Font-Names="true">

                   <HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle ></ItemStyle>
                    
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
                <br />
                <asp:DataGrid ID="dgData" runat="server" CssClass="gridView_style" AutoGenerateColumns="False" CellPadding="4" Width="700px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" DataKeyField="recipientsID" OnItemCommand="dgData_ItemCommand" OnItemDataBound="dgData_ItemDataBound" >
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <EditItemStyle CssClass="dg_item" />
            <Columns>
                <asp:TemplateColumn HeaderText="删除">
                    <ItemStyle ></ItemStyle>
                    <ItemTemplate>
<%--                        <asp:ImageButton ID="btnEdit1" runat="server" ToolTip="结项" CommandName="Edit1" ImageUrl="../CommUI/Images/icon-pencil.gif">
                        </asp:ImageButton>--%>
                        <asp:ImageButton ID="btnDelete1" runat="server" ToolTip="删除受助人" ImageUrl="../CommUI/Images/icon-delete.gif"
                            CommandName="Delete1"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateColumn>
            
                <asp:TemplateColumn HeaderText="受助人姓名">
                    <ItemStyle ></ItemStyle>
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
                <asp:TemplateColumn HeaderText="身份证号">
                    <ItemStyle ></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labName" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsPIdcard") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditName" runat="server" MaxLength="10" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsPIdcard") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="来源">
                    <ItemStyle ></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labOrder" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditOrder" runat="server" MaxLength="6" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <%--<asp:TemplateColumn HeaderText="启用">
                    <ItemStyle CssClass="idt"></ItemStyle>
                    <ItemTemplate>
                        <asp:CheckBox ID="ckState" runat="server" ToolTip="启用标示，点中为启用" CssClass="txtbox"
                            Checked=''
                            Enabled="False"></asp:CheckBox>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <font face="宋体">
                            <asp:CheckBox ID="ckEditState" runat="server" CssClass="txtbox" Checked=''
                                oolTip="启用标示，点中为启用"></asp:CheckBox></font>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>              
                <asp:TemplateColumn Visible="False" HeaderText="维护时间">
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
<%--                <asp:TemplateColumn HeaderText="备注说明" HeaderStyle-Font-Names="true">

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
        </asp:DataGrid>
                <br />
                <asp:DataGrid ID="dgData1" runat="server" CssClass="gridView_style" AutoGenerateColumns="False" CellPadding="4" Width="700px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <EditItemStyle CssClass="dg_item" />
            <Columns>
                
                <asp:TemplateColumn HeaderText="捐助人ID">
                    <ItemStyle ></ItemStyle>
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
                <asp:TemplateColumn HeaderText="捐助人名称">
                    <ItemStyle ></ItemStyle>
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
                
<%--                <asp:TemplateColumn HeaderText="联系方式">
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
                <%--<asp:TemplateColumn HeaderText="启用">
                    <ItemStyle CssClass="idt"></ItemStyle>
                    <ItemTemplate>
                        <asp:CheckBox ID="ckState" runat="server" ToolTip="启用标示，点中为启用" CssClass="txtbox"
                            Checked=''
                            Enabled="False"></asp:CheckBox>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <font face="宋体">
                            <asp:CheckBox ID="ckEditState" runat="server" CssClass="txtbox" Checked=''
                                oolTip="启用标示，点中为启用"></asp:CheckBox></font>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>                         
                <asp:TemplateColumn HeaderText="已用物品" HeaderStyle-Font-Names="true">

                   <HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle ></ItemStyle>
                    
                    <ItemTemplate>
                        <asp:Label ID="lblItem" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.item") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbItem" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.item") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="使用时间" HeaderStyle-Font-Names="true">

                   <HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle ></ItemStyle>
                    
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
            </div>
        </div>
    </form>
         </center>
         </div>
</body>
</html>
