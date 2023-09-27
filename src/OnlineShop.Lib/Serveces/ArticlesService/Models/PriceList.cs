using OnlineShop.Lib.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Lib.Serveces.ArticlesService.Models
{
    public class PriceList : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [ForeignKey("Article")]
        public Guid ArticleId { get; set; }

        [Column(TypeName = "numeric(12,4)")]
        public decimal Price { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ValidForm { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }
    }
}
