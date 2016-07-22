<%@ Page Language="C#" AutoEventWireup="true" CodeFile="信息查看.aspx.cs" Inherits="Basic201512_信息查看" %>

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

    <title>信息查看</title>

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
        #form1 {
            width: 1000px;
        }
        .div1 {
        width:950px;
        text-align:left;
        }
    </style>
</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline">
  
        <div>
        <h2>
           <strong>信息查看</strong> 
        </h2>
    </div>     
            <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="标记为"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" class="btn btn-default dropdown-toggle">
                <asp:ListItem>未读</asp:ListItem>
                <asp:ListItem>已读</asp:ListItem>
            </asp:DropDownList>
            
        &nbsp;<asp:Button ID="btnReceipt" runat="server" OnClick="btnReceipt_Click" Text="发送回执" CssClass="btn btn-danger" />
        &nbsp;<asp:Button ID="btnBatch" runat="server" OnClick="btnBatch_Click" Text="批量选择受助人" CssClass=" btn btn-danger" Height="34px" Width="128px"/> 
               &nbsp;<asp:Button ID="btnBatchAdd" runat="server" OnClick="btnBatchAdd_Click" Text="批量添加受助人" CssClass=" btn btn-danger" Height="34px" Width="128px"/>  
               &nbsp;<asp:Button ID="btnchoic" runat="server"  Text="受助人预选" CssClass=" btn btn-danger" Height="34px" Width="128px" OnClick="btnchoic_Click"/>           
                 <asp:Label ID="lblErr" runat="server" ForeColor="Red"></asp:Label>
            </div>           
        <br />
         <div id="publicProject" runat="server" class="form-group div1">
            <asp:Label ID="Label4" runat="server" Text="项目ID："></asp:Label>
            <asp:TextBox ID="tbID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>       
        </div> 
        <br />
        <br />
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="标题："></asp:Label>
            <asp:TextBox ID="infoTitle" runat="server" CssClass="form-control" Width="900px"></asp:TextBox>
        </div>
        <br />
        <br />
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="内容："></asp:Label>
            <asp:TextBox ID="infoContent" runat="server" Height="250px" CssClass="form-control" TextMode="MultiLine" Width="900px"></asp:TextBox>
         </div>    
    
     <div>
         文件列表
     </div>
     <div>
         <asp:ListBox ID="ListBox1" runat="server" Width="250px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
         </asp:ListBox>
         <br />
         
     </div>
             <asp:Button ID="Button4" runat="server" Text="下载文件" onclick="Button4_Click"  Height="40px" Width="109px" class="btn btn-danger"/>
           <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="返回" Height="40px" Width="109px" class="btn btn-danger" />
   
         </form>
    </center>
</body>
</html>

