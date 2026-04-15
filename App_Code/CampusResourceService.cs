using System;

/// <summary>
/// Campus Resource Service — Kenisha Kaushal
/// A reusable service component that returns ASU campus support resources
/// based on the input category. This class can be called from any ASPX page
/// or wrapped into a WCF/WSDL service endpoint.
/// </summary>
public class CampusResourceService
{
    /// <summary>
    /// Returns a campus support resource description based on the given category.
    /// </summary>
    /// <param name="category">The resource category (e.g., Stress, Tutoring, Career)</param>
    /// <returns>A string describing the matching campus resource</returns>
    public static string GetCampusResource(string category)
    {
        if (string.IsNullOrEmpty(category))
        {
            return "No category provided. Try: Stress, Tutoring, Career, Health, Writing, Finance, Technology, Fitness, Housing, or Disability.";
        }

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
