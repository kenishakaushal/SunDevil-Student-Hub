<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member_Member" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Page</title>
    <style type="text/css">
        body {
            font-family: Arial, Helvetica, sans-serif;
            background-color: #f7f7f7;
            margin: 30px;
        }

        .box {
            width: 760px;
            margin: auto;
            background: white;
            padding: 24px;
            border: 1px solid #ddd;
            border-radius: 10px;
        }

        .btn {
            padding: 8px 15px;
            margin-right: 8px;
            margin-top: 8px;
        }

        .inputBox {
            width: 260px;
            padding: 6px;
            margin-top: 5px;
            margin-bottom: 10px;
        }

        .output {
            display: inline-block;
            background: #fff8dc;
            border: 1px solid #d8cfa3;
            padding: 8px 12px;
            min-width: 340px;
            margin-top: 8px;
        }

        .section {
            margin-top: 25px;
            padding: 15px;
            border: 1px solid #e2e2e2;
            border-radius: 8px;
            background-color: #fcfcfc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h1>Member Page</h1>

            <asp:Label ID="lblWelcome" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblStateInfo" runat="server"></asp:Label>

            <div class="section">
                <h2>What this page offers</h2>
                <ul>
                    <li>Protected member-only access</li>
                    <li>Study support service access</li>
                    <li>Campus resource service access</li>
                    <li>State management using session and cookie</li>
                </ul>
            </div>

            <div class="section">
                <h2>TryIt - Study Tip Service</h2>
                <asp:TextBox ID="txtStudySubject" runat="server" CssClass="inputBox"
                    placeholder="Example: Math"></asp:TextBox>
                <br />
                <asp:Button ID="btnStudyTip" runat="server" Text="Get Study Tip" CssClass="btn" OnClick="btnStudyTip_Click" />
                <br />
                <asp:Label ID="lblStudyTipResult" runat="server" CssClass="output"></asp:Label>
            </div>

            <div class="section">
                <h2>TryIt - Campus Resource Service</h2>
                <asp:TextBox ID="txtCategory" runat="server" CssClass="inputBox"
                    placeholder="Example: Stress"></asp:TextBox>
                <br />
                <asp:Button ID="btnResource" runat="server" Text="Get Campus Resource" CssClass="btn" OnClick="btnResource_Click" />
                <br />
                <asp:Label ID="lblResourceResult" runat="server" CssClass="output"></asp:Label>
            </div>

            <div class="section">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn" OnClick="btnLogout_Click" />
                <asp:Button ID="btnHome" runat="server" Text="Back Home" CssClass="btn" OnClick="btnHome_Click" />
            </div>
        </div>
    </form>
</body>
</html>
