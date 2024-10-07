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

            //Ігнорити властивість Image в процесі передачі даних на productDto
            CreateMap<Product, ProductDto>()
              .ForMember(productDto => productDto.Image, opt => opt.Ignore());

            CreateMap<Product, CreateProductDto>()
                         .ForMember(productDto => productDto.Image, opt => opt.Ignore());

            CreateMap<CreateProductDto, Product>();


        }
    }
}
