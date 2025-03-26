using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.ApplicationLayer.DTOs;
using StudentManagement.DomainLayer.Entities;

namespace StudentManagement.ApplicationLayer.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(StudentDTO studentDto);
        void UpdateStudent(int id, StudentDTO studentDto);
        void DeleteStudent(int id);
    }
}
