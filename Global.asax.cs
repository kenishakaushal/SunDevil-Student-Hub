using System;
using System.Web;

namespace SunDevilStudentHub
{
    public class Global : HttpApplication
    {
        // Application_Start: runs once when the application first starts
        void Application_Start(object sender, EventArgs e)
        {
            // Store the application start time
            Application["AppStartTime"] = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");

            // Initialize a global hit counter
            Application["HitCounter"] = 0;

            // Initialize active session counter
            Application["ActiveSessions"] = 0;
        }

        // Session_Start: runs every time a new user session begins
        void Session_Start(object sender, EventArgs e)
        {
            // Increment active session counter
            Application.Lock();
            Application["ActiveSessions"] = (int)Application["ActiveSessions"] + 1;
            Application["HitCounter"] = (int)Application["HitCounter"] + 1;
            Application.UnLock();

            // Initialize session defaults
            Session["UserName"] = null;
            Session["UserRole"] = null;
        }

        // Session_End: runs when a session expires
        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            int count = (int)Application["ActiveSessions"];
            if (count > 0)
                Application["ActiveSessions"] = count - 1;
            Application.UnLock();
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Optionally log errors here
        }
    }
}
