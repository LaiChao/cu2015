<%@ Page Language="C#" AutoEventWireup="true" CodeFile="资金追踪.aspx.cs" Inherits="Basic201512_受助人" %>

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

    <title>资金追踪</title>

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
        td { text-align: center; border: #cc9966 1px solid;}
        .id { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
        .txtbox { width: 95%; padding: 0; margin: 0; }
        .name { width: 170px; }
        .name { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
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
            font-size: 16px;            
        }
        .gridView_style {
            font-family: 'Microsoft YaHei';
            font-size: 14px;
        }
        a {
            text-decoration: none !important;
        }
        a:hover {
            color: #0a1e58;
            transition: 0.2s;
        }
        .label_style {
            font-size: 15px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        } 
    </style>
</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline" role="form">
    <div>
        <div>
            <h2>
                <strong>善款追踪</strong> 
            </h2>
        </div>
        <div class="form-group">
            <p>
                <asp:Label ID="Label1" runat="server" Text="捐赠人ID:" CssClass="label_style"></asp:Label>
                <asp:TextBox ID="TbselectName" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="捐赠人名称:" CssClass="label_style"></asp:Label>
                <asp:TextBox ID="txtselectName" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="项目ID:" CssClass="label_style"></asp:Label>
                <asp:TextBox ID="TbselectID" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="项目名称:" CssClass="label_style"></asp:Label>
                <asp:TextBox ID="txtselectproname" runat="server" CssClass="form-control"></asp:TextBox>
            </p> 
            <p>
                <asp:Button ID="Btselect" runat="server" OnClick="Btselect_Click" Text="搜索"  CssClass="btn btn-danger" Height="35px" Width="70px"/>
                <asp:Button ID="btout" runat="server" OnClick="btout_Click" Text="导出" CssClass=" btn btn-danger" Height="35px" Width="70px" />
            </p>           
        </div> 

        <div id="divPrint" runat="server">
            <asp:DataGrid ID="dgData" runat="server" CssClass="gridView_style" AutoGenerateColumns="False" Width="800px" OnItemDataBound="dgData_ItemDataBound1" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"  AllowPaging="True" OnPageIndexChanged="dgData_PageIndexChanged">               
                <Columns>
                    <asp:TemplateColumn HeaderText="捐赠人ID">
                        <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="labID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benefactorID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditID" runat="server" MaxLength="8" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benefactorID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="捐赠人名称">
                        <ItemStyle CssClass="index"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="labteladd" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtteladd" runat="server" MaxLength="6" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                <%--<asp:TemplateColumn HeaderText="启用">
                    <ItemStyle CssClass="idt"></ItemStyle>
                    <ItemTemplate>
                        <asp:CheckBox ID="ckState" runat="server" ToolTip="启用标示，点中为启用" CssClass="txtbox"
                            Checked=''
                            Enabled="False"></asp:CheckBox>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <font face="宋体">
                            <asp:CheckBox ID="ckEditState" runat="server" CssClass="txtbox" Checked=''
                                oolTip="启用标示，点中为启用"></asp:CheckBox></font>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>
                    <asp:HyperLinkColumn DataTextField="projectID" DataNavigateUrlField="projectID"  HeaderText="项目ID" DataNavigateUrlFormatString="项目审批副本.aspx?projectID={0}">
                        <HeaderStyle Height="30px" HorizontalAlign="Center"/>
                        <ItemStyle Height="30px"/>                         
                    </asp:HyperLinkColumn>       
                    <asp:TemplateColumn Visible="true" HeaderText="项目名称">
                        <ItemTemplate>
                            <asp:Label ID="labproname" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtproname" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="已用资金" HeaderStyle-Font-Names="true">
                        <HeaderStyle Font-Names="true"></HeaderStyle>
                        <ItemStyle CssClass="des"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="labguanming" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.useMoney") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditguanming" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.useMoney") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="出账时间" HeaderStyle-Font-Names="true">
                        <HeaderStyle Font-Names="true"></HeaderStyle>
                        <ItemStyle CssClass="des"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="labwuzhu" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.prouseoutTime") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditwuzhu" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.prouseoutTime") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099"  />
                <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" CssClass="text-center" Height="30px" />
                <PagerStyle BackColor="#FFFFCC" HorizontalAlign="Center" CssClass="page_style"  Mode="NumericPages"/>
        </asp:DataGrid>
                        </div>    
    </div>
    </form>
    </center>
</body>
</html>
