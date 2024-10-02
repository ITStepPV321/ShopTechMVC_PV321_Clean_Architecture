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
        List<Category> GetAllCategories();
        List<Product> GetAll();
        Product GetById(int? id);
        Product GetEditProduct(int? id);
        void Create(Product product);
        void Edit(Product product);
        void Delete(int? id);
    }
}
