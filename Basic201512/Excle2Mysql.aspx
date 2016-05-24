<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Excle2Mysql.aspx.cs" Inherits="Basic201512_Excle2Mysql" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="btnImport" runat="server" OnClick="btnImport_Click" Text="提交" />
    
    </div>
    </form>
</body>
</html>
