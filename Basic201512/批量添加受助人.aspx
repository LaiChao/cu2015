<%@ Page Language="C#" AutoEventWireup="true" CodeFile="批量添加受助人.aspx.cs" Inherits="Basic201512_批量添加受助人" %>

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

    <title>批量添加受助人</title>

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
        .clas1 {
            font-size: 15px;
            text-align: right;
            font-family: 'Microsoft YaHei';        
        }
        .auto-style1 {
            width: 300px;
            text-align: left;
        }
        .auto-style2 {
            width: 150px;
            font-size: 16px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        }
        .div_style {
            width:500px;
         text-align:left;
        }
        tr {
            display:block;
            margin: 10px 0;
        }
        .abc{
            margin: 0 auto;
            width: 720px;
            border: 1px solid;
            border-style: dashed;
            text-align: left;
        }
    </style>

</head>
<body>
    <center>
    <form id="form1" runat="server">
        <div>
            <h2><strong>批量添加受助人</strong></h2>
        </div>
        <div class="div_style">
            <table>
                <tr id="divid" runat="server">
                    <td class="auto-style2">项目ID：&nbsp;</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tbID" runat="server" class="form-control" Height="31px" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">请选择Excel文件：</td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" Width="300px" Height="45px" />
                    </td>
                <br />
                </tr>
            </table>
        </div>
        <br />            
        <asp:Button ID="btnImport" runat="server" OnClick="btnImport_Click" Text="提&nbsp;交" class="btn btn-danger" Width="100px"/>
        <br /><br />
		<div style="width: 923px; font-family: 'Microsoft YaHei'; font-size: 16px; color: red;" class="abc">
                注意事项：
         <br />1、批量添加受助人的模板，需要从QQ群文件中下载。
        <br />2、模板中的第一列“受助人来源”，要与系统平台中的“用户与机构管理”模块中的“经办单位”名称一致。
        <br />3、模板中的“身份证号”一列，如果最后一位为X，一定要大写。
        <br />4、在模板中带有“是否...”的一列，“是”要填写“1”，“否”要填写“0”。如果填“1”，则对应一列的后面相关列要填写。
        </div>         
    </form>
    </center>
</body>
</html>
