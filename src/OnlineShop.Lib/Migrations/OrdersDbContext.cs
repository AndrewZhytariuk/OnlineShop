using Microsoft.EntityFrameworkCore;
using OnlineShop.Lib.Serveces.ArticlesService.Models;
using OnlineShop.Lib.Serveces.OrdersService.Models;

namespace OnlineShop.Lib.Migrations
{
    public class OrdersDbContext : DbContext
    {
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<OrderedArticle> OrderedArticles { get; set; }
        public virtual DbSet<PriceList> PriceList { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderedArticle>()
                .HasOne<Order>(e => e.Order)
                .WithMany(e => e.Articles)
                .HasForeignKey(e => e.OrderId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
