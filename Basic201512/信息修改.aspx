﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="信息修改.aspx.cs" Inherits="Basic201512_信息修改" %>

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

    <title>信息修改</title>

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
            width: 1200px;
            height: 740px;
        }
    </style>
</head>
<body>
        <center>
    <form id="form1" runat="server" class="form-inline" role="form">
    <div>
        <h2>
            
           <strong>信息修改</strong> 
       </h2>
    </div>      
        <p>     
             <asp:Label ID="Label1" runat="server" Text="标题："></asp:Label>
            <asp:TextBox ID="infoTitle" runat="server" Width="1000px" class="form-control" ></asp:TextBox>
        </p>
        <p> 
         <asp:Label ID="Label2" runat="server" Text="内容："></asp:Label>
         <asp:TextBox ID="infoContent" runat="server" Height="250px" TextMode="MultiLine"  Width="1000px" class="form-control"></asp:TextBox>
        </p>
         <div>
         文件列表
         </div>
        <div>
             <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" Width="200px" Height="50px" />                
             <asp:ListBox ID="ListBox1" runat="server" Width="350px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" class="form-control">
              <asp:ListItem Text="文件列表"></asp:ListItem>
             </asp:ListBox>
          </div>
        <asp:Button ID="Button3" runat="server" Text="上传文件并提交" onclick="Button3_Click" Height="40px"  class="btn btn-danger" Width="120px" /> &nbsp;      
        <asp:Button ID="Button4" runat="server" Text="下载文件" onclick="Button4_Click"  Height="40px"  class="btn btn-danger" Width="120px"/>&nbsp;
        <asp:Button ID="Button5" runat="server" Text="删除文件并提交"  onclick="Button5_Click" Height="40px"  class="btn btn-danger" Width="120px"/> 
   
        
        <p>
            <asp:Button ID="post" runat="server" OnClick="Button1_Click" Text="提交" Height="40px" class="btn btn-danger" Width="106px"/>
            &nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="关闭"  Height="40px"  class="btn btn-danger" Width="106px"/>
            </p>
    </form>
        </center>
</body>
</html>
