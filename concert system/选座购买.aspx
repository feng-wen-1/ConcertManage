<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="选座购买.aspx.cs" Inherits="concert_system.选座购买" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            margin-left: 632px;
        }
        .auto-style3 {
            text-align: left;
        }
        .auto-style4 {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <div class="auto-style1">
                <div>
                    <br />
                    <div class="auto-style3">
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="返回上一页" />
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="舞台"></asp:Label>
                </div>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="auto-style2" DataSourceID="TNO" DataTextField="TNO" DataValueField="TNO" Height="29px" OnDataBound="CheckBoxList1_DataBound" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" RepeatColumns="10" RepeatDirection="Horizontal" Width="161px">
                </asp:CheckBoxList>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="确定" />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </div>
            <asp:SqlDataSource ID="TNO" runat="server" ConnectionString="<%$ ConnectionStrings:YCH1ConnectionString %>" DeleteCommand="DELETE FROM [TICKET] WHERE [TNO] = @TNO" InsertCommand="INSERT INTO [TICKET] ([TNO]) VALUES (@TNO)" OnSelecting="TNO_Selecting1" SelectCommand="SELECT [TNO] FROM [TICKET] ORDER BY [TKINDS], [TNO]">
                <DeleteParameters>
                    <asp:Parameter Name="TNO" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="TNO" Type="String" />
                </InsertParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <div class="auto-style3">
                座位：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                <br />
                数量：<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                <br />
                金额：<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                <br />
                收货地址：<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="height: 23px">
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
                省/市<asp:DropDownList ID="DropDownList2" runat="server" style="margin-bottom: 0px" CssClass="auto-style4">
            <asp:ListItem>请选择</asp:ListItem>
        </asp:DropDownList>
                市/区<br />
        <asp:TextBox ID="TextBox2" runat="server" Height="124px" style="margin-top: 7px; color: #808080; margin-left: 84px;" Width="568px" OnTextChanged="TextBox2_TextChanged">详细地址</asp:TextBox>
                <br />
                联系方式：<asp:TextBox ID="TextBox3" runat="server" Width="232px" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                <br />
            </div>
            <br />
            <asp:Button ID="Button1" runat="server" Height="77px" OnClick="Button1_Click" Text="点击购买" Width="201px" />
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
