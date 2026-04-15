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
            string result = CampusResourceService.GetCampusResource(category);
            lblServiceOutput.Text = "Service Output: " + result;
        }
        catch (Exception ex)
        {
            lblServiceOutput.Text = "Error calling service: " + ex.Message;
        }
    }
}
