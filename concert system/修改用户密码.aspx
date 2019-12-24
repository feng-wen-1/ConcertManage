<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="修改用户密码.aspx.cs" Inherits="concert_system.修改用户mim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;用户账户：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="无此用户！"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="用户名"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="用户密码"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="修改密码" />
        </div>
    </form>
</body>
</html>
