<%@ Page Language="C#" AutoEventWireup="true" CodeFile="业务流转日志.aspx.cs" Inherits="Basic201512_实体信息日志" %>

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

    <title>业务流转日志</title>

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

</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline" role="form">
    <div>
        <h2>
           <strong>业务流转日志</strong> 

        </h2>
    </div>
    <div style="height: 34px">
        <asp:Label ID="Label2" runat="server" Text="起："></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" onClick="WdatePicker()" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="止："></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" onClick="WdatePicker()" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="用户："></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="103px" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" CssClass=" btn btn-danger" Width="80px" Height="34px" />
         </div>
        <br />

    <div> 
        <asp:GridView ID="GridView1" align="center" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" Width="500px">
            <Columns>
                <asp:BoundField DataField="CreateDate" HeaderText="时间" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="user" HeaderText="用户" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
                <asp:BoundField DataField="Message" HeaderText="操作" HeaderStyle-Height="30px" ItemStyle-Height="30px" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" HorizontalAlign="Center" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Center" />
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
