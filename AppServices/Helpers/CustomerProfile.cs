using ApplicationModels.Requests;
using ApplicationModels.Responses;
using AutoMapper;
using DomainModels;

namespace ApplicationModels.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResult>();
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<UpdateCustomerRequest, Customer>();
        }
    }
}