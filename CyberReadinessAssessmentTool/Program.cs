/* Jeff O'Hara
 * 6/10/2026
 * 
 * Evaluates an organization's cybersecurity practices by asking a series of weighted assessment questions covering areas 
 * such as access control, backups, security updates, employee training, and incident response. Based on the responses, 
 * it calculates a readiness score, assigns a risk level, and generates recommendations to help improve the 
 * organization's overall cybersecurity posture. 
 */

using System;

namespace CyberReadinessAssessmentTool
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadinessAssessmentManager manager = new ReadinessAssessmentManager();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("      CYBER READINESS ASSESSMENT TOOL");
                Console.WriteLine("==========================================");
                Console.WriteLine("Assess basic cybersecurity readiness,");
                Console.WriteLine("calculate a score, and generate recommendations.");
                Console.WriteLine();
                Console.WriteLine("1. Start assessment");
                Console.WriteLine("2. View assessment questions");
                Console.WriteLine("3. Exit");
                Console.Write("\nChoose an option 1 through 3: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    manager.StartAssessment();
                }
                else if (choice == "2")
                {
                    manager.ViewQuestionList();
                }
                else if (choice == "3")
                {
                    running = false;
                    Console.WriteLine("Exiting Cyber Readiness Assessment Tool.");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose 1 through 3.");
                }
            }
        }
    }
}