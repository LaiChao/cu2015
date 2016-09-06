<%@ Page Language="c#" Inherits="CL.Utility.Web.BasicData.Register" CodeFile="资金录入副本.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>用户</title>
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

    <title>资金录入</title>

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
        //window.onload = function () {
        //    document.all.item('div_dynamic').scrollTop = currentScrollTop;
        //    var ctl;
        //}
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
        function openform(theURL,winName,features) {
           // newwin = window.showModalDialog(theURL, winName, features);
            newwin = window.showModalDialog(theURL,winName,features);
        }
        function tdisplay()
        {
            document.getElementById("Panel2").style.visibility = true;
        }
       
    </script>
    
    <style type="text/css">
        #nav { width: 1200px; height: 60px; line-height: 30px;
            text-align: center;
        }
        
       /* .body { width: 1660px; }*/
        .short_name, .energy, .meter_type, .xishu, .upper_limit { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }

        .energy { width: 80px; }
        .meter_type { width: 80px; }
        .xishu { width: 60px; }
        .upper_limit { width: 80px; }
        
        #divTitle { height: 60px; line-height: 60px; font-size: 26px; border: #cc9966 0px solid; text-align: center; font-weight: bold; }
        #div_dynamic {  border: #cc9966 0px solid;  }
        #divTitle, #div_dynamic { width: 800px; margin:0 auto; }
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
        .td_c1{ width:20px;}

         .auto-style13 {
             width: 170px;
             font-size: 16px;
             text-align: right;
             font-family: 'Microsoft YaHei';
         }
         .auto-style14 {
             height: 50px;
             margin-left: 40px;
             vertical-align: middle;
             text-align: left;
         }
         .textBox_style {
            width: 300px !important;
         }
         .labError_style {
            text-align: left;
            font-family: 'Microsoft YaHei';
            font-size: 15px;
            color: #e8a1eb;
            height: 50px;
        }
    </style>
</head>
    
<body id="thebody">
    <center>
    <form id="Form1" method="post" runat="server" onsubmit="ck2()">
        <input type="hidden" value="0" name="ScrollPos" />
        <div >
        
   <h2>
      <strong>资金录入</strong> 
   </h2>     
    </div>
    <div class="body">       
        <div id="div_dynamic" >         
            <table style="width: 550px" align="center">
                <tr>
                    <td class="auto-style13">捐赠人名称：&nbsp;</td>
                    <td class="auto-style14">
                        <asp:TextBox runat="server" ID="LbproID" CssClass="form-control textBox_style" ReadOnly="true"></asp:TextBox>
                    </td>                       
                </tr>
                <tr>
                    <td class="auto-style13">所&nbsp;属&nbsp;机&nbsp;构：&nbsp;</td>
                    <td class="auto-style14">
                        <asp:TextBox runat="server" ID="lblBranch" CssClass="form-control textBox_style" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">联&nbsp;系&nbsp;方&nbsp;式：&nbsp; </td>
                    <td class="auto-style14">
                        <asp:TextBox runat="server" ID="lbbenfnadd" CssClass="form-control textBox_style" ReadOnly="true"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style13">资&nbsp;金&nbsp;ID：&nbsp; </td>
                    <td class="auto-style14">
                        <asp:TextBox runat="server" ID="lbcaptID" CssClass="form-control textBox_style" ReadOnly="true"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style13">已&nbsp;有&nbsp;资&nbsp;金：&nbsp; </td>
                    <td class="auto-style14">
                        <asp:TextBox runat="server" ID="lbcaptIDown" CssClass="form-control textBox_style" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">录&nbsp;入&nbsp;资&nbsp;金：&nbsp; </td>
                    <td class="auto-style14">
                        <asp:TextBox MaxLength="20" runat="server" ID="txtPLAN" CssClass="form-control textBox_style"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">资金录入时间：&nbsp; </td>
                    <td class="auto-style14">
                        <asp:TextBox runat="server" ID="lbtime" CssClass="form-control textBox_style" ReadOnly="true"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style13">
                        </td>
                    <td class="labError_style">
                        <asp:Label ID="lblErr" runat="server" ForeColor="Red" align="center" Text="" style="text-align: center"></asp:Label>                   
                    </td>
                </tr>
            </table>
            <div>
                <asp:Button ID="btnCancel" runat="server" Text="撤回" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                <asp:Button ID="btyes" runat="server" Text="添加资金" OnClick="btyes_Click" CssClass=" btn btn-danger" Width="120px"/>&nbsp;&nbsp;
                <asp:Button ID="confirm" runat="server" Text="确认添加" OnClick="confirm_Click" CssClass=" btn btn-danger" Width="120px"/>
            </div>
        </div>
    </div>
    </form>
    </center>
</body>
</html>
