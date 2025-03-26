using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.ApplicationLayer.DTOs;
using StudentManagement.ApplicationLayer.Interfaces;

namespace StudentManagement.PresentationLayer.Controllers
{
    public class StudentController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public void AddStudent()
        {
            Console.WriteLine("\nADD NEW STUDENT");
            var studentDto = new StudentDTO();

            Console.Write("Enter Name: ");
            studentDto.FullName = Console.ReadLine();

            Console.Write("Enter Email: ");
            studentDto.Email = Console.ReadLine();

            Console.Write("Enter Date (dd/MM/yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out var dob))
            {
                studentDto.DateOfBirth = dob;
            }

            Console.Write("Enter Address: ");
            studentDto.Address = Console.ReadLine();

            Console.Write("Enter Phone: ");
            studentDto.PhoneNumber = Console.ReadLine();

            _studentService.AddStudent(studentDto);
            Console.WriteLine("Add student success!");
        }
        public void UpdateStudent()
        {
            Console.Write("\nEnter student ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var student = _studentService.GetStudentById(id);
                if (student != null)
                {
                    var studentDto = new StudentDTO
                    {
                        FullName = student.FullName,
                        Email = student.Email,
                        DateOfBirth = student.DateOfBirth,
                        Address = student.Address,
                        PhoneNumber = student.PhoneNumber
                    };

                    Console.WriteLine($"Update information for student: {student.FullName}");

                    Console.Write("Full name (Enter to keep it as is): ");
                    var name = Console.ReadLine();
                    if (!string.IsNullOrEmpty(name)) studentDto.FullName = name;

                    Console.Write("Email (Enter to keep): ");
                    var email = Console.ReadLine();
                    if (!string.IsNullOrEmpty(email)) studentDto.Email = email;

                    Console.Write("Date of birth (dd/MM/yyyy, Enter to keep it as is): ");
                    var dobStr = Console.ReadLine();
                    if (!string.IsNullOrEmpty(dobStr) && DateTime.TryParse(dobStr, out var dob))
                    {
                        studentDto.DateOfBirth = dob;
                    }

                    Console.Write("Address (Enter to keep it the same): ");
                    var address = Console.ReadLine();
                    if (!string.IsNullOrEmpty(address)) studentDto.Address = address;

                    Console.Write("Phone number (Enter to keep it as is): ");
                    var phone = Console.ReadLine();
                    if (!string.IsNullOrEmpty(phone)) studentDto.PhoneNumber = phone;

                    _studentService.UpdateStudent(id, studentDto);
                    Console.WriteLine("Updated successfully!");
                }
                else
                {
                    Console.WriteLine("No student found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
        }
        public void DeleteStudent()
        {
            Console.Write("\nEnter student ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _studentService.DeleteStudent(id);
                Console.WriteLine("Student deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
        }
        public void DisplayAllStudents()
        {
            var students = _studentService.GetAllStudents();
            Console.WriteLine("\nSTUDENT LIST");
            Console.WriteLine("ID\tFull name\t\tEmail\t\tDate of birth");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id}\t{student.FullName}\t{student.Email}\t{student.DateOfBirth:dd/MM/yyyy}");
            }
        }
    }
}
