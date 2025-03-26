using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.PresentationLayer.Controllers;

namespace StudentManagement.PresentationLayer.Views
{
    public class MenuView
    {
        private readonly StudentController _studentController;
        public MenuView(StudentController studentController)
        {
            _studentController = studentController;
        }
        public void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("STUDENT MANAGEMENT");
                Console.WriteLine("1. View student list");
                Console.WriteLine("2. Add new student");
                Console.WriteLine("3. Update student information");
                Console.WriteLine("4. Delete student");
                Console.WriteLine("5. Exit");
                Console.Write("Select function: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _studentController.DisplayAllStudents();
                        break;
                    case "2":
                        _studentController.AddStudent();
                        break;
                    case "3":
                        _studentController.UpdateStudent();
                        break;
                    case "4":
                        _studentController.DeleteStudent();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection!");
                        break;
                }
            }
        }
    }
}
