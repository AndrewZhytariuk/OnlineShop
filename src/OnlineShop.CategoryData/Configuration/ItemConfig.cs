using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.CategoryData.Models;

namespace OnlineShop.CategoryData.Configuration
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ItemName).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(128);
        }
    }
}
