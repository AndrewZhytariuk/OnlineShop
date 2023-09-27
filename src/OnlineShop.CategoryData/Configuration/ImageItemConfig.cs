using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.CategoryData.Models;

namespace OnlineShop.CategoryData.Configuration
{
    public class ImageItemConfig : IEntityTypeConfiguration<ImageItem>
    {
        public void Configure(EntityTypeBuilder<ImageItem> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Item).WithOne(p => p.Image);
        }
    }
}
