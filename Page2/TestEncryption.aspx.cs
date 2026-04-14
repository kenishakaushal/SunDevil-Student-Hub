using System;
using Group19Project.SecurityLib;

public partial class Page2_TestEncryption : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnHash_Click(object sender, EventArgs e)
    {
        string input = txtInput.Text.Trim();

        if (input == "")
        {
            lblOutput.Text = "Please enter text.";
            return;
        }

        try
        {
            string result = SecurityUtils.HashPassword(input);
            lblOutput.Text = "Hashed Output: " + result;
        }
        catch (Exception ex)
        {
            lblOutput.Text = "Error: " + ex.Message;
        }
    }
}
