using AutoMapper;
using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Domain;

namespace ProductMicroservice.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();

        }
    }
}
