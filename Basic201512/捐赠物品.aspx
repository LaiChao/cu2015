<%@ Page Language="C#" AutoEventWireup="true" CodeFile="捐赠物品.aspx.cs" Inherits="Basic201512_捐赠物品" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

    <title>捐赠物品</title>

    <!-- Bootstrap core CSS -->
   <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
    <%-- <link href="../../dist/css/bootstrap-theme.min.css" rel="stylesheet">--%>
   <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="theme.css" rel="stylesheet">
     <style type="text/css">
         #div_dynamic { width: 500px; margin:0 auto; }
         .class1 {
         text-align:right;
         width:200px;
         }
         .class2 {
         text-align:center;
         width:300px;
         }
         </style>
</head>
<body>
    <center>
    <form id="form1" runat="server">
    <div>
        <h2><strong>捐赠物品</strong></h2>
    </div>
        <div id="div_dynamic">
        <table class="table">
            <tr>
                <td class="class1">    
        <asp:Label ID="Label3" runat="server" Text="捐赠人名称："></asp:Label>
                    </td>
                <td class="class2">
        <asp:Label ID="lblName" runat="server" Text="获取失败"></asp:Label>    
                </td>
                </tr>
            <tr>
                <td class="class1">

                    <asp:Label ID="Label4" runat="server" Text="所属机构："></asp:Label>

                </td>
                <td class="class2">

                    <asp:Label ID="lblBranch" runat="server"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="class1">   
        <asp:Label ID="Label1" runat="server" Text="物品："></asp:Label>
                    </td>
                <td class="class2">
        <asp:TextBox ID="tbItem" runat="server" CssClass="form-control"></asp:TextBox>    
                </td>
                </tr>
            <tr>
                <td class="class1">   
        <asp:Label ID="Label2" runat="server" Text="公允值（元）："></asp:Label>
                    </td>
                <td class="class2">
        <asp:TextBox ID="tbValue" runat="server" CssClass="form-control"></asp:TextBox>  
                </td>
                </tr>
            <tr>
                <td class="class1">  
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                <td class="class2">
        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" CssClass=" btn btn-danger" Width="80px" Height="34px" />
                </td>
            </tr>
            </table>
        </div>
    </form>
    </center>
</body>
</html>
