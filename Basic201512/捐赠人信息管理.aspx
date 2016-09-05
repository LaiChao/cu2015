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
    <style>
         .mycenter{
        text-align:center;    
        }
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
            <asp:Label ID="Label7" runat="server" Text="是否定向"></asp:Label>
            <asp:DropDownList ID="ddlDirect" runat="server"  CssClass="btn btn-default dropdown-toggle">
                <asp:ListItem>未指定</asp:ListItem>
                <asp:ListItem>非定向</asp:ListItem>
                <asp:ListItem>助学</asp:ListItem>
                <asp:ListItem>助医</asp:ListItem>
                <asp:ListItem>助残</asp:ListItem>
                <asp:ListItem>助老</asp:ListItem>
                <asp:ListItem>助困</asp:ListItem>
                <asp:ListItem>双拥</asp:ListItem>

                <asp:ListItem>重特大灾难</asp:ListItem>

            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" CssClass="btn btn-danger" Width="80px" Height="34px" />
            <asp:Button ID="btputout" runat="server" Text="筛选导出"  CssClass="btn btn-danger" Width="80px" Height="34px" OnClick="btputout_Click" />
        </p>
    </div>
    <div id="putout" runat="server">

        <%--<asp:Button ID="btnReload" runat="server" OnClick="btnReload_Click" Text="刷新" CssClass="btn btn-danger" Width="80px" Height="34px" />--%>
        请选择需要导出的列：<asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox1_CheckedChanged" Text="名称" />
&nbsp;<asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox2_CheckedChanged" Text="来源" />
&nbsp;<asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox3_CheckedChanged" Text="类型" />
&nbsp;<asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox4_CheckedChanged" Text="手机号" />
&nbsp;<asp:CheckBox ID="CheckBox5" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox5_CheckedChanged" Text="使用范围" />
&nbsp;<asp:CheckBox ID="CheckBox6" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox6_CheckedChanged" Text="备注" />
&nbsp;<asp:CheckBox ID="CheckBox7" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox7_CheckedChanged" Text="联系人" />
&nbsp;<asp:CheckBox ID="CheckBox8" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox8_CheckedChanged" Text="电子邮箱" />     
&nbsp;<asp:CheckBox ID="CheckBox9" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox9_CheckedChanged" Text="性别" />
        <br />
&nbsp;<asp:CheckBox ID="CheckBox10" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox10_CheckedChanged" Text="募捐箱编号" />
&nbsp;<asp:CheckBox ID="CheckBox11" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox11_CheckedChanged" Text="冠名年限" />
&nbsp;<asp:CheckBox ID="CheckBox12" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox12_CheckedChanged" Text="冠名到期日期" />
&nbsp;<asp:CheckBox ID="CheckBox13" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox13_CheckedChanged" Text="冠名捐助金" />
&nbsp;<asp:CheckBox ID="CheckBox14" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox14_CheckedChanged" Text="受助人类型" />
&nbsp;<asp:CheckBox ID="CheckBox15" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox15_CheckedChanged" Text="受助人描述" />
&nbsp;<asp:CheckBox ID="CheckBox16" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox16_CheckedChanged" Text="余额" />
        <br />
&nbsp;<asp:Button ID="btnExp" runat="server" OnClick="btnExp_Click" Text="导出" CssClass="btn btn-danger" Width="80px" Height="34px" />

    </div>
    <div id="divOut" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowCreated="GridView1_RowCreated" OnPageIndexChanging="GridView1_PageIndexChanging" >
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFormatString="修改捐赠人信息.aspx?ID={0}" DataNavigateUrlFields="benfactorID"  Text="编辑" >
                    <%--<ControlStyle Font-Underline="True" />--%>
                </asp:HyperLinkField>
                <asp:CommandField ShowDeleteButton="True" DeleteText="删除" />
<%--                <asp:CommandField ShowSelectButton="True" SelectText="查看" Visible="False"/>--%>
                <asp:BoundField DataField="benfactorID" HeaderText="捐赠人ID" Visible="False" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>
<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
              <asp:HyperLinkField DataNavigateUrlFormatString="资金追踪.aspx?ID={0}" DataNavigateUrlFields="benfactorID" HeaderText="名称" DataTextField="benfactorName" DataTextFormatString="{0}" Text="banfactorName">
                    <%--<ControlStyle Font-Underline="True" />--%>
                </asp:HyperLinkField>
                <asp:BoundField DataField="benfactorFrom" HeaderText="来源" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="donorType" HeaderText="类型" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="TEL" HeaderText="手机号" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="bftRange" HeaderText="使用范围" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="bftRemark" HeaderText="备注"  HeaderStyle-Height="30px" ItemStyle-Height="30px">
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Contacts" HeaderText="联系人" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="email" HeaderText="电子邮箱" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="sex" HeaderText="性别" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="moneyboxNo" HeaderText="募捐箱编号" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="namingAge" HeaderText="冠名年限" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="deadline" HeaderText="冠名到期日期" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="namingSelected" HeaderText="冠名慈善捐助金" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="recipientsType" HeaderText="受助人类型" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>
                        
<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="recipientsDescription" HeaderText="受助人描述"  HeaderStyle-Height="30px" ItemStyle-Height="30px">
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="remain" HeaderText="余额" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
<HeaderStyle Height="30px" CssClass="mycenter"></HeaderStyle>

<ItemStyle Height="30px"></ItemStyle>
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="benfactorID" DataNavigateUrlFormatString="捐赠物品.aspx?ID={0}" HeaderText="捐物" Text="捐赠" />
                <asp:HyperLinkField DataNavigateUrlFields="benfactorID" DataNavigateUrlFormatString="捐赠人资金录入详情.aspx?ID={0}" HeaderText="资金录入详情" Text="资金录入详情" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="gridhead" />
            <PagerTemplate>
                <asp:Label ID="lblPage" runat="server" Text='<%# "第"+(((GridView)Container.NamingContainer).PageIndex+1)+"页/共"+(((GridView)Container.NamingContainer).PageCount)+"页" %> '></asp:Label>
                <asp:LinkButton ID="lblFirst" runat="Server" Text="首页"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton>
                <asp:LinkButton ID="lblPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton>
                <asp:LinkButton ID="lblNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
                <asp:LinkButton ID="lblLast" runat="Server" Text="尾页"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton>
            </PagerTemplate>                        
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
