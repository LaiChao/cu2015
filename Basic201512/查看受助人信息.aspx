<%@ Page Language="C#" AutoEventWireup="true" CodeFile="查看受助人信息.aspx.cs" Inherits="Basic201512_查看受助人信息" %>

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

    <title>查看受助人信息</title>

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
    <script language="javascript" type="text/javascript"></script>
    <style type="text/css">

        .auto-style1 {
            width: 13px;
        }
        .auto-style2 {
            width:120px;
            text-align:right;
            font-family:'Microsoft YaHei';
            height:45px;
            font-size: 13px;
        }
        .label_style {
            font-size: 14px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        }
        .checkBox_style {
            font-family: 'Microsoft YaHei';
        }
        .dropDownList_style {
            width:220px;
        }
    </style>
</head>
<body>
    <center>
    <form id="form1" runat="server">
    <div style="height: 41px">
    
        <h2>
          <strong>查看受助人信息</strong>  

        </h2>
        </div>
    <div style="height: 47px">    
        <asp:Label ID="Label1" runat="server" Text="受助类别：" CssClass="label_style"></asp:Label>    
        <asp:CheckBox ID="CheckBox2" runat="server" Text="助医" CssClass="checkBox_style"  />    
        &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Text="助学" CssClass="checkBox_style"  />
        &nbsp;<asp:CheckBox ID="CheckBox4" runat="server" Text="助老" CssClass="checkBox_style"  />
        &nbsp;<asp:CheckBox ID="CheckBox3" runat="server" Text="助残" CssClass="checkBox_style"  />
        &nbsp;<asp:CheckBox ID="CheckBox5" runat="server" Text="助困" CssClass="checkBox_style"  />    
        &nbsp;<asp:CheckBox ID="CheckBox6" runat="server" AutoPostBack="True" Text="双拥" CssClass="checkBox_style" />
        &nbsp;<asp:CheckBox ID="CheckBox7" runat="server" AutoPostBack="True" Text="重特大灾害" CssClass="checkBox_style" />    
    </div>
    <div style="height: 1312px; width: 806px;">
         <div class="panel panel-danger">
            <div class="panel-heading" align="left">
              <h3 class="panel-title">基本信息</h3>
            </div>
            <div class="panel-body" >
        <table style="width: 90%; height: 155px; margin-right: 116px;">
            <tr style="font-family: 'Microsoft YaHei';">
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    受助人来源：</td>
                <td>
                    <asp:TextBox ID="benfactorFrom" runat="server" class="form-control"></asp:TextBox>
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
                    <asp:DropDownList ID="sex" runat="server" class="btn btn-default dropdown-toggle dropDownList_style">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style2">
                    身份证号：</td>
                <td>
                    <asp:TextBox ID="recipientsPIdcard" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
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
                    <asp:DropDownList ID="marryNow" runat="server" class="btn btn-default dropdown-toggle dropDownList_style">
                        <asp:ListItem>未婚</asp:ListItem>
                        <asp:ListItem>已婚</asp:ListItem>
                        <asp:ListItem>离异</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    致困原因：</td>
                <td>
                    <asp:DropDownList ID="reason" runat="server" class="btn btn-default dropdown-toggle dropDownList_style">
                        <asp:ListItem Value="无">无</asp:ListItem>
                        <asp:ListItem>低保</asp:ListItem>
                        <asp:ListItem>低收入</asp:ListItem>
                        <asp:ListItem>其他</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="familylist" style=" border:0px none" runat="server" Height="18px" OnClick="familylist_Click" Text="-" Width="18px"  BackColor="#c2c2c2" />
                </td>
                <td class="auto-style2" style="font-family: 'Microsoft YaHei'; font-size: 15px; font-weight: bold">
                    家庭成员列表</td>
                <td>
                    
                    &nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    </td>
                <td>
                    
                </td>
            </tr>

            </table>
            <table style="width: 90%; height: 155px; margin-right: 116px;" id="tablefamily" runat="server">
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
                    <asp:TextBox ID="famWork1" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    成员收入1：</td>
                <td>
                    <asp:TextBox ID="famIncome1" runat="server" class="form-control"></asp:TextBox>
                </td>
 
            </tr>
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
                <td class="auto-style1"></td>
                <td class="auto-style2">
                    成员姓名3：</td>
                <td>
                    <asp:TextBox ID="famName3" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
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
        <div class="panel panel-danger">
            <div class="panel-heading" align="left">
              <h3 class="panel-title">其他信息</h3>
            </div>
        <div class="panel-body" style="font-family: 'Microsoft YaHei';">
        
        <table style="width: 90%; height: 155px; margin-right: 116px;">
            <tr>
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
            <tr>
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
            <tr>
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
            <tr>
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
                    <asp:TextBox ID="illtime" runat="server" onClick="WdatePicker()" class="form-control"></asp:TextBox><%--<input class="Wdate" type="text" onClick="WdatePicker()"><font color=red>&lt;- 点我弹出日期控件</font>--%> 
                </td>
            </tr>
            <tr>
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
            <tr>
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
            <tr>
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
            <tr>
                                                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    是否失能：</td>
                <td>
                    <asp:DropDownList ID="shiNeng" runat="server" class="btn btn-default dropdown-toggle dropDownList_style">
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
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    临时说明：</td>
                <td>
                    <asp:TextBox ID="timeDis" runat="server" class="form-control"></asp:TextBox>
                </td>


               <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    是否失独：</td>
                <td>
                    <asp:DropDownList ID="shiDu" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle dropDownList_style">
                        <asp:ListItem>否</asp:ListItem>
                        <asp:ListItem>是</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
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
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    助困说明：</td>
                <td>
                    <asp:TextBox ID="shuoming5" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>

            <tr>
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
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    军官证号：</td>
                <td>
                    
                    <asp:TextBox ID="tbOfficerID" runat="server" class="form-control"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    灾害名称：</td>
                <td>                   
                    <asp:TextBox ID="disaster" runat="server" class="form-control"></asp:TextBox>                   
                </td>
                <td></td>
                <td></td>
                <td style="text-align:right;">
                    <asp:Button ID="btnReturn" runat="server" class="btn btn-danger" OnClick="btnReturn_Click" Text="返回" Width="100px" />
                </td>
            </tr>
        </table>
                </div>
            </div>
    </div>
    </form>
    </center>
</body>
</html>
