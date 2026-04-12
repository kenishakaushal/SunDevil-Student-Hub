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

        ul {
            line-height: 1.7;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <h1>SunDevil Student Hub</h1>
            <p class="smallText">
                A service-oriented ASP.NET Web Application for CSE 445 Assignments 5 and 6.
            </p>

            <!-- App Description -->
            <div class="section">
                <h2>1. Application Description</h2>
                <p>
                    SunDevil Student Hub is a student-support web application that helps users access
                    academic resources, study suggestions, and protected member/staff features.
                    The application demonstrates:
                </p>
                <ul>
                    <li>Presentation layer using ASPX pages and server controls</li>
                    <li>Local component layer using DLL, session/cookies, Global.asax, and user controls</li>
                    <li>Remote service layer using WSDL/REST-style services</li>
                    <li>Data management using XML files, session state, and cookies</li>
                    <li>Access control using Forms Security for Assignment 6</li>
                </ul>
            </div>

            <!-- Grader Instructions -->
            <div class="section">
                <h2>2. How the TA/Grader Can Test This Application</h2>
                <ul>
                    <li>Use the TryIt section below to test the web services and local DLL component.</li>
                    <li>Use the hash test box to verify the local password hashing function.</li>
                    <li>Use the service test boxes to verify the service operations and outputs.</li>
                    <li>Use the Session/Cookie demo button to verify state management.</li>
                    <li>Buttons to Member and Staff pages are included here for Assignment 5 completeness.</li>
                </ul>

                <p class="important">
                    For Assignment 5, Member and Staff full implementation is not required yet, but the buttons/links are included as required.
                </p>
            </div>

            <!-- Navigation -->
            <div class="section">
                <h2>3. Main Navigation</h2>
                <div class="buttonRow">
                    <asp:Button ID="btnMemberPage" runat="server" Text="Go to Member Page"
                        CssClass="btn" OnClick="btnMemberPage_Click" />
                    <asp:Button ID="btnStaffPage" runat="server" Text="Go to Staff Page"
                        CssClass="btn" OnClick="btnStaffPage_Click" />
                </div>
            </div>

            <!-- Application and Components Summary Table -->
            <div class="section">
                <h2>4. Application and Components Summary Table</h2>
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
                        <td>Hashes password for secure storage in XML.</td>
                        <td>TryIt section: Local DLL Hash Test</td>
                    </tr>
                    <tr>
                        <td>Ishita Bansal</td>
                        <td>Session / Cookie Module</td>
                        <td>SaveUserState</td>
                        <td>username : string</td>
                        <td>void</td>
                        <td>Stores temporary user information using Session and Cookie.</td>
                        <td>TryIt section: Session/Cookie Demo</td>
                    </tr>
                    <tr>
                        <td>Ishita Bansal</td>
                        <td>WSDL / SVC Service</td>
                        <td>GetStudyTip</td>
                        <td>subject : string</td>
                        <td>string</td>
                        <td>Returns a study tip based on the subject entered by user.</td>
                        <td>TryIt section: Study Tip Service</td>
                    </tr>
                    <tr>
                        <td>Kenisha Kaushal</td>
                        <td>User Control</td>
                        <td>Captcha Validation</td>
                        <td>captchaInput : string</td>
                        <td>bool</td>
                        <td>Validates user input during sign-up in Assignment 6.</td>
                        <td>Member registration page / linked in integrated app</td>
                    </tr>
                    <tr>
                        <td>Kenisha Kaushal</td>
                        <td>Global.asax Event</td>
                        <td>Session_Start / Application_Start</td>
                        <td>none</td>
                        <td>void</td>
                        <td>Initializes application/session-level variables.</td>
                        <td>Visible through application behavior / label output</td>
                    </tr>
                    <tr>
                        <td>Kenisha Kaushal</td>
                        <td>WSDL / SVC Service</td>
                        <td>GetCampusResource</td>
                        <td>category : string</td>
                        <td>string</td>
                        <td>Returns a campus support resource based on selected category.</td>
                        <td>TryIt section: Campus Resource Service</td>
                    </tr>
                </table>
            </div>

            <!-- TryIt Area -->
            <div class="section">
                <h2>5. TryIt / Component Testing Area</h2>

                <h3>5.1 Local DLL Hash Test</h3>
                <p>Enter a password and test the DLL hash function.</p>
                <asp:TextBox ID="txtPasswordToHash" runat="server" CssClass="inputBox"
                    placeholder="Enter password to hash"></asp:TextBox>
                <br />
                <asp:Button ID="btnHashPassword" runat="server" Text="Test Hash Function"
                    CssClass="btn" OnClick="btnHashPassword_Click" />
                <br />
                <asp:Label ID="lblHashOutput" runat="server" CssClass="outputLabel"></asp:Label>

                <hr />

                <h3>5.2 Ishita's Study Tip Service</h3>
                <p>Enter a subject and call the service.</p>
                <asp:TextBox ID="txtStudySubject" runat="server" CssClass="inputBox"
                    placeholder="Example: Math"></asp:TextBox>
                <br />
                <asp:Button ID="btnStudyTip" runat="server" Text="Get Study Tip"
                    CssClass="btn" OnClick="btnStudyTip_Click" />
                <br />
                <asp:Label ID="lblStudyTipOutput" runat="server" CssClass="outputLabel"></asp:Label>

                <hr />

                <h3>5.3 Kenisha's Campus Resource Service</h3>
                <p>Enter a category and call the service.</p>
                <asp:TextBox ID="txtResourceCategory" runat="server" CssClass="inputBox"
                    placeholder="Example: Stress"></asp:TextBox>
                <br />
                <asp:Button ID="btnCampusResource" runat="server" Text="Get Campus Resource"
                    CssClass="btn" OnClick="btnCampusResource_Click" />
                <br />
                <asp:Label ID="lblCampusResourceOutput" runat="server" CssClass="outputLabel"></asp:Label>

                <hr />

                <h3>5.4 Session / Cookie Demo</h3>
                <p>Click the button below to store and display sample state information.</p>
                <asp:Button ID="btnSessionCookieDemo" runat="server" Text="Run Session/Cookie Demo"
                    CssClass="btn" OnClick="btnSessionCookieDemo_Click" />
                <br />
                <asp:Label ID="lblSessionCookieOutput" runat="server" CssClass="outputLabel"></asp:Label>
            </div>

            <!-- Test Inputs -->
            <div class="section">
                <h2>6. Suggested Test Cases / Inputs</h2>
                <ul>
                    <li>Hash test input: <b>Cse445!</b></li>
                    <li>Study Tip service input: <b>Math</b>, <b>Programming</b>, <b>Science</b></li>
                    <li>Campus Resource service input: <b>Stress</b>, <b>Tutoring</b>, <b>Career</b></li>
                    <li>Session/Cookie demo: click button and verify displayed stored values</li>
                </ul>
            </div>

        </div>
    </form>
</body>
</html>
