<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="下单页面.aspx.cs" Inherits="WebApplication1.下单页面" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            width: 1268px;
            font-size: medium;
        }
        .auto-style1 {
            margin-left: 42px;
            margin-top: 22px;
            width: 1326px;
        }
        .auto-style2 {
            margin-left: 333px;
        }
        .auto-style3 {
            margin-top: 0px;
        }
        .auto-style4 {
            height: 171px;
            width: 417px;
        }
        .auto-style5 {
            margin-top: 185px;
        }
        .auto-style6 {
            margin-left: 26px;
        }
        .auto-style8 {
            margin-left: 0px;
        }
        .auto-style9 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style1">
        <div style="width: 1262px; height: 233px; margin-top: 5px">
            <br />
            <asp:Button ID="Button12" runat="server" CssClass="auto-style6" Height="42px" OnClick="Button12_Click" Text="返回主页" Width="78px" />
            <br />
            <br />
            <asp:Image ID="Image1" runat="server" Height="178px" Width="129px" />
            <div class="auto-style4">
                演唱会编号：<asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="演唱会名称："></asp:Label>
                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label12" runat="server" Text="地址："></asp:Label>
                <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="时间："></asp:Label>
                <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                <br />
                <div style="height: 85px; margin-top: 16px; width: 1093px;">
                    <asp:Label ID="Label6" runat="server" Text="票档："></asp:Label>
                </div>
            </div>
        </div>
        <asp:Button ID="Button1" runat="server" Height="63px" OnClick="Button1_Click" style="margin-left: 54px; margin-top: 89px;" Text="188元（看台）" Width="186px" />
        <asp:Button ID="Button2" runat="server" Height="63px" OnClick="Button2_Click" style="margin-left: 14px" Text="388元（看台）" Width="186px" CssClass="auto-style3" />
        <asp:Button ID="Button3" runat="server" Height="63px" OnClick="Button3_Click" style="margin-left: 13px; " Text="588元（看台）" Width="186px" CssClass="auto-style5" />
        <asp:Button ID="Button4" runat="server" Height="63px" OnClick="Button4_Click" style="margin-left: 16px; margin-top: 11px" Text="688元（内场）" Width="186px" />
        <asp:Button ID="Button5" runat="server" Height="63px" OnClick="Button5_Click" style="margin-left: 14px" Text="988元（内场）" Width="186px" />
        <p style="height: 32px">
            <asp:Label ID="Label1" runat="server" Text="数量："></asp:Label>
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="-" Width="23px" Height="27px" />
            <asp:Label ID="Label9" runat="server" Text="1"></asp:Label>
            <asp:Button ID="Button10" runat="server" style="margin-left: 7px" Text="+" Width="23px" OnClick="Button10_Click" />
            <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
        </p>
        <p style="height: 25px">
            <asp:Label ID="Label7" runat="server" Text="金额："></asp:Label>
            <asp:Label ID="Label8" runat="server" Text="0"></asp:Label>
            元</p>
        <asp:Label ID="Label2" runat="server" Text="收货地址："></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>请选择</asp:ListItem>
            <asp:ListItem>山东</asp:ListItem>
            <asp:ListItem>江苏</asp:ListItem>
            <asp:ListItem>上海</asp:ListItem>
            <asp:ListItem>浙江</asp:ListItem>
            <asp:ListItem>安徽</asp:ListItem>
            <asp:ListItem>福建</asp:ListItem>
            <asp:ListItem>江西</asp:ListItem>
            <asp:ListItem>广东</asp:ListItem>
            <asp:ListItem>广西</asp:ListItem>
            <asp:ListItem>海南</asp:ListItem>
            <asp:ListItem>河南</asp:ListItem>
            <asp:ListItem>湖南</asp:ListItem>
            <asp:ListItem>湖北</asp:ListItem>
            <asp:ListItem>北京</asp:ListItem>
            <asp:ListItem>天津</asp:ListItem>
            <asp:ListItem>河北</asp:ListItem>
            <asp:ListItem>山西</asp:ListItem>
            <asp:ListItem>内蒙古</asp:ListItem>
            <asp:ListItem>宁夏</asp:ListItem>
            <asp:ListItem>青海</asp:ListItem>
            <asp:ListItem>陕西</asp:ListItem>
            <asp:ListItem>甘肃</asp:ListItem>
            <asp:ListItem>新疆</asp:ListItem>
            <asp:ListItem>四川</asp:ListItem>
            <asp:ListItem>贵州</asp:ListItem>
            <asp:ListItem>云南</asp:ListItem>
            <asp:ListItem>重庆</asp:ListItem>
            <asp:ListItem>西藏</asp:ListItem>
            <asp:ListItem>辽宁</asp:ListItem>
            <asp:ListItem>吉林</asp:ListItem>
            <asp:ListItem>黑龙江</asp:ListItem>
            <asp:ListItem>香港</asp:ListItem>
            <asp:ListItem>澳门</asp:ListItem>
            <asp:ListItem>台湾</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label10" runat="server" Text="省份/市"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" style="margin-bottom: 0px">
            <asp:ListItem>请选择</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label11" runat="server" Text="市/区"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Height="124px" style="margin-top: 7px; color: #808080; margin-left: 84px;" Width="568px" OnTextChanged="TextBox2_TextChanged">详细地址</asp:TextBox>
        <p>
            <asp:Label ID="Label3" runat="server" Text="联系方式："></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" Width="232px" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
        </p>
        <p class="auto-style9">
            <asp:Button ID="Button13" runat="server" CssClass="auto-style8" Height="77px" OnClick="Button13_Click" Text="选座购买" Width="201px" />
            <asp:Button ID="Button11" runat="server" Height="77px" OnClick="Button11_Click" Text="立即购买" Width="201px" CssClass="auto-style2" />
            <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
        </p>
    </form>
</body>
</html>
