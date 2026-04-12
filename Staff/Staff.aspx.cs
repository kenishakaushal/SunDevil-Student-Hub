using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Xml;

namespace SunDevilStudentHub.Staff
{
    public partial class StaffPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is authenticated and has Staff role
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Staff")
            {
                Response.Redirect("~/Login.aspx?role=Staff");
                return;
            }

            if (!IsPostBack)
            {
                string username = Session["UserName"] != null ? Session["UserName"].ToString() : "Staff";
                lblGreeting.Text = "Logged in as: <b>" + Server.HtmlEncode(username) + "</b> (Staff)";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        // Load registered members from Member.xml
        protected void btnLoadMembers_Click(object sender, EventArgs e)
        {
            string xmlPath = Server.MapPath("~/App_Data/Member.xml");
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(xmlPath);

                if (ds.Tables.Count > 0 && ds.Tables["member"] != null && ds.Tables["member"].Rows.Count > 0)
                {
                    gvMembers.DataSource = ds.Tables["member"];
                    gvMembers.DataBind();
                    lblMemberStatus.Text = ds.Tables["member"].Rows.Count + " member(s) found.";
                }
                else
                {
                    gvMembers.DataSource = null;
                    gvMembers.DataBind();
                    lblMemberStatus.Text = "No registered members yet.";
                }
            }
            catch (Exception ex)
            {
                lblMemberStatus.Text = "Error loading members: " + ex.Message;
            }
        }

        // Load announcements from Announcements.xml
        protected void btnLoadAnnouncements_Click(object sender, EventArgs e)
        {
            string xmlPath = Server.MapPath("~/App_Data/Announcements.xml");
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(xmlPath);

                if (ds.Tables.Count > 0 && ds.Tables["announcement"] != null)
                {
                    gvAnnouncements.DataSource = ds.Tables["announcement"];
                    gvAnnouncements.DataBind();
                }
                else
                {
                    gvAnnouncements.DataSource = null;
                    gvAnnouncements.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblAnnouncementStatus.Text = "Error: " + ex.Message;
            }
        }

        // Add a new announcement to Announcements.xml
        protected void btnAddAnnouncement_Click(object sender, EventArgs e)
        {
            string title = txtAnnouncementTitle.Text.Trim();
            string message = txtAnnouncementMsg.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(message))
            {
                lblAnnouncementStatus.ForeColor = System.Drawing.Color.Red;
                lblAnnouncementStatus.Text = "Both title and message are required.";
                return;
            }

            string xmlPath = Server.MapPath("~/App_Data/Announcements.xml");
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);

                XmlElement announcementEl = doc.CreateElement("announcement");

                XmlElement titleEl = doc.CreateElement("title");
                titleEl.InnerText = title;
                announcementEl.AppendChild(titleEl);

                XmlElement msgEl = doc.CreateElement("message");
                msgEl.InnerText = message;
                announcementEl.AppendChild(msgEl);

                doc.DocumentElement.AppendChild(announcementEl);
                doc.Save(xmlPath);

                lblAnnouncementStatus.ForeColor = System.Drawing.Color.Green;
                lblAnnouncementStatus.Text = "Announcement added successfully.";
                txtAnnouncementTitle.Text = "";
                txtAnnouncementMsg.Text = "";

                // Reload
                btnLoadAnnouncements_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblAnnouncementStatus.ForeColor = System.Drawing.Color.Red;
                lblAnnouncementStatus.Text = "Error: " + ex.Message;
            }
        }

        // Test CampusResourceService from staff page
        protected void btnTestService_Click(object sender, EventArgs e)
        {
            string category = txtCategory.Text.Trim();
            var service = new Services.CampusResourceService();
            string result = service.GetCampusResource(category);
            lblServiceOutput.Text = "Result: " + Server.HtmlEncode(result);
        }
    }
}
