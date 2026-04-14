<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SunDevil Student Hub</title>
    <style type="text/css">
        body {
            font-family: Arial, Helvetica, sans-serif;
            margin: 30px;
            background-color: #f8f9fb;
            color: #222;
        }

        .container {
            max-width: 1100px;
            margin: auto;
            background-color: white;
            padding: 24px 30px;
            border: 1px solid #ddd;
            border-radius: 10px;
        }

        h1, h2, h3 {
            color: #8C1D40;
        }

        .section {
            margin-top: 28px;
            padding: 18px;
            border: 1px solid #e2e2e2;
            border-radius: 8px;
            background-color: #fcfcfc;
        }

        .buttonRow {
            margin-top: 15px;
            margin-bottom: 15px;
        }

        .btn {
            padding: 8px 16px;
            margin-right: 10px;
            margin-top: 8px;
        }

        .inputBox {
            width: 250px;
            padding: 6px;
            margin-top: 6px;
            margin-bottom: 6px;
        }

        .outputLabel {
            display: inline-block;
            margin-top: 8px;
            padding: 8px 10px;
            background-color: #fff8dc;
            border: 1px solid #d8cfa3;
            min-width: 320px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 12px;
        }

        th, td {
            border: 1px solid #bbb;
            padding: 10px;
            text-align: left;
            vertical-align: top;
        }

        th {
            background-color: #ececec;
        }

        .smallText {
            font-size: 14px;
            color: #444;
        }

        .important {
            color: #b00020;
            font-weight: bold;
        }

        ul, ol {
            line-height: 1.7;
        }

        a {
            color: #8C1D40;
            text-decoration: none;
        }

        a:hover {
            text-decoration: underline;
        }

        hr {
            margin-top: 20px;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <h1>SunDevil Student Hub</h1>
            <p class="smallText">
                A service-oriented ASP.NET Web Application for CSE 445 Assignment 5
            </p>

            <div class="section">
                <h2>Group Information</h2>
                <p>
                    <b>Group Number:</b> 19
                </p>
                <p>
                    <b>Ishita Bansal</b><br />
                    ASU ID: 1228943471<br />
                    Email: ibansal3@asu.edu
                </p>
                <p>
                    <b>Kenisha Kaushal</b><br />
                    ASU ID: 1230694064<br />
                    Email: kkausha6@asu.edu
                </p>
            </div>

            <div class="section">
                <h2>1. Application Description</h2>
                <p>
                    SunDevil Student Hub is a student-support ASP.NET web application designed for Arizona State University students.
                    It demonstrates a service-oriented architecture by integrating a presentation layer, local components,
                    remote services, and temporary state management into one unified application.
                </p>
                <ul>
                    <li>Presentation layer using ASPX pages and server controls</li>
                    <li>Local component layer using a DLL function and a captcha user control</li>
                    <li>Remote service layer using a service that returns campus support resources</li>
                    <li>Data management using session state and cookies</li>
                    <li>Member and Staff navigation links for Assignment 5 completeness</li>
                </ul>
            </div>

            <div class="section">
                <h2>2. How the TA/Grader Can Test This Application</h2>
                <ol>
                    <li>Use the Service Directory below to access each component and page.</li>
                    <li>Test Ishita's captcha validation component in the Captcha TryIt area.</li>
                    <li>Test Ishita's DLL hashing function in the Hash Test area.</li>
                    <li>Test Kenisha's campus resource service in the Service TryIt area.</li>
                    <li>Test Kenisha's temporary state management feature in the Session/Cookie demo area.</li>
                    <li>Use the Member and Staff buttons to verify navigation links included for Assignment 5.</li>
                </ol>

                <p class="important">
                    For Assignment 5, Member and Staff full implementation is not required yet, but the links are included as required.
                </p>
            </div>

            <div class="section">
                <h2>3. Main Navigation</h2>
                <div class="buttonRow">
                    <asp:Button ID="btnMemberPage" runat="server" Text="Go to Member Page"
                        CssClass="btn" OnClick="btnMemberPage_Click" />
                    <asp:Button ID="btnStaffPage" runat="server" Text="Go to Staff Page"
                        CssClass="btn" OnClick="btnStaffPage_Click" />
                </div>

                <p>
                    Direct links:
                    <br />
                    <a href="../Page4/Member.aspx">../Page4/Member.aspx</a>
                    <br />
                    <a href="../Page5/Staff.aspx">../Page5/Staff.aspx</a>
                </p>
            </div>

            <div class="section">
                <h2>4. Service Directory</h2>
                <ul>
                    <li><a href="../Page1/CaptchaForm.aspx">../Page1/CaptchaForm.aspx</a> - Ishita's Captcha Validation</li>
                    <li><a href="../Page2/TestEncryption.aspx">../Page2/TestEncryption.aspx</a> - Ishita's DLL Hash Function</li>
                    <li><a href="../Page1/SessionManager.aspx">../Page1/SessionManager.aspx</a> - Kenisha's Session/Cookie Demo</li>
                    <li><a href="../Page3/TryItService.aspx">../Page3/TryItService.aspx</a> - Kenisha's Campus Resource Service</li>
                </ul>
            </div>

            <div class="section">
                <h2>5. Applications and Components Summary Table</h2>
                <table>
                    <tr>
                        <th>Provider Name</th>
                        <th>Component Type</th>
                        <th>Operation Name</th>
                        <th>Parameters and Types</th>
                        <th>Return Type</th>
                        <th>Description</th>
                        <th>TryIt / Test Access</th>
                    </tr>
                    <tr>
                        <td>Ishita Bansal</td>
                        <td>DLL Function</td>
                        <td>HashPassword</td>
                        <td>input : string</td>
                        <td>string</td>
                        <td>Hashes a user-entered password or text string for security demonstration.</td>
                        <td><a href="../Page2/TestEncryption.aspx">../Page2/TestEncryption.aspx</a></td>
                    </tr>
                    <tr>
                        <td>Ishita Bansal</td>
                        <td>User Control</td>
                        <td>CaptchaValidation</td>
                        <td>captchaInput : string</td>
                        <td>bool</td>
                        <td>Validates whether the user entered the displayed captcha correctly.</td>
                        <td><a href="../Page1/CaptchaForm.aspx">../Page1/CaptchaForm.aspx</a></td>
                    </tr>
                    <tr>
                        <td>Kenisha Kaushal</td>
                        <td>Session / Cookie Module</td>
                        <td>SaveUserState</td>
                        <td>username : string</td>
                        <td>void</td>
                        <td>Stores and retrieves temporary user data using session and cookies.</td>
                        <td><a href="../Page1/SessionManager.aspx">../Page1/SessionManager.aspx</a></td>
                    </tr>
                    <tr>
                        <td>Kenisha Kaushal</td>
                        <td>WSDL / SVC Service</td>
                        <td>GetCampusResource</td>
                        <td>category : string</td>
                        <td>string</td>
                        <td>Returns a campus support resource based on the category entered by the user.</td>
                        <td><a href="../Page3/TryItService.aspx">../Page3/TryItService.aspx</a></td>
                    </tr>
                </table>
            </div>

            <div class="section">
                <h2>6. TryIt / Component Testing Area</h2>

                <h3>6.1 Ishita's Captcha Validation</h3>
                <p>Enter the captcha text shown below and click the button to validate it.</p>
                <asp:Label ID="lblCaptchaDisplay" runat="server" CssClass="outputLabel" Text="AB12X"></asp:Label>
                <br />
                <asp:TextBox ID="txtCaptchaInput" runat="server" CssClass="inputBox"
                    placeholder="Enter captcha text"></asp:TextBox>
                <br />
                <asp:Button ID="btnValidateCaptcha" runat="server" Text="Validate Captcha"
                    CssClass="btn" OnClick="btnValidateCaptcha_Click" />
                <br />
                <asp:Label ID="lblCaptchaOutput" runat="server" CssClass="outputLabel"></asp:Label>

                <hr />

                <h3>6.2 Ishita's DLL Hash Test</h3>
                <p>Enter a password or text string and test the DLL hash function.</p>
                <asp:TextBox ID="txtPasswordToHash" runat="server" CssClass="inputBox"
                    placeholder="Enter text to hash"></asp:TextBox>
                <br />
                <asp:Button ID="btnHashPassword" runat="server" Text="Test Hash Function"
                    CssClass="btn" OnClick="btnHashPassword_Click" />
                <br />
                <asp:Label ID="lblHashOutput" runat="server" CssClass="outputLabel"></asp:Label>

                <hr />

                <h3>6.3 Kenisha's Campus Resource Service</h3>
                <p>Enter a category and call the service.</p>
                <asp:TextBox ID="txtResourceCategory" runat="server" CssClass="inputBox"
                    placeholder="Example: Stress"></asp:TextBox>
                <br />
                <asp:Button ID="btnCampusResource" runat="server" Text="Get Campus Resource"
                    CssClass="btn" OnClick="btnCampusResource_Click" />
                <br />
                <asp:Label ID="lblCampusResourceOutput" runat="server" CssClass="outputLabel"></asp:Label>

                <hr />

                <h3>6.4 Kenisha's Session / Cookie Demo</h3>
                <p>Click the button below to store and display sample state information.</p>
                <asp:Button ID="btnSessionCookieDemo" runat="server" Text="Run Session/Cookie Demo"
                    CssClass="btn" OnClick="btnSessionCookieDemo_Click" />
                <br />
                <asp:Label ID="lblSessionCookieOutput" runat="server" CssClass="outputLabel"></asp:Label>
            </div>

            <div class="section">
                <h2>7. Suggested Test Cases / Inputs</h2>
                <ul>
                    <li>Captcha input: enter the exact displayed captcha text to receive a valid result</li>
                    <li>Captcha input: enter an incorrect value to receive an invalid result</li>
                    <li>Hash test input: <b>Cse445!</b></li>
                    <li>Campus Resource service input: <b>Stress</b>, <b>Tutoring</b>, <b>Career</b></li>
                    <li>Session/Cookie demo: click the button and verify that stored values are displayed</li>
                </ul>
            </div>

        </div>
    </form>
</body>
</html>
