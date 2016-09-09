<%@ Page Language="c#" Inherits="CL.Utility.Web.BasicData.Register" CodeFile="项目申请.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>项目申请</title>

    <!-- Bootstrap core CSS -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap theme -->
    <%-- <link href="../../dist/css/bootstrap-theme.min.css" rel="stylesheet">--%>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="theme.css" rel="stylesheet">

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
        //function ck() {
        //    var txt = document.getElementById("txtID").value;
        //    var txtpwd = document.getElementById("txtPWD");
        //    var lblerr = document.getElementById("lblErr");
        //   // alert(lblerr.innerText);
        //    //alert(isNumberOr_Letter(txt));

        //    if (isNumberOr_Letter(txt)) {
        //        lblerr.innerText = "用户名正常";
        //        //txtpwd.value = "用户名正常";
        //        document.getElementById("Form1").submit();
        //        alert(11);
        //    }
        //    else {
        //        lblerr.innerText = "用户名不正常";
        //        //txtpwd.value = "用户名不正常";
        //    }
        //}
        //function ck2() {
        //    txtpwd.value = "用户名正常";
        // }
        function isNumberOr_Letter(s) {//判断是否是数字或字母 

            var regu = "^[0-9a-zA-Z\_]{5,15}$";
            var re = new RegExp(regu);
            if (re.test(s)) {
                return true;
            } else {
                return false;
            }
            
        }
        //function openform(theURL,winName,features) {
        //   // newwin = window.showModalDialog(theURL, winName, features);
        //    newwin = window.showModalDialog(theURL,winName,features);
        //}
        function tdisplay()
        {
            document.getElementById("Panel2").style.visibility = true;
        }
       
    </script>
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        #nav { width: 1200px; height: 60px; line-height: 30px; }
        
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
        .auto-style8 {
            width: 150px;
            font-size: 16px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        }
        .lb11_style {
            text-align: right;
            font-family: 'Microsoft YaHei';
        }
        .auto-style9 {          
            height: 50px;
            margin-left: 40px;
            vertical-align: middle;
            text-align: left;
        }
        .dropDownList_style {
            width: 340px !important;
        }
        .yahei_style {
            font-family: 'Microsoft YaHei';
        }
        .link_style {
            font-family: 'Microsoft YaHei';           
        }
        .link_style:link {
            text-decoration: none;
        }
        .link_style:hover {
            color: #d60808;
            transition: 0.2s;
        }
        #dgData1 a, #dgData a {
            text-decoration: none !important;
        }
        #dgData1 a:hover, #dgData a:hover {
            color: #0a1e58 !important;
            transition: 0.2s;
        }
        .labError_style {
            text-align: left;
            font-family: 'Microsoft YaHei';
            font-size: 15px;
            color: #e8a1eb;
            height: 50px;
        }
        #dgData1 td, #dgData td {
            height: 35px;
            vertical-align: middle;
            padding: 0px 10px 0px 10px;
            white-space: nowrap;
            border: #cc9966 1px solid;
        }
        #dgData1 th, #dgData td {
            padding: 0px 10px 0px 10px;
            text-align:center;
            white-space: nowrap;
        }
        .gridView_style {
            font-family: 'Microsoft YaHei';
            font-size: 14px;
        }
        .label_style {
            font-size: 15px;
            text-align: right;
            font-family: 'Microsoft YaHei';
        } 
        .link_style {
            font-family: 'Microsoft YaHei'; 
            font-size: 15px;          
        }
        .link_style:link {
            text-decoration: none;
        }
        .link_style:hover {
            color: #d60808;
            transition: 0.2s;
        }
        .mycenter {
            text-align: center;
            color: black;           
        }
    </style>
</head>
    
<body id="thebody">
    <center>
    <form id="Form1" method="post" runat="server" class="form-inline">
        <input type="hidden" value="0" name="ScrollPos" />
        <div runat="server">       
            <div>
                <h2>
                  <strong>项目申请</strong>  
                </h2>
            </div>
            <table width="550px" runat="server">
                <tr>
                    <td class="auto-style8">
                        <asp:Button ID="familylist" style=" border:0px none" runat="server" Height="30px" OnClick="familylist_Click" Text="-" Width="30px" BackColor="#c2c2c2" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="labError" runat="server" ForeColor="Red" align="center" Text="" CssClass="labError_style"></asp:Label>
                    </td>
                </tr>
            </table>
            <table width="550px" runat="server" id="applyTable">
                <thead>
                    <tr>
                        <td class="auto-style8">项&nbsp;目&nbsp;ID：&nbsp;</td>
                        <td class="auto-style9">
                            <asp:TextBox runat="server" ID="LbproID"  Width="360px" style="text-align: left" CssClass="form-control" Visible="false" ReadOnly="true"></asp:TextBox>
                            <asp:Button runat="server" ID="btnGetId" Text="获取项目ID" OnClick="btnGetId_Click"  CssClass=" btn btn-danger" Width="110px" Height="34px" />
                        </td>
                    </tr>
                </thead>
                <tr>
                    <td class="auto-style8">项&nbsp;目&nbsp;类&nbsp;型：&nbsp;</td>
                    <td class="auto-style9">           
                        <asp:DropDownList ID="ddlType" Width="112px" runat="server" class="btn btn-default dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" >
                                <asp:ListItem>资金</asp:ListItem>
                                <asp:ListItem>物品</asp:ListItem>
                        </asp:DropDownList>
                    &nbsp;
                        <asp:DropDownList ID="ddlNaming" Width="112px" runat="server" class="btn btn-default dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlNaming_SelectedIndexChanged">
                            <asp:ListItem Value="0">非冠名</asp:ListItem>
                            <asp:ListItem Value="1">冠名</asp:ListItem>
                        </asp:DropDownList>
                    &nbsp;
                        <asp:DropDownList ID="ddlDirect" Width="112px" runat="server" class="btn btn-default dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlDirect_SelectedIndexChanged">
                            <asp:ListItem Value="0">非定向</asp:ListItem>
                            <asp:ListItem Value="1">定向</asp:ListItem>
                        </asp:DropDownList>
