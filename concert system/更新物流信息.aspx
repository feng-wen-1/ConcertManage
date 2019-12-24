<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="更新物流信息.aspx.cs" Inherits="concert_system.更新物流信息" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 30px;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
        <div class="auto-style3">
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="返回主页" />
        </div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style1" OnClick="Button1_Click" Text="搜索" />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
        </div>
        <asp:Label ID="Label1" runat="server" Text="发货状态："></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>已发货</asp:ListItem>
            <asp:ListItem>未发货</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="物流信息："></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <div class="auto-style2">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="确定" />
        </div>
    </form>
</body>
</html>
