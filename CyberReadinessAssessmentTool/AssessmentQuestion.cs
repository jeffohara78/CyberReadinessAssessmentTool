using System.Security.Cryptography.X509Certificates;

namespace CyberReadinessAssessmentTool
{
    public class AssessmentQuestion
    { 
        public int QuestionId { get; set; }

        public string Category { get; set; }

        public string QuestionText { get; set; }

        public int Weight { get; set; }

        public AssessmentQuestion(int questionId, string category, string questionText, int weight)
        { 
            QuestionId = questionId;
            Category = category;
            QuestionText = questionText;
            Weight = weight;
        }
    }
}