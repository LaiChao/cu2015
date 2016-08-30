<%@ Page Language="C#" AutoEventWireup="true" CodeFile="添加受助人.aspx.cs" Inherits="Basic201512_添加受助人" %>

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

    <title>添加受助人</title>

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
        .auto-style1 {
            width: 13px;
        }
        .auto-style2 {
            width:141px;
            text-align:right;
            font-family:'Microsoft YaHei';
            height:45px;
        }
        #Button2 {
            text-align: left;
        }
        .auto-style3 {
            width: 13px;
            height: 48px;
        }
        .auto-style5 {
            height: 48px;
        }
    </style>
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <script language="javascript">
        <!--
        //function openwin(url,name,iWidth,iHeight)
        //{
        //    var url; //转向网页的地址;
        //    var name; //网页名称，可为空;
        //    var iWidth; //弹出窗口的宽度;
        //    var iHeight; //弹出窗口的高度;
        //    var iTop = (window.screen.height-30-iHeight)/2; //获得窗口的垂直位置;  
        //    var iLeft = (window.screen.width-10-iWidth)/2; //获得窗口的水平位置; 
        //    window.open(url,name,'height='+iHeight+',,innerHeight='+iHeight+',width='+iWidth+',innerWidth='+iWidth+',top='+iTop+',left='+iLeft+',toolbar=no,menubar=no,scrollbars=auto,resizeable=no,location=no,status=no, alwaysRaised=yes');
        //}
        function openform(theURL, winName, features) {
            // newwin = window.showModalDialog(theURL, winName, features);
            newwin = window.showModalDialog(theURL, winName, features);
        }
        //-->
    </script>
