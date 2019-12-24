<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="concert_system.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tbody class="auto-style1">
            <tr>
                <td align="center" colspan="2">注册新帐户</td>
            </tr>
            <tr>
                <td align="right">
                    <asp:label runat="server" AssociatedControlID="UserNO" ID="UserNameLabel">账户:</asp:label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="UserNO"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserNO" ErrorMessage="必须填写“用户名”。" ValidationGroup="CreateUserWizard1" ToolTip="必须填写“用户名”。" ID="UserNameRequired">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:label runat="server" AssociatedControlID="Password" ID="PasswordLabel">密码:</asp:label>
                </td>
                <td>
                    <asp:TextBox runat="server" TextMode="Password" ID="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="必须填写“密码”。" ValidationGroup="CreateUserWizard1" ToolTip="必须填写“密码”。" ID="PasswordRequired">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:label runat="server" AssociatedControlID="ConfirmPassword" ID="ConfirmPasswordLabel">确认密码:</asp:label>
                </td>
                <td>
                    <asp:TextBox runat="server" TextMode="Password" ID="ConfirmPassword"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="必须填写“确认密码”。" ValidationGroup="CreateUserWizard1" ToolTip="必须填写“确认密码”。" ID="ConfirmPasswordRequired">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:label runat="server" AssociatedControlID="Email" ID="EmailLabel">电子邮件:</asp:label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Email" OnTextChanged="Email_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" ErrorMessage="必须填写“电子邮件”。" ValidationGroup="CreateUserWizard1" ToolTip="必须填写“电子邮件”。" ID="EmailRequired">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="昵称："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="NickName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NicknameRequired" runat="server" ErrorMessage="必须填写昵称" ControlToValidate="NickName">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" ErrorMessage="“密码”和“确认密码”必须匹配。" Display="Dynamic" ValidationGroup="CreateUserWizard1" ID="PasswordCompare"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="color:Red;">
                    <asp:Literal runat="server" ID="ErrorMessage" EnableViewState="False"></asp:Literal>
                    <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="text-align: left; margin-left: 0px" Text="注册" />
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="取消" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
