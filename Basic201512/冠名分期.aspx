<%@ Page Language="C#" AutoEventWireup="true" CodeFile="冠名分期.aspx.cs" Inherits="Basic201512_冠名分期" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <center>
        <form id="form1" runat="server">
            <div>
                <h2>
                    <strong>冠名慈善捐助金周期提醒</strong> 
                </h2>
            </div>
            <div>

                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="benfactorName" HeaderText="名称" />
                        <asp:BoundField DataField="benfactorFrom" HeaderText="所属机构" />
                        <asp:BoundField DataField="deadline" HeaderText="截止时间" />
                        <asp:BoundField DataField="cycle" HeaderText="提醒周期（月）" />
                        <asp:BoundField DataField="flag" HeaderText="剩余提醒次数" />
                        <asp:ButtonField CommandName="cancelRemind" HeaderText="取消本次提醒" Text="取消" />
                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>

            </div>
        </form>
    </center>
</body>
</html>
