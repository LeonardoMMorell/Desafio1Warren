using AutoMapper;
using DomainModels;
using DomainServices.Dtos;

namespace DomainServices.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
