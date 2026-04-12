using System.ServiceModel;

namespace SunDevilStudentHub.Services
{
    public class CampusResourceService : ICampusResourceService
    {
        /// <summary>
        /// Returns a campus resource recommendation based on the given category.
        /// Developed by: Kenisha Kaushal
        /// </summary>
        /// <param name="category">Category such as Stress, Math, Writing, Health, Career</param>
        /// <returns>A string describing the recommended campus resource</returns>
        public string GetCampusResource(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return "Please provide a category (e.g., Stress, Math, Writing, Health, Career).";

            switch (category.Trim().ToLower())
            {
                case "stress":
                    return "Counseling Services — Student Center, Room 320. Free sessions for all enrolled students.";
                case "math":
                    return "Math Tutoring Center — Hayden Library, 2nd Floor. Drop-in hours Mon–Fri 9AM–5PM.";
                case "writing":
                    return "Writing Center — Ross-Blakley Hall, Room 105. Schedule online or walk in.";
                case "health":
                    return "ASU Health Services — Taylor Place, Building B. Open Mon–Fri 8AM–5PM.";
                case "career":
                    return "Career and Professional Development — University Center, Suite 411. Resume reviews and mock interviews.";
                case "finance":
                    return "Financial Aid Office — Student Services Building, Room 120. FAFSA help and scholarship info.";
                case "technology":
                    return "MyASU IT Help Desk — Computing Commons, 1st Floor. Tech support and loaner laptops.";
                case "fitness":
                    return "Sun Devil Fitness Complex — Apache Blvd. Free gym access for students with valid ID.";
                default:
                    return "Resource not found for category: '" + category + "'. Try: Stress, Math, Writing, Health, Career, Finance, Technology, or Fitness.";
            }
        }
    }
}
