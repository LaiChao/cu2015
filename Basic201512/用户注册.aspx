<%@ Page Language="c#" Inherits="CL.Utility.Web.BasicData.Register" CodeFile="用户注册.aspx.cs" %>

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
    <script src="../../assets/js/ie-emulation-modes-warning.js"></script>
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
    <script language="javascript" type="text/javascript">
        var currentFocus;
        var currentScrollTop;
        window.onload = function () {
            document.all.item('div_dynamic').scrollTop = currentScrollTop;
            var ctl;
        }
        function ck() {
            var txt = document.getElementById("txtID").value;
            var txtpwd = document.getElementById("txtPWD");
            var lblerr = document.getElementById("lblErr");
           // alert(lblerr.innerText);
            //alert(isNumberOr_Letter(txt));

            if (isNumberOr_Letter(txt)) {
                lblerr.innerText = "用户名正常";
                //txtpwd.value = "用户名正常";
                document.getElementById("Form1").submit();
                alert(11);
            }
            else {
                lblerr.innerText = "用户名不正常";
                //txtpwd.value = "用户名不正常";
            }
        }
        function ck2() {
            txtpwd.value = "用户名正常";
         }
        function isNumberOr_Letter(s) {//判断是否是数字或字母 

            var regu = "^[0-9a-zA-Z\_]{5,15}$";
            var re = new RegExp(regu);
            if (re.test(s)) {
                return true;
            } else {
                return false;
            }
        } 
    </script>
    <style type="text/css">
        #nav { width: 1000px; height: 60px; line-height: 30px; }
        
       /* .body { width: 1660px; }*/
        .short_name, .energy, .meter_type, .xishu, .upper_limit { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }

        .energy { width: 80px; }
        .meter_type { width: 80px; }
        .xishu { width: 60px; }
        .upper_limit { width: 80px; }
        
        #divTitle { height: 60px; line-height: 60px; font-size: 26px; border: #cc9966 0px solid; text-align: center; font-weight: bold; }
        #div_dynamic { height: 450px; border:#e8a1eb 0px solid; text-align:center;  }
        #divTitle, #div_dynamic { width: 650px; margin:0 auto; }
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
        .td_c1{ width:50px;}
        .auto-style1 {
            width: 300px;
            text-align: left;
        }
        .auto-style2 {
            width: 100px;
            font-size: 16px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        }
        .auto-style5 {
            width: 300px;
            height: 50px;
            text-align:left;
        }
        .textbox_style {
            width: 340px;
        }
        .labError_style {
            text-align: left;
            font-family: 'Microsoft YaHei';
            font-size: 15px;
            color: #e8a1eb
        }
    </style>
</head>
<body id="thebody">
    <form id="Form1" method="post" runat="server" onsubmit="ck2()">
        <center>
            <div class="body">
                <div runat="server">
                    <h2>
                        <strong>用户注册</strong>

                    </h2>
                </div>
                <div id="div_dynamic">
                    <table align="center" width="550px">
                        <tr>
                            <td class="auto-style2">用&nbsp;户&nbsp;名：&nbsp;</td>
                            <td class="auto-style1">
                                <asp:TextBox runat="server" MaxLength="8" ID="txtID" class="form-control textbox_style" Height="31px" placeholder="5~8位由数字、英文字母或下划线组成，不可更改"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">姓&nbsp;&nbsp;名：&nbsp;
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox MaxLength="20" runat="server" class="form-control textbox_style" ID="txtName" placeholder="请输入您的姓名"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>

                            <td class="auto-style2">所属机构：&nbsp;
                            </td>
                            <td class="auto-style5">
                                <asp:DropDownList ID="benfactorFrom" runat="server" class="btn btn-default dropdown-toggle" Width="340px">
                                </asp:DropDownList>
                            </td>

                        </tr>
                        <tr>

                            <td class="auto-style2">联系方式：&nbsp;
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="TEL" runat="server" class="form-control textbox_style" placeholder="请输入您的联系方式"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>

                            <td class="auto-style2">密&nbsp;&nbsp;码：&nbsp;
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox MaxLength="20" runat="server" ID="txtPWD" TextMode="Password" class="form-control textbox_style" placeholder="5~20位由数字、英文字母或下划线组成"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>

                            <td class="auto-style2">确认密码：&nbsp;
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox runat="server" ID="txtPWD2" MaxLength="20" TextMode="Password" class="form-control textbox_style" placeholder="再次确认您的密码"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td></td>
                            <td class="labError_style">
                                <asp:Label ID="labError" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>

                        <tfoot>
                        </tfoot>
                    </table>
                    <asp:Button runat="server" ID="btyes" class="btn btn-danger" Text="确认" OnClick="btyes_Click" Width="80px" Height="34px" align="center" />
                </div>
            </div>
        </center>
    </form>
</body>
</html>
