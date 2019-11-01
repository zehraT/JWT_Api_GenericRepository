using Exam.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Exam.API.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public T Add(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            _dataContext.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            T entity = Get(id);
            _dataContext.Set<T>().Remove(entity);
            _dataContext.SaveChanges();

        }

        public T Get(int id)
        {
            return _dataContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dataContext.Set<T>().ToList();
        }

        public T Update(T entity)
        {
            _dataContext.Set<T>().Update(entity);
            _dataContext.SaveChanges();
            return entity;
        }
    }
}
