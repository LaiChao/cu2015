<%@ Page Language="C#" AutoEventWireup="true" CodeFile="项目查询.aspx.cs" Inherits="Basic201512_受助人" EnableEventValidation="false" %>

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

    <title>Theme Template for Bootstrap</title>

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
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline" role="form">
    <div>
        <div>
            <h2>
              <strong>项目信息管理</strong>  
            </h2>
        </div>
        <div class="form-group">
        <p>
            <asp:Label ID="Label6" runat="server" Text="执行单位:" CssClass="label_style"></asp:Label>
            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="btn btn-default dropdown-toggle"> 
                <asp:ListItem>全部</asp:ListItem>
            </asp:DropDownList>&nbsp;
            <asp:Label ID="Label5" runat="server" Text="执行状态:" CssClass="label_style"></asp:Label>
            <asp:DropDownList ID="ddlState" runat="server" CssClass="btn btn-default dropdown-toggle">
                <asp:ListItem>全部</asp:ListItem>
                <asp:ListItem>申请中</asp:ListItem>
                <asp:ListItem>未通过</asp:ListItem>
                <asp:ListItem>科室审批通过</asp:ListItem>
                <asp:ListItem>会长审批通过</asp:ListItem>
                <asp:ListItem>结项</asp:ListItem>
                <asp:ListItem>归档</asp:ListItem>
            </asp:DropDownList>&nbsp;
            <asp:Label ID="Label7" runat="server" Text="项目类型:" CssClass="label_style"></asp:Label>
            <asp:DropDownList ID="ddlType" runat="server"  CssClass="btn btn-default dropdown-toggle">
                <asp:ListItem>全部</asp:ListItem>
                <asp:ListItem>资金</asp:ListItem>
                <asp:ListItem>物品</asp:ListItem>
            </asp:DropDownList>&nbsp;
            <asp:Label ID="Label8" runat="server" Text="受助人类别:" CssClass="label_style"></asp:Label>
            <asp:DropDownList ID="recipientsType" runat="server"  CssClass="btn btn-default dropdown-toggle">
                <asp:ListItem>全部</asp:ListItem>
                <asp:ListItem>助学</asp:ListItem>
                <asp:ListItem>助医</asp:ListItem>
                <asp:ListItem>助残</asp:ListItem>
                <asp:ListItem>助老</asp:ListItem>
                <asp:ListItem>助困</asp:ListItem>
                <asp:ListItem>双拥</asp:ListItem>
                <asp:ListItem>重特大灾难</asp:ListItem>
            </asp:DropDownList>&nbsp;
            <asp:Button ID="Btselect2" runat="server" OnClick="Btselect2_Click" Text="搜索" CssClass=" btn btn-danger" Width="80px" Height="34px"/>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="项目ID:" CssClass="label_style"></asp:Label>
            <asp:TextBox ID="TbselectID" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>&nbsp;
            <asp:Label ID="Label2" runat="server" Text="项目名称:" CssClass="label_style"></asp:Label>
            <asp:TextBox ID="TbselectName" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>&nbsp;
            <asp:Button ID="Btselect" runat="server" OnClick="Btselect_Click" Text="搜索" CssClass=" btn btn-danger" Width="80px" Height="34px"/>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="时间（起）:" CssClass="label_style"></asp:Label>
            <asp:TextBox ID="illtimebe" runat="server" onClick="WdatePicker()" CssClass="form-control" Width="120px"></asp:TextBox>&nbsp;
            <asp:Label ID="Label4" runat="server" Text="时间（止）:" CssClass="label_style"></asp:Label>
            <asp:TextBox ID="illtimeend" runat="server" onClick="WdatePicker()" CssClass="form-control" Width="120px"></asp:TextBox>&nbsp;
            <asp:Button ID="Btselectout" runat="server"  Text="搜索" OnClick="Btselectout_Click" CssClass=" btn btn-danger" Width="80px" Height="34px" />&nbsp;
            <asp:Button ID="btputout" runat="server"  Text="筛选导出"  CssClass=" btn btn-danger" Width="80px" Height="34px" OnClick="btputout_Click" />
        </p>
       </div>
        <div id="putout" runat="server" class="div_style">
           <asp:Label ID="Label9" runat="server" Text="请选出需要导出的列：" CssClass="label_style"></asp:Label>
           <asp:CheckBox ID="CheckBox0" runat="server" CssClass="checkBox_style" AutoPostBack="True" OnCheckedChanged="CheckBox0_CheckedChanged" Text="项目ID" />
           &nbsp; <asp:CheckBox ID="CheckBox1" runat="server" CssClass="checkBox_style" Text="项目名称" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
           &nbsp;<asp:CheckBox ID="CheckBox2" runat="server" CssClass="checkBox_style" Text="执行单位" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" />
           &nbsp;<asp:CheckBox ID="CheckBox3" runat="server" CssClass="checkBox_style" Text="执行状态" AutoPostBack="True" OnCheckedChanged="CheckBox3_CheckedChanged" />
           &nbsp;<asp:CheckBox ID="CheckBox4" runat="server" CssClass="checkBox_style" Text="联系人" AutoPostBack="True" OnCheckedChanged="CheckBox4_CheckedChanged" />
           &nbsp;<asp:CheckBox ID="CheckBox5" runat="server" CssClass="checkBox_style" Text="联系电话" AutoPostBack="True" OnCheckedChanged="CheckBox5_CheckedChanged" />
           &nbsp;<asp:CheckBox ID="CheckBox6" runat="server" CssClass="checkBox_style" AutoPostBack="True" OnCheckedChanged="CheckBox6_CheckedChanged" Text="项目描述" />
           <p>
               <asp:Button ID="btout" runat="server" OnClick="btout_Click" Text="导出" CssClass=" btn btn-danger" Width="80px" Height="34px" />
           </p>
        </div>
        <br />
           <div id="divPrint" runat="server">
           <asp:DataGrid ID="dgData" runat="server" CssClass="gridView_style" AutoGenerateColumns="False" CellPadding="4" Width="1054px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" OnItemDataBound="dgData_ItemDataBound1" OnItemCommand="dgData_ItemCommand" OnDeleteCommand="dgData_DeleteCommand" AllowPaging="True" OnPageIndexChanged="dgData_PageIndexChanged">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <Columns>
                <asp:HyperLinkColumn DataTextField="projectID" DataNavigateUrlField="projectID"  HeaderText="项目ID"    DataNavigateUrlFormatString="项目审批副本.aspx?projectID={0}" >
                </asp:HyperLinkColumn>
