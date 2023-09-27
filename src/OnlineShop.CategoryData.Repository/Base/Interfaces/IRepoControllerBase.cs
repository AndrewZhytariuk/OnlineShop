using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.CategoryData.Repository.Base.Interfaces
{
    public interface IRepoControllerBase<T>
    {
        Task<IActionResult> Add(T entry);
        Task<IActionResult> AddTest(T entry);
        Task<IActionResult> Add(IEnumerable<T> entritis);
        Task<IActionResult> GetOne(Guid id);
        Task<IActionResult> GetAll();
        Task<IActionResult> Update(T entry);
        Task<IActionResult> Remove(Guid Id);
        Task<IActionResult> Remove(IEnumerable<T> entritis);

    }
}
