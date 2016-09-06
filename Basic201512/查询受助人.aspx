<%@ Page Language="C#" AutoEventWireup="true" CodeFile="查询受助人.aspx.cs" Inherits="Basic201512_查询受助人" EnableEventValidation = "false" %>

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

    <title>受助人信息管理</title>

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
            color: #0a1e58;
            transition: 0.2s;
        }
        .font_style1:hover {
            color: #721313 !important;
            transition: 0.2s;
        }
    </style>

    </head>
<body align="center">
    <center>
    <div style="height: 41px">
    
        <h2>
            <strong>受助人信息管理</strong> 
            <br />
        </h2>      
    </div>
    <form id="form1" runat="server" class="form-inline">
        <div class="form-group">              
            <p>
                <asp:Label ID="Label3" runat="server" Text="来源:" CssClass="label_style"></asp:Label>
                <asp:DropDownList ID="benfactorFrom" runat="server" class="btn btn-default dropdown-toggle" >
                <asp:ListItem>所有机构</asp:ListItem>
                </asp:DropDownList>&nbsp;
                <asp:Label ID="Label2" runat="server" Text="姓名:" CssClass="label_style"></asp:Label>
                <asp:TextBox ID="TextBoxName" runat="server" CssClass="form-control" Width="80px"  ></asp:TextBox>&nbsp;
                <asp:Label ID="Label4" runat="server" Text="性别:" CssClass="label_style"></asp:Label>
                <asp:DropDownList ID="sex" runat="server" class="btn btn-default dropdown-toggle">
                <asp:ListItem>未指定</asp:ListItem>
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
                </asp:DropDownList>&nbsp;
                <asp:Label ID="Label5" runat="server" Text="年龄:" CssClass="label_style"></asp:Label>
                <asp:TextBox ID="age" runat="server" CssClass="form-control" Width="80px"></asp:TextBox>&nbsp;
                <asp:Label ID="Label6" runat="server" Text="致困原因:" CssClass="label_style"></asp:Label>
                <asp:DropDownList ID="reason" runat="server" class="btn btn-default dropdown-toggle">
                <asp:ListItem>未指定</asp:ListItem>
                <asp:ListItem>无</asp:ListItem>
                <asp:ListItem>低保</asp:ListItem>
                <asp:ListItem>低收入</asp:ListItem>
                <asp:ListItem>其他</asp:ListItem>
                </asp:DropDownList>&nbsp;
                <asp:Label ID="Label1" runat="server" Text="受助类别:" CssClass="label_style"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" class="btn btn-default dropdown-toggle">
                <asp:ListItem>未指定</asp:ListItem>
                <asp:ListItem>助学</asp:ListItem>
                <asp:ListItem>助医</asp:ListItem>
                <asp:ListItem>助残</asp:ListItem>
                <asp:ListItem>助老</asp:ListItem>
                <asp:ListItem>助困</asp:ListItem>
                <asp:ListItem>双拥</asp:ListItem>
                <asp:ListItem>重特大灾害</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click"  class="btn btn-danger"/>
            </p>
            <p>
                <asp:Label ID="Label7" runat="server" Text="项目ID:"  CssClass="label_style"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;
                <asp:Label ID="Label8" runat="server" Text="项目名称:" CssClass="label_style"></asp:Label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ></asp:TextBox>&nbsp;
                <asp:Button ID="btnQuery2" runat="server" Text="查询" OnClick="btnQuery2_Click"  class="btn btn-danger"/>            
            </p>
        </div>
        <div>            
            <asp:Label ID="Label9" runat="server" Text="请选择需要导出的列：" CssClass="label_style"></asp:Label>
            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Checked="True" Text="来源" OnCheckedChanged="CheckBox1_CheckedChanged" CssClass="checkBox_style" />
            &nbsp;<asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" Checked="True" Text="性别" OnCheckedChanged="CheckBox3_CheckedChanged" CssClass="checkBox_style"/>
            &nbsp;<asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="True" Checked="True" Text="年龄" OnCheckedChanged="CheckBox4_CheckedChanged" CssClass="checkBox_style"/>
            &nbsp;<asp:CheckBox ID="CheckBox5" runat="server" AutoPostBack="True" Checked="True" Text="致困原因" OnCheckedChanged="CheckBox5_CheckedChanged" CssClass="checkBox_style"/>
            &nbsp;<asp:CheckBox ID="CheckBox6" runat="server" AutoPostBack="True" Checked="True" Text="受助类别" OnCheckedChanged="CheckBox6_CheckedChanged" CssClass="checkBox_style"/>
            &nbsp;<asp:CheckBox ID="CheckBox7" runat="server" AutoPostBack="True" Checked="True" Text="联系电话" OnCheckedChanged="CheckBox7_CheckedChanged" CssClass="checkBox_style"/>
            &nbsp;<asp:CheckBox ID="CheckBox8" runat="server" AutoPostBack="True" Checked="True" Text="身份证号" OnCheckedChanged="CheckBox8_CheckedChanged" CssClass="checkBox_style"/>
            &nbsp;<asp:CheckBox ID="CheckBox9" runat="server" AutoPostBack="True" Checked="True" Text="低保低收入号" OnCheckedChanged="CheckBox9_CheckedChanged" CssClass="checkBox_style"/>
            &nbsp;<asp:Button ID="btnExp" runat="server" Text="导出" CssClass="btn btn-danger" OnClick="btnExp_Click"/>
        </div>
        <br />
        <div id="divPrint" runat="server">
            <div class="form-group">
                <asp:GridView ID="GridView1" runat="server" CssClass="gridView_style" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True"  OnRowDeleting="GridView1_RowDeleting" OnRowCreated="GridView1_RowCreated" HorizontalAlign="Center" OnPageIndexChanging="GridView1_PageIndexChanging" >                     
                    <Columns>                            
                        <asp:BoundField DataField="benfactorFrom" HeaderText="受助人来源" HeaderStyle-Height="30px" ItemStyle-Height="30px">
                            <HeaderStyle Height="30px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                        </asp:BoundField>
                        <asp:HyperLinkField DataTextField="recipientsName" HeaderText="姓名" HeaderStyle-Height="30px" ItemStyle-Height="30px" DataNavigateUrlFormatString="查看受助人信息.aspx?ID={0}" DataNavigateUrlFields="recipientsID">
                            <ControlStyle Font-Underline="false"  CssClass="font_style"/>
                            <HeaderStyle Height="30px" HorizontalAlign="Center"></HeaderStyle> 
                            <ItemStyle  HorizontalAlign="Center"/>                          
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="sex" HeaderText="性别" HeaderStyle-Height="30px" ItemStyle-Height="30px">
                            <HeaderStyle Height="30px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="newAge" HeaderText="年龄" HeaderStyle-Height="30px" ItemStyle-Height="30px">
                            <HeaderStyle Height="30px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="reason" HeaderText="致困原因"  HeaderStyle-Height="30px" ItemStyle-Height="30px">
                            <HeaderStyle Height="30px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="受助类别" DataField="leibie" HeaderStyle-Height="30px" ItemStyle-Height="30px">
                            <HeaderStyle Height="30px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="telphoneADD" HeaderText="联系电话" HeaderStyle-Height="30px" ItemStyle-Height="30px" >
                            <HeaderStyle Height="30px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="recipientsPIdcard" HeaderText="身份证号" HeaderStyle-Height="30px" ItemStyle-Height="30px">
                            <HeaderStyle Height="30px"></HeaderStyle>
                            <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="incomlowID" HeaderText="低保低收入号"  HeaderStyle-Height="30px" ItemStyle-Height="30px">
                            <HeaderStyle Height="30px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                        </asp:BoundField>
                        <asp:HyperLinkField Text="编辑" HeaderStyle-Height="30px" ItemStyle-Height="30px" DataNavigateUrlFormatString="修改受助人信息.aspx?ID={0}" DataNavigateUrlFields="recipientsID">
                            <ControlStyle Font-Underline="false" CssClass="font_style"/>
                            <HeaderStyle Height="30px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                        </asp:HyperLinkField>
                        <asp:CommandField ShowDeleteButton="True" DeleteText="删除" HeaderStyle-Height="30px" ItemStyle-Height="30px">
                            <HeaderStyle Height="30px" HorizontalAlign="Center"></HeaderStyle>
                            <ControlStyle ForeColor="#d60808" Font-Underline="false" CssClass="font_style1"/>
                            <ItemStyle Height="30px"  CssClass="mycenter"></ItemStyle>
                        </asp:CommandField>
                        <asp:HyperLinkField DataNavigateUrlFields="recipientsID"  HeaderText="查看所在项目" DataNavigateUrlFormatString="业务流程统计.aspx?ID={0}" DataTextField="recipientsName">
                            <HeaderStyle HorizontalAlign="Center" Height="30px"></HeaderStyle>
                            <ControlStyle Font-Underline="false" CssClass="font_style"></ControlStyle>
                            <ItemStyle  HorizontalAlign="Center"/>
                        </asp:HyperLinkField>
                    </Columns>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099"  />
                        <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" CssClass="text-center" Height="30px" />
<%--                        <PagerSettings FirstPageText="首页" LastPageText="末页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" PageButtonCount="3" />--%>
                        <PagerTemplate>
                            <asp:Label ID="lblPage" runat="server" Text='<%# "第"+(((GridView)Container.NamingContainer).PageIndex+1)+"页/共"+(((GridView)Container.NamingContainer).PageCount)+"页" %> '></asp:Label>
                            <asp:LinkButton ID="lblFirst" runat="Server" Text="首页"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton>
                            <asp:LinkButton ID="lblPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton>
                            <asp:LinkButton ID="lblNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
                            <asp:LinkButton ID="lblLast" runat="Server" Text="尾页"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton>
                        </PagerTemplate>
                        <PagerStyle BackColor="#FFFFCC" HorizontalAlign="Center"  CssClass="page_style"/>
                        
                        <RowStyle BackColor="White" ForeColor="#330099"  />
                
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
            </div>
                </div>
            <%--            <div>
                    <asp:Button ID="btnReload" runat="server" OnClick="btnReload_Click" Text="刷新" CssClass="btn btn-danger" Width="80px" Height="34px" />
     </div>--%>
    </form>
   </center>
</body>
</html>
