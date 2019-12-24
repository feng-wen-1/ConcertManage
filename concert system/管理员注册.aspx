<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="管理员注册.aspx.cs" Inherits="concert_system.管理员注册" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            账号：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            密码：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确定" />
        </div>
    </form>
</body>
</html>
