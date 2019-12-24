<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="管理员个人信息.aspx.cs" Inherits="concert_system.管理员个人信息" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button4" runat="server" CssClass="auto-style1" OnClick="Button4_Click" style="height: 27px" Text="返回主页" />
            <br />
            <br />
            账号：<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修改密码" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="确定" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="取消" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="旧密码："></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="新密码："></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="确认新密码："></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
