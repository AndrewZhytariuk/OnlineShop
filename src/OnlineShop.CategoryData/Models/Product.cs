using OnlineShop.CategoryData.Interfaces;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.CategoryData.Models
{
    [ProtoContract]
    [Table("Product")]
    public class Product : IIdentifiable
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string Description { get; set; }
        [ProtoMember(3)]
        public bool Published { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        [ProtoMember(4)]
        [NotMapped]
        public Category? Category { get; set; }
        [ForeignKey("Price")]
        public Guid PriceId { get; set; }
        [ProtoMember(5)]
        [NotMapped]
        public Price Price { get; set; }
        [ProtoMember(6)]
        public ICollection<ImageProduct>? Images { get; private set; }

        public Product() { }

        public Product (Guid id, string description, bool published, Category category, Price price, List<ImageProduct> images)
        {
            Id = id;
            Description = description;
            Published = published;
            Category = category;
            Price = price;
            Images = images;
        }

        public void ChangeDescription(string description) => Description = description;
        public void ChangePublished(bool published) => Published = published;
        public void ChangeCategory(Category category) => Category = category;
        public void ChangePrice(Price price) => Price = price;

        public void AddImages(ImageProduct images) => Images.Add(images);
        public bool RemoveImage(Guid id)
        {
            var image = Images.FirstOrDefault(x => x.Id == id);

            return Images.Remove(image);
        }
    }
}
