using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.DomainLayer.Entities;

namespace StudentManagement.DomainLayer.Interfaces
{
    public interface IStudentRepository<T> where T:class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
