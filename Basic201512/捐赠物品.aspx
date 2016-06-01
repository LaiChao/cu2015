<%@ Page Language="C#" AutoEventWireup="true" CodeFile="捐赠物品.aspx.cs" Inherits="Basic201512_捐赠物品" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
    <div>
        <h2><strong>捐赠物品</strong></h2>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="捐赠人名称："></asp:Label>
        <asp:Label ID="lblName" runat="server" Text="获取失败"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="物品："></asp:Label>
        <asp:TextBox ID="tbItem" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="公允值（元）："></asp:Label>
        <asp:TextBox ID="tbValue" runat="server"></asp:TextBox>
    </div>
    <div>

        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />

        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

    </div>
    </form>
    </center>
</body>
</html>
