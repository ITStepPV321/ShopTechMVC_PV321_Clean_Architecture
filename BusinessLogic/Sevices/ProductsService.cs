using AutoMapper;
using BusinessLogic.DTOs;
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
        private readonly IMapper _mapper;
        public ProductsService(ShopTechMVCDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public void Create(CreateProductDto productDto)
        {
            //ProductDto=> Product
            //Product product = new Product() { 
            //    Title = productDto.Title,
            //    Description = productDto.Description,
            //    Price = productDto.Price,
            //    ImagePath= productDto.ImagePath,   
            //    CategoryId  = productDto.CategoryId,

            //};
            var product=_mapper.Map<Product>(productDto);   // ProductDto=>Product(Entity)
            _context.Products.Add(product);
            _context.SaveChanges(true);
        }

        public void Delete(int? id)
        {
            var productDto = GetById(id);
            if (productDto != null)
            { //ProductDto=> Product
            //Product product = new Product() { 
            //    Id=productDto.Id,
            //    Title = productDto.Title,
            //    Description = productDto.Description,
            //    Price = productDto.Price,
            //    ImagePath= productDto.ImagePath,   
            //    CategoryId  = productDto.CategoryId,

            //};
            var product= _mapper.Map<Product>(productDto);
                //_products.Remove(product);
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void Edit(ProductDto productDto)
        {
            var productOld = GetById(productDto.Id); 
            if (productOld != null)
            {
                //ProductDto=> Product
                //Product product = new Product()
                //{
                //    Title = productDto.Title,
                //    Description = productDto.Description,
                //    Price = productDto.Price,
                //    ImagePath = productDto.ImagePath,
                //    CategoryId = productDto.CategoryId,

                //};
                var product = _mapper.Map<Product>(productDto );
                _context.Products.Update(product);
                _context.SaveChanges();
            }
        }

        public List<ProductDto> GetAll()
        {
            var products= _context.Products.Include(p=>p.Category).ToList();
            //return products.Select(p => new ProductDto()
            //{Id= p.Id,
            //    Title = p.Title,
            //    Description = p.Description,
            //    Price = p.Price,
            //    ImagePath = p.ImagePath,
            //    CategoryId = p.CategoryId,
            //    CategoryName = p.Category?.Name
            //}).ToList();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public List<CategoryDto> GetAllCategories()
        {var categories= _context.Categories.ToList();
            return categories.Select(c => new CategoryDto()
            {    Id=c.Id,
                Name  = c.Name,    
                Description = c.Description,

            }).ToList();
        }

        public ProductDto? GetById(int? id)
        {
            Product? product = _context.Products.FirstOrDefault(product => product.Id == id);
            if (product == null) { 
            return null;
            }

            //ProductDto productDto=new ProductDto() { 
            //    Id=product.Id,
            //    Title   = product.Title,
            //    Description = product.Description,
            //    Price = product.Price,  
            //    ImagePath = product.ImagePath,
            //    CategoryId = product.CategoryId,
            //    CategoryName = product.Category?.Name   
            //};
            //return productDto;
            return _mapper.Map<ProductDto>(product);
        }

        public ProductDto GetEditProduct(int? id)
        {
            var productDto = GetById(id);
            if (productDto == null)
            {
                return null;
            }
            return productDto;
        }
    }
}
