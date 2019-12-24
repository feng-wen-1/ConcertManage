<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="下单成功界面.aspx.cs" Inherits="WebApplication1.下单成功界面" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 59px;
        }
    </style>
</head>
<body style="height: 264px; margin-top: 206px; margin-left: 0px;">
    <form id="form1" runat="server">
        <div style="margin-left: 684px" class="auto-style1">
        <asp:Label ID="Label1" runat="server" Text="下单成功！" style="font-weight: 700; font-size: xx-large; text-align: center"></asp:Label>
            <br />
            <br />
        </div>
        <p>
            &nbsp;</p>
        <div style="margin-left: 448px">
            <asp:Label ID="Label2" runat="server" Text="订单编号："></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            快递单号：<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            发货状态：<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
        <asp:Button ID="Button1" runat="server" Height="56px" OnClick="Button1_Click" style="margin-left: 452px" Text="查看订单" Width="183px" />
        <asp:Button ID="Button2" runat="server" Height="56px" OnClick="Button2_Click" style="margin-left: 295px" Text="返回主页" Width="183px" />
        </p>
    </form>
</body>
</html>
