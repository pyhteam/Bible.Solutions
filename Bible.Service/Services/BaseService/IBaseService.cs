namespace Bible.Service.Services.BaseService
{
    public interface IBaseService<T, T1>
    {
        Task<IEnumerable<T1>> GetAllAsync();
        Task<T1> GetByIdAsync(int id);
        Task<bool> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity, int id);
        Task<int> DeleteAsync(int id);
    }
}
