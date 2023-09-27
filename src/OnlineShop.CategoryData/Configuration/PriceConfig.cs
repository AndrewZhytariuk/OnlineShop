using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.CategoryData.Models;

namespace OnlineShop.CategoryData.Configuration
{
    public class PriceConfig : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Product).WithOne(p => p.Price);
        }
    }
}
