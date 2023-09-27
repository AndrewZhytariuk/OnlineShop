using OnlineShop.CategoryData.Models;
using ProtoBuf;

namespace OnlineShop.CategoryData.Interfaces
{
    [ProtoContract, ProtoInclude(3, typeof(Item))]
    public interface IIdentifiable
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
    }
}
