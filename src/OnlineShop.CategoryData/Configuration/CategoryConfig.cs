using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.CategoryData.Models;

namespace OnlineShop.CategoryData.Configuration
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Item).WithMany(p => p.Category);
            builder.Property(p => p.CategoryName).HasColumnName("Name").HasColumnName("CategoryName").HasMaxLength(128);
        }
    }
}