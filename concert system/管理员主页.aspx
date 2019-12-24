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
        .auto-style3 {
            margin-left: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            <div class="auto-style2">
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style3" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>个人中心</asp:ListItem>
                    <asp:ListItem>个人信息</asp:ListItem>
                    <asp:ListItem>退出登录</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="新增演唱会" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="修改演唱会信息" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="删除演唱会" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="修改用户密码" />
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" Text="更新物流信息" />      
        </div>
    </form>
</body>
</html>
