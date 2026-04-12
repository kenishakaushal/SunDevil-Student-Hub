<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Member_Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Registration</title>
    <style type="text/css">
        body {
            font-family: Arial, Helvetica, sans-serif;
            background-color: #f7f7f7;
            margin: 30px;
        }

        .box {
            width: 650px;
            margin: auto;
            background: white;
            padding: 24px;
            border: 1px solid #ddd;
            border-radius: 10px;
        }

        .inputBox {
            width: 280px;
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

        .ok {
            color: green;
            font-weight: bold;
        }

        .verifyBox {
            background-color: #f2f2f2;
            padding: 10px;
            border: 1px dashed #888;
            width: 200px;
            text-align: center;
            font-size: 22px;
            letter-spacing: 3px;
            margin-bottom: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h1>Member Registration</h1>
            <p>Create a new member account to access the protected member page.</p>

            <table>
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
                    <td>Confirm Password:</td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="inputBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Interest:</td>
                    <td>
                        <asp:TextBox ID="txtInterest" runat="server" CssClass="inputBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Verification:</td>
                    <td>
                        <div class="verifyBox">
                            <asp:Label ID="lblVerificationCode" runat="server"></asp:Label>
                        </div>
                        <asp:TextBox ID="txtVerificationInput" runat="server" CssClass="inputBox"
                            placeholder="Type the code shown above"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />
            <asp:Button ID="btnRefreshCode" runat="server" Text="Refresh Code" CssClass="btn" OnClick="btnRefreshCode_Click" />
            <asp:Button ID="btnLogin" runat="server" Text="Go to Login" CssClass="btn" OnClick="btnLogin_Click" />
            <asp:Button ID="btnHome" runat="server" Text="Back Home" CssClass="btn" OnClick="btnHome_Click" />

            <br /><br />
            <asp:Label ID="lblMessage" runat="server" CssClass="msg"></asp:Label>
            <br />
            <asp:Label ID="lblSuccess" runat="server" CssClass="ok"></asp:Label>
        </div>
    </form>
</body>
</html>
