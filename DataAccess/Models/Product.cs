using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100,MinimumLength =2)]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0;
        [Url]
        public string? ImagePath { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        //navigagion property
        public Category? Category { get; set; }
     }
}
