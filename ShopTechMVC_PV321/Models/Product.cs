using System.ComponentModel.DataAnnotations;

namespace ShopTechMVC_PV321.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0;
    }
}
