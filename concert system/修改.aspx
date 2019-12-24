<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="修改.aspx.cs" Inherits="concert_system.修改" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="搜索" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="演唱会名称："></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="修改" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="演唱会举办时间："></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="修改" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="举办地址："></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
        <p>
            &nbsp;</p>
        <asp:Label ID="Label4" runat="server" Text="歌手："></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:Button ID="Button5" runat="server" Text="修改" OnClick="Button5_Click" />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="VNAME" DataTextField="VNAME" DataValueField="VNAME" Height="16px" Width="70px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="VNAME" runat="server" ConnectionString="<%$ ConnectionStrings:YCH1ConnectionString5 %>" SelectCommand="SELECT [VNAME] FROM [VOCALIST]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label5" runat="server" Text="歌手公司："></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox6" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="歌手公司地址："></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="歌手公司联系方式："></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="主办方："></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox9" runat="server" OnTextChanged="TextBox9_TextChanged"></asp:TextBox>
        <asp:Button ID="Button9" runat="server" Text="修改" OnClick="Button9_Click" />
        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="HNAME" DataTextField="HNAME" DataValueField="HNAME">
        </asp:DropDownList>
        <asp:SqlDataSource ID="HNAME" runat="server" ConnectionString="<%$ ConnectionStrings:YCH1ConnectionString3 %>" SelectCommand="SELECT [HNAME] FROM [CONCERT1]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label9" runat="server" Text="主办方地址："></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Text="主办方联系方式："></asp:Label>
        <asp:TextBox ID="TextBox11" runat="server" OnTextChanged="TextBox11_TextChanged"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label11" runat="server" Text="场馆编号："></asp:Label>
        <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
        <asp:Button ID="Button12" runat="server" Text="修改" OnClick="Button12_Click" />
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="CNO" DataTextField="CNO" DataValueField="CNO">
        </asp:DropDownList>
        <asp:SqlDataSource ID="CNO" runat="server" ConnectionString="<%$ ConnectionStrings:YCH1ConnectionString4 %>" SelectCommand="SELECT [CNO] FROM [CONCERT1]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label12" runat="server" Text="场馆地址："></asp:Label>
        <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
    </form>
</body>
</html>
