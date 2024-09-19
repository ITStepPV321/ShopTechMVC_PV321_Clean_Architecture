using DataAccess.Entities;

namespace ShopTechMVC_PV321.Models
{
    public class ProductCartViewModel
    {
        public Product Product { get; set; }
        public bool IsInCart { get; set; }
       // public int Count { get; set;} => mycart => {1: 2,2:3...}
        
    }
}
