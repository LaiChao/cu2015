<%@ Page Language="C#" AutoEventWireup="true" CodeFile="信息接收.aspx.cs" Inherits="Basic201512_信息接收" %>

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

    <title>信息接收</title>

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

        tr{ line-height:30px;height:30px;}
        tr { padding: 0; margin: 0; border: 0; }
        .option { width: 50px; }
        .option { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
        td { text-align: center; }
        .id { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
        .txtbox { width: 95%; padding: 0; margin: 0; }
        .name { width: 170px; }
        .name { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
        </style>
</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline">
    <div>    
        <h2>
           <strong>重要信息查询</strong> 

        </h2>
&nbsp;</div>
    <div class="form-group">

        查看:<asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" class="btn btn-default dropdown-toggle">
            <asp:ListItem>未读信息</asp:ListItem>
            <asp:ListItem>收件箱</asp:ListItem>
            <asp:ListItem>发件箱</asp:ListItem>
            <asp:ListItem>群发信息</asp:ListItem>
            <asp:ListItem>全部信息</asp:ListItem>
        </asp:DropDownList>
    </div>
                <td>
        <asp:GridView ID="GridView1" HeaderStyle-CssClass="text-center" align="center" runat="server" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCreated="GridView1_RowCreated" Width="600px" >
            <Columns>
                <asp:HyperLinkField DataTextField="infoTitle" HeaderText="标题" DataNavigateUrlFormatString="信息查看.aspx?ID={0}" DataNavigateUrlFields="infoID" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
                <ControlStyle Font-Overline="False" Font-Underline="True" />
<HeaderStyle Height="30px"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:HyperLinkField>
                <asp:BoundField DataField="infoDATE" HeaderText="时间" HeaderStyle-Height="30px" ItemStyle-Height="30px">
<HeaderStyle Height="30px"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="infoFrom" HeaderText="发件人" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="infoTo" HeaderText="收件人"  HeaderStyle-Height="30px" ItemStyle-Height="30px">
<HeaderStyle Height="30px"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:CommandField>
                <asp:HyperLinkField HeaderText="编辑" Text="编辑" HeaderStyle-Height="30px" ItemStyle-Height="30px">
                <ControlStyle Font-Underline="True" />
                <FooterStyle Font-Underline="False" />
<HeaderStyle Height="30px"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:HyperLinkField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" HorizontalAlign="Center"/>
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
        </table>
        </div>


    </form>
    </center>
</body>
</html>
