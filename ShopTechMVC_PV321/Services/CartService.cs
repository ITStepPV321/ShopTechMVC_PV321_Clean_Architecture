using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using ShopTechMVC_PV321.Helpers;

namespace ShopTechMVC_PV321.Services
{
    public class CartService : ICartService
    {
        private readonly IProductsService _productsService;
        private readonly HttpContext? _httpContext;
        public CartService(IProductsService productsService, HttpContext httpContext)
        {
            _httpContext = httpContext; 
            _productsService = productsService;
        }

        public void Add(int id)
        {
           if(_productsService.GetById(id)==null) return ;
            List<int> idList = _httpContext.Session.GetObject<List<int>>("mycart");
            if (idList == null)
            {
                idList=new List<int>();

            }
            idList.Add(id); //add id of product to cart
            _httpContext.Session.SetObject<List<int>>("mycart", idList);
        }

        public IEnumerable<ProductDto> GetProduct()
        {
            List<int> idList = _httpContext.Session.GetObject<List<int>>("mycart");
            if (idList == null) idList = new List<int>();
            var products = idList.Select(id => _productsService.GetById(id));
            return products;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
