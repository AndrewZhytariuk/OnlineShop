using OnlineShop.CategoryData.Interfaces;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlineShop.Lib.Common.Enums.ApplicationEnum;

namespace OnlineShop.CategoryData.Models
{
    [ProtoContract]
    [Table("Price")]
    public class Price : IIdentifiable
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public double price { get; set; }
        [ProtoMember(3)]
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
        [ProtoMember(4)]
        [NotMapped]
        public Product? Product { get; set; }
        [ProtoMember(5)]
        public СurrencyEnum Currency { get; set; }

        public Price() { }

        public Price(Guid id, double price, Product product, СurrencyEnum currency)
        {
            Id = id;
            this.price = price;
            Product = product;
            Currency = currency;
        }

        public void ChangePrice(double price) => this.price = price;
        public void ChangeCurrency(СurrencyEnum сurrency) => this.Currency = сurrency;
    }
}
