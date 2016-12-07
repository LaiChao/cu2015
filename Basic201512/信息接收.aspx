<%@ Page Language="C#" AutoEventWireup="true" CodeFile="信息接收.aspx.cs" Inherits="Basic201512_信息接收" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link rel="icon" href="../../favicon.ico"/>

    <title>信息接收</title>

    <!-- Bootstrap core CSS -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
   <%-- <link href="../../dist/css/bootstrap-theme.min.css" rel="stylesheet">--%>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="theme.css" rel="stylesheet"/>

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="../../assets/js/ie-emulation-modes-warning.js"></script>
    <script type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
  
    <style type="text/css">       
        #GridView1 th{
            text-align:center
        }
        .label_style {
            font-size: 15px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        }
        .listItem_style {
            font-size: 16px;
            font-family: 'Microsoft YaHei';
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
            font-size: 14px;           
        }
        .gridView_style {
            font-family: 'Microsoft YaHei';
            font-size: 14px;
        }
        .font_style:hover {
            color: #0a1e58;
            transition: 0.2s;
        }
        .font_style1:hover {
            color: #721313 !important;
            transition: 0.2s;
        }
    </style>
</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline" role="form">
    <div>    
        <h2>
           <strong>重要信息查询</strong> 

        </h2>
    </div>
    <div class="form-group">
        <p>
            <asp:Label ID="Label3" runat="server" Text="查看：" CssClass="label_style" Width="72px"></asp:Label>
            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" class="btn btn-default dropdown-toggle listItem_style">
                <asp:ListItem>未读信息</asp:ListItem>
                <asp:ListItem>收件箱</asp:ListItem>
                <asp:ListItem>发件箱</asp:ListItem>
                <asp:ListItem>群发信息</asp:ListItem>
                <asp:ListItem>全部信息</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>

            <asp:Label ID="Label4" runat="server" Text="标题：" CssClass="label_style" Width="72px"></asp:Label>
            <asp:TextBox ID="tbTitle" runat="server"  Width="140px" CssClass="form-control"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label5" runat="server" Text="时间：" CssClass="label_style" Width="72px"></asp:Label>
            <asp:TextBox ID="tbFrom" runat="server"  Width="140px"  onClick="WdatePicker()" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="至" CssClass="label_style" Width="72px"></asp:Label>
            <asp:TextBox ID="tbTo" runat="server"  Width="140px"  onClick="WdatePicker()" CssClass="form-control"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="发件人：" CssClass="label_style" Width="72px"></asp:Label>
            <asp:DropDownList ID="ddlBranchFrom" runat="server" CssClass="btn btn-default dropdown-toggle">
                <asp:ListItem>请选择</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:Label ID="Label6" runat="server" Text="收件人：" CssClass="label_style" Width="72px"></asp:Label>
            <asp:DropDownList ID="ddlBranchTo" runat="server" CssClass="btn btn-default dropdown-toggle">
                <asp:ListItem>请选择</asp:ListItem>
                <asp:ListItem>所有机构</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-danger" Width="80px" Height="34px" OnClick="btnSearch_Click" />&nbsp;&nbsp;

        </p>            
    </div>
        <br />
    <div class="form-group" style="padding-right:38px">
        <asp:GridView ID="GridView1" runat="server" Width="900px" CssClass="gridView_style" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCreated="GridView1_RowCreated" >
            <Columns>
                <asp:HyperLinkField DataTextField="infoTitle" HeaderText="标题" DataNavigateUrlFormatString="信息查看.aspx?ID={0}" DataNavigateUrlFields="infoID" >            
                    <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC"/>
                    <ControlStyle Font-Underline="false" CssClass="font_style"/>  
                    <ItemStyle HorizontalAlign="Center"/>                       
                </asp:HyperLinkField>
                <asp:BoundField DataField="infoDATE" HeaderText="时间" >
                   <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="mycenter"/>
                   <ItemStyle Height="30px" CssClass="mycenter" Wrap="false"/>             
                </asp:BoundField>
                <asp:BoundField DataField="infoFrom" HeaderText="发件人"  >
                 <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="mycenter"/>
                 <ItemStyle Height="30px" CssClass="mycenter" Wrap="false"/>
                </asp:BoundField>
                <asp:BoundField DataField="infoTo" HeaderText="收件人"  >
                 <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="mycenter"/>
                   <ItemStyle Height="30px" CssClass="mycenter" Wrap="false"/>
                </asp:BoundField>
                <asp:CommandField HeaderText="删除" DeleteText="删除" ShowDeleteButton="True"  >
                    <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="mycenter"/>
                    <ControlStyle Font-Underline="false" CssClass="font_style1" ForeColor="#d60808"/>
                    <ItemStyle HorizontalAlign="Center" Wrap="false"/> 
                </asp:CommandField>
                <asp:HyperLinkField HeaderText="编辑" Text="编辑" DataNavigateUrlFormatString="信息修改.aspx?ID={0}" DataNavigateUrlFields="infoID" HeaderStyle-Height="30px" ItemStyle-Height="30px">       
                      <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="mycenter"/>
					  <ControlStyle Font-Underline="false" CssClass="font_style"/>
                      <ItemStyle HorizontalAlign="Center" Wrap="false"/> 					  
                </asp:HyperLinkField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="gridhead"/>
            <PagerTemplate>
                <asp:Label ID="lblPage" runat="server" Text='<%# "第"+(((GridView)Container.NamingContainer).PageIndex+1)+"页/共"+(((GridView)Container.NamingContainer).PageCount)+"页" %> '></asp:Label>&nbsp;&nbsp;
                <asp:LinkButton ID="lblFirst" runat="Server" Font-Underline="false" Text="首页"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lblPrev" runat="server" Font-Underline="false" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lblNext" runat="Server" Font-Underline="false" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lblLast" runat="Server" Font-Underline="false" Text="尾页"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton>&nbsp;
            </PagerTemplate>
            <PagerStyle BackColor="#FFFFCC" HorizontalAlign="Center" CssClass="page_style"/>
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
