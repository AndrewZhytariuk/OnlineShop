namespace OnlineShop.CategoryData.Repository.Base.Interfaces
{
    public interface IRepos<T>
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
