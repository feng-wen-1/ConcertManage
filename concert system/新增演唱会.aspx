<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="新增演唱会.aspx.cs" Inherits="concert_system.新增演唱会" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        演唱会编号：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        演唱会名称：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        演唱会举办时间：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        歌手：<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="VNAME" DataTextField="VNAME" DataValueField="VNAME">
        </asp:DropDownList>
        <asp:SqlDataSource ID="VNAME" runat="server" ConnectionString="<%$ ConnectionStrings:YCH1ConnectionString2 %>" SelectCommand="SELECT [VNAME] FROM [VOCALIST]"></asp:SqlDataSource>
        <br />
        <br />
        主办方：<asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="HOLDER" DataTextField="HNAME" DataValueField="HNAME">
        </asp:DropDownList>
        <asp:SqlDataSource ID="HOLDER" runat="server" ConnectionString="<%$ ConnectionStrings:YCH1ConnectionString2 %>" SelectCommand="SELECT [HNAME] FROM [HOLDER]"></asp:SqlDataSource>
        <br />
        <br />
        场馆编号：<asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SNO" DataTextField="SNO" DataValueField="SNO">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SNO" runat="server" ConnectionString="<%$ ConnectionStrings:YCH1ConnectionString2 %>" SelectCommand="SELECT [SNO] FROM [STADIUM1]"></asp:SqlDataSource>
        <br />
        <br />
        <br />
        演唱会票类：188元档<asp:TextBox ID="TextBox14" runat="server" Width="68px"></asp:TextBox>
        --<asp:TextBox ID="TextBox19" runat="server" Width="68px"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 388元档<asp:TextBox ID="TextBox15" runat="server" Width="68px"></asp:TextBox>
        --<asp:TextBox ID="TextBox20" runat="server" Width="68px"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 588元档<asp:TextBox ID="TextBox16" runat="server" Width="68px"></asp:TextBox>
        --<asp:TextBox ID="TextBox21" runat="server" Width="68px"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 688元档<asp:TextBox ID="TextBox17" runat="server" Width="68px"></asp:TextBox>
        --<asp:TextBox ID="TextBox22" runat="server" Width="68px"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 988元档<asp:TextBox ID="TextBox18" runat="server" Width="68px"></asp:TextBox>
        --<asp:TextBox ID="TextBox23" runat="server" Width="68px"></asp:TextBox>
        <br />
        <br />
        <div class="auto-style2">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确定" />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
        <br />
    </form>
</body>
</html>
