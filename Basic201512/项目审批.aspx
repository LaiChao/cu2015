<%@ Page Language="C#" AutoEventWireup="true" CodeFile="项目审批.aspx.cs" Inherits="Basic201512_受助人" %>

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

    <title>项目审批</title>

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
        .name2{ width: 200px; }
        .name { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
        .gv_td
        {
            width:100px;
            /*word-break:keep-all;*/
            overflow: hidden; 
            /*white-space: nowrap;*/
            -o-text-overflow: ellipsis;
            text-overflow: ellipsis;
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
            white-space: nowrap;
            border: #cc9966 1px solid;
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
            color: #0a1e58 !important;
            transition: 0.2s;
        }
    </style>
</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline" role="form">
        
    <div>
        <h2>
          <strong>项目审批</strong>  
        </h2>
    </div>
        <div>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="项目ID:" CssClass="label_style"></asp:Label>
                <asp:TextBox ID="TbselectID" runat="server" CssClass="form-control"  Width="200px"></asp:TextBox>&nbsp;
                <asp:Label ID="Label2" runat="server" Text="项目名称:" CssClass="label_style"></asp:Label>
                <asp:TextBox ID="TbselectName" runat="server" CssClass="form-control"  Width="300px"></asp:TextBox>&nbsp;
                <asp:Button ID="Btselect" runat="server" OnClick="Btselect_Click" Text="搜索" CssClass=" btn btn-danger" Width="80px" Height="34px" />
            </div>
         <br />
            <br />
    <asp:DataGrid ID="dgData" runat="server" Width="1000px" CssClass="gridView_style" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" AllowPaging="True" OnPageIndexChanged="dgData_PageIndexChanged" >
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
                <Columns>
                    <asp:HyperLinkColumn DataTextField="projectID" DataNavigateUrlField="projectID"  HeaderText="项目ID"    DataNavigateUrlFormatString="项目审批副本.aspx?projectID={0}" >
                    </asp:HyperLinkColumn>
                    <asp:TemplateColumn HeaderText="项目名称">
                        <ItemTemplate>
                        <asp:Label ID="labName" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditName" runat="server" MaxLength="10" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectName") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="状态">
                    <ItemTemplate>
                        <asp:Label ID="labState" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.proschedule") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditState" runat="server" MaxLength="10" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.proschedule") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="执行单位">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labOrder" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditOrder" runat="server" MaxLength="6" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
                        </asp:TextBox>
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
                <asp:TemplateColumn Visible="true" HeaderText="联系人">
                    <ItemTemplate>
                        <asp:Label ID="labCreateDate" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.telphoneName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditCreateDate" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.telphoneName") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn Visible="False" HeaderText="联系电话">
                    <ItemTemplate>
                        <asp:Label ID="labMaintainDate" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.telphoneADD") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditMaintainDate" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.telphoneADD") %>'
                            Enabled="False">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="项目描述" HeaderStyle-Font-Names="true">
                    <ItemStyle CssClass="gv_td"></ItemStyle>  
                    <ItemTemplate>                  
                        <asp:Label ID="labBtw" runat="server" CssClass="gv_td"  Text='<%# DataBinder.Eval(Container.DataItem,"projectDir").ToString().Length>15?DataBinder.Eval(Container.DataItem,"projectDir").ToString().Substring(0,15) + "...":DataBinder.Eval(Container.DataItem,"projectDir").ToString()%>' ToolTip='<%# DataBinder.Eval(Container, "DataItem.projectDir") %>'  >
                        </asp:Label>                        
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditBtw" runat="server" MaxLength="40" CssClass="gv_td"   Text='<%# DataBinder.Eval(Container.DataItem,"projectDir").ToString().Length>15?DataBinder.Eval(Container.DataItem,"projectDir").ToString().Substring(0,15) + "...":DataBinder.Eval(Container.DataItem,"projectDir").ToString()%>' ToolTip='<%# DataBinder.Eval(Container, "DataItem.projectDir") %>' >
                        </asp:TextBox>
                    </EditItemTemplate>                   
                </asp:TemplateColumn>
            </Columns>
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" Mode="NumericPages"/>
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:DataGrid>
 
    </div>
    </form>
    </center>
</body>
</html>
