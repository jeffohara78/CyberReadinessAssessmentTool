using System;
using System.Collections.Generic;

namespace CyberReadinessAssessmentTool
{
    public class ReadinessAssessmentManager
    {
        private List<AssessmentQuestion> questions = new List<AssessmentQuestion>();

        public ReadinessAssessmentManager()
        {
            LoadAssessmentQuestions();
        }

        public void StartAssessment()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("      CYBER READINESS ASSESSMENT");
            Console.WriteLine("======================================");
            Console.WriteLine("This assessment asks a series of questions");
            Console.WriteLine("about basic cybersecurity practices.");
            Console.WriteLine();
            Console.WriteLine("Your answers will be used to calculate a");
            Console.WriteLine("cyber readiness score and provide improvement");
            Console.WriteLine("recommendations.");
            Console.WriteLine();
            Console.WriteLine("Answer each question using:");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. Partially");
            Console.WriteLine("3. No");
            Console.WriteLine("0. Cancel assessment");
            Console.WriteLine();

            int earnedPoints = 0;
            int totalPossiblePoints = 0;
            List<string> recommendations = new List<string>();

            foreach (AssessmentQuestion question in questions)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Category: {question.Category}");
                Console.WriteLine($"Question {question.QuestionId}: {question.QuestionText}");
                Console.WriteLine();

                int answer = GetAnswerFromUser();

                if (answer == 0)
                {
                    Console.WriteLine("Assessment cancelled. No score was generated.");
                    return;
                }

                totalPossiblePoints += question.Weight;

                if (answer == 1)
                {
                    earnedPoints += question.Weight;
                }
                else if (answer == 2)
                {
                    earnedPoints += question.Weight / 2;
                    recommendations.Add(GetRecommendation(question));
                }
                else if (answer == 3)
                {
                    recommendations.Add(GetRecommendation(question));
                }
            }

            AssessmentResult result = CalculateResult(
                earnedPoints,
                totalPossiblePoints,
                recommendations
            );

