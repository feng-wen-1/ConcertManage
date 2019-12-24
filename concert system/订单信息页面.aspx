<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="订单信息页面.aspx.cs" Inherits="WebApplication1.付款页面" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            width: 1442px;
            height: 796px;
        }
        .auto-style1 {
            margin-left: 603px;
        }
        .auto-style2 {
            width: 1124px;
            height: 790px;
        }
        .auto-style3 {
            margin-left: 59px;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            margin-left: 37px;
        }
        .auto-style6 {
            margin-left: 148px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="Image1" runat="server" Height="203px" style="margin-left: 45px; margin-top: 27px" Width="147px" />
        <div class="auto-style2" style="margin-left: 45px">
            订单信息：<br />
            订单编号：<asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="演唱会名称："></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            演唱会编号：<asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="举办时间："></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" style="text-align: left" Text="演唱会地址："></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="座位号："></asp:Label>
            <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            数量：<asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            订单金额：<asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            下单时间：<asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <br />
            物流信息：<br />
            物流编号：<asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            物流状态：<asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" CssClass="auto-style1" OnClick="Button1_Click" Text="修改" />
            <asp:Button ID="Button2" runat="server" CssClass="auto-style3" OnClick="Button2_Click" Text="确定" />
            <asp:Button ID="Button4" runat="server" CssClass="auto-style5" OnClick="Button4_Click" Text="取消" Width="50px" />
            <br />
            收货地址：<asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Height="109px" Width="368px"></asp:TextBox>
            <br />
            <br />
            收货人联系方式：<asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            物流信息：<asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
            <br />
            <div class="auto-style4">
                <asp:Button ID="Button3" runat="server" Height="47px" Text="退票" Width="120px" OnClick="Button3_Click1" />
                <asp:Button ID="Button5" runat="server" CssClass="auto-style6" Height="47px" OnClick="Button5_Click" Text="返回主页" Width="120px" />
            </div>
        </div>
        <br />
        <br />
    </form>
</body>
</html>
