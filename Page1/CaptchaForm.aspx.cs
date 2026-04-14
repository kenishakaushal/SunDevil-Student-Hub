using System;

public partial class Page1_CaptchaForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateNewCaptcha();
            lblCaptchaOutput.Text = "";
        }
    }

    protected void btnValidateCaptcha_Click(object sender, EventArgs e)
    {
        string enteredCaptcha = txtCaptchaInput.Text.Trim();
        string actualCaptcha = Session["CaptchaCode"] != null
            ? Session["CaptchaCode"].ToString()
            : "";

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

        txtCaptchaInput.Text = "";
        GenerateNewCaptcha();
    }

    protected void btnRefreshCaptcha_Click(object sender, EventArgs e)
    {
        txtCaptchaInput.Text = "";
        lblCaptchaOutput.Text = "Captcha refreshed.";
        GenerateNewCaptcha();
    }

    private void GenerateNewCaptcha()
    {
        string newCaptcha = GenerateCaptchaCode(5);
        Session["CaptchaCode"] = newCaptcha;
        lblCaptchaDisplay.Text = newCaptcha;
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
