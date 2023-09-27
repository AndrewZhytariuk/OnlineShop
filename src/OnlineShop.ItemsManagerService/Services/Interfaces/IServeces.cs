namespace OnlineShop.ItemsManagerService.Services.Interfaces
{
    public interface IServeces<T>
    {
        Task<T> GetOneAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<Guid> AddAsync(T entity);
        Task<IEnumerable<Guid>> AddRangeAsync(IEnumerable<T> entries);
        Task<int> SaveAsync(T entry);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteRangeAsync(IEnumerable<Guid> ids);
    }
}
