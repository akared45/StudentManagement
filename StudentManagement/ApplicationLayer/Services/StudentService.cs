using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.ApplicationLayer.DTOs;
using StudentManagement.ApplicationLayer.Interfaces;
using StudentManagement.DomainLayer.Entities;
using StudentManagement.DomainLayer.Interfaces;

namespace StudentManagement.ApplicationLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository<Student> _studentRepository;
        public StudentService(IStudentRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void AddStudent(StudentDTO studentDto)
        {
            var student = new Student
            {
                FullName = studentDto.FullName,
                Email = studentDto.Email,
                DateOfBirth = studentDto.DateOfBirth,
                Address = studentDto.Address,
                PhoneNumber = studentDto.PhoneNumber
            };
            _studentRepository.Add(student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.Delete(id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public void UpdateStudent(int id, StudentDTO studentDto)
        {
            var student = _studentRepository.GetById(id);
            if (student != null)
            {
                student.FullName = studentDto.FullName;
                student.Email = studentDto.Email;
                student.DateOfBirth = studentDto.DateOfBirth;
                student.Address = studentDto.Address;
                student.PhoneNumber = studentDto.PhoneNumber;
                _studentRepository.Update(student);
            }
        }
    }
}
