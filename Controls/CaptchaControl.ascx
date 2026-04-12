<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaptchaControl.ascx.cs" Inherits="SunDevilStudentHub.Controls.CaptchaControl" %>

<div style="border: 2px solid #8C1D40; padding: 15px; border-radius: 8px; background-color: #FFF8DC; display: inline-block;">
    <asp:Label ID="lblCaptchaTitle" runat="server" Text="CAPTCHA Verification"
        Font-Bold="True" Font-Size="14px" ForeColor="#8C1D40" /><br /><br />

    <!-- Display the generated CAPTCHA code -->
    <asp:Label ID="lblCaptchaCode" runat="server"
        Font-Size="24px" Font-Bold="True" ForeColor="#333"
        BackColor="#E0E0E0" 
        Style="padding: 8px 16px; letter-spacing: 8px; font-family: 'Courier New', monospace; border: 1px solid #999;" /><br /><br />

    <asp:Label ID="lblInstruction" runat="server" Text="Enter the code shown above:" Font-Size="12px" /><br />
    <asp:TextBox ID="txtCaptchaInput" runat="server" Width="180px" MaxLength="5" 
        Style="padding: 5px; font-size: 14px; letter-spacing: 4px;" />&nbsp;
    <asp:Button ID="btnVerifyCaptcha" runat="server" Text="Verify" OnClick="btnVerifyCaptcha_Click"
        BackColor="#8C1D40" ForeColor="White" Style="padding: 5px 12px; cursor: pointer;" />&nbsp;
    <asp:Button ID="btnRefreshCaptcha" runat="server" Text="Refresh" OnClick="btnRefreshCaptcha_Click"
        BackColor="#FFC627" ForeColor="#333" Style="padding: 5px 12px; cursor: pointer;" /><br /><br />

    <asp:Label ID="lblCaptchaResult" runat="server" Font-Bold="True" Font-Size="13px" />
</div>
