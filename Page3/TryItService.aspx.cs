using System;

public partial class Page3_TryItService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblServiceOutput.Text = "";
        }
    }

    protected void btnCallService_Click(object sender, EventArgs e)
    {
        string category = txtCategory.Text.Trim();

        if (string.IsNullOrEmpty(category))
        {
            lblServiceOutput.Text = "Please enter a category (e.g., Stress, Tutoring, Career, Health, Writing).";
            return;
        }

        try
        {
            // Call the campus resource service
            // If deployed as .svc, replace with service reference client call:
            // CampusResourceServiceClient client = new CampusResourceServiceClient();
            // string result = client.GetCampusResource(category);

            string result = GetCampusResource(category);
            lblServiceOutput.Text = "Service Output: " + result;
        }
        catch (Exception ex)
        {
            lblServiceOutput.Text = "Error calling service: " + ex.Message;
        }
    }

    /// <summary>
    /// Campus Resource Service logic — Kenisha Kaushal
    /// Returns a campus support resource based on the input category.
    /// This method represents the service operation GetCampusResource(string category).
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
}
