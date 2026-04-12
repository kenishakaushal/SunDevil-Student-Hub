<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - SunDevil Student Hub</title>
    <style type="text/css">
        body {
            font-family: Arial, Helvetica, sans-serif;
            background-color: #f7f7f7;
            margin: 30px;
        }

        .box {
            width: 520px;
            margin: auto;
            background: white;
            padding: 24px;
            border: 1px solid #ddd;
            border-radius: 10px;
        }

        .inputBox {
            width: 250px;
            padding: 6px;
            margin-top: 5px;
            margin-bottom: 10px;
        }

        .btn {
            padding: 8px 15px;
            margin-right: 8px;
        }

        .msg {
            color: #b00020;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h1>Login</h1>
            <p>Please enter your username and password.</p>

            <table>
                <tr>
                    <td>Role:</td>
                    <td>
                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="inputBox">
                            <asp:ListItem Text="Member" Value="Member"></asp:ListItem>
                            <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Username:</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="inputBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="inputBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Remember username:</td>
                    <td>
                        <asp:CheckBox ID="chkRemember" runat="server" />
                    </td>
                </tr>
            </table>

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
            <asp:Button ID="btnRegister" runat="server" Text="Go to Register" CssClass="btn" OnClick="btnRegister_Click" />
            <asp:Button ID="btnHome" runat="server" Text="Back Home" CssClass="btn" OnClick="btnHome_Click" />

            <br /><br />
            <asp:Label ID="lblMessage" runat="server" CssClass="msg"></asp:Label>
        </div>
    </form>
</body>
</html>
