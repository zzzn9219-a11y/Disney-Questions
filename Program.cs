using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace DisneyQuiz
{
    // Record structure for questions
    public record Question(string QuestionText, string Answer);

    class Program
    {
        static void Main(string[] args)
        {
            // Set EPPlus license context for non-commercial use
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Get filename and path
            string fileName = GetFileName();
            
            // Load all questions from file
            List<Question> questions = LoadQuestions(fileName);
            
            if (questions.Count == 0)
            {
                Console.WriteLine("No questions found in the file.");
                return;
            }

            // Pick 5 random questions and display quiz
            RunQuiz(questions);
        }

        /// <summary>
        /// Subroutine to get the filename and path for the DisneyQuestions.csv file
        /// </summary>
        static string GetFileName()
        {
            // Default filename
            string fileName = "DisneyQuestions.xlsx";

            // Check if file exists in current directory
            if (File.Exists(fileName))
            {
                return fileName;
            }

            // Check in project directory (go up from bin/Debug/net6.0 to project root)
            string projectPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", fileName);
            if (File.Exists(projectPath))
            {
                return Path.GetFullPath(projectPath);
            }

            // Prompt user for file path if not found
            Console.WriteLine($"File '{fileName}' not found in current or project directory.");
            Console.Write("Please enter the full path to DisneyQuestions.xlsx: ");
            string userPath = Console.ReadLine();

            return userPath;
        }

        /// <summary>
        /// Subroutine to get all questions from the file and store in a list
        /// </summary>
        static List<Question> LoadQuestions(string fileName)
        {
            List<Question> questions = new List<Question>();

            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension?.Rows ?? 0;

                    // Read all questions from the Excel file
                    for (int row = 1; row <= rowCount; row++)
                    {
                        string questionText = worksheet.Cells[row, 1].Value?.ToString();
                        string answer = worksheet.Cells[row, 2].Value?.ToString();

                        if (!string.IsNullOrWhiteSpace(questionText) && !string.IsNullOrWhiteSpace(answer))
                        {
                            questions.Add(new Question(questionText, answer.Trim().ToLower()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return questions;
        }

        /// <summary>
        /// Subroutine to pick a question at random from the list and display on screen
        /// Gets and checks answer, updates the score and displays result
        /// Ensures no question is picked more than once
        /// </summary>
        static void RunQuiz(List<Question> allQuestions)
        {
            const int TOTAL_QUESTIONS = 5;
            int score = 0;
            
            // Create a copy of the questions list to track which ones have been used
            List<Question> availableQuestions = new List<Question>(allQuestions);
            Random random = new Random();

            Console.WriteLine("=== Disney Quiz ===");
            Console.WriteLine($"Answer {TOTAL_QUESTIONS} questions about Disney!\n");

            // Ask 5 questions
            for (int i = 1; i <= TOTAL_QUESTIONS; i++)
            {
                // Pick a random question from available questions
                int randomIndex = random.Next(availableQuestions.Count);
                Question currentQuestion = availableQuestions[randomIndex];
                
                // Remove the question so it won't be picked again
                availableQuestions.RemoveAt(randomIndex);

                // Display question
                Console.WriteLine($"Question {i}: {currentQuestion.QuestionText}");
                Console.Write("Your answer: ");
                string userAnswer = Console.ReadLine()?.Trim().ToLower() ?? "";

                // Check answer
                if (userAnswer == currentQuestion.Answer)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Wrong! The correct answer was: {currentQuestion.Answer}\n");
                }
            }

            // Display final score
            Console.WriteLine("=== Quiz Complete ===");
            Console.WriteLine($"Final Score: {score} out of {TOTAL_QUESTIONS}");
            
            // Additional feedback based on score
            if (score == TOTAL_QUESTIONS)
            {
                Console.WriteLine("Perfect! You're a Disney expert!");
            }
            else if (score >= 3)
            {
                Console.WriteLine("Good job! You know your Disney!");
            }
            else
            {
                Console.WriteLine("Keep watching Disney movies!");
            }
        }
    }
}