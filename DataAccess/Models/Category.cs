using System.ComponentModel.DataAnnotations;
namespace DataAccess.Models
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
