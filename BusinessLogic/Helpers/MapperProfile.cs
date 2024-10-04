using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Helpers
{
	public class MapperProfile:Profile
	{
        public MapperProfile()
        {
            //map Product=> ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(productDto=>productDto.CategoryName,
                           opt=>opt.MapFrom(product=>product.Category!.Name));
            //map ProductDto=> Product;
            CreateMap<ProductDto, Product>();


        }
    }
}
