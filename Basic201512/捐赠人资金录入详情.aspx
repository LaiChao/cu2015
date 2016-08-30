<%@ Page Language="C#" AutoEventWireup="true" CodeFile="捐赠人资金录入详情.aspx.cs" Inherits="Basic201512_捐赠人资金录入详情" %>

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

    <title>捐赠人资金录入详情</title>

    <!-- Bootstrap core CSS -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
   <%-- <link href="../../dist/css/bootstrap-theme.min.css" rel="stylesheet">--%>
     <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="theme.css" rel="stylesheet">

    <style>
        #GridView1 th {
        text-align:center;
        }
    </style>
</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline">
    <div>
            <h2>
               <strong>捐赠人资金录入详情</strong> 

            </h2>
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="1013px">
            <Columns>
                <asp:BoundField DataField="branchName" HeaderText="捐赠人所属机构" />
                <asp:BoundField DataField="detailID" HeaderText="捐赠人ID" />
                <asp:BoundField DataField="benefactorName" HeaderText="捐赠人名称" />
                <asp:BoundField DataField="operator" HeaderText="操作人" />
                <asp:BoundField DataField="opBranchName" HeaderText="操作人所在机构" />
                <asp:BoundField DataField="opType" HeaderText="操作类型" />
                <asp:BoundField DataField="income" HeaderText="操作金额" />
                <asp:BoundField DataField="opTime" HeaderText="操作时间" />
                <asp:BoundField DataField="remain" HeaderText="原有金额" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="gridhead" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>
    </form>
    </center>
</body>
</html>
