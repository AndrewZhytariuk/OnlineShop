using OnlineShop.CategoryData.Interfaces;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.CategoryData.Models
{
    [ProtoContract]
    [Table("ImageProduct")]
    public class ImageProduct : IIdentifiable
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        [ProtoMember(2)]
        [NotMapped]
        public Product? Products { get; set; }
        [ProtoMember(3)]
        public string Url { get; set; }

        public ImageProduct() { }

        public ImageProduct(Guid id, Product products, string url) {
            Id = id;
            Url = url;
        }
        public void ChangeUrl(string url) => Url = url;
    }




}
