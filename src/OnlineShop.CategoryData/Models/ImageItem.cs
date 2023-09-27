using OnlineShop.CategoryData.Interfaces;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.CategoryData.Models
{
    [ProtoContract]
    public class ImageItem : IIdentifiable
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ForeignKey("Item")]
        public Guid? ItemId { get; set; }
        [NotMapped]
        public Item? Item { get; set; }
        [ProtoMember(2)]
        public string ImageUrl { get;  set; }

        public ImageItem() { }

        public ImageItem(Guid id, Item item, string url)
        {
            Id = id;
            Item = item;
            ImageUrl = url;
        }
        public void ChangeUrl(string url) => ImageUrl = url;
    }
}
