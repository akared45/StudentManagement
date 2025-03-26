using StudentManagement.ApplicationLayer.Services;
using StudentManagement.DomainLayer.Entities;
using StudentManagement.InfrastructureLayer.Repository;
using StudentManagement.PresentationLayer.Controllers;
using StudentManagement.PresentationLayer.Views;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repository = new GenericRepository<Student>();
            var studentService = new StudentService(repository);
            var studentController = new StudentController(studentService);
            var menuView = new MenuView(studentController);
            menuView.ShowMenu();
        }
    }
}
