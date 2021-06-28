using API.Dtos;
using AutoMapper;
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductCategory, o => o.MapFrom(s => s.ProductCategory.CategoryName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            
        }
    }
}
