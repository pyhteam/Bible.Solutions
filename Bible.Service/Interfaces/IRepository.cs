namespace Bible.Service.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(int id);
        List<T> AddRange(List<T> list);
    }
}
