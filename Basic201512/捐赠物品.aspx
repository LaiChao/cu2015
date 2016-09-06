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
        .auto-style2 {
            width: 130px;
            font-size: 16px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        }
        .auto-style9 {        
            height: 50px;
            margin-left: 40px;
            vertical-align: middle;
            text-align: left;
        }
         .auto-style10 {
             width: 130px;
             font-size: 16px;
             text-align: right;
             font-family: 'Microsoft YaHei';
             height: 51px;
         }
         .auto-style11 {
             height: 51px;
             margin-left: 40px;
             vertical-align: middle;
             text-align: left;
         }
         .labError_style {
            text-align: left;
            font-family: 'Microsoft YaHei';
            font-size: 15px;
            color: #e8a1eb
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
            <div class="form-group">
                <table runat="server" width="550px">
                <tr>
                    <td class="auto-style10">捐赠人名称：&nbsp;</td>
                    <td class="auto-style11">
                        <asp:TextBox runat="server" ID="lblName" class="form-control" ReadOnly="true" Height="31px" Width="300px"></asp:TextBox>   
                    </td>
                </tr>
                <tr>               
                    <td class="auto-style2">所属机构：&nbsp;</td>
                    <td class="auto-style9">
                        <asp:TextBox runat="server" ID="lblBranch" class="form-control" Height="31px" ReadOnly="true" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">物&nbsp;&nbsp;品：&nbsp;</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="tbItem" runat="server" CssClass="form-control" Height="31px" Width="300px"></asp:TextBox>    
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">公允值（元）：&nbsp;</td>               
                    <td class="auto-style9">
                        <asp:TextBox ID="tbValue" runat="server" CssClass="form-control" Height="31px" Width="300px"></asp:TextBox>  
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style9">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="labError_style"></asp:Label>                   
                    </td>
                </tr>
            </table>
                <div>
                    <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" CssClass=" btn btn-danger" Width="80px" Height="34px" />
                </div>
            </div>           
        </div>
    </form>
    </center>
</body>
</html>
