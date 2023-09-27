using ProtoBuf;

namespace OnlineShop.CategoryData.Models.Interfaces
{
    [ProtoContract, ProtoInclude(3, typeof(Item))]
    public interface ItemAdd
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string? ItemName { get; set; }
    }
}
