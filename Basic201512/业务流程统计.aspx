<%@ Page Language="C#" AutoEventWireup="true" CodeFile="业务流程统计.aspx.cs" Inherits="Basic201512_受助人" EnableEventValidation="false" %>

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

    <title>业务流程统计</title>

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
        .option { width: 100px; }
        .option { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
        td { text-align: center; }
        .id { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
        .txtbox { width: 95%; padding: 0; margin: 0; }
        .name { width: 170px; }
        .name { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
        .des {
        width:40px;
        }
        .des1 {
        width:100px;
        }
        .index {
        width:90px;
        }
        </style>
</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline" role="form">
        <div>
            <h2>
               <strong>业务流程统计</strong> 
            </h2>
        </div>
                                <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="执行单位："></asp:Label>
                                <asp:DropDownList ID="dpdhand" runat="server" class="btn btn-default dropdown-toggle">
                                </asp:DropDownList>
                                
                                <asp:Label ID="Label1" runat="server" Text="项目ID："></asp:Label>
                                
                                <asp:TextBox ID="TbselectID" runat="server" Width="142px" CssClass="form-control"></asp:TextBox>
                                 <asp:Label ID="Label2" runat="server" Text="项目名称："></asp:Label>
                                <asp:TextBox ID="TbselectName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Button ID="Btselect" runat="server" OnClick="Btselect_Click" Text="确认" CssClass=" btn btn-danger" />
                               <asp:Button ID="btoutexl" runat="server" Text="导出" CssClass="btn btn-danger" OnClick="btoutexl_Click" />
                                     </div>

          <div id="divPrint" runat="server">                
    <asp:DataGrid ID="dgData" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="1300px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" OnItemDataBound="dgData_ItemDataBound1">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
            <ItemStyle CssClass="dg_item" BackColor="White" ForeColor="#330099"></ItemStyle>
            <EditItemStyle CssClass="dg_item" />
            <Columns>
            <%--    <asp:TemplateColumn HeaderText="操作">
                    <ItemStyle CssClass="option"></ItemStyle>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit" runat="server" ToolTip="编辑" CommandName="Edit" ImageUrl="../CommUI/Images/icon-pencil.gif">
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
                <asp:TemplateColumn HeaderText="项目ID">
                    <ItemStyle CssClass="id"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="labID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
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
                    <ItemStyle CssClass="option"></ItemStyle>
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
                <asp:TemplateColumn Visible="false" HeaderText="联系人">
                    <ItemStyle CssClass="index"></ItemStyle>
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
                <asp:TemplateColumn Visible="False" HeaderText="联系电话">
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
                 <asp:TemplateColumn HeaderText="申请时间" HeaderStyle-Font-Names="true">

                     <HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle CssClass="des1"></ItemStyle>
                    
                    <ItemTemplate>
                        <asp:Label ID="labtime" runat="server" CssClass="txtbox" Text='<%#Eval(bandtime,"{0:yyyy-MM-dd}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txttime" runat="server" MaxLength="40" CssClass="txtbox" Text='<%#Eval(bandtime,"{0:yyyy-MM-dd}") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="科室审批时间" HeaderStyle-Font-Names="true">

                     <HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle CssClass="des1"></ItemStyle>
                    
                    <ItemTemplate>
                        <asp:Label ID="labtimeshen" runat="server" CssClass="txtbox" Text='<%#Eval(bandtimeshen,"{0:yyyy-MM-dd}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txttimeshen" runat="server" MaxLength="40" CssClass="txtbox" Text='<%#Eval(bandtimeshen,"{0:yyyy-MM-dd}") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="审批用时（天）" HeaderStyle-Font-Names="true">
                     <HeaderStyle Font-Names="true"></HeaderStyle>
                    <ItemStyle CssClass="des1"></ItemStyle>               
                    <ItemTemplate>
                        <asp:Label ID="labtimespend" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.keshispend") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="会长审批时间" HeaderStyle-Font-Names="true">

                     <HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle CssClass="des1"></ItemStyle>
                    
                    <ItemTemplate>
                        <asp:Label ID="labtimeshen1" runat="server" CssClass="txtbox" Text='<%#Eval(bandtimeshen1,"{0:yyyy-MM-dd}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txttimeshen1" runat="server" MaxLength="40" CssClass="txtbox" Text='<%#Eval(bandtimeshen1,"{0:yyyy-MM-dd}") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="审批用时（天）" HeaderStyle-Font-Names="true">
                     <HeaderStyle Font-Names="true"></HeaderStyle>
                    <ItemStyle CssClass="des1"></ItemStyle>               
                    <ItemTemplate>
                        <asp:Label ID="labtimespend1" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.huizhangspend") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="结项时间" HeaderStyle-Font-Names="true">
                    <ItemStyle CssClass="des1"></ItemStyle>               
                     <HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle CssClass="des1"></ItemStyle>
                    
                    <ItemTemplate>
                        <asp:Label ID="labtimefinsh" runat="server" CssClass="txtbox" Text='<%#Eval(bandtimefinsh,"{0:yyyy-MM-dd}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txttimefinsh" runat="server" MaxLength="40" CssClass="txtbox" Text='<%#Eval(bandtimefinsh,"{0:yyyy-MM-dd}") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                   
              
            
             
                    <asp:TemplateColumn HeaderText="执行用时（天）" HeaderStyle-Font-Names="true">
                     <HeaderStyle Font-Names="true"></HeaderStyle>
                    <ItemStyle CssClass="des1"></ItemStyle>               
                    <ItemTemplate>
                        <asp:Label ID="labtimespend2" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.zhixingspend") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                   <asp:TemplateColumn HeaderText="归档时间" HeaderStyle-Font-Names="true">

                     <HeaderStyle Font-Names="true"></HeaderStyle>

                    <ItemStyle CssClass="des1"></ItemStyle>
                    
                    <ItemTemplate>
                        <asp:Label ID="labtimeguid" runat="server" CssClass="txtbox" Text='<%#Eval("prodatatimeguid","{0:yyyy-MM-dd}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txttimeguid" runat="server" MaxLength="40" CssClass="txtbox" Text='<%#Eval("prodatatimeguid","{0:yyyy-MM-dd}") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="归档用时（天）" HeaderStyle-Font-Names="true">
                     <HeaderStyle Font-Names="true"></HeaderStyle>
                    <ItemStyle CssClass="des1"></ItemStyle>               
                    <ItemTemplate>
                        <asp:Label ID="labtimespend2" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.jiexiangspend") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                   
              
            
             
            </Columns>
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:DataGrid>
          </div>  

    </form>
    </center>
</body>
</html>
