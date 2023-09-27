using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Lib.Repositories.Interfaces;
using OnlineShop.Lib.Serveces.ArticlesService.Models;
using System.Text.Json.Serialization;

namespace OnlineShop.Lib.Serveces.OrdersService.Models
{
    public class Order : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        public Guid AddressId { get; set; }

        [Required]
        [Column(TypeName = "uniqueidentifier")]
        public Guid UserId { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<OrderedArticle> Articles { get; set; }
    }
}
