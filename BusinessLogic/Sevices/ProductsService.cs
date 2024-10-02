using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Sevices
{
    public class ProductsService : IProductsService
    {
        private readonly ShopTechMVCDbContext _context;
        public ProductsService(ShopTechMVCDbContext context)
        {
            _context=context;
        }
        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges(true);
        }

        public void Delete(int? id)
        {
            var product = GetById(id);
            if (product != null)
            {
                //_products.Remove(product);
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void Edit(Product product)
        {
            var products = GetById(product.Id); 
            if (products != null)
            {
                _context.Products.Update(products);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            return _context.Products.Include(p=>p.Category).ToList();
        }

        public List<Category> GetAllCategories()
        {
           return _context.Categories.ToList();
        }

        public Product? GetById(int? id)
        {
            Product? product = _context.Products.FirstOrDefault(product => product.Id == id);
            if (product == null) { 
            return null;
            }
            return product;

        }

        public Product GetEditProduct(int? id)
        {
            var product = GetById(id);
            if (product == null)
            {
                return null;
            }
            return product;
        }
    }
}
