<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestEncryption.aspx.cs" Inherits="Page2_TestEncryption" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DLL Hash Test - SunDevil Student Hub</title>

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
            max-width: 600px;
        }

        .inputBox {
            width: 250px;
            padding: 6px;
        }

        .btn {
            margin-top: 10px;
            padding: 8px 16px;
        }

        .output {
            margin-top: 10px;
            padding: 10px;
            background: #fff8dc;
            border: 1px solid #d8cfa3;
        }
    </style>
</head>
<body>

<form id="form1" runat="server">
    <div class="box">

        <h2>DLL Hash Function Test (Ishita)</h2>

        <p>
            This page tests the DLL-based hashing function used for secure password handling.
        </p>

        <asp:TextBox ID="txtInput" runat="server" CssClass="inputBox"
            placeholder="Enter text to hash"></asp:TextBox>
        <br />

        <asp:Button ID="btnHash" runat="server" Text="Generate Hash"
            CssClass="btn" OnClick="btnHash_Click" />

        <br />

        <asp:Label ID="lblOutput" runat="server" CssClass="output"></asp:Label>

    </div>
</form>

</body>
</html>
