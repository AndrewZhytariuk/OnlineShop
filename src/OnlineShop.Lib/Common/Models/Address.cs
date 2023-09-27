using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Lib.Common.Models
{
    [ProtoContract]
    [Table("Addresses")]
    public class Address
    {
        [ProtoMember(1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string Country { get; set; }
        [ProtoMember(3)]
        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string City { get; set; }
        [ProtoMember(4)]
        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string PostalCode { get; set; }
        [ProtoMember(5)]
        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string AddressLine1 { get; set; }
        [ProtoMember(6)]
        [Column(TypeName = "nvarchar(256)")]
        public string AddressLine2 { get; set; }
    }
}
