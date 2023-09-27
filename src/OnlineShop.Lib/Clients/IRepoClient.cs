using OnlineShop.Lib.Common.Response;

namespace OnlineShop.Lib.Clients
{
    public interface IRepoClient<T>
    {

        Task<ServiceResponse<Guid>> Add(T entity);

        Task<ServiceResponse<IEnumerable<Guid>>> AddRange(IEnumerable<T> entities);

        Task<ServiceResponse<T>> Update(T entity);

        Task<ServiceResponse<object>> Remove(Guid entityId);

        Task<ServiceResponse<object>> RemoveRange(IEnumerable<Guid> entities);

        Task<ServiceResponse<T>> GetOne(Guid id);
        Task<ServiceResponse<IEnumerable<T>>> GetAll();

    }
}
