using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Product
    {
        /*
         Arrtibuts Validations:
        MinLength
        MaxLength
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
        //[Key]
        public int Id { get; set; }

        [Display(Name ="Назва продукту")]
        //[Required (ErrorMessage ="Не вказано назву товару")]
        //[StringLength(150,MinimumLength =2,ErrorMessage ="Мінімальна кількість симовлів => 2")]
        public string? Title { get; set; }

        [Display(Name = "Опис продукту")]
        public string? Description { get; set; }

        [Display(Name = "Ціна продукту")]
        //[Range(0,double.MaxValue,ErrorMessage ="Вихід за межі діапазону (1;100000)")]
        public decimal Price { get; set; } = 0;
       
        [Display(Name ="URL адреса зображення продукту")]
        [Url]
        public string? ImagePath { get; set; }

        [Display(Name = "Категорія продукту")]
        //[ForeignKey("Category")]
         public int CategoryId { get; set; }
        //navigagion property
        public Category? Category { get; set; }
     }
}
