using BusinessLogic.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IProductsService
    {
        //functional 
        List<CategoryDto> GetAllCategories();
        List<ProductDto> GetAll();
        ProductDto GetById(int? id);
        ProductDto GetEditProduct(int? id);
        void Create(CreateProductDto productDto);
        void Edit(ProductDto productDto);
        void Delete(int? id);
    }
}
