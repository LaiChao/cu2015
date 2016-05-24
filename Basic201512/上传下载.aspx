<%@ Page Language="C#" AutoEventWireup="true" CodeFile="上传下载.aspx.cs" Inherits="Basic201512_上传下载" %>
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
     <br />
     <br />
     <div>
         <%--         <asp:Button ID="Button1" runat="server" Text="检查文件" onclick="Button1_Click" Height="25px" />
         &nbsp;&nbsp;
         &nbsp;&nbsp;--%>
         <asp:Button ID="Button3" runat="server" Text="上传文件" onclick="Button3_Click" Height="25px" />
     &nbsp;<asp:Label ID="uploadMsg" runat="server" ForeColor="Red"></asp:Label>
     </div>
     <br />
     <div>
                 <asp:Label ID="Label1" runat="server"></asp:Label>
     </div>
     <div>已上传文件</div>
     <div>
         <asp:ListBox ID="ListBox1" runat="server" Width="250px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
         </asp:ListBox>
     </div>
     <div>
         <asp:Button ID="Button4" runat="server" Text="下载文件" onclick="Button4_Click"  Height="25px" Width="62px"/>
         &nbsp;<asp:Button ID="Button5" runat="server" Text="删除文件" Height="25px" onclick="Button5_Click" Width="62px"/>
     &nbsp;
         <asp:Label ID="fileMsg" runat="server" ForeColor="Red"></asp:Label>
     </div>
     </form>
 </body>
 </html>