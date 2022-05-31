using AutoMapper;
using DomainModels;
using DomainServices;
using DomainServices.Dtos;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerServices _customerServices;

        private readonly IMapper _mapper;

        public CustomerAppService(ICustomerServices customerServices, IMapper mapper)
        {
            _customerServices = customerServices;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDto> GetAll(Predicate<Customer> predicate = null)
        {
            var customer = _customerServices.GetAll();
            return _mapper.Map<IEnumerable<CustomerDto>>(customer);
        }

        public CustomerDto GetBy(Func<Customer, bool> predicate)
        {
            var customer = _customerServices.GetBy(predicate);
            return _mapper.Map<CustomerDto>(customer);
        }

        public int Add(CustomerDto model)
        {
            var customer =_mapper.Map<Customer>(model);
            return _customerServices.Add(customer);
        }

        public bool DeleteCustomer(int id)
        {
            return _customerServices.DeleteCustomer(id);
        }

        public bool Update(int id, CustomerDto modelUpdated)
        {
            var customer = _mapper.Map<Customer>(modelUpdated);
            return _customerServices.Update(id,customer);
        }

        public Customer GetById(int id)
        {
            return _customerServices.GetBy(x => x.Id == id);
        }

        public List<Customer> GetAllByFullName(string fullName)
        {
            return _customerServices.GetAll(x => x.FullName == fullName);
        }

        public List<Customer> GetAllByEmail(string email)
        {
            return _customerServices.GetAll(x => x.Email == email);
        }

        public List<Customer> GetAllByCpf(string cpf)
        {
            return  _customerServices.GetAll(x => x.Cpf == cpf);
        }
    }
}