﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="资金申请分配.aspx.cs" Inherits="Basic201512_受助人" %>

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

    <title>资金申请分配</title>

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
        #div_dynamic {  border: #cc9966 0px solid;  }
        #divTitle, #div_dynamic { width: 1000px; margin:0 auto; }
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
     <script language="javascript" type="text/javascript">
         function click()
         {
            
         }
         </script>
</head>
<body>
    
    <form id="form1" runat="server" class="form-inline" role="form">
        <center>
        <div id="div_dynamic" >
    <div>   
         <h2>
            <strong>善款分配申请</strong> 
         </h2>   
    </div>
        <div>
            <div class="form-group">
                <p style="text-align: center;margin:0 auto">
                    <asp:Label ID="Label4" runat="server" Text="项目ID:" CssClass="label_style"></asp:Label>
                    <asp:TextBox ID="txtproid" runat="server" Width="100px" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                    <asp:Label ID="Label5" runat="server" Text="负责人:" CssClass="label_style"></asp:Label>
                    <asp:TextBox ID="txttelname" runat="server" Width="100px" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="项目名称:" CssClass="label_style"></asp:Label>
                    <asp:TextBox ID="TbselectName" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>&nbsp; &nbsp;                                     
<%--                </p>
                <br />      
                <p style="text-align: center;margin:0 auto">--%>
                    <asp:Label ID="Label2" runat="server" Text="项目执行单位:" CssClass="label_style"></asp:Label>
                    <asp:DropDownList ID="dpdhud" runat="server" class="btn btn-default dropdown-toggle">
                        <asp:ListItem>全部</asp:ListItem>
                    </asp:DropDownList>&nbsp;
                    <asp:Button ID="Btselect" runat="server" OnClick="Btselect_Click" Text="搜索" CssClass=" btn btn-danger" Width="80px" Height="34px" />
                </p>
                <br />        
            </div> 
            <p style="text-align: center;margin:0 auto">
                   <asp:Label ID="lbpoint" runat="server" Text="操作说明：按项目信息详细搜索项目，显示结果并点击捐赠物资跳转申请物资页面" CssClass="label_style"></asp:Label>
            </p>
            <br />
        </div>
        </div>
        <div>
            <asp:DataGrid ID="dgData" runat="server" CssClass="gridView_style" AutoGenerateColumns="False" CellPadding="4" Width="900px" BackColor="White" BorderColor="#ce2c27" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
                        <EditItemStyle CssClass="dg_item" />
                        <Columns>
                            <asp:TemplateColumn HeaderText="捐赠物资或资金">
                                <ItemTemplate>
                                    <asp:HyperLink Text="进行匹配" NavigateUrl='<%#"资金申请分配副本1.aspx?type="+DataBinder.Eval(Container.DataItem,"projectType")+"&benfactorName="+DataBinder.Eval(Container.DataItem,"projectID") %>' runat="server">

                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateColumn>
<%--                            <asp:HyperLinkColumn HeaderText="项目ID" DataTextField="projectID" ></asp:HyperLinkColumn>
                            <asp:HyperLinkColumn HeaderText="项目名称" DataTextField="projectName" ></asp:HyperLinkColumn>--%>
                            <asp:TemplateColumn  HeaderText="项目ID">
                                <ItemTemplate>
                                    <asp:Label runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'>
                        </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'
                            Enabled="False">
                        </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn  HeaderText="项目名称">
                                <ItemTemplate>
                                    <asp:Label runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectName") %>'>
                        </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectName") %>'
                            Enabled="False">
                        </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="执行单位">
                                <ItemStyle CssClass="index"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="labteladd" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
                        </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtteladd" runat="server" MaxLength="6" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
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
                            <asp:TemplateColumn Visible="true" HeaderText="申请资金">
                                <ItemTemplate>
                                    <asp:Label ID="labemail" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.needMoney") %>'>
                        </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtemail" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.needMoney") %>'
                            >
                        </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn  HeaderText="项目负责人">
                                <ItemTemplate>
                                    <asp:Label ID="labdir" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.telphoneName") %>'>
                        </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtdir" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.telphoneName") %>'
                            Enabled="False">
                        </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="项目联系方式" HeaderStyle-Font-Names="true">
                                <HeaderStyle Font-Names="true"></HeaderStyle>
                                <ItemStyle CssClass="des"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="labguanming" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.telphoneADD") %>'>
                        </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditguanming" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.telphoneADD") %>'>
                        </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="项目描述" HeaderStyle-Font-Names="true">
                                <HeaderStyle Font-Names="true"></HeaderStyle>
                                <ItemStyle CssClass="des"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="labwuzhu" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container.DataItem,"projectDir").ToString().Length>10?DataBinder.Eval(Container.DataItem,"projectDir").ToString().Substring(0,10) + "...":DataBinder.Eval(Container.DataItem,"projectDir").ToString()%>' ToolTip='<%# DataBinder.Eval(Container, "DataItem.projectDir") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditwuzhu" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container.DataItem,"projectDir").ToString().Length>10?DataBinder.Eval(Container.DataItem,"projectDir").ToString().Substring(0,10) + "...":DataBinder.Eval(Container.DataItem,"projectDir").ToString()%>' ToolTip='<%# DataBinder.Eval(Container, "DataItem.projectDir") %>'></asp:TextBox>
                                </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="项目类型" HeaderStyle-Font-Names="true">
                            <HeaderStyle Font-Names="true"></HeaderStyle>
                            <ItemStyle CssClass="des"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="labxmlx" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectType") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditxmlx" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectType") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    </asp:DataGrid>
        </div>
        </center>
         </form>

</body>
</html>
