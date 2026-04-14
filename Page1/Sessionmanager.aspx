<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionManager.aspx.cs" Inherits="Page1_SessionManager" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Session / Cookie Manager - SunDevil Student Hub</title>
    <style>
        body {
            font-family: Arial;
            margin: 30px;
            background-color: #f8f9fb;
        }

        .box {
            background: white;
            padding: 20px;
            border-radius: 8px;
            border: 1px solid #ddd;
            max-width: 750px;
        }

        h2 {
            color: #8C1D40;
        }

        .inputBox {
            width: 260px;
            padding: 6px;
            margin-top: 6px;
            margin-bottom: 6px;
        }

        .btn {
            margin-top: 10px;
            padding: 8px 16px;
            margin-right: 8px;
        }

        .output {
            display: block;
            margin-top: 12px;
            padding: 10px;
            background: #eef6ff;
            border: 1px solid #b7cde6;
            min-width: 320px;
            line-height: 1.7;
        }

        .section {
            margin-top: 20px;
            padding: 16px;
            border: 1px solid #e2e2e2;
            border-radius: 8px;
            background-color: #fcfcfc;
        }

        table {
            border-collapse: collapse;
            margin-top: 10px;
            width: 100%;
        }

        th, td {
            border: 1px solid #bbb;
            padding: 8px 10px;
            text-align: left;
        }

        th {
            background-color: #ececec;
        }

        .smallText {
            font-size: 13px;
            color: #555;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h2>Session and Cookie Manager (Kenisha)</h2>
            <p class="smallText">
                This page demonstrates temporary state management using ASP.NET Session and HTTP Cookies.
                Developed by Kenisha Kaushal for CSE 445 Assignment 5.
            </p>

            <!-- SECTION 1: Store values -->
            <div class="section">
                <h3>1. Store Session and Cookie Values</h3>
                <p>Enter a username and preferred category to store in Session and Cookie.</p>

                <label><b>Username:</b></label><br />
                <asp:TextBox ID="txtUsername" runat="server" CssClass="inputBox"
                    placeholder="e.g. DemoUser"></asp:TextBox><br />

                <label><b>Preferred Category:</b></label><br />
                <asp:TextBox ID="txtCategory" runat="server" CssClass="inputBox"
                    placeholder="e.g. Tutoring, Stress, Career"></asp:TextBox><br />

                <asp:Button ID="btnStoreValues" runat="server" Text="Store in Session + Cookie"
                    CssClass="btn" OnClick="btnStoreValues_Click" />
                <br />
                <asp:Label ID="lblStoreResult" runat="server" CssClass="output"></asp:Label>
            </div>

            <!-- SECTION 2: Retrieve values -->
            <div class="section">
                <h3>2. Retrieve Stored Values</h3>
                <p>Click the button to read back the current Session and Cookie values.</p>

                <asp:Button ID="btnRetrieveValues" runat="server" Text="Retrieve Session + Cookie"
                    CssClass="btn" OnClick="btnRetrieveValues_Click" />
                <br />
                <asp:Label ID="lblRetrieveResult" runat="server" CssClass="output"></asp:Label>
            </div>

            <!-- SECTION 3: Clear values -->
            <div class="section">
                <h3>3. Clear All State</h3>
                <p>Click to clear all Session variables and remove the Cookie.</p>

                <asp:Button ID="btnClearAll" runat="server" Text="Clear Session + Cookie"
                    CssClass="btn" OnClick="btnClearAll_Click" />
                <br />
                <asp:Label ID="lblClearResult" runat="server" CssClass="output"></asp:Label>
            </div>

            <!-- SECTION 4: State summary table -->
            <div class="section">
                <h3>4. Current State Summary</h3>
                <asp:Button ID="btnRefreshSummary" runat="server" Text="Refresh Summary"
                    CssClass="btn" OnClick="btnRefreshSummary_Click" />
                <table>
                    <tr>
                        <th>Storage Type</th>
                        <th>Key</th>
                        <th>Current Value</th>
                    </tr>
                    <tr>
                        <td>Session</td>
                        <td>UserName</td>
                        <td><asp:Label ID="lblSummarySessionUser" runat="server" Text="(empty)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Session</td>
                        <td>Role</td>
                        <td><asp:Label ID="lblSummarySessionRole" runat="server" Text="(empty)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Cookie</td>
                        <td>PreferredCategory</td>
                        <td><asp:Label ID="lblSummaryCookieCategory" runat="server" Text="(empty)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Session</td>
                        <td>LastAccess</td>
                        <td><asp:Label ID="lblSummaryLastAccess" runat="server" Text="(empty)"></asp:Label></td>
                    </tr>
                </table>
            </div>

            <br />
            <a href="../Default.aspx">← Back to Default Page</a>
        </div>
    </form>
</body>
</html>
