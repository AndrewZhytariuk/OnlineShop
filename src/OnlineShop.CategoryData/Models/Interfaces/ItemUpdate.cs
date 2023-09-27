using Microsoft.AspNetCore.Mvc;
using ProtoBuf;

namespace OnlineShop.CategoryData.Models.Interfaces
{
    [ProtoContract, ProtoInclude(3, typeof(Item))]
    public interface ItemUpdate
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string? ItemName { get; set; }
    }
}
