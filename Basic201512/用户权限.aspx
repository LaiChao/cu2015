﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="用户权限.aspx.cs" Inherits="Permission_用户权限" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>用户权限</title>

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
        #div_dynamic { height: 450px; border:#e8a1eb 0px solid; text-align:center;  }
        #divTitle, #div_dynamic { width: 650px; margin:0 auto;text-align:center; }
        #GridView1 th {
            text-align:center;
        }
        .label_style {
            font-size: 15px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        }
        .font_style:hover {
            color: #0a1e58 !important;
            transition: 0.2s;
        }
        .font_style1:hover {
            color: #721313 !important;
            transition: 0.2s;
        }
        .mycenter {
            text-align: center;
            color: black;           
        }
        td {
            height: 35px;
            vertical-align: middle;
            padding: 0px 10px 0px 10px;
            white-space: nowrap;
        }
        th {
            padding: 0px 10px 0px 10px;
            text-align:center;
            white-space: nowrap;
        }
        .page_style {
            color: #bd1c1c;
            font-size: 16px;            
        }
        .checkBox_style {
            font-family: 'Microsoft YaHei';           
        }
        .gridView_style {
            font-family: 'Microsoft YaHei';
            font-size: 14px;
        }
    </style>
</head>
<body>
    <center>
    <div style="height: 41px">
    
        <h2>
           <strong>用户权限管理</strong> 

        </h2>
        </div>
        <form id="form1" runat="server">
            <div style="height: 47px">
    
        <asp:Label ID="Label1" runat="server" Text="所属机构：" CssClass="label_style"></asp:Label>
        <asp:DropDownList ID="branchName" runat="server" class="btn btn-default dropdown-toggle">
              <asp:ListItem>所有机构</asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" CssClass=" btn btn-danger" Width="80px" Height="34px"/>
    
    </div>
     <asp:Label ID="Lbtitle" runat="server" Text="1：分会；&nbsp;&nbsp;2：科室；&nbsp;&nbsp;3：会长；&nbsp;&nbsp;4：管理员" CssClass="label_style" Font-Bold="true"></asp:Label>
     <br /><br />
<%--        <asp:GridView ID="GridView1" align="center" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">--%> 
        <asp:GridView ID="GridView1" CssClass="gridView_style"  HorizontalAlign="Center" Align="Center" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" >
            <Columns >
                <asp:BoundField DataField="user" HeaderText="用户名" ReadOnly="true"  >
                <HeaderStyle Height="30px" HorizontalAlign="Center"/>
                <ControlStyle Height="30px"  />
                <ItemStyle Height="30px" CssClass="mycenter"/>  
                </asp:BoundField>
                <asp:BoundField DataField="userRole" HeaderText="权限">
                <HeaderStyle Height="30px"  />
                <ControlStyle Height="30px" Width="100%" />
                <ItemStyle Height="30px" CssClass="mycenter"/>  
                </asp:BoundField>
                <asp:BoundField DataField="benfactorFrom" HeaderText="所属机构" ReadOnly="true" >
                <HeaderStyle Height="30px"  />
                <ControlStyle Height="30px"  />
                <ItemStyle Height="30px" CssClass="mycenter"/>
                </asp:BoundField>
<%--                <asp:CommandField HeaderText="选择" ShowSelectButton="True" />--%>
<%--                <asp:TemplateField HeaderText="所属分会">
                    <ItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSource='<%# ddlBind() %>'
                                DataValueField="benfactorFrom" DataTextField="benfactorFrom">
                            </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True"  >
                    <HeaderStyle Height="30px"  />
                    <ControlStyle ForeColor="#337ab7" CssClass="font_style" Font-Underline="false" />
                    <ItemStyle Height="30px"/>
                </asp:CommandField >
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
                    <HeaderStyle Height="30px" />
                    <ControlStyle ForeColor="#d60808" Font-Underline="false" CssClass="font_style1"/>
                    <ItemStyle Height="30px" />
                </asp:CommandField >
                <asp:ButtonField CommandName="resetPWD" HeaderText="重置密码" Text="重置密码" >
                    <HeaderStyle Height="30px" />
                    <ControlStyle ForeColor="#337ab7" CssClass="font_style" Font-Underline="false" />
                    <ItemStyle Height="30px" />
                </asp:ButtonField>

            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px"/>
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
   
      
    </form>
    </center>
</body>

</html>