<%--                <asp:TemplateColumn HeaderText="项目ID">
                    <ItemStyle CssClass="id"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditID" runat="server" MaxLength="8" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>
                <asp:TemplateColumn HeaderText="项目名称">
                    <ItemStyle CssClass="name"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labName" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditName" runat="server" MaxLength="10" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectName") %>'>
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
                <asp:TemplateColumn HeaderText="执行状态">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labtimer" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.proschedule") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txttimer" runat="server" MaxLength="6" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.proschedule") %>'>
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
                        <asp:Label ID="labteladdname" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.telphoneName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtteladdname" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.telphoneName") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn Visible="true" HeaderText="联系电话">
                    <ItemTemplate>
                        <asp:Label ID="labteladd" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.telphoneADD") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtteladd" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.telphoneADD") %>'
                            Enabled="False">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="项目描述" HeaderStyle-Font-Names="true">
                    <HeaderStyle Font-Names="true"></HeaderStyle>
                    <ItemStyle CssClass="des"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labdes" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container.DataItem,"projectDir").ToString().Length>10?DataBinder.Eval(Container.DataItem,"projectDir").ToString().Substring(0,10) + "...":DataBinder.Eval(Container.DataItem,"projectDir").ToString()%>' ToolTip='<%# DataBinder.Eval(Container, "DataItem.projectDir") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtdes" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container.DataItem,"projectDir").ToString().Length>10?DataBinder.Eval(Container.DataItem,"projectDir").ToString().Substring(0,10) + "...":DataBinder.Eval(Container.DataItem,"projectDir").ToString()%>' ToolTip='<%# DataBinder.Eval(Container, "DataItem.projectDir") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="结项">
                    <ItemStyle CssClass="option"></ItemStyle>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit1" runat="server" ToolTip="结项" CommandName="Edit1" ImageUrl="~/image/chaigai.jpg">
                        </asp:ImageButton>
<%--                        <asp:ImageButton ID="btnDelete1" Visible="false" runat="server" ImageUrl="../CommUI/Images/icon-delete.gif"
                            CommandName="Delete1"></asp:ImageButton>--%>
                    </ItemTemplate>
<%--                    <EditItemTemplate>                        
                            <asp:ImageButton ID="btnUpdate" runat="server" ToolTip="保存修改" CommandName="Update"
                                ImageUrl="../CommUI/Images/icon-floppy.gif"></asp:ImageButton>
                            <asp:ImageButton ID="btnCancel" runat="server" ToolTip="放弃修改" CommandName="Cancel"
                                ImageUrl="../CommUI/Images/icon-pencil-x.gif"></asp:ImageButton>
                    </EditItemTemplate>--%>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="归档">
                    <ItemStyle CssClass="option"></ItemStyle>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit" runat="server" ToolTip="归档" CommandName="Edit" ImageUrl="~/image/hetong.jpg">
                        </asp:ImageButton>
                        <asp:ImageButton ID="btnDelete" Visible="false" runat="server" ImageUrl="../CommUI/Images/icon-delete.gif"
                            CommandName="Delete"></asp:ImageButton>
                    </ItemTemplate>
                    <EditItemTemplate>                        
                            <asp:ImageButton ID="btnUpdate" runat="server" ToolTip="保存修改" CommandName="Update"
                                ImageUrl="../CommUI/Images/icon-floppy.gif"></asp:ImageButton>
                            <asp:ImageButton ID="btnCancel" runat="server" ToolTip="放弃修改" CommandName="Cancel"
                                ImageUrl="../CommUI/Images/icon-pencil-x.gif"></asp:ImageButton>
                    </EditItemTemplate>
                </asp:TemplateColumn>

                <asp:ButtonColumn CommandName="Delete" HeaderText="删除项目" Text="删除">
                    <ItemStyle ForeColor="#d60808"/>
                </asp:ButtonColumn>

            </Columns>
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" Mode="NumericPages" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:DataGrid>
                        </div>
 
           
    </div>
    </form>
    </center>
</body>
</html>
