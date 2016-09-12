<%@ Page Language="C#" AutoEventWireup="true" CodeFile="资金录入.aspx.cs" Inherits="Basic201512_受助人" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <!-- Bootstrap core CSS -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
    <%-- <link href="../../dist/css/bootstrap-theme.min.css" rel="stylesheet">--%>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="theme.css" rel="stylesheet">
    <title>资金录入</title>
    <style type="text/css">
        tr {
            line-height: 30px;
            height: 30px;
        }

        tr {
            padding: 0;
            margin: 0;
            border: 0;
        }

        .option {
            width: 50px;
        }

        .option {
            height: 24px;
            font-size: small;
            text-align: center;
            line-height: 24px;
            border: #cc9966 1px solid;
        }

        td {
            text-align: center;
        }

        .id {
            height: 24px;
            font-size: small;
            text-align: center;
            line-height: 24px;
            border: #cc9966 1px solid;
        }

        .txtbox {
            width: 100%;
            padding: 0;
            margin: 0;
        }

        .name {
            width: 170px;
        }

        .name {
            height: 24px;
            font-size: small;
            text-align: center;
            line-height: 24px;
            border: #cc9966 1px solid;
        }

        .label_style {
            font-size: 15px;
            text-align: right;
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
            border: #cc9966 1px solid;
            white-space: nowrap;
        }

        th {
            padding: 0px 10px 0px 10px;
            text-align: center;
            white-space: nowrap;
        }

        .page_style {
            color: #bd1c1c;
            font-size: 16px;
        }

        .checkBox_style {
            font-family: 'Microsoft YaHei';
        }

        .gridView_style {
            font-family: 'Microsoft YaHei';
            font-size: 14px;
        }

        .font_style:hover {
            color: #0a1e58 !important;
            transition: 0.2s;
        }

        .font_style1:hover {
            color: #721313 !important;
            transition: 0.2s;
        }

        .div_style {
            width: 800px;
            border-width: 1px;
            border-style: dashed;
        }

        a {
            text-decoration: none !important;
        }
        a:hover {
            color: #0a1e58;
            transition: 0.2s;
        }
        .link_style {
            font-family: 'Microsoft YaHei';  
            font-size: 15px;         
        }
        .link_style:link {
            text-decoration: none;
        }
        .link_style:hover {
            color: #d60808;
            transition: 0.2s;
        }
    </style>
</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline">
        <div>
            <h2>
               <strong>捐赠金额录入与确认</strong> 
            </h2>
        </div>
        <div class="form-group">
            <p style="text-align: center;margin:0 auto">
                <asp:Label ID="Label3" runat="server" Text="捐赠人类型:" CssClass="label_style"></asp:Label>
                <asp:DropDownList ID="benfactorType" runat="server" class="btn btn-default dropdown-toggle">
                <asp:ListItem Value="0">所有类型</asp:ListItem>
                <asp:ListItem Value="3">个人</asp:ListItem>
                <asp:ListItem Value="2">单位</asp:ListItem>
                <asp:ListItem Value="1">公益组织</asp:ListItem>
                <asp:ListItem Value="4">募捐箱</asp:ListItem>
                <asp:ListItem Value="5">冠名慈善捐助金</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="名称:" CssClass="label_style"></asp:Label>
                <asp:TextBox ID="TbselectName" runat="server" Width="116px" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="手机号:" CssClass="label_style"></asp:Label> 
                <asp:TextBox ID="TbselectID" runat="server" CssClass="form-control" Width="116px"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="Btselect" runat="server" OnClick="Btselect_Click" Text="搜索" CssClass=" btn btn-danger" Width="80px" Height="34px"/>&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="显示全部待确认金额" CssClass=" btn btn-danger" />
            </p>
            <p style="text-align: center;margin:0 auto">
                <asp:Label ID="Label4" runat="server" Text="搜索不到捐赠人？前往:" CssClass="label_style"></asp:Label>
                <a href="捐赠人添加.aspx" target="main" class="link_style">添加捐赠人</a>
            </p>
            <br />      
        </div>
        
            <asp:DataGrid ID="dgData" runat="server" CssClass="gridView_style" AutoGenerateColumns="False" CellPadding="4" Width="900px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" AllowPaging="True" OnPageIndexChanged="dgData_PageIndexChanged">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <ItemStyle CssClass="dg_item" BackColor="White" ForeColor="#330099"></ItemStyle>
            <EditItemStyle CssClass="dg_item" />
            <Columns>
                <asp:HyperLinkColumn DataTextField="benfactorID" DataNavigateUrlField="benfactorID"  HeaderText="捐赠人ID"    DataNavigateUrlFormatString="资金录入副本.aspx?benfactorID={0}" ></asp:HyperLinkColumn>
                <asp:TemplateColumn HeaderText="名称">
                    <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditID" runat="server" CssClass="txtbox" MaxLength="8" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="labID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'></asp:Label>
                    </ItemTemplate>
                    <%--<ItemStyle CssClass="id"></ItemStyle>--%>
                </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="捐赠人类型">
                                <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.sbenfactorType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="手机号">
                            <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtteladd" runat="server" CssClass="txtbox" MaxLength="6" Text='<%# DataBinder.Eval(Container, "DataItem.TEL") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="labteladd" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.TEL") %>'></asp:Label>
                            </ItemTemplate>
<%--                                <ItemStyle CssClass="index"></ItemStyle>--%>
                        </asp:TemplateColumn>                   
                            <asp:TemplateColumn HeaderText="是否冠名">
                                <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblNaming" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.snaming") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="是否定向">
                                <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblDirect" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.sdirection") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="定向受助人类型">
                                <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblRType" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                        </Columns>
                        <PagerStyle BackColor="#FFFFCC" CssClass="page_style" HorizontalAlign="Center" Mode="NumericPages"/>
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:DataGrid>
        <br />
        <asp:DataGrid ID="dgData1" runat="server" CssClass="gridView_style" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" >
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <ItemStyle CssClass="dg_item" BackColor="White" ForeColor="#330099"></ItemStyle>
            <EditItemStyle CssClass="dg_item" />
            <Columns>
                        <asp:HyperLinkColumn DataTextField="benfactorID" DataNavigateUrlField="benfactorID"  HeaderText="捐赠人ID"    DataNavigateUrlFormatString="资金录入副本.aspx?benfactorID={0}" ></asp:HyperLinkColumn>
                <asp:TemplateColumn HeaderText="名称">
                    <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditID" runat="server" CssClass="txtbox" MaxLength="8" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="labID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'></asp:Label>
                    </ItemTemplate>
                    <%--<ItemStyle CssClass="id"></ItemStyle>--%>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="资金ID">
                    <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="capitalID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalID") %>' MaxLength="40"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="手机号">
                    <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtteladd" runat="server" CssClass="txtbox" MaxLength="6" Text='<%# DataBinder.Eval(Container, "DataItem.TEL") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="labteladd" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.TEL") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn> 
                <asp:TemplateColumn HeaderText="已有资金">
                    <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="capitalEarn" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalEarn") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="添加资金">
                    <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="capitalIn" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalIn") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <%--<asp:ButtonColumn CommandName="confirm" HeaderText="操作" Text="确认"></asp:ButtonColumn>--%>
            </Columns>
            <PagerStyle BackColor="#FFFFCC" CssClass="page_style" HorizontalAlign="Center" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:DataGrid>
    </form>
    </center>
</body>
</html>