<%--                    &nbsp;
                        <asp:DropDownList ID="ddlRType" runat="server"  class="btn btn-default dropdown-toggle">

                        </asp:DropDownList>--%>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">受助人类别：&nbsp;</td>
                    <td class="auto-style9">           
                        <asp:DropDownList ID="recipientsType" runat="server" class="btn btn-default dropdown-toggle" Width="360px">
                                <asp:ListItem>请选择</asp:ListItem>
                                <asp:ListItem>助学</asp:ListItem>
                                <asp:ListItem>助医</asp:ListItem>
                                <asp:ListItem>助残</asp:ListItem>
                                <asp:ListItem>助老</asp:ListItem>
                                <asp:ListItem>助困</asp:ListItem>
                                <asp:ListItem>双拥</asp:ListItem>
                                <asp:ListItem>重特大灾难</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server">
                    <td class="auto-style8">项&nbsp;目&nbsp;名&nbsp;称：&nbsp;</td>
                    <td class="auto-style9" runat="server">
                        <asp:TextBox runat="server" ID="projectID"  Width="360px" style="text-align: left" CssClass="form-control"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style8">项&nbsp;目&nbsp;方&nbsp;案：&nbsp;</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="projectDir" runat="server" Height="100px" TextMode="MultiLine" Width="360px" CssClass="form-control"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style8">计划使用善款(元)：&nbsp;</td>
                    <td class="auto-style9">
                        <asp:TextBox MaxLength="20" runat="server" ID="txtPLAN"  Width="360px" CssClass="form-control"></asp:TextBox>
                    </td>                  
                </tr>
                <tr id="trNaming" runat="server">
                    <td class="auto-style8">受助人情况：&nbsp;</td>
                    <td class="auto-style9">
                        <asp:TextBox runat="server" ID="txtDIR" MaxLength="20" Width="360px" Height="100px" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </td>                    
                </tr>                
                <tr>
                    <td class="auto-style8">项目负责人：&nbsp;</td>
                    <td class="auto-style9">
                            <asp:TextBox ID="txttel" runat="server" CssClass="form-control" Width="360px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">负责人电话：&nbsp;</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtteladd" runat="server" CssClass="form-control" Width="360px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">项目实施单位：&nbsp;</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="lblBranch" runat="server" CssClass="form-control" Width="360px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr id="buttonVisible" runat="server">
                    <td class="auto-style8"></td>
                    <td class="auto-style9">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btntijiao" runat="server" OnClick="btntijiao_Click" Text="提交申请" Visible="False"  CssClass=" btn btn-danger" Width="80px" Height="34px"/>
                    </td> 
                </tr>
            </table>
            <div>
                <p>
                    &nbsp;<asp:Button ID="btnReapply" runat="server" Text="重新提交申请" Visible="False"  CssClass=" btn btn-danger" Width="120px" Height="34px" OnClick="btnReapply_Click"/>
                    &nbsp;
                    <asp:Button ID="btnFinish" runat="server" Text="完成项目申请" Visible="false" CssClass=" btn btn-danger" Width="120px" Height="34px" OnClick="btnFinish_Click" />
                </p>
            </div>
            <hr style="width: 1000px;"/>
            <asp:DataGrid ID="dgData1" runat="server" CssClass="gridView_style" AutoGenerateColumns="false" CellPadding="4" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" OnItemCommand="dgData1_ItemCommand" Width="900px" OnItemDataBound="dgData1_ItemDataBound">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
                <EditItemStyle CssClass="dg_item" />
                <Columns>
                    <asp:ButtonColumn CommandName="DeleteR" HeaderText="删除受助人" Text="删除">
                        <ItemStyle ForeColor="#d60808"/>
                    </asp:ButtonColumn>
                    <asp:TemplateColumn HeaderText="受助人姓名">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="受助人ID">
                        <ItemTemplate>
                            <asp:Label ID="lblID1" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container,"DataItem.recipientsID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="年龄">
                        <ItemTemplate>
                            <asp:Label ID="lblAge" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.newAge") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="身份证号">
                        <ItemTemplate>
                            <asp:Label ID="lblPID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsPIdcard") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="来源">
                        <ItemTemplate>
                            <asp:Label ID="lblFrom" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="救助金额">
                        <ItemTemplate>
                            <asp:Label ID="lblMoneyR" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.money") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="救助申请">
                        <ItemTemplate>
                            <asp:Label ID="lblRequestR" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.request").ToString().Length>10?DataBinder.Eval(Container, "DataItem.request").ToString().Substring(0,10) + "...":DataBinder.Eval(Container, "DataItem.request").ToString() %>' ToolTip='<%# DataBinder.Eval(Container, "DataItem.request")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            </asp:DataGrid>
            <br />
            <div id="table1" runat="server">
                <div class="form-group">
                    <p>
                        <asp:Label ID="Label3" runat="server" Text="姓名:" CssClass="label_style"></asp:Label>
                        <asp:TextBox ID="tbName" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="年龄(周岁):" CssClass="label_style"></asp:Label>
                        <asp:TextBox ID="tbAge" runat="server" Width="100px" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="身份证号:" CssClass="label_style"></asp:Label>
                        <asp:TextBox ID="Tbselect" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>&nbsp;
                        <asp:Button ID="Btselect0" runat="server" OnClick="Btselect_Click" Text="搜索" CssClass=" btn btn-danger" Height="34px" Width="85px" />
                    </p>
                    <p>
                        <asp:Label ID="Label4" runat="server" Text="搜索不到受助人？前往:" CssClass="label_style"></asp:Label>
                        <a href="添加受助人.aspx" target="_blank" class="link_style" id="addHelp">添加受助人</a>&nbsp;&nbsp;
                        <asp:Button ID="btnBatch" runat="server" OnClick="btnBatch_Click" Text="批量选择受助人" CssClass=" btn btn-danger" Height="34px" Width="128px" Visible="False" /><%--&nbsp;--%>
