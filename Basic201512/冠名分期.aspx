<%@ Page Language="C#" AutoEventWireup="true" CodeFile="冠名分期.aspx.cs" Inherits="Basic201512_冠名分期" %>

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
    <title></title>
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
        tr { padding: 0; margin: 0; border: 0; }
        td { text-align: center; }
        .data_Option { width: 50px; }
        .data_Id { width: 180px; }
        .data_Name { width: 300px; }
        .data_ShortName { width: 300px; }
        .data_Energy { width: 80px; }
        .data_SubItem { width: 140px; }
        .data_Purpose { width: 80px; }
        .data_Business { width: 80px; }
        .data_Index { width: 50px; }
        .data_Open { width: 40px; }
        .data_Beizhu { width: 230px; }

        #GridView1 th{
            text-align:center
        }
        .label_style {
            font-size: 15px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        }
        .listItem_style {
            font-size: 16px;
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
            border-color: #CC9966;
        }
        th {
            padding: 0px 10px 0px 10px;
            text-align:center;
            white-space: nowrap;
            border-color: #CC9966;
        }
        .page_style {
            color: #bd1c1c; 
            font-size: 16px;          
        }
        .gridView_style {
            font-family: 'Microsoft YaHei';
            font-size: 14px;
        }
        .font_style1:hover {
            color: #721313 !important;
            transition: 0.2s;
        }
     </style>
</head>
<body>
    <center>
        <form id="form1" runat="server" class="form-inline" role="form">
            <div>
                <h2>
                    <strong>冠名慈善捐助金周期提醒</strong> 
                </h2>
            </div>
            <div class="form-group">
                <asp:GridView ID="GridView1" runat="server" Width="900px" CssClass="gridView_style" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID">
                            <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px"/>
                            <ItemStyle Height="30px" CssClass="mycenter"/>    
                        </asp:BoundField>                       
                        <asp:BoundField DataField="benfactorName" HeaderText="名称" >
                            <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" />
                            <ItemStyle Height="30px" CssClass="mycenter"/> 
                        </asp:BoundField>
                        <asp:BoundField DataField="benfactorFrom" HeaderText="所属机构" >
                            <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" />
                            <ItemStyle Height="30px" CssClass="mycenter"/> 
                        </asp:BoundField>
                        <asp:BoundField DataField="deadline" HeaderText="截止时间" >
                            <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px"/>
                            <ItemStyle Height="30px" CssClass="mycenter"/> 
                        </asp:BoundField>
                        <asp:BoundField DataField="cycle" HeaderText="提醒周期（月）" >
                            <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" />
                            <ItemStyle Height="30px" CssClass="mycenter"/> 
                        </asp:BoundField>
                        <asp:BoundField DataField="flag" HeaderText="剩余提醒次数" >
                            <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px"/>
                            <ItemStyle Height="30px" CssClass="mycenter"/> 
                        </asp:BoundField>
                        <asp:ButtonField CommandName="cancelRemind" HeaderText="取消本次提醒" Text="取消" >
                            <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="mycenter"/>
                            <ControlStyle Font-Underline="false" CssClass="font_style1" ForeColor="#d60808"/>
                            <ItemStyle HorizontalAlign="Center" Wrap="false"/>
                        </asp:ButtonField>
                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="gridhead"/>
                    <PagerStyle BackColor="#FFFFCC" HorizontalAlign="Center" CssClass="page_style"/>
                    <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
            </div>
        </form>
    </center>
</body>
</html>
