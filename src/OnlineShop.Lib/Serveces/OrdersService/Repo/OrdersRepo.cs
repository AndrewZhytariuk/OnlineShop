using Microsoft.EntityFrameworkCore;
using OnlineShop.Lib.Migrations;
using OnlineShop.Lib.Repositories;
using OnlineShop.Lib.Serveces.OrdersService.Models;

namespace OnlineShop.Lib.Serveces.OrdersService.Repo
{
    public class OrdersRepo : BaseRepo<Order>
    {
        public OrdersRepo(OrdersDbContext context) : base(context)
        {
            Table = context.Order;
        }
        public override Task<Order> GetOneAsync(Guid id)
            => Task.Run(() => Table.Include(nameof(Order.Articles)).FirstOrDefault(entry => entry.Id == id));

        public override async Task<IEnumerable<Order>> GetAllAsync()
            => await Table.Include(nameof(Order.Articles)).ToListAsync();
    }
}
