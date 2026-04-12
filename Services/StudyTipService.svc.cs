using System.ServiceModel;

namespace SunDevilStudentHub.Services
{
    /// <summary>
    /// Returns study tips based on subject.
    /// Developed by: Ishita Bansal
    /// </summary>
    public class StudyTipService : IStudyTipService
    {
        public string GetStudyTip(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
                return "Please provide a subject (e.g., Math, Science, History, Programming).";

            switch (subject.Trim().ToLower())
            {
                case "math":
                    return "Practice 5 problems daily and review your mistakes carefully.";
                case "science":
                    return "Use diagrams and flashcards to memorize key concepts.";
                case "history":
                    return "Create timelines to connect events and understand cause-effect.";
                case "programming":
                    return "Code every day, even 30 minutes. Build small projects to reinforce concepts.";
                case "english":
                    return "Read actively and annotate. Practice writing summaries of what you read.";
                case "physics":
                    return "Focus on understanding formulas, not memorizing. Solve varied problems.";
                case "chemistry":
                    return "Practice balancing equations and understand reaction types thoroughly.";
                default:
                    return "General tip: Break study sessions into 25-minute blocks with 5-minute breaks (Pomodoro Technique).";
            }
        }
    }
}
