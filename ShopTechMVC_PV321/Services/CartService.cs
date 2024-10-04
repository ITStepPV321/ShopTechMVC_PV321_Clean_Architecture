using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using ShopTechMVC_PV321.Helpers;

namespace ShopTechMVC_PV321.Services
{
    public class CartService : ICartService
    {
        private readonly IProductsService _productsService;
        private readonly HttpContext _httpContext;
        public CartService(IProductsService productsService, IHttpContextAccessor contextAccessor)
        {
            _httpContext =  contextAccessor.HttpContext!; 
            _productsService = productsService;
        }
             

		
		public List<ProductDto> GetProducts()
        {
            List<int>? idList = _httpContext.Session.GetObject<List<int>>("mycart");
            if (idList == null) idList = new List<int>();
            var products = idList.Select(id => _productsService.GetById(id)).ToList();
            return products;
        }

		public void Add(int id)
		{
			if (_productsService.GetById(id) == null) return;
			List<int> idList = _httpContext?.Session.GetObject<List<int>>("mycart");
			if (idList == null)
			{
				idList = new List<int>();

			}
			idList.Add(id); //add id of product to cart
			_httpContext?.Session.SetObject<List<int>>("mycart", idList);
		}
		public void Remove(int id)
        {
            if (_productsService.GetById(id) == null) return;
            List<int>? idList = _httpContext?.Session.GetObject<List<int>>("mycart")!;
            if (idList == null) idList = new List<int>();
            idList.Remove(id);
            _httpContext?.Session.SetObject<List<int>>("mycart", idList);
        }

		public void Clear()
		{
			_httpContext.Session.Remove("mycart");

		}

	}
}
