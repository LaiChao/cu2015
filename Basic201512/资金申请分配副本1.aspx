<%@ Page Language="C#" AutoEventWireup="true" CodeFile="资金申请分配副本1.aspx.cs" Inherits="Basic201512_受助人"  EnableEventValidation="false"%>

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
        .option { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
        td { text-align: center; }
        .id { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
        .txtbox { width: 95%; padding: 0; margin: 0; }
        .name { width: 170px; }
        .name { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
         #form1 {
             width: 850px;             
          }
        
        </style>
     <script language="javascript" type="text/javascript">
         
         </script>
</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline">
        <div>
            <h2>
               <strong>善款分配申请</strong> 

            </h2>
        </div> 
        
                <h4>
                <asp:Label ID="Label5" runat="server" Text="项目ID:"></asp:Label>
                <asp:Label ID="LbproID" runat="server" Text="" class="label label-default"></asp:Label>
                &nbsp;<asp:Label ID="Label7" runat="server" Text="项目类型:"></asp:Label>
                <asp:Label ID="lblType" runat="server" class="label label-default"></asp:Label>
                    &nbsp;<asp:Label ID="lblNaming" runat="server" class="label label-default"></asp:Label>
                    &nbsp;<asp:Label ID="lblDirect" runat="server" class="label label-default"></asp:Label>
&nbsp;<asp:Label ID="Label6" runat="server" Text="项目名称:"></asp:Label>
                <asp:Label ID="lbbenfnadd" runat="server" class="label label-default"></asp:Label>
                &nbsp;<asp:Label ID="Label4" runat="server" Text="计划资金:"></asp:Label>
                <asp:Label ID="lbcaptID" runat="server" class="label label-default"></asp:Label>                               
                <%--<asp:Button ID="Btselect" runat="server" OnClick="Btselect_Click" Text="匹配资金" CssClass=" btn btn-danger" Height="34px" Width="80px" />--%>
                    <asp:Label ID="lberror" runat="server" BorderColor="#FF6699" ForeColor="Red"></asp:Label>
                 </h4>               
                    <div class="form-group">
                    捐助人名称:<asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="btn btn-danger" Text="搜索" Height="34px" Width="80px" />

                    </div>          
                       
       <%--<asp:Label ID="lberror" runat="server" BorderColor="#FF6699" ForeColor="Red"></asp:Label>--%>
    <%--    <asp:Label ID="lberror" runat="server" BorderColor="#FF6699" ForeColor="Red"></asp:Label>--%>
                &nbsp;<asp:DataGrid ID="dgData" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="800px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <ItemStyle CssClass="dg_item" BackColor="White" ForeColor="#330099"></ItemStyle>
            <EditItemStyle CssClass="dg_item" />
            <Columns>
                   
                <asp:TemplateColumn HeaderText="操作">
                    <ItemStyle CssClass="option"></ItemStyle>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit" runat="server" ToolTip="编辑" CommandName="Edit" ImageUrl="../CommUI/Images/icon-pencil.gif">
                        </asp:ImageButton>
                        <%--<asp:ImageButton ID="btnDelete" Visible="true" runat="server" ImageUrl="../CommUI/Images/icon-delete.gif"
                            CommandName="Delete"></asp:ImageButton>--%>
                    </ItemTemplate>
                    <EditItemTemplate>                           
                            <asp:ImageButton ID="btnUpdate" runat="server" ToolTip="保存修改" CommandName="Update"
                                ImageUrl="../CommUI/Images/icon-floppy.gif"></asp:ImageButton>                            
                            <asp:ImageButton ID="btnCancel" runat="server" ToolTip="放弃修改" CommandName="Cancel"
                                ImageUrl="../CommUI/Images/icon-pencil-x.gif"></asp:ImageButton>
                    </EditItemTemplate>
                </asp:TemplateColumn>                           
                <asp:TemplateColumn HeaderText="资金ID">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labteladd" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtteladd" runat="server"  CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalID") %>' Enabled="false">
                        </asp:TextBox>
                    </EditItemTemplate>                
					</asp:TemplateColumn>  
					<asp:TemplateColumn HeaderText="捐助人名称">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labdename" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtdename" runat="server"  CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>' Enabled="false">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="捐助人ID" Visible="false">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="bectID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="bectID" runat="server"  CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorID") %>' Enabled="false">
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
                <asp:TemplateColumn Visible="true" HeaderText="拥有资金">
                    <ItemTemplate>
                        <asp:Label ID="labemail" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalEarn") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtemail" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalEarn") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn  HeaderText="资金录入时间">
                    <ItemTemplate>
                        <asp:Label ID="labdirtime" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalIntime") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtdirtime" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalIntime") %>'
                            Enabled="False">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn  HeaderText="项目ID" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="labproid" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtproid" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'
                           Enabled="false"  >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                 
            </Columns>
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:DataGrid>
        <br />
    <asp:DataGrid ID="dgData1" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="800px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <ItemStyle CssClass="dg_item" BackColor="White" ForeColor="#330099"></ItemStyle>
            <EditItemStyle CssClass="dg_item" />
            <Columns>
                   
                <asp:TemplateColumn HeaderText="操作">
                    <ItemStyle CssClass="option"></ItemStyle>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit" runat="server" ToolTip="编辑" CommandName="Edit" ImageUrl="../CommUI/Images/icon-pencil.gif">
                        </asp:ImageButton>
                        <%--<asp:ImageButton ID="btnDelete" Visible="true" runat="server" ImageUrl="../CommUI/Images/icon-delete.gif"
                            CommandName="Delete"></asp:ImageButton>--%>
                    </ItemTemplate>
                    <EditItemTemplate>                           
                            <asp:ImageButton ID="btnUpdate" runat="server" ToolTip="保存修改" CommandName="Update"
                                ImageUrl="../CommUI/Images/icon-floppy.gif"></asp:ImageButton>                            
                            <asp:ImageButton ID="btnCancel" runat="server" ToolTip="放弃修改" CommandName="Cancel"
                                ImageUrl="../CommUI/Images/icon-pencil-x.gif"></asp:ImageButton>
                    </EditItemTemplate>
                </asp:TemplateColumn>                           
                <asp:TemplateColumn HeaderText="物品ID">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="lblItemID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.itemID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbItemID" runat="server"  CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.itemID") %>' Enabled="false">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="物品名称">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="lblItemName" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.item") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbItemName" runat="server"  CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.item") %>' Enabled="false">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn Visible="true" HeaderText="公允值">
                    <ItemTemplate>
                        <asp:Label ID="lblValue" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.fairValue") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbValue" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.fairValue") %>' Enabled="false">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="所属机构">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="lblBranch" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbBranch" runat="server"  CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>' Enabled="false">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="捐助人名称">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbName" runat="server"  CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorName") %>' Enabled="false">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
<%--                <asp:TemplateColumn HeaderText="捐助人ID" Visible="false">
                    <ItemStyle CssClass="index"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="bectID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="bectID" runat="server"  CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorID") %>' Enabled="false">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>
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
<%--                <asp:TemplateColumn Visible="true" HeaderText="拥有资金">
                    <ItemTemplate>
                        <asp:Label ID="labemail" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalEarn") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtemail" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalEarn") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn  HeaderText="资金录入时间">
                    <ItemTemplate>
                        <asp:Label ID="labdirtime" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalIntime") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtdirtime" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.capitalIntime") %>'
                            Enabled="False">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>
                <asp:TemplateColumn  HeaderText="项目ID">
                    <ItemTemplate>
                        <asp:Label ID="lblProjectID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbProjectID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'
                           Enabled="false"  >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                 
            </Columns>
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:DataGrid>
        <br />       
        </div>   
    </form>
    </center>
</body>
</html>
