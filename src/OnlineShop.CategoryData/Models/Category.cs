using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.CategoryData.Interfaces;

namespace OnlineShop.CategoryData.Models
{
    [ProtoContract]
    [Table("Category")]
    public class Category : IIdentifiable
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string CategoryName { get; set; }
        [ForeignKey("Item")]
        public Guid? ItemId { get; set; }
        [ProtoMember(3)]
        [NotMapped]
        public Item? Item { get; set; }
        [ProtoMember(4)]
        public ICollection<Product>? Products { get; set; }

        public Category() { }

        public Category(Guid id, string name, Item item, Product product) {
            Id = id;
            CategoryName = name;
            Item = item;
            Products.Add(product);
        }

        public void ChangeName(string name) =>  CategoryName = name;
        public void ChangeItem (Item item) => Item = item;
        public void AddProduct(Product product) => Products.Add(product);
        public bool RemoveProduct(Guid id)
        {
            var product = Products.Where(i => i.Id == id).First();
            return Products.Remove(product);
        }
    }
}
