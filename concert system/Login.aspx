<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="增删.Login" %>

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
        <br />
        <br />
    
        <asp:Label ID="Label1" runat="server" Text="账户"></asp:Label>
        ：<asp:TextBox ID="TXTUNO" runat="server"></asp:TextBox>
    
    </div>
        <div class="auto-style1">
        <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
        ：<asp:TextBox runat="server" TextMode="Password" ID="TXTPS"></asp:TextBox>
        </div>
        <p class="auto-style1">
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登录" />
&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="注册" />
        </p>
    </form>
</body>
</html>
