<%@ Page Language="C#" AutoEventWireup="true" CodeFile="捐赠人信息管理.aspx.cs" Inherits="Basic201512_捐赠人信息管理" EnableViewState="true" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>捐赠人信息管理</title>

    <!-- Bootstrap core CSS -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
   <%-- <link href="../../dist/css/bootstrap-theme.min.css" rel="stylesheet">--%>
     <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="theme.css" rel="stylesheet">
</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline">
    <div>
            <h2>
               <strong>捐赠人信息管理</strong> 

            </h2>
    </div>
    <div class="form-group">
        <p>
        <asp:Label ID="Label1" runat="server" Text="来源"></asp:Label>
        <asp:DropDownList ID="ddlBranchName" runat="server" CssClass="btn btn-default dropdown-toggle">
            <asp:ListItem>所有机构</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="类型"></asp:Label>
        <asp:DropDownList ID="ddlBenfactorType" runat="server" CssClass="btn btn-default dropdown-toggle">
            <asp:ListItem Value="0">未指定</asp:ListItem>
            
            <asp:ListItem Value="3">个人</asp:ListItem>
            <asp:ListItem Value="2">单位</asp:ListItem>
            <asp:ListItem Value="1">公益组织</asp:ListItem>
            <asp:ListItem Value="4">募捐箱</asp:ListItem>
            <asp:ListItem Value="5">冠名慈善捐助金</asp:ListItem>
        </asp:DropDownList>
            <asp:Label ID="Label4" runat="server" Text="捐助人ID"></asp:Label>
            <asp:TextBox ID="tbID" runat="server" Width="121px" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="名称"></asp:Label>
            <asp:TextBox ID="tbName" runat="server" Width="139px" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="手机号"></asp:Label>
            <asp:TextBox ID="tbTEL" runat="server" Width="118px" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="余额"></asp:Label>
            <asp:TextBox ID="tbRemain" runat="server" Width="39px" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" CssClass="btn btn-danger" Width="80px" Height="34px" />
        </p>
    </div>
    <div>

        <%--<asp:Button ID="btnReload" runat="server" OnClick="btnReload_Click" Text="刷新" CssClass="btn btn-danger" Width="80px" Height="34px" />--%>
&nbsp;<asp:Button ID="btnExp" runat="server" OnClick="btnExp_Click" Text="导出" CssClass="btn btn-danger" Width="80px" Height="34px" />

    </div>
    <div id="divOut" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowCreated="GridView1_RowCreated" OnPageIndexChanging="GridView1_PageIndexChanging" Width="900px">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFormatString="修改捐赠人信息.aspx?ID={0}" DataNavigateUrlFields="benfactorID"  Text="编辑" >
                    <%--<ControlStyle Font-Underline="True" />--%>
                </asp:HyperLinkField>
                <asp:CommandField ShowDeleteButton="True" />
<%--                <asp:CommandField ShowSelectButton="True" SelectText="查看" Visible="False"/>--%>
                <asp:BoundField DataField="benfactorID" HeaderText="捐赠人ID" Visible="False" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="benfactorName" HeaderText="名称" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="benfactorFrom" HeaderText="来源" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="donorType" HeaderText="类型" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="TEL" HeaderText="手机号" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="bftRange" HeaderText="使用范围" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="bftRemark" HeaderText="备注"  HeaderStyle-Height="30px" ItemStyle-Height="30px"/>
                <asp:BoundField DataField="Contacts" HeaderText="联系人" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="email" HeaderText="电子邮箱" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="sex" HeaderText="性别" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="moneyboxNo" HeaderText="募捐箱编号" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="namingAge" HeaderText="冠名年限" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="deadline" HeaderText="冠名到期日期" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="namingSelected" HeaderText="选择的冠名慈善捐助金" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="recipientsType" HeaderText="受助人类型" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="recipientsDescription" HeaderText="受助人描述"  HeaderStyle-Height="30px" ItemStyle-Height="30px"/>
                <asp:BoundField DataField="remain" HeaderText="余额" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>

    <%--<div>
            <asp:DetailsView ID="DetailsView1" runat="server" DataKeyNames="benfactorID" BackColor="White" BorderColor="#CC9966" BorderWidth="1px" CellPadding="4" Height="50px" Width="351px" AutoGenerateRows="False" BorderStyle="None" EmptyDataText="无该项数据" OnDataBound="DetailsView1_DataBound" >
            <EditRowStyle BackColor="#FFCC66" ForeColor="#663399" Font-Bold="True" />
            <Fields>
                <asp:BoundField DataField="benfactorID" HeaderText="捐赠人ID" ReadOnly="True" />
                <asp:BoundField DataField="benfactorName" HeaderText="名称" ReadOnly="True" />
                <asp:BoundField DataField="benfactorFrom" HeaderText="来源" ReadOnly="True" />
                <asp:BoundField DataField="benfactorType" HeaderText="类型" ReadOnly="True" />
                <asp:BoundField DataField="Contacts" HeaderText="联系人" ReadOnly="True" />
                <asp:BoundField DataField="TEL" HeaderText="手机号" ReadOnly="True" />
                <asp:BoundField DataField="email" HeaderText="电子邮箱" ReadOnly="True" />
                <asp:BoundField DataField="sex" HeaderText="性别" ReadOnly="True" />
                <asp:BoundField DataField="moneyboxNo" HeaderText="募捐箱编号" ReadOnly="True" />
                <asp:BoundField DataField="namingAge" HeaderText="冠名年限" ReadOnly="True" />
                <asp:BoundField DataField="deadline" HeaderText="到期时间" ReadOnly="True" />
                <asp:BoundField DataField="namingSelected" HeaderText="选择的冠名慈善捐助金名称" ReadOnly="True" />
                <asp:BoundField DataField="recipientsType" HeaderText="定向捐助类型" ReadOnly="True" />
            </Fields>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
        </asp:DetailsView>
    </div>--%>
    </form>
    </center>
</body>
</html>
