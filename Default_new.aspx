<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_new.aspx.cs" Inherits="Default_new" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>慈善信息系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<%--    <link href="css/default.css" rel="stylesheet" type="text/css" />--%>
    <link href="css/head.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/LoadCSS.js" type="text/javascript"></script>
    <script src="Scripts/autoUpdateDatetime.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function () {
            var windowHeight = document.documentElement.clientHeight;
            var headHeight = document.getElementById("divHead").offsetHeight;
            // alert("windowHeight:" + windowHeight + "headHeight:" + headHeight); /*174*/
            document.getElementById("main").height = windowHeight - headHeight;
            compWidth(window.screen.width);
            // if (window.screen.width > 1366) {
            //   LoadCSS('css/head1366.css');
            // 如果分辨率超过  ，则显示;
            // }
            // var size = document.getElementById("labelMode").style.fontSize;
            //alert(size);
        }
    </script>
    <style type="text/css">
        .divImg {
            background-image:url(../image/裁剪4.jpg);
            background-size:97% 100%;
            background-repeat:no-repeat;
            width:auto;
        }
        .lable {
            height: 2em;
            line-height: 2em;
            overflow: hidden;
        padding-left:18px;
        padding-top:10px;
        }
    </style>
</head>
<body>
    <div id="divHead">
        <div id="divTitle">
           <%-- <div id="divDate">
                2013-12</div>
            <div id="divUserInfo">
                当前用户：<% =inputName %>
                <%=signoutURL%></div>--%>
        </div>
        <div id="divImg" class="divImg">
            <%--<img src="image/裁剪4.jpg" alt="logo" style="height: 100%; width: 97%;" />--%>
           <asp:Label ID="Lbtitle" runat="server" Text="Label" Font-Names="微软雅黑" ForeColor="#CE2C27" CssClass="lable" Font-Bold="True" Font-Size="14"></asp:Label> 
        </div>
        <div id="divTitle">
           <%-- <div id="divDate">
                2013-12</div>
            <div id="divUserInfo">
                当前用户：<% =inputName %>
                <%=signoutURL%></div>--%>
        </div>
        <div class="menu2">
            <%=Menus %>
          
        </div>
       <%-- <div id="daohang">当前位置：</div>--%>
    </div>
    <%--<div  style="width:1024px; height:2px; background-color:Blue;"></div>--%>
 <%--   <div  style="width:1150px; height:2px; background-color:red;"></div>--%>
<%--    <iframe border="0" padding="0" height="100px" frameborder="0" width="100%" src="menus.aspx"></iframe>--%>
    <iframe id="main" name="main" border="0" padding="0" frameborder="0" width="100%" src="Basic201512/待办事项.aspx" ></iframe>
</body>
</html>
