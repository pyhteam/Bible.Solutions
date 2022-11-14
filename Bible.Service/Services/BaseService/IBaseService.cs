namespace Bible.Service.Services.BaseService
{
    public interface IBaseService<T1, T2>
    {
        Task<IEnumerable<T2>> GetAllAsync();
        Task<T2> GetByIdAsync(int id);
        Task<bool> CreateAsync(T1 entity);
        Task<int> UpdateAsync(T1 entity, int id);
        Task<int> DeleteAsync(int id);
    }
}
