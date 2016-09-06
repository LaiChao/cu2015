<%@ Page Language="C#" AutoEventWireup="true" CodeFile="待办事项.aspx.cs" Inherits="Basic201512_待办事项" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Bootstrap core CSS -->
    <%--<script src="../Content/bootstrap.min.css"></script>--%>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
    <%-- <link href="../../dist/css/bootstrap-theme.min.css" rel="stylesheet">--%>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="theme.css" rel="stylesheet">
    <style type="text/css">
        a:link {
            text-decoration: none;
            font-size: 18px;
            font-weight: bold;
            font-family: 'Microsoft YaHei';
        }
        a:hover {
            color: #bd1c1c;
            transition: 0.3s;

        }
        .h2_font {
            text-align: center;
            font-family: inherit;
            font-size: 30px;
        }
        .label_style {
            font-family: Arial;
            font-size: 18px;
            font-weight: bold;
            color: #bd1c1c;
        }
    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
    <div>
        <h2 class="h2_font">
           <strong>待办事项</strong> 
        </h2>
    </div>
        <br />
    <div>

        <table runat="server">
            <tr id="tr1">
                <td>
                <p>
                <a href="信息接收.aspx" target="main" >查看未读信息</a>                                
                <asp:Label ID="Label1" runat="server" Text="（0）" CssClass="label_style"></asp:Label>
                </p></td>
            </tr>
            <tr id="tr2">
                <td>
                <p>
                <a href="用户权限.aspx" target="main" >给新用户分配权限</a>
                <asp:Label ID="Label2" runat="server" Text="（0）" CssClass="label_style"></asp:Label>
                </p></td>
            </tr>
            <tr id="tr3">
                <td>
                <p>
                <a href="项目审批.aspx" target="main" >审批项目</a>
                <asp:Label ID="Label3" runat="server" Text="（0）" CssClass="label_style"></asp:Label>
                </p></td>
            </tr>
            <tr id="tr4">
                <td>
                <p>
                <a href="资金录入.aspx" target="main" >确认捐赠金额</a>
                <asp:Label ID="Label4" runat="server" Text="（0）" CssClass="label_style"></asp:Label>
                </p></td>
            </tr>
            <tr id="tr5">
                <td>
                <p>
                <a href="捐赠人信息管理.aspx" target="main" >冠名慈善捐助金到期</a>
                <asp:Label ID="Label5" runat="server" Text="（0）" CssClass="label_style"></asp:Label>
                </p></td>
            </tr>
            <tr id="tr6">
                <td>
                    <p>
                        <a href="冠名分期.aspx" target="main">冠名慈善捐助金分期提醒</a>
                        <asp:Label ID="Label6" runat="server" Text="（0）" CssClass="label_style"></asp:Label>
                    </p>
                </td>
            </tr>
        </table>
    </div>
    </form>
    </center>
</body>
</html>
