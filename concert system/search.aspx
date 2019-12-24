<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="concert_system.search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 47px">
    
        <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" Orientation="Horizontal" StaticSubMenuIndent="10px" OnMenuItemClick="Menu1_MenuItemClick" style="font-size: medium">
            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <DynamicSelectedStyle BackColor="#FFCC66" />
            <Items>
                <asp:MenuItem Text="全部" Value="全部"></asp:MenuItem>
                <asp:MenuItem Text="北京" Value="北京"></asp:MenuItem>
                <asp:MenuItem Text="天津" Value="天津"></asp:MenuItem>
                <asp:MenuItem Text="上海" Value="上海"></asp:MenuItem>
                <asp:MenuItem Text="重庆" Value="重庆"></asp:MenuItem>
                <asp:MenuItem Text="河北" Value="河北"></asp:MenuItem>
                <asp:MenuItem Text="山西" Value="山西"></asp:MenuItem>
                <asp:MenuItem Text="辽宁" Value="辽宁"></asp:MenuItem>
                <asp:MenuItem Text="吉林" Value="吉林"></asp:MenuItem>
                <asp:MenuItem Text="黑龙江" Value="黑龙江"></asp:MenuItem>
                <asp:MenuItem Text="江苏" Value="江苏"></asp:MenuItem>
                <asp:MenuItem Text="浙江" Value="浙江"></asp:MenuItem>
                <asp:MenuItem Text="安徽" Value="安徽"></asp:MenuItem>
                <asp:MenuItem Text="福建" Value="福建"></asp:MenuItem>
                <asp:MenuItem Text="江西" Value="江西"></asp:MenuItem>
                <asp:MenuItem Text="山东" Value="山东"></asp:MenuItem>
                <asp:MenuItem Text="河南" Value="河南"></asp:MenuItem>
                <asp:MenuItem Text="湖北" Value="湖北"></asp:MenuItem>
                <asp:MenuItem Text="湖南" Value="湖南"></asp:MenuItem>
                <asp:MenuItem Text="广东" Value="广东"></asp:MenuItem>
                <asp:MenuItem Text="海南" Value="海南"></asp:MenuItem>
                <asp:MenuItem Text="四川" Value="四川"></asp:MenuItem>
                <asp:MenuItem Text="贵州" Value="贵州"></asp:MenuItem>
                <asp:MenuItem Text="云南" Value="云南"></asp:MenuItem>
                <asp:MenuItem Text="陕西" Value="陕西"></asp:MenuItem>
                <asp:MenuItem Text="甘肃" Value="甘肃"></asp:MenuItem>
                <asp:MenuItem Text="青海" Value="青海"></asp:MenuItem>
                <asp:MenuItem Text="台湾" Value="台湾"></asp:MenuItem>
                <asp:MenuItem Text="内蒙古" Value="内蒙古"></asp:MenuItem>
                <asp:MenuItem Text="广西" Value="广西"></asp:MenuItem>
                <asp:MenuItem Text="西藏" Value="西藏"></asp:MenuItem>
                <asp:MenuItem Text="宁夏" Value="宁夏"></asp:MenuItem>
                <asp:MenuItem Text="新疆" Value="新疆"></asp:MenuItem>
                <asp:MenuItem Text="香港" Value="香港"></asp:MenuItem>
                <asp:MenuItem Text="澳门" Value="澳门"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#FFCC66" />
        </asp:Menu>
    
    </div>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand" Height="320px" style="text-align: center; font-size: large;" Width="703px" OnDataBound="GridView1_DataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="查看">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="link" Text="详情" OnClick="Button1_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </form>
</body>
</html>
