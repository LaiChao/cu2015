<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uploadDownloadFile.aspx.cs" Inherits="Basic201512_uploadDownloadFile" %>

  <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
 <head runat="server">
      <title></title>
  </head>
  <body>
    <form id="form1" runat="server">
     <div>
         <asp:FileUpload ID="FileUpload1" runat="server" />
     </div>
     <div>
         <asp:Button ID="Button3" runat="server" Text="上传文件" onclick="Button3_Click" Height="25px" />
     </div>
     <div>
         <br />
         文件列表
     </div>
     <div>
         <asp:ListBox ID="ListBox1" runat="server" Width="250px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
         </asp:ListBox>
     </div>
     <div>
         <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="刷新" />
&nbsp;
         <asp:Button ID="Button4" runat="server" Text="下载文件" onclick="Button4_Click"  Height="25px" Width="62px"/>
         &nbsp;<asp:Button ID="Button5" runat="server" Text="删除文件" Height="25px" onclick="Button5_Click" Width="62px"/>
     &nbsp;
         </div>
     </form>
 </body>
 </html>
