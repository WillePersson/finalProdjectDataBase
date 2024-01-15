using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finalProdjectDataBase.Models;
using Spectre.Console;

namespace finalProdjectDataBase
{
    internal class MenuHandler
    {
        private readonly EntityFramework entityFrameworkInstance;

        public MenuHandler()
        {
            
            FiktivSkolaContext dbContext = new FiktivSkolaContext(); 
            entityFrameworkInstance = new EntityFramework(dbContext);
        }
        public void Run()
        {
            while (true)
            {
                var selectedOption = GetUserSelection();

                ProcessSelectedOption(selectedOption);

                if (selectedOption.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }

        private string GetUserSelection()
        {
            var selectedOption = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Console Menu")
                .PageSize(10)
                .AddChoices(
                    "Show Personal",
                    "Add Personal",
                    "Save Student",
                    "Save Grade",
                    "Show Teachers in Department",
                    "Show All Students",
                    "Show All Active Courses",
                    "Department Payout",
                    "Department Average Salary",
                    "Show Student Information",
                    "Set Grade for Student",
                    "Exit")
                .MoreChoicesText("[grey](Use arrow keys to navigate)[/]"));

            return selectedOption?.ToLowerInvariant().Trim();
        }

        private void ProcessSelectedOption(string option)
        {
            AdoCode adoCode = new AdoCode();
            switch (option)
            {
                case "show personal":
                    Console.Clear();
                    adoCode.DisplayPersonalInformation();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case "add personal":
                    Console.Clear();
                    adoCode.AddPersonalInformation();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case "save student":
                    Console.Clear();
                    adoCode.SaveStudent();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case "save grade":
                    Console.Clear();
                    adoCode.SaveGrade();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case "show teachers in department":
                    Console.Clear();
                    entityFrameworkInstance.DisplayTeacherCountsByDepartment();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case "show all students":
                    Console.Clear();
                    EntityFramework.ViewAllStudents();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case "show all active courses":
                    Console.Clear();
                    entityFrameworkInstance.ShowAllActiveCourses();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case "department payout":
                    Console.Clear();
                    adoCode.CalculateDepartmentPayout();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case "department average salary":
                    Console.Clear();
                    adoCode.CalculateDepartmentAverageSalary();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case "show student information":
                    Console.Clear();
                    int studentId = adoCode.GetStudentIdFromUser();
                    Console.Clear();
                    adoCode.GetStudentInformation(studentId);
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                    

                case "set grade for student":
                    Console.Clear();
                    int studentIdToUpdate = adoCode.GetUserInput("Enter Student ID: ");
                    adoCode.UpdateGradeForStudentWithTransaction(studentIdToUpdate);
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                  
                case "exit":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}

