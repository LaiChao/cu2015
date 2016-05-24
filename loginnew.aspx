<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginnew.aspx.cs" Inherits="test3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="UTF-8">
   
	<script type="text/javascript" charset="UTF-8" src="prefixfree.min.js"></script>
<style type="text/css">
    body {
    background-color:#d74d4e;
   background-image:url(../image/bg.png);
   background-repeat:no-repeat;
   background-position:50% 50%;
   margin:0;
   padding:0;
   
  
    }
.content {
    width:437px;
    height:513px;
    margin:50px auto 10px auto;
    background-image:url(../image/loin_box.png);
    padding-top:90px;
    background-repeat:no-repeat;
}
.login-form {
    width:370px;
    height:300px;
    margin:70px auto 0;
    padding-top:90px;
    position:relative;
    background-image:none;
}

/*.login-form:before {
    content:"";
    position:absolute;
    top:60px;
    left:-10px;
    width:393px;
    height:34px;
    padding:0px;
    border:0px solid rgb(216,216,219);
    /*background:#fff url("../image/befor1.jpg") no-repeat 2px 2px;*/
    /*background:#fff url("../image/before2.jpg") no-repeat 1px 1px;*/

    /*top:-50px;
    left:150px;
    width:82px;
    height:82px;
    padding:2px;
    border:1px solid rgb(216,216,219);
    background:#fff url("../image/befor1.jpg") no-repeat 2px 2px;*/
    }
    /*.login-form::after {
    content:"";
    position:absolute;
    top:-50px;
    left:144px;
    width:82px;
    height:82px;
    padding:2px;
    border:1px solid rgb(216,216,219);
    background:#fff url("../image/befor1.jpg") no-repeat 0px 0px;
    }*/
.not-registered {
    position:absolute;
    color:rgb(153,153,153);
    font-weight:bold;
	font-size:13px;
    top:calc(100% + 20px);
    background-color:rgb(255,255,255);
    width:370px;
    height:46px;
    margin:0 auto;
    line-height:46px;
    text-align: center;
    box-shadow:0 3px 3px rgba(21,62,78,0.8);
}
.not-registered a {
    margin-left:5px;
    text-decoration: none;
    color:rgb(52,119,182);
    cursor: pointer;
}
.login-form div,.username,.password {
    width:216px;
    height:28px;
    margin:20px auto;
    position:relative;
    line-height:28px;
    border:none;
}
.user-icon, 
.password-icon {
    display:inline-block;
    font-family: 'loginform-icon';
    font-size:15px;
    text-align:center;
    line-height:28px;
    color:rgb(153,153,153);
    position:absolute;
    left:1px;
    top:1px;
    background-color:rgb(255,255,255);
    border:none;
    border-right:1px solid rgb(229,229,232);
    width:30px;
    height:28px;
    transition: all 300ms linear;
}
.username input, .password input {
    height:100%;
    width:calc(100% - 40px);
    padding-left:40px;
    border-radius:0px;
    border:0px solid;
    border-color:rgb(105,105,105) rgb(120,120,120) rgb(109,109,109) rgb(110,110,110);
    display:block;
    background-color:rgb(223,223,223);
    transition: all 300ms linear;
}

 .icon:before, .icon:after {
    content:"";
    position:absolute;
    top:10px;
    left:30px;
    width:0;
    height:0;
    border:0px solid transparent;
    border-left-color:rgb(205,205,205);
}
 .icon:before {
    top:9px;
    border:5px solid transparent;
    border-left-color:rgb(189,189,182);
}
 .username input:focus, .password input:focus {
    border-color:rgb(69,153,228);
    box-shadow:0 0 2px 1px rgb(200,223,244);
}
 .username input:focus + span,  .password input:focus + span {
    background:-*-linear-gradient(top,rgb(185,185,185),rgb(150,150,150));
    color:rgb(51,51,51);
}
 .username input:focus + span:after,  .password input:focus + span:after {
    border-left-color:rgb(205,205,205);
}

.login-form .account-control label {
    margin-left:24px;
    font-size:12px;
    font-family: Arial, Helvetica, sans-serif;
    cursor:pointer;
}
 .button{
    color:#fff;
    font-weight:bold;
    float:right;
    width:68px;
    height:35px;
    position:relative;
    background:-*-linear-gradient(top,rgb(206, 44, 39),rgb(245, 9, 9)) 1px 0 no-repeat,
               -*-linear-gradient(top,rgb(206, 44, 39),rgb(245, 9, 9)) left top no-repeat;
    background-size:66px 35px,68px 35px;
    border:none;
    border-top:1px solid rgb(206, 44, 391);
    border-radius:2px;
    box-shadow:inset 0 1px 0 rgb(205, 38, 38);
    text-shadow:0 1px 1px rgb(51,113,173);
    transition: all 200ms linear;
}
 .button:hover{
    text-shadow:0 0 2px rgb(255,255,255);
    box-shadow:inset 0 1px 0 rgb(255, 51, 0),0 0 10px 3px rgba(250, 35,35, 0.5);
}
  .button:active{
    background:-*-linear-gradient(top,rgb(255, 51, 0),rgb(250, 35,0.5)) 1px 0 no-repeat,
               -*-linear-gradient(top,rgb(255, 51, 0),rgb(250, 35,0.5)) left top no-repeat;
}

.login-form .account-control input {
    }
.login-form label.check {
    position:absolute;
    left:0;
    top:50%;
    margin:-8px 0;
    display:inline-block;
    width:16px;
    height:16px;
    line-height: 16px;
    text-align:center;
    border-radius:2px;
    background:-*-linear-gradient(top,rgb(255,255,255),rgb(246,246,246)) 1px 1px no-repeat,
               -*-linear-gradient(top,rgb(227,227,230),rgb(165,165,165)) left top no-repeat;
    background-size:14px 14px,16px 16px;
}
.login-form .account-control input:checked + label.check:before {
    content:attr(data-on);
    font-family:loginform-icon;
}
@font-face {
  font-family: 'loginform-icon';
  src: url("font/loginform-icon.eot");
  src: url("font/loginform-icon.eot?#iefix") format('embedded-opentype'),
       url("font/loginform-icon.woff") format('woff'),
       url("font/loginform-icon.ttf") format('truetype'),
       url("font/loginform-icon.svg#loginform-icon") format('svg');
  font-weight: normal;
  font-style: normal;
}
</style>
 <script src="/gg_bd_ad_720x90.js" type="text/javascript"></script>
<script src="/follow.js" type="text/javascript"></script>
</head>
<body>

	   <div class="content">
           <form id="form1" runat="server" class="login-form">
               <div class="username">                 
                  <asp:TextBox ID="txtID" runat="server" placeholder="用户名" ></asp:TextBox>
                    <span class="user-icon icon">u</span>
               </div>
               <div class="password">                  
                   <asp:TextBox ID="txtPWD" runat="server" placeholder="*******" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                   <span class="password-icon icon">p</span>
               </div>
               <div class="account-control">
                 <%--  <input type="checkbox" name="Remember me" id="Remember me" value="Remember me" checked="checked" />
                   <label for="Remember me" data-on="c" class="check"></label>
                   <label for="Remember me" class="info">Remember me</label>--%>
                         
                   <asp:Label ID="lblMsg" runat="server" Text="" ></asp:Label>
                   <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="button" OnClick="btnLogin_Click" />
               <%--    <button type="zhuce">注册</button>--%>
               </div>
          <%--     <p class="not-registered">Not a registered user yet?<a>Sign up now!</a></p>--%>
           </form>
	   </div>
<%--<div style="text-align:center;clear:both">

</div>--%>
</body>
</html>
