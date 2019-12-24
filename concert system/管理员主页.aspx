<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="管理员主页.aspx.cs" Inherits="concert_system.管理员主页" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            text-align: left;
        }
        .auto-style4 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style4">
            <div class="auto-style2">
                <asp:Menu ID="个人中心" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
                    <Items>
                        <asp:MenuItem Text="个人信息" Value="个人信息"></asp:MenuItem>
                        <asp:MenuItem Text="退出登录" Value="退出登录"></asp:MenuItem>
                    </Items>
                </asp:Menu>
                <br />
            </div>
            <div class="auto-style4">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="新增演唱会" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="修改演唱会信息" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="删除演唱会" OnClick="Button3_Click" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="修改用户密码" OnClick="Button4_Click" />
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" Text="更新物流信息" OnClick="Button5_Click" />
            </div>
        </div>
    </form>
</body>
</html>
