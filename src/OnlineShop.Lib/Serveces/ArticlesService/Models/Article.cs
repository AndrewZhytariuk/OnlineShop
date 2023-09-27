using OnlineShop.Lib.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Lib.Serveces.ArticlesService.Models
{
    public class Article : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(512)")]
        public string Description { get; set; }

        public ICollection<PriceList> PriceLists { get; set; }
    }
}
