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
            string result = GetCampusResource(category);
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
            // Store values in Session — Kenisha's state management component
            Session["UserName"] = "DemoUser_Kenisha";
            Session["Role"] = "Member";
            Session["LastAccess"] = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");

            // Store preferred category in Cookie
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
                cookieValue = "Tutoring (will appear on next request)";
            }

            lblSessionCookieOutput.Text =
                "Session[UserName] = " + Session["UserName"] +
                " | Session[Role] = " + Session["Role"] +
                " | Session[LastAccess] = " + Session["LastAccess"] +
                " | Cookie[PreferredCategory] = " + cookieValue +
                "<br/><br/>Full demo available at: <a href='../Page1/SessionManager.aspx'>Session Manager Page</a>";
        }
        catch (Exception ex)
        {
            lblSessionCookieOutput.Text = "Error in session/cookie demo: " + ex.Message;
        }
    }

    /// <summary>
    /// Campus Resource Service — Kenisha Kaushal
    /// Returns a campus support resource based on the input category.
    /// </summary>
    private string GetCampusResource(string category)
    {
        switch (category.Trim().ToLower())
        {
            case "stress":
                return "Counseling Services — Student Center, Room 320. Free sessions for all enrolled students.";
            case "tutoring":
                return "Academic Success Center — Hayden Library, 2nd Floor. Drop-in tutoring Mon–Fri 9AM–5PM.";
            case "career":
                return "Career and Professional Development — University Center, Suite 411. Resume reviews and mock interviews.";
            case "health":
                return "ASU Health Services — Taylor Place, Building B. Open Mon–Fri 8AM–5PM.";
            case "writing":
                return "Writing Center — Ross-Blakley Hall, Room 105. Schedule online or walk in.";
            case "finance":
                return "Financial Aid Office — Student Services Building, Room 120. FAFSA help and scholarship info.";
            case "technology":
                return "MyASU IT Help Desk — Computing Commons, 1st Floor. Tech support and loaner laptops.";
            case "fitness":
                return "Sun Devil Fitness Complex — Apache Blvd. Free gym access for students with valid ID.";
            case "housing":
                return "University Housing — Residential Life Office, Manzanita Hall. Housing applications and roommate help.";
            case "disability":
                return "Student Accessibility and Inclusive Learning Services (SAILS) — University Center, Suite 160.";
            default:
                return "Resource not found for category: '" + category +
                    "'. Try: Stress, Tutoring, Career, Health, Writing, Finance, Technology, Fitness, Housing, or Disability.";
        }
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
