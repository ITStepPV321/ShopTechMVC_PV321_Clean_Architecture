using System.ComponentModel.DataAnnotations;
namespace ShopTechMVC_PV321.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        //public ICollection<Product> Products { get; set; }
        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
