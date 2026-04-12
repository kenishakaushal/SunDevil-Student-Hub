using System;
using System.Web;

// Replace these namespaces with your actual service references and DLL namespace
// using Group19Project.SecurityLib;
// using Group19Project.IshitaStudyTipServiceRef;
// using Group19Project.KenishaCampusResourceServiceRef;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblHashOutput.Text = "";
            lblStudyTipOutput.Text = "";
            lblCampusResourceOutput.Text = "";
            lblSessionCookieOutput.Text = "";

            // Optional: show info from existing session/cookie if available
            if (Session["UserName"] != null)
            {
                lblSessionCookieOutput.Text = "Current Session User: " + Session["UserName"].ToString();
            }
        }
    }

    protected void btnMemberPage_Click(object sender, EventArgs e)
    {
        // Assignment 5 only needs button/link presence.
        // Later for Assignment 6, update logic for login redirection.
        Response.Redirect("~/Member/Member.aspx");
    }

    protected void btnStaffPage_Click(object sender, EventArgs e)
    {
        // Assignment 5 only needs button/link presence.
        // Later for Assignment 6, update logic for login redirection.
        Response.Redirect("~/Staff/Staff.aspx");
    }

    protected void btnHashPassword_Click(object sender, EventArgs e)
    {
        string input = txtPasswordToHash.Text.Trim();

        if (input == "")
        {
            lblHashOutput.Text = "Please enter a password first.";
            return;
        }

        try
        {
            // Replace this line with your actual DLL call
            // Example:
            // string hashedValue = SecurityHelper.HashPassword(input);

            string hashedValue = "SampleHashedValue_ForNow_" + input.GetHashCode().ToString();

            lblHashOutput.Text = "Hashed Output: " + hashedValue;
        }
        catch (Exception ex)
        {
            lblHashOutput.Text = "Error while hashing: " + ex.Message;
        }
    }

    protected void btnStudyTip_Click(object sender, EventArgs e)
    {
        string subject = txtStudySubject.Text.Trim();

        if (subject == "")
        {
            lblStudyTipOutput.Text = "Please enter a subject first.";
            return;
        }

        try
        {
            // Replace with actual service call
            // Example:
            // StudyTipServiceClient client = new StudyTipServiceClient();
            // string result = client.GetStudyTip(subject);

            string result = GetLocalStudyTipFallback(subject);

            lblStudyTipOutput.Text = "Service Output: " + result;
        }
        catch (Exception ex)
        {
            lblStudyTipOutput.Text = "Error calling Study Tip service: " + ex.Message;
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
            // Replace with actual service call
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
            Session["UserName"] = "DemoUser_Ishita";
            Session["Role"] = "Member";

            HttpCookie demoCookie = new HttpCookie("PreferredCategory");
            demoCookie.Value = "Math";
            demoCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(demoCookie);

            string cookieValue = "";
            if (Request.Cookies["PreferredCategory"] != null)
            {
                cookieValue = Request.Cookies["PreferredCategory"].Value;
            }
            else
            {
                cookieValue = "Math (will appear on next request if not immediately visible)";
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

    // Temporary local fallback logic so page can run before services are fully wired
    private string GetLocalStudyTipFallback(string subject)
    {
        string s = subject.ToLower();

        if (s == "math")
            return "Practice problems daily and review each mistake.";
        else if (s == "programming")
            return "Write code by hand first, then test small parts.";
        else if (s == "science")
            return "Focus on concepts first, then memorize key terms.";
        else
            return "Build a short daily review routine for " + subject + ".";
    }

    private string GetLocalCampusResourceFallback(string category)
    {
        string c = category.ToLower();

        if (c == "stress")
            return "Counseling Services - Student Center.";
        else if (c == "tutoring")
            return "Academic Support / Tutoring Center.";
        else if (c == "career")
            return "Career Services - Resume and internship support.";
        else
            return "General Student Support Desk for category: " + category;
    }
}
