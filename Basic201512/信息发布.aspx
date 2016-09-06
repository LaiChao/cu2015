<%@ Page Language="C#" AutoEventWireup="true" CodeFile="信息发布.aspx.cs" Inherits="Basic201512_信息发布" %>
<%@ Register Assembly="DevControl" Namespace="DevControl" TagPrefix="Dev" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="../../favicon.ico" />

    <title>信息发布</title>

    <!-- Bootstrap core CSS -->
    <%--<script src="../Content/bootstrap.min.css"></script>--%>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
   <%-- <link href="../../dist/css/bootstrap-theme.min.css" rel="stylesheet">--%>
  <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="theme.css" rel="stylesheet" />

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="../../assets/js/ie-emulation-modes-warning.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>

    <style type="text/css">
        #form1 {
            width: 1000px;
        }
        div#row1{
            float:left;
        }
        div#row2{
            float:left;
            margin-left: 17px;
            height: 54px;
        }
        .divtitle {
            text-align:left;
        }
        .clas1 {
            /*width: 100px;*/
            font-size: 15px;
            text-align: right;
            font-family: 'Microsoft YaHei';        

        }
        .clas2 {
            display:inline;      
        }
        .clas3 {
        display:block;
        
        }
        .lbError
        {
            height:30px; 
            line-height:30px
        }
        .checkbox_style {
            font-family: 'Microsoft YaHei';
        }
        .labError_style {
            text-align: right;
            font-family: 'Microsoft YaHei';
            font-size: 15px;
            color: #e8a1eb
        }
        .listItem_style {
            font-size: 16px;
            font-family: 'Microsoft YaHei';
        }
    </style>

</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline" role="form">
    
    <div id="divtitle">
        <h2>
           <strong>重要信息发布</strong> 
        </h2>
    </div>  
    <div id="divfrom" style="text-align:left">         
        <div id="row1" class="form-group">
            <asp:Label ID="Label3" runat="server" Text="收件人：" CssClass="clas1" Width="72px"></asp:Label>           
            <asp:DropDownList ID="DropDownList1" runat="server" class="btn btn-default dropdown-toggle listItem_style" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>所有机构</asp:ListItem>
            <asp:ListItem>选择机构</asp:ListItem>
            </asp:DropDownList>      
        </div>
        <div id="row2">
            <Dev:DropDownCheckBoxList ID="DropDownCheckBoxList1" runat="server" ShowSelectAllOption="true" DisplayMode="Value" Width="200px" Height="30px">
            </Dev:DropDownCheckBoxList>
            <asp:CheckBox ID="CheckBox1" runat="server" CssClass="checkbox checkbox_style" AutoPostBack="True" Text="公共项目" Font-Size="12pt" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>

        </div>
        <br/><br/><br/>
        <div id="publicProject" runat="server" class="form-group">      
            <asp:Label ID="Label5" runat="server" Text="项目ID："  CssClass="clas1" Width="72px"></asp:Label>
            <asp:TextBox ID="tbID" runat="server" class="form-control" Width="900px"></asp:TextBox>  
            <br /><br />                              
        </div>
        
            <%--<asp:Label ID="Label1" runat="server" Text="标题"></asp:Label>--%>
        <div class="form-group">
            <asp:Label ID="Lbtitle" runat="server" Text="标&nbsp;&nbsp;&nbsp;题：" CssClass="clas1" Width="72px"></asp:Label>
            <asp:TextBox ID="infoTitle" runat="server" Width="900px" class="form-control" ></asp:TextBox>                                      
        </div>
        <br /><br />
        <div class="form-group">  
            <asp:Label ID="Label2" runat="server" Text="内&nbsp;&nbsp;&nbsp;容：" CssClass="clas1" Width="72px"></asp:Label> 
            <asp:TextBox ID="infoContent" runat="server" Height="200px" TextMode="MultiLine" Width="900px" class="form-control"></asp:TextBox>            
        </div> 
            <br />
            <br />
        <div>
            <div class="form-group" style="display:inline" > 
                <asp:Label ID="Label4" runat="server" Text="附&nbsp;&nbsp;&nbsp;件：" CssClass="clas1" Width="72px"></asp:Label>
                <asp:ListBox ID="ListBox1" runat="server" Width="396px" class="form-control" placeholder="文件列表" >
                <asp:ListItem  text="文件列表"></asp:ListItem>
                </asp:ListBox>
            </div> 
            <div style="display:inline">                 
                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control clas3" Width="229px" Height="42px"/>                 
                <asp:Button ID="Button3" runat="server" Text="上传" onclick="Button3_Click" Height="34px"  class="btn btn-danger clas2" Width="80px"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
        </div> 
        <br />   
        <div id="row3" class="form-group lbError" >
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblError" class="labError_style" runat="server" ForeColor="Red" Font-Size="11pt" Height="30px"></asp:Label>                       
        </div>               
        <div style="text-align:center"> 
            <asp:Button ID="post" runat="server" OnClick="Button1_Click" Text="发布" class="btn btn-danger" Height="34px" Width="80px" />  
        </div>    
    </div>     
    </form>
    </center>
</body>
</html>
