using System;
using System.Web;

public partial class Page1_SessionManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RefreshSummaryTable();
        }
    }

    // Store values into Session and Cookie
    protected void btnStoreValues_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string category = txtCategory.Text.Trim();

        if (string.IsNullOrEmpty(username))
        {
            lblStoreResult.Text = "Please enter a username.";
            return;
        }

        // Store in Session
        Session["UserName"] = username;
        Session["Role"] = "Member";
        Session["LastAccess"] = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");

        // Store preferred category in Cookie
        HttpCookie categoryCookie = new HttpCookie("PreferredCategory");
        categoryCookie.Value = string.IsNullOrEmpty(category) ? "General" : category;
        categoryCookie.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(categoryCookie);

        lblStoreResult.Text = "Stored successfully. Session[UserName] = " + username +
            " | Session[Role] = Member" +
            " | Cookie[PreferredCategory] = " + categoryCookie.Value;

        txtUsername.Text = "";
        txtCategory.Text = "";

        RefreshSummaryTable();
    }

    // Retrieve values from Session and Cookie
    protected void btnRetrieveValues_Click(object sender, EventArgs e)
    {
        string sessionUser = Session["UserName"] != null ? Session["UserName"].ToString() : "(not set)";
        string sessionRole = Session["Role"] != null ? Session["Role"].ToString() : "(not set)";
        string sessionAccess = Session["LastAccess"] != null ? Session["LastAccess"].ToString() : "(not set)";

        string cookieCategory = "(not set)";
        if (Request.Cookies["PreferredCategory"] != null)
        {
            cookieCategory = Request.Cookies["PreferredCategory"].Value;
        }

        lblRetrieveResult.Text =
            "Session[UserName] = " + sessionUser +
            "<br/>Session[Role] = " + sessionRole +
            "<br/>Session[LastAccess] = " + sessionAccess +
            "<br/>Cookie[PreferredCategory] = " + cookieCategory;

        RefreshSummaryTable();
    }

    // Clear all Session and Cookie values
    protected void btnClearAll_Click(object sender, EventArgs e)
    {
        // Clear session
        Session.Clear();

        // Expire the cookie
        if (Request.Cookies["PreferredCategory"] != null)
        {
            HttpCookie expiredCookie = new HttpCookie("PreferredCategory");
            expiredCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(expiredCookie);
        }

        lblClearResult.Text = "All Session variables cleared and Cookie expired.";
        lblStoreResult.Text = "";
        lblRetrieveResult.Text = "";

        RefreshSummaryTable();
    }

    // Refresh the summary table
    protected void btnRefreshSummary_Click(object sender, EventArgs e)
    {
        RefreshSummaryTable();
    }

    private void RefreshSummaryTable()
    {
        lblSummarySessionUser.Text = Session["UserName"] != null ? Session["UserName"].ToString() : "(empty)";
        lblSummarySessionRole.Text = Session["Role"] != null ? Session["Role"].ToString() : "(empty)";
        lblSummaryLastAccess.Text = Session["LastAccess"] != null ? Session["LastAccess"].ToString() : "(empty)";

        if (Request.Cookies["PreferredCategory"] != null &&
            !string.IsNullOrEmpty(Request.Cookies["PreferredCategory"].Value))
        {
            lblSummaryCookieCategory.Text = Request.Cookies["PreferredCategory"].Value;
        }
        else
        {
            lblSummaryCookieCategory.Text = "(empty)";
        }
    }
}
