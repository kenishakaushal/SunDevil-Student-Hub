using System;
using System.Web.UI;

namespace SunDevilStudentHub.Controls
{
    public partial class CaptchaControl : UserControl
    {
        // Public property so parent pages can check if CAPTCHA passed
        public bool IsVerified
        {
            get
            {
                if (ViewState["CaptchaVerified"] != null)
                    return (bool)ViewState["CaptchaVerified"];
                return false;
            }
            private set
            {
                ViewState["CaptchaVerified"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateNewCaptcha();
            }
        }

        // Generate a random 5-character alphanumeric code
        private void GenerateNewCaptcha()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            Random rng = new Random();
            char[] code = new char[5];
            for (int i = 0; i < 5; i++)
            {
                code[i] = chars[rng.Next(chars.Length)];
            }
            string captchaCode = new string(code);

            // Store in ViewState so it persists across postbacks
            ViewState["CaptchaCode"] = captchaCode;
            lblCaptchaCode.Text = captchaCode;

            // Reset verification state
            IsVerified = false;
            lblCaptchaResult.Text = "";
            txtCaptchaInput.Text = "";
        }

        protected void btnVerifyCaptcha_Click(object sender, EventArgs e)
        {
            string expected = ViewState["CaptchaCode"] as string;
            string entered = txtCaptchaInput.Text.Trim().ToUpper();

            if (!string.IsNullOrEmpty(expected) && entered == expected)
            {
                IsVerified = true;
                lblCaptchaResult.Text = "✔ CAPTCHA PASSED";
                lblCaptchaResult.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                IsVerified = false;
                lblCaptchaResult.Text = "✘ CAPTCHA FAILED — Try again";
                lblCaptchaResult.ForeColor = System.Drawing.Color.Red;
                // Generate a new code on failure
                GenerateNewCaptcha();
            }
        }

        protected void btnRefreshCaptcha_Click(object sender, EventArgs e)
        {
            GenerateNewCaptcha();
        }
    }
}
