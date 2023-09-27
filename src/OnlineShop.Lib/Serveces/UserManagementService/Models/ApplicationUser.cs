using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineShop.Lib.Common.Models;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Lib.Serveces.UserManagementService.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    [ProtoContract]
    public class ApplicationUser : IdentityUser
    {
        [ProtoMember(1)]
        [Column(TypeName = "nvarchar(256)")]
        public string FirstName { get; set; }
        [ProtoMember(2)]
        [Column(TypeName = "nvarchar(256)")]
        public string LastName { get; set; }
        [ProtoMember(3)]
        public Address DefaultAddress { get; set; }
        [ProtoMember(4)]
        public Address DeliveryAddress { get; set; }
    }
}
