<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TryItService.aspx.cs" Inherits="Page3_TryItService" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Campus Resource Service - SunDevil Student Hub</title>
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

        .testCase {
            background-color: #fff8dc;
            border: 1px solid #d8cfa3;
            padding: 10px;
            border-radius: 6px;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h2>Campus Resource Service TryIt (Kenisha)</h2>
            <p class="smallText">
                This page tests the Campus Resource Service developed by Kenisha Kaushal.
                The service accepts a category string and returns a matching ASU campus support resource.
            </p>

            <!-- SERVICE INFO -->
            <div class="section">
                <h3>Service Information</h3>
                <table>
                    <tr><th>Property</th><th>Value</th></tr>
                    <tr><td>Provider</td><td>Kenisha Kaushal</td></tr>
                    <tr><td>Component Type</td><td>WSDL / SVC Service</td></tr>
                    <tr><td>Operation</td><td>GetCampusResource(string category)</td></tr>
                    <tr><td>Input</td><td>category : string</td></tr>
                    <tr><td>Output</td><td>string (resource description)</td></tr>
                </table>
            </div>

            <!-- TRY IT -->
            <div class="section">
                <h3>Test the Service</h3>
                <p>Enter a category to get a campus resource recommendation.</p>

                <label><b>Category:</b></label><br />
                <asp:TextBox ID="txtCategory" runat="server" CssClass="inputBox"
                    placeholder="e.g. Stress, Tutoring, Career"></asp:TextBox><br />

                <asp:Button ID="btnCallService" runat="server" Text="Call GetCampusResource"
                    CssClass="btn" OnClick="btnCallService_Click" />
                <br />
                <asp:Label ID="lblServiceOutput" runat="server" CssClass="output"></asp:Label>
            </div>

            <!-- TEST CASES -->
            <div class="section">
                <h3>Suggested Test Cases</h3>
                <div class="testCase">
                    <table>
                        <tr><th>Input Category</th><th>Expected Output</th></tr>
                        <tr><td>Stress</td><td>Counseling Services — Student Center, Room 320</td></tr>
                        <tr><td>Tutoring</td><td>Academic Success Center — Hayden Library</td></tr>
                        <tr><td>Career</td><td>Career and Professional Development — University Center</td></tr>
                        <tr><td>Health</td><td>ASU Health Services — Taylor Place</td></tr>
                        <tr><td>Writing</td><td>Writing Center — Ross-Blakley Hall</td></tr>
                        <tr><td>Finance</td><td>Financial Aid Office — Student Services Building</td></tr>
                        <tr><td>Technology</td><td>MyASU IT Help Desk — Computing Commons</td></tr>
                        <tr><td>Fitness</td><td>Sun Devil Fitness Complex — Apache Blvd</td></tr>
                        <tr><td>(empty)</td><td>Error message asking for input</td></tr>
                        <tr><td>Unknown</td><td>Fallback message with available categories</td></tr>
                    </table>
                </div>
            </div>

            <br />
            <a href="../Default.aspx">← Back to Default Page</a>
        </div>
    </form>
</body>
</html>
