using System.Collections.Generic;

namespace CyberReadinessAssessmentTool
{
    public class AssessmentResult
    { 
        public int TotalPossiblePoints { get; set; }

        public int EarnedPoints { get; set; }

        public decimal ReadinessScore { get; set; }

        public string ReadinessLevel { get; set; }

        public List<string> Recommendations { get; set; }

        public AssessmentResult()
        {
            Recommendations = new List<string>();
        }
    }
}