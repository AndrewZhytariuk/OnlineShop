using Microsoft.EntityFrameworkCore;
using OnlineShop.CategoryData.DbContexts;
using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Repository.Base;

namespace OnlineShop.CategoryData.Repository
{
    public class CategoryRepository : BaseRepo<Category>
    {
        private ItemsDbContext _context;
        public CategoryRepository(ItemsDbContext context) : base(context)
        {
            _context = context;
            Table = Context.Categories;
        }
    }
}
