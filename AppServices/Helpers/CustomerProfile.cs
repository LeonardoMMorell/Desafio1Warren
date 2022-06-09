using AppServices.Dtos;
using AutoMapper;
using DomainModels;
using DomainServices.Dtos;
using System.Collections.Generic;

namespace DomainServices.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResult>();
            CreateMap<List<Customer>, CustomerResult>();
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<UpdateCustomerRequest, Customer>();

        }
    }
}
