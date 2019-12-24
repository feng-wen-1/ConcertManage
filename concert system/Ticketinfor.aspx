<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ticketinfor.aspx.cs" Inherits="concert_system.Ticketinfor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            color: #000000;
            font-size: large;
        }
        .auto-style1 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
&nbsp;
        <asp:Image ID="Image1" runat="server" Height="220px" style="margin-left: 0px" />
&nbsp;<br />
        <asp:Label ID="Label1" runat="server" Text="演唱会编号"></asp:Label>
        <span class="auto-style1">：<asp:Label ID="lblcno" runat="server" Text="Label"></asp:Label>
&nbsp;<p>
            <asp:Label ID="Label2" runat="server" Text="演唱会名称"></asp:Label>
            ：<asp:Label ID="lblcname" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            时间：&nbsp; <asp:Label ID="lblctime" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            场馆：<asp:Label ID="lblsadd" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            </span>
        </p>
        <p>
            <asp:Label ID="lblpch" runat="server" Text="主演"></asp:Label>
            :</p>
        <p>
            姓名：<asp:Label ID="lblvname" runat="server" Text="歌手1"></asp:Label>
            &nbsp; 
        </p>
        <p>
            公司名字：<asp:Label ID="lblvcname" runat="server" Text="公司名字"></asp:Label>
&nbsp; 
        </p>
        <p>
            公司地址：<asp:Label ID="lblvcadd" runat="server" Text="公司地址"></asp:Label>
&nbsp;&nbsp; 
        </p>
        <p>
            公司联系：
            <asp:Label ID="lblvctel" runat="server" Text="公司联系方式"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            主办方:</p>
        <p>
            名字：<asp:Label ID="hname" runat="server" Text="Label"></asp:Label>
&nbsp;</p>
        <p>
            联系方式：<asp:Label ID="htel" runat="server" Text="Label"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p>
            地址：<asp:Label ID="hadd" runat="server" Text="Label"></asp:Label>
            &nbsp;</p>
        <p>
            &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" style="margin-left: 109px" Text="购买" OnClick="Button1_Click" Height="41px" Width="86px" />
        &nbsp;
            <asp:Button ID="Button2" runat="server" Height="41px" OnClick="Button2_Click" style="margin-left: 27px" Text="返回主页" />
        </p>
    </form>
</body>
</html>
