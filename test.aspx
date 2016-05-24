<%@ Page Language="C#" Inherits="test" CodeFile="test.aspx.cs"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!-- saved from url=(0047)http://211.140.160.74/myta/homeftp/feilong/bbs/ -->
<html> 
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
        <meta name="Generator" content="EditPlus®"/>
        <meta name="Author" content=""/>
        <meta name="Keywords" content=""/>
        <meta name="Description" content=""/>
        <link rel="stylesheet" href="css/main_petrel.css" type="text/css" />
        <title>慈善信息慈善信息系统</title>
        
<%--    <link href="css/default.css" rel="stylesheet" type="text/css" />--%>
        <style type="text/css">     
	        .auto-style1 {
                width: 146px;
                background-color:#6b6160;
                height:100%;
                margin:0;
            }
            .auto-style2 {
            width:100%;
            height:100%;
            margin:0;
            }
            .form {
            width:100%;
            height:100%;
            margin:0;          
            overflow:no-content;
            }
            .divImag {
            background-image:url("../image/lefttop (2).jpg");
            font-family:'Microsoft YaHei';
            color:#cccccc;
            text-align:center;
            }
            a:link{color:#cccccc}
            a:visited{color:#cccccc}
            a:hover{color:#cccccc}
   
	</style>
    </head>
   <body>
   <div id="divTest" style="width:100%;height:100%;position:absolute;overflow:hidden;left:0px;bottom:0px;top:0px;">   
        <form action="" class="form">
        <table  class="auto-style2">
            <tbody>
                <tr class="form">                 
                    <td id="frmTitle"  valign="top" nowrap="nowrap" class="auto-style1" >                   
                        
                        <img alt="标题" src="image/lefttop (1).jpg"/> 
                        <div id="divUserInfo" class="divImag ">
                你好！<%=inputName %>  | 
                <%=signoutURL%></div>                     
                         <a href="Default_new.aspx?id=1" target="carnoc" id="href1"> <li style="list-style-type:none;" class="MENU_LI" id='1'><img src="image/tool.png" width="37" height="37" border="0" alt="" /><span class="">基本工具</span></li></a>
                         <a href="Default_new.aspx?id=2" target="carnoc" id="href2"> <li style="list-style-type:none;" class="MENU_LI" id="2"><img src="image/site.png" width="37" height="37" border="0" alt=""><span class="">用户与机构管理</span></li></a>
                         <a href="Default_new.aspx?id=3" target="carnoc" id="href3"> <li style="list-style-type:none;" class="MENU_LI" id="3"><img src="image/manage.png" width="37" height="37" border="0" alt=""><span class="">项目管理</span></li></a>
                         <a href="Default_new.aspx?id=4" target="carnoc" id="href4"> <li style="list-style-type:none;" class="MENU_LI" id="4"><img src="image/heart.png" width="37" height="37" border="0" alt=""><span class="">捐赠人管理</span></li></a>
                         <a href="Default_new.aspx?id=5" target="carnoc" id="href5"> <li style="list-style-type:none;" class="MENU_LI" id="5"><img src="image/heart.png" width="37" height="37" border="0" alt=""><span class="">受助人管理</span></li></a>
                         <a href="Default_new.aspx?id=6" target="carnoc" id="href6"><li style="list-style-type:none;" class="MENU_LI" id="7"><img src="image/setting.png" width="37" height="37" border="0" alt=""><span class="">日志管理</span></li></a>
                         <a href="Default_new.aspx?id=7" target="carnoc" id="href7"> <li style="list-style-type:none;" class="MENU_LI" id="6"><img src="image/log.png" width="37" height="37" border="0" alt=""><span class="">统计查询</span></li></a>
                        
                      <%--<iframe align="top" width=100% height="100%" src="menu.html"></iframe>--%>                      
                    </td>
                    <td width="30px" >
                         <p hidden="hidden"> 
                            <asp:Label Text="" ID="lbflag" runat ="server"></asp:Label>
                        </p>
                    </td>
                    <td>
                                            
                        <iframe id="carnoc"  style="z-index:2; visibility:inherit; width:100%; height:100%"
                            name="carnoc" src="Default_new.aspx" frameborder="0" scrolling="no"></iframe>
                        
                          
                    
                        <%--<IFRAME id="main" style="VISIBILITY: inherit; WIDTH: 100%; HEIGHT: 300px" name="main" src=""
                            frameBorder="0" scrolling="no"></IFRAME>--%></td>
                </tr>

            </tbody>
            </table>         
            </form>

   </div>       
    </body>
       
</html>
