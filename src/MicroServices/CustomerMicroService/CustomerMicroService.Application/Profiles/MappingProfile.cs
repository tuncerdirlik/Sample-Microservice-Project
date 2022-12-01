using AutoMapper;
using CustomerMicroService.Application.DTOs;
using CustomerMicroService.Domain;

namespace CustomerMicroService.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
        }
    }
}
