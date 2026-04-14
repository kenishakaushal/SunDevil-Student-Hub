<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CaptchaForm.aspx.cs" Inherits="Page1_CaptchaForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Captcha Validation - SunDevil Student Hub</title>
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
            max-width: 650px;
        }

        .captchaBox {
            display: inline-block;
            margin-top: 10px;
            padding: 10px 14px;
            background: #fff8dc;
            border: 1px solid #d8cfa3;
            font-weight: bold;
            letter-spacing: 2px;
            min-width: 140px;
        }

        .inputBox {
            width: 260px;
            padding: 6px;
            margin-top: 10px;
        }

        .btn {
            margin-top: 10px;
            padding: 8px 16px;
            margin-right: 8px;
        }

        .output {
            display: inline-block;
            margin-top: 12px;
            padding: 10px;
            background: #eef6ff;
            border: 1px solid #b7cde6;
            min-width: 320px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h2>Captcha Validation Test (Ishita)</h2>

            <p>
                This page tests the captcha user control/local component used to validate human input.
            </p>

            <p><b>Generated Captcha:</b></p>
            <asp:Label ID="lblCaptchaDisplay" runat="server" CssClass="captchaBox"></asp:Label>
            <br />

            <asp:TextBox ID="txtCaptchaInput" runat="server" CssClass="inputBox"
                placeholder="Enter captcha text"></asp:TextBox>
            <br />

            <asp:Button ID="btnValidateCaptcha" runat="server" Text="Validate Captcha"
                CssClass="btn" OnClick="btnValidateCaptcha_Click" />

            <asp:Button ID="btnRefreshCaptcha" runat="server" Text="Refresh Captcha"
                CssClass="btn" OnClick="btnRefreshCaptcha_Click" />

            <br />
            <asp:Label ID="lblCaptchaOutput" runat="server" CssClass="output"></asp:Label>
        </div>
    </form>
</body>
</html>
