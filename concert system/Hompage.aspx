<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hompage.aspx.cs" Inherits="concert_system.Hompage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 69px;
            font-size: large;
        }
        .auto-style2 {
            margin-left: 163px;
            font-size: large;
        }
        .auto-style3 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;&nbsp;
    
        <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal" StaticSubMenuIndent="10px" style="font-size: large">
            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <DynamicSelectedStyle BackColor="#FFCC66" />
            <Items>
                <asp:MenuItem Text="请登录" Value="请登录">
                    <asp:MenuItem Text="个人中心" Value="个人中心"></asp:MenuItem>
                    <asp:MenuItem Text="订单管理" Value="订单管理"></asp:MenuItem>
                    <asp:MenuItem Text="退出登录" Value="退出登录"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#FFCC66" />
        </asp:Menu>
    
    </div>
        <span class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" CssClass="auto-style1" />
        &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="286px" CssClass="auto-style2"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" style="margin-left: 30px" Text="搜索" OnClick="Button3_Click" CssClass="auto-style3" />
        <br />
        &nbsp;&nbsp;<p>
&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="162px" Width="167px" OnClick="ImageButton1_Click" Visible="False" />
&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Height="162px" Width="167px" Visible="False" OnClick="ImageButton2_Click" />
&nbsp;<asp:ImageButton ID="ImageButton3" runat="server" Height="162px" Width="167px" Visible="False" OnClick="ImageButton3_Click" />
&nbsp;<asp:ImageButton ID="ImageButton4" runat="server" Height="162px" Width="167px" Visible="False" OnClick="ImageButton4_Click" />
&nbsp;<asp:ImageButton ID="ImageButton5" runat="server" Height="162px" Width="167px" Visible="False" OnClick="ImageButton5_Click" />
        </p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="auto-style3"> </span>
            <asp:Label ID="cname1" runat="server" Text="Label" Visible="False" AssociatedControlID="ImageButton1" CssClass="auto-style3"></asp:Label>
            <span class="auto-style3">&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;</span><asp:Label ID="cname2" runat="server" Text="Label" Visible="False" AssociatedControlID="ImageButton2" CssClass="auto-style3"></asp:Label>
            <span class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
            <asp:Label ID="cname3" runat="server" AssociatedControlID="ImageButton3" Text="Label" Visible="False" CssClass="auto-style3"></asp:Label>
            <span class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; </span>
            <asp:Label ID="cname4" runat="server" AssociatedControlID="ImageButton4" Text="Label" Visible="False" CssClass="auto-style3"></asp:Label>
            <span class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; </span>
            <asp:Label ID="cname5" runat="server" AssociatedControlID="ImageButton5" Text="Label" Visible="False" CssClass="auto-style3"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
