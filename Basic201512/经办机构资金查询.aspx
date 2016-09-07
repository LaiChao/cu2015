<%@ Page Language="c#" Inherits="CL.Utility.Web.BasicData.Register" CodeFile="��������ʽ��ѯ.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- ����3��meta��ǩ*����*������ǰ�棬�κ��������ݶ�*����*������� -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>��������ʽ�״��</title>

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
        tr { padding: 0; margin: 0; border: 0; }
        td { text-align: center; }

        #GridView1 th {
        text-align:center;
        }

        .mycenter {
            text-align: center;
            color: black;           
        }
        .label_style {
            font-size: 15px;
            text-align: right;
            font-family: 'Microsoft YaHei';
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
    </style>    
</head>
    
<body>
    <form id="Form1" runat="server">
    <center>
        <div>
            <h2>
              <strong>�����������״��</strong>
            </h2>
        </div>
    <div class="form-group">
        <asp:GridView ID="GridView1" CssClass="gridView_style" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="800px" OnRowDataBound="GridView1_RowDataBound" >
            <Columns>
                <asp:BoundField DataField="benfactorFrom" HeaderText="�����������" >
                    <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="mycenter"/>
                    <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                </asp:BoundField>
                <%--<asp:BoundField DataField="thisMonth" HeaderText="����ʹ���ʽ�"  HeaderStyle-Height="30px" ItemStyle-Height="30px" >
                    <HeaderStyle Height="30px"></HeaderStyle>
                    <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                </asp:BoundField>--%>
                <asp:BoundField HeaderText="ʣ���ʽ�" DataField="remain" >
                    <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="mycenter"/>
                    <ItemStyle Height="30px" CssClass="mycenter"></ItemStyle>
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="benfactorFrom" DataNavigateUrlFormatString="�ʽ�׷��.aspx?from={0}" HeaderText="�鿴�ʽ�ʹ�����" Text="�鿴">
                    <HeaderStyle HorizontalAlign="Center" BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" Height="30px" CssClass="mycenter"/>
					<ControlStyle Font-Underline="false" CssClass="font_style"/>
                    <ItemStyle HorizontalAlign="Center" Wrap="false"/>
                </asp:HyperLinkField>
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
    </center>
    </form>
</body>
</html>
