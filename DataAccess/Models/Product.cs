using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Product
    {
        /*
         Arrtibuts Validations:
         Required
         StringLength
         Range
         Key
         Compare //Compare("Password")
         URL
         EmailAddress
         Phone
         CreditCard!
           RegularExpresion   => RegularExpresion(@"[A-Za-z0-9_.]+@[A-Za-z0-9.]+\.[A-Za-z]{2,4}")
         */
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="Не вказано назву товару")]
        [StringLength(100,MinimumLength =2,ErrorMessage ="Мінімальна кількість симовлів => 2")]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Range(1,100000,ErrorMessage ="Вихід за межі діапазону (1;100000)")]
        public decimal Price { get; set; } = 0;
        [Url]
        public string? ImagePath { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        //navigagion property
        public Category? Category { get; set; }
     }
}
