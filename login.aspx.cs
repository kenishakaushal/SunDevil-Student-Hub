using System;
using System.Web;
using System.Xml;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["role"] != null)
            {
                string role = Request.QueryString["role"];
                if (role == "Staff")
                    ddlRole.SelectedValue = "Staff";
                else
                    ddlRole.SelectedValue = "Member";
            }

            if (Request.Cookies["RememberedUser"] != null)
            {
                txtUsername.Text = Request.Cookies["RememberedUser"].Value;
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string role = ddlRole.SelectedValue;
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();

        if (username == "" || password == "")
        {
            lblMessage.Text = "Please enter username and password.";
            return;
        }

        if (role == "Member")
        {
            if (ValidateMember(username, password))
            {
                Session["UserName"] = username;
                Session["UserRole"] = "Member";

                if (chkRemember.Checked)
                {
                    HttpCookie ck = new HttpCookie("RememberedUser");
                    ck.Value = username;
                    ck.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(ck);
                }

                Response.Redirect("~/Member/Member.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid member username or password.";
            }
        }
        else
        {
            if (ValidateStaff(username, password))
            {
                Session["UserName"] = username;
                Session["UserRole"] = "Staff";
                Response.Redirect("~/Staff/Staff.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid staff username or password.";
            }
        }
    }

    private bool ValidateMember(string username, string password)
    {
        string filePath = Server.MapPath("~/App_Data/Member.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(filePath);

        string hashedPassword = SecurityHelper.HashPassword(password);

        XmlNodeList members = doc.SelectNodes("/members/member");
        foreach (XmlNode member in members)
        {
            string xmlUser = member["username"] != null ? member["username"].InnerText : "";
            string xmlHash = member["passwordHash"] != null ? member["passwordHash"].InnerText : "";

            if (xmlUser == username && xmlHash == hashedPassword)
                return true;
        }

        return false;
    }

    private bool ValidateStaff(string username, string password)
    {
        string filePath = Server.MapPath("~/App_Data/Staff.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(filePath);

        string hashedPassword = SecurityHelper.HashPassword(password);

        XmlNodeList staffMembers = doc.SelectNodes("/staffMembers/staff");
        foreach (XmlNode staff in staffMembers)
        {
            string xmlUser = staff["username"] != null ? staff["username"].InnerText : "";
            string xmlHash = staff["passwordHash"] != null ? staff["passwordHash"].InnerText : "";

            if (xmlUser == username && xmlHash == hashedPassword)
                return true;
        }

        return false;
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Member/Register.aspx");
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}
