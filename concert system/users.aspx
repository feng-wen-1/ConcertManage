<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="concert_system.users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 46px;
        }
        .auto-style2 {
            margin-left: 26px;
        }
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style3">
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        昵称：<asp:Label ID="lblnk" runat="server" Text="Label"></asp:Label>
        <br />
        账号：<asp:Label ID="lbluno" runat="server" Text="Label"></asp:Label>
        <br />
        邮箱：<asp:Label ID="umail" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修改" CssClass="auto-style1" />
        &nbsp;<asp:Button ID="Button3" runat="server" CssClass="auto-style2" OnClick="Button3_Click" Text="返回" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="昵称："></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="邮箱："></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="确定" />
    
    </div>
    </form>
</body>
</html>
