using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.CategoryData.Models;

namespace OnlineShop.CategoryData.Configuration
{
    public class ImageProductConfig : IEntityTypeConfiguration<ImageProduct>
    {
        public void Configure(EntityTypeBuilder<ImageProduct> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Products).WithMany(p => p.Images);
        }
    }
}
