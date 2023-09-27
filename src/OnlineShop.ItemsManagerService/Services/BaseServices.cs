using OnlineShop.ItemsManagerService.Services.Interfaces;
using OnlineShop.CategoryData.Repository.Base.Interfaces;

namespace OnlineShop.ItemsManagerService.Services
{
    public abstract class BaseServices<T> : IServeces<T> where T : class
    {
        public IRepos<T> BaseRepo { get; set; }
        public BaseServices(IRepos<T> baseRepo)
        {
            BaseRepo = baseRepo;
        }

        public virtual async Task<Guid> AddAsync(T entity) => await BaseRepo.AddAsync(entity);
        public Task<IEnumerable<Guid>> AddRangeAsync(IEnumerable<T> entries) => BaseRepo.AddRangeAsync(entries);

        public Task<int> DeleteAsync(Guid id) => BaseRepo.DeleteAsync(id);

        public Task<int> DeleteRangeAsync(IEnumerable<Guid> ids) => BaseRepo.DeleteRangeAsync(ids);

        public Task<IEnumerable<T>> GetAllAsync() => BaseRepo.GetAllAsync();

        public Task<T> GetOneAsync(Guid id) => BaseRepo.GetOneAsync(id);

        public Task<int> SaveAsync(T entry) => BaseRepo.SaveAsync(entry);
    }
}
