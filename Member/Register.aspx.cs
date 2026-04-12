using System;
using System.Xml;

public partial class Member_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateVerificationCode();
        }
    }

    private void GenerateVerificationCode()
    {
        string code = Guid.NewGuid().ToString("N").Substring(0, 5).ToUpper();
        Session["VerificationCode"] = code;
        lblVerificationCode.Text = code;
    }

    protected void btnRefreshCode_Click(object sender, EventArgs e)
    {
        GenerateVerificationCode();
        lblMessage.Text = "";
        lblSuccess.Text = "";
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        lblSuccess.Text = "";

        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();
        string confirmPassword = txtConfirmPassword.Text.Trim();
        string email = txtEmail.Text.Trim();
        string interest = txtInterest.Text.Trim();
        string verificationInput = txtVerificationInput.Text.Trim().ToUpper();

        if (username == "" || password == "" || confirmPassword == "")
        {
            lblMessage.Text = "Username, password, and confirm password are required.";
            return;
        }

        if (password != confirmPassword)
        {
            lblMessage.Text = "Passwords do not match.";
            return;
        }

        if (Session["VerificationCode"] == null || verificationInput != Session["VerificationCode"].ToString())
        {
            lblMessage.Text = "Verification code is incorrect.";
            GenerateVerificationCode();
            return;
        }

        string filePath = Server.MapPath("~/App_Data/Member.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(filePath);

        XmlNodeList members = doc.SelectNodes("/members/member");
        foreach (XmlNode member in members)
        {
            string existingUser = member["username"] != null ? member["username"].InnerText : "";
            if (existingUser.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                lblMessage.Text = "Username already exists. Please choose another one.";
                return;
            }
        }

        string hashedPassword = SecurityHelper.HashPassword(password);

        XmlNode root = doc.SelectSingleNode("/members");

        XmlElement memberElement = doc.CreateElement("member");

        XmlElement userElement = doc.CreateElement("username");
        userElement.InnerText = username;
        memberElement.AppendChild(userElement);

        XmlElement passwordElement = doc.CreateElement("passwordHash");
        passwordElement.InnerText = hashedPassword;
        memberElement.AppendChild(passwordElement);

        XmlElement emailElement = doc.CreateElement("email");
        emailElement.InnerText = email;
        memberElement.AppendChild(emailElement);

        XmlElement interestElement = doc.CreateElement("interest");
        interestElement.InnerText = interest;
        memberElement.AppendChild(interestElement);

        root.AppendChild(memberElement);
        doc.Save(filePath);

        lblSuccess.Text = "Registration successful. You can now log in.";
        txtUsername.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        txtEmail.Text = "";
        txtInterest.Text = "";
        txtVerificationInput.Text = "";

        GenerateVerificationCode();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx?role=Member");
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}
