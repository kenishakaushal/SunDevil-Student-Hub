using System;
using System.Web;

public partial class Member_Member : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["UserRole"] == null || Session["UserRole"].ToString() != "Member")
        {
            Response.Redirect("~/Login.aspx?role=Member");
            return;
        }

        if (!IsPostBack)
        {
            string username = Session["UserName"].ToString();
            lblWelcome.Text = "Hello, " + username + ". You are logged in as a member.";

            string cookieInfo = "No preferred user cookie found.";
            if (Request.Cookies["RememberedUser"] != null)
            {
                cookieInfo = "Remembered username cookie: " + Request.Cookies["RememberedUser"].Value;
            }

            lblStateInfo.Text = "Session User = " + username + " | " + cookieInfo;
            lblStudyTipResult.Text = "";
            lblResourceResult.Text = "";
        }
    }

    protected void btnStudyTip_Click(object sender, EventArgs e)
    {
        string subject = txtStudySubject.Text.Trim();
        if (subject == "")
        {
            lblStudyTipResult.Text = "Please enter a subject.";
            return;
        }

        try
        {
            // Replace with your real service call later
            lblStudyTipResult.Text = GetLocalStudyTipFallback(subject);
        }
        catch (Exception ex)
        {
            lblStudyTipResult.Text = "Error calling study tip service: " + ex.Message;
        }
    }

    protected void btnResource_Click(object sender, EventArgs e)
    {
        string category = txtCategory.Text.Trim();
        if (category == "")
        {
            lblResourceResult.Text = "Please enter a category.";
            return;
        }

        try
        {
            // Replace with Kenisha's real service call later
            lblResourceResult.Text = GetLocalCampusResourceFallback(category);
        }
        catch (Exception ex)
        {
            lblResourceResult.Text = "Error calling campus resource service: " + ex.Message;
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();

        if (Request.Cookies["RememberedUser"] != null)
        {
            HttpCookie ck = new HttpCookie("RememberedUser");
            ck.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ck);
        }

        Response.Redirect("~/Default.aspx");
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    private string GetLocalStudyTipFallback(string subject)
    {
        string s = subject.ToLower();

        if (s == "math")
            return "Practice 5 problems and review each mistake carefully.";
        else if (s == "programming")
            return "Break the problem into functions and test each one.";
        else if (s == "science")
            return "Review core concepts first, then memorize definitions.";
        else
            return "Create a short review plan for " + subject + ".";
    }

    private string GetLocalCampusResourceFallback(string category)
    {
        string c = category.ToLower();

        if (c == "stress")
            return "Suggested resource: Counseling Services.";
        else if (c == "tutoring")
            return "Suggested resource: Academic Tutoring Center.";
        else if (c == "career")
            return "Suggested resource: Career Development Office.";
        else
            return "Suggested resource: General Student Support for " + category + ".";
    }
}
