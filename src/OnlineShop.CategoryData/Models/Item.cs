using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop.CategoryData.Interfaces;
using OnlineShop.CategoryData.Models.Interfaces;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.CategoryData.Models
{
    [ProtoContract]
    [Table("Item")]
    public class Item : IIdentifiable, ItemUpdate, ItemAdd
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string? ItemName { get; set; }
        [ProtoMember(3)]
        public ImageItem? Image { get; set; }

        [ProtoMember(4)]
        public ICollection<Category>? Category { get; set; }

        public void Create(Guid id, string name, Category category, ImageItem image)
        {
            Id = id;
            ItemName = name;
            Category.Add(category);
            Image = image;
        }

        public void AddCategory(Category category) => Category.Add(category);

        public void ChangeName(string name) => ItemName = name;

        public void ChangeImage(ImageItem image) => Image = image;

        public bool ReemoveCategory(Guid id)
        {
            var category = Category.Where(i => i.Id == id).First();

            return Category.Remove(category);
        }
    }
}
