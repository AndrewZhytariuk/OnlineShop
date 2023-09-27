using Microsoft.EntityFrameworkCore;
using OnlineShop.CategoryData.Configuration;
using OnlineShop.CategoryData.Models;

namespace OnlineShop.CategoryData.DbContexts
{
    public class ItemsDbContext : DbContext
    {
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<ImageItem> ImageItem { get; set; }
        public virtual DbSet<ImageProduct> ImageProduct { get; set; }
        public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ItemConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ImageItemConfig());
            modelBuilder.ApplyConfiguration(new ImageProductConfig());
            modelBuilder.ApplyConfiguration(new PriceConfig());
        }
    }
}
