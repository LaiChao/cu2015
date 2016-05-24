﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="修改捐赠人信息.aspx.cs" Inherits="Basic201512_修改捐赠人信息" %>

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

    <title>捐赠人添加</title>

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
        /*td { text-align: center; }*/
        td { text-align: left }
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
        #nav { width: 1200px; height: 60px; line-height: 30px; }
        
       /* .body { width: 1660px; }*/
        .short_name, .energy, .meter_type, .xishu, .upper_limit { height: 24px; font-size: small; text-align: center; line-height: 24px; border: #cc9966 1px solid; }

        .energy { width: 80px; }
        .meter_type { width: 80px; }
        .xishu { width: 60px; }
        .upper_limit { width: 80px; }
        
        #divTitle { height: 60px; line-height: 60px; font-size: 26px; border: #cc9966 1px solid; text-align: center; font-weight: bold; }
        #div_dynamic {  border: #cc9966 1px solid;  }
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
    </style>
</head>
    
<body id="thebody">
    <center>
    <form id="Form1" runat="server">
    <div id="nav">
        <input type="hidden" value="0" name="ScrollPos" />
       <br />
        <label id="lblErr" runat="server"  style="color:Red" ></label>
    </div>
    <div style="height: 41px">
        <h2>
           <strong>修改捐赠人信息</strong> 

        </h2>
    </div>
    <div class="body">
        
        <div id="div_dynamic" >
        <style>
        tr{ line-height:30px;height:30px;}
        .td_c1{ width:20px;}
            .auto-style8 {
                width: 221px;
                height: 50px;
                text-align: right;
            }
            .auto-style9 {
                width: 137px;
                height: 50px;
                margin-left: 40px;
            }
            .auto-style13 {
                width: 22px;
                height: 50px;
            }
            .auto-style14 {
                width: 184px;
                height: 50px;
                text-align: right;
            }
            .auto-style15 {
                width: 183px;
                height: 50px;
                text-align: right;
            }
        </style>
           
            <table style="width: 556px" runat="server">
                <tr>
                        <td class="auto-style8">捐赠人ID：</td>
                        <td class="auto-style9">
                            <asp:Label ID="lblID" runat="server" Text="未获取到ID"></asp:Label>
                        </td> 
                    <td></td>                       
                </tr>             

                <tr>
                        <td class="auto-style8">经办单位：</td>
                        <td class="auto-style9">
                            <asp:DropDownList ID="ddlBranch" runat="server" class="btn btn-default dropdown-toggle" Width="170px">
                            </asp:DropDownList>
                        </td>    
                    <td></td>                    
                </tr>             
                <tr>

                        <td class="auto-style8">
                            捐助人类型：
                        </td>
                        <td class="auto-style9">

<%--                            <asp:CheckBox ID="Chboxgongyi" runat="server" AutoPostBack="true" OnCheckedChanged="Chboxgongyi_CheckedChanged" Text="公益组织" />
                            <asp:CheckBox ID="Chboxfaren" runat="server" AutoPostBack="True" OnCheckedChanged="Chboxfaren_CheckedChanged" Text="单位" />
                            <asp:CheckBox ID="Chboxziran" runat="server" AutoPostBack="True" OnCheckedChanged="Chboxziran_CheckedChanged" Text="个人" />
                            <asp:CheckBox ID="Chboxmojuan" runat="server" AutoPostBack="True" OnCheckedChanged="Chboxmojuan_CheckedChanged" Text="募捐箱" />
                            <asp:CheckBox ID="Chboxguanming" runat="server" AutoPostBack="True" OnCheckedChanged="Chboxguanming_CheckedChanged" Text="冠名慈善捐助金" />--%>
                            <asp:DropDownList ID="benfactorType" runat="server"  class="btn btn-default dropdown-toggle" Width="170px">
                                <asp:ListItem Value="1">公益组织</asp:ListItem>
                                <asp:ListItem Value="2">单位</asp:ListItem>
                                <asp:ListItem Value="3">个人</asp:ListItem>
                                <asp:ListItem Value="4">募捐箱</asp:ListItem>
                                <asp:ListItem Value="5">冠名慈善捐助金</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td></td>
                    </tr>          
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="Lb11" runat="server" Text="名称："></asp:Label>                      
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox runat="server" ID="benfactorName" CssClass="form-control" Width="170px"></asp:TextBox>                       
                    </td>
                    <td></td>
                </tr>
                <tr id="trSex" runat="server">
                        <td class="auto-style8">
                            <asp:Label ID="Label1" runat="server" Text="性别："></asp:Label>
                        </td>
                        <td class="auto-style9">
                            <asp:DropDownList ID="ddlSex" runat="server" class="btn btn-default dropdown-toggle">
                            <asp:ListItem>男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:DropDownList>
                        </td>    
                    <td></td>                    
                </tr>
                <tr id="trMoneyboxNo" runat="server">                      
                        <td class="auto-style8">
                            <asp:Label runat="server" Text="募捐箱编号："></asp:Label>
                        </td>
                        <td class="auto-style9">                            
                            <asp:TextBox ID="moneyboxNo" runat="server" Width="170px" CssClass="form-control" ></asp:TextBox>
                        </td>
                    <td></td>
                </tr>
                <tr id="trAge" runat="server">
                        <td class="auto-style8">
                        <asp:Label ID="lb12" runat="server" Text="年限："></asp:Label>
                            </td>
                        <td class="auto-style9">                           
                        <%--<asp:DropDownList ID="ddlAge" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAge_SelectedIndexChanged">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>--%>
                            <asp:Label ID="lblAge" runat="server"></asp:Label>
                            <asp:Button ID="btnMinus" runat="server" OnClick="btnMinus_Click" Text="-" Width="23px" />
                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="+" Width="23px" />                      
                        </td>     
                    <td></td>                   
                </tr>
                <tr id="trDeadline" runat="server">
                        <td class="auto-style8">
                        <asp:Label runat="server" Text="到期日期："></asp:Label>
                           </td>
                        <td class="auto-style9">
                        <asp:Label ID="deadline" runat="server" Text="日期"></asp:Label>
                            </td>    
                    <td></td>
                </tr>
                <tr id="trContact" runat="server">
                    <td class="auto-style8">
                        <asp:Label ID="lb23" runat="server" Text="联系人姓名："></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="Contacts" runat="server" CssClass="form-control" Width="170px"></asp:TextBox>

                    </td>
                    <td></td>
                </tr>

                <tr>
                        <td class="auto-style8">
                        <asp:Label ID="lb24" runat="server" Text="手机号："></asp:Label>
                            </td>
                        <td class="auto-style9">                      
                            <asp:TextBox ID="TEL" runat="server" CssClass="form-control" Width="170px" MaxLength="11"></asp:TextBox>                          
                        </td>     
                    <td></td>                   
                </tr>

                <tr>
                    <td class="auto-style8">
                       <asp:Label ID="Lb33" runat="server" Text="电子邮箱："></asp:Label>
                        
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox MaxLength="20" runat="server" ID="email"  CssClass="form-control" Width="170px"></asp:TextBox>
                    </td>
                    <td></td>
                    
                </tr>

                
                
            </table>
            <table id="tbDirect"  style="width: 556px" runat="server" class="form-inline">
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="Lb44" runat="server" Text="是否定向捐赠："></asp:Label>
                      
                    </td>
                    <td class="auto-style9">
                        <div class="form-group">
                        <asp:RadioButton ID="rdbDirect" runat="server" AutoPostBack="True" GroupName="rdoDirect" OnCheckedChanged="rdoDirect_CheckedChanged" Text="是" CssClass="checkbox" />
                        <asp:RadioButton ID="rdbUndirect" runat="server" AutoPostBack="True" GroupName="rdoDirect" Text="否" OnCheckedChanged="rdoDirect_CheckedChanged" CssClass="checkbox" />
                         </div>
                             </td>
                    <td></td>
                    
                </tr>
                <tr id="trRcpType" runat="server">
                    <td class="auto-style8">
                        <asp:Label ID="Lb66" runat="server" Text="受助人类型："></asp:Label>
                    </td>
                    <td class="auto-style9">
                            <asp:DropDownList ID="recipientsType" runat="server" class="btn btn-default dropdown-toggle" Width="170px">
                                <asp:ListItem>助学</asp:ListItem>
                                <asp:ListItem>助医</asp:ListItem>
                                <asp:ListItem>助残</asp:ListItem>
                                <asp:ListItem>助老</asp:ListItem>
                                <asp:ListItem>助困</asp:ListItem>
                                <asp:ListItem>双拥</asp:ListItem>
                                <asp:ListItem>重特大灾难</asp:ListItem>
                            </asp:DropDownList>                    
                    </td>
                    <td></td>
                </tr>
            </table>

            <table id="tbNaming"  style="width: 556px" runat="server" class="form-inline">


                <tr id="trNaming" runat="server">
                  
                    <td class="auto-style8">
                        <asp:Label ID="Lb55" runat="server" Text="是否冠名捐助："></asp:Label>             
                    </td>
                    <td class="auto-style9"    >
                        <div class="form-group">
                        <asp:RadioButton ID="rdbNaming" runat="server" Text="是" AutoPostBack="True" GroupName="rdoNaming" OnCheckedChanged="rdoNaming_CheckedChanged" CssClass="checkbox" />
                        <asp:RadioButton ID="rdbUnNaming" runat="server" Text="否" AutoPostBack="True" GroupName="rdoNaming" OnCheckedChanged="rdoNaming_CheckedChanged" CssClass="checkbox" />                                        
                            </div>
                    </td>  
                      <td></td>               
                    </tr>
                <tr id="trFundName" runat="server">
                    <td class="auto-style8">
                        <asp:Label ID="lb61" runat="server" Text="冠名慈善捐助金名称："></asp:Label>
                    </td>
                    <td class="auto-style9">                        
                        <asp:DropDownList ID="ddlNaming" runat="server" class="btn btn-default dropdown-toggle" Width="170px">
                        </asp:DropDownList>                        
                        <br />
                        </td>
                    <td></td>
                </tr>

                

            </table>
            <table  style="width: 556px" runat="server">
                    <tr>
                       <td class="auto-style8"> 
                            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="返回" CssClass=" btn btn-danger" Width="80px" Height="34px" />
                            <asp:Button ID="Btinput" runat="server" OnClick="Btinput_Click" Text="提交修改" CssClass=" btn btn-danger" Width="80px" Height="34px" />
                        </td>
                        <td class="auto-style9">
                       <asp:Label ID="labError" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>          
                        <td></td>                               
                    </tr>

            </table>
      </div>  
    </div>
    </form>
    </center>
</body>
</html>
