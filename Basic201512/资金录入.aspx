<%@ Page Language="C#" AutoEventWireup="true" CodeFile="资金录入.aspx.cs" Inherits="Basic201512_受助人" %>

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

      <!-- Bootstrap core CSS -->
     <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
   <%-- <link href="../../dist/css/bootstrap-theme.min.css" rel="stylesheet">--%>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="theme.css" rel="stylesheet">
    <title>Theme Template for Bootstrap</title>
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
     <script language="javascript" type="text/javascript">
         function click()
         {
            
         }
         </script>
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
                                    <asp:DropDownList ID="benfactorType" runat="server" class="btn btn-default dropdown-toggle">
                                        <asp:ListItem Value="0">所有类型</asp:ListItem>
                                        
                                        <asp:ListItem Value="3">个人</asp:ListItem>
                                        <asp:ListItem Value="2">单位</asp:ListItem>
                                         <asp:ListItem Value="1">公益组织</asp:ListItem>
                                        <asp:ListItem Value="4">募捐箱</asp:ListItem>
                                        <asp:ListItem Value="5">冠名慈善捐助金</asp:ListItem>
                                    </asp:DropDownList>
                                   <asp:Label ID="Label1" runat="server" Text="名称:"></asp:Label>
                                    <asp:TextBox ID="TbselectName" runat="server" Width="116px" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="Label2" runat="server" Text="手机号:"></asp:Label>
                                    <asp:TextBox ID="TbselectID" runat="server" CssClass="form-control"></asp:TextBox>
                                   <asp:Button ID="Btselect" runat="server" OnClick="Btselect_Click" Text="搜索" CssClass=" btn btn-danger" Width="80px" Height="34px"/>
                                    <br />
                                    搜索不到捐赠人？前往&nbsp; <a href="捐赠人添加.aspx" target="main" >添加捐赠人</a>
                                    <br />
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="显示全部待确认金额" CssClass=" btn btn-danger" />
                       </div>        
                                         
                    <asp:DataGrid ID="dgData" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="900px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
                        <ItemStyle CssClass="dg_item" BackColor="White" ForeColor="#330099"></ItemStyle>
                        <EditItemStyle CssClass="dg_item" />
                        <Columns>
                        <asp:HyperLinkColumn DataTextField="benfactorID" DataNavigateUrlField="benfactorID"  HeaderText="捐助人ID"    DataNavigateUrlFormatString="资金录入副本.aspx?benfactorID={0}" ></asp:HyperLinkColumn>

                            <asp:TemplateColumn HeaderText="名称">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditID" runat="server" CssClass="txtbox" MaxLength="8" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="labID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'></asp:Label>
                                </ItemTemplate>
<%--                                <ItemStyle CssClass="id"></ItemStyle>--%>
                            </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="手机号">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtteladd" runat="server" CssClass="txtbox" MaxLength="6" Text='<%# DataBinder.Eval(Container, "DataItem.TEL") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="labteladd" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.TEL") %>'></asp:Label>
                            </ItemTemplate>
<%--                                <ItemStyle CssClass="index"></ItemStyle>--%>
                        </asp:TemplateColumn>                   
                            <asp:TemplateColumn HeaderText="email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtemail" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.email") %>'
                            >
                        </asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="labemail" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.email") %>'>
                        </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
<%--                            <asp:TemplateColumn Visible="False" HeaderText="联系电话">
                                <ItemTemplate>
                                    <asp:Label ID="labdir" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.directionlBef") %>'>
                        </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtdir" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.directionlBef") %>'
                            Enabled="False">
                        </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>--%>
<%--                            <asp:TemplateColumn  Visible="true" HeaderText="冠名捐助" HeaderStyle-Font-Names="微软雅黑" HeaderStyle-Font-Size="Medium" >
                                <HeaderStyle Font-Names="true"></HeaderStyle>
                                <ItemStyle CssClass="des"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="labguanming" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.guanming") %>'>
                        </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditguanming" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.guanming") %>'>
                        </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn  Visible="true" HeaderText="五助">
                                <HeaderStyle Font-Names="true"></HeaderStyle>
                                <ItemStyle CssClass="des"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="labwuzhu" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.wuzhu") %>'>
                        </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditwuzhu" runat="server" MaxLength="40" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.wuzhu") %>'>
                        </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>--%>
                        </Columns>
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    </asp:DataGrid>
                    <asp:DataGrid ID="dgData1" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="900px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" >
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
                        <ItemStyle CssClass="dg_item" BackColor="White" ForeColor="#330099"></ItemStyle>
                        <EditItemStyle CssClass="dg_item" />
                        <Columns>
                        <asp:HyperLinkColumn DataTextField="benfactorID" DataNavigateUrlField="benfactorID"  HeaderText="捐助人ID"    DataNavigateUrlFormatString="资金录入副本.aspx?benfactorID={0}" ></asp:HyperLinkColumn>
                            <asp:TemplateColumn HeaderText="名称">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditID" runat="server" CssClass="txtbox" MaxLength="8" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="labID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'></asp:Label>
                                </ItemTemplate>
<%--                                <ItemStyle CssClass="id"></ItemStyle>--%>
                            </asp:TemplateColumn>

                            <asp:TemplateColumn HeaderText="资金ID">
                                <ItemTemplate>
                                    <asp:Label ID="capitalID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalID") %>' MaxLength="40"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                            <asp:TemplateColumn HeaderText="手机号">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtteladd" runat="server" CssClass="txtbox" MaxLength="6" Text='<%# DataBinder.Eval(Container, "DataItem.TEL") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="labteladd" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.TEL") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="index"></ItemStyle>
                            </asp:TemplateColumn>                   

                            <asp:TemplateColumn HeaderText="已有资金">
                                <ItemTemplate>
                                    <asp:Label ID="capitalEarn" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalEarn") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="添加资金">
                                <ItemTemplate>
                                    <asp:Label ID="capitalIn" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalIn") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
<%--                            <asp:ButtonColumn CommandName="confirm" HeaderText="操作" Text="确认"></asp:ButtonColumn>--%>
                        </Columns>
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    </asp:DataGrid>
                    
    
       
    </form>
    </center>
</body>
</html>
