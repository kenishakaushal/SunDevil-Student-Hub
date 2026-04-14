using System;
using System.Web;
using Group19Project.SecurityLib;

// Replace these namespaces with your actual service references when ready
// using Group19Project.KenishaCampusResourceServiceRef;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblCaptchaOutput.Text = "";
            lblHashOutput.Text = "";
            lblCampusResourceOutput.Text = "";
            lblSessionCookieOutput.Text = "";

            string newCaptcha = GenerateCaptchaCode(5);
            Session["CaptchaCode"] = newCaptcha;
            lblCaptchaDisplay.Text = newCaptcha;

            if (Session["UserName"] != null)
            {
                lblSessionCookieOutput.Text = "Current Session User: " + Session["UserName"].ToString();
            }
        }
    }

    protected void btnMemberPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Page4/Member.aspx");
    }

    protected void btnStaffPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Page5/Staff.aspx");
    }

    protected void btnValidateCaptcha_Click(object sender, EventArgs e)
    {
        string enteredCaptcha = txtCaptchaInput.Text.Trim();
        string actualCaptcha = "";

        if (Session["CaptchaCode"] != null)
        {
            actualCaptcha = Session["CaptchaCode"].ToString();
        }

        if (enteredCaptcha == "")
        {
            lblCaptchaOutput.Text = "Please enter the captcha first.";
            return;
        }

        if (string.Equals(enteredCaptcha, actualCaptcha, StringComparison.OrdinalIgnoreCase))
        {
            lblCaptchaOutput.Text = "Captcha validation result: Valid";
        }
        else
        {
            lblCaptchaOutput.Text = "Captcha validation result: Invalid";
        }

        string newCaptcha = GenerateCaptchaCode(5);
        Session["CaptchaCode"] = newCaptcha;
        lblCaptchaDisplay.Text = newCaptcha;
        txtCaptchaInput.Text = "";
    }

    protected void btnHashPassword_Click(object sender, EventArgs e)
    {
        string input = txtPasswordToHash.Text.Trim();

        if (input == "")
        {
            lblHashOutput.Text = "Please enter text to hash first.";
            return;
        }

        try
        {
            string hashedValue = SecurityUtils.HashPassword(input);
            lblHashOutput.Text = "Hashed Output: " + hashedValue;
        }
        catch (Exception ex)
        {
            lblHashOutput.Text = "Error while hashing: " + ex.Message;
        }
    }

    protected void btnCampusResource_Click(object sender, EventArgs e)
    {
        string category = txtResourceCategory.Text.Trim();

        if (category == "")
        {
            lblCampusResourceOutput.Text = "Please enter a category first.";
            return;
        }

        try
        {
            // Replace with Kenisha's actual service call when ready
            // Example:
            // CampusResourceServiceClient client = new CampusResourceServiceClient();
            // string result = client.GetCampusResource(category);

            string result = GetLocalCampusResourceFallback(category);
            lblCampusResourceOutput.Text = "Service Output: " + result;
        }
        catch (Exception ex)
        {
            lblCampusResourceOutput.Text = "Error calling Campus Resource service: " + ex.Message;
        }
    }

    protected void btnSessionCookieDemo_Click(object sender, EventArgs e)
    {
        try
        {
            Session["UserName"] = "DemoUser_Kenisha";
            Session["Role"] = "Member";

            HttpCookie demoCookie = new HttpCookie("PreferredCategory");
            demoCookie.Value = "Tutoring";
            demoCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(demoCookie);

            string cookieValue;
            if (Request.Cookies["PreferredCategory"] != null)
            {
                cookieValue = Request.Cookies["PreferredCategory"].Value;
            }
            else
            {
                cookieValue = "Tutoring (may appear fully after next request)";
            }

            lblSessionCookieOutput.Text =
                "Session UserName = " + Session["UserName"] +
                " | Session Role = " + Session["Role"] +
                " | Cookie PreferredCategory = " + cookieValue;
        }
        catch (Exception ex)
        {
            lblSessionCookieOutput.Text = "Error in session/cookie demo: " + ex.Message;
        }
    }

    private string GetLocalCampusResourceFallback(string category)
    {
        string c = category.ToLower();

        if (c == "stress")
            return "Counseling Services - Student Services Building.";
        else if (c == "tutoring")
            return "Academic Support Center - Tutoring and study help.";
        else if (c == "career")
            return "Career Services - Resume review and internship support.";
        else
            return "General Student Support Desk for category: " + category;
    }

    private string GenerateCaptchaCode(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random random = new Random();
        char[] code = new char[length];

        for (int i = 0; i < length; i++)
        {
            code[i] = chars[random.Next(chars.Length)];
        }

        return new string(code);
    }
}
