<%@ Page Language="c#" Inherits="CL.Utility.Web.BasicData.Register" CodeFile="用户修改密码_v.aspx.cs" %>

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
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>用户</title>

    <!-- Bootstrap core CSS -->
     <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
   <%-- <link href="../../dist/css/bootstrap-theme.min.css" rel="stylesheet">--%>
     <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="theme.css" rel="stylesheet">

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script type="text/javascript" src="../../assets/js/ie-emulation-modes-warning.js"></script>
    <style type="text/css">
        tr { padding: 0; margin: 0; border: 0; }
        td { text-align: center;height:50px }
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
    </style>
    <%--<script language="javascript">
        var currentFocus;
        var currentScrollTop;
        window.onload = function () {
            document.all.item('div_dynamic').scrollTop = currentScrollTop;
            var ctl;
        }

    </script>--%>
    <style type="text/css">
        #nav { width: 550px; height: 60px; line-height: 30px; }
        
        /*.body { width: 1000px; }*/
        .short_name, .energy, .meter_type, .xishu, .upper_limit { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }

        .energy { width: 80px; }
        .meter_type { width: 80px; }
        .xishu { width: 60px; }
        .upper_limit { width: 80px; }
        
        #divTitle { height: 60px; line-height: 60px; font-size: 26px; border: #cc9966 0px solid; text-align: center; font-weight: bold; }
        #div_dynamic { height: 400px; border: #cc9966 0px solid; text-align:center; }
        #divTitle, #div_dynamic { width: 550px; margin:0 auto; }
        .option, .id, .name, .order, .state, .description, .area { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }
        .option { width: 50px; }
        .data_Id { width: 130px; }
        .name { width: 170px; }
        .data_Index { width: 170px; }
        .state { width: 60px; }
        .description { width: 200px; }
        .txtbox { width: 95%; padding: 0; margin: 0; }
        .area { width: 100px; }
        tr{ line-height:30px;height:30px;}
        .auto-style10 {
            width: 100px;
            font-size: 16px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        }
        .auto-style11 {
            height: 50px;
        }
        .auto-style12 {
           width: 300px;
            text-align: left;
        }
        .textbox_style {
            width: 340px;
        }
        .labError_style {
            text-align: left;
            font-family: 'Microsoft YaHei';
            font-size: 15px;
        }
    </style>
</head>
<body id="thebody" align="left">
    <form id="Form1" method="post" runat="server">
        <center>
            <div class="body">
                <div runat="server">
                    <h2>
                        <strong>用户信息管理</strong>

                    </h2>
                </div>
                <div id="div_dynamic">
                    <table align="center" width="550px">
                        <tr>
                            <td class="auto-style10">用&nbsp;户&nbsp;名：&nbsp;</td>
                            <td class="auto-style12">
                                <asp:TextBox runat="server" ID="txtID" class="form-control textbox_style" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style10">姓&nbsp;&nbsp;名：&nbsp;
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox runat="server" ID="txtName" class="form-control textbox_style textbox_style"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>

                            <td class="auto-style10">联系方式：&nbsp;
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox ID="TEL" runat="server" class="form-control textbox_style"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>

                            <td class="auto-style10">旧&nbsp;密&nbsp;码：&nbsp;
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox runat="server" MaxLength="20" ID="txtPWDOld" TextMode="Password" class="form-control textbox_style"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>

                            <td class="auto-style10">新&nbsp;密&nbsp;码：&nbsp;
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox runat="server" MaxLength="20" ID="txtPWD" TextMode="Password" class="form-control textbox_style" placeholder="5~20位由数字、英文字母或下划线组成"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>

                            <td class="auto-style10">确认新密码：&nbsp;
                            </td>
                            <td>
                                <asp:TextBox runat="server" MaxLength="20" ID="txtPWD2" TextMode="Password" class="form-control textbox_style"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="labError_style">
                                <asp:Label ID="labError" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:Button runat="server" ID="submit" Text="确认修改" OnClick="submit_Click" class="btn btn-danger" Width="80px" Height="34px" />
                </div>
            </div>
        </center>
    </form>
</body>
</html>
