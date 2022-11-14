using Bible.Database.Data;
using Bible.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bible.Service.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BibleContext dbContext;
        public Repository(BibleContext db)
        {
            dbContext = db;
        }

        public T Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            return entity;
        }

        public List<T> AddRange(List<T> list)
        {
            dbContext.Set<T>().AddRange(list);
            return list;
        }

        public IQueryable<T> AsQueryable()
        {
            return dbContext.Set<T>().AsQueryable();
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public T Get(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