</head>
<body>
    <center>
    <form id="form1" runat="server" class="form-inline"> 
        <div style="height: 41px">
    
        <h2>
           <strong>添加受助人</strong> 

        </h2>
        </div>
    <div style="height: 47px">
    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="选择受助类别："></asp:Label>
        <asp:CheckBox ID="CheckBox2" runat="server" Text="助医" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" Font-Names="Microsoft YaHei" Font-Bold="false" CssClass="checkbox"/>
        <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="助学" AutoPostBack="True" Font-Names="Microsoft YaHei" Font-Bold="false" CssClass="checkbox"/>
        <asp:CheckBox ID="CheckBox4" runat="server" Text="助老" AutoPostBack="True" OnCheckedChanged="CheckBox4_CheckedChanged" Font-Names="Microsoft YaHei" Font-Bold="false" CssClass="checkbox"/>
        <asp:CheckBox ID="CheckBox3" runat="server" Text="助残" AutoPostBack="True" OnCheckedChanged="CheckBox3_CheckedChanged" Font-Names="Microsoft YaHei" Font-Bold="false" CssClass="checkbox"/>
        <asp:CheckBox ID="CheckBox5" runat="server" Text="助困" AutoPostBack="True" OnCheckedChanged="CheckBox5_CheckedChanged" Font-Names="Microsoft YaHei" Font-Bold="false" CssClass="checkbox"/>    
        <asp:CheckBox ID="CheckBox6" runat="server" AutoPostBack="True" Text="双拥" OnCheckedChanged="CheckBox6_CheckedChanged" Font-Names="Microsoft YaHei" CssClass="checkbox" />
        <asp:CheckBox ID="CheckBox7" runat="server" AutoPostBack="True" Text="重特大灾害" OnCheckedChanged="CheckBox7_CheckedChanged" Font-Names="Microsoft YaHei" CssClass="checkbox"/>
    </div>
    </div>
    <div style="height: 1312px; width: 806px;">
        <div class="panel panel-danger">
            <div class="panel-heading">
              <h3 class="panel-title" align="left">基本信息</h3>
            </div>
            <div class="panel-body" ScrollBars="Auto">
             <table style="width: 90%; height: 155px; margin-right: 116px;">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        受助人来源：</td>
                    <td>
                        <asp:DropDownList ID="benfactorFrom" runat="server" class="btn btn-default dropdown-toggle">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        受助人户籍：</td>
                    <td>
                        <asp:TextBox ID="recipientsADD" runat="server" class="form-control"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        受助人姓名：</td>
                    <td>
                        <asp:TextBox ID="recipientsName" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        性别：</td>
                    <td>
                        <asp:DropDownList ID="sex" runat="server" class="btn btn-default dropdown-toggle">
                            <asp:ListItem>男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:DropDownList>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        身份证号：</td>
                    <td>
                        <asp:TextBox ID="recipientsPIdcard" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        现住址：</td>
                    <td>
                        <asp:TextBox ID="recipientsADDnow" runat="server" class="form-control"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        低保低收入号：</td>
                    <td>
                        <asp:TextBox ID="incomlowID" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        联系电话：</td>
                    <td>
                        <asp:TextBox ID="telphoneADD" runat="server" class="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        工作单位：</td>
                    <td>
                        <asp:TextBox ID="workplace" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        平均月收入：</td>
                    <td>
                        <asp:TextBox ID="arrIncome" runat="server" class="form-control"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style2">
                        婚姻状况：</td>
                    <td>
                        <asp:DropDownList ID="marryNow" runat="server" class="btn btn-default dropdown-toggle">
                            <asp:ListItem>未婚</asp:ListItem>
                            <asp:ListItem>已婚</asp:ListItem>
                            <asp:ListItem>离异</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        致困原因：</td>
                    <td>
                        <asp:DropDownList ID="reason" runat="server" class="btn btn-default dropdown-toggle">
                            <asp:ListItem Value="无">无</asp:ListItem>
                            <asp:ListItem>低保</asp:ListItem>
                            <asp:ListItem>低收入</asp:ListItem>
                            <asp:ListItem>其他</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="familylist" style=" border:0px none" runat="server" Height="18px" OnClick="familylist_Click" Text="+" Width="17px" />
                    </td>
                    <td class="auto-style2">
                        家庭成员列表</td>
                    <td>
                    
                        &nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        </td>
                    <td>
                    
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        家庭成员姓名1：</td>
                    <td>
                        <asp:TextBox ID="famName1" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1"></td>
                    <td class="auto-style2">
                        与本人关系1：</td>
                    <td>
                        <asp:TextBox ID="famRelation1" runat="server" class="form-control"></asp:TextBox>
                    </td>
                
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员工作单位1：</td>
                    <td>
                        <asp:TextBox ID="famWorkplace1" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员联系方式1：</td>
                    <td>
                        <asp:TextBox ID="famTel1" runat="server" class="form-control"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员职业1：</td>
                    <td>
                        <asp:TextBox ID="famWork1" runat="server" class="form-control"> </asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员收入：</td>
                    <td>
                        <asp:TextBox ID="famIncome1" runat="server" class="form-control"></asp:TextBox>
                    </td>
 
                </tr>

                </table>
            <table style="width: 90%; height: 155px; margin-right: 116px;" id="tablefamily" runat="server">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        家庭成员姓名2：</td>
                    <td>
                        <asp:TextBox ID="famName2" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        与本人关系2：</td>
                    <td>
                        <asp:TextBox ID="famRelation2" runat="server" class="form-control"></asp:TextBox>
                    </td>
 
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员工作单位2：</td>
                    <td>
                        <asp:TextBox ID="famWorkplace2" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员联系方式2：</td>
                    <td>
                        <asp:TextBox ID="famTel2" runat="server" class="form-control"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员职业2：</td>
                    <td>
                        <asp:TextBox ID="famWork2" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员收入2：</td>
                    <td>
                        <asp:TextBox ID="famIncome2" runat="server" class="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员姓名3：</td>
                    <td>
                        <asp:TextBox ID="famName3" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        与本人关系3：</td>
                    <td>
                        <asp:TextBox ID="famRelation3" runat="server" class="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员工作单位3：</td>
                    <td>
                        <asp:TextBox ID="famWorkplace3" runat="server"  class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员联系方式3：</td>
                    <td>
                        <asp:TextBox ID="famTel3" runat="server" class="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员职业3：</td>
                    <td>
                        <asp:TextBox ID="famWork3" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员收入3：</td>
                    <td>
                        <asp:TextBox ID="famIncome3" runat="server" class="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        家庭成员姓名4：</td>
                    <td>
                        <asp:TextBox ID="famName4" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        与本人关系4：</td>
                    <td>
                        <asp:TextBox ID="famRelation4" runat="server" class="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员工作单位4：</td>
                    <td>
                        <asp:TextBox ID="famWorkplace4" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员联系方式4：</td>
                    <td>
                        <asp:TextBox ID="famTel4" runat="server" class="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员职业4：</td>
                    <td>
                        <asp:TextBox ID="famWork4" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        成员收入4：</td>
                    <td>
                        <asp:TextBox ID="famIncome4" runat="server" class="form-control"></asp:TextBox>
                    </td>
                </tr>
            </table>
            </div>
          </div>
            <%--<asp:Panel ID="Panel2" runat="server" BorderColor="Black" Height="321px" Width="806px" GroupingText="基本信息" ScrollBars="Auto">
            
            
            </asp:Panel>--%>
        <div class="panel panel-danger">
            <div class="panel-heading">
              <h3 class="panel-title" align="left">其他信息</h3>
            </div>
            <div class="panel-body">
             <table style="width: 90%; height: 155px; margin-right: 116px;" runat="server">
            <tr id="trstu1">
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    就读学校：</td>
                <td>
                    <asp:TextBox runat="server" ID="studySchool" class="form-control"></asp:TextBox>
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    就读年级：</td>
                <td>
                    <asp:TextBox ID="studyGrade" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr id="trstu2">
                 <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    监护人姓名：</td>
                <td>
                    <asp:TextBox ID="guardianName" runat="server" class="form-control"></asp:TextBox>
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    与被监护人关系：</td>
                <td>
                    <asp:TextBox ID="guardianGuanxi" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr id="trstu3">
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    监护人电话：</td>
                <td>
                    <asp:TextBox ID="guardianTelADD" runat="server" class="form-control"></asp:TextBox>
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    助学说明：</td>
                <td>
                    <asp:TextBox ID="shuoming2" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
