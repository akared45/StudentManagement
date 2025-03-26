using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.DomainLayer.Entities;
using StudentManagement.DomainLayer.Interfaces;

namespace StudentManagement.InfrastructureLayer.Repository
{
    public class GenericRepository<T> : IStudentRepository<T> where T : class
    {
        private readonly List<T> _items = new List<T>();
        private int _nextId = 1;
        public void Add(T entity)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null && idProperty.CanWrite)
            {
                idProperty.SetValue(entity, _nextId++);
            }
            _items.Add(entity);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _items;
        }

        public T GetById(int id)
        {
            var property = typeof(T).GetProperty("Id");
            return _items.FirstOrDefault(item => (int)property.GetValue(item) == id);
        }

        public void Update(T entity)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty == null) return;

            var id = (int)idProperty.GetValue(entity);
            var existing = GetById(id);

            if (existing != null)
            {
                var properties = typeof(T).GetProperties();
                foreach (var property in properties)
                {
                    if (property.CanWrite)
                    {
                        var value = property.GetValue(entity);
                        property.SetValue(existing, value);
                    }
                }
            }
        }
    }
}