<%--                        <asp:Button ID="btnBatchAdd" runat="server" OnClick="btnBatchAdd_Click" Text="批量添加受助人" CssClass=" btn btn-danger" Height="34px" Width="128px" Visible="False" />  --%>
                    </p>
                    
                    
                </div>
                <p>
                    <asp:Label ID="lblMoney" runat="server" Text="救助金额(元)：" CssClass="label_style"></asp:Label>
                    <asp:TextBox ID="tbMoney" runat="server" CssClass="form-control" Width="375px"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblRequest" runat="server" Text="救助申请：" CssClass="label_style"></asp:Label>
                    <asp:TextBox ID="tbRequest" runat="server"  Width="400px" Height="90px" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>                  
                </p>
                <asp:DataGrid ID="dgData" runat="server" CssClass="gridView_style" AutoGenerateColumns="False" CellPadding="4" Width="900px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" OnItemCommand="dgData_ItemCommand" OnItemDataBound="dgData_ItemDataBound1" >
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#ce2c27" Font-Bold="True" ForeColor="#FFFFCC" />
                    <EditItemStyle CssClass="dg_item" />
                    <Columns>
                        <%--<asp:TemplateColumn Visible="true" HeaderText="项目ID">
                    <ItemTemplate>
                        <asp:Label ID="labproid" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtproid" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.projectID") %>'
                            >
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>
                        <asp:ButtonColumn CommandName="SelectR" HeaderText="选择受助人" Text="选择"></asp:ButtonColumn>
                        <asp:TemplateColumn HeaderText="姓名">
                            <%--<EditItemTemplate>
                                <asp:TextBox ID="txtEditID" runat="server" MaxLength="8" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsName") %>'>
                                </asp:TextBox>
                                </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="labID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="受助人ID">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="年龄">
                            <%--<ItemStyle CssClass=""--%>
                            <%--<EditItemTemplate>
                                <asp:Label ID="txtEditAge" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.newAge") %>'></asp:Label>
                                </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="labAge" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.newAge") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="身份证号">
                            <%--<EditItemTemplate>
                        <asp:TextBox ID="txtEditName" runat="server" MaxLength="10" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsPIdcard") %>'>
                        </asp:TextBox>
                                </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="labName" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.recipientsPIdcard") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="来源">
                            <%--<EditItemTemplate>
                        <asp:TextBox ID="txtEditOrder" runat="server" MaxLength="6" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'>
                        </asp:TextBox>
                                </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="labOrder" runat="server" CssClass="txtbox" Text='<%# DataBinder.Eval(Container, "DataItem.benfactorFrom") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                </asp:DataGrid>
            </div>
        </div>
    </form>
    </center>
</body>
</html>