<%--            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    </td>
                <td>
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    </td>
                <td>
                </td>
            </tr>--%>
            <tr id="trdoc1">
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    大病种类：</td>
                <td>
                    <asp:TextBox ID="illness" runat="server" class="form-control"></asp:TextBox>
                </td>


                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    就诊时间：</td>
                <td>
                    <asp:TextBox ID="illtime" runat="server" onClick="WdatePicker()" class="form-control" ></asp:TextBox><%--<input class="Wdate" type="text" onClick="WdatePicker()"><font color=red>&lt;- 点我弹出日期控件</font>--%> 
                </td>
            </tr>
            <tr id="trdoc2">
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    花费数额：</td>
                <td>
                    <asp:TextBox ID="illpay" runat="server" class="form-control"></asp:TextBox>
                </td>


                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    助医说明：</td>
                <td>
                    <asp:TextBox ID="shuoming1" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
<%--            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    </td>
                <td>
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    </td>
                <td>
                </td>
            </tr>--%>
            <tr id="trcan1">
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    残疾级别：</td>
                <td>
                    <asp:TextBox ID="canjijibie" runat="server" class="form-control"></asp:TextBox>
                </td>


                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    残疾类别：</td>
                <td>
                    <asp:TextBox ID="canjileibie" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr id="trcan2">
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    残疾人证号：</td>
                <td>
                    <asp:TextBox ID="canjiID" runat="server" class="form-control"></asp:TextBox>
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    助残说明：</td>
                <td>
                    <asp:TextBox ID="shuoming3" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
<%--            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    </td>
                <td>
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    </td>
                <td>
                </td>
            </tr>--%>
            <tr id="trold">
                                                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    是否失能：</td>
                <td>
                    <asp:DropDownList ID="shiNeng" runat="server" class="btn btn-default dropdown-toggle">
                        <asp:ListItem>否</asp:ListItem>
                        <asp:ListItem>半失能</asp:ListItem>
                        <asp:ListItem>全失能</asp:ListItem>
                    </asp:DropDownList>
                </td>

               <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    助老说明：</td>
                <td>
                    <asp:TextBox ID="shuoming4" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
<%--            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    </td>
                <td>
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    </td>
                <td>
                </td>
            </tr>--%>
            <tr id="trkun1">
                <td class="auto-style3"></td>
                <td class="auto-style2">
                    临时说明：</td>
                <td class="auto-style5">
                    <asp:TextBox ID="timeDis" runat="server" class="form-control"></asp:TextBox>
                </td>
               <td class="auto-style3"></td>
                <td class="auto-style2">
                    是否失独：</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="shiDu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="shiDu_SelectedIndexChanged" class="btn btn-default dropdown-toggle">
                        <asp:ListItem>否</asp:ListItem>
                        <asp:ListItem>是</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trkun2">
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    子女姓名：</td>
                <td>
                    <asp:TextBox ID="sonName" runat="server" class="form-control"></asp:TextBox>
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    死亡原因：</td>
                <td>
                    <asp:TextBox ID="deathReason" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr id="trkun3">
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    助困说明：</td>
                <td>
                    <asp:TextBox ID="shuoming5" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>

            <tr id="tryong1">
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    部队名称：</td>
                <td>
                    
                    <asp:TextBox ID="army" runat="server" class="form-control"></asp:TextBox>
                    
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    职位：</td>
                <td>
                    
                    <asp:TextBox ID="title" runat="server" class="form-control"></asp:TextBox>
                    
                </td>
            </tr>
            <tr id="tryong2">
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    军官证号：</td>
                <td>
                    <asp:TextBox ID="tbOfficerID" runat="server" class="form-control"></asp:TextBox>
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    </td>
                <td>
                </td>
            </tr>
            <tr id="trdst">
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    灾害名称：</td>
                <td>
                    
                    <asp:TextBox ID="disaster" runat="server" class="form-control"></asp:TextBox>
                    
                </td>
            </tr>
<%--            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    </td>
                <td>
                </td>

                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    </td>
                <td>
                </td>
            </tr>--%>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提交" class="btn btn-danger"/>
                    
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="批量添加受助人：" style="text-align: right"></asp:Label>
                </td>
                <td>                
                    <%--<input id="Button2" type="button" value="前往" onclick="openwin('批量添加受助人.aspx', '批量添加受助人', 400, 200);" />--%>
                    
                    <asp:Button ID="Button2" runat="server" Text="前往" CssClass="btn btn-danger" OnClick="Button2_Click1" />
                    
                </td>
            </tr>
        </table>
            </div>
          </div>
        <%--<asp:Panel ID="Panel3" runat="server" BorderColor="Black" Height="470px" Width="806px" GroupingText="其他信息">
        
        </asp:Panel>--%>
    </div>
    </form>
    </center>
</body>
</html>