            DisplayAssessmentResult(result);
        }

        public void ViewQuestionList()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("        ASSESSMENT QUESTION LIST");
            Console.WriteLine("======================================");

            foreach (AssessmentQuestion question in questions)
            {
                Console.WriteLine($"\nQuestion ID: {question.QuestionId}");
                Console.WriteLine($"Category: {question.Category}");
                Console.WriteLine($"Question: {question.QuestionText}");
                Console.WriteLine($"Weight: {question.Weight}");
            }
        }

        private void LoadAssessmentQuestions()
        {
            questions.Add(new AssessmentQuestion(
                1,
                "Access Control",
                "Does the organization require multi-factor authentication for important accounts?",
                10));

            questions.Add(new AssessmentQuestion(
                2,
                "Password Security",
                "Does the organization require strong passwords or passphrases?",
                8));

            questions.Add(new AssessmentQuestion(
                3,
                "Backups",
                "Does the organization regularly back up important data?",
                10));

            questions.Add(new AssessmentQuestion(
                4,
                "Backup Testing",
                "Does the organization test backups to make sure data can be restored?",
                10));

            questions.Add(new AssessmentQuestion(
                5,
                "Security Updates",
                "Are computers, servers, and applications kept up to date with security patches?",
                10));

            questions.Add(new AssessmentQuestion(
                6,
                "Employee Training",
                "Do employees receive cybersecurity awareness training?",
                8));

            questions.Add(new AssessmentQuestion(
                7,
                "Incident Response",
                "Does the organization have a plan for responding to cybersecurity incidents?",
                10));

            questions.Add(new AssessmentQuestion(
                8,
                "Antivirus / Endpoint Protection",
                "Are company devices protected with antivirus or endpoint security software?",
                8));

            questions.Add(new AssessmentQuestion(
                9,
                "Data Protection",
                "Is sensitive business or customer data protected from unauthorized access?",
                10));

            questions.Add(new AssessmentQuestion(
                10,
                "Vendor Risk",
                "Does the organization review third-party vendors that access systems or data?",
                6));
        }

        private int GetAnswerFromUser()
        {
            while (true)
            {
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. Partially");
                Console.WriteLine("3. No");
                Console.WriteLine("0. Cancel assessment");
                Console.Write("Choose option 0 through 3: ");

                string input = Console.ReadLine();

                bool isValidNumber = int.TryParse(input, out int answer);

                if (isValidNumber && answer >= 0 && answer <= 3)
                {
                    return answer;
                }

                Console.WriteLine("Invalid input. Please choose 0, 1, 2, or 3.");
            }
        }

        private AssessmentResult CalculateResult(
            int earnedPoints,
            int totalPossiblePoints,
            List<string> recommendations)
        {
            AssessmentResult result = new AssessmentResult();

            result.EarnedPoints = earnedPoints;
            result.TotalPossiblePoints = totalPossiblePoints;

            result.ReadinessScore = totalPossiblePoints > 0
                ? ((decimal)earnedPoints / totalPossiblePoints) * 100
                : 0;

            if (result.ReadinessScore >= 85)
            {
                result.ReadinessLevel = "Strong";
            }
            else if (result.ReadinessScore >= 70)
            {
                result.ReadinessLevel = "Moderate";
            }
            else if (result.ReadinessScore >= 50)
            {
                result.ReadinessLevel = "Needs Improvement";
            }
            else
            {
                result.ReadinessLevel = "High Risk";
            }

            result.Recommendations = recommendations;

            return result;
        }

        private string GetRecommendation(AssessmentQuestion question)
        {
            if (question.Category == "Access Control")
            {
                return "Enable multi-factor authentication for important accounts.";
            }
            else if (question.Category == "Password Security")
            {
                return "Create and enforce a strong password or passphrase policy.";
            }
            else if (question.Category == "Backups")
            {
                return "Implement regular backups for critical business data.";
            }
            else if (question.Category == "Backup Testing")
            {
                return "Test backup restoration regularly to confirm data can be recovered.";
            }
            else if (question.Category == "Security Updates")
            {
                return "Create a patching process for computers, servers, and applications.";
            }
            else if (question.Category == "Employee Training")
            {
                return "Provide regular cybersecurity awareness training for employees.";
            }
            else if (question.Category == "Incident Response")
            {
                return "Create an incident response plan for security events.";
            }
            else if (question.Category == "Antivirus / Endpoint Protection")
            {
                return "Deploy endpoint protection or antivirus software on company devices.";
            }
            else if (question.Category == "Data Protection")
            {
                return "Limit access to sensitive data and review permissions regularly.";
            }
            else if (question.Category == "Vendor Risk")
            {
                return "Review vendors that access company systems, data, or services.";
            }

            return "Review this area and create a cybersecurity improvement plan.";
        }

        private void DisplayAssessmentResult(AssessmentResult result)
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("        ASSESSMENT RESULTS");
            Console.WriteLine("======================================");
            Console.WriteLine($"Points Earned: {result.EarnedPoints}");
            Console.WriteLine($"Total Possible Points: {result.TotalPossiblePoints}");
            Console.WriteLine($"Readiness Score: {result.ReadinessScore:F1}%");
            Console.WriteLine($"Readiness Level: {result.ReadinessLevel}");
            Console.WriteLine();

            Console.WriteLine("--- Summary ---");

            if (result.ReadinessLevel == "Strong")
            {
                Console.WriteLine("The organization appears to have a strong cybersecurity foundation.");
            }
            else if (result.ReadinessLevel == "Moderate")
            {
                Console.WriteLine("The organization has a reasonable foundation but still has areas to improve.");
            }
            else if (result.ReadinessLevel == "Needs Improvement")
            {
                Console.WriteLine("The organization has several cybersecurity gaps that should be addressed.");
            }
            else
            {
                Console.WriteLine("The organization may be exposed to significant cybersecurity risk.");
            }

            Console.WriteLine();

            Console.WriteLine("--- Recommendations ---");

            if (result.Recommendations.Count == 0)
            {
                Console.WriteLine("No major recommendations were generated.");
            }
            else
            {
                foreach (string recommendation in result.Recommendations)
                {
                    Console.WriteLine($"- {recommendation}");
                }
            }
        }
    }
}